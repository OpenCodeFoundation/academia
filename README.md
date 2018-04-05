# Academia

[![Build Status](https://travis-ci.org/techcombd/academia.svg?branch=master)](https://travis-ci.org/techcombd/academia)
[![Build status](https://ci.appveyor.com/api/projects/status/rq56t7j772m25m1t/branch/master?svg=true)](https://ci.appveyor.com/project/ratanparai/academia/branch/master)
[![codecov](https://codecov.io/gh/techcombd/academia/branch/master/graph/badge.svg)](https://codecov.io/gh/techcombd/academia)
[![GitHub license](https://img.shields.io/github/license/techcombd/academia.svg)](https://github.com/techcombd/academia/blob/master/LICENSE)
[![GitHub issues](https://img.shields.io/github/issues/techcombd/academia.svg)](https://github.com/techcombd/academia/issues)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)

School Management System

## Building from source

Before building from source make sure you have [NET Core SDK](https://www.microsoft.com/net/download) and [Node.js](https://nodejs.org/) installed on your system.

To run a complete build on command line only, install [Node.js](https://nodejs.org/) and execute `build.cmd` or `build.sh` without arguments.

## Code Coverage Report

You can generate `Code Coverage Report` in `HTML` format by running from `Windows Powershell`-

```
.\build.ps1 -Target CodeCoverage
```

or from `Windows` `cmd` -

```
build.cmd -Target CodeCoverage
```

and from `Linux` or `MacOSX` -

```
./build.sh -Target CodeCoverage
```

The `Coverage` report will be generated inside `reports` directory of your project `root`