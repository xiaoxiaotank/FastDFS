using FastDFS.Client.Common;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FastDFS.Client._4._5
{
    public class MyFastDFSClient : FastDFSClient
    {
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="node">存储节点</param>
        /// <param name="filePath">文件路径</param>
        /// <return>远程文件Url</return>
        public static string UploadFile(StorageNode node, string filePath)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));
            if (File.Exists(filePath))
            {
                var fileBytes = File.ReadAllBytes(filePath);
                var fileUrl = UploadFile(node, fileBytes, Path.GetExtension(filePath).TrimStart('.'));
                return fileUrl;
            }
            else
            {
                throw new ArgumentException("文件不存在！");
            }
        }
    }
}
