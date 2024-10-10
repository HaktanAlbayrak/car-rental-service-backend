using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers.GuidHelper;

public class GuidUtilities
{
    public static Guid GenerateNewGuid()
    {
        return Guid.NewGuid();
    }

    public static bool IsValidGuid(string guidString)
    {
        return Guid.TryParse(guidString, out _);
    }

    public static string GuidToString(Guid guid)
    {
        return guid.ToString();
    }

    public static Guid StringToGuid(string guidString)
    {
        if (IsValidGuid(guidString))
        {
            return Guid.Parse(guidString);
        }
        else
        {
            throw new ArgumentException("Invalid GUID format.");
        }
    }
}
