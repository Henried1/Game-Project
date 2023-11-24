using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.animation;
using Project.Input;
using Project.interfaces;
using Project.Interfaces;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
     class Hero:IGameObject
    {
        private Texture2D heroTexture;
        private Animation animation;
        private Vector2 position;
        private Vector2 speed;
        private Vector2 acceleration;
        private Vector2 mouseVector;
        IinputReader inputReader;
        public Hero(Texture2D texture,KeyBoardReader reader)
        {
            heroTexture = texture;
            animation = new Animation();
            animation.AddFrame(new AnimationFrame(new Rectangle(15, 176, 45, 48)));
            animation.AddFrame(new AnimationFrame(new Rectangle(73, 176, 45, 48)));
            animation.AddFrame(new AnimationFrame(new Rectangle(131, 176, 45, 48)));
            animation.AddFrame(new AnimationFrame(new Rectangle(189, 176, 45, 48)));
            position = new Vector2(10, 0);
            speed = Vector2.Zero;
            acceleration = new Vector2(0.1f, 0.1f);
            inputReader = reader;



        }
        public void Update(GameTime gameTime)
        {



            var direction = inputReader.ReadInput();
            Move(direction);


                

                

            
            
          // Move(GetMouseState());
           animation.Update(gameTime);
           
        }
        private void Move(Vector2 direction)
        {
            if (direction != Vector2.Zero)
            {
                speed += acceleration * direction;
                speed = Limit(speed, 1f);
                position += speed;

            }
            else
            {
                speed = Vector2.Zero;
            }


            Bounce();
            Debug.WriteLine($"Current Position: {position}");
        }
        private void Bounce()
        {

            if (position.X > 600 || position.X < 0)
            {
                speed.X *= -1;
                acceleration.X *= -1;
            }
            if (position.Y > 400 || position.Y < 0)
            {
                speed.Y *= -1;
                acceleration.Y *= -1;

            }
        }
        private Vector2 Limit(Vector2 v, float max)
        {
            if (v.Length() > max )
            {
                var ratio = max / v.Length();
                v.X *= ratio;
                v.Y *= ratio;
            }
            return v;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, position,animation.CurrentFrame.SourceRectangle  , Color.White);
        }

    }
}
