using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DigitalClock
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //DispatcherTimer timer = new DispatcherTimer();  // 计时器
        System.Timers.Timer timer = new System.Timers.Timer(1000);
        DateTime CurrTime = DateTime.Now;                   // 当前时间

        DigitLine[] digitLine = new DigitLine[6];
        DigitLine[] digitLineBack = new DigitLine[6];

        DigitLine[] digitColon = new DigitLine[2];
        DigitLine[] digitColonBack = new DigitLine[2];

        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 6; i++)
            {
                digitLine[i] = new DigitLine(new SolidColorBrush(Color.FromArgb(240, 0 ,100 ,180)));
                digitLineBack[i] = new DigitLine(new SolidColorBrush(Color.FromArgb(120, 240, 248 ,255)));
            }

            // 初始化冒号
            for (int i = 0; i < 2; i++)
            {
                digitColon[i] = new DigitLine(Brushes.Black);
                digitColonBack[i] = new DigitLine(new SolidColorBrush(Color.FromArgb(255, 95, 158, 160)));
            }
            // 画数字表背景矩形
            //DrawDigitRect(new Point(-24, 36),616, 196, Brushes.SteelBlue);
            //DrawDigitRect(new Point(-16, 44), 600, 180, Brushes.Lavender);

            // 画数字底色
            DrawDigitTimeBack(new SolidColorBrush(Color.FromArgb(120, 120, 120, 120)));

            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Enabled = true;

        }
         private void Image1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Image3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            this.Close();
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }

        }
        private void DrawDigitRect(Point pos, double width, double height, Brush color)
        {
            Rectangle rect = new Rectangle();
            rect.Width = width;
            rect.Height = height;
            rect.Fill = color;
            Canvas.SetLeft(rect, pos.X);
            Canvas.SetTop(rect, pos.Y);
            digitCanvas.Children.Add(rect);

        }
        /// <summary>
        /// 显示背景数字（底色）
        /// </summary>
        /// <param name="brush"></param>
        private void DrawDigitTimeBack(Brush brush)
        {
            // 第1、2位--小时
            Canvas.SetLeft(digitLineBack[0].Path0_9[8], 40);
            Canvas.SetTop(digitLineBack[0].Path0_9[8], 80);
            digitCanvas.Children.Add(digitLineBack[0].Path0_9[8]);

            Canvas.SetLeft(digitLineBack[1].Path0_9[8], 120);
            Canvas.SetTop(digitLineBack[1].Path0_9[8], 80);
            digitCanvas.Children.Add(digitLineBack[1].Path0_9[8]);

            // 冒号
            Canvas.SetLeft(digitColonBack[0].PathColon, 190);
            Canvas.SetTop(digitColonBack[0].PathColon, 100);
            digitCanvas.Children.Add(digitColonBack[0].PathColon);

            // 第二冒号
            Canvas.SetLeft(digitColonBack[1].PathColon, 370);
            Canvas.SetTop(digitColonBack[1].PathColon, 100);
            digitCanvas.Children.Add(digitColonBack[1].PathColon);

            // 3、4位--分钟
            Canvas.SetLeft(digitLineBack[2].Path0_9[8], 220);
            Canvas.SetTop(digitLineBack[2].Path0_9[8], 80);
            digitCanvas.Children.Add(digitLineBack[2].Path0_9[8]);

            Canvas.SetLeft(digitLineBack[3].Path0_9[8], 300);
            Canvas.SetTop(digitLineBack[3].Path0_9[8], 80);
            digitCanvas.Children.Add(digitLineBack[3].Path0_9[8]);

            // 5、6位--秒钟
            Canvas.SetLeft(digitLineBack[4].Path0_9[8], 400);
            Canvas.SetTop(digitLineBack[4].Path0_9[8], 80);
            digitCanvas.Children.Add(digitLineBack[4].Path0_9[8]);

            Canvas.SetLeft(digitLineBack[5].Path0_9[8], 480);
            Canvas.SetTop(digitLineBack[5].Path0_9[8], 80);
            digitCanvas.Children.Add(digitLineBack[5].Path0_9[8]);
        }
        /// <summary>
        /// 显示数字时间
        /// </summary>
        private void DrawDigitTime()
        {
            // 删除已在画图区的数字
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (digitCanvas.Children.Contains(digitLine[i].Path0_9[j]))
                    {
                        digitCanvas.Children.Remove(digitLine[i].Path0_9[j]);
                    }
                }
            }

            // 小时
            int hour = CurrTime.Hour;
            int hour1 = hour / 10;
            int hour2 = hour % 10;
            Canvas.SetLeft(digitLine[0].Path0_9[hour1], 40);
            Canvas.SetTop(digitLine[0].Path0_9[hour1], 80);
            digitCanvas.Children.Add(digitLine[0].Path0_9[hour1]);

            Canvas.SetLeft(digitLine[1].Path0_9[hour2], 120);
            Canvas.SetTop(digitLine[1].Path0_9[hour2], 80);
            digitCanvas.Children.Add(digitLine[1].Path0_9[hour2]);

            // 冒号闪烁
            if (CurrTime.Second % 2 == 0)
            {
                digitColon[0].PathColon.Visibility = Visibility.Visible;
                digitColon[1].PathColon.Visibility = Visibility.Visible;
            }
            else
            {
                digitColon[0].PathColon.Visibility = Visibility.Hidden;
                digitColon[1].PathColon.Visibility = Visibility.Hidden;
            }

            // 分钟
            int minute = CurrTime.Minute;
            int minu1 = minute / 10;
            int minu2 = minute % 10;
            Canvas.SetLeft(digitLine[2].Path0_9[minu1], 220);
            Canvas.SetTop(digitLine[2].Path0_9[minu1], 80);
            digitCanvas.Children.Add(digitLine[2].Path0_9[minu1]);

            Canvas.SetLeft(digitLine[3].Path0_9[minu2], 300);
            Canvas.SetTop(digitLine[3].Path0_9[minu2], 80);
            digitCanvas.Children.Add(digitLine[3].Path0_9[minu2]);

            // 秒钟
            int second = CurrTime.Second;
            int sec1 = second / 10;
            int sec2 = second % 10;
            Canvas.SetLeft(digitLine[4].Path0_9[sec1], 400);
            Canvas.SetTop(digitLine[4].Path0_9[sec1], 80);
            digitCanvas.Children.Add(digitLine[4].Path0_9[sec1]);

            Canvas.SetLeft(digitLine[5].Path0_9[sec2], 480);
            Canvas.SetTop(digitLine[5].Path0_9[sec2], 80);
            digitCanvas.Children.Add(digitLine[5].Path0_9[sec2]);
        }
        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>
            {
                CurrTime = DateTime.Now;

                // 更新数字时钟数字
                DrawDigitTime();
            }));  
        }
    }
}
