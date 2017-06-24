using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Engine;
using System.Drawing.Drawing2D;

namespace SuperAdventure
{
    public partial class Map : Form
    {
        public Map()
        {
            InitializeComponent();
            panel1.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Location loc in World.Locations)
            {
                e.Graphics.DrawRectangle(Pens.Black,
                    250 + (50 * loc.XRef),
                    250 + (50 * loc.YRef), 50, 50);
                
                e.Graphics.DrawString(loc.Name, SystemFonts.DefaultFont, Brushes.Red, new RectangleF(250 + (50 * loc.XRef), 250 + (50 * loc.YRef), 50, 50));

            }

        }
    }
}
