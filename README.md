# CarparkWhere: Where got parking space?

**CarparkWhere** is a web application written using the .NET Core and ReactJS frameworks. It allows registered users to access the API and retrieve information about the available parking spaces in Singapore.

It features a frontend for easy browsing of the carpark information and comes with a full-fledged REST API to the underlying data using JWT authentication.

## Deploying to production

To deploy this web application to production, you will need to have ASP.NET Core 3.1, MySQL/MariaDB, Node.js as well as NPM.

### Create the backend database

On the MySQL server, create a new database named `carparks` and adjust `ConnectionStrings` in the `appsettings.json` file in the repository root with the appropriate credentials. The original settings are as follows:

```
"ConnectionStrings": {
  "CarparkWhere": "server=localhost;user=root;password=password;database=carpark;persistsecurityinfo=True"
},
```

Run the database migration to populate the tables in the new database using the following command:

```
dotnet ef database update
```

The `carparks` database should now be populated with an empty `Users` table.

### Compile the frontend

Navigate to the `ClientApp` folder located in the root of this repository and run the following command:

```
npm run build
```

This command compiles the frontend to be ready for production use.

### Start the production server

Navigate back to the root of this repository and run the following command:

```
dotnet run
```

This will start the production server running on `https://localhost:5001` by default. This can be changed by editing the `launchSettings.json` file in the `Properties` folder.

## Acknowledgements

The data used by this project is retrieved directly from the [Carpark Availability API on Data.gov.sg](https://data.gov.sg/dataset/carpark-availability), which is available under the [Singapore Open Data License version 1.0](https://data.gov.sg/open-data-licence).
