﻿using System;

namespace Patchwork.Framework.Platform.Window
{
    [Flags]
    public enum NativeWindowDecorations
    {
        None = 0,
        CloseButton,
        MinimizeButton,
        MaximizeButton,
        Titlebar,
        Border,
        All = CloseButton | MinimizeButton | MaximizeButton | Titlebar | Border
    }
}