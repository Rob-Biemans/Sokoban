using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Field
    {
        // Declarations
        public string type;
        public int X { get; set; }
        public int Y { get; set; }
        public bool moveAble;

        public Player Player { get; set; }

        // Constructor
        public Field()
        {

        }

        
    }
}