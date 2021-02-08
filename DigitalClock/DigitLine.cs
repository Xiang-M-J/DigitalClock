using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DigitalClock
{
    
        public class DigitLine
        {
            // 数字7个笔划路径数据数组
            string[] PathDatas = new string[]
            {
        "M3,0 L53,0 L38,15 L18,15 Z",                               //  -
        "M0,3 L15,18 L15,38 L0,53 Z",                               // |
        "M41,18 L56,3 L56,53 L41,38 Z",                             //    |
        "M10,48.5 L18,41 L38,41 L46,48.5 L38,56 L18,56 Z",          //   -
        "M0,44 L15,60 L15,80 L0,94 Z",                              // |
        "M41,59 L56,44 L56,94 L41,79 Z",                            //    |
        "M18,82 L38,82 L53,97 L3,97 Z",                             //  _                    
        "M0,0 L15,0 L15,15 L0,15Z M0,40 L15,40 L15,55 L0,55 Z"      // :
            };

            // 路径数组（公共）
            public Path[] Path0_9 = new Path[10];
            public Path PathColon = new Path();

            /// <summary>
            /// 根据digit设置（分配）数字路径数据
            /// </summary>
            /// <param name="digit">数字</param>
            private void SetDigit(int digit)
            {
                StringBuilder sbData = new StringBuilder();

                switch (digit)
                {
                    case 0:
                        for (int i = 0; i < 7; i++)
                        {
                            if (i == 3)
                                continue;
                            sbData.Append(PathDatas[i]);
                        }
                        break;
                    case 1:
                        for (int i = 0; i < 7; i++)
                        {
                            if (i == 0 || i == 1 || i == 3 || i == 4 || i == 6)
                            {
                                continue;
                            }
                            sbData.Append(PathDatas[i]);
                        }
                        break;

                    case 2:
                        for (int i = 0; i < 7; i++)
                        {
                            if (i == 1 || i == 5)
                            {
                                continue;
                            }
                            sbData.Append(PathDatas[i]);
                        }
                        break;
                    case 3:
                        for (int i = 0; i < 7; i++)
                        {
                            if (i == 1 || i == 4)
                            {
                                continue;
                            }
                            sbData.Append(PathDatas[i]);
                        }
                        break;
                    case 4:
                        for (int i = 0; i < 7; i++)
                        {
                            if (i == 0 || i == 4 || i == 6)
                            {
                                continue;
                            }
                            sbData.Append(PathDatas[i]);
                        }
                        break;

                    case 5:
                        for (int i = 0; i < 7; i++)
                        {
                            if (i == 2 || i == 4)
                            {
                                continue;
                            }
                            sbData.Append(PathDatas[i]);
                        }
                        break;

                    case 6:
                        for (int i = 0; i < 7; i++)
                        {
                            if (i == 2)
                            {
                                continue;
                            }
                            sbData.Append(PathDatas[i]);
                        }
                        break;

                    case 7:
                        for (int i = 0; i < 7; i++)
                        {
                            if (i == 1 || i == 3 || i == 4 || i == 6)
                            {
                                continue;
                            }
                            sbData.Append(PathDatas[i]);
                        }
                        break;

                    case 8:
                        for (int i = 0; i < 7; i++)
                        {
                            sbData.Append(PathDatas[i]);
                        }
                        break;
                    case 9:
                        for (int i = 0; i < 7; i++)
                        {
                            if (i == 4)
                            {
                                continue;
                            }
                            sbData.Append(PathDatas[i]);
                        }
                        break;

                }

                Path0_9[digit].Data = Geometry.Parse(sbData.ToString());
            }
            /// <summary>
            /// 设置冒号
            /// </summary>
            /// <param name="color"></param>
            private void SetColon(Brush color)
            {
                PathColon.Fill = color;
                PathColon.Data = Geometry.Parse(PathDatas[7]);
            }
            public DigitLine(Brush brush)
            {
                // 初始化路径数组
                for (int i = 0; i < 10; i++)
                {
                Path0_9[i] = new Path
                {
                    Fill = brush
                };

                SetDigit(i);
                }

                SetColon(brush);
            }
            public void SetDigitSkewTransform(double angleX)
            {
                SkewTransform stf = new SkewTransform(angleX, 0);

                for (int i = 0; i < 10; i++)
                {
                    Path0_9[i].RenderTransform = stf;
                }
            }

            public void SetColonSkewTransform(double angleX)
            {
                SkewTransform stf = new SkewTransform(angleX, 0);
                PathColon.RenderTransform = stf;
            }
        }
    }

