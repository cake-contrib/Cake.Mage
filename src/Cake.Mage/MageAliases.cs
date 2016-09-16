using System;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Mage
{
    [CakeAliasCategory("Mage")]
    public static class MageAliases
    {
        [CakeMethodAlias]
        public static void MageNewApplication(this ICakeContext context, NewApplicationSettings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            NewOrUpdate(context, settings);
        }

        [CakeMethodAlias]
        public static void MageNewDeployment(this ICakeContext context, NewDeploymentSettings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            NewOrUpdate(context, settings);
        }

        [CakeMethodAlias]
        public static void MageUpdateApplication(this ICakeContext context, UpdateApplicationSettings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            NewOrUpdate(context, settings);
        }

        [CakeMethodAlias]
        public static void MageUpdateDeployment(this ICakeContext context, UpdateDeploymentSettings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            NewOrUpdate(context, settings);
        }

        private static void NewOrUpdate(ICakeContext context, BaseNewAndUpdateMageSettings settings)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            var resolver = new DotNetToolResolver(context.FileSystem, context.Environment, context.Registry);
            var runner = new NewOrUpdateMageTool(context.FileSystem, context.Environment,context.ProcessRunner, context.Tools, context.Registry, resolver);
            runner.NewOrUpdate(settings);
        }
    }
}
