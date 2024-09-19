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
        public Vector2 foodPosition;
        public Rectangle foodBox;
        public Texture2D foodTexture;
        public List<Food> MenuList = new List<Food>();
        public int getFood;
        public bool OntableAble;

        public Food(Texture2D foodTexture, Vector2 foodPosition)
        {
            this.foodTexture = foodTexture;
            this.foodPosition = foodPosition;
            foodBox = new Rectangle((int)foodPosition.X, (int)foodPosition.Y,64,64);
            OntableAble = false;

        }

        public override void Update(GameTime gameTime)
        {
            MouseState ms = Mouse.GetState();
            if (foodBox.Intersects(Game1.player.playerBox) && !OntableAble)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    OnCollision();

                }
            }
            foodBox = new Rectangle((int)foodPosition.X, (int)foodPosition.Y, 64,64);
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(foodTexture, foodPosition, Color.White);
        }
        public virtual void OnCollision()
        {
            OntableAble = true;
            Game1.BagList.Add(this);
            Game1.IsPopUp = true;
            foreach (Food food in Game1.foodList)
            {
                Game1.foodList.Remove(this);
                break;
            }
        }

    }
}
