using System;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Mage
{
    /// <summary>
    ///  <para>Contains functionality related to the creation and editing of application and deployment manifests.  using <see href="https://msdn.microsoft.com/en-us/library/acz3y3te(v=vs.110).aspx">Mage (Manifest Generation and Editing Tool)</see>.</para>
    /// </summary>
    /// <para>
    /// In order to use the commands for this alias, Mage.exe will need to be installed on the machine where
    /// the Cake script is being executed.  This is typically achieved by installing the correct Windows SDK.
    /// </para>
    [CakeAliasCategory("Mage")]
    public static class MageAliases
    {
        /// <summary>
        /// Creates a new application manifest.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void MageNewApplication(this ICakeContext context, NewApplicationSettings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            NewOrUpdate(context, settings);
        }

        /// <summary>
        /// Creates a new deployment manifest.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// MageNewApplication(new NewApplicationSettings{
        ///     ToFile = "WindowsFormsApplication1.exe.manifest",
        ///     Name = "Windows Form Application",
        ///     Version = "1.0.0.0",
        ///     FromDirectory = "./WindowsFormsApplication1/bin/Release"
        /// });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void MageNewDeployment(this ICakeContext context, NewDeploymentSettings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            NewOrUpdate(context, settings);
        }

        /// <summary>
        /// Makes one or more changes to an application manifest file. 
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// MageUpdateApplication(new UpdateApplicationSettings("./dist/WindowsFormsApplication1.manifest"){
        ///     UseManifestForTrust = true,
        ///     SupportUrl = new Uri("http://www.example.com")
        /// });
        /// </code></example>
        [CakeMethodAlias]
        public static void MageUpdateApplication(this ICakeContext context, UpdateApplicationSettings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            NewOrUpdate(context, settings);
        }

        /// <summary>
        /// Makes one or more changes to a deployment manifest file. 
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <code>
        /// <example>
        /// MageUpdateDeployment(new UpdateDeploymentSettings("./dist/WindowsFormsApplication1.application") {
        ///     ProviderUrl = new Uri("\\\\myServerOtherServer\\myShare\\WindowsFormsApplication1.application")
        /// });
        /// </example>
        /// </code>
        [CakeMethodAlias]
        public static void MageUpdateDeployment(this ICakeContext context, UpdateDeploymentSettings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            NewOrUpdate(context, settings);
        }

        /// <summary>
        /// Signs an application or deployment.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        ///   <code>
        /// MageSign(new SignSettings("./dist/WindowsFormsApplication1.application") {
        /// CertFile = ".\\example.com.pfx",
        /// Password = "password"
        /// });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void MageSign(this ICakeContext context, SignSettings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            var resolver = new DotNetToolResolver(context.FileSystem, context.Environment, context.Registry);
            var runner = new SignMageTool(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, context.Registry, resolver);
            runner.Sign(settings);
        }

        private static void NewOrUpdate(ICakeContext context, BaseNewAndUpdateMageSettings settings)
        {
            var resolver = new DotNetToolResolver(context.FileSystem, context.Environment, context.Registry);
            var runner = new NewOrUpdateMageTool(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, context.Registry, resolver);
            runner.NewOrUpdate(settings);
        }
    }
}
