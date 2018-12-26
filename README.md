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

# Technology Stack 📚
- .NET Core 2.1
- Entity Framework

# Contributing
Please read CONTRIBUTING.md for details on our code of conduct, and the process for submitting pull requests to us.

# Authors
Lam Le, Khai Le, Linh Le, and Phat Nguyen.
See also the list of contributors who participated in this project.

# License
This project is licensed under the MIT License - see the [LICENSE.md](LICENSE) file for details

# Design Documentation
The design documentation is currently in 1 language (Vietnamese) [here](https://drive.google.com/file/d/1h9vPLV3zv5bGFUXuRGKPwWl_H1Qbw0sJ/view?usp=sharing).
