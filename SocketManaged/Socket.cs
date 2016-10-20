using System;

namespace SocketManaged
{
    /// <summary>
    /// ソケット通信によるデータを受信する機能を提供します。
    /// </summary>
    public class SocketReceiver : IDisposable
    {
        /// <summary>
        /// 初期化処理が完了したかどうかを表すフラグ
        /// </summary>
        public bool IsInitialized { get; private set; }

        /// <summary>
        /// 受信したデータ
        /// </summary>
        public int Data { get; private set; }

        //  リソースの破棄を行ったかどうかを表すフラグ
        private bool isDisposed = false;

        /// <summary>
        /// インスタンスを生成して、初期設定を行います。
        /// </summary>
        public SocketReceiver()
        {
            if (!NativeFunc.setup())
            {
                IsInitialized = false;
                throw new SocketInitException();
            }

            else
            {
                IsInitialized = true;
            }
        }

        /// <summary>
        /// データを受信して更新します。
        /// </summary>
        public void Update()
        {
            if (IsInitialized)
            {
                Data = NativeFunc.update();
            }
        }

        /// <summary>
        /// リソースを破棄します。
        /// </summary>
        public void Dispose()
        {
            if (!isDisposed)
            {
                NativeFunc.close();
                isDisposed = true;
            }
        }
    }
}