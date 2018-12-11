using System;
using Cake.Core.IO;

namespace Cake.Mage
{
    /// <summary>
    /// Class BaseNewAndUpdateDeploymentSettings.
    /// </summary>
    /// <seealso cref="Cake.Mage.BaseNewAndUpdateMageSettings" />
    public abstract class BaseNewAndUpdateDeploymentSettings : BaseNewAndUpdateMageSettings
    {
        /// <summary>
        /// Gets or sets the URI code base of the app manifest to be placed in the
        /// deployment manifest being generated or updated.
        /// </summary>
        /// <remarks>If specified <see cref="AppCodeBaseFilePath"/> must not be specified.</remarks>
        /// <value>The application code base.</value>
        public Uri AppCodeBaseUri { get; set; }

        /// <summary>
        /// Gets or sets the file path code base of the app manifest to be placed in the
        /// deployment manifest being generated or updated.
        /// </summary>
        /// <remarks>If specified <see cref="AppCodeBaseUri"/> must not be specified.</remarks>
        /// <value>The application code base.</value>
        public FilePath AppCodeBaseFilePath { get; set; }

        /// <summary>
        /// Gets or sets the local path to an application manifest that is being
        /// referenced from the deployment manifest being generated or updated.
        /// </summary>
        /// <value>The application manifest.</value>
        public FilePath AppManifest { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the deployment manifest will include the deployment
        /// provider URL.
        /// </summary>
        /// <value>The include provider URL.</value>
        public bool IncludeProviderUrl { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether if the application will be an installed or an online only
        /// application. Default is false.
        /// </summary>
        /// <value>The install.</value>
        public bool Install { get; set; } = false;

        /// <summary>
        /// Gets or sets whether the manifest being generated specifies a minimum version.
        /// Must be of the form "0.0.0.0".  Specifying "none" removes this from the manifest.
        /// </summary>
        /// <value>The minimum version.</value>
        public string MinVersion { get; set; }

        /// <summary>
        /// Gets or sets the provider URL to be use in the deployment manifest being
        /// generated or updated.
        /// </summary>
        /// <value>The provider URL.</value>
        public Uri ProviderUrl { get; set; }
    }
}