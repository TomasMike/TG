using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TG.CoreStuff;
using TG.Forms;
using TG.HelpersUtils;
using TG.Libs;

namespace TG.CustomControls
{
    public class MapPanel : Panel
    {
        public IEnumerable<LocationCardControl> LocationCards => Controls.Cast<LocationCardControl>();

        public MapPanel()
        {
            Location = new Point(10, 10);
            Size = new Size(50, 50);
            BackColor = Color.CadetBlue;
            TabIndex = 1;
            AutoScroll = true;
        }

        public void RefreshMapLayout()
        {
            SuspendLayout();
            var locGrid = new List<Tuple<LocationCardControl, int, int>>();//x,y
            foreach (LocationCardControl loc in Controls)
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
            var tileMargin = 5;

            foreach (var l in locGrid)
            {
                var col = l.Item2 - mostLeftColIndex;
                var row = l.Item3 - mostTopRowIndex;

                l.Item1.Location = new Point(
                    col * l.Item1.Width + mapPadding + (col - 1) * tileMargin,
                    row * l.Item1.Height + mapPadding + (row - 1) * tileMargin);
            }

            PerformLayout();
        }

        public void AddMissingMapTiles()
        {
            foreach (var player in Game.Instance.Players)
            {
                foreach(var loc in LocationsHelper.GetNeighbourLocationNumbers(player.CurrentLocationCard))
                {
                    if(LocationsHelper.IsLocationNearActiveMenhir(loc) || DebugCheats.IgnoreMenhirVicinityWhenShowNewLocationAfterTravel)
                    {
                        AddLocationCardToMap(loc);
                    }
                }
            }
        }

        public void RemoveLocationsOutsideMenhirRange()
        {
            var LocsToRemove = new List<LocationCardControl>();
            foreach (LocationCardControl l in LocationCards)
            {
                if(!LocationsHelper.IsLocationNearActiveMenhir(l.LocationNumber))
                    LocsToRemove.Add(l);
            }

            foreach (var l in LocsToRemove)
            {
                Controls.Remove(l);
            }
        }

        public void ActivateMenhir(LocationCardControl lcc, int value)
        {
            lcc.MenhirValue = value;

            foreach (var s in LocationsHelper.GetNeighbourLCCs(lcc))
            {
                AddLocationCardToMap(s);
            }
        }

        public void AddLocationCardToMap(int locationNumber, int alsoActivateMenhirWithValue = -1)
        {
            AddLocationCardToMap(LocationsHelper.GetLCControl(locationNumber), alsoActivateMenhirWithValue);
        }

        public void AddLocationCardToMap(LocationCardControl loc, int alsoActivateMenhirWithValue = -1)
        {
            //location is already on map
            if (LocationCards.Any(_ => _.LocationNumber == loc.LocationNumber))
                return;

            Controls.Add(loc);
            if (alsoActivateMenhirWithValue >= 0)
            {
                ActivateMenhir(loc, alsoActivateMenhirWithValue);
            }

            RefreshMapLayout();
        }

        public void RemoveInactiveMenhirs()
        {
            foreach (var loc in LocationCards)
            {
                if(loc.MenhirValue == 0)
                {
                    loc.MenhirValue = -1;
                }
            }
        }
    }
}