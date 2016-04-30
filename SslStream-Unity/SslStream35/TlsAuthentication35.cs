using Org.BouncyCastle.Crypto.Tls;

namespace SslStream35
{
    internal class TlsAuthentication35 : TlsAuthentication
    {
        public TlsCredentials GetClientCredentials(CertificateRequest certificateRequest)
        {
            return null;
        }

        public void NotifyServerCertificate(Certificate serverCertificate)
        {
        }
    }
}
