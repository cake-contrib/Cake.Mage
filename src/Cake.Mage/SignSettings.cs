using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Mage
{
    /// <summary>
    /// Class SignSettings.
    /// </summary>
    /// <seealso cref="Cake.Core.Tooling.ToolSettings" />
    public class SignSettings : ToolSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SignSettings"/> class.
        /// </summary>
        /// <param name="fileToSign">The file to sign.</param>
        public SignSettings(FilePath fileToSign)
        {
            FileToSign = fileToSign;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SignSettings"/> class.
        /// </summary>
        public SignSettings()
        {
        }

        /// <summary>
        /// Gets or sets the file to sign.
        /// </summary>
        /// <value>The file to sign.</value>
        public FilePath FileToSign { get; set; }

        /// <summary>
        /// Gets or sets the location of a digital certificate for signing a manifest
        /// </summary>
        /// <value>The password.</value>
        public FilePath CertFile { get; set; }

        /// <summary>
        /// <para>
        /// Gets or sets the hash of a digital certificate stored in the personal certificate store
        /// of the client computer. This corresponds to the Thumbprint property of a 
        /// digital certificate viewed in the Windows Certificates Console.
        /// </para>
        /// <para>
        /// The hashSignature can be either uppercase or lowercase, and can be supplied either
        ///  as a single string or with each octet of the Thumbprint separated by spaces and 
        /// the entire Thumbprint enclosed in quotation marks.
        /// </para>
        /// </summary>
        /// <value>The cert hash.</value>
        public string CertHash { get; set; }

        /// <summary>
        /// Gets or sets the password that is used for signing a manifest with a digital certificate. Must be 
        /// used in conjunction with the CertFile option.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the output path of the file that has been created or modified.
        /// </summary>
        /// <value>To file.</value>
        public FilePath ToFile { get; set; }
    }
}