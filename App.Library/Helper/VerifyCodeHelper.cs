﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


//验证码分为3大类
//1、随机字母或者数字，纯文本验证码
//这种非常容易破解 ，市场上有大量的现成接口或者工具，背景越复杂难度越高。
//2、题库验证码
//要破解这种验证码，需要人工收集题库才可以破解，可以免疫不是专门针对你一个网站的黑客，所以我偏爱这种验证码
//?1+1=??本论坛的域名是??今天是星期几??复杂点的数学运算
//但是他到底是不是就不能破解了呢？
//缺点：数量有限。破解方式也很简单，多刷新几次，建立题库和对应的答案，用正则从网页里抓取问题，
//寻找匹配的答案后破解。也有些用随机生成的数学公式，比如 随机数[+-*/]随机运算符 随机数 =?，小学生水平的程序员也可以搞定……
//3、干扰型题库验证码
//  将文字显示进行处理起到干扰效果，就算你有正确题库也不能轻易破解
//  今天正好身体不舒服请了天假整理了这么一个可以实现上面三种验证码的
//实现步骤
//编写Action 名为： ValidateImg

//public void ValidateImg()
//{
//    VerifyCodeSugar v = new VerifyCodeSugar();
//    //是否随机字体颜色
//    v.SetIsRandomColor = true;
//    //随机码的旋转角度
//    v.SetRandomAngle = 4;
//    //文字大小
//    v.SetFontSize = 15;
//    //背景色
//    //v.SetBackgroundColor
//    //前景噪点数量
//    //v.SetForeNoisePointCount = 3;
//    //v.SetFontColor =Color.Red;
//    //...还有更多设置不介绍了
//    var questionList = new Dictionary<string, string>()
//           {
//                {"1+1=？","2"},
//               {"喜羊羊主角叫什么名字？","喜羊羊" },
//               {"【我爱你】中间的那个字？","爱" },
//           };
//    var questionItem = v.GetQuestion(questionList);//不赋值为随机验证码 例如： 1*2=? 这种
//                                                   //指定验证文本
//                                                   //v.SetVerifyCodeText
//    v.SetVerifyCodeText = questionItem.Key;
//    Session["VerifyCode"] = questionItem.Value;
//    //输出图片
//    v.OutputImage(System.Web.HttpContext.Current.Response);
//}
//2、给IMG设置URL地址,js给src更换url添加随机参数 达到刷新验证码的功能
// <img src="/File/ValidateImg" />

namespace App.Library.Helper
{
    /// <summary>
    /// 
    /// </summary>
   public class VerifyCodeHelper
    {
        private Random objRandom = new Random();

        #region setting

        /// <summary>
        /// //验证码长度
        /// </summary>
        public int SetLength = 4;
        /// <summary>
        /// 验证码字符串
        /// </summary>
        public string SetVerifyCodeText { get; set; }
        /// <summary>
        /// 是否加入小写字母
        /// </summary>
        public bool SetAddLowerLetter = false;
        /// <summary>
        /// 是否加入大写字母
        /// </summary>
        public bool SetAddUpperLetter = false;
        /// <summary>
        /// 字体大小
        /// </summary>
        public int SetFontSize = 18;
        /// <summary>
        ///  //字体颜色
        /// </summary>
        public Color SetFontColor = Color.Blue;
        /// <summary>
        /// 字体类型
        /// </summary>
        public string SetFontFamily = "Verdana";
        /// <summary>
        /// 背景色
        /// </summary>
        public Color SetBackgroundColor = Color.AliceBlue;
        /// <summary>
        /// 前景噪点数量
        /// </summary>
        public int SetForeNoisePointCount = 2;
        /// <summary>
        /// 随机码的旋转角度
        /// </summary>
        public int SetRandomAngle = 40;

