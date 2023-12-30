using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerTool.FileRwHelper
{
    /// <summary>
    /// 文件读写类
    /// </summary>
    public class FileReadWrite
    {
        /// <summary>
        /// 文件的名字
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 带参数构造函数
        /// </summary>
        /// <param name="fileName"></param>
        public FileReadWrite(string fileName)
        {
            FileName = fileName;
        }

        /// <summary>
        /// 空构造函数
        /// </summary>
        public FileReadWrite()
        {

        }

        /// <summary>
        /// 读取文件内容
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string ReadFile()
        {
            StreamReader sr = new StreamReader(FileName);
            string s = sr.ReadLine();
            sr.Close();
            return s;
        }


    }
}
