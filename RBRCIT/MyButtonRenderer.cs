using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightIdeasSoftware;
using System.Drawing;
using System.ComponentModel;

namespace RBRCIT
{
    public class MyButtonRenderer : ColumnButtonRenderer
    {
        [Category("Appearance")]
        [Description("which image of the imagelist to draw")]
        public int ImageIndex { get; set; }

        override protected void DrawImageAndText(Graphics g, Rectangle r)
        {
            base.DrawImageAndText(g, r);
            if (OLVSubItem.Text != "") g.DrawImage(ImageList.Images[ImageIndex], 
                r.X + Bounds.Width / 2- ImageList.Images[ImageIndex].Width/2, 
                r.Y + Bounds.Height / 2 - ImageList.Images[ImageIndex].Height/2);
        }


    }
}
