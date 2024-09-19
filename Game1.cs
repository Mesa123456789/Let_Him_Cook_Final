using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Formats.Asn1.AsnWriter;


namespace Let_Him_Cook_Final
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static Point WindowSize { get; set; }
        ////////////////Class////////////////////
        AnimatedTexture SpriteTexture;
        public static Char01 player;
        Camera _camera;
        Enemy enemy;
        Food food;
        ////////////////Content////////////////////
        SpriteFont font;
        SpriteFont heart;
        StringBuilder inputText;
        SpriteFont inputFont;
        ////////////////Food////////////////////
        Texture2D foodTexture;
        Texture2D foodTex2;
        Texture2D foodTex3;
        Texture2D foodTex4;
        Texture2D foodTex5;
        Texture2D foodTex6;
        Texture2D foodTex7;
        Texture2D foodTex8;
        Texture2D foodTex9;
        Texture2D foodTex10;
        Texture2D foodTex11;
        ////////////////asset////////////////////
        Texture2D Inventory;
        Texture2D bg;
        Texture2D door;
        Texture2D inventory;
        Texture2D menu1;
        Texture2D chest;
        Texture2D popup;
        ////////////////Player////////////////////
        public static Vector2 CharPosition = new Vector2(770, 450);

        public Rectangle equalBox = new Rectangle(350, 75, 64, 64);
        private const float Rotation = 0;
        private const float Scale = 1.0f;
        private const float Depth = 0.5f;
        private const int Frames = 5;
        private const int FramesPerSec = 10;
        private const int FramesRow = 4;
        ////////////////List////////////////////
        public static List<Food> BagList = new List<Food>();
        public static List<Food> foodList = new();
        public static List<Enemy> enemyList = new();
        public static List<Food> CraftList = new List<Food>();
        ////////////////boolean////////////////////
        bool ShowInventory = false;
        bool IsEnd = false;
        private bool isCameraEnabled = true;
        bool isMenu;
        bool isGameplay;
        public static bool IsPopUp = false;
        public bool Ontable = false;
        bool Crafting = false;
        Vector2 temp_mouse = Vector2.Zero;
        bool clicked = false;


        //วิธีทำให้ uiPos = playerPos แล้ว +- Posเอง
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            WindowSize = new(1600, 900);
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 450;
            _graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            inputText = new StringBuilder();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            //player
            SpriteTexture = new AnimatedTexture(new Vector2(0, 0), Rotation, Scale, Depth);
            player = new Char01(SpriteTexture, CharPosition);
            SpriteTexture.Load(Content, "Char01_1", Frames, FramesRow, FramesPerSec);
            //food
            foodTexture = Content.Load<Texture2D>("chicken");
            foodTex2 = Content.Load<Texture2D>("enemy");
            foodTex3 = Content.Load<Texture2D>("enemy2");
            foodTex4 = Content.Load<Texture2D>("flower");
            foodTex5 = Content.Load<Texture2D>("fruit");
            foodTex6 = Content.Load<Texture2D>("mushroom1");
            foodTex7 = Content.Load<Texture2D>("mushroom2");
            foodTex8 = Content.Load<Texture2D>("pumkin");
            foodTex9 = Content.Load<Texture2D>("pumkin2");
            foodTex10 = Content.Load<Texture2D>("snail");
            foodTex11 = Content.Load<Texture2D>("snail2");
            ////////////////Food.AddList////////////////////
            enemyList.Add(new Enemy(foodTexture, new Vector2(450 + 100, 250)));
            enemyList.Add(new Enemy(foodTex2, new Vector2(400 + 100, 400)));
            foodList.Add(new Food(foodTex3, new Vector2(300 + 100, 300)));
            foodList.Add(new Food(foodTex4, new Vector2(150 + 100, 150)));
            foodList.Add(new Food(foodTex5, new Vector2(300 + 100, 200)));
            foodList.Add(new Food(foodTex6, new Vector2(380 + 100, 330)));
            foodList.Add(new Food(foodTex7, new Vector2(230 + 100, 260)));
            foodList.Add(new Food(foodTex8, new Vector2(300, 200)));
            foodList.Add(new Food(foodTex9, new Vector2(100, 200)));
            enemyList.Add(new Enemy(foodTex10, new Vector2(100, 250)));
            enemyList.Add(new Enemy(foodTex11, new Vector2(150, 280)));
            //font
            font = Content.Load<SpriteFont>("MyFont");
            heart = Content.Load<SpriteFont>("Heart");
            //asset_01 = Content.Load<Texture2D>("Assets");
            bg = Content.Load<Texture2D>("map");
            menu1 = Content.Load<Texture2D>("map");
            //door = Content.Load<Texture2D>("end");
            inventory = Content.Load<Texture2D>("inventory");
            _camera = new Camera(new Vector2(-400, -225));
            chest = Content.Load<Texture2D>("chest");
            popup = Content.Load<Texture2D>("popup");
        }

        public Rectangle tableBox = new Rectangle((int)CharPosition.X, (int)CharPosition.Y, 100, 100);
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            MouseState ms = Mouse.GetState();
            Rectangle mouseBox = new Rectangle((int)_camera.worldPos.X + (int)temp_mouse.X, (int)_camera.worldPos.Y + (int)temp_mouse.Y, 100, 100);
            ////////////////Camera////////////////////
            _camera.Follow(player);
            ////////////////Inventory////////////////////
            ///
            if (ms.LeftButton == ButtonState.Pressed)
            {
                temp_mouse.X = ms.X;
                temp_mouse.Y = ms.Y;
                clicked = true;
            }
            else
            {
                clicked = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                ShowInventory = true;
            }
            else
            {
                ShowInventory = false;
            }
            ////////////////Craft////////////////////
            if (player.playerBox.Intersects(tableBox))
            {
                if (ms.LeftButton == ButtonState.Pressed && mouseBox.Intersects(tableBox))
                {
                    Ontable = true;
                }
            }
            else
            {
                Ontable = false;
            }
            for (int i = 0; i < BagList.Count; i++)
            {
                BagList[i].Update(gameTime);
                if (mouseBox.Intersects(BagList[i].foodBox) && ms.LeftButton == ButtonState.Pressed && Ontable)
                {
                    for (int j = food.MenuList.Count; j <= 2; j++)
                    {
                        food.getFood++;
                    }
                    CraftList.Add(BagList[i]);
                    BagList.RemoveAt(i);
                    break;
                }
            }
            if (mouseBox.Intersects(equalBox) && ms.LeftButton == ButtonState.Pressed && Ontable)
            {
                Crafting = true;
            }
            ////////////////Food.Update////////////////////
            for (int i = foodList.Count - 1; i >= 0; i--)
            {
                foodList[i].Update(gameTime);
            }
            for (int i = enemyList.Count - 1; i >= 0; i--)
            {
                enemyList[i].Update(gameTime);
            }
            player.Update(gameTime, GraphicsDevice.Viewport);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            MouseState ms = Mouse.GetState();
            _spriteBatch.Begin(transformMatrix: _camera.Transform);
            ////////////////Map////////////////////
            _spriteBatch.Draw(bg, new Rectangle(0, 0, 1600, 900), Color.White);
            ////////////////List<Bag>////////////////////
            //_spriteBatch.DrawString(font, BagList.Count.ToString(), new Vector2(10, 10), Color.White);
            //_spriteBatch.DrawString(font, $"{_camera.worldPos} + {player.CharPosition}", player.CharPosition+ new Vector2(0,-50), Color.White);
            ////////////////Life////////////////////
            _spriteBatch.DrawString(heart, player.Life.ToString(), new Vector2(10, 30), Color.White);

            if (clicked == true)
            {
                _spriteBatch.DrawString(font, $"{_camera.worldPos} + {temp_mouse} = {_camera.worldPos + temp_mouse}", _camera.worldPos + temp_mouse, Color.White);
            }
            _spriteBatch.DrawString(font, "aaaaaaaaa", new Vector2(CharPosition.X, 400), Color.White);
            ////////////////Food.Draw////////////////////
            foreach (Food food in foodList)
            {
                for (int i = 0; i < foodList.Count; i++)
                {
                    foodList[i].Draw(_spriteBatch);
                }

            }
            //foreach (Enemy enemy in enemyList)
            //{
            //    for (int i = 0; i < enemyList.Count; i++)
            //    {
            //        enemyList[i].Draw(_spriteBatch);
            //    }
            //}
            _spriteBatch.Draw(popup, player.CharPosition, tableBox, Color.White);
            ////////////////player////////////////////
            player.Draw(_spriteBatch);
            ////////////////Inventory////////////////////

            if (ShowInventory == true)
            {

            }
            foreach (Food food in BagList)
            {
                if (IsPopUp == true)
                {
                    for (int i = 0; i < BagList.Count; i++)
                    {
                        _spriteBatch.Draw(popup, new Rectangle(500, 500, 100, 100), Color.Black);
                        _spriteBatch.Draw(BagList[i].foodTexture, new Vector2(10, 10), Color.White);
                    }
                    CountTime();
                }
            }
            if (Ontable == true)
            {
                //craft
                _spriteBatch.Draw(popup, new Vector2(400, 150), new Rectangle(0, 0, 500, 150), Color.Red);
                _spriteBatch.Draw(popup, new Rectangle(400, 500, 500, 200), Color.White);
                _spriteBatch.Draw(popup, new Vector2(350, 75), equalBox, Color.White);
                for (int i = 0; i < CraftList.Count; i++)
                {
                    _spriteBatch.Draw(CraftList[i].foodTexture, new Vector2(230 + i * 60, 70), Color.White);
                }
                for (int i = 0; i < BagList.Count; i++)
                {
                    _spriteBatch.Draw(BagList[i].foodTexture, new Vector2(230 + i * 60, 250), Color.White);
                }

            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public int countPopUp;
        public void CountTime()
        {
            countPopUp += 1;
            {
                if (countPopUp > 100)
                {
                    countPopUp = 0;
                    IsPopUp = false;
                    Ontable = false;
                }
            }
        }


    }
}
