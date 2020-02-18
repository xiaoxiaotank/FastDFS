using FastDFS.Client.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FastDFS.Client._4._5
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 初始化
            // 所有 tracker 服务器的ip:port
            var trackerIPs = new List<IPEndPoint>()
            {
                new IPEndPoint(IPAddress.Parse("192.168.181.128"), 22122)
            };
            if (!ConnectionManager.Initialize(trackerIPs))
            {
                throw new Exception("fastDFS连接初始化失败！");
            }

            var node = FastDFSClient.GetStorageNode("group1");
            #endregion

            #region 小文件上传
            //var uploadingfilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\1.jpg");
            //var uploadedfileUrl1 = MyFastDFSClient.UploadFile(node, uploadingfilePath);
            //Console.WriteLine($"小文件已上传，Url 为：{uploadedfileUrl1}");


            //var slaveFileName = FastDFSClient.UploadSlaveFile("group1", content, fileName, "-part1", "jpg");
            #endregion

            #region 大文件上传



            #endregion

            #region 文件查询
            var queryFileUrl = "M00/00/00/wKi1gF5LsuiAdeRbAAYD2YvCnl8857.jpg";
            try
            {
                var fileInfo = FastDFSClient.GetFileInfo(node, queryFileUrl);
                Console.WriteLine($"文件大小：{fileInfo.FileSize}");
                Console.WriteLine($"文件创建时间：{fileInfo.CreateTime.AddHours(8):yyyy-MM-dd HH:mm:ss}");
            }
            catch (FDFSException ex)
            {
                Console.WriteLine($"文件不存在：{queryFileUrl}");
                Console.WriteLine($"Message：{ex.Message}");
            }           
           
            #endregion

            #region 小文件下载        
            var downloadingfileUrl = "M00/00/00//wKi1gF5LsuiAdeRbAAYD2YvCnl8857.jpg";
            var localPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $@"..\..\download\1{Path.GetExtension(downloadingfileUrl)}");

            // 出现图片内容丢失
            //var downloadingfileBytes = FastDFSClient.DownloadFile(node, downloadingfileUrl);
            //File.WriteAllBytes(localPath, downloadingfileBytes);

            //var downloadingfileUrl = $"http://192.168.181.128:8888/group1/{downloadingfileUrl}";
            //using (WebClient web = new WebClient())
            //{
            //    Directory.CreateDirectory(Path.GetDirectoryName(localPath));
            //    web.DownloadFile(downloadingfileUrl, localPath);

            //    //Console.WriteLine("文件已下载完毕，稍后将自动打开。。。");
            //    //Process.Start("explore.exe", localPath);
            //}

            #endregion

            #region 大文件下载

            #endregion

            #region 文件删除
            var removingfileName = "M00/00/00/wKi1gF5LsuiAdeRbAAYD2YvCnl8857.jpg";
            try
            {
                FastDFSClient.RemoveFile(node.GroupName, removingfileName);
                Console.WriteLine($"文件已删除：{removingfileName}");
            }
            catch(FDFSException ex)
            {
                Console.WriteLine($"文件不存在：{queryFileUrl}");
                Console.WriteLine($"Message：{ex.Message}");
            }
            #endregion

            Console.WriteLine("ending........................");
            Console.ReadKey();
        }


    }
}
