using Org.BouncyCastle.Crypto.Tls;
using Org.BouncyCastle.Security;
using System.IO;

namespace SslStream35
{
    public class TlsStream : Stream
    {
        private readonly Stream stream;
        private readonly bool closeStream;

        private readonly TlsClientProtocol tls;

        public TlsStream(Stream stream, bool closeStream)
        {
            this.stream = stream;
            this.closeStream = closeStream;
            tls = new TlsClientProtocol(stream, new SecureRandom());
        }

        public void Connect()
        {
            this.tls.Connect(new TlsClient35());
        }

        public override bool CanRead
        {
            get
            {
                return this.tls.Stream.CanRead;
            }
        }

        public override bool CanSeek
        {
            get
            {
                return this.tls.Stream.CanSeek;
            }
        }

        public override bool CanWrite
        {
            get
            {
                return this.tls.Stream.CanWrite;
            }
        }

        public override long Length
        {
            get
            {
                return this.tls.Stream.Length;
            }
        }

        public override long Position
        {
            get
            {
                return this.tls.Stream.Position;
            }

            set
            {
                this.tls.Stream.Position = value;
            }
        }

        public override void Flush()
        {
            this.tls.Stream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return this.tls.Stream.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return this.tls.Stream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            this.tls.Stream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            this.tls.Stream.Write(buffer, offset, count);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                if (this.closeStream)
                {
                    this.stream.Close();
                }

                this.tls.Close();

            }
        }
    }
}
