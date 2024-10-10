using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers.FileHelper;

public interface IFileHelperService
{
    string Upload(IFormFile file, string root);
    string Update(IFormFile file, string filePath, string root);
    void Delete(string filePath);
}
