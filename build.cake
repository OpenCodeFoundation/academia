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

Task("NpmRestore")
.Does(() => {
    var settings = new NpmInstallSettings();

    settings.LogLevel = NpmLogLevel.Info;
    settings.WorkingDirectory = "src/Academia.Web/";

    NpmInstall(settings);
});

Task("Build")
.IsDependentOn("Clean")
.IsDependentOn("Restore")
.IsDependentOn("NpmRestore")
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