using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Let_Him_Cook_Final
{
    public class Food : Sprite
    {
        Vector2 foodPosition;
        public Rectangle foodBox;

        public Texture2D foodTexture;

        public Food(Texture2D foodTexture, Vector2 foodPosition)
        {
            this.foodTexture = foodTexture;
            this.foodPosition = foodPosition;
            foodBox = new Rectangle((int)foodPosition.X, (int)foodPosition.Y,10,10);
        }

        public override void Update(GameTime gameTime)
        {
            if (foodBox.Intersects(Game1.player.playerBox))
            {
                MouseState ms = Mouse.GetState();
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    OnCollied();
                }
            }
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {

            _spriteBatch.Draw(foodTexture, foodPosition, Color.White);
        }

        public virtual void OnCollied()
        {
            Game1.bag.Add(this);
            foreach (Food food in Game1.foodList)
            {
                Game1.foodList.Remove(this);
                break;

            }
            
           
        }

        public virtual void Hit()
        {
        }
    }
}
