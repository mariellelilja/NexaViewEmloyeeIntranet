:: Run this script from project directory root by writing BuildAndServeNVIntra.bat from terminal
:: Requires 'dotnet run' set up

echo Building Vue.js application...
cd .\IntraUmbracoProject\IntraUmbracoProject\ClientApp\app
npm run build
echo Build finished.

echo Starting Umbraco project...
cd %~dp0\IntraUmbracoProject
dotnet run
echo Running the Umbraco solution...