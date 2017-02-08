dotnet pack src/Ornament.Identity -c:release -o:./
dotnet pack src/Ornament.Identity.Dao.NhImple -c:release -o:./

copy *.nupkg c:\inetpub\wwwroot\packages /y
del *.nupkg