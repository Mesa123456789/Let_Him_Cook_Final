
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LET_HIM_COOK_FINAL
{
    public class Char01
    {
        private readonly Point _mapTileSize = new(50, 30);
        public Vector2 CharPosition = new Vector2(3, 3);
        public Vector2 CharInventory = new Vector2(575, 395);
        AnimatedTexture SpriteTexture;
        int speed = 2;
        public int Life = 10;
        private Viewport viewport;
        private Matrix _translation;

        public enum Direction { Left, Right, Up, Down }
        public Direction direction { get; set; }

        public Rectangle playerBox;

        public Char01(AnimatedTexture SpriteTexture, Vector2 CharPosition)
        {

            this.SpriteTexture = SpriteTexture;
            this.CharPosition = CharPosition;
            direction = Direction.Right;
            playerBox = new Rectangle((int)CharPosition.X, (int)CharPosition.Y, 64, 64);

        }



        public void Update(GameTime gameTime)
        {

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            SpriteTexture.Pause();

            Vector2 velocity = Vector2.Zero;

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {

                velocity.Y -= 1;
                SpriteTexture.Play();
                direction = Direction.Down;

            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {

                velocity.Y += 1;
                SpriteTexture.Play();
                direction = Direction.Right;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {

                velocity.X += 1;
                SpriteTexture.Play();
                direction = Direction.Right;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {

                velocity.X -= 1;
                SpriteTexture.Play();
                direction = Direction.Left;
            }






            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }

            CharPosition += velocity * speed;

            CharPosition.X = MathHelper.Clamp(CharPosition.X, 0, Game1.WindowSize.X - playerBox.Width);
            CharPosition.Y = MathHelper.Clamp(CharPosition.Y, 0, Game1.WindowSize.Y - playerBox.Height);


            playerBox.Location = CharPosition.ToPoint();

            SpriteTexture.UpdateFrame(elapsed);

            playerBox = new Rectangle((int)CharPosition.X, (int)CharPosition.Y, 64, 64);

        }


        public void Draw(SpriteBatch _spriteBatch)
        {

            SpriteTexture.DrawFrame(_spriteBatch, CharPosition, (int)direction + 1);

        }

        public void DrawInventory(SpriteBatch _spriteBatch)
        {

            SpriteTexture.DrawFrame(_spriteBatch, CharInventory, (int)direction + 1);

        }
    }
}
