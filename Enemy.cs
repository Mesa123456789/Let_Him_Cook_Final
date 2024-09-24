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
    public class Enemy : Food
    {
        bool isHit;
        Texture2D texture;
        public Vector2 enemyPosition;
        private double hitCooldown = 2.0; // Cooldown period in seconds
        private double lastHitTime = 0;
        int countDamage;

        public Enemy(Texture2D enemytex, Vector2 enemyPosition) : base(enemytex, enemyPosition)
        {
            this.texture = enemytex;
            this.enemyPosition = enemyPosition;
        }

        public override void Update(GameTime gameTime)
        {
            MouseState ms = Mouse.GetState();
            if (foodBox.Intersects(Game1.player.playerBox) && !isHit && !OntableAble)
            {
                Hit();
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    OnCollision();

                }
            }
            if (isHit == true)
            {
                countDamage += 1;
                {
                    if (countDamage > 100)
                    {
                        countDamage = 0;
                        isHit = false;
                    }
                }
            }
            foodBox = new Rectangle((int)foodPosition.X, (int)foodPosition.Y, 50, 50);

        }



        public void Hit()
        {
            Game1.currentHeart -= 20;
            isHit = true;

        }
        public override void OnCollision()
        {
            OntableAble = true;
            Game1.BagList.Add(this);
            Game1.IsPopUp = true;
            foreach (Enemy enemy in Game1.enemyList)
            {
                Game1.enemyList.Remove(this);
                break;
            }
        }

    }
}
