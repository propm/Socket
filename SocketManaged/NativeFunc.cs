using System;
using System.Runtime.InteropServices;

namespace SocketManaged
{
    internal static class NativeFunc
    {
        [DllImport("SocketClient.dll")]
        internal static extern bool setup();

        [DllImport("SocketClient.dll")]
        internal static extern int update();

        [DllImport("SocketClient.dll")]
        internal static extern void close();
    }
}