using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaMitraTextile
{
	public enum Companies
	{
		CV,
		Pribadi
	};

	public enum FormMode
    {
        Search,
        New,
        Update,
        Browse
    };

    public enum MasterDataColumnWidth
    {
        Hidden = -1,
        Fit = 0,
        Fill = Int16.MaxValue
    };

    class Enums
    {
    }
}
