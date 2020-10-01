﻿#region Usings
using System;
using Patchwork.Framework.Environment;
#endregion

namespace Patchwork.Framework.Platform
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class AssemblyRenderingAttribute : PlatformAttribute
    {
        public Type RenderDeviceType { get; private set; }

        /// <inheritdoc />
        public AssemblyRenderingAttribute(OSType requiredOperatingSystem, 
                                          int priority, 
                                          string name,
                                          Type managerType = null,
                                          Type renderDevice = null) 
            : base(requiredOperatingSystem, priority, name, managerType)
        {
            RenderDeviceType = renderDevice;
        }
    }
}