using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Let_Him_Cook_Final
{
    public class Camera
    {
        public Camera(Vector2 inputOffset) {
            staterOffset = inputOffset;
        }
        Vector2 staterOffset; 
        public Matrix Transform { get; private set; }
        //Vector2 WindowSize = new Vector2(1600, 900);
        public void Follow(Char01 target)
        {
            if (target.CharPosition.X < 1168 && target.CharPosition.X > 368 && target.CharPosition.Y < 600 && target.CharPosition.Y > 192)
            {
                var position = Matrix.CreateTranslation(
              -target.CharPosition.X - (target.playerBox.Width / 2) + staterOffset.X,
              -target.CharPosition.Y - (target.playerBox.Height / 2) + staterOffset.Y,
              0);

                var offset = Matrix.CreateTranslation(
                    Game1.WindowSize.X / 2,
                    Game1.WindowSize.Y / 2,
                    0);

                Transform = position * offset;
            }
        }
    }
}