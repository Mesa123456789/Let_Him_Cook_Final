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
        Texture2D uni;
        ////////////////asset////////////////////
        Texture2D Inventory;
        Texture2D bg;
        Texture2D interact;
        Texture2D bg2;
        Texture2D table;
        Texture2D inventory;
        Texture2D menu1;
        Texture2D craft;
        Texture2D popup;
        ////////////////Player////////////////////
        public static Vector2 CharPosition = new Vector2(770, 450);
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
        public static List<Food> MenuList = new List<Food>();
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
        ScreenState mCurrentScreen;
        enum ScreenState
        {
            Title,
            Gameplay
        }

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

            _camera = new Camera(new Vector2(-400, -225));
            SpriteTexture = new AnimatedTexture(new Vector2(0, 0), Rotation, Scale, Depth);
            player = new Char01(SpriteTexture, CharPosition);
            SpriteTexture.Load(Content, "Char01_1", Frames, FramesRow, FramesPerSec);
            fade = true;
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
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
            MenuList.Add(new Enemy(foodTexture, new Vector2(450 + 100, 250)));
            MenuList.Add(new Enemy(foodTex2, new Vector2(400 + 100, 400)));
            MenuList.Add(new Food(foodTex3, new Vector2(300 + 100, 300)));
            MenuList.Add(new Food(foodTex4, new Vector2(150 + 100, 150)));
            MenuList.Add(new Food(foodTex5, new Vector2(300 + 100, 200)));
            MenuList.Add(new Food(foodTex6, new Vector2(380 + 100, 330)));
            MenuList.Add(new Food(foodTex7, new Vector2(230 + 100, 260)));
            MenuList.Add(new Food(foodTex8, new Vector2(300, 200)));
            MenuList.Add(new Food(foodTex9, new Vector2(100, 200)));
            MenuList.Add(new Enemy(foodTex10, new Vector2(100, 250)));
            MenuList.Add(new Enemy(foodTex11, new Vector2(150, 280)));
            //font
            font = Content.Load<SpriteFont>("myfonts");
            heart = Content.Load<SpriteFont>("Life");
            bg = Content.Load<Texture2D>("map");
            bg2 = Content.Load<Texture2D>("In_Restaurant");
            inventory = Content.Load<Texture2D>("inventory");
            popup = Content.Load<Texture2D>("popup");
            craft = Content.Load<Texture2D>("craft");
            table = Content.Load<Texture2D>("table");
            interact = Content.Load<Texture2D>("interact");
            uni = Content.Load<Texture2D>("Uni");
            mCurrentScreen = ScreenState.Gameplay;
        }
        
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            switch (mCurrentScreen)
            {
                case ScreenState.Title:
                    {
                        UpdateRestaurant(gameTime); break;
                    }
                case ScreenState.Gameplay:
                    {
                        UpdateGameplay(gameTime); break;
                    }
            }

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            MouseState ms = Mouse.GetState();
            _spriteBatch.Begin(transformMatrix: _camera.Transform);
            DrawGameplay();
            switch (mCurrentScreen)
            {
                case ScreenState.Title:
                    {
                        DrawRestaurant(); break;
                    }
                case ScreenState.Gameplay:
                    {
                        DrawGameplay(); break;
                    }
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public Rectangle doorRec = new Rectangle(790, 380, 20,5);
        public void UpdateGameplay(GameTime gameTime)
        {
            if (player.playerBox.Intersects(doorRec))
            {
                mCurrentScreen = ScreenState.Title;
            }
            MouseState ms = Mouse.GetState();   
                ////////////////Camera////////////////////
                _camera.Follow(player);
                if (Keyboard.GetState().IsKeyDown(Keys.E))
                {
                    ShowInventory = true;
                }
                else
                {
                    ShowInventory = false;
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
        }
        public Rectangle doorRestaurantRec = new Rectangle(560,567,50,10);
        public static Vector2 tablePos = new Vector2(848, 345);
        public Rectangle tableBox = new Rectangle((int)tablePos.X, (int)tablePos.Y, 100,50);
        public Rectangle equalBox = new Rectangle((int)equalPos.X, (int)equalPos.Y, 150,40);
        public static Vector2 equalPos = new Vector2(720, 310);
        bool IsInterect = false;
        public void UpdateRestaurant(GameTime gameTime)
        {

            MouseState ms = Mouse.GetState();
            Rectangle mouseBox = new Rectangle((int)_camera.worldPos.X + (int)temp_mouse.X, (int)_camera.worldPos.Y + (int)temp_mouse.Y,50,50);
           // Rectangle msCraftBox = new Rectangle((int)ms.X, (int)ms.Y, 100, 50);
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

            if (player.playerBox.Intersects(tableBox))
            {
                IsInterect = true;
                if (ms.LeftButton == ButtonState.Pressed && mouseBox.Intersects(tableBox))
                {
                    Ontable = true;
                }
            }
            else
            {
                IsInterect = false;
                Ontable = false;
                
            }
            for (int i = 0; i < BagList.Count; i++)
            {
                BagList[i].Update(gameTime);
                if (mouseBox.Intersects(BagList[i].foodBox) && ms.LeftButton == ButtonState.Pressed && Ontable)
                {
                    //for (int j = MenuList.Count; j <= 2; j++)
                    //{
                    //    //chicken + แมงป่อง
                    //    food.getFood++;
                    //}
                    CraftList.Add(BagList[i]);
                    BagList.RemoveAt(i);
                    break;
                }
            }
            if (mouseBox.Intersects(equalBox) && ms.LeftButton == ButtonState.Pressed && Ontable)
            {
                Crafting = true;
            }
            if (player.playerBox.Intersects(doorRestaurantRec))
            {
                mCurrentScreen = ScreenState.Gameplay;
                player.CharPosition = new Vector2 (830,360);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                ShowInventory = true;
            }
            else
            {
                ShowInventory = false;
            }
            player.Update(gameTime, GraphicsDevice.Viewport);
        }
        public void DrawGameplay()
        {
            MouseState ms = Mouse.GetState();
                ////////////////Map////////////////////
                _spriteBatch.Draw(bg, new Rectangle(0, 0, 1600, 900), Color.White);
                _spriteBatch.DrawString(heart, player.Life.ToString(), new Vector2(10, 30), Color.White);
                ////////////////Food.Draw////////////////////
                foreach (Food food in foodList)
                {
                    for (int i = 0; i < foodList.Count; i++)
                    {
                        foodList[i].Draw(_spriteBatch);
                    }
                }
                foreach (Enemy enemy in enemyList)
                {
                    for (int i = 0; i < enemyList.Count; i++)
                    {
                        enemyList[i].Draw(_spriteBatch);
                    }
                }
                //_spriteBatch.Draw(table, doorRec, Color.White);
                ////////////////player////////////////////
                player.Draw(_spriteBatch);
                ////////////////Inventory////////////////////
                if (ShowInventory == true)
                {
                    _spriteBatch.Draw(inventory, new Vector2(player.CharPosition.X - 240, player.CharPosition.Y - 70), Color.White);
                    for (int i = 0; i < BagList.Count; i++)
                    {
                        _spriteBatch.Draw(BagList[i].foodTexture, new Vector2((player.CharPosition.X - 210) + i * 52, player.CharPosition.Y - 40), Color.White);
                    }
                }
                ////////////////popup////////////////////
                foreach (Food food in BagList)
                {
                    if (IsPopUp == true)
                    {
                        for (int i = 0; i < BagList.Count; i++)
                        {
                            _spriteBatch.Draw(popup, new Vector2(player.CharPosition.X + 270, player.CharPosition.Y - 150), Color.White);
                            _spriteBatch.Draw(BagList[i].foodTexture, new Vector2(player.CharPosition.X + 280, player.CharPosition.Y - 142), Color.White);
                        }
                        CountTime();
                    }
                }
                if (clicked == true)
                {
                    _spriteBatch.DrawString(font, $"{_camera.worldPos} + {temp_mouse} = {_camera.worldPos + temp_mouse}", _camera.worldPos + temp_mouse, Color.White);
                }
        }
        bool fade;
        
        public void DrawRestaurant()
        {
            //new Vector2(402,195)
            _spriteBatch.Draw(bg, new Rectangle(0, 0, 1600, 900), Color.Black);
            _spriteBatch.Draw(bg2, new Vector2(402, 195), Color.White);
            if (IsInterect == true)
            {
                _spriteBatch.Draw(interact, new Rectangle(848, 340, 130, 50), Color.White);
            }
            player.Draw(_spriteBatch);
            if (fade == true)
            {
                _spriteBatch.Draw(bg, new Rectangle(0, 0, 1600, 900), Color.Black);
                CountTime();
            }
            if (ShowInventory == true)
            {
                _spriteBatch.Draw(inventory, new Vector2(player.CharPosition.X - 240, player.CharPosition.Y - 70), Color.White);
                for (int i = 0; i < BagList.Count; i++)
                {
                    _spriteBatch.Draw(BagList[i].foodTexture, new Vector2((player.CharPosition.X - 210) + i * 52, player.CharPosition.Y - 40), Color.White);
                }
            }
            if (Ontable == true)
            {
                _spriteBatch.Draw(craft, new Vector2(600,220), Color.White);
                _spriteBatch.Draw(inventory, new Vector2(520,400), Color.White);
                for (int i = 0; i < CraftList.Count; i++)
                {
                    _spriteBatch.Draw(CraftList[i].foodTexture, new Vector2(673 + i * 68, 252), Color.White);
                }
                for (int i = 0; i < BagList.Count; i++)
                {
                    _spriteBatch.Draw(BagList[i].foodTexture, new Vector2(550 + i * 52, 430), Color.White);
                }
                if(Crafting == true)
                {
                    _spriteBatch.Draw(popup, new Rectangle(660,280 ,250,150), Color.White);
                    _spriteBatch.Draw(uni,new Rectangle(680,300,128,128), Color.White);
                }
                
            }  
            //_spriteBatch.Draw(table, equalPos, equalBox, Color.White);
            if (clicked == true)
            {
                _spriteBatch.DrawString(font, $"{_camera.worldPos} + {temp_mouse} = {_camera.worldPos + temp_mouse}", _camera.worldPos + temp_mouse, Color.White);
            }

        }
        public int countPopUp;
        public void CountTime()
        {
            countPopUp += 1;
            {
                if (countPopUp > 80)
                {
                    countPopUp = 0;
                    IsPopUp = false;
                    Ontable = false;
                    fade = false;
                }
            }
        }


    }
}
