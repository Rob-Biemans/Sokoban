﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Player : Field
    {
        // Declarations

        // Constructor
        public Player()
        {
            this.type = "Player";
            this.moveAble = true;
            this.icon = "@";
        }

        public override void moveTo()
        {

        }

        
    }
}