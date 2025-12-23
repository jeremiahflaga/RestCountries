# Rest Countries Web API

**How to run:**

1. Open in Visual Studio 2022, then set `RestCountries.WebApi` as default project.

2. Update connection string in `appsettings.json` of the `RestCountries.WebApi` project.

3. Run DB Migrations

   Open "Package Manager Console" in Visual Studio. Then select `RestCountries.Data` as "Default Project".

   Then run this command

   ```
   Update-Database
   ```

4. Click on the Run button in Visual Studio

5. Open Web API UI on browser: https://localhost:7044/scalar

6. Use the UI to call `POST /api/Import` endpoint.

7. Use the UI to call `GET /api/Countries` endpoint.