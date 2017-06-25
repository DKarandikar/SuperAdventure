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
        private Rectangle LocationRect;
        private List<Point> TrianglePoints = new List<Point>();
        private const int WIDTH = 70;
        private const int BORDER = 20;
        private const int CENTER_X = 200;
        private const int CENTER_Y = 300;

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
                
                LocationRect = new Rectangle(CENTER_X + ((WIDTH + BORDER) * loc.XRef), CENTER_Y + ((WIDTH + BORDER) * loc.YRef), WIDTH, WIDTH);

                e.Graphics.DrawRectangle(Pens.Black,LocationRect);

                if (loc == _currentPlayer.CurrentLocation)
                {
                    e.Graphics.DrawString(loc.Name, SystemFonts.DefaultFont, Brushes.Red, LocationRect);
                }
                else
                {
                    e.Graphics.DrawString(loc.Name, SystemFonts.DefaultFont, Brushes.Black, LocationRect);
                }

                if (loc.LocationToNorth != null)
                {
                    TrianglePoints.Add(new Point(LocationRect.X , LocationRect.Y));
                    TrianglePoints.Add(new Point(LocationRect.X + WIDTH, LocationRect.Y));
                    TrianglePoints.Add(new Point(LocationRect.X + WIDTH/2, LocationRect.Y - BORDER));

                    e.Graphics.FillPolygon(Brushes.Black, TrianglePoints.ToArray());
                    TrianglePoints.Clear();
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
