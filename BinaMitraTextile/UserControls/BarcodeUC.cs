using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaMitraTextile
{
    public partial class BarcodeUC : UserControl
    {
        public BarcodeLib.BarcodeControl Barcode { get { return barcode; } }
        public PictureBox Marker { get { return pbMarker; } }

        public BarcodeUC()
        {
            InitializeComponent();
        }

        public void setup(BorderStyle borderstyle, Size barcodeSize, Size markerSize, Font font, Point markerLocation)
        {
            barcode.BorderStyle = borderstyle;
            barcode.Font = font;
            this.Size = barcodeSize;
            //barcode.Size = barcodeSize;
            //this.Size = new Size(barcodeSize.Width, barcodeSize.Height + pbMarker.Height + 2 * markerYOffset);

            pbMarker.Location = new Point(20, this.Height - pbMarker.Height);

            //minimum width of the barcode control inside the user control must be 120 or will throw error
            if (barcode.Width < 120)
                this.Width += 120 - barcode.Width;

            barcode.BringToFront(); //for unknown reason, if barcode is on top of marker, the marker gets printed. otherwise, marker is hidden under barcode when printed
        }

        public void encode(string data, BarcodeLib.TYPE type, bool includeLabel)
        {            
            barcode.encode(data, type, includeLabel);
        }
    }
}
