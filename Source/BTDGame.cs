using BTDMG.Source.GameContent.Assets;
using BTDMG.Source.Internals.DataStructures.Drawing;
using BTDMG.Source.Internals.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BTDMG.Source
{
    /// <summary>
    ///     Main game class.
    /// </summary>
    public sealed class BTDGame : Game
    {
        /// <summary>
        ///     Cursor drawing options. The cursor will always be drawn on top of everything else in the game.
        /// </summary>
        public static CursorDrawOptions cursorDrawOptionData;

        internal BTDGame()
        {
            GDManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
            Window.AllowUserResizing = true;
            Instance = this;
        }

        public static BTDGame Instance { get; private set; }

        /// <summary>
        ///     <see cref="GraphicsDeviceManager" /> used by <see cref="BTDGame" />.
        /// </summary>
        public static GraphicsDeviceManager GDManager { get; private set; }

        /// <summary>
        ///     A generic <see cref="SpriteBatch" /> used for common drawing.
        /// </summary>
        public static SpriteBatch GenericSB { get; private set; }

        protected override void LoadContent()
        {
            GenericSB = new SpriteBatch(GraphicsDevice);

            AssetLoader.Load(Content);

            cursorDrawOptionData = new CursorDrawOptions(true, true, Assets.CursorTexture);
        }

        protected override void Update(GameTime gameTime)
        {
            Window.IsBorderless = true;
            if (Keyboard.GetState().AreKeysDown(Keys.LeftAlt, Keys.Enter))
            {
                if (GDManager.IsFullScreen)
                {
                    if (Window.IsBorderless)
                    {
                        //Window.IsBorderless = false;
                        GDManager.ToggleFullScreen();
                    }
                    else
                    {
                        Window.IsBorderless = true;
                        GDManager.ApplyChanges();
                    }
                }
                else
                {
                    GDManager.ToggleFullScreen();
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            InitializeSpriteBatches();

            GenericSB.End();

            base.Draw(gameTime);
        }

        private static void InitializeSpriteBatches()
        {
            GenericSB.Begin(SpriteSortMode.FrontToBack,
                BlendState.AlphaBlend,
                SamplerState.LinearClamp,
                DepthStencilState.Default,
                RasterizerState.CullCounterClockwise,
                null,
                Matrix.Identity);
        }
    }
}