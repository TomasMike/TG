using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TG
{
    public class MapPanel : Panel
    {
        public MapPanel()
        {
            this.BackColor = Color.CadetBlue;
        }

        public void RefreshMapLayout()
        {
            var locGrid = new List<Tuple<LocationCardControl, int, int>>();//x,y
            foreach (LocationCardControl loc in this.Controls)
            {
                var n = locGrid.FirstOrDefault(_ => _.Item1.NorthDirectionKey == loc.LocationNumber);
                if (n != null) locGrid.Add(new Tuple<LocationCardControl, int, int>(loc,n.Item2,n.Item3-1));
                else
                {
                    n = locGrid.FirstOrDefault(_ => _.Item1.EastDirectionKey == loc.LocationNumber);
                    if (n != null) locGrid.Add(new Tuple<LocationCardControl, int, int>(loc, n.Item2+1, n.Item3));
                    else
                    {
                        n = locGrid.FirstOrDefault(_ => _.Item1.SouthDirectionKey == loc.LocationNumber);
                        if (n != null) locGrid.Add(new Tuple<LocationCardControl, int, int>(loc, n.Item2, n.Item3 + 1));
                        else
                        {
                            n = locGrid.FirstOrDefault(_ => _.Item1.WestDirectionKey == loc.LocationNumber);
                            if (n != null) locGrid.Add(new Tuple<LocationCardControl, int, int>(loc, n.Item2-1, n.Item3));
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

            foreach (var l in locGrid)
            {
                var col = mostLeftColIndex -  l.Item2;
                var row = mostTopRowIndex - l.Item3;

                l.Item1.Location = new Point(col * l.Item1.Width + mapPadding,row*l.Item1.Height+mapPadding);
            }

        }
    }
}