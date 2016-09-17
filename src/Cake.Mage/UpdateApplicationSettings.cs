using Cake.Core.IO;

namespace Cake.Mage
{
    /// <summary>
    /// Settings for updating an application manifest.
    /// </summary>
    /// <seealso cref="Cake.Mage.BaseNewAndUpdateApplicationSettings" />
    public class UpdateApplicationSettings : BaseNewAndUpdateApplicationSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateApplicationSettings"/> class.
        /// </summary>
        /// <param name="fileToUpdate">The file to update.</param>
        public UpdateApplicationSettings(FilePath fileToUpdate)
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