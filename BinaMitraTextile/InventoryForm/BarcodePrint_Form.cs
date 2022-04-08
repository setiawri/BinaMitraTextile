using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Printing;
using BarcodeLib;


namespace BinaMitraTextile.InventoryForm
{
    public partial class BarcodePrint_Form : Form
    {
        private List<BarcodeUC> listBarcodeUC;
        private int listBarcodeUCColumnCount = 0;
        private List<TextBox> listManualInputTexboxes;
        Margins _margins = new Margins(2,2,2,2);

        private DataTable _barcodeForReprint;
        private int _currentReprintIdx;
        private int currentVisibleLabelCount = 0;

        public BarcodePrint_Form()
        {
            InitializeComponent();

            Settings.setGeneralSettings(this);

            listBarcodeUCColumnCount = 5;
            listBarcodeUC = new List<BarcodeUC>() { 
                barcodeUC1, barcodeUC2, barcodeUC3, barcodeUC4, barcodeUC5,
                barcodeUC6, barcodeUC7, barcodeUC8, barcodeUC9, barcodeUC10,
                barcodeUC11, barcodeUC12, barcodeUC13, barcodeUC14, barcodeUC15,
                barcodeUC16, barcodeUC17, barcodeUC18, barcodeUC19, barcodeUC20,
                barcodeUC21, barcodeUC22, barcodeUC23, barcodeUC24, barcodeUC25,
                barcodeUC26, barcodeUC27, barcodeUC28, barcodeUC29, barcodeUC30,
                barcodeUC31, barcodeUC32, barcodeUC33, barcodeUC34, barcodeUC35,
                barcodeUC36, barcodeUC37, barcodeUC38, barcodeUC39, barcodeUC40, 
            };

            listManualInputTexboxes = new List<TextBox>() { 
                textBox1, textBox2, textBox3, textBox4, textBox5, 
                textBox6, textBox7, textBox8, textBox9, textBox10, 
                textBox11, textBox12, textBox13, textBox14, textBox15, 
                textBox16, textBox17, textBox18, textBox19, textBox20, 
                textBox21, textBox22, textBox23, textBox24, textBox25, 
                textBox26, textBox27, textBox28, textBox29, textBox30, 
                textBox31, textBox32, textBox33, textBox34, textBox35, 
                textBox36, textBox37, textBox38, textBox39, textBox40, 
            };            
        }

        private void BarcodePrint_Form_Shown(object sender, EventArgs e)
        {
            checkInputMode();
            txtSheetNo.Focus();
            setControlLayout();

            string lastSheetNo = Settings.LastSheetNo;
            if (!string.IsNullOrEmpty(lastSheetNo))
            {
                txtSheetNo.Text = lastSheetNo.ToString();
                txtStartHex.Text = Settings.LastStartHexNo;
            }

            in_Qty.Value = 5;
            in_ManualOffsetX.Value = Settings.OffsetX;
            in_ManualOffsetY.Value = Settings.OffsetY;
        }

        private void BarcodePrint_Form_Load(object sender, EventArgs e)
        {
            label1.Text = String.Format("Enter last printed {0} digit Hex number (must start with a letter).", Settings.itemBarcodeLength);
            txtStartHex.MaxLength = Settings.itemBarcodeLength + Settings.itemBarcodeMandatoryPrefix.Length;
            txtStartHex.Text = Settings.itemBarcodeMandatoryPrefix.ToLower();
            foreach (TextBox textbox in listManualInputTexboxes)
                textbox.Text = Settings.itemBarcodeMandatoryPrefix.ToLower();
            btnPrint.Enabled = false;
            clearBarcodes();
        }

        private void clearBarcodes()
        {
            foreach (BarcodeUC barcode in listBarcodeUC)
                barcode.Visible = false;

            btnPrint.Enabled = false;
        }

        private void clearManualInputs()
        {
            foreach (TextBox textbox in listManualInputTexboxes)
            {
                textbox.Text = "";
            }
        }

        private string _prefix = "";
        private string _lastHex = "";

