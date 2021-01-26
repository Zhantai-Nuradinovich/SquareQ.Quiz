"..\..\oqtane.framework\oqtane.package\nuget.exe" pack SquareQ.Quiz.nuspec 
XCOPY "*.nupkg" "..\..\oqtane.framework\Oqtane.Server\wwwroot\Modules\" /Y
