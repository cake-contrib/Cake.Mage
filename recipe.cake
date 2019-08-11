#load nuget:?package=Cake.Recipe&version=1.0.0

Environment.SetVariableNames();

BuildParameters.SetParameters(context: Context,
                            buildSystem: BuildSystem,
                            sourceDirectoryPath: "./src",
                            title: "Cake.Mage",
                            repositoryOwner: "cake-contrib",
                            repositoryName: "Cake.Mage",
                            appVeyorAccountName: "cakecontrib",
							shouldRunDupFinder: true,
							shouldRunInspectCode: true);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context,
                            dupFinderExcludePattern: new []
                            {
                                BuildParameters.RootDirectoryPath + "/src/Cake.Mage/obj/**/*.*",
                                BuildParameters.RootDirectoryPath + "/src/Cake.Mage.Tests/**/*.cs",
                            },
                            testCoverageFilter: "+[*]* -[xunit.*]* -[Cake.Core]* -[Cake.Testing]* -[*.Tests]* ",
                            testCoverageExcludeByAttribute: "*.ExcludeFromCodeCoverage*",
                            testCoverageExcludeByFile: "*/*Designer.cs;*/*.g.cs;*/*.g.i.cs");

Build.RunDotNetCore();
