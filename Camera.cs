using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LET_HIM_COOK_FINAL
{
    public class Camera
    {
        public Vector2 worldPos = new Vector2(385, 225);
        public Vector2 worldPos2 = new Vector2(385, 225);
        public Camera(Vector2 inputOffset)
        {
            staterOffset = inputOffset;
        }
        float x, y;
        Vector2 staterOffset;
        public Matrix Transform { get; private set; }
        public void Follow(Char01 target)
        {
            if (target.CharPosition.X > 368 && target.CharPosition.X < 1168)
            {
                x = -target.CharPosition.X - (target.playerBox.Width / 2) + staterOffset.X;
            }
            if (target.CharPosition.Y > 192 && target.CharPosition.Y < 600)
            {
                y = -target.CharPosition.Y - (target.playerBox.Height / 2) + staterOffset.Y;
            }

            var position = Matrix.CreateTranslation(x, y, 0);

            var offset = Matrix.CreateTranslation(
                Game1.WindowSize.X / 2,
                Game1.WindowSize.Y / 2,
                0);

            Transform = position * offset;
            worldPos.X = target.CharPosition.X + staterOffset.X - 32;
            worldPos.Y = target.CharPosition.Y + staterOffset.Y - 32;
            worldPos2.X = target.CharPosition.X + staterOffset.X - 80;
            worldPos2.Y = target.CharPosition.Y + staterOffset.Y - 80;
        }
        public void UX(Char01 target)
        { }
    }
}