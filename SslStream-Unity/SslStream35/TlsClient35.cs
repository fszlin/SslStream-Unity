using Org.BouncyCastle.Crypto.Tls;

namespace SslStream35
{
    internal class TlsClient35 : DefaultTlsClient
    {
        public override TlsAuthentication GetAuthentication()
        {
            return new TlsAuthentication35();
        }
    }
}
