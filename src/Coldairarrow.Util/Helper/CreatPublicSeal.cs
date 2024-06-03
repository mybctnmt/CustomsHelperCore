﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Util.Helper
{
    public class CreatPublicSeal
    {

        //Rectangle rect = new Rectangle(10, 10, 160, 160);//实例化Rectangle类
        private static int tem_Line = 160;//记录圆的直径
        private static int circularity_W = 5;//设置圆画笔的粗细
        //圆线条
        private static Rectangle rect = new Rectangle(circularity_W, circularity_W, tem_Line - circularity_W * 2, tem_Line - circularity_W * 2);//设置圆的绘制区域
        private static int _letterspace = -6;//字体间距
        private static Char_Direction _chardirect = Char_Direction.Center;
        private static int _degree = 90;
        //字体圆弧所在圆
        private static int space = 18;//比外面圆圈小
        private static Rectangle NewRect = new Rectangle(new Point(rect.X + space, rect.Y + space), new Size(rect.Width - 2 * space, rect.Height - 2 * space));

        /// <summary>
        /// 创建公司公共印章得到gif图片存储地址
        /// </summary>
        /// <param name="company">公司名字</param>
        /// <param name="department">部门名字</param>
        /// <returns></returns>
        public static Bitmap CreatSeal(string company)
        {
            string star_Str = "★";
            Bitmap bMap = new Bitmap(160, 160);//画图初始化
            if (!string.IsNullOrEmpty(company))
            {
                Graphics g = Graphics.FromImage(bMap);
                //Graphics g = this.panel1.CreateGraphics();//实例化Graphics类
                g.SmoothingMode = SmoothingMode.AntiAlias;//消除绘制图形的锯齿
                g.Clear(Color.Transparent);//以白色清空panel1控件的背景
                Pen myPen = new Pen(Color.Red, circularity_W);//设置画笔的颜色
                g.DrawEllipse(myPen, rect); //绘制圆

                Font star_Font = new Font("黑体", 45, FontStyle.Bold);//设置星号的字体样式
                SizeF star_Size = g.MeasureString(star_Str, star_Font);//对指定字符串进行测量
                                                                       //要指定的位置绘制星号
                PointF star_xy = new PointF(tem_Line / 2 - star_Size.Width / 2, tem_Line / 2 - star_Size.Height / 2);
                g.DrawString(star_Str, star_Font, myPen.Brush, star_xy);

                //string text_txt = "吉林省明日科技有限公司";
                string text_txt = company;
                int text_len = text_txt.Length;//获取字符串的长度
                Font text_Font = new Font("黑体", 34 - text_len, FontStyle.Regular);//定义公司名字的字体的样式
                Pen myPenbush = new Pen(Color.Transparent, circularity_W);

                float[] fCharWidth = new float[text_len];
                float fTotalWidth = ComputeStringLength(text_txt, g, fCharWidth, _letterspace, _chardirect, text_Font);
                // Compute arc's start-angle and end-angle
                double fStartAngle, fSweepAngle;
                fSweepAngle = fTotalWidth * 360 / (NewRect.Width * Math.PI);
                fStartAngle = 270 - fSweepAngle / 2;
                // Compute every character's position and angle
                //PointF[] pntChars = new PointF[text_len];
                PointF[] pntChars = new PointF[text_len];
                double[] fCharAngle = new double[text_len];
                ComputeCharPos(fCharWidth, pntChars, fCharAngle, fStartAngle);
                for (int i = 0; i < text_len; i++)
                {
                    DrawRotatedText(g, text_txt[i].ToString(), (float)(fCharAngle[i] + _degree), pntChars[i], text_Font, myPenbush);
                }
            }
            return bMap;
        }
        /// <summary>
        /// 计算字符串总长度和每个字符长度
        /// </summary>
        /// <param name="sText"></param>
        /// <param name="g"></param>
        /// <param name="fCharWidth"></param>
        /// <param name="fIntervalWidth"></param>
        /// <returns></returns>
        private static float ComputeStringLength(string sText, Graphics g, float[] fCharWidth, float fIntervalWidth, Char_Direction Direction, Font text_Font)
        {
            // Init字符串格式
            StringFormat sf = new StringFormat();
            sf.Trimming = StringTrimming.None;
            sf.FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap
            | StringFormatFlags.LineLimit;
            // 衡量整个字符串长度
            SizeF size = g.MeasureString(sText, text_Font, (int)text_Font.Style);
            RectangleF rect = new RectangleF(0f, 0f, size.Width, size.Height);
            // 测量每个字符大小
            CharacterRange[] crs = new CharacterRange[sText.Length];
            for (int i = 0; i < sText.Length; i++)
                crs[i] = new CharacterRange(i, 1);
            // 复位字符串格式
            sf.FormatFlags = StringFormatFlags.NoClip;
            sf.SetMeasurableCharacterRanges(crs);
            sf.Alignment = StringAlignment.Near;
            // 得到每一个字符大小
            Region[] regs = g.MeasureCharacterRanges(sText, text_Font, rect, sf);
            // Re-compute whole string length with space interval width
            float fTotalWidth = 0f;
            for (int i = 0; i < regs.Length; i++)
            {
                if (Direction == Char_Direction.Center || Direction == Char_Direction.OutSide)
                    fCharWidth[i] = regs[i].GetBounds(g).Width;
                else
                    fCharWidth[i] = regs[i].GetBounds(g).Height;
                fTotalWidth += fCharWidth[i] + fIntervalWidth;
            }
            fTotalWidth -= fIntervalWidth;//Remove the last interval width
            return fTotalWidth;
        }

        /// <summary>
        /// 求出每个字符的所在的点，以及相对于中心的角度
        ///1．  通过字符长度，求出字符所跨的弧度；
        ///2．  根据字符所跨的弧度，以及字符起始位置，算出字符的中心位置所对应的角度；
        ///3．  由于相对中心的角度已知，根据三角公式很容易算出字符所在弧上的点，如下图所示；
        ///4．  根据字符长度以及间隔距离，算出下一个字符的起始角度；
        ///5．  重复1直至整个字符串结束。
        /// </summary>
        /// <param name="CharWidth"></param>
        /// <param name="recChars"></param>
        /// <param name="CharAngle"></param>
        /// <param name="StartAngle"></param>
        private static void ComputeCharPos(float[] CharWidth, PointF[] recChars, double[] CharAngle, double StartAngle)
        {
            double fSweepAngle, fCircleLength;
            //Compute the circumference
            fCircleLength = NewRect.Width * Math.PI;

            for (int i = 0; i < CharWidth.Length; i++)
            {
                //Get char sweep angle
                fSweepAngle = CharWidth[i] * 360 / fCircleLength;

                //Set point angle
                CharAngle[i] = StartAngle + fSweepAngle / 2;

                //Get char position
                if (CharAngle[i] < 270f)
                    recChars[i] = new PointF(
                    NewRect.X + NewRect.Width / 2
                    - (float)(NewRect.Width / 2 *
                    Math.Sin(Math.Abs(CharAngle[i] - 270) * Math.PI / 180)),
                    NewRect.Y + NewRect.Width / 2
                    - (float)(NewRect.Width / 2 * Math.Cos(
                    Math.Abs(CharAngle[i] - 270) * Math.PI / 180)));
                else
                    recChars[i] = new PointF(
                    NewRect.X + NewRect.Width / 2
                    + (float)(NewRect.Width / 2 *
                    Math.Sin(Math.Abs(CharAngle[i] - 270) * Math.PI / 180)),
                    NewRect.Y + NewRect.Width / 2
                    - (float)(NewRect.Width / 2 * Math.Cos(
                    Math.Abs(CharAngle[i] - 270) * Math.PI / 180)));

                //Get total sweep angle with interval space
                fSweepAngle = (CharWidth[i] + _letterspace) * 360 / fCircleLength;
                StartAngle += fSweepAngle;

            }
        }
        /// <summary>
        /// 绘制每个字符
        /// </summary>
        /// <param name="g"></param>
        /// <param name="_text"></param>
        /// <param name="_angle"></param>
        /// <param name="text_Point"></param>
        /// <param name="text_Font"></param>
        /// <param name="myPen"></param>
        private static void DrawRotatedText(Graphics g, string _text, float _angle, PointF text_Point, Font text_Font, Pen myPen)
        {
            // Init format
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            // Create graphics path
            GraphicsPath gp = new GraphicsPath(System.Drawing.Drawing2D.FillMode.Winding);
            int x = (int)text_Point.X;
            int y = (int)text_Point.Y;

            // Add string
            gp.AddString(_text, text_Font.FontFamily, (int)text_Font.Style, text_Font.Size, new Point(x, y), sf);

            // Rotate string and draw it
            Matrix m = new Matrix();
            m.RotateAt(_angle, new PointF(x, y));
            g.ScaleTransform(1, 3.0f); // This will stretch the text horizontally

            g.Transform = m;
            g.DrawPath(myPen, gp);
            g.FillPath(new SolidBrush(Color.Red), gp);
        }

        public enum Char_Direction
        {
            Center = 0,
            OutSide = 1,
            ClockWise = 2,
            AntiClockWise = 3,
        }
    }
}
