using System;

namespace SocketManaged
{
    /// <summary>
    /// ソケット通信の初期化時に発生する例外を提供します。
    /// </summary>
    public class SocketInitException : Exception
    {
        internal SocketInitException() : base("ソケット通信の初期化処理でエラーが発生しました。") { }
    }
}