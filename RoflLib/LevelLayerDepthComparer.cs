using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoflLib
{
    public class LevelLayerDepthComparer : IComparer<LevelLayer>
    {
        public int Compare(LevelLayer x, LevelLayer y)
        {
            return x.Depth < y.Depth ? -1 : 1;
        }
    }
}
