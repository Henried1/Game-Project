using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.animation;
using Project.interfaces;
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
        private Vector2 positie;
        private Vector2 snelheid;
        private Vector2 versnelling;
        private Vector2 mouseVector;
        public Hero(Texture2D texture)
        {
            heroTexture = texture;
            animation = new Animation();
            animation.AddFrame(new AnimationFrame(new Rectangle(15, 176, 45, 48)));
            animation.AddFrame(new AnimationFrame(new Rectangle(73, 176, 45, 48)));
            animation.AddFrame(new AnimationFrame(new Rectangle(131, 176, 45, 48)));
            animation.AddFrame(new AnimationFrame(new Rectangle(189, 176, 45, 48)));
            positie = new Vector2(10, 0);
            snelheid = new Vector2(1, 0);
            versnelling = new Vector2(0.1f, 0.1f);
            



        }
        public void Update(GameTime gameTime)
        {
            
           Move(GetMouseState());
           animation.Update(gameTime);
        }
        private Vector2 GetMouseState()
        {
            MouseState state = Mouse.GetState();
            mouseVector = new Vector2(state.X, state.Y);
            return mouseVector;
        }
        private void Move(Vector2 mouse)
        {
            var direction = Vector2.Add(mouse, -positie);
            direction.Normalize();
            direction = Vector2.Multiply(direction, 0.3f);

            snelheid += direction;
            snelheid = Limit(snelheid, 5);
            positie += snelheid;

            if (positie.X > 600 || positie.X < 0)
            {
                snelheid.X *= -1;
                versnelling.X *= -1;
            }
            if (positie.Y > 400 || positie.Y < 0)
            {
                snelheid.Y *= -1;
                versnelling.Y *= -1;

            }
            Debug.WriteLine($"Current Position: {positie}");
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
            spriteBatch.Draw(heroTexture, positie,animation.CurrentFrame.SourceRectangle  , Color.White);
        }

    }
}
