using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
namespace spicarrierguideness.Models
{
    public class FileManager
    {
        public string FolderName;
        public HttpPostedFileBase FileNmae;
        public bool SaveFile()
        {
            try
            {
                Directory.CreateDirectory("../Content/" + FolderName);
                FileNmae.SaveAs(HttpContext.Current.Server.MapPath("../Content/" + FolderName + "/" + FileNmae.FileName));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}