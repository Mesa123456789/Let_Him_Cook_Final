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
        //public static Char01 playerRun;
        Camera _camera;
        Enemy enemy;
        //Menu menu;
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
        ////////////////Player////////////////////
        Vector2 CharPosition = new Vector2(770,450);
        private const float Rotation = 0;
        private const float Scale = 1.0f;
        private const float Depth = 0.5f;
        private const int Frames = 5;
        private const int FramesPerSec = 10;
        private const int FramesRow = 4;
        ////////////////List////////////////////
        public static List<Food> bag = new List<Food>();
        public static List<Food> foodList = new();
        public static List<Enemy> enemyList = new();
        ////////////////boolean////////////////////
        bool ShowInventory = false;
        bool IsEnd = false;
        private bool isCameraEnabled = true;
        bool isMenu;
        bool isGameplay;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            WindowSize = new(1600,900);
            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 900;
            _graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            inputText = new StringBuilder();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Window.TextInput += TextInputHandler;
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
            enemyList.Add(new Enemy(foodTexture,new Vector2(450, 250)));
            enemyList.Add(new Enemy(foodTex2, new Vector2(400, 400)));
            foodList.Add(new Food(foodTex3, new Vector2(300,300)));
            foodList.Add(new Food(foodTex4, new Vector2(150, 150)));
            foodList.Add(new Food(foodTex5, new Vector2(300, 200)));
            foodList.Add(new Food(foodTex6, new Vector2(380, 330)));
            foodList.Add(new Food(foodTex7, new Vector2(230, 260)));
            //foodList.Add(new Food(foodTex8, new Vector2(300, 200)));
            //foodList.Add(new Food(foodTex9, new Vector2(100, 200)));
            //enemyList.Add(new Enemy(foodTex10, new Vector2(100, 250)));
            enemyList.Add(new Enemy(foodTex11, new Vector2(150, 280)));
            //font
            inputFont = Content.Load<SpriteFont>("inputText");
            font = Content.Load<SpriteFont>("MyFont");
            heart = Content.Load<SpriteFont>("Heart");
            //asset_01 = Content.Load<Texture2D>("Assets");
            bg = Content.Load<Texture2D>("map");
            menu1 = Content.Load<Texture2D>("map");
            //door = Content.Load<Texture2D>("end");
            inventory = Content.Load<Texture2D>("inventory");
            _camera = new Camera();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            isMenu = true;
            Rectangle Door = new Rectangle(850,300, 50,50);
            player.Update(gameTime , GraphicsDevice.Viewport);
            ////////////////Camera////////////////////
            
                _camera.Follow(player);
            
            ////////////////Food.Update////////////////////
            for (int i = foodList.Count - 1; i >= 0; i--)
            {
                foodList[i].Update(gameTime);
            }
            for (int i = enemyList.Count - 1; i >= 0; i--)
            {
                enemyList[i].Update(gameTime);
            }
            ////////////////Inventory////////////////////
            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                ShowInventory = true;
            }
            else
            {
                ShowInventory = false;
            }
            ////////////////Scene////////////////////
            if (player.playerBox.Intersects(Door))
            {
                IsEnd = true;
            }
            else
            {
                IsEnd = false;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(transformMatrix: _camera.Transform);
            ////////////////Map////////////////////
            _spriteBatch.Draw(bg,new Rectangle(0,0,1600,900), Color.White);
            ////////////////List<Bag>////////////////////
            _spriteBatch.DrawString(font, bag.Count.ToString(), new Vector2(10, 10), Color.White);
            ////////////////Life////////////////////
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
            ////////////////player////////////////////
            player.Draw(_spriteBatch);
            ////////////////Scene////////////////////
            //if (IsEnd == true)
            //{
            //    _spriteBatch.Draw(door, new Rectangle(300, 300, 556, 491), Color.White);
            //}
            ////////////////Inventory////////////////////
            if (ShowInventory == true)
            {
                _spriteBatch.Draw(inventory, new Rectangle(500, 300, 605, 360), Color.White);
                player.DrawInventory(_spriteBatch);
                for (int i = 0; i < bag.Count; i++)
                {

                    _spriteBatch.Draw(bag[i].foodTexture, new Vector2(690 + i * 47, 360), Color.White);

                }

            }
            //_spriteBatch.DrawString(inputFont, inputText.ToString(), new Vector2(100, 100), Color.White);
            ////////////////menu////////////////////
            //if (isMenu == true)
            //{
            //    _spriteBatch.Draw(menu1, new Rectangle(0, 0, 1600, 900), Color.White);
            //}
            _spriteBatch.End();

            base.Draw(gameTime);
        }
        private void TextInputHandler(object sender, TextInputEventArgs e)
        {
            if (e.Key == Keys.Back && inputText.Length > 0)
            {
                inputText.Remove(inputText.Length - 1, 1);
            }
            else if (!char.IsControl(e.Character))
            {
                inputText.Append(e.Character);
            }
        }
        protected override void UnloadContent()
        {
            Window.TextInput -= TextInputHandler;
            base.UnloadContent();
        }

    }
}
