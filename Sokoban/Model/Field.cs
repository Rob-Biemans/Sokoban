using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public abstract class Field
    {
        // Declarations
        public string type;
        public string icon;
        public bool moveAble;
        public int X { get; set; }
        public int Y { get; set; }

        // Constructor
        public Field()
        {

        }

        public abstract void moveTo();

        public bool checkNextOfMe()
        {
            // Bekijk welke object / instantie naast mij zit
            // Als het een muur is dan return dat het niet mogelijk is
            return false;
        }


    }
}