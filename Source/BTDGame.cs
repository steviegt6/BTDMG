#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using BTDMG.Source.GameContent.Assets;
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

        internal BTDGame()
        {
            GDManager = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            
            Window.AllowUserResizing = true;
            Window.ClientSizeChanged += HandleWindowResizing;

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
        ///     The current window mode the game is in. Use <see cref="CycleWindowMode"/> or <see cref="SetWindowMode"/> to change modes.
        /// </summary>
        public static WindowType WindowMode { get; private set; } = WindowType.Windowed;

        /// <summary>
        ///     A dictionary used for storing times. Useful for cleaner pseudo-timers with <see cref="GameTime"/>.
        /// </summary>
        public static Dictionary<string, TimeCapsule> TimeCapsules { get; } = new Dictionary<string, TimeCapsule>();

        public static long TotalGameTicks;

        protected override void LoadContent()
        {
            GenericSB = new SpriteBatch(GraphicsDevice);

            AssetLoader.Load(Content);

            cursorDrawOptionData = new CursorDrawOptions(true, true, Assets.CursorTexture);
        }

        protected override void Update(GameTime gameTime)
        {
            TotalGameTicks++;

            foreach (TimeCapsule timeCapsule in TimeCapsules.Keys.ToList().Select(key => TimeCapsules[key]))
                timeCapsule.UpdateCurrent(gameTime, TotalGameTicks);

            if (Keyboard.GetState().AreKeysDown(Keys.LeftAlt, Keys.Enter))
            {
                TimeCapsules.GetOrCreate(BTDMGTimeCapsuleID.CycleWindowCapsule, new TimeCapsule(gameTime, TotalGameTicks), out TimeCapsule capsule);

                if (capsule.Valid(10))
                {
                    CycleWindowMode();
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

        public void CycleWindowMode()
        {
            switch (WindowMode)
            {
                case WindowType.Windowed:
                    SetWindowMode(Environment.OSVersion.Platform != PlatformID.MacOSX
                        ? WindowType.Borderless
                        : WindowType.Fullscreen);
                    break;

                case WindowType.Borderless:
                    SetWindowMode(WindowType.Fullscreen);
                    break;

                case WindowType.Fullscreen:
                    SetWindowMode(WindowType.Windowed);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void SetWindowMode(WindowType type)
        {
            switch (type)
            {
                case WindowType.Windowed:
                    GDManager.IsFullScreen = false;
                    Window.IsBorderless = false;
                    break;

                case WindowType.Borderless:
                    GDManager.IsFullScreen = false;
                    Window.IsBorderless = true;
                    break;

                case WindowType.Fullscreen:
                    GDManager.IsFullScreen = true;
                    Window.IsBorderless = false;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            WindowMode = type;
            GDManager.ApplyChanges();
        }

        public void HandleWindowResizing(object? sender, EventArgs e)
        {
            if (!GDManager.IsFullScreen && !Window.IsBorderless)
                return;

            GDManager.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            GDManager.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;

            try
            {
                GDManager.ApplyChanges();
            }
            catch (StackOverflowException)
            {
                // what
            }
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