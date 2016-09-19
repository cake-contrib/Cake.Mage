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
        /// Gets or sets the algorithm to generate digests.
        /// </summary>
        /// <value>The algorithm.</value>
        public Algorithm Algorithm { get; set; } = Algorithm.SHA1RSA;

        /// <summary>
        /// Gets or sets the name of an X509 certificate file with which to sign a
        /// manifest or license file.This option requires the -Password option.
        /// </summary>
        /// <value>The cert file.</value>
        public FilePath CertFile { get; set; }

        /// <summary>
        /// Gets or sets the hash of an X509 certificate in your local cert store.
        /// </summary>
        /// <value>The cert hash.</value>
        public string CertHash { get; set; }

        /// <summary>
        /// Gets or sets the name of the application whose manifest is being
        /// generated or updated.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the password to use with an X509 certificate when signing
        /// a manifest or license file.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the processor architecture of the application whose manifest
        /// is being generated or updated.
        /// </summary>
        /// <value>The processor.</value>
        public Processor? Processor { get; set; }

        /// <summary>
        /// Gets or sets the name of the publisher.  Names which include spaces should
        /// be enclosed in quotes.
        /// </summary>
        /// <value>The publisher.</value>
        public string Publisher { get; set; }

        /// <summary>
        /// Gets or sets the support URL for the application.
        /// </summary>
        /// <value>The support URL.</value>
        public Uri SupportUrl { get; set; }

        /// <summary>
        /// Gets or sets the URI to use for time stamping during signing.
        /// </summary>
        /// <value>The time stamp URI.</value>
        public Uri TimeStampUri { get; set; }

        /// <summary>
        /// Gets or sets the name of the file to save the output of a sign, new, or
        /// update command.
        /// </summary>
        /// <value>To file.</value>
        public FilePath ToFile { get; set; }

        /// <summary>
        /// Gets or sets the version of the application whose manifest is being
        /// generated or updated.Must be of the form "0.0.0.0".
        /// </summary>
        /// <value>The version.</value>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the application is a Windows Presentation Foundation Browser Application or not.
        /// </summary>
        /// <value>The WPF browser application.</value>
        public bool WpfBrowserApp { get; set; } = false;
    }
}