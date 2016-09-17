using System;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Mage
{
    /// <summary>
    /// Class MageSettings.
    /// </summary>
    public class BaseNewAndUpdateMageSettings : ToolSettings
    {
        /// <summary>
        /// Specifies the algorithm to generate digests.
        /// </summary>
        /// <value>The algorithm.</value>
        public Algorithm Algorithm { get; set; } = Algorithm.SHA1RSA;

        /// <summary>
        /// Specifies the name of an X509 certificate file with which to sign a
        /// manifest or license file.This option requires the -Password option.
        /// </summary>
        /// <value>The cert file.</value>
        public FilePath CertFile { get; set; }

        /// <summary>
        /// Specifies the hash of an X509 certificate in your local cert store.
        /// </summary>
        /// <value>The cert hash.</value>
        public string CertHash { get; set; }

        /// <summary>
        /// Specifies the name of the application whose manifest is being
        /// generated or updated.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Specifies the password to use with an X509 certificate when signing
        /// a manifest or license file.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }

        /// <summary>
        /// Specifies the processor architecture of the application whose manifest
        /// is being generated or updated.
        /// </summary>
        /// <value>The processor.</value>
        public Processor? Processor { get; set; }
        
        /// <summary>
        /// Specifies the name of the publisher.  Names which include spaces should
        /// be enclosed in quotes.
        /// </summary>
        /// <value>The publisher.</value>
        public string Publisher { get; set; }

        /// <summary>
        /// Existing file to be signed.
        /// </summary>
        /// <value>The sign file path.</value>
        public FilePath SignFilePath { get; set; }

        /// <summary>
        /// Specifies the support URL for the application.
        /// </summary>
        /// <value>The support URL.</value>
        public Uri SupportUrl { get; set; }

        /// <summary>
        /// Specifies the URI to use for timestamping during signing.
        /// </summary>
        /// <value>The time stamp URI.</value>
        public Uri TimeStampUri { get; set; }

        /// <summary>
        /// Specifies the name of the file to save the output of a sign, new, or
        /// update command.
        /// </summary>
        /// <value>To file.</value>
        public FilePath ToFile { get; set; }

        /// <summary>
        ///  Specifies the version of the application whose manifest is being
        /// generated or updated.Must be of the form "0.0.0.0".
        /// </summary>
        /// <value>The version.</value>
        public string Version { get; set; }

        /// <summary>
        /// Specifies whether the application is a Windows Presentation Foundation Browser Application or not.
        /// </summary>
        /// <value>The WPF browser application.</value>
        public bool WpfBrowserApp { get; set; } = false;


    }
}