        private bool isValidBarcode(TextBox textbox)
        {
            if (string.IsNullOrEmpty(textbox.Text))
                return false;

            if (textbox.Text.Length == Settings.itemBarcodeLength + Settings.itemBarcodeMandatoryPrefix.Length
                || textbox.Text.Length == Settings.itemBarcodeLength + Settings.itemBarcodeMandatoryPrefix.Length + 3) //for suffix [.XX]
            {
                _prefix = InventoryItem.getBarcodePrefix(textbox.Text.ToUpper());
                _lastHex = InventoryItem.getBarcodeWithoutPrefix(textbox.Text.ToUpper());

                if (_prefix != Settings.itemBarcodeMandatoryPrefix)
                {
                    Tools.hasMessage("Prefix must be character: '" + Settings.itemBarcodeMandatoryPrefix + "'");
                    return false;
                }
                else if (!Tools.isHexNumber(_lastHex))
                {
                    Tools.hasMessage("Must be hex number");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        private void generateBarcodes()
        {
            if(!chkPrintExisting.Checked)
            {
                string currentHex = _lastHex;
                foreach (BarcodeUC barcode in listBarcodeUC)
                {
                    if(barcode.Enabled)
                    {
                        currentHex = Tools.IncrementBarcode(currentHex, 1, Settings.itemBarcodeLength);
                        showBarcode(barcode, _prefix + currentHex);
                    }
                }
            }
            else
            {
                clearBarcodes();
                foreach (BarcodeUC barcode in listBarcodeUC)
                {
                    if(_currentReprintIdx < _barcodeForReprint.Rows.Count)
                    {
                        showBarcode(barcode, _prefix + _barcodeForReprint.Rows[_currentReprintIdx][InventoryItem.COL_DB_BARCODE].ToString());
                        _currentReprintIdx++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            btnPrint.Enabled = true;
        }

        private void setControlLayout()
        {
            int startX = -10 + in_ManualOffsetX.ValueInt;
            int startY = 0 + in_ManualOffsetY.ValueInt;
            int gapX = 7;
            int gapY = 24;
            int columnCount = 5;
            int rowCount = 8;

            BorderStyle borderStyle = BorderStyle.None;
            Size barcodeSize = new Size(145, 50); //minimum width of the barcode control inside the user control must be 120 or will throw error
            Size markerSize = new Size(14, 14);
            Point markerLocation = new Point(1, (barcodeSize.Height / 2) - (markerSize.Height / 2));
            Font barcodeFont = new Font(barcodeUC1.Barcode.Font.FontFamily, 6);

            if (chkLabel107.Checked)
            {
                startX = -7;
                startY = 0;
                gapX = 12;
                gapY = 24;
                columnCount = 4;
                rowCount = 7;
                barcodeSize = new Size(190, 50);
            }

            //set location of every barcode control
            currentVisibleLabelCount = 0;
            Point currentPoint = new Point(startX, startY);
            int currentColumnIndex = 0;
            int currentRowIndex = 0;
            int barcodeIndexCounter = 0;
            foreach (BarcodeUC barcode in listBarcodeUC)
            {
                barcode.Enabled = false;
                if (barcodeIndexCounter % listBarcodeUCColumnCount < columnCount)
                {
                    if (currentColumnIndex == columnCount)
                    {
                        currentColumnIndex = 0;
                        currentRowIndex++;
                    }

                    if (currentRowIndex < rowCount && currentColumnIndex <= columnCount)
                    {
                        barcode.Enabled = true;
                        barcode.setup(borderStyle, barcodeSize, markerSize, barcodeFont, markerLocation);
                        currentPoint = new Point(startX + (barcodeSize.Width * currentColumnIndex) + (gapX * currentColumnIndex), startY + (barcodeSize.Height * currentRowIndex) + (gapY * currentRowIndex));
                        barcode.Location = currentPoint;
                        currentVisibleLabelCount++;
                        currentColumnIndex++;
                    }
                }
                else
                {
                    currentPoint = new Point(currentPoint.X + gapX + barcodeSize.Width, currentPoint.Y);
                    barcode.Location = currentPoint;
                }

                barcodeIndexCounter++;
            }

            //set size of printable panel
            pnlPrint.Width = (columnCount * barcodeSize.Width) + (gapX * columnCount);
            pnlPrint.Height = (rowCount * barcodeSize.Height) + (gapY * rowCount);
        }

        private void setTextboxVisibilityForLabel107(bool show)
        {
            textBox5.Visible = show;
            textBox10.Visible = show;
            textBox15.Visible = show;
            textBox20.Visible = show;
            textBox25.Visible = show;
            textBox30.Visible = show;
            textBox35.Visible = show;

            textBox36.Visible = show;
            textBox37.Visible = show;
            textBox38.Visible = show;
            textBox39.Visible = show;
            textBox40.Visible = show;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (in_Qty.ValueInt > 0)
                for(int i=0; i< in_Qty.ValueInt; i++)
                {
                    if (LIBUtil.Util.print(chkShowPrintDialog.Checked, chkShowPrintDialog.Checked, pnlPrint))
                    {
                        btnNext.PerformClick();

                        //save for next print session
                        Settings.LastSheetNo = txtSheetNo.Text;
                        Settings.LastStartHexNo = txtStartHex.Text;
                        Settings.OffsetX = in_ManualOffsetX.ValueInt;
                        Settings.OffsetY = in_ManualOffsetY.ValueInt;
                    }
                }
        }

        private void txtStartHex_TextChanged(object sender, EventArgs e)
        {
            if(isValidBarcode(txtStartHex))
                generateBarcodes();
        }

        private void setStartHexToCurrentReprintBarcode()
        {
            if (_currentReprintIdx < _barcodeForReprint.Rows.Count)
                txtStartHex.Text = Settings.itemBarcodeMandatoryPrefix + _barcodeForReprint.Rows[_currentReprintIdx][InventoryItem.COL_DB_BARCODE].ToString();
            else
                txtStartHex.Text = "";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (isValidBarcode(txtStartHex))
            {
                if (chkPrintExisting.Checked)
                {
                    setStartHexToCurrentReprintBarcode(); 
                }
                else
                    txtStartHex.Text = _prefix + Tools.IncrementBarcode(_lastHex, currentVisibleLabelCount, Settings.itemBarcodeLength);

                if (Tools.isNumeric(txtSheetNo.Text))
                    txtSheetNo.Text = (Convert.ToInt16(txtSheetNo.Text) + 1).ToString();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (isValidBarcode(txtStartHex))
            {
                if (chkPrintExisting.Checked)
                {
                    if (_currentReprintIdx > listBarcodeUC.Count * 2)
                        _currentReprintIdx -= listBarcodeUC.Count * 2;
                    else
                        _currentReprintIdx = 0;
                    setStartHexToCurrentReprintBarcode();
                }
                else
                    txtStartHex.Text = _prefix + Tools.IncrementBarcode(_lastHex, currentVisibleLabelCount * -1, Settings.itemBarcodeLength); 
    
                if (Tools.isNumeric(txtSheetNo.Text))
                    txtSheetNo.Text = (Convert.ToInt16(txtSheetNo.Text) - 1).ToString();
            }
        }

        private void chkManualInput_CheckedChanged(object sender, EventArgs e)
        {
            checkInputMode();
        }

        private void checkInputMode()
        {
            if (chkManualInput.Checked)
            {
                in_Qty.Value = 1;
                pnlManualInput.Visible = true;
                pnlAutomaticInput.Enabled = false;
                clearManualInputs();
                clearBarcodes();
                setTextboxVisibilityForLabel107(!chkLabel107.Checked);
            }
            else
            {
                pnlManualInput.Visible = false;
                pnlAutomaticInput.Enabled = true;
                clearBarcodes();
                if (isValidBarcode(txtStartHex))
                    generateBarcodes();
            }
        }

        private void manualInput_TextChanged(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            int cursorPosition = textbox.SelectionStart;

            int index = listManualInputTexboxes.IndexOf(textbox);
            if (textbox.Text.Length > 0 || textbox.Text == StockOpname_Form.BARCODE_RESET || isValidBarcode(textbox))
            {
                if (textbox.Text != textbox.Text.ToUpper())
                    textbox.Text = textbox.Text.ToUpper();
                else
                {
                    try
                    {
                        showBarcode(listBarcodeUC[index], textbox.Text);
                    } catch (Exception ex) { LIBUtil.Util.displayMessageBoxError(ex.Message); }

                    btnPrint.Enabled = true;
                }
            }
            else if (listBarcodeUC[index].Location.X + listBarcodeUC[index].Width > 0) //barcode is not out of print panel
            {
                hideBarcode(listBarcodeUC[index]);

                btnPrint.Enabled = false;
                foreach (BarcodeUC barcode in listBarcodeUC)
                {
                    if (barcode.Visible)
                    {
                        btnPrint.Enabled = true;
                        return;
                    }
                }
            }
            textbox.SelectionStart = cursorPosition; //place cursor at the original index
        }

        private void showBarcode(BarcodeUC barcode, string data)
        {
            barcode.encode(data, TYPE.CODE128, true);
            barcode.Visible = true;
        }

        private void hideBarcode(BarcodeUC barcode)
        {
            barcode.Visible = false;
        }

        private void chkPrintExisting_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkPrintExisting.Checked)
            {
                txtStartHex.Enabled = true;
                txtStartHex.Text = Settings.itemBarcodeMandatoryPrefix;
                txtStartHex.Focus();
                txtStartHex.SelectionStart = txtStartHex.Text.Length;
            }
            else
            {
                txtStartHex.Enabled = false;
                _currentReprintIdx = 0;
                _barcodeForReprint = InventoryItem.getExistingBarcodesForReprinting(null,null);
                if (_barcodeForReprint.Rows.Count > 0)
                {
                    txtStartHex.Text = Settings.itemBarcodeMandatoryPrefix + _barcodeForReprint.Rows[0][InventoryItem.COL_DB_BARCODE].ToString();
                }
                else
                {
                    Tools.showError("No existing barcode to reprint");
                }
            }
        }

        private void in_ManualOffsetX_ValueChanged(object sender, EventArgs e)
        {
            setControlLayout();
        }

        private void in_ManualOffsetY_ValueChanged(object sender, EventArgs e)
        {
            setControlLayout();
        }

        private void chkLabel107_CheckedChanged(object sender, EventArgs e)
        {
            setControlLayout();
            checkInputMode();
        }
    }
}
