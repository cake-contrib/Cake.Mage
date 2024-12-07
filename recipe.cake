#load nuget:?package=Cake.Recipe&version=3.1.1

Environment.SetVariableNames();

BuildParameters.SetParameters(
    context: Context,
    buildSystem: BuildSystem,
    sourceDirectoryPath: "./src",
    title: "Cake.Mage",
    repositoryOwner: "cake-contrib",
    repositoryName: "Cake.Mage",
    appVeyorAccountName: "cakecontrib",
	shouldPostToGitter: false,
    shouldRunInspectCode: false,
	shouldRunCodecov: false,
    shouldRunDotNetCorePack: true,
    shouldRunCoveralls: false); // Disabled because it's currently failing

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolPreprocessorDirectives(
    gitReleaseManagerGlobalTool: "#tool dotnet:?package=GitReleaseManager.Tool&version=0.18.0",
    nugetTool: "#tool nuget:?package=NuGet.CommandLine&version=6.12.1",
    gitVersionGlobalTool: "#tool dotnet:?package=GitVersion.Tool&version=5.12.0"
);

ToolSettings.SetToolSettings(
    context: Context,
    testCoverageFilter: "+[*]* -[nunit.*]* -[Cake.Core]* -[Cake.Testing]* -[*.Tests]*",
    testCoverageExcludeByAttribute: "*.ExcludeFromCodeCoverage*",
    testCoverageExcludeByFile: "*/*Designer.cs;*/*.g.cs;*/*.g.i.cs");
Build.RunDotNetCore();
