using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectCrawler
{
    public partial class ExampleDownload : System.Web.UI.Page
    {
        public void downloadimage(string url,string VirtuleFolder)
        {
            try
            {
                string LocalFolder = Server.MapPath(VirtuleFolder);
                string ext = string.Empty;
                ext = url.Substring(url.Length - 3, 3);
                string filename = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + ext;
                WebClient my = new WebClient();
                byte[] mybyte;
                mybyte = my.DownloadData(url);
                MemoryStream ms = new MemoryStream(mybyte);
                System.Drawing.Image img;
                img = System.Drawing.Image.FromStream(ms);
                switch(ext.ToLower())
                {
                    case "gif":
                        img.Save(Path.Combine(LocalFolder, filename), ImageFormat.Gif);
                        break;
                    case "png":
                        img.Save(Path.Combine(LocalFolder, filename), ImageFormat.Png);
                        break;
                    case "jpeg":
                    case "jpg":
                        img.Save(Path.Combine(LocalFolder, filename), ImageFormat.Jpeg);
                        break;
                }
            }
            catch(Exception ex)
            {
                Response.Write("----------下载图片发生错误----------</br>");
                Response.Write("错误内容：</br>" + ex.Message);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}