﻿using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Patchwork.Framework;
using Patchwork.Framework.Messaging;
using Patchwork.Framework.Platform;
using Patchwork.Framework.Platform.Interop.User32;
using Patchwork.Framework.Platform.Window;
using Shin.Framework;
using Shin.Framework.Logging.Loggers;
using Shin.Framework.Logging.Native;
using Shin.Framework.Messaging;

namespace WindowsApp
{
    internal class Program
    {
        #region Methods
        private static readonly CancellationTokenSource m_cts = new CancellationTokenSource();

        [MTAThread]
        private static void Main(string[] args)
        {
            var log = new Logger();
            log.Initialize();
            log.AddLogProvider(new ConsoleLogger());

            PlatformManager.Startup += OnStartup;
            PlatformManager.Shutdown += OnShutdown;
            PlatformManager.ProcessMessage += OnMessage;

            PlatformManager.Create(log);
            PlatformManager.CreateConsole();
            PlatformManager.Initialize();

            PlatformManager.Application.CreateWindow().Show();
            PlatformManager.Run(m_cts.Token);

            PlatformManager.Dispose();
            PlatformManager.CloseConsole();
        }

        private static void OnStartup() { }

        private static void OnShutdown()
        {
            Console.WriteLine("Press any key to exit.");
            while (!Console.KeyAvailable)
            {
                Console.Write(".");
                Thread.Sleep(250);
            }
        }

        private static void OnMessage(IPlatformMessage message)
        {
            PlatformManager.Logger.LogDebug("Message type: " + message.Id);
            switch (message.Id)
            {
                case MessageIds.Window:
                    var data = message.Data as WindowMessageData;
                    //Throw.IfNull(wmsg).ArgumentNullException(nameof(message));
                    PlatformManager.Logger.LogDebug("--Message sub type: " + data?.MessageId);
                    break;
                case MessageIds.Quit:
                    m_cts.Cancel();
                    break;
                case MessageIds.Display:
                    break;
                case MessageIds.System:
                    break;
                case MessageIds.Keyboard:
                    break;
                case MessageIds.Mouse:
                    break;
                case MessageIds.Joystick:
                    break;
                case MessageIds.Controller:
                    break;
                case MessageIds.Touch:
                    break;
                case MessageIds.Sensor:
                    break;
                case MessageIds.Audio:
                    break;
                case MessageIds.User:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
        }
        #endregion
    }
}