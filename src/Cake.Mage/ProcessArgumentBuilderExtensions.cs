using System;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Mage
{
    internal static class ProcessArgumentBuilderExtensions
    {
        public static ProcessArgumentBuilder AppendNonEmptySwitch(this ProcessArgumentBuilder builder, string @switch, string text)
        {
            return string.IsNullOrWhiteSpace(text) == false ? builder.AppendSwitch(@switch, text) : builder;
        }

        public static ProcessArgumentBuilder AppendNonEmptyQuotedSwitch(this ProcessArgumentBuilder builder, string @switch, string text)
        {
            return string.IsNullOrWhiteSpace(text) == false ? builder.AppendSwitchQuoted(@switch, text) : builder;
        }

        public static ProcessArgumentBuilder AppendNonEmptySecretSwitch(this ProcessArgumentBuilder builder, string @switch, string text)
        {
            return string.IsNullOrWhiteSpace(text) == false ? builder.AppendSwitchSecret(@switch, text) : builder;
        }

        public static ProcessArgumentBuilder AppendNonNullSwitch(this ProcessArgumentBuilder builder, string @switch, object o)
        {
            return o != null ? builder.AppendSwitchQuoted(@switch, o.ToString()) : builder;
        }

        public static ProcessArgumentBuilder AppendNonNullFilePathSwitch(this ProcessArgumentBuilder builder, string @switch, FilePath filePath, ICakeEnvironment environment)
        {
            return filePath == null ? builder : builder.AppendSwitchQuoted(@switch, filePath.MakeAbsolute(environment).FullPath);
        }

        public static ProcessArgumentBuilder AppendNonNullDirectoryPathSwitch(this ProcessArgumentBuilder builder, string @switch, DirectoryPath directoryPath, ICakeEnvironment environment)
        {
            return directoryPath == null ? builder : builder.AppendSwitchQuoted(@switch, directoryPath.MakeAbsolute(environment).FullPath);
        }

        public static ProcessArgumentBuilder AppendNonNullUriSwitch(this ProcessArgumentBuilder builder, string @switch, Uri uri)
        {
            return uri == null ? builder : builder.AppendSwitchQuoted(@switch, uri.ToString());
        }

        public static ProcessArgumentBuilder AppendIfNotDefaultSwitch<T>(this ProcessArgumentBuilder builder, string @switch, T value, T defaultValue)
        {
            return value == null || value.Equals(defaultValue) ? builder : builder.AppendSwitch(@switch, value.ToString());
        }


    }
}