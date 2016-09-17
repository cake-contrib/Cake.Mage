#r "../../src/Cake.Mage/bin/Release/Cake.Mage.dll"

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories.
var buildDir = Directory("./WindowsFormsApplication1/bin") + Directory(configuration);

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectory(buildDir);
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    NuGetRestore("./WindowsFormsApplication1.sln");
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    if(IsRunningOnWindows())
    {
      // Use MSBuild
      MSBuild("./WindowsFormsApplication1.sln", settings =>
        settings
            .SetConfiguration(configuration)
            .SetVerbosity(Verbosity.Minimal));
    }
    else
    {
      // Use XBuild
      XBuild("./WindowsFormsApplication1.sln", settings =>
        settings.SetConfiguration(configuration));
    }
});

Task("Build-Click-Once")
    .IsDependentOn("Build")
    .Does(() =>
{
    EnsureDirectoryExists("./dist");
    CleanDirectory("./dist");

    MageNewApplication(new NewApplicationSettings{
        ToFile = "./dist/WindowsFormsApplication1.manifest",
        Name = "Windows Form Application",
        Version = "1.0.0.0",
        FromDirectory = "./WindowsFormsApplication1/bin/Release"
    });

    MageUpdateApplication(new UpdateApplicationSettings("./dist/WindowsFormsApplication1.manifest") {
        UseManifestForTrust = true,
        SupportUrl = new Uri("http://www.example.com"),
        FromDirectory = "./WindowsFormsApplication1/bin/Release"
    });

    MageNewDeployment(new NewDeploymentSettings{
        AppManifest = "./dist/WindowsFormsApplication1.manifest",
        ToFile = "./dist/WindowsFormsApplication1.application",
        ProviderUrl = new Uri("\\\\myServer\\myShare\\WindowsFormsApplication1.application")
    });

    MageUpdateDeployment(new UpdateDeploymentSettings("./dist/WindowsFormsApplication1.application") {
        ProviderUrl = new Uri("\\\\myServerOtherServer\\myShare\\WindowsFormsApplication1.application")
    });
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Build-Click-Once");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);