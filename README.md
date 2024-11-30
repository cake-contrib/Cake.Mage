# Cake.Mage

The Cake.Mage addin adds Mage.exe support to Cake

[![License](http://img.shields.io/:license-mit-blue.svg)](http://cake-contrib.mit-license.org)

## Information

| | Stable | Pre-release |
|---|---|---|
|GitHub Release|-|[![GitHub release](https://img.shields.io/github/release/cake-contrib/Cake.Mage.svg)](https://github.com/cake-contrib/Cake.Mage/releases/latest)|
|NuGet|[![NuGet](https://img.shields.io/nuget/v/Cake.Mage.svg)](https://www.nuget.org/packages/Cake.Mage)|[![NuGet](https://img.shields.io/nuget/vpre/Cake.Mage.svg)](https://www.nuget.org/packages/Cake.Mage)|

## Build Status

|Develop|Master|
|:--:|:--:|
|[![Build status](https://ci.appveyor.com/api/projects/status/5hl4g2ilm5rmsj84/branch/develop?svg=true)](https://ci.appveyor.com/project/cakecontrib/cake-mage/branch/develop)|[![Build status](https://ci.appveyor.com/api/projects/status/5hl4g2ilm5rmsj84/branch/develop?svg=true)](https://ci.appveyor.com/project/cakecontrib/cake-mage/branch/master)|

## Code Coverage

[![Coverage Status](https://coveralls.io/repos/github/cake-contrib/Cake.Mage/badge.svg?branch=develop)](https://coveralls.io/github/cake-contrib/Cake.Mage?branch=develop)

## Quick Links

- [Documentation](https://cake-contrib.github.io/Cake.Mage)

## Breaking changes

2.0.0

- References Cake 5.0.0
- Supports .NET 8.0 and .NET 9.0
- Drops support for mage.exe tool that comes with SDK
- Adds support for dotnet-mage tool - make sure you include [Microsoft.DotNet.Mage](https://www.nuget.org/packages/Microsoft.DotNet.Mage/) nuget package in your script

1.1.0

- References Cake 4.0.0
- Supports .net 6+

1.0.0

- References cake 1.0.0
- Add paths for .net 4.8, add logging of tool lookup

0.4

- BaseNewAndUpdateDeploymentSettings.Install is false by default

## Discussion

If you have questions, search for an existing one, or create a new discussion on the Cake GitHub repository, using the `extension-q-a` category.

[![Join in the discussion on the Cake repository](https://img.shields.io/badge/GitHub-Discussions-green?logo=github)](https://github.com/cake-build/cake/discussions/categories/extension-q-a)

## Build

To build this package we are using Cake.

On Windows PowerShell run:

```powershell
./build
```