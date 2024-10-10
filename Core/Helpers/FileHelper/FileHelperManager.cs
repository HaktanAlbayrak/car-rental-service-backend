using Core.Helpers.GuidHelper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers.FileHelper;

public class FileHelperManager : IFileHelperService
{

    public void Delete(string filePath)
    {
        // If the file does not exist, exit the method early.
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"File at path {filePath} does not exist.");
        }

        // File exists, so delete it
        File.Delete(filePath);
    }

    public string Update(IFormFile file, string filePath, string root)
    {
        if (file == null || file.Length == 0)
            throw new Exception("Invalid file.");

        // Ensure the root directory exists
        if (!Directory.Exists(root))
            Directory.CreateDirectory(root);

        // Check if the file exists at the filePath
        if (!File.Exists(filePath))
            throw new Exception("File does not exist.");

        // Optionally delete the existing file if you want to overwrite it
        File.Delete(filePath);

        // Save the new file at the same file path
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            file.CopyTo(stream);
        }

        return filePath;  // Return the updated file path
    }

    public string Upload(IFormFile file, string root)
    {
        if (file == null || file.Length == 0)
            throw new Exception("Invalid file.");

        // Ensure the root directory exists
        if (!Directory.Exists(root))
            Directory.CreateDirectory(root);

        // Generate GUID for the file name using the GuidHelper
        string extension = Path.GetExtension(file.FileName);
        string fileName = $"{GuidUtilities.GenerateNewGuid().ToString()}{extension}";
        string filePath = Path.Combine(root, fileName);

        // Save the file
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            file.CopyTo(stream);
        }

        return filePath;  // Return the saved file path
    }
}
