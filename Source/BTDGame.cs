#nullable enable
using System.Collections.Generic;
using System.Linq;
using BTDMG.Source.GameContent.Assets;
using BTDMG.Source.Internals.Framework.AssetFramework;
using BTDMG.Source.Internals.Framework.DataStructures.Drawing;
using BTDMG.Source.Internals.Framework.DataStructures.Time;
using BTDMG.Source.Internals.IDs;
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

        public static long TotalGameTicks;

        internal BTDGame()
        {
            GDManager = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";

            Window.AllowUserResizing = true;

            Instance = this;
        }

        public static BTDGame Instance { get; private set; } = null!;

        /// <summary>
        ///     <see cref="GraphicsDeviceManager" /> used by <see cref="BTDGame" />.
        /// </summary>
        public static GraphicsDeviceManager GDManager { get; private set; } = null!;

        /// <summary>
        ///     A generic <see cref="SpriteBatch" /> used for common drawing.
        /// </summary>
        public static SpriteBatch GenericSB { get; private set; } = null!;

        /// <summary>
        ///     The current window mode the game is in. Use <see cref="WindowUtils.CycleWindowMode" /> or <see cref="WindowUtils.SetWindowMode" /> to
        ///     change modes.
        /// </summary>
        public static WindowType WindowMode { get; internal set; } = WindowType.Windowed;

        /// <summary>
        ///     A dictionary used for storing times. Useful for cleaner pseudo-timers with <see cref="GameTime" />.
        /// </summary>
        public static Dictionary<string, TimeCapsule> TimeCapsules { get; } = new();

        protected override void LoadContent()
        {
            GenericSB = new SpriteBatch(GraphicsDevice);

            AssetLoader.LoadAssets();

            cursorDrawOptionData = new CursorDrawOptions(true, true, TextureAssets.CursorTexture);
        }

        protected override void Update(GameTime gameTime)
        {
            TotalGameTicks++;

            foreach (TimeCapsule timeCapsule in TimeCapsules.Keys.ToList().Select(key => TimeCapsules[key]))
                timeCapsule.UpdateCurrent(gameTime, TotalGameTicks);

            if (Keyboard.GetState().AreKeysDown(Keys.LeftAlt, Keys.Enter))
            {
                TimeCapsules.GetOrCreate(BTDMGTimeCapsuleID.CycleWindowCapsule,
                    new TimeCapsule(gameTime, TotalGameTicks), out TimeCapsule capsule);

                if (capsule.Valid(10))
                {
                    // WindowUtils.CycleWindowMode();
                    capsule.UpdateCache(gameTime, TotalGameTicks);
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            InitializeSpriteBatches();

            CursorDrawOptions.Draw(cursorDrawOptionData, GenericSB);

            GenericSB.End();
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