        /// <summary>
        /// 是否随机字体颜色
        /// </summary>
        public bool SetIsRandomColor = false;
        /// <summary>
        /// 图片宽度
        /// </summary>
        private int SetWith
        {
            get
            {
                return this.SetVerifyCodeText.Length * SetFontSize;
            }
        }
        /// <summary>
        /// 图片高度
        /// </summary>
        private int SetHeight
        {
            get
            {
                return Convert.ToInt32((60.0 / 100) * SetFontSize + SetFontSize);
            }
        }
        #endregion

        #region Constructor Method
        public VerifyCodeHelper()
        {
            this.GetVerifyCodeText();
        }
        #endregion

        #region Private Method
        /// <summary>
        /// 得到验证码字符串
        /// </summary>
        private void GetVerifyCodeText()
        {

            //没有外部输入验证码时随机生成
            if (String.IsNullOrEmpty(this.SetVerifyCodeText))
            {
                StringBuilder objStringBuilder = new StringBuilder();

                //加入数字1-9
                for (int i = 1; i <= 9; i++)
                {
                    objStringBuilder.Append(i.ToString());
                }

                //加入大写字母A-Z，不包括O
                if (this.SetAddUpperLetter)
                {
                    char temp = ' ';

                    for (int i = 0; i < 26; i++)
                    {
                        temp = Convert.ToChar(i + 65);

                        //如果生成的字母不是'O'
                        if (!temp.Equals('O'))
                        {
                            objStringBuilder.Append(temp);
                        }
                    }
                }

                //加入小写字母a-z，不包括o
                if (this.SetAddLowerLetter)
                {
                    char temp = ' ';

                    for (int i = 0; i < 26; i++)
                    {
                        temp = Convert.ToChar(i + 97);

                        //如果生成的字母不是'o'
                        if (!temp.Equals('o'))
                        {
                            objStringBuilder.Append(temp);
                        }
                    }
                }

                //生成验证码字符串
                {
                    int index = 0;

                    for (int i = 0; i < SetLength; i++)
                    {
                        index = objRandom.Next(0, objStringBuilder.Length);

                        this.SetVerifyCodeText += objStringBuilder[index];

                        objStringBuilder.Remove(index, 1);
                    }
                }
            }
        }

