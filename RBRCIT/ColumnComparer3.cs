using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightIdeasSoftware;
using System.Windows.Forms;

namespace RBRCIT
{
    public class ColumnComparer3 : ColumnComparer
    {
        private ColumnComparer thirdComparer;


        public ColumnComparer3(OLVColumn col, SortOrder order, OLVColumn col2, SortOrder order2, OLVColumn col3, SortOrder order3)
            : base(col, order, col2, order2)
        {
            // There is no point in secondary sorting on the same column
            if (col3 != col2)
                this.thirdComparer = new ColumnComparer(col3, order3);
        }


        public int Compare(OLVListItem x, OLVListItem y)
        {
            int result = base.Compare(x, y);
            if (result == 0 && this.thirdComparer != null)
                result = this.thirdComparer.Compare(x, y);
            return result;
        }


    }
}
