# park-eco-server [![Build status](https://ci.appveyor.com/api/projects/status/pv0l6qgqskxsuepy/branch/master?svg=true)](https://ci.appveyor.com/project/nguyenlamlll/park-eco-server/branch/master) [![codecov](https://codecov.io/gh/park-eco/park-eco-server/branch/master/graph/badge.svg)](https://codecov.io/gh/park-eco/park-eco-server)

Core API server for ParkEco system.


# Build from source

Clone this repository.

```
git clone 
```

Navigate to ParkEco.CoreAPI\ParkEco.CoreAPI directory.

```
cd ParkEco.CoreAPI\ParkEco.CoreAPI
```

Restore the project.

```
dotnet restore
```

Change the server name of ConnectionStrings inside `appsettings.json` file. Then, update the database.

```
dotnet ef database update
```

Now you can run the backend server!

```
dotnet run
```