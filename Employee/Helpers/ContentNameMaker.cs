using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Helpers;

class ContentNameMaker
{
    public static string GetImageName(string filepath)
    {
        FileInfo fileInfo = new FileInfo(filepath);
        return "IMG_" + Guid.NewGuid().ToString() + fileInfo.Extension;
    }
}
