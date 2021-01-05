﻿using System;
using System.Runtime.CompilerServices;
using System.Windows.Threading;

namespace Meziantou.Framework.WPF
{
    public static class DispatcherExtensions
    {
        // https://medium.com/@kevingosse/switching-back-to-the-ui-thread-in-wpf-uwp-in-modern-c-5dc1cc8efa5e
        public static SwitchToUiAwaitable SwitchToDispatcherThread(this Dispatcher dispatcher)
        {
            return new SwitchToUiAwaitable(dispatcher);
        }

        public readonly struct SwitchToUiAwaitable : INotifyCompletion
        {
            private readonly Dispatcher _dispatcher;

            public SwitchToUiAwaitable(Dispatcher dispatcher)
            {
                _dispatcher = dispatcher;
            }

            public SwitchToUiAwaitable GetAwaiter()
            {
                return this;
            }

            public void GetResult()
            {
            }

            public bool IsCompleted => _dispatcher.CheckAccess();

            public void OnCompleted(Action continuation)
            {
                _dispatcher.BeginInvoke(continuation);
            }
        }
    }
}
