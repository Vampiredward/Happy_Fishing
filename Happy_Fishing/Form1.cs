using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//Edward：其他引用
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;

namespace Happy_Fishing
{
    public partial class Form1 : Form
    {
        #region 必要引用
        [DllImport("user32.dll")]
        private static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);//导入激活指定窗口的方法
        [DllImport("user32.dll")]
        private static extern void SetCursorPos(int x, int y);//导入移动鼠标的方法
        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);//导入移动鼠标的按键方法
        //移动鼠标 
        const int MOUSEEVENTF_MOVE = 0x0001;
        //模拟鼠标左键按下 
        const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        //模拟鼠标左键抬起 
        const int MOUSEEVENTF_LEFTUP = 0x0004;
        //模拟鼠标右键按下 
        const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        //模拟鼠标右键抬起 
        const int MOUSEEVENTF_RIGHTUP = 0x0010;
        //模拟鼠标中键按下 
        const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        //模拟鼠标中键抬起 
        const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        //标示是否采用绝对坐标 
        const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        #endregion

        #region 带鼠标截屏必要引用
        private const Int32 CURSOR_SHOWING = 0x00000001;
        [DllImport("user32.dll")]
        static extern bool GetCursorInfo(out CURSORINFO pci);

        [StructLayout(LayoutKind.Sequential)]
        private struct CURSORINFO
        {
            public Int32 cbSize;
            public Int32 flags;
            public IntPtr hCursor;
            public System.Drawing.Point ptScreenPos;
        }
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out Point pt);
        #endregion

        #region 全局参数
        //string log_path = @"C:\Users\DELL\Documents\Visual Studio 2008\Projects\Happy_Fishing\Logs.txt"; 
        Bitmap base_cursor_image = (Bitmap)Image.FromFile(@"C:\Users\DELL\Documents\Visual Studio 2008\Projects\Happy_Fishing\base_cursor.jpg");
        Bitmap base_giant_float_buff_image = (Bitmap)Image.FromFile(@"C:\Users\DELL\Documents\Visual Studio 2008\Projects\Happy_Fishing\giant_float_buff.jpg");
        int fishing_cursor_checks = 0;
        int fishing_cursor_check_max = 15;
        #endregion

        public Form1()
        {
            InitializeComponent();
            this.numericUpDown1.Value = 5;
            lbl_repeats.BackColor = Color.Transparent;
            ckbx_giant_float.BackColor = Color.Transparent;
        }

        private void btn_start_fishing_Click(object sender, EventArgs e)
        {
            #region 初始化相关参数
            Point cursor_position = new Point(0,0);//用来获取move_2_fishing_cursor_position()函数的返回值传递给system_volume()函数；
            //string base_path = @"C:\Users\DELL\Documents\Visual Studio 2008\Projects\Happy_Fishing\base_image.jpg";//定义基准图片
            //string target_path = @"C:\Users\DELL\Documents\Visual Studio 2008\Projects\Happy_Fishing\target_image.jpg";//定义目标图片            
            Random rd = new Random();            
            #endregion

            #region [ 该段代码已注释 ] 激活魔兽世界窗口
            //Thread.Sleep(500);

            string pName = "Wow-64";
            Process[] temp = Process.GetProcessesByName(pName);
            //if (temp.Length > 0)//进程存在的话，则激活对应窗口
            //{
            //    IntPtr process_handler = temp[0].MainWindowHandle;
            //    SwitchToThisWindow(process_handler, true);//激活指定进程的窗口
            //}
            //else//进程不存在的话，弹窗提示魔兽世界未打开，并跳出循环
            //{
            //    MessageBox.Show("魔兽世界未打开！");
            //    //break;
            //}
            #endregion

            #region [ 该段代码已注释 ] 使用巨型鱼漂（按键3），在循环中使用判断是否存在巨型鱼漂Buff函数，存在则不使用
            //Thread.Sleep(200);

            //SendKeys.Send("3");

            //Thread.Sleep(1800);//巨型鱼漂施放时间1.5秒

            //DateTime giant_float_duration_start = DateTime.Now;
            //DateTime giant_float_duration_check = DateTime.Now;
            //int giant_float_duration;//记录巨型鱼漂时长
            #endregion

            #region [ 该段代码已注释 ] 记录开始执行的时间
            //txt_start_time_4_test.Text = DateTime.Now.ToString();
            #endregion

            #region 根据设定的重复次数执行
            for (int i = 1; i <= (int) this.numericUpDown1.Value; i++)
            {
                #region 激活魔兽世界窗口
                Thread.Sleep(500);

                //string pName = "Wow-64";
                temp = Process.GetProcessesByName(pName);
                if (temp.Length > 0)//进程存在的话，则激活对应窗口
                {
                    IntPtr process_handler = temp[0].MainWindowHandle;
                    SwitchToThisWindow(process_handler, true);//激活指定进程的窗口
                }
                else//进程不存在的话，弹窗提示魔兽世界未打开，并跳出循环
                {
                    MessageBox.Show("魔兽世界未打开！");
                    break;
                }
                #endregion                

                #region [ 该段代码已注释 ] 判断巨型鱼漂时间长度是否已经超过30分钟，即1800秒
                //giant_float_duration_check = DateTime.Now;
                //giant_float_duration = (giant_float_duration_check - giant_float_duration_start).Minutes * 60 + (giant_float_duration_check - giant_float_duration_start).Seconds;
                
                //if (giant_float_duration > 1799)
                //{
                //    //giant_float_duration = 0;//重置giant_float_duration时长
                //    giant_float_duration_start = DateTime.Now;//重置giant_float_duration_start时间

                //    #region 使用巨型鱼漂（按键3）
                //    Thread.Sleep(200);

                //    SendKeys.Send("3");

                //    Thread.Sleep(1800);//巨型鱼漂施放时间1.5秒
                //    #endregion

                //}
                #endregion

                #region 根据用户设置判断巨型鱼漂Buff是否存在，否则使用巨型鱼漂
                if (ckbx_giant_float.Checked && whether_giant_float_buff() == false)
                {
                    Thread.Sleep(200);

                    SendKeys.Send("3");

                    Thread.Sleep(1800);//巨型鱼漂施放时间1.5秒
                }
                #endregion

                #region [ 该段代码已注释 ] 使用鼠标形状对比的方法，因此不需要在放线之前截屏
                //#region 放线之前截屏，调用 capture_screen(string saving_path)函数
                //Thread.Sleep(500);

                //capture_screen(base_path);
                //#endregion
                #endregion

                #region 按键钓鱼
                Thread.Sleep(200);

                SendKeys.Send("t");
                #endregion

                #region [ 该段代码已注释 ] 使用鼠标形状对比的方法，因此不需要在放线之后截屏
                //#region 放线之后截屏，调用 capture_screen(string saving_path)函数
                //Thread.Sleep(800);

                //capture_screen(target_path);
                //#endregion
                #endregion

                #region [ 该段代码已注释 ] 使用鼠标形状对比的方法，不需要调用截屏对比函数
                //#region 对比屏幕并给出鼠标位置，调用compare_screen(string base_path, string target_path)函数
                //Thread.Sleep(500);

                //mouse_position = compare_screen(base_path, target_path);
                //#endregion
                #endregion

                #region [ 该段代码已注释 ] 使用鼠标形状对比的方法，不需要再移动鼠标，钓鱼鼠标位置函数本身已经把鼠标移动到钓鱼鼠标的位置
                //#region 在全局范围内移动鼠标至指定位置，调用SetCursorPos(int x, int y)函数
                //Thread.Sleep(1000);//给图片对比多预留一些时间

                //SetCursorPos(mouse_position.X, mouse_position.Y);
                //#endregion
                #endregion

                #region 移动到钓鱼鼠标的位置
                Thread.Sleep(2000);//放线后等鱼漂不再晃动

                cursor_position = move_2_fishing_cursor_position();
                #endregion

                #region 监控系统音量，在鱼上钩时点击左键
                system_volume(cursor_position);
                #endregion

                Thread.Sleep(rd.Next(2000,4000));//让已经完成的鱼漂消失，否则可能导致下一次截图会包含上一次已完成鱼漂的影像
            }
            #endregion

            #region [ 该段代码已注释 ] 记录结束执行的时间
            //txt_end_time_4_test.Text = DateTime.Now.ToString();
            #endregion
        }

        #region 截屏函数（已完成）——截屏对比方法中使用，鼠标形状对比中不使用
        private void capture_screen(string saving_path)
        {
            int iWidth = Screen.PrimaryScreen.Bounds.Width;//获取屏幕宽度
            int iHeight = Screen.PrimaryScreen.Bounds.Height;//获取屏幕长度

            Image img = new Bitmap(iWidth, iHeight);//按照屏幕宽高创建位图            
            Graphics gc = Graphics.FromImage(img);//从一个继承自Image类的对象中创建Graphics对象
            //Image copy_img = new Bitmap(iWidth, iHeight);

            gc.CopyFromScreen(new System.Drawing.Point(0, 0), new System.Drawing.Point(0, 0), new Size(iWidth, iHeight));//抓屏并拷贝到img里            
            img.Save(saving_path);//保存位图

            img.Dispose();
            gc.Dispose();
        }
        #endregion

        #region 截屏对比函数（已完成）——截屏对比方法中使用，鼠标形状对比中不使用
        private Point compare_screen(string base_path, string target_path)
        {
            #region 获取基准图片和目标图片
            Bitmap base_image = (Bitmap)Image.FromFile(base_path);
            Bitmap target_image = (Bitmap)Image.FromFile(target_path);
            #endregion

            int image_width = base_image.Width;
            int image_height = base_image.Height;
            int compare_step_length = 10;//定义图片对比的步长
            int pixel_delta = 0;//初始化像素差值
            Point cursor_position = new Point();//初始化返回值的点
            cursor_position.X = 700;//初始化返回值的点坐标X，如果未找到鱼漂位置就返回（700，175），（0，0）的话会双击关闭窗口
            cursor_position.Y = 175;//初始化返回值的点坐标Y，如果未找到鱼漂位置就返回（700，175），（0，0）的话会双击关闭窗口
            bool whether_found_the_float = false;//初始化是否已经找到鱼漂位置的布尔值

            #region [ 重要 ]核心对比代码
            for (int i = 0; i * compare_step_length <= 350; i++)//参考目前17张图片对比测试范围是BS（71）12 ~ CO（93）19，设定实测范围 i 区间为（60，95）
            {
                for (int j = 0; j * compare_step_length <= 200; j++)//同上，设定实测范围 y 区间为（10，30）
                {
                    //i的变化范围取决于i * compare_step_length有没有达到350，即从600到950，这样就不必再针对步长重新设置 i；
                    //j的变化范围取决于j * compare_step_length有没有达到200，即从122到322，这样就不必再针对步长重新设置 j；

                    pixel_delta = base_image.GetPixel(i * compare_step_length + 600, j * compare_step_length + 122).R - target_image.GetPixel(i * compare_step_length + 600, j * compare_step_length + 122).R;//22为标题栏高度；
                    //cursor_position.X = i * compare_step_length + 600，即从横向600的位置开始计算，这样步长就有意义；
                    //cursor_position.Y = j * compare_step_length + 122，即从纵向122的位置开始计算，这样步长就有意义；

                    if (Math.Abs(pixel_delta) >= 30)
                    {
                        whether_found_the_float = true;
                        cursor_position.X = i * compare_step_length + 600;
                        cursor_position.Y = j * compare_step_length + 122;
                        break;
                    }                   
                }

                if (whether_found_the_float)
                    break;
            }
            #endregion

            base_image.Dispose();//释放图片非常重要，否则第二次截屏时会报GDI+ 中发生一般性错误
            target_image.Dispose();//释放图片非常重要，否则第二次截屏时会报GDI+ 中发生一般性错误

            return cursor_position;//返回获取的鱼漂位置坐标
        }
        #endregion        

        #region 监控声音函数（已完成）
        private void system_volume(Point cursor_position)
        {
            int time_gap = 0;

            //string volume_capture_path = @"C:\Users\DELL\Documents\Visual Studio 2008\Projects\Happy_Fishing\volume_image.jpg";//调用截屏函数时使用，当前不再调用；
            //int iWidth = Screen.PrimaryScreen.Bounds.Width;//获取屏幕宽度 @2018/3/21：只取目标1个点，可行，减少建图内存需求
            //int iHeight = Screen.PrimaryScreen.Bounds.Height;//获取屏幕长度 @2018/3/21：只取目标1个点，可行，减少建图内存需求
            int iWidth = 1;
            int iHeight = 1;

            if (cursor_position.X != 88 && cursor_position.Y != 88)//如果 cursor_position = (88, 88)，则说明没找到鼠标，就不用再监控声音；
            {             
                #region 激活系统音量窗口
                Thread.Sleep(500);

                string pName = "SndVol";
                Process[] temp = Process.GetProcessesByName(pName);

                if (temp.Length > 0)
                {
                    IntPtr process_handler = temp[0].MainWindowHandle;//
                    SwitchToThisWindow(process_handler, true);//激活指定进程的窗口
                }
                else
                {
                    Process.Start("SndVol.exe");
                }
                #endregion

                #region 实时覆盖保存音量截屏，需要保证音量设置在50的位置
                for (; true; )
                {
                    Image img = new Bitmap(iWidth, iHeight);//按照屏幕宽高创建位图 @2018/3/21：只取目标1个点，可行，减少建图内存需求
                    Graphics gc = Graphics.FromImage(img);//从一个继承自Image类的对象中创建Graphics对象
                    //gc.CopyFromScreen(new System.Drawing.Point(0, 0), new System.Drawing.Point(0, 0), new Size(iWidth, iHeight));//@2018/3/21：只取目标1个点，可行，减少建图内存需求
                    gc.CopyFromScreen(new System.Drawing.Point(1394, 745), new System.Drawing.Point(0, 0), new Size(iWidth, iHeight));

                    Thread.Sleep(50);
                    time_gap += 50;//用int型代替stopwatch()函数试试，默认下方截图加分析时间为0；

                    #region 优先监控是否满足条件1，即有鱼上钩
                    Bitmap volume_image = (Bitmap)img;
                    //if (volume_image.GetPixel(1394, 745).R == 51)//满足条件1，即有鱼上钩，则跳出循环
                    if (volume_image.GetPixel(0, 0).R == 51)
                    {
                        volume_image.Dispose();//在break之前，释放图片非常重要，否则第二次截屏时会报GDI+ 中发生一般性错误
                        gc.Dispose(); 
                        img.Dispose();

                        Thread.Sleep(750);//在鱼上钩后先等鱼漂不再晃动
                        time_gap += 750;

                        #region 点击鼠标左键钓起上钩的鱼
                        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                        Thread.Sleep(500);
                        time_gap += 500;
                        #endregion

                        #region 将鼠标位置向左上角移动（10，10），以防上一次鼠标点击时没有自动拾取物品
                        SetCursorPos(cursor_position.X - 10, cursor_position.Y - 10);
                        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                        #endregion

                        break;
                    }
                    #endregion

                    #region 其次监控是否满足条件2，即计时超过22s
                    if (time_gap >= 20000)//满足条件2，即计时超过22s，则跳出循环
                    {
                        volume_image.Dispose();
                        gc.Dispose();
                        img.Dispose();
                        break;
                    }
                    #endregion

                    volume_image.Dispose();
                    gc.Dispose();
                    img.Dispose();
                }
                #endregion
            }
        }
        #endregion

        #region 截取鼠标样式重构函数（void）（已完成）
        private void capture_cursor_type()
        {
            CURSORINFO pci;
            pci.cbSize = Marshal.SizeOf(typeof(CURSORINFO));
            GetCursorInfo(out pci);
            System.Windows.Forms.Cursor cur = new System.Windows.Forms.Cursor(pci.hCursor);
            Image img = new Bitmap(cur.Size.Width, cur.Size.Height);
            Graphics gc = Graphics.FromImage(img);
            cur.Draw(gc, new System.Drawing.Rectangle(0, 0, cur.Size.Width, cur.Size.Height));
            img.Save(@"C:\Users\DELL\Documents\Visual Studio 2008\Projects\Happy_Fishing\target_cursor.jpg");

            gc.Dispose();
            img.Dispose();
        }
        #endregion

        #region [ 已注释，不需要 ] 截取鼠标样式重构函数（bitmap）（未完成）
        //private Bitmap capture_cursor_type()
        //{
        //    CURSORINFO pci;
        //    pci.cbSize = Marshal.SizeOf(typeof(CURSORINFO));
        //    GetCursorInfo(out pci);
        //    System.Windows.Forms.Cursor cur = new System.Windows.Forms.Cursor(pci.hCursor);
        //    Image img = new Bitmap(cur.Size.Width, cur.Size.Height);
        //    Graphics gc = Graphics.FromImage(img);
        //    cur.Draw(gc, new System.Drawing.Rectangle(0, 0, cur.Size.Width, cur.Size.Height));
        //    //img.Save(@"C:\Users\DELL\Documents\Visual Studio 2008\Projects\Happy_Fishing\target_cursor.jpg");

        //    return img;//返回
        //    gc.Dispose();
        //    img.Dispose();
        //}
        #endregion

        #region 鼠标对比重构函数（图片路径）（已完成）
        private bool image_whether_match(string base_path, string target_path)
        {
            bool image_whether_match = true;

            #region 获取基准图片和目标图片
            Bitmap base_image = (Bitmap)Image.FromFile(base_path);
            Bitmap target_image = (Bitmap)Image.FromFile(target_path);
            int base_image_width = base_image.Width;
            int base_image_height = base_image.Height;
            int target_image_width = target_image.Width;
            int target_image_height = target_image.Height;
            #endregion

            #region [ 重要 ]核心对比代码
            if (target_image_width != base_image_width || target_image_height != base_image_height)//首先对比大小，大小不一致就不必继续判断
                image_whether_match = false;

            else for (int w = 0; w < base_image_width; w++)
                {
                    for (int h = 0; h < base_image_height; h++)//其次按照像素点一一对比
                    {
                        if (target_image.GetPixel(w, h) != base_image.GetPixel(w, h))
                        {
                            image_whether_match = false;
                            break;
                        }
                    }

                    if (!image_whether_match)
                        break;
                }
            #endregion

            base_image.Dispose();//释放图片非常重要，否则第二次截屏时会报GDI+ 中发生一般性错误
            target_image.Dispose();//释放图片非常重要，否则第二次截屏时会报GDI+ 中发生一般性错误

            return image_whether_match;
        }
        #endregion

        #region 鼠标对比重构函数（图片）（已完成）
        private bool image_whether_match(Bitmap base_image, Bitmap target_image)
        {
            bool image_whether_match = true;

            #region 获取基准图片和目标图片的宽与高            
            int base_image_width = base_image.Width;
            int base_image_height = base_image.Height;
            int target_image_width = target_image.Width;
            int target_image_height = target_image.Height;
            #endregion

            #region [ 重要 ]核心对比代码
            if (target_image_width != base_image_width || target_image_height != base_image_height)//首先对比大小，大小不一致就不必继续判断
                image_whether_match = false;

            else for (int w = 0; w < base_image_width; w++)
                {
                    for (int h = 0; h < base_image_height; h++)//其次按照像素点一一对比
                    {
                        if (target_image.GetPixel(w, h) != base_image.GetPixel(w, h))
                        {
                            image_whether_match = false;
                            break;
                        }
                    }

                    if (!image_whether_match)
                        break;
                }
            #endregion

            return image_whether_match;
        }
        #endregion

        #region 钓鱼鼠标位置函数，调用鼠标对比重构函数（图片）（已完成）
        private Point move_2_fishing_cursor_position()
        {
            int compare_step_length_i = 25;//定义鼠标移动的横向步长，后期作成程序界面设置接入
            int compare_step_length_j = 25;//定义鼠标移动的纵向步长，后期作成程序界面设置接入
            int compare_step_time = 10;//定义鼠标移动的时间间隔，后期作成程序界面设置接入
            Point cursor_position = new Point(88, 88);
            CURSORINFO pci;
            pci.cbSize = Marshal.SizeOf(typeof(CURSORINFO));
            bool whether_found_the_float = false;//初始化是否已经找到鱼漂位置的布尔值

            #region 控制递归循环的次数，超过fishing_cursor_check_max次就不再继续
            fishing_cursor_checks++;
            if (fishing_cursor_checks == fishing_cursor_check_max)
            {
                fishing_cursor_checks = 0;
                return cursor_position;
            }
            #endregion

            else
            {
                #region [ 重要 ]核心对比代码
                for (int j = 0; j * compare_step_length_j <= 150; j++) //参考目前17张图片对比测试范围是BS（71）12 ~ CO（93）19
                {
                    for (int i = 0; i * compare_step_length_i <= 650; i++)
                    {
                        //i的变化范围取决于i * compare_step_length有没有达到650，即从400到1050，这样就不必再针对步长重新设置 i；
                        //j的变化范围取决于j * compare_step_length有没有达到200，即从122到322，这样就不必再针对步长重新设置 j；

                        #region [ 已置后 ] 步进鼠标位置。有些情况下，上一次收线的鼠标位置正好是下一次鱼漂的位置，因此先判断是否满足鼠标样式，再移动鼠标，因此该段代码置后
                        //cursor_position.X = i * compare_step_length_i + 600;//即从横向600的位置开始计算，这样步长就有意义；
                        //cursor_position.Y = j * compare_step_length_j + 122;//即从纵向122的位置开始计算，这样步长就有意义；
                        //SetCursorPos(cursor_position.X, cursor_position.Y);
                        #endregion

                        #region [ 未使用 ] 移动鼠标后调用截取鼠标样式函数来获取当前鼠标的样式
                        //Thread.Sleep(500);

                        //capture_cursor_type();
                        //#endregion

                        //#region 获取鼠标样式后调用鼠标对比函数（图片路径）来判断是否为钓鱼鼠标
                        //Thread.Sleep(compare_step_time);

                        //if (image_whether_match(@"C:\Users\DELL\Documents\Visual Studio 2008\Projects\Happy_Fishing\base_cursor.jpg", @"C:\Users\DELL\Documents\Visual Studio 2008\Projects\Happy_Fishing\target_cursor.jpg"))
                        //{
                        //    whether_found_the_float = true;
                        //    break;
                        //}
                        #endregion

                        #region [ 使用 ] 获取鼠标样式后调用鼠标对比函数（图片）来判断是否为钓鱼鼠标
                        Thread.Sleep(compare_step_time);

                        pci.cbSize = Marshal.SizeOf(typeof(CURSORINFO));
                        GetCursorInfo(out pci);
                        System.Windows.Forms.Cursor cur = new System.Windows.Forms.Cursor(pci.hCursor);
                        Image img = new Bitmap(cur.Size.Width, cur.Size.Height);
                        Graphics gc = Graphics.FromImage(img);
                        cur.Draw(gc, new System.Drawing.Rectangle(0, 0, cur.Size.Width, cur.Size.Height));

                        if (image_whether_match(base_cursor_image, (Bitmap)img))
                        {
                            whether_found_the_float = true;
                            GetCursorPos(out cursor_position);//解决第二次放线正好是上次位置时导致的不显示音量的问题

                            //cursor_position.X = i * compare_step_length_i + 600 + 5;//+5的目的是让鼠标横向再移动5个像素，确保在鱼漂上面
                            //cursor_position.Y = j * compare_step_length_j + 122 + 5;//+5的目的是让鼠标纵向再移动5个像素，确保在鱼漂上面
                            //SetCursorPos(cursor_position.X, cursor_position.Y);

                            gc.Dispose();
                            img.Dispose();
                            break;
                        }
                        else
                        {
                            gc.Dispose();//不管是否一致都释放资源
                            img.Dispose();//不管是否一致都释放资源
                        }
                        #endregion

                        #region 步进鼠标位置
                        cursor_position.X = i * compare_step_length_i + 400;//即从横向400的位置开始计算，这样步长就有意义；
                        cursor_position.Y = j * compare_step_length_j + 122;//即从纵向122的位置开始计算，这样步长就有意义；
                        SetCursorPos(cursor_position.X, cursor_position.Y);
                        #endregion
                    }

                    if (whether_found_the_float)
                        break;
                }
                #endregion

                #region 使用递归的方法解决一些发现的横向移动过头的情况
                Thread.Sleep(100);

                GetCursorInfo(out pci);
                System.Windows.Forms.Cursor cur_over_move = new System.Windows.Forms.Cursor(pci.hCursor);
                Image img_over_move = new Bitmap(cur_over_move.Size.Width, cur_over_move.Size.Height);
                Graphics gc_over_move = Graphics.FromImage(img_over_move);
                cur_over_move.Draw(gc_over_move, new System.Drawing.Rectangle(0, 0, cur_over_move.Size.Width, cur_over_move.Size.Height));

                if (image_whether_match(base_cursor_image, (Bitmap)img_over_move) == false)
                {
                    //cursor_position.X = cursor_position.X - 15;
                    //cursor_position.Y = cursor_position.Y + 15;
                    //SetCursorPos(cursor_position.X, cursor_position.Y);

                    cursor_position = move_2_fishing_cursor_position();
                }
                #endregion

                fishing_cursor_checks = 0;
                return cursor_position;
            }
        }
        #endregion        

        #region 检测巨型鱼漂Buff
        private bool whether_giant_float_buff()
        {
            bool whether_giant_float_buff = false;
            Image img = new Bitmap(26, 26);
            Graphics gc = Graphics.FromImage(img);

            for (int i = 1; i <= 10; i++)
            {
                gc.CopyFromScreen(new System.Drawing.Point(1367 - (i - 1) * 35, 37), new System.Drawing.Point(0, 0), new Size(26, 26));

                if (image_whether_match(base_giant_float_buff_image, (Bitmap)img))
                {
                    whether_giant_float_buff = true;
                    break;
                }
            }

            img.Dispose();
            gc.Dispose();

            return whether_giant_float_buff;
        }
        #endregion

        #region 测试用代码段，已注释
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    #region 激活魔兽世界窗口
        //    Thread.Sleep(500);

        //    string pName = "Wow-64";
        //    Process[] temp = Process.GetProcessesByName(pName);
        //    if (temp.Length > 0)//进程存在的话，则激活对应窗口
        //    {
        //        IntPtr process_handler = temp[0].MainWindowHandle;
        //        SwitchToThisWindow(process_handler, true);//激活指定进程的窗口
        //    }
        //    else//进程不存在的话，弹窗提示魔兽世界未打开，并跳出循环
        //    {
        //        MessageBox.Show("魔兽世界未打开！");
        //        //break;
        //    }
        //    #endregion

        //    Image img = new Bitmap(26, 26);
        //    Graphics gc = Graphics.FromImage(img);
        //    for (int i = 1; i <= 5; i++)
        //    {
        //        string saving_path = @"C:\Users\DELL\Documents\Visual Studio 2008\Projects\Happy_Fishing\buff_" + i.ToString() + ".jpg";
        //        gc.CopyFromScreen(new System.Drawing.Point(1367 - (i - 1) * 35, 37), new System.Drawing.Point(0, 0), new Size(26, 26));
        //        img.Save(saving_path);

        //        Thread.Sleep(500);
        //    }

        //    img.Dispose();
        //    gc.Dispose();
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    Thread.Sleep(3000);
        //    capture_cursor_type();

        //    string target_path = @"C:\Users\DELL\Documents\Visual Studio 2008\Projects\Happy_Fishing\target_cursor.jpg";
        //    string base_path = @"C:\Users\DELL\Documents\Visual Studio 2008\Projects\Happy_Fishing\base_cursor.jpg";

        //    if(image_whether_match(base_path,target_path))
        //        MessageBox.Show("钓鱼鼠标");
        //    else MessageBox.Show("不是钓鱼鼠标");
        //}

        //private void btn_time_test_Click(object sender, EventArgs e)
        //{
        //    DateTime dt = DateTime.Now;

        //    txt_start_time_4_test.Text = dt.ToString();
        //    Thread.Sleep(12100);
        //    DateTime dtt = DateTime.Now;
        //    TimeSpan gap = dtt - dt;
        //    int gap_millisecond = gap.Hours * 3600000 + gap.Minutes * 60000 + gap.Seconds * 1000 + gap.Milliseconds;


        //    txt_end_time_4_test.Text = (dtt - dt).ToString();

        //    txt_time_test.Text = gap_millisecond.ToString();
        //}

        //private void btn_buff_test_Click_1(object sender, EventArgs e)
        //{
        //    #region 激活魔兽世界窗口
        //    Thread.Sleep(500);

        //    string pName = "Wow-64";
        //    Process[] temp = Process.GetProcessesByName(pName);
        //    if (temp.Length > 0)//进程存在的话，则激活对应窗口
        //    {
        //        IntPtr process_handler = temp[0].MainWindowHandle;
        //        SwitchToThisWindow(process_handler, true);//激活指定进程的窗口
        //    }
        //    else//进程不存在的话，弹窗提示魔兽世界未打开，并跳出循环
        //    {
        //        MessageBox.Show("魔兽世界未打开！");
        //        //break;
        //    }
        //    #endregion

        //    Image img = new Bitmap(26, 26);
        //    Graphics gc = Graphics.FromImage(img);
        //    for (int i = 1; i <= 5; i++)
        //    {
        //        string saving_path = @"C:\Users\DELL\Documents\Visual Studio 2008\Projects\Happy_Fishing\buff_" + i.ToString() + ".jpg";
        //        gc.CopyFromScreen(new System.Drawing.Point(1367 - (i - 1) * 35, 37), new System.Drawing.Point(0, 0), new Size(26, 26));
        //        img.Save(saving_path);

        //        Thread.Sleep(500);
        //    }

        //    img.Dispose();
        //    gc.Dispose();
        //}
        #endregion        
    }
}

#region 整体逻辑说明
/* 1. 激活魔兽世界窗口并放线；
 * 2. 移动鼠标位置直至找到鱼漂，核心方法为 Point move_2_fishing_cursor_position()；
 * 2.1 在寻找鱼漂位置的过程中使用递归的方法，但次数不超过 fishing_cursor_check_max，目前设置为 15；
 * 2.2 如果找到鱼漂位置，则返回鱼漂位置坐标点；如果没找到则返回 (88, 88)，通过主函数传递给监控声音函数 system_volume(Point cursor_position)；
 * 3. 监控系统音量合成器中魔兽世界的音量，超过某个音量时自动点击鼠标左键收线；
 * 3.1 在监控过程中，用函数内变量 time_gap 累计监控的时间长度是否超过 22 s；
 * 3.2 如果监控到声音变化，则直接点击鼠标；如果没有监控到而超时，也直接点击鼠标；即不能存在无限等待的情况；
*/
#endregion