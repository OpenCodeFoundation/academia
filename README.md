# Academia

[![Build Status](https://travis-ci.org/OpenCodeFoundation/academia.svg?branch=master)](https://travis-ci.org/OpenCodeFoundation/academia)
[![Build status](https://ci.appveyor.com/api/projects/status/rq56t7j772m25m1t/branch/master?svg=true)](https://ci.appveyor.com/project/ratanparai/academia/branch/master)
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/858f2c6c20694f52807e530ac235d9ae)](https://www.codacy.com/app/ratanparai/academia?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=techcombd/academia&amp;utm_campaign=Badge_Grade) 
[![codecov](https://codecov.io/gh/OpenCodeFoundation/academia/branch/master/graph/badge.svg)](https://codecov.io/gh/OpenCodeFoundation/academia)
[![GitHub license](https://img.shields.io/github/license/OpenCodeFoundation/academia.svg)](https://github.com/OpenCodeFoundation/academia/blob/master/LICENSE)
[![GitHub issues](https://img.shields.io/github/issues/OpenCodeFoundation/academia.svg)](https://github.com/OpenCodeFoundation/academia/issues)
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
