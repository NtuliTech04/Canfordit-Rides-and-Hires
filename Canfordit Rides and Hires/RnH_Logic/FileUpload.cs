using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Canfordit_Rides_and_Hires.Models;
using System.IO;

namespace Canfordit_Rides_and_Hires.RnH_Logic
{
    public class FileUpload
    {
        public byte[] ConvertToBytes(HttpPostedFileBase photo)
        {
            byte[] photoBytes = null;
            BinaryReader reader = new BinaryReader(photo.InputStream);
            photoBytes = reader.ReadBytes((int)photo.ContentLength);
            return photoBytes;
        }
    }
}