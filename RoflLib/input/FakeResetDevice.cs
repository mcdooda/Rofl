using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoflLib.input
{
    public class FakeResetDevice : FakeDevice
    {
        public override bool IsResetButtonJustPressed()
        {
            return true;
        }
    }
}
