using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Linq;

namespace IntraUmbracoProject.Helpers
{
    public class AssetHelper
    {
        private readonly IWebHostEnvironment _environment;

        public AssetHelper (IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public string GetAssetPath(string folder, string pattern)
        {
            var assetDirectory = Path.Combine(_environment.WebRootPath, folder);
            if (!Directory.Exists(assetDirectory))
            {
                return null;
            }

            var assetFile = Directory.GetFiles(assetDirectory, pattern).FirstOrDefault();
            if(assetFile == null) {
                return null;
            }

            return "/" + folder + "/" + Path.GetFileName(assetFile);
        }
    }
}
