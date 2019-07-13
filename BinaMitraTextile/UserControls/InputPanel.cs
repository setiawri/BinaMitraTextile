using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaMitraTextile.UserControls
{
    public class InputPanel : UserControl
    {
        public virtual void reset() { }

        public virtual void focus() { }

        public virtual void setAsDefaultTabbing() { }

        public virtual void setLabelText(string text) { }
    }
}
