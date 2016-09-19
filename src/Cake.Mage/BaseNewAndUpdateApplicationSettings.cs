using Cake.Core.IO;

namespace Cake.Mage
{
    /// <summary>
    /// Class BaseNewAndUpdateApplicationSettings.
    /// </summary>
    /// <seealso cref="Cake.Mage.BaseNewAndUpdateMageSettings" />
    public abstract class BaseNewAndUpdateApplicationSettings : BaseNewAndUpdateMageSettings
    {
        /// <summary>
        /// Gets or sets the directory to recursively search for files to include in
        /// an application manifest.
        /// </summary>
        /// <value>From directory.</value>
        public DirectoryPath FromDirectory { get; set; }
        
        /// <summary>
        /// Gets or sets if the deployment manifest will include the deployment
        /// provider URL.
        /// </summary>
        /// <value>The icon file.</value>
        public FilePath IconFile { get; set; }

        /// <summary>
        /// Gets or sets the trust level to be included in the application manifest
        /// being generated or updated.
        /// </summary>
        /// <value>The trust level.</value>
        public TrustLevel TrustLevel { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether if the application manifest will be used for certification and
        /// branding information.
        /// </summary>
        /// <value>The use manifest for trust.</value>
        public bool UseManifestForTrust { get; set; } = false;
    }
}