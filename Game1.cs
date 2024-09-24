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
        public static Camera _camera;
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
        Texture2D babiq;
        Texture2D dunpling;
        Texture2D tempura;
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
        public Vector2 foodPos;
        public Texture2D foodTex;
        public Vector2 enemyPos;
        public Texture2D enemyTex;
        Texture2D ui;
        Texture2D uiHeart;
        Texture2D bag;
        public Texture2D Quest;
        public Texture2D book;
        ////////////////Player////////////////////
        public static Vector2 CharPosition = new Vector2(770, 450);
        public Rectangle bookRec;
        public Rectangle questboxRec;
        public Rectangle bagRec;
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
        public static Vector2 temp_mouse = Vector2.Zero;
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
            FinsihCooking  = false;
            base.Initialize();
        }
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            food = new Food(foodTex, foodPos);
            enemy = new Enemy(enemyTex, enemyPos);
            
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
            enemyList.Add(new Enemy(foodTexture, new Vector2(550, 250)));
            enemyList.Add(new Enemy(foodTex2, new Vector2(500, 400)));
            foodList.Add(new Food(foodTex3, new Vector2(300 + 100, 300)));
            foodList.Add(new Food(foodTex4, new Vector2(150 + 100, 150)));
            foodList.Add(new Food(foodTex5, new Vector2(300 + 100, 200)));
            foodList.Add(new Food(foodTex6, new Vector2(380 + 100, 330)));
            foodList.Add(new Food(foodTex7, new Vector2(230 + 100, 260)));
            foodList.Add(new Food(foodTex8, new Vector2(300, 200)));
            foodList.Add(new Food(foodTex9, new Vector2(100, 200)));
            enemyList.Add(new Enemy(foodTex10, new Vector2(100, 250)));
            enemyList.Add(new Enemy(foodTex11, new Vector2(150, 280)));
            MenuList.Add(new Enemy(foodTexture, new Vector2(550, 250)));
            MenuList.Add(new Enemy(foodTex2, new Vector2(500, 400)));
            MenuList.Add(new Food(foodTex3, new Vector2(400, 300)));
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
            babiq = Content.Load<Texture2D>("BabiQ");
            dunpling = Content.Load<Texture2D>("Dunpling");
            tempura = Content.Load<Texture2D>("tempura");
            ui = Content.Load<Texture2D>("ui");
            uiHeart = Content.Load<Texture2D>("uiHeart");
            book = Content.Load<Texture2D>("book");
            Quest = Content.Load<Texture2D>("Quest");
            bag = Content.Load<Texture2D>("bag");
            currentHeart = uiHeart.Width - 10;
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
            _spriteBatch.Begin(transformMatrix: _camera.Transform, samplerState: SamplerState.PointClamp);
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

        public Rectangle doorRec = new Rectangle(810, 380, 50, 2);
        public Rectangle doorRestaurantRec = new Rectangle(530, 230, 100, 2);
        public static int currentHeart;
        Color color = Color.White;
        bool OnCursor = false;
        bool OnCursor1 = false;
        bool OnCursor2 = false;
        public void UpdateGameplay(GameTime gameTime)
        {
            if (player.playerBox.Intersects(doorRec))
            {
                mCurrentScreen = ScreenState.Title;
                player.CharPosition = new Vector2(770, 385);
                fade = true;
            }
            bagRec = new Rectangle((int)(player.CharPosition.X + 350), (int)(player.CharPosition.Y - 220), 30,30);
            bookRec = new Rectangle((int)(player.CharPosition.X + 350), (int)(player.CharPosition.Y - 170), 30, 30);
            questboxRec = new Rectangle((int)(player.CharPosition.X + 350), (int)(player.CharPosition.Y - 120), 30, 30);
            MouseState ms = Mouse.GetState();
            Rectangle mouseBox = new Rectangle((int)_camera.worldPos.X + (int)temp_mouse.X, (int)_camera.worldPos.Y + (int)temp_mouse.Y,50,50);
            temp_mouse.X = ms.X;
            temp_mouse.Y = ms.Y;
            ////////////////Camera////////////////////
            _camera.Follow(player);
            if(mouseBox.Intersects(bagRec))
            {
                OnCursor = true;
                if (ms.LeftButton == ButtonState.Pressed && mouseBox.Intersects(bagRec))
                {
                    ShowInventory = true;
                }
            }
            else
            {
                ShowInventory = false;
                OnCursor = false;
            }
            if (mouseBox.Intersects(bookRec))
            {
                OnCursor1 = true;
            }
            else
            {
                OnCursor1 = false;
            }
            if (mouseBox.Intersects(questboxRec))
            {
                OnCursor2 = true;
            }
            else
            {
                OnCursor2 = false;
            }

            if (currentHeart < 60)
            {
                color = Color.Red;
            }
            else
            {
                color = Color.White;
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
            player.Update(gameTime);

        }

        public static Vector2 tablePos = new Vector2(848, 345);
        public Rectangle tableBox = new Rectangle((int)tablePos.X, (int)tablePos.Y, 100, 50);
        public Rectangle equalBox = new Rectangle((int)equalPos.X, (int)equalPos.Y, 150, 40);
        public static Vector2 equalPos = new Vector2(720, 310);
        bool IsInterect = false;
        bool GotMenu = false;
        public Rectangle FrigeRec = new Rectangle(750, 310, 40, 80);
        int getbabiq;
        bool FinsihCooking;
        public void UpdateRestaurant(GameTime gameTime)
        {
            MouseState ms = Mouse.GetState();
            Rectangle mouseBox = new Rectangle((int)_camera.worldPos.X + (int)temp_mouse.X, (int)_camera.worldPos.Y + (int)temp_mouse.Y, 50, 50);
            Rectangle mouseCraftBox = new Rectangle((int)_camera.worldPos2.X + (int)temp_mouse.X, (int)_camera.worldPos2.Y + (int)temp_mouse.Y, 30,30);
            if (player.playerBox.Intersects(doorRestaurantRec))
            {
                mCurrentScreen = ScreenState.Gameplay;
                player.CharPosition = new Vector2(658, 270);
                player.direction = Char01.Direction.Right;
                fade = true;
            }
            //if (ms.LeftButton == ButtonState.Pressed)
            //{
            //    temp_mouse.X = ms.X;
            //    temp_mouse.Y = ms.Y;
            //    clicked = true;
            //}
            //else { clicked = false; }
            temp_mouse.X = ms.X;
            temp_mouse.Y = ms.Y;
            if (Keyboard.GetState().IsKeyDown(Keys.E)) { ShowInventory = true; } else { ShowInventory = false; }
            if (player.playerBox.Intersects(FrigeRec))
            {
                IsFrigeInterect = true;
            }
            else { IsFrigeInterect = false; }
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
                if (mouseBox.Intersects(BagList[i].foodBox) && ms.LeftButton == ButtonState.Pressed && Ontable )
                {
                    food.getFood++;
                    CraftList.Add(BagList[i]);
                    BagList.RemoveAt(i);
                    break;
                }
            }
            if (mouseBox.Intersects(equalBox) && ms.LeftButton == ButtonState.Pressed && Ontable && !FinsihCooking)
            {
                if(food.getFood == 2)
                {
                    Crafting = true;
                    MenuPopup = 1;
                }
            }
            if(Crafting == true && MenuPopup == 0) { FinsihCooking = true; } else { FinsihCooking = false; }
            for (int i = 0; i < BagList.Count; i++)
            {
                BagList[i].Update(gameTime);
            }
            for (int i = foodList.Count - 1; i >= 0; i--)
            {
                foodList[i].Update(gameTime);
            }
            for (int i = enemyList.Count - 1; i >= 0; i--)
            {
                enemyList[i].Update(gameTime);
            }
            player.Update(gameTime);
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
                        _spriteBatch.Draw(popup, new Vector2(player.CharPosition.X + 270, player.CharPosition.Y ), Color.White);
                        _spriteBatch.Draw(BagList[i].foodTexture, new Vector2(player.CharPosition.X + 280, player.CharPosition.Y + 8 ), Color.White);
                    }
                    CountTime(200);
                }
            }
            
            _spriteBatch.Draw(bag, new Vector2(player.CharPosition.X + 350, player.CharPosition.Y - 180), new Rectangle(0, 0, 64, 44), Color.White);
            if (OnCursor == true)
            {
                _spriteBatch.Draw(bag, new Vector2(player.CharPosition.X + 350, player.CharPosition.Y - 180), new Rectangle(64, 0, 44, 44), Color.White);
            }
            _spriteBatch.Draw(book, new Vector2(player.CharPosition.X + 350, player.CharPosition.Y - 130), new Rectangle(0, 0, 64, 44), Color.White);
            if(OnCursor1 == true)
            {
                _spriteBatch.Draw(book, new Vector2(player.CharPosition.X + 350, player.CharPosition.Y - 130), new Rectangle(64, 0, 44, 44), Color.White);
            }
            _spriteBatch.Draw(Quest, new Vector2(player.CharPosition.X + 350, player.CharPosition.Y - 80), new Rectangle(0, 0, 64, 44), Color.White);
            if(OnCursor2 == true)
            {
                _spriteBatch.Draw(Quest, new Vector2(player.CharPosition.X + 350, player.CharPosition.Y - 80), new Rectangle(64, 0, 44, 44), Color.White);
            }
            
            _spriteBatch.Draw(uiHeart, new Vector2(player.CharPosition.X - 261,player.CharPosition.Y - 174), 
                new Rectangle(0,0,currentHeart + 10,18), color);
            _spriteBatch.Draw(ui, new Vector2(player.CharPosition.X - 365, player.CharPosition.Y - 190), Color.White);
            SpriteTexture.DrawFrame(_spriteBatch, new Vector2(player.CharPosition.X - 350, player.CharPosition.Y - 170),1);
            if (fade == true)
            {
                _spriteBatch.Draw(bg, new Rectangle(0, 0, 1600, 900), Color.Black);
                CountTime(70);
            }
            if (clicked == true)
            {
                _spriteBatch.DrawString(font, $"{_camera.worldPos} + {temp_mouse} = {_camera.worldPos + temp_mouse}", _camera.worldPos + temp_mouse, Color.White);
            }
        }
        bool fade;
        int MenuPopup;
        bool IsFrigeInterect = false;
        public void DrawRestaurant()
        {
            //new Vector2(402,195)
            _spriteBatch.Draw(bg, new Rectangle(0, 0, 1600, 900), Color.Black);
            _spriteBatch.Draw(bg2, new Vector2(402, 195), Color.White);
            if (IsInterect == true)
            {
                _spriteBatch.Draw(interact, new Rectangle(848, 340, 134, 50), Color.White);
            }
            if (IsFrigeInterect == true)
            {
                _spriteBatch.Draw(interact, new Rectangle(748, 310, 40, 80), Color.White);
            }
            player.Draw(_spriteBatch);
            if (fade == true)
            {
                _spriteBatch.Draw(bg, new Rectangle(0, 0, 1600, 900), Color.Black);
                CountTime(70);
            }
            if (ShowInventory == true)
            {
                _spriteBatch.Draw(inventory, new Vector2(520,320), Color.White);
                for (int i = 0; i < BagList.Count; i++)
                {
                    _spriteBatch.Draw(BagList[i].foodTexture, new Vector2((player.CharPosition.X - 210) + i * 52, player.CharPosition.Y - 40), Color.White);
                }
            }
            if (Ontable == true)
            {
                _spriteBatch.Draw(craft, new Vector2(600, 220), Color.White);
                _spriteBatch.Draw(inventory, new Vector2(520, 400), Color.White);
                if (!GotMenu)
                {
                    for (int i = 0; i < CraftList.Count; i++)
                    {
                        _spriteBatch.Draw(CraftList[i].foodTexture, new Vector2(673 + i * 68, 252), Color.White);
                    }
                }
                for (int i = 0; i < BagList.Count; i++)
                {
                    _spriteBatch.Draw(BagList[i].foodTexture, new Vector2(550 + i * 52, 430), Color.White);
                }
            }

            if (MenuPopup == 1 && !FinsihCooking)
            {
                if (Crafting == true)
                {
                    _spriteBatch.Draw(popup, new Rectangle(660, 280, 250, 150), Color.White);
                    _spriteBatch.Draw(uni, new Rectangle(680, 300, 128, 128), Color.White);
                    GotMenu = true;
                }
                CountTime(200);
            }
            if (clicked == true)
            {
                _spriteBatch.DrawString(font, $"{_camera.worldPos} + {temp_mouse} = {_camera.worldPos + temp_mouse}", _camera.worldPos + temp_mouse, Color.White);
            }

        }
        public int countPopUp;
        public void CountTime(int timePopup)
        {
            countPopUp += 1;
            {
                if (countPopUp > timePopup)
                {
                    countPopUp = 0;
                    IsPopUp = false;
                    Ontable = false;
                    fade = false;
                    MenuPopup = 0;
                    ShowInventory = false;
                    
                }
            }
        }
        public void OnCrafting(GameTime gameTime)
        {
            for (int i = 0; i < BagList.Count; i++)
            {
                CraftList.Add(BagList[i]);
                BagList.RemoveAt(i);
                break;
            }
        }




    }
}
