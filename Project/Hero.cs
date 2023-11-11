using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.animation;
using Project.interfaces;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
     class Hero:IGameObject
    {
        Texture2D heroTexture;
        Animation animation;
        public Hero(Texture2D texture)
        {
            heroTexture = texture;
            animation = new Animation();
            animation.AddFrame(new AnimationFrame(new Rectangle(15, 176, 45, 48)));
            animation.AddFrame(new AnimationFrame(new Rectangle(73, 176, 45, 48)));
            animation.AddFrame(new AnimationFrame(new Rectangle(131, 176, 45, 48)));
            animation.AddFrame(new AnimationFrame(new Rectangle(189, 176, 45, 48)));



        }
        public void Update(GameTime gameTime)
        {
           animation.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, new Vector2(0, 0),animation.CurrentFrame.SourceRectangle  , Color.White);
        }

    }
}
