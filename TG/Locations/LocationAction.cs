using System;
using TG.CustomControls;

namespace TG.Locations
{
    public class LocationAction
    {
        public string Description;
        public Action<LocationActionArgs> Action;
    }
}