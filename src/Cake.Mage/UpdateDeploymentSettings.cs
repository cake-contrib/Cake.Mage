using Cake.Core.IO;

namespace Cake.Mage
{
    /// <summary>
    /// Settings for updating a deployment manifest.
    /// </summary>
    /// <seealso cref="Cake.Mage.BaseNewAndUpdateDeploymentSettings" />
    public class UpdateDeploymentSettings : BaseNewAndUpdateDeploymentSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateDeploymentSettings"/> class.
        /// </summary>
        /// <param name="fileToUpdate">The file to update.</param>
        public UpdateDeploymentSettings(FilePath fileToUpdate)
        {
            FileToUpdate = fileToUpdate;
        }

        /// <summary>
        /// Gets or sets the file to update.
        /// </summary>
        /// <value>The file to update.</value>
        public FilePath FileToUpdate { get; set; }
    }
}