using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_Project
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _texture;
        private Rectangle _deelRectangle;
        private int schuifOp_X = 8;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _deelRectangle = new Rectangle(schuifOp_X,176 , 39, 43);
            base.Initialize();
        }
        // beweging 66-8
        //max 233 x 
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _texture = Content.Load<Texture2D>("tanjiro");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            // TODO: Add your drawing code here
            _spriteBatch.Draw(_texture, new Vector2(0, 0),_deelRectangle, Color.White);
            schuifOp_X += 58;
            if (schuifOp_X > 238)
            {
                schuifOp_X = 8;
            }
            _deelRectangle.X = schuifOp_X;
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}