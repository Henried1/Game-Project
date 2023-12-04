﻿using Microsoft.Xna.Framework;
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
        private Animation running;
        private Animation standing;
        private Vector2 position;
        private Vector2 speed;
        private Vector2 acceleration;
        IinputReader inputReader;
        private int screenWidth;
        private int screenHeight;
        private bool isAnimating;
        private int yOffset = 30;
        public Hero(Texture2D texture,KeyBoardReader reader, int screenWidth, int screenHeight)
        {
            heroTexture = texture;
            running = new Animation();
            standing = new Animation();
            //running
            running.AddFrame(new AnimationFrame(new Rectangle(15, 176, 45, 48)));
            running.AddFrame(new AnimationFrame(new Rectangle(73, 176, 45, 48)));
            running.AddFrame(new AnimationFrame(new Rectangle(131, 176, 45, 48)));
            running.AddFrame(new AnimationFrame(new Rectangle(189, 176, 45, 48)));
            //standing
            standing.AddFrame(new AnimationFrame(new Rectangle(0, 0, 55,85)));
            position = new Vector2(10, 100);
            speed = Vector2.Zero;
            acceleration = new Vector2(0.1f, 0.1f);
            inputReader = reader;
           // this.screenHeight = screenHeight;
           // this.screenWidth = screenWidth;



        }
        public void Update(GameTime gameTime)
        {
            var direction = inputReader.ReadInput();

            // Check if any arrow key is pressed
            if (direction != Vector2.Zero)
            {
                if (!isAnimating)
                {
                    // Start the animation only if it's not already started
                    speed = Vector2.Zero;   
                    running.Start();
                    standing.Stop();
                    isAnimating = true;
                }

                Move(direction);
            }
            else
            {
                // Stop the animation if no arrow key is pressed
                standing.Start();
                running.Stop();
                isAnimating = false;
            }

            running.Update(gameTime);
            standing.Update(gameTime);

        }
        private void Move(Vector2 direction)
        {
            if (direction != Vector2.Zero)
            {
                speed += acceleration * direction;
                speed = Limit(speed, 2f);


            }
            else
            {
                speed *= 0.95f;
                if (speed.Length()< 0.01f)
                {
                    speed = Vector2.Zero;
                }


            }
            position += speed;

            bounce();

            Debug.WriteLine($"Current Position: {position}");
        }
        private void bounce()
        {

            if (position.X > 600 || position.X < 0)
            {
                speed.X *= -1;
                acceleration.X *= -1;
            }
            if (position.Y > 400|| position.Y < 0)
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
            if (running.IsPlaying)
            {
                spriteBatch.Draw(heroTexture, position + new Vector2(0, yOffset), running.CurrentFrame.SourceRectangle, Color.White);

            }
            else
            {
                spriteBatch.Draw(heroTexture, position, standing.CurrentFrame.SourceRectangle, Color.White);

            }

        }

    }
}
