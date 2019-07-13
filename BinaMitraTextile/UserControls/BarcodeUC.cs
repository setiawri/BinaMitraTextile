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
        public PictureBox Marker { get { return marker; } }

        public BarcodeUC()
        {
            InitializeComponent();
        }

        public void setup(BorderStyle borderstyle, Size controlSize, Size markerSize, Font font, Point markerLocation)
        {
            //setup marker. 
            splitContainer.SplitterDistance = markerSize.Width + splitContainer.SplitterWidth;
            marker.Size = markerSize;
            marker.Location = markerLocation;

            barcode.BorderStyle = BorderStyle.None;
            barcode.Font = font;

            this.Size = controlSize;
            this.BorderStyle = borderstyle;

            //minimum width of the barcode control inside the user control must be 120 or will throw error
            if (barcode.Width < 120)
                this.Width += 120 - barcode.Width;
        }

        public void encode(string data, BarcodeLib.TYPE type, bool includeLabel)
        {            
            barcode.encode(data, type, includeLabel);
        }
    }
}
