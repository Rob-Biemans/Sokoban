using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Destination : Field
    {

        // Constructor
        public Destination()
        {
            this.type = "Destination";
            this.moveAble = false;
            this.icon = "x";
        }
    }
}