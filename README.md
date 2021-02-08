# DigitalClock
一个简单的WPF小程序(显示当前的时间)，该程序改自博客园sssion的练手WPF（一）--模拟时钟与数字时钟的制作，仅提取了当中制作数字时钟的部分。
## 程序的改动如下
1. 更改了时钟触发方式，代码如下：
``` C#
System.Timers.Timer timer = new System.Timers.Timer(1000); //设置计时器  
timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed); // 添加事件
timer.Enabled = true;  
private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)  // 事件定义
        {
            this.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>
            {
                CurrTime = DateTime.Now;

                // 更新数字时钟数字
                DrawDigitTime();
            }));  
        }
```

2. 按照个人审美重新定义了窗口，更改了背景颜色，使窗口背景透明。
