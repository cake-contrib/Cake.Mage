using System;
using Cake.Core.IO;

namespace Cake.Mage
{
    public abstract class BaseNewAndUpdateDeploymentSettings : BaseNewAndUpdateMageSettings
    {
        /// <summary>
        /// Specifies the code base of the app manifest to be placed in the
        /// deployment manifest being generated or updated.
        /// </summary>
        /// <value>The application code base.</value>
        public string AppCodeBase { get; set; }

        /// <summary>
        /// Specifies the local path to an application manifest that is being
        /// referenced from the deployment manifest being generated or updated.
        /// </summary>
        /// <value>The application manifest.</value>
        public FilePath AppManifest { get; set; }

        /// <summary>
        /// Specifies if the deployment manifest will include the deployment
        /// provider URL.
        /// </summary>
        /// <value>The include provider URL.</value>
        public bool IncludeProviderUrl { get; set; } = true;

        /// <summary>
        /// Specifies if the application will be an installed or an online only
        /// application.
        /// </summary>
        /// <value>The install.</value>
        public bool Install { get; set; } = true;

        /// <summary>
        /// Specifies whether the manifest being generated specifies a minimum version.
        /// Must be of the form "0.0.0.0".  Specifying "none" removes this from the manifest.
        /// </summary>
        /// <value>The minimum version.</value>
        public string MinVersion { get; set; }

        /// <summary>
        /// Specifies the provider URL to be use in the deployment manifest being
        /// generated or updated.
        /// </summary>
        /// <value>The provider URL.</value>
        public Uri ProviderUrl { get; set; }
    }
}