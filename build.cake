#addin "Cake.Npm"

///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var solution = File("./Academia.sln");


///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////

Setup(ctx =>
{
   // Executed BEFORE the first task.
   Information("Running tasks...");
});

Teardown(ctx =>
{
   // Executed AFTER the last task.
   Information("Finished running tasks.");
});

///////////////////////////////////////////////////////////////////////////////
// TASKS
///////////////////////////////////////////////////////////////////////////////

Task("Clean")
.Does(() => {
    DotNetCoreClean(solution,
        new DotNetCoreCleanSettings
        {
            Configuration = configuration
        }
    );
});

Task("Restore")
.Does(() => {
    DotNetCoreRestore();
});

Task("NgTestCoverage")
.Does(() => {
    //Build Angular frontend project using Angular cli
    var runSettings = new NpmRunScriptSettings {
      ScriptName = "ng",
      WorkingDirectory = "src/Academia.Web/ClientApp",
      LogLevel = NpmLogLevel.Warn
    };
    runSettings.Arguments.Add("test");
    runSettings.Arguments.Add("--single-run");
    runSettings.Arguments.Add("--cc");

    NpmRunScript(runSettings);

    CreateDirectory("./tests/Angular");
    CopyFile("./src/Academia.Web/ClientApp/coverage/coverage.xml", "./tests/Angular/coverage.xml");
});

Task("Build")
.IsDependentOn("Clean")
.IsDependentOn("Restore")
.Does(() => {
    DotNetCoreBuild(solution,
        new DotNetCoreBuildSettings
        {
            NoRestore = true,
            ArgumentCustomization = arg => arg.AppendSwitch("/p:DebugType","=","Full")
        }
    );
});

Task("Test")
.IsDependentOn("Build")
.IsDependentOn("NgTestCoverage")
.Does(() => {
    var projectFiles = GetFiles("./tests/**/*.csproj");
    foreach(var file in projectFiles)
    {
        DotNetCoreTest(file.FullPath,
            new DotNetCoreTestSettings
            {
                NoBuild = true,
                ArgumentCustomization = args=>args.Append("/p:CollectCoverage=true /p:CoverletOutputFormat=opencover")
            }
        );
    }
});

#tool "nuget:?package=OpenCover"
Task("OpenCover")
.IsDependentOn("Build")
.IsDependentOn("NgTestCoverage")
.Does(() => {
    var projectFiles = GetFiles("./tests/**/*.csproj");
    foreach(var file in projectFiles)
    {
        OpenCover(tool => {
            tool.DotNetCoreTest(file.FullPath,
                new DotNetCoreTestSettings
                {
                    NoBuild = true}
            );
        },
        new FilePath("./" + file.GetDirectory() + "/coverage.xml"),
        new OpenCoverSettings{
            OldStyle = true,
            Register = "user"
        }
        .WithFilter("+[Academia*]*"));

    }
});

#tool "nuget:?package=ReportGenerator"
Task("CodeCoverage")
.Does(() => {
    if (IsRunningOnUnix())
    {
        Information("Linux! Running Coverlet for code coverage");
        RunTarget("Test");
    } else {
        Information("Windows! Running OpenCover");
        RunTarget("OpenCover");
    }

    ReportGenerator("./tests/*/coverage.xml", "reports", new ReportGeneratorSettings(){
        HistoryDirectory = "reports/history"
    });
});

Task("Default")
.IsDependentOn("Test");


RunTarget(target);