using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Let_Him_Cook_Final

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
            
            if (foodBox.Intersects(Game1.player.playerBox) && isHit == false)
            {
                //Game1.player.CharPosition.X -= 5;
                Hit();
                MouseState ms = Mouse.GetState();
                if(ms.LeftButton == ButtonState.Pressed)
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

        }



        public void Hit()
        {
            Game1.player.Life -= 1;
            //enemyPosition = Vector2.Zero;
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