        /// <summary>
        /// 得到验证码图片
        /// </summary>
        private Bitmap GetVerifyCodeImage()
        {
            Bitmap result = null;

            //创建绘图
            result = new Bitmap(SetWith, SetHeight);

            using (Graphics objGraphics = Graphics.FromImage(result))
            {
                objGraphics.SmoothingMode = SmoothingMode.HighQuality;

                //清除整个绘图面并以指定背景色填充
                objGraphics.Clear(this.SetBackgroundColor);

                //创建画笔
                using (SolidBrush objSolidBrush = new SolidBrush(this.SetFontColor))
                {
                    this.AddForeNoisePoint(result);

                    this.AddBackgroundNoisePoint(result, objGraphics);

                    //文字居中
                    StringFormat objStringFormat = new StringFormat(StringFormatFlags.NoClip);

                    objStringFormat.Alignment = StringAlignment.Center;
                    objStringFormat.LineAlignment = StringAlignment.Center;

                    //字体样式
                    Font objFont = new Font(this.SetFontFamily,
                     objRandom.Next(this.SetFontSize - 3, this.SetFontSize), FontStyle.Regular);

                    //验证码旋转，防止机器识别
                    char[] chars = this.SetVerifyCodeText.ToCharArray();

                    for (int i = 0; i < chars.Length; i++)
                    {
                        //转动的度数
                        float angle = objRandom.Next(-this.SetRandomAngle, this.SetRandomAngle);

                        objGraphics.TranslateTransform(12, 12);
                        objGraphics.RotateTransform(angle);
                        objGraphics.DrawString(chars[i].ToString(),
                        objFont, objSolidBrush, -2, 2, objStringFormat);
                        objGraphics.RotateTransform(-angle);
                        objGraphics.TranslateTransform(2, -12);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 添加前景噪点
        /// </summary>
        /// <param name="objBitmap"></param>
        private void AddForeNoisePoint(Bitmap objBitmap)
        {
            for (int i = 0; i < objBitmap.Width * this.SetForeNoisePointCount; i++)
            {
                objBitmap.SetPixel(objRandom.Next(objBitmap.Width),
                objRandom.Next(objBitmap.Height), this.SetFontColor);
            }
        }

        /// <summary>
        /// 添加背景噪点
        /// </summary>
        /// <param name="objBitmap"></param>
        /// <param name="objGraphics"></param>
        private void AddBackgroundNoisePoint(Bitmap objBitmap, Graphics objGraphics)
        {
            using (Pen objPen = new Pen(Color.Azure, 0))
            {
                for (int i = 0; i < objBitmap.Width * 2; i++)
                {
                    objGraphics.DrawRectangle(objPen, objRandom.Next(objBitmap.Width),
                     objRandom.Next(objBitmap.Height), 1, 1);
                }
            }

        }

        /// <summary>
        /// 获取随机颜色
        /// </summary>
        /// <returns></returns>
        private Color GetRandomColor()
        {
            Random RandomNum_First = new Random((int)DateTime.Now.Ticks);
            // 对于C#的随机数，没什么好说的
            System.Threading.Thread.Sleep(RandomNum_First.Next(50));
            Random RandomNum_Sencond = new Random((int)DateTime.Now.Ticks);
            // 为了在白色背景上显示，尽量生成深色
            int int_Red = RandomNum_First.Next(256);
            int int_Green = RandomNum_Sencond.Next(256);
            int int_Blue = (int_Red + int_Green > 400) ? 0 : 400 - int_Red - int_Green;
            int_Blue = (int_Blue > 255) ? 255 : int_Blue;
            return Color.FromArgb(int_Red, int_Green, int_Blue);
        }
        #endregion

        #region Public Method
        /// <summary>
        /// 输出验证码图片
        /// </summary>
        /// <param name="objHttpResponse">Http响应实例</param>
        /// <returns>输出是否成功</returns>
        public bool OutputImage(HttpResponse objHttpResponse)
        {
            bool result = false;
            if (this.SetIsRandomColor)
            {
                this.SetFontColor = GetRandomColor(); ;
            }

            using (Bitmap objBitmap = this.GetVerifyCodeImage())
            {
                if (objBitmap != null)
                {
                    using (MemoryStream objMS = new MemoryStream())
                    {
                        objBitmap.Save(objMS, ImageFormat.Jpeg);

                        HttpContext.Current.Response.ClearContent();
                        HttpContext.Current.Response.ContentType = "image/Jpeg";
                        HttpContext.Current.Response.BinaryWrite(objMS.ToArray());
                        HttpContext.Current.Response.Flush();
                        HttpContext.Current.Response.End();

                        result = true;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 获取问题
        /// </summary>
        /// <param name="questionList">默认数字加减验证</param>
        /// <returns></returns>
        public KeyValuePair<string, string> GetQuestion(Dictionary<string, string> questionList = null)
        {
            if (questionList == null)
            {
                questionList = new Dictionary<string, string>();
                var operArray = new string[] { "+", "*", "num" };
                var left = objRandom.Next(0, 10);
                var right = objRandom.Next(0, 10);
                var oper = operArray[objRandom.Next(0, operArray.Length)];
                if (oper == "+")
                {
                    string key = string.Format("{0}+{1}=?", left, right);
                    string val = (left + right).ToString();
                    questionList.Add(key, val);
                }
                else if (oper == "*")
                {
                    string key = string.Format("{0}×{1}=?", left, right);
                    string val = (left * right).ToString();
                    questionList.Add(key, val);
                }
                else
                {
                    var num = objRandom.Next(1000, 9999); ;
                    questionList.Add(num.ToString(), num.ToString());
                }
            }
            return questionList.ToList()[objRandom.Next(0, questionList.Count)];
        }
        #endregion
    }
}
