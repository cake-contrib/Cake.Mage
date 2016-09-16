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
        settings.SetConfiguration(configuration));
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
    MageNewApplication(new NewApplicationSettings{
        ToFile = "WindowsFormsApplication1.exe.manifest",
        Name = "Windows Form Application",
        Version = "1.0.0.0",
        FromDirectory = "./WindowsFormsApplication1/bin/Release"
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