using BTDMG.Internals.Assets;
using BTDMG.Internals.DataStructures.Drawing;
using BTDMG.Internals.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BTDMG
{
    public class BTDGame : Game
    {
        /// <summary>
        ///     Cursor drawing options. The cursor will always be drawn on top of everything else in the game.
        /// </summary>
        public static CursorOptions CursorOptionData;

        internal BTDGame()
        {
            GDManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
            Window.AllowUserResizing = true;
        }

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

            CursorOptionData = new CursorOptions(true, true, Assets.CursorTexture);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            GenericSB.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.LinearClamp,
                DepthStencilState.Default, RasterizerState.CullCounterClockwise, null, Matrix.Identity);

            if (CursorOptionData.DrawCursor)
            {
                IsMouseVisible = !CursorOptionData.DrawCustomCursorTexture;

                if (CursorOptionData.DrawCustomCursorTexture)
                {
                    GenericSB.Draw(CursorOptionData.CustomCursorTexture, Mouse.GetState().Position.ToVector2(), null,
                        CursorOptionData.CursorColor, 0f, Assets.CursorTexture.Size() / 2f, Vector2.One,
                        SpriteEffects.None, 1f);
                }
            }
            else
            {
                IsMouseVisible = false;
            }

            GenericSB.End();

            base.Draw(gameTime);
        }
    }
}