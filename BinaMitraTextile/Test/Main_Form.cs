using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using LIBUtil;

namespace BinaMitraTextile.Test
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();

            //populatePanel1();
            //populatePanel2();

            addStatusContextMenu(label3);
            addStatusContextMenu(label4);
            addStatusContextMenu(label7);
            addStatusContextMenu(label8);
            addStatusContextMenu(label1);
            tabControl1.Visible = false;
        }


        #region Panel2 

        private void populatePanel2()
        {

            //generate list of barcodes from 00001 to 00796
            string barcode = "00001";
            StringBuilder sb = new StringBuilder();
            sb.Append(barcode);
            while(barcode != "007C9")
            {
                barcode = Tools.IncrementBarcode(barcode, 1, barcode.Length);
                sb.Append("," + barcode);
            }
            List<string> barcodeList = sb.ToString().Split(',').ToList();

            //get data from database
            DataTable dt = DBUtil.getData(string.Format(@"
	            SELECT barcode AS Barcode, 
			            Inventory.code AS CODE,
                        item_length AS Qty, 
			            ProductWidths.product_width_name AS 'lebar (cm)', 
			            Products.name_store AS Product,
			            Grades.grade_name AS Grade,
			            Colors.color_name AS Warna
	            FROM ((((((InventoryItems 
		            LEFT OUTER JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
		            ) LEFT OUTER JOIN Products ON Products.id = Inventory.product_id
		            ) LEFT OUTER JOIN ProductWidths ON ProductWidths.id = Inventory.product_width_id
		            ) LEFT OUTER JOIN LengthUnits ON LengthUnits.id = Inventory.length_unit_id
		            ) LEFT OUTER JOIN Grades ON Grades.id = Inventory.grade_id
		            ) LEFT OUTER JOIN Colors ON Colors.id = Inventory.color_id
		            ) LEFT OUTER JOIN ProductPrices
			            ON (ProductPrices.product_id = Inventory.product_id
				            AND ProductPrices.grade_id = Inventory.grade_id
				            AND ProductPrices.product_width_id = Inventory.product_width_id
				            AND ProductPrices.length_unit_id = Inventory.length_unit_id)"));
            Tools.setDataTablePrimaryKey(dt, "Barcode");

            List<string> missingBarcodeList = new List<string>();
            DataTable dtMissing = new DataTable();
            Tools.addColumn<string>(dtMissing, "barcode", null);
            for (int i = barcodeList.Count - 1; i > -1; i--)
            {
                if (!dt.Rows.Contains(barcodeList[i]))
                    dtMissing.Rows.Add(barcodeList[i]);
            }

                //display in gridview
            gridBarcodesNotInDB.DataSource = dtMissing;
            
                //SELECT barcode AS Barcode, 
                //        Inventory.code AS CODE,
                //        item_length AS Qty, 
                //        ProductWidths.product_width_name AS 'lebar (cm)', 
                //        Products.name_store AS Product,
                //        Grades.grade_name AS Grade,
                //        Colors.color_name AS Warna

            //remove from list

            
                //SELECT InventoryItems.id,inventory_id,item_length, barcode,InventoryItems.notes,
                //        Inventory.code AS inventory_code,
                //        ProductWidths.product_width_name AS product_width_name, 
                //        Products.name_store AS product_name_store,
                //        ProductPrices.tag_price AS tag_price,
                //        LengthUnits.length_unit_name AS length_unit_name,
                //        Grades.grade_name AS grade_name,
                //        Colors.color_name AS color_name
        }

        #endregion Panel2 


        #region Tab3

        private void btnAddCustomerInfoToSalesTable_Click(object sender, EventArgs e)
        {
            foreach (DataRow sale in Sale.get().Rows)
            {
                string sql = String.Format(@"UPDATE Sales SET customer_info = '{0}' WHERE id='{1}'", new Customer((Guid)sale[Sale.COL_CUSTOMER_ID]).Info, (Guid)sale[Sale.COL_ID]);
                using (SqlCommand cmd = new SqlCommand(sql, DBConnection.ActiveSqlConnection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        #endregion Tab3


        #region Tab4
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataRow obj in Sale.get().Rows)
            {
                Guid id = (Guid)obj[Sale.COL_ID];
                decimal saleAmount = Convert.ToDecimal(obj[Sale.COL_SALEAMOUNT]);
                //SalePayment.submitNew(id, PaymentMethod.Cash, saleAmount, "Submitted programmatically");
            }
        }

        private void btnAddBuyValue_Click(object sender, EventArgs e)
        {
            decimal[] buyValues = { 
                                      0, //code=1
                                      1
                                  };

            string sql = "";
            for (int i = 0; i < buyValues.Length; i++)
            {
                sql += String.Format(@"UPDATE Inventory SET buy_price = {0} WHERE code={1};", buyValues[i], i + 1);
            }

            if(!string.IsNullOrEmpty(sql.Trim()))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(sql, DBConnection.ActiveSqlConnection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Update done");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error on update: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No update");
            }
        }

        #endregion Tab4

        #region Tab Scanner Listener

        DateTime _lastKeystroke = new DateTime(0);
        List<char> _barcode = new List<char>(10);

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblScannerListener.Text = "";
            //MessageBox.Show("hmm");
            //_barcode.Add(e.KeyChar);
            //string msg = new String(_barcode.ToArray());
            //lblScannerListener.Text = msg;
            //return;

            // check timing (keystrokes within 100 ms)
            TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
            if (elapsed.TotalMilliseconds > 100)
                _barcode.Clear();

            // record keystroke & timestamp
            _barcode.Add(e.KeyChar);
            _lastKeystroke = DateTime.Now;

            // process barcode
            if (e.KeyChar == 13 && _barcode.Count > 0)
            {
                string msg = new String(_barcode.ToArray());
                MessageBox.Show(msg);
                _barcode.Clear();
            }
        }

        #endregion Tab Scanner Listener

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new Test.TestConnection(Convert.ToInt16(txtTimeoutLength.Text), Convert.ToInt16(txtConnectionTime.Text)));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updateReceivedDate();
        }

        private void updateReceivedDate()
        {
            string path = @"C:\Ricky\COMPANIES\CV Bina Mitra\Financial + Inventory\Database\Inventory.xlsx";
            if (!System.IO.File.Exists(path))
            {
                Tools.showError("Invalid Excel file path");
                return;
            }

            Microsoft.Office.Interop.Excel.ApplicationClass appExcel = new Microsoft.Office.Interop.Excel.ApplicationClass();
            Microsoft.Office.Interop.Excel.Workbook workbook = appExcel.Workbooks.Open(path, true, true);
            Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)appExcel.ActiveWorkbook.ActiveSheet;
            
            string sql = "";
            foreach (Microsoft.Office.Interop.Excel.Range row in sheet.UsedRange.Rows)
            {
                if (Tools.isNumeric(((Microsoft.Office.Interop.Excel.Range)row.Cells[1, 1]).Value.ToString()))
                {
                    object date = ((Microsoft.Office.Interop.Excel.Range)row.Cells[1, 3]).Value;
                    if(date != null) 
                        sql += string.Format("UPDATE Inventory SET receive_date='{0}' WHERE code={1};",
                            Convert.ToDateTime(date.ToString()), 
                            ((Microsoft.Office.Interop.Excel.Range)row.Cells[1, 1]).Value.ToString());
                }
            }

            //close workbook
            System.Runtime.InteropServices.Marshal.ReleaseComObject(appExcel);
            workbook = null;
            sheet = null;

            updateDB(sql);
        }

        private void updateBuyPrice()
        {
            decimal[] array = {
                              433,(decimal)7808.40,
                              434,4750
                          };

            string sql = "";
            for (int i = 0; i < array.Length; i++)
            {
                sql += string.Format("UPDATE Inventory SET buy_price={1} WHERE code={0};", Convert.ToInt16(array[i]), array[i + 1]);
                i++;
            }

            updateDB(sql);
        }

        private void updateDB(string sql)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, DBConnection.ActiveSqlConnection))
                {
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Update done");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on update: " + ex.Message);
            }
        }

        private void iclb_Test_Item_Checked(object sender, EventArgs e)
        {
            MessageBox.Show("aaa");
        }


        /*
         * DRAG AND DROP CONTROL
         */

        //private Control activeControl;

        //void button1_MouseDown(object sender, MouseEventArgs e)
        //{
        //    activeControl = sender as Control;

        //    Bitmap bitmap = new Bitmap(activeControl.Width, activeControl.Height);
        //    activeControl.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
        //    PictureBox pb = new PictureBox() { Image = bitmap };
        //    //Cursor = new Cursor(((Bitmap)pb.Image).GetHicon());

        //    activeControl.DoDragDrop(activeControl, DragDropEffects.All);
        //}

        //void panel_DragEnter(object sender, DragEventArgs e)
        //{
        //    e.Effect = DragDropEffects.All;
        //}

        //void panel_DragDrop(object sender, DragEventArgs e)
        //{
        //    //activeControl.Parent = (Control)sender;

        //    Button control = (Button)e.Data.GetData(typeof(Button));
        //    FlowLayoutPanel _source = (FlowLayoutPanel)control.Parent;
        //    FlowLayoutPanel targetContainer = (FlowLayoutPanel)sender;

        //    // Add control to panel
        //    targetContainer.Controls.Add(control);
        //    //control.Size = new Size(targetContainer.Width, 50);

        //    // Reorder
        //    Point p = targetContainer.PointToClient(new Point(e.X, e.Y));
        //    var item = targetContainer.GetChildAtPoint(p);
        //    int index = targetContainer.Controls.GetChildIndex(item, false);
        //    targetContainer.Controls.SetChildIndex(control, index);

        //    // Invalidate to paint!
        //    targetContainer.Invalidate();

        //    MessageBox.Show(string.Format("x:{0}, y:{1}", p.X, p.Y));
        //}
        
        private void control_MouseDown(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            if (e.Button == MouseButtons.Left)
            {
                this.DoDragDrop(control.Name, DragDropEffects.Move);
            }
            else if (e.Button == MouseButtons.Right)
            {
                control.ContextMenuStrip.Opening += (s, i) =>
                {
                    if (control.Parent != flpDestination)
                        i.Cancel = true;
                };
            }
        }
            private void panel_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(string)))
                return;

            var name = e.Data.GetData(typeof(string)) as string;
            var control = this.Controls.Find(name, true).FirstOrDefault();
            if (control != null)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void panel_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(string)))
                return;

            var name = e.Data.GetData(typeof(string)) as string;
            var control = this.Controls.Find(name, true).FirstOrDefault();
            if (control != null)
            {
                FlowLayoutPanel targetContainer = (FlowLayoutPanel)sender;
                
                //move control
                control.Parent = targetContainer;

                // Reorder
                Point p = targetContainer.PointToClient(new Point(e.X, e.Y));
                var item = targetContainer.GetChildAtPoint(p);
                int index = targetContainer.Controls.GetChildIndex(item, false);
                targetContainer.Controls.SetChildIndex(control, index);
                targetContainer.Invalidate();
            }
        }

        public void addStatusContextMenu(Label label)
        {
            label.ContextMenuStrip = new ContextMenuStrip();
            foreach (POItemStatus status in Tools.GetEnumItems<POItemStatus>())
                label.ContextMenuStrip.Items.Add(new ToolStripMenuItem(Tools.GetEnumDescription(status), null, applyFilter_Click));
        }

        public void applyFilter_Click(object sender, EventArgs args)
        {
        }
    }
}
