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
        private Player _currentPlayer;
        private Rectangle locRect;

        public Map(Player player)
        {
            InitializeComponent();
            panel1.Invalidate();
            _currentPlayer = player;
            _currentPlayer.PropertyChanged += MapPlayerOnPropertyChanged;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            

            foreach (Location loc in World.Locations)
            {
                locRect = new Rectangle(250 + (50 * loc.XRef), 250 + (50 * loc.YRef), 50, 50);

                e.Graphics.DrawRectangle(Pens.Black,locRect);

                if (loc == _currentPlayer.CurrentLocation)
                {
                    e.Graphics.DrawString(loc.Name, SystemFonts.DefaultFont, Brushes.Red, locRect);
                }
                else
                {
                    e.Graphics.DrawString(loc.Name, SystemFonts.DefaultFont, Brushes.Black, locRect);
                }

            }

        }

        private void MapPlayerOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == "CurrentLocation")
            {
                panel1.Refresh();
            }
        }
    }
}
