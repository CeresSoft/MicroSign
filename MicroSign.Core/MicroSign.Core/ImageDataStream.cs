using System;
using System.IO;

namespace MicroSign.Core
{
    /// <summary>
    /// 画像データ用ストリーム
    /// </summary>
    /// <remarks>
    /// https://pierre3.hatenablog.com/entry/2015/10/25/001207
    /// BitmapImage向けのStream
    /// BitmapImage.StreamSourceに渡したStreamは解除できない(=nullを渡しても解除できない)ので
    /// Streamをラップし、ラップしたStreamのDispose
    /// </remarks>
    public class ImageDataStream : Stream
    {
        /// <summary>
        /// 内部ストリーム
        /// </summary>
        public Stream? InnnerStream { get; protected set; } = null;

        /// <summary>
        /// 破棄フラグ
        /// </summary>
        public bool IsDispose { get; protected set; } = false;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="innerStream"></param>
        public ImageDataStream(Stream innerStream)
        {
            this.InnnerStream = innerStream;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="data"></param>
        public ImageDataStream(byte[] data)
        {
            this.InnnerStream = new MemoryStream(data);
        }

        /// <summary>
        /// 破棄
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            this.IsDispose = true;
            if (disposing)
            {
                //disposeしたら内部ストリームをnullにして参照を外す
                CommonUtils.SafeDispose(this.InnnerStream);
                this.InnnerStream = null;
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// ストリーム取得
        /// </summary>
        protected Stream GetStream()
        {
            //破棄判定
            bool isDispose = this.IsDispose;
            if(isDispose)
            {
                //破棄済み
                throw new ObjectDisposedException(this.GetType().Name);
            }

            //ストリーム取得
            Stream? s = this.InnnerStream;
            if(s == null)
            {
                //無効な状態
                throw new InvalidOperationException(this.GetType().Name);
            }
            return s;
        }

        /// <summary>
        /// 読み取りをサポート
        /// </summary>
        public override bool CanRead
        {
            get
            {
                return this.GetStream().CanRead;
            }
        }

        /// <summary>
        /// シークをサポート
        /// </summary>
        public override bool CanSeek
        {
            get
            {
                return this.GetStream().CanSeek;
            }
        }

        /// <summary>
        /// 書き込みをサポート
        /// </summary>
        public override bool CanWrite
        {
            get
            {
                return this.GetStream().CanWrite;
            }
        }

        /// <summary>
        /// 長さ
        /// </summary>
        public override long Length
        {
            get
            {
                return this.GetStream().Length;
            }
        }

        /// <summary>
        /// 位置
        /// </summary>
        public override long Position
        {
            get
            {
                return this.GetStream().Position;
            }
            set
            {
                this.GetStream().Position = value;
            }
        }

        /// <summary>
        /// Flush
        /// </summary>
        public override void Flush()
        {
            this.GetStream().Flush();
        }

        /// <summary>
        /// 読み込み
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public override int Read(byte[] buffer, int offset, int count)
        {
            return this.GetStream().Read(buffer, offset, count);
        }

        /// <summary>
        /// シーク
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="origin"></param>
        /// <returns></returns>
        public override long Seek(long offset, SeekOrigin origin)
        {
            return this.GetStream().Seek(offset, origin);
        }

        /// <summary>
        /// 長さ設定
        /// </summary>
        /// <param name="value"></param>
        public override void SetLength(long value)
        {
            this.GetStream().SetLength(value);
        }

        /// <summary>
        /// 書き込み
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        public override void Write(byte[] buffer, int offset, int count)
        {
            this.GetStream().Write(buffer, offset, count);
        }
    }
}
