using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TG.Forms;

namespace TG
{
    public class MapPanel : Panel
    {
        public  IEnumerable<LocationCardControl> LocationCards => Controls.Cast<LocationCardControl>();
        
        public MapPanel()
        {
            Location = new Point(10, 10);
            Size = new Size(50,50);
            BackColor = Color.CadetBlue;
            TabIndex = 1;
        }


        public void RefreshMapLayout()
        {
            this.SuspendLayout();
            var locGrid = new List<Tuple<LocationCardControl, int, int>>();//x,y
            foreach (LocationCardControl loc in this.Controls)
            {
                var n = locGrid.FirstOrDefault(_ => _.Item1.NorthDirectionKey == loc.LocationNumber);
                if (n != null) locGrid.Add(new Tuple<LocationCardControl, int, int>(loc, n.Item2, n.Item3 - 1));
                else
                {
                    n = locGrid.FirstOrDefault(_ => _.Item1.EastDirectionKey == loc.LocationNumber);
                    if (n != null) locGrid.Add(new Tuple<LocationCardControl, int, int>(loc, n.Item2 + 1, n.Item3));
                    else
                    {
                        n = locGrid.FirstOrDefault(_ => _.Item1.SouthDirectionKey == loc.LocationNumber);
                        if (n != null) locGrid.Add(new Tuple<LocationCardControl, int, int>(loc, n.Item2, n.Item3 + 1));
                        else
                        {
                            n = locGrid.FirstOrDefault(_ => _.Item1.WestDirectionKey == loc.LocationNumber);
                            if (n != null) locGrid.Add(new Tuple<LocationCardControl, int, int>(loc, n.Item2 - 1, n.Item3));
                            else
                            {
                                //this is the first card
                                locGrid.Add(new Tuple<LocationCardControl, int, int>(loc, 0, 0));
                            }
                        }
                    }
                }
            }

            var mostTopRowIndex = locGrid.Min(_ => _.Item3);
            var mostLeftColIndex = locGrid.Min(_ => _.Item2);
            var mapPadding = 10;
            var tileMargin = 0;

            foreach (var l in locGrid)
            {
                var col = l.Item2 - mostLeftColIndex;
                var row = l.Item3 - mostTopRowIndex;

                l.Item1.Location = new Point(col * l.Item1.Width + mapPadding + (col - 1) * tileMargin, row * l.Item1.Height + mapPadding + ((row - 1) * tileMargin));
            }

            this.PerformLayout();
        }

        public void AddMissingMapTiles()
        {
            foreach (var l in LocationCards.Where(_ => _.MenhirValue != null))
            {
                foreach (var s in l.GetNeighbourLocationNumbers())
                {
                    if (LocationCards.FirstOrDefault(_ => _.LocationNumber == s) == null)
                    {
                        AddLocationCardToMap(s);
                    }
                }
            }
        }

        public void ActivateMenhir(LocationCardControl lcc, uint? value)
        {
            lcc.MenhirValue = value;
            AddMissingMapTiles();
        }

        public void AddLocationCardToMap(string locationNumber, int? alsoActivateMenhirWithValue = null)
        {
            var l = LocationsLib.Locations.FirstOrDefault(_ => _.LocationNumber == locationNumber);
            if(l == null)
                throw  new Exception("wanted to add location that doesnt exist or isnt settuped.");

            this.Controls.Add(l);
            if(alsoActivateMenhirWithValue != null)
                ActivateMenhir(l,(uint?)alsoActivateMenhirWithValue);

            AddMissingMapTiles();
            RefreshMapLayout();
        }
    }
}