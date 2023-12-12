using Microsoft.Xna.Framework.Input;
using Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Project.Input
{
    class KeyBoardReader : IinputReader
    {
        public Vector2 ReadInput()
        {
            var direction = Vector2.Zero;

            KeyboardState state = Keyboard.GetState();

           
            //movement
            if (state.IsKeyDown(Keys.Left))
                direction = new Vector2(-1, 0);
            if (state.IsKeyDown(Keys.Right))
                direction = new Vector2(1, 0);
        
            return direction;
        }

        //attack
        public bool attackPressed() 
        {
            KeyboardState state = Keyboard.GetState();
            return state.IsKeyDown(Keys.A);
        }
     
       
    }
}
