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

Task("Build")
.IsDependentOn("Clean")
.IsDependentOn("Restore")
.Does(() => {
    DotNetCoreBuild(solution,
        new DotNetCoreBuildSettings
        {
            NoRestore = true
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
                NoBuild = true
            }
        );
    }
});

Task("Default")
.IsDependentOn("Test");


RunTarget(target);