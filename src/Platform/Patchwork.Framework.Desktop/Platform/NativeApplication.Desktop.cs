﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Patchwork.Framework.Platform
{
    public partial class NativeApplication
    {
        /// <inheritdoc />
        public abstract bool OpenConsole();

        public abstract void CloseConsole();
    }
}
