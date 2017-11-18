using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using HeroesOfVuklut.Shared.Menu;
using HeroesOfVuklut.Windows.InputProcessor;
using HeroesOfVuklut.Windows.Resources;
using HeroesOfVuklut.Shared.Clash;
using HeroesOfVuklut.Windows.Factions;
using HeroesOfVuklut.Engine.DI;
using HeroesOfVuklut.Engine.Scenes;
using System.Reflection;
using HeroesOfVuklut.Engine.IO;

namespace HeroesOfVuklut.Windows
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ISceneNavigator SceneNavigator;
        private KeyboardProcessorImpl _inputProce;
        private GameConfiguration gameConfiguration;

        private MouseProcessorImpl _mouseProce;
        private InputInterface _inputInterface;
        private GraphicInterface graphInterface;
        private IResourceProvider resourceProvider;
        private FactionProvider factionProvider = new FactionProvider();
        private GameConfigurationProvider gameConfigurationProvider = new GameConfigurationProvider();
        private IContainerSystem Container = new ContainerSystem();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            this.graphics.PreferredBackBufferWidth = 800;
            this.graphics.PreferredBackBufferHeight = 600;

            Content.RootDirectory = "Content";


            var assembly = Assembly.GetEntryAssembly();
            Container.AddAttributeDeclarations(assembly);


            _inputInterface = Container.Resolve<IInputInterface>() as InputInterface;


            var keyState = Keyboard.GetState();
            _inputProce = new KeyboardProcessorImpl();
            _inputProce.RegisterKey("exit", Keys.Escape);

            _mouseProce = new MouseProcessorImpl();
            _mouseProce.Register("cursorLeft", MouseKeys.Left);
            _mouseProce.Register("cursorRight", MouseKeys.Right);
            
            _inputInterface.AddProcessor(_inputProce);
            _inputInterface.AddProcessor(_mouseProce);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();

            
            var mapProvider = Container.Resolve<IMapProvider>();
            SceneNavigator = Container.Resolve<ISceneNavigator>();
            

            PrepareScenes();

            gameConfiguration = gameConfigurationProvider.GetConfiguration();
            mapProvider.SetConfiguration(gameConfiguration);

            factionProvider.LoadConfiguration();
        }

        private void PrepareScenes()
        {
            var menuScene = Container.AddScene<MenuSceneManager>();
            var worldMapScene = Container.AddScene<WorldSceneManager>();
            var clashScene = Container.AddScene<ClashSceneManager>();
            
            SceneNavigator.Scenes.AddScene(menuScene);
            SceneNavigator.Scenes.SetDefault(menuScene);

            SceneNavigator.GotoScene(menuScene.GetSceneType(), menuScene.GetDefault());
            
            SceneNavigator.Scenes.AddScene(worldMapScene);
            SceneNavigator.Scenes.AddScene(clashScene);

            SceneNavigator.Scenes.AddSceneTransition(menuScene, worldMapScene);
            SceneNavigator.Scenes.AddSceneTransition(worldMapScene, clashScene);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            graphInterface = Container.Resolve<IGraphicsInterface>() as GraphicInterface;
            resourceProvider = Container.Resolve<IResourceProvider>();

            // this.graphics.IsFullScreen = true;

            graphInterface.Batch = spriteBatch;
            graphInterface.ResourceProvider = resourceProvider;

            resourceProvider.LoadTextures(Content);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            SceneNavigator.CurrentScene.ClearScene();

            _inputProce.Refresh(Keyboard.GetState());
            _mouseProce.Refresh(Mouse.GetState());

            if(_inputProce.GetButtonState("exit") == ButtonStateValue.OnClick)
            {
                Exit();
            }

            SceneNavigator.CurrentScene.ProcessInput();

            // TODO: Add your update logic here
            SceneNavigator.CurrentScene.PreUpdate();
            SceneNavigator.CurrentScene.Update(gameTime.ElapsedGameTime);
            SceneNavigator.CurrentScene.PostUpdate();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.CornflowerBlue);

            SceneNavigator.CurrentScene.Draw();

            // TODO: Add your drawing code here

            spriteBatch.End();
            
        }
    }
}
