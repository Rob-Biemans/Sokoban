using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class DestinationFilled : Field
    {
        public DestinationFilled()
        {
            this.type = "DestinationFilledWithChest";
            this.moveAble = false;
            this.icon = "0";
        }

        public override void moveTo()
        {
            return;
        }
    }
}