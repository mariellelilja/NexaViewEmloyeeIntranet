# Make this script executable with 'chmod +x BuildAndServeNVIntra.sh' and run with './BuildAndServeNVIntra.sh' from project root.
# Run this script from the root of the project directory.
# Requires 'dotnet run' set up

echo "Building Vue.js application..."
cd ./IntraUmbracoProject/IntraUmbracoProject/ClientApp/app
npm run build
echo "Build finished."

echo "Starting Umbraco project..."
cd $(dirname "$0")/IntraUmbracoProject
dotnet run
echo "Running the Umbraco solution..."

#start YourUmbracoProject.sln
#echo "Opening up the project in Visual Studio..."
#echo "If not auto running, click F7! :)"
