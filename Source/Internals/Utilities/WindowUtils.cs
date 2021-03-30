using System;
using BTDMG.Source.Internals.IDs;

namespace BTDMG.Source.Internals.Utilities
{
    public static class WindowUtils
    {
        public static void CycleWindowMode()
        {
            switch (BTDGame.WindowMode)
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

        public static void SetWindowMode(WindowType type)
        {
            switch (type)
            {
                case WindowType.Windowed:
                    BTDGame.GDManager.IsFullScreen = false;
                    BTDGame.Instance.Window.IsBorderless = false;
                    break;

                case WindowType.Borderless:
                    BTDGame.GDManager.IsFullScreen = false;
                    BTDGame.Instance.Window.IsBorderless = true;
                    break;

                case WindowType.Fullscreen:
                    BTDGame.GDManager.IsFullScreen = true;
                    BTDGame.Instance.Window.IsBorderless = false;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            BTDGame.WindowMode = type;
            BTDGame.GDManager.ApplyChanges();
        }
    }
}