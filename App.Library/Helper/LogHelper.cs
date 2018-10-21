﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Library.Helper
{
    /// <summary>
    /// 日志帮助类
    /// </summary>
    public static class LogHelper
    {
        /// <summary>
        /// 写入日志到本地TXT文件
        /// 注：日志文件名为"A_log.txt",目录为根目录
        /// </summary>
        /// <param name="log">日志内容</param>
        public static void WriteLog_LocalTxt(string log)
        {
            Task.Factory.StartNew(() =>
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "A_log.txt");
                string logContent = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}:{log}\r\n";
                File.AppendAllText(filePath, logContent);
            });
        }
    }
}
