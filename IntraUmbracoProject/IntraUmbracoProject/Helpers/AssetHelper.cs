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

        public IEnumerable<string> GetAllAssetPaths(string folder)
        {
            var assetDirectory = Path.Combine(_environment.WebRootPath, folder);
            if (!Directory.Exists(assetDirectory))
            {
                yield break;
            }

            var assetFiles = Directory.GetFiles(assetDirectory, "*.*", SearchOption.AllDirectories);
            foreach (var assetFile in assetFiles)
            {
                var relativePath = assetFile.Replace(_environment.WebRootPath, "").Replace("\\", "/");
                yield return relativePath;
            }
        }

        public string GenerateHtmlTagForAsset(string assetPath)
        {
            var extension = Path.GetExtension(assetPath).ToLower();
            switch (extension)
            {
                case ".css":
                    return $"<link rel=\"stylesheet\" href=\"{assetPath}\">";
                case ".js":
                    return $"<script src=\"{assetPath}\"></script>";
                case ".png":
                case ".jpg":
                case ".jpeg":
                case ".gif":
                case ".svg":
                    return $"<img src=\"{assetPath}\" alt=\"\">";
                default:
                    return "";
            }
        }
    }
}
