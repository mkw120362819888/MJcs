using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.ComPONentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;



namespace MJcs
{
    public partial class MainForm : Form
    {

        //==============================================================================================
        //public static int[] MJnum={0,
        // 11, 12, 13, 14, 21, 22, 23, 24, 31, 32, 33, 34, 41, 42, 43, 44, 51, 52, 53, 54, 61, 62, 63, 64, 71, 72, 73, 74, 81, 82, 83, 84, 91, 92, 93, 94,
        //101,102,103,104,111,112,113,114,121,122,123,124,131,132,133,134,141,142,143,144,151,152,153,154,161,162,163,164,171,172,173,174,181,182,183,184,
        //191,192,193,194,201,202,203,204,211,212,213,214,221,222,223,224,231,232,233,234,241,242,243,244,251,252,253,254,261,262,263,264,271,272,273,274,
        //281,282,283,284,291,292,293,294,301,302,303,304,311,312,313,314,321,322,323,324,331,332,333,334,341,342,343,344,
        //350,360,370,380,390,400,410,420
        //};
        private static int[] MJnum = new int[145]{0,
 1,  1,  1,  1,  2,  2,  2,  2,  3,  3,  3,  3,  4,  4,  4,  4,  5,  5,  5,  5,  6,  6,  6,  6,  7,  7,  7,  7,  8,  8,  8,  8,  9,  9,  9,  9,
11, 11, 11, 11, 12, 12, 12, 12, 13, 13, 13, 13, 14, 14, 14, 14, 15, 15, 15, 15, 16, 16, 16, 16, 17, 17, 17, 17, 18, 18, 18, 18, 19, 19, 19, 19,
21, 21, 21, 21, 22, 22, 22, 22, 23, 23, 23, 23, 24, 24, 24, 24, 25, 25, 25, 25, 26, 26, 26, 26, 27, 27, 27, 27, 28, 28, 28, 28, 29, 29, 29, 29,
31, 31, 31, 31, 32, 32, 32, 32, 33, 33, 33, 33, 34, 34, 34, 34, 35, 35, 35, 35, 36, 36, 36, 36, 37, 37, 37, 37,
41,42,43,44,45,46,47,48
};
        private int[] MJran = new int[145]{0,0,0,0,0,
0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
};
        private int[] MJdata = new int[145]{0,0,0,0,0,
0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
};
        private int[] MJPDL = new int[146]
        {0,
    0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,//1
	0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,//2
	0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,//3
	0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,//4
	0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,//5
	0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,//6
	0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,//7
	0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,//8
	0};
        private int[,] MJP = new int[5, 20]
        {
//   0,1,2,3,4,5,6,7,8,9,0,1,2,3,4,5,6,7,8,9
	{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
        };
        private int[,,] MJPED = new int[5, 11, 4]
        {
    {{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 }},
    {{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 }},
    {{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 }},
    {{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 }},
    {{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 },{0,0,0,0 }}
        };
        private int[,] MJPF = new int[5, 10]
        {
//   0,1,2,3,4,5,6,7,8,9
	{0,0,0,0,0,0,0,0,0,0},
    {0,0,0,0,0,0,0,0,0,0},
    {0,0,0,0,0,0,0,0,0,0},
    {0,0,0,0,0,0,0,0,0,0},
    {0,0,0,0,0,0,0,0,0,0}
        };
        //                    0,1,2,3,4,5,6,7,8,9,0,1,2,3,4,5,6,7,8   拋牌資料陣列
        private int[] MJPC = new int[73]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                                        0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                                        0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                                        0,0,0,0,0,0,0,0,0,0,0,0,0};
        //==============================================================================================
        //DataChange 資料整理陣列
        //                             0,1,2,3,4,5,6,7,8,9,0,1,2,3,4,5,6,7,8,9,0,1,2,3,4   資料整理陣列
        private int[] MJDC = new int[25] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        //public int[] MJDataChange={0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
        //==============================================================================================
        //                           0,  1,  2,  3,  4,  5,  6,  7,  8,  9, 10, 11, 12, 13, 14, 15, 16, 17,18
        public static int[] MJPBX = { 0, 10, 50, 90, 130, 170, 210, 250, 290, 330, 370, 410, 450, 490, 530, 570, 610, 655, 0 };
        public static int[] MJPBY = { 0, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 0 };

        public static int[] MJPBX1 = { 0, 0, 40, 80, 120, 160, 200, 240, 280, 320, 360, 400, 440, 480, 520, 560, 600, 645, 0 };
        public static int[] MJPBY1 = { 0, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 0 };

        public static int[] MJPSX = { 0, 0, 32, 64, 96, 128, 160, 192, 224, 256, 288, 320, 352, 384, 416, 448, 480, 512, 0 };
        public static int[] MJPSY = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        //--------------------
        //                           0,  1,  2,  3,  4,  5,  6,  7,  8,  9, 10, 11, 12, 13, 14, 15, 16, 17,18
        public static int[] MJPX = { 0, 10, 92, 174, 256, 338, 420, 502, 584, 666, 748, 830, 912, 994, 1076, 1158, 1240, 1322, 1404, 0 };
        public static int[] MJPY = { 0, 65, 65, 65, 65, 65, 65, 65, 65, 65, 65, 65, 65, 65, 65, 65, 65, 65, 65, 0 };
        public static int MJPW = 82, MJPH = 128;
        //                            0,  1,  2,  3,  4,  5,  6,  7,  8,  9, 10, 11, 12, 13, 14, 15, 16, 17,18
        public static int[] MJPEDX = { 0, 0, 82, 164, 246, 328, 410, 492, 574, 656, 738, 820, 902, 984, 1066, 1148, 1230, 1312, 1394, 1476, 1558, 1640, 1722, 0 };
        public static int[] MJPEDY = { 0, 65, 65, 65, 65, 65, 65, 65, 65, 65, 65, 65, 65, 65, 65, 65, 65, 65, 65, 65, 65, 65, 65, 0 };
        public static int MJPEDW = 82, MJPEDH = 128;
        //                           0,  1,  2,  3,  4,  5,  6,  7,  8,  9, 10, 11, 12, 13, 14, 15, 16, 17,18
        public static int[] MJPFX = { 0, 0, 41, 82, 123, 164, 205, 246, 287, 0 };
        public static int[] MJPFY = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public static int MJPFW = 41, MJPFH = 64;

        public static int[] MJPCX ={
          0,0,41,82,123,164,205,246,287,328,369,410,451,492,533,574,615,656,697,738,779,820,861,902,943,984,1025,1066,1107,1148,1189,1230,1271,1312,1353,1394,1435,
            0,41,82,123,164,205,246,287,328,369,410,451,492,533,574,615,656,697,738,779,820,861,902,943,984,1025,1066,1107,1148,1189,1230,1271,1312,1353,1394,1435,0
};
        public static int[] MJPCY ={
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,0};
        public static int MJPCW = 41, MJPCH = 64;

        public static int[] MJPMX ={0,
0,40,80,120,160,200,240,280,320,360,400,440,480,520,560,600,640,680,
0,40,80,120,160,200,240,280,320,360,400,440,480,520,560,600,640,680,
0,40,80,120,160,200,240,280,320,360,400,440,480,520,560,600,640,680,
0,40,80,120,160,200,240,280,320,360,400,440,480,520,560,600,640,680
};
        public static int[] MJPMY ={0,
0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,
100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,
150,150,150,150,150,150,150,150,150,150,150,150,150,150,150,150,150,150
};
        public static int MJPMW = 41, MJPMH = 64;

        public static int MJBW = 82, MJBH = 128;
        public static int MJSW = 41, MJSH = 64;
        //==============================================================================================
        //public int MJBPC=0,MJSPC=0;
        public int MJBigCircle = 0;//風值
        public int MJSmallCircle = 0;//局值
                                     //private int MJStartMainPlayer=0;//開始的莊家
                                     //private int MJMainPlayer=0;//現在的莊家
                                     //private int MJStartPlayer=0;//開始的玩家
                                     //private int MJplayer=1;//現在領牌的玩家
                                     //public int MJGet=0;//private int MJPGetOrder=0;//發牌序號
                                     //private int MJPMGetPOS=0;//中央區覆蓋牌圖形消除位置
                                     //private int MJPMCancelPOS=0;//中央區棄牌圖形繪製位置
                                     //==============================================================================================
        public int MJMPL = 0, MJPlayCircleNum = 0, MJGameChange = 0, MJGameOver = 0;
        public int MJStartPlayer = 0, MJplayerRan = 0, MJplayerOrder = 0, MJplayer = 1, MJREPLAY = 0;
        public int MJStartGet = 0, MJGetRan = 0, MJGet = 0;

        public int MJPMPOS = 0;
        public int MJCancelNum = 0, MJCancelPos = 0, MJPCnum = 0, MJPCtotal = 0;
        public int RandNum = 7, StartGetGoNum = 0;
        public int LastGos = 0, Gos = 0, GoRow = 0, GoIcon = 0, GetOrder = 0;
        public int row = 0, GoSum = 0, LastGoSum = 0;
        public int DisplayNum = 0, xxxx = 0, yyyy = 0, wwww = 0, hhhh = 0;


        public int BmpNum = 0, px = 0, py = 0, pxy = 0;


        public int StartPlay = 2;
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public int MJBUTTOMm = 999999;
        public int MJLEFTm = 999999;
        public int MJRIGHTm = 999999;


        public int MJTOPm = 999999;
        public int MJPLnum = 88;
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public int MJDX = 0, MJDY = 0, MJTYPE = 0;
        public string newText = "";
        public string MJdisTEXT = "";
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public int MJAuto = 0, MJisHU = 0;
        public int MJsupplemented = 0;
        public int MJdistributed = 0;
        public int ChangeFormPOSed = 0;
        public int FormPOSnum = 0;
        //==============================================================================================
        public int MJINran = 0;
        public int MJINnum = 0;
        public int MJisSupplement = 0;
        public int MJCPX = 0, MJCPY = 0;

        //==============================================================================================
        public static string[,] LBstatusText =
        {
    {"","","","",""},
    {"","東風東局","東風南局","東風西局","東風北局"},
    {"","南風東局","南風南局","南風西局","南風北局"},
    {"","西風東局","西風南局","西風西局","西風北局"},
    {"","北風東局","北風南局","北風西局","北風北局"}
};
        //==============================================================================================
        Bitmap MJbmp0 = new Bitmap(1480, 130);//1476, 130
        Bitmap MJbmp1 = new Bitmap(1325, 195);//1322, 195
        Bitmap MJbmp2 = new Bitmap(1325, 195);
        Bitmap MJbmp3 = new Bitmap(1325, 195);
        Bitmap MJbmp4 = new Bitmap(1325, 195);
        //Bitmap MJTOPbmp = new Bitmap(664,90);//(665,665)private
        //public Bitmap MJPBbmp = new Bitmap(550,550);//(665,665)private
        //public Bitmap ggimg; // Bitmap 影像
        public Image MJimg; // Bitmap 影像

        //WebCam webcam;

        //==============================================================================================



        public MainForm()
        {
            InitializeComponent();
        }

        int device = 0;
        int hwnd;

        // 宣告Windows API
        const int WM_USER = 0x400;
        const int WM_CAP_DRIVER_CONNECT = WM_USER + 10;
        const int WM_CAP_DRIVER_DISCONNECT = WM_USER + 11;
        const int WM_CAP_FILE_SAVEAS = WM_USER + 23;
        const int WM_CAP_EDIT_COPY = WM_USER + 30;
        const int WM_CAP_SET_PREVIEW = WM_USER + 50;
        const int WM_CAP_SET_PREVIEWRATE = WM_USER + 52;
        const int WM_CAP_SET_SCALE = WM_USER + 53;
        const int WM_CAP_SEQUENCE = WM_USER + 62;

        const int WS_CHILD = 0x40000000;
        const int WS_VISIBLE = 0x10000000;
        const short SWP_NOSIZE = 1;
        const short SWP_NOMOVE = 2;
        const short SWP_NOZORDER = 4;
        const short HWND_BOTTOM = 1;

        [DllImport("avicap32.dll")]
        static extern int capCreateCaptureWindowA(string lpszWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, int hWndParent, int nID);

        //[DllImport("avicap32.dll")]
        //static extern bool capGetDriverDescriptionA(short wDriver, byte[] lpszName, int cbName, byte[] lpszVer, int cbVer);

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        static extern int SendMessage(int hwnd, int wMsg, int wParam, [MarshalAs(UnmanagedType.AsAny)] object lParam);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        static extern int SetWindowPos(int hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);

        [DllImport("user32.dll")]
        static extern bool DestroyWindow(int hndw);



        private void Form1_Load(object sender, EventArgs e)
        {
            this.MJmain.Text = "麻將";
            this.MJMSG1.Visible = false;
            this.MJMSG2.Visible = false;
            this.MJMSG3.Visible = false;
            this.MJMSG4.Visible = false;
            this.BT1.Text = "";
            this.BT2.Text = "";
            this.BT3.Text = "";
            this.BT1.Enabled = false;
            this.BT2.Enabled = false;
            this.BT3.Enabled = false;
            ////this.BUThu.Enabled = false;
            ////this.BUTga.Enabled = false;

            //Thread TR = new Thread(Run);//指派工作給執行緒
            //TR.IsBackground = true;
            //TR.Start();//使用thread.Start(); 來開始執行緒工作 


            StartWebCam();




        }


        void Run()  //static
        {
            while (true)
            {
                // 建立視訊裝置的控制代碼 (Handle to a Window) 
                // 並輸出至指定的PictureBox物件中
                hwnd = capCreateCaptureWindowA("WebCam", (WS_CHILD | WS_VISIBLE), 0, 0, 0, 0, MJimage1.Handle.ToInt32(), 0);

                // 連接至視訊裝置
                if (SendMessage(hwnd, WM_CAP_DRIVER_CONNECT, device, 0) == 1)
                {
                    // 設定預覽比率
                    SendMessage(hwnd, WM_CAP_SET_SCALE, 1, 0);
                    // 設定預覽速率
                    SendMessage(hwnd, WM_CAP_SET_PREVIEWRATE, 30, 0);
                    // 開始視訊裝置預覽
                    SendMessage(hwnd, WM_CAP_SET_PREVIEW, 1, 0);
                    // 調整預覽大小至PictureBox
                    SetWindowPos(hwnd, HWND_BOTTOM, 0, 0, MJimage1.Width, MJimage1.Height, (SWP_NOMOVE | SWP_NOZORDER));
                }
                else
                {
                    // 無法連接至視訊裝置
                    DestroyWindow(hwnd);

                    MessageBox.Show("無法連接至視訊裝置.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    Environment.Exit(0);
                }
            }
        }


        private void StartWebCam()  //private
        {
            // 建立視訊裝置的控制代碼 (Handle to a Window) 
            // 並輸出至指定的PictureBox物件中
            hwnd = capCreateCaptureWindowA("WebCam", (WS_CHILD | WS_VISIBLE), 0, 0, 0, 0, MJimage1.Handle.ToInt32(), 0);

            // 連接至視訊裝置
            if (SendMessage(hwnd, WM_CAP_DRIVER_CONNECT, device, 0) == 1)
            {
                // 設定預覽比率
                SendMessage(hwnd, WM_CAP_SET_SCALE, 1, 0);
                // 設定預覽速率
                SendMessage(hwnd, WM_CAP_SET_PREVIEWRATE, 30, 0);
                // 開始視訊裝置預覽
                SendMessage(hwnd, WM_CAP_SET_PREVIEW, 1, 0);
                // 調整預覽大小至PictureBox
                SetWindowPos(hwnd, HWND_BOTTOM, 0, 0, MJimage1.Width, MJimage1.Height, (SWP_NOMOVE | SWP_NOZORDER));
            }
            else
            {
                // 無法連接至視訊裝置
                DestroyWindow(hwnd);

                MessageBox.Show("無法連接至視訊裝置.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Environment.Exit(0);
            }
        }





        private void MJmain_Click(object sender, EventArgs e)
        {
            Point screenPoint = MJmain.PointToScreen(new Point(MJmain.Left, MJmain.Bottom));
            if (screenPoint.Y + contextMenuStrip1.Size.Height > Screen.PrimaryScreen.WorkingArea.Height)
            {
                contextMenuStrip1.Show(MJmain, new Point(0, -contextMenuStrip1.Size.Height));
            }
            else
            {
                contextMenuStrip1.Show(MJmain, new Point(0, MJmain.Height));
            }
        }
        private void contextMenuStrip1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        void BTchangeformPOSClick(object sender, EventArgs e)
        {
            if (ChangeFormPOSed == 0)
            { ChangeFormPOSed = 1;
                TEXTBOXDIS("開始改變視窗位置..." + "  ");
            }
            else
            { ChangeFormPOSed = 0;
                TEXTBOXDIS("停止改變視窗位置 !!!" + "  ");
            }
        }
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        void ChangeFormPOS()
        {
            //	public int FormPOSnum=0;

            int deskHeight = Screen.PrimaryScreen.Bounds.Height;
            int deskWidth = Screen.PrimaryScreen.Bounds.Width;

            FormPOSnum += 1;
            if (FormPOSnum > 5) { FormPOSnum = 1; }
            if (FormPOSnum == 1)
            {
                this.Left = (deskWidth - this.Width) / 2;
                this.Top = (deskHeight - this.Height) / 2;
            }
            if (FormPOSnum == 2)
            {
                this.Left = 0; this.Top = 0;
            }
            if (FormPOSnum == 3)
            {
                this.Left = 0;
                this.Top = deskHeight - this.Height;
            }
            if (FormPOSnum == 4)
            {
                this.Left = deskWidth - this.Width;
                this.Top = deskHeight - this.Height;
            }
            if (FormPOSnum == 5)
            {
                this.Left = deskWidth - this.Width;
                this.Top = 0;
            }
        }
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        void BTexitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888



        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        void BTrunAUTOClick(object sender, EventArgs e)
        {
            ChangeFormPOSed = 0;
            MJSmallCircle = 0;
            MJBigCircle = 1;
            if (this.MJmaintimer.Enabled == true) { this.MJmaintimer.Enabled = false; }//MJAuto=0;
            else { this.MJmaintimer.Enabled = true; }//MJAuto=0;
        }

        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
            private void webCamTestToolStripMenuItem_Click(object sender, EventArgs e)
            {

            }

        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        void MJTESTtimerTick(object sender, EventArgs e)
        {
            Color BC = Color.FromArgb(0, 128, 0);//自訂RGB
            SolidBrush BrushBC = new SolidBrush(BC);//Graphics Brush使用方式

            Graphics g0 = Graphics.FromImage(MJbmp0);
            g0.FillRectangle(BrushBC, new Rectangle(0, 0, 1480, 130));
            MJPBDIS(0);

            Graphics g1 = Graphics.FromImage(MJbmp1);
            g1.FillRectangle(BrushBC, new Rectangle(0, 0, 1325, 195));
            MJPBDIS(1);
            Graphics g2 = Graphics.FromImage(MJbmp2);
            g2.FillRectangle(BrushBC, new Rectangle(0, 0, 1325, 195));
            MJPBDIS(2);
            Graphics g3 = Graphics.FromImage(MJbmp3);
            g3.FillRectangle(BrushBC, new Rectangle(0, 0, 1325, 195));
            MJPBDIS(3);
            Graphics g4 = Graphics.FromImage(MJbmp4);
            g4.FillRectangle(BrushBC, new Rectangle(0, 0, 1325, 195));
            MJPBDIS(4);

            MessageBox.Show("MJTESTtimerTick OK !!!");

        }
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        void MJAUTOPLAYtimerTick(object sender, EventArgs e)
        {
            //MJGet = 1;
            try
            {
                //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*	
                if (MJGet > 144)
                {
                    TEXTBOXDIS("<<< MJAUTOPLAY END" + "  ");
                    MJGet = 1; MJREPLAY = 1; TEXTMSG.Text = "";
                }
                //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*	
                if (MJGet == 1)
                {
                    TEXTBOXDIS(">>> MJAUTOPLAY ..." + "  ");
                    if (ChangeFormPOSed == 1) { ChangeFormPOS(); }

                    MJSmallCircle++;
                    if (MJSmallCircle > 4) { MJSmallCircle = 1; MJBigCircle++; if (MJBigCircle > 4) { MJBigCircle = 1; } }
                    //*****************************************************************************	
                    ////MJStartINIT();

                    MJINIT();//MJ數據初始化

                    //MessageBox.Show("MJINIT OK !!!");

                    MJbmp0dis(); //亂數牌顯示
                    MJrandomdata(); //建立亂數資料 MJrandomdata
                    MJdistribute(); //分牌 distribute

                    do
                    {
                        MJarrange(); //理牌 arrange
                        MJsupplement(); //補牌 supplement
                        MJarrange(); //理牌 arrange
                    } while (MJsupplemented == 1);

                    for (int p = 1; p <= 4; p++)
                    {
                        MJdataDIS(p);
                    }

                    //MJarrange(); //理牌 arrange
                    //x=17;MJDIS(MJnum[MJPD[1,1,x]],MJBW,MJBH,MJPDBX[x],MJPDBY[x],1);//MJCancelNum=MJPD[1,1,17];
                    this.MJmain.Text = LBstatusText[MJBigCircle, MJSmallCircle];
                    //牌位置ICON顯示 //MJDIS(MJnum[MJB2[c]],MJB2W,MJB2H,MJB2X+(c-1)*MJB2W,MJB2Y,0,1);//MJBUTTOMPB.Image = MJBUTTOMbmp;MJBUTTOMPB.Refresh();
                    //                    MJDIS(112, 40, 40, MJPDBX[14], 0, 1); MJDIS(-1, 0, 0, 0, 0, 11); MJPBDIS(1);
                    //                    MJDIS(113, 40, 40, MJPDBX[14], MJPDSY[1], 2); MJDIS(-1, 0, 0, 0, 0, 12); MJPBDIS(2);
                    //                    MJDIS(114, 40, 40, MJPDBX[14], MJPDSY[1], 3); MJDIS(-1, 0, 0, 0, 0, 13); MJPBDIS(3);
                    //                    MJDIS(111, 40, 40, MJPDBX[14], MJPDSY[1], 4); MJDIS(-1, 0, 0, 0, 0, 14); MJPBDIS(4);
                    //                    MJDIS(100, 40, 40, MJPDX[13], 0, MJplayer); MJPBDIS(MJplayer);
                    //*****************************************************************************	
                    //x=17;MJDIS(MJnum[MJPD[1,1,x]],MJBW,MJBH,MJPDBX[x],MJPDBY[x],1);
                    //MJCancelNum=MJPD[MJplayer,1,17];
                    //                    MJCancelNum = MJPD[MJplayer, 17];//MJDIS(0,MJBW,MJBH,MJPDBX[17],MJPDBY[17],MJplayer);
                    //                    MJDIS(0, MJPDW, MJPDH, MJPDX[17], MJPDY[17], MJplayer); MJPBDIS(MJplayer);
                    //                    MJDIS(MJnum[MJCancelNum], MJPMW, MJPMH, MJPMX[MJCancelPos], MJPMY[MJCancelPos], 0); MJPBDIS(0);

                    MJdataWriteAll();
                }
                //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*	
                //-----------------------------------------------
                ////MJAutoPlayCircle();

                //MJINran=MJran[MJGet];
                //MJInAnalysis();//進牌分析
                MJin();//進牌
                //MJCancelAnalysis();//拋牌分析
                //MJCancel();//拋牌
                //MJSolutionAnalysis();//結果分析
                //MJSolution();//結果顯示

                ////MJP[MJplayer, 17] = MJran[MJGet];  //65
                ////MJDIS(MJnum[MJP[MJplayer, 17]], 0, 0, 0, 0, 200 + MJplayer);

                TEXTBOXDIS(MJMPL.ToString() + "," + MJplayer.ToString()
                       + "," + MJGet.ToString() + "," + MJCancelNum.ToString() + "  ");
                //設定玩者循環
                MJplayer = MJplayer + 1;
                if (MJplayer > 4) { MJplayer = 1; }
                //-----------------------------------------------	
                //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*		
            }
            catch (Exception ex)
            { MessageBox.Show("MJAUTOPLAYtimerTick OnTimer(): " + ex.Message); }

        }
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        void MJInAnalysis()
        {
            MJINran = MJran[MJGet];
            MJINnum = MJnum[MJINran];  //MJnum[MJran[MJGet]]
        }
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //public void MJIn(int MJCPX, int MJCPY, int MJisSupplement)
        void MJin()//進牌
        {
            //MJINran=MJran[MJGet];//MJDIS(int mjicontype,int mjw,int mjh,int mjddx,int mjddy,int mjdisrect)
            //-----------------------------------------------
            MJdataRead();

            MJCPX = 0; MJCPY = 0; MJisSupplement = 0;
            //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            if (MJnum[MJran[MJGet]] > 40)
            {
                if (MJisSupplement == 0 || MJisSupplement == 1)
                {
                    TEXTBOXDIS("-> 補花牌" + "  "); TEXTBOXDIS("MJINnum=" + MJINnum.ToString() + "  ");
                    TEXTBOXDIS("MJisSupplement=" + MJisSupplement.ToString() + "  ");

                    MJP[MJplayer, 17] = MJran[MJGet];
                    //-----------------------------------------------
                    MJPF[MJplayer, 0]++;//玩者第2列花牌列花牌數量+1
                    MJPF[MJplayer, MJPF[MJplayer, 0]] = MJP[MJplayer, 17];//將第1列第17位置花牌設定給第2列花牌列

                    MJdataDIS(MJplayer);//重繪玩者牌區

                    MJP[MJplayer, 17] = 0;//將第1列第17位置數值歸0
                    MJDIS(0, 0, 0, 0, 0, 300 + MJplayer);
                    //-----------------------------------------------
                    MJisSupplement = 1;//補牌動作未結束
                    MJGet++;
                }
            }
            //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            //MJINran=MJran[MJGet];//MJINnum=MJnum[MJINran];
            //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            if (MJnum[MJran[MJGet]] < 41 && MJisSupplement == 1)//MJINran
            {
                TEXTBOXDIS("花牌進牌..." + "  ");
                //暫設第1列第17子為棄牌子
                MJP[MJplayer, 17] = MJran[MJGet];
                MJarrangeone();//玩者牌區第1列理牌
                MJDIS(MJnum[MJP[MJplayer, 17]], 0, 0, 0, 0, 300 + MJplayer);

                Thread.Sleep(2000); //Delay 1秒
                MJCancelNum = MJP[MJplayer, 17];
                MJCancel();
                MJdataDIS(MJplayer);

                MJarrange();//玩者牌區理牌
                MJdataDIS(MJplayer);

                MJisSupplement = 2; TEXTBOXDIS("花牌補完!" + "  ");
                MJGet++;
            }
            //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            if (MJnum[MJran[MJGet]] < 41 && MJisSupplement == 0)
            {
                TEXTBOXDIS("[ 正常進牌 ]" + "  ");
                //暫設第1列第17子為棄牌子//MJPD[MJplayer,1,17]=MJINran;//MJPD[MJplayer,1,17]=MJran[MJGet];
                MJP[MJplayer, 17] = MJran[MJGet];
                MJarrangeone();//玩者牌區理牌1
                MJDIS(MJnum[MJP[MJplayer, 17]], 0, 0, 0, 0, 300 + MJplayer);

                Thread.Sleep(2000); //Delay 1秒
                MJCancelNum = MJP[MJplayer, 17];
                MJCancel();
                MJdataDIS(MJplayer);

                MJarrange();//玩者牌區理牌
                MJdataDIS(MJplayer);

                //MJP[MJplayer, 17] = 0;//將第1列第17位置數值歸0
                //MJDIS(0, 0, 0, 0, 0, 300 + MJplayer);

                PUN();

                MJGet++;
            }
            //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            //MJGet++;

            MJdataWriteAll();
        }
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        void MJCancelAnalysis()
        {

        }
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        void MJCancel()
        {
            //MJCancelNum=MJP[MJplayer,17];MJPCnum = 0, MJPCtotal = 0;
            //MJPCnum = MJCancelNum;

            if(MJCancelNum>0 && MJCancelNum<137)
            {
                MJPCtotal++;
                MJPC[MJPCtotal] = MJCancelNum;

                MJCancelPos++; if (MJCancelPos > 72) { MJCancelPos = 72; }

                MJdataDIS0();
            }

            //MJPBDIS(MJplayer);

            //MJbmp0clear();

            //MJDIS(0, MJPCW, MJPCH, MJPCX[MJCancelPos], MJPCY[MJCancelPos], 0);
            //MJPBDIS(0);//清除棄牌區蓋牌圖形
            //MJCPX = MJPCX[MJCancelPos]; MJCPY = MJPCY[MJCancelPos];//顯示棄牌子圖形
            //if (MJGet == 144) { MJCPX = MJPCX[MJCancelPos] - 60; }
            //MJDIS(MJnum[MJCancelNum], MJPCW, MJPCH, MJCPX, MJCPY, 0);
            //MJPBDIS(0);

        }
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        void MJbmp0clear_distribute(int DistributeNum)
        {
            if (DistributeNum % 2 == 0 && DistributeNum > 1)
            {
                //MJPMPOS++;if(MJPMPOS > 72){MJPMPOS=1;}
                MJPMPOS++; if (MJPMPOS > 72) { MJPMPOS = 72; }
                MJDIS(0, MJPCW, MJPCH, MJPCX[MJPMPOS], MJPCY[MJPMPOS], 0);
                MJPBDIS(0);
            }
        }
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        void MJbmp0clear()
        {
            if (MJGet % 2 == 0 && MJGet > 1)
            {
                //MJPMPOS++;if(MJPMPOS > 72){MJPMPOS=1;}
                MJPMPOS++; if (MJPMPOS > 72) { MJPMPOS = 72; }
                //MJDIS(0, MJPCW, MJPCH, MJPCX[MJPMPOS], MJPCY[MJPMPOS], 0);
                MJDIS(0, MJPCW, MJPCH, MJPCX[MJPMPOS - 1], MJPCY[MJPMPOS - 1], 0);
                MJDIS(52, MJPCW, MJPCH, MJPCX[MJPMPOS], MJPCY[MJPMPOS], 0);
                MJPBDIS(0);
            }
            else
            {
                MJDIS(51, MJPCW, MJPCH, MJPCX[MJPMPOS], MJPCY[MJPMPOS], 0);
                MJPBDIS(0);
            }
        }
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        void MJbmp0dis() //亂數牌顯示
        {
            int x = 0;
            //--------------------------------------------------------
            for (x = 1; x <= 72; x++) { MJDIS(50, MJPCW, MJPCH, MJPCX[x], MJPCY[x], 0); }
            MJPBDIS(0);

            //Graphics g = Graphics.FromImage(MJbmp0);
            //Font GFont = new Font("Arial", 8); // 字型
            //string MJtext = "";
            //for (x = 1; x <= 36; x++)
            //{
            //    for (y = 1; y <= 4; y++)
            //    {
            //        MJtext = MJran[x + (y - 1) * 36].ToString();
            //        float i = (x - 1) * 41;
            //        float j = (y - 1) * 32;
            //        g.DrawString(MJtext, GFont, Brushes.Blue, i, j);//Brushes.Black
            //    }
            //}
            //MJPBDIS(0);
        }
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        void MJdataINIT()
        {
            int x = 0, y = 0, z = 0;
            //	-----------------------------------------------
            for (x = 0; x <= 24; x++) { MJDC[x] = 0; }
            for (z = 0; z <= 4; z++) for (x = 0; x <= 18; x++) { MJP[z, x] = 0; }

            for (z = 0; z <= 4; z++)
            {
                for (y = 0; y <= 10; y++)
                {
                    for (x = 0; x <= 3; x++) { MJPED[z, y, x] = 0; }
                }
            }

            for (z = 0; z <= 4; z++) for (x = 0; x <= 8; x++) { MJPF[z, x] = 0; }

            for (x = 0; x <= 72; x++) { MJPC[x] = 0; }

        }
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        void MJINIT()
        {
            int x = 0, y = 0;
            //	-----------------------------------------------
            for (x = 0; x <= 144; x++) { MJran[x] = 0; }
            for (x = 0; x <= 144; x++) { MJdata[x] = 0; }
            ////for (x = 0; x <= 144; x++) { MJPDL[x] = 0; }
            MJdataINIT();
            //	-----------------------------------------------
            int MJranno = 0, raned = 0;
            Random MJNO = new Random(); //建立亂數物件
            Random position = new Random(); //建立亂數物件
                                            //-------------------------------------------------
            x = 1;
            do
            {
                MJranno = MJNO.Next(144) + 1;//raned=0;
                if (MJranno < 1) { MJranno = 1; }
                if (MJranno > 144) { MJranno = 144; }
                raned = 0;
                for (y = 1; y <= 144; y++) { if (MJran[y] == MJranno) { raned = 1; } }
                for (y = 1; y <= 144; y++)
                {
                    if (MJran[y] == 0 && raned == 0)
                    {
                        MJran[y] = MJranno;
                        //MJPDL[y] = y;
                        raned = 1;
                        x++;
                    }
                }
            } while (x < 145);
            //	-----------------------------------------------
            MJPMPOS = 0;
            MJplayerRan = 0; MJplayer = 1; MJplayerOrder = 0;
            MJGetRan = 0; MJGet = 0;
            MJStartPlayer = 0; MJStartGet = 0;
            MJCancelNum = 0; MJCancelPos = 0; MJPCnum = 0; MJPCtotal = 0; 
            MJGameChange = 0; MJGameOver = 0;
            MJAuto = 0; MJisHU = 0; MJPlayCircleNum = 0;
            MJsupplemented = 0;
            //	-----------------------------------------------
            Graphics g0 = Graphics.FromImage(MJbmp0);//cg.Clear(Color.FromArgb(0,64,0));
            g0.Clear(Color.FromArgb(0, 64, 0)); MJPB0.Image = MJbmp0; MJPB0.Refresh();  //0, 0, 0, 0
            Graphics g1 = Graphics.FromImage(MJbmp1);//bg.Clear(Color.FromArgb(0,64,0));
            g1.Clear(Color.FromArgb(0, 64, 0)); MJPB1.Image = MJbmp1; MJPB1.Refresh();
            Graphics g2 = Graphics.FromImage(MJbmp2);//lg.Clear(Color.FromArgb(0,64,0));
            g2.Clear(Color.FromArgb(0, 64, 0)); MJPB2.Image = MJbmp2; MJPB2.Refresh();
            Graphics g3 = Graphics.FromImage(MJbmp3);//tg.Clear(Color.FromArgb(0,64,0));
            g3.Clear(Color.FromArgb(0, 64, 0)); MJPB3.Image = MJbmp3; MJPB3.Refresh();
            Graphics g4 = Graphics.FromImage(MJbmp4);//rg.Clear(Color.FromArgb(0,64,0));
            g4.Clear(Color.FromArgb(0, 64, 0)); MJPB4.Image = MJbmp4; MJPB4.Refresh();
            //	-----------------------------------------------
            this.MJMPB1.Image = MJ82128.Images[1];
            this.MJMPB2.Image = MJ82128.Images[2];
            this.MJMPB3.Image = MJ82128.Images[3];
            this.MJMPB4.Image = MJ82128.Images[4];
            ////MJOrderNum = 1;
            ////MJPlayDataTextSave();

        }
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        void MJrandomdata() //建立亂數
        {
            Random GONUM = new Random(); //建立亂數物件
            Random PLNUM = new Random(); //建立亂數物件
            MJGetRan = GONUM.Next(72) + 1;
            MJStartPlayer = PLNUM.Next(4) + 1; ;
            if (MJStartPlayer < 1) { MJStartPlayer = 4; }
            if (MJStartPlayer > 4) { MJStartPlayer = 1; }
            MJplayer = MJStartPlayer;
            MJPMPOS = 0; MJCancelPos = MJPMPOS;
            if (MJCancelPos > 72) { MJCancelPos = 72; }
            //-----------------------------------------------			
            //MJGetRan=PLRN.Next(18)+1;
            //MJplayerRan=(MJGetRan/4)+1;
            //MJStartPlayer=MJplayerRan;
            //x=(Player-1)*18+LastGos;//MJStartGet=(MJStartPlayer-1)*18+MJGetRan-1;
            //MJPMPOS=MJGetRan;//MJCancelPos=MJPMPOS+1;
            //if(MJCancelPos>72){MJCancelPos=1;}
            //MJDIS(57,MJPMW,MJPMH,MJPMX[MJPMPOS],MJPMY[MJPMPOS],0);
            //MJDIS(53,MJPMW,MJPMH,MJPMX[MJPMPOS],MJPMY[MJPMPOS],0);
            //GoYes=0; GetOrder=1; GoSum=2;	Gos=LastGos+1;
            //if(Gos>18){Gos=1; GoRow++;if(GoRow>4){GoRow=1;}}
            //GoRow=MJplayer;
            //MJGet=MJStartGet+1;
            //MJGet=MJStartGet*2;
            //if(MJGet>18){MJGet=1; GoRow++;	if(GoRow>4){GoRow=1;}}
            //-----------------------------------------------			
        }
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        void MJdistribute() //分牌 distribute
        {
            int p = 0, x = 0, dx = 0;
            //int Geted = 0;
            //-------------------------------------------------------
            //玩家1-4 依序一次領16張牌 記錄在未處理資料區
            //for (p = 1; p <= 4; p++)
            //{//p=1;p<=4;p++
            //    for (x = 1; x <= 16; x++)
            //    {
            //        //Geted = 0;
            //        //if (MJP[p, x] == 0 && Geted == 0)
            //        if (MJP[p, x] == 0)
            //        {
            //            MJP[p, x] = MJran[MJGet];//記錄在未處理資料區
            //            //MJPDL[MJGet] = p * 1000 + 100 + x;//記錄在牌資料清單陣列
            //                                              //MJGet++;//if(MJGet>144){MJGet=1;}Geted=1;MJbmp0clear();
            //            //Geted = 1;
            //            MJGet++;
            //        }
            //    }
            //    //Player++;if(Player > 4){Player=1;}
            //}//p=1;p<=4;p++

            MJP[1, 1] = MJran[1]; MJdata[MJran[1]] = 1001000 + MJran[1];
            MJP[1, 2] = MJran[2]; MJdata[MJran[2]] = 1002000 + MJran[2];
            MJP[1, 3] = MJran[3]; MJdata[MJran[3]] = 1003000 + MJran[3];
            MJP[1, 4] = MJran[4]; MJdata[MJran[4]] = 1004000 + MJran[4];
            MJP[1, 5] = MJran[5]; MJdata[MJran[5]] = 1005000 + MJran[5];
            MJP[1, 6] = MJran[6]; MJdata[MJran[6]] = 1006000 + MJran[6];
            MJP[1, 7] = MJran[7]; MJdata[MJran[7]] = 1007000 + MJran[7];
            MJP[1, 8] = MJran[8]; MJdata[MJran[8]] = 1008000 + MJran[8];
            MJP[1, 9] = MJran[9]; MJdata[MJran[9]] = 1009000 + MJran[9];
            MJP[1, 10] = MJran[10]; MJdata[MJran[10]] = 1010000 + MJran[10];
            MJP[1, 11] = MJran[11]; MJdata[MJran[11]] = 1011000 + MJran[11];
            MJP[1, 12] = MJran[12]; MJdata[MJran[12]] = 1012000 + MJran[12];
            MJP[1, 13] = MJran[13]; MJdata[MJran[13]] = 1013000 + MJran[13];
            MJP[1, 14] = MJran[14]; MJdata[MJran[14]] = 1014000 + MJran[14];
            MJP[1, 15] = MJran[15]; MJdata[MJran[15]] = 1015000 + MJran[15];
            MJP[1, 16] = MJran[16]; MJdata[MJran[16]] = 1016000 + MJran[16];

            MJP[2, 1] = MJran[17]; MJdata[MJran[17]] = 2001000 + MJran[17];
            MJP[2, 2] = MJran[18]; MJdata[MJran[18]] = 2002000 + MJran[18];
            MJP[2, 3] = MJran[19]; MJdata[MJran[19]] = 2003000 + MJran[19];
            MJP[2, 4] = MJran[20]; MJdata[MJran[20]] = 2004000 + MJran[20];
            MJP[2, 5] = MJran[21]; MJdata[MJran[21]] = 2005000 + MJran[21];
            MJP[2, 6] = MJran[22]; MJdata[MJran[22]] = 2006000 + MJran[22];
            MJP[2, 7] = MJran[23]; MJdata[MJran[23]] = 2007000 + MJran[23];
            MJP[2, 8] = MJran[24]; MJdata[MJran[24]] = 2008000 + MJran[24];
            MJP[2, 9] = MJran[25]; MJdata[MJran[25]] = 2009000 + MJran[25];
            MJP[2, 10] = MJran[26]; MJdata[MJran[26]] = 2010000 + MJran[26];
            MJP[2, 11] = MJran[27]; MJdata[MJran[27]] = 2011000 + MJran[27];
            MJP[2, 12] = MJran[28]; MJdata[MJran[28]] = 2012000 + MJran[28];
            MJP[2, 13] = MJran[29]; MJdata[MJran[29]] = 2013000 + MJran[29];
            MJP[2, 14] = MJran[30]; MJdata[MJran[30]] = 2014000 + MJran[30];
            MJP[2, 15] = MJran[31]; MJdata[MJran[31]] = 2015000 + MJran[31];
            MJP[2, 16] = MJran[32]; MJdata[MJran[32]] = 2016000 + MJran[32];

            MJP[3, 1] = MJran[33]; MJdata[MJran[33]] = 3001000 + MJran[33];
            MJP[3, 2] = MJran[34]; MJdata[MJran[34]] = 3002000 + MJran[34];
            MJP[3, 3] = MJran[35]; MJdata[MJran[35]] = 3003000 + MJran[35];
            MJP[3, 4] = MJran[36]; MJdata[MJran[36]] = 3004000 + MJran[36];
            MJP[3, 5] = MJran[37]; MJdata[MJran[37]] = 3005000 + MJran[37];
            MJP[3, 6] = MJran[38]; MJdata[MJran[38]] = 3006000 + MJran[38];
            MJP[3, 7] = MJran[39]; MJdata[MJran[39]] = 3007000 + MJran[39];
            MJP[3, 8] = MJran[40]; MJdata[MJran[40]] = 3008000 + MJran[40];
            MJP[3, 9] = MJran[41]; MJdata[MJran[41]] = 3009000 + MJran[41];
            MJP[3, 10] = MJran[42]; MJdata[MJran[42]] = 3010000 + MJran[42];
            MJP[3, 11] = MJran[43]; MJdata[MJran[43]] = 3011000 + MJran[43];
            MJP[3, 12] = MJran[44]; MJdata[MJran[44]] = 3012000 + MJran[44];
            MJP[3, 13] = MJran[45]; MJdata[MJran[45]] = 3013000 + MJran[45];
            MJP[3, 14] = MJran[46]; MJdata[MJran[46]] = 3014000 + MJran[46];
            MJP[3, 15] = MJran[47]; MJdata[MJran[47]] = 3015000 + MJran[47];
            MJP[3, 16] = MJran[48]; MJdata[MJran[48]] = 3016000 + MJran[48];

            MJP[4, 1] = MJran[49]; MJdata[MJran[49]] = 4001000 + MJran[49];
            MJP[4, 2] = MJran[50]; MJdata[MJran[50]] = 4002000 + MJran[50];
            MJP[4, 3] = MJran[51]; MJdata[MJran[51]] = 4003000 + MJran[51];
            MJP[4, 4] = MJran[52]; MJdata[MJran[52]] = 4004000 + MJran[52];
            MJP[4, 5] = MJran[53]; MJdata[MJran[53]] = 4005000 + MJran[53];
            MJP[4, 6] = MJran[54]; MJdata[MJran[54]] = 4006000 + MJran[54];
            MJP[4, 7] = MJran[55]; MJdata[MJran[55]] = 4007000 + MJran[55];
            MJP[4, 8] = MJran[56]; MJdata[MJran[56]] = 4008000 + MJran[56];
            MJP[4, 9] = MJran[57]; MJdata[MJran[57]] = 4009000 + MJran[57];
            MJP[4, 10] = MJran[58]; MJdata[MJran[58]] = 4010000 + MJran[58];
            MJP[4, 11] = MJran[59]; MJdata[MJran[59]] = 4011000 + MJran[59];
            MJP[4, 12] = MJran[60]; MJdata[MJran[60]] = 4012000 + MJran[60];
            MJP[4, 13] = MJran[61]; MJdata[MJran[61]] = 4013000 + MJran[61];
            MJP[4, 14] = MJran[62]; MJdata[MJran[62]] = 4014000 + MJran[62];
            MJP[4, 15] = MJran[63]; MJdata[MJran[63]] = 4015000 + MJran[63];
            MJP[4, 16] = MJran[64]; MJdata[MJran[64]] = 4016000 + MJran[64];

            MJGet = 65;

            //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
            //顯示發牌圖形動作
            for (x = 0; x < 4; x++)
            {
                for (p = 1; p <= 4; p++)
                {
                    for (dx = 1; dx <= 4; dx++)
                    {
                        //MJDIS(51, MJPW, MJPH, MJPX[x * 4 + dx], MJPY[x * 4 + dx], p);  //51
                        ////MJbmp0clear();
                        MJbmp0clear_distribute(x * 4 + dx);
                        MJPBDIS(p);
                    }
                    //MJPBDIS(p);
                }
            }
            //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*


            //Graphics g = Graphics.FromImage(MJbmp1);
            //Font GFont = new Font("Arial", 16); // 字型
            //string MJBUTTOMmtext = "$999999";
            //SizeF stringSize11 = g.MeasureString(MJBUTTOMmtext, GFont); // 文字字串的寬高;
            //float X11 = 200; // 左上角的座標
            //float Y11 = 50;
            //g.DrawString(MJBUTTOMmtext, GFont, Brushes.Peru, X11, Y11);//Brushes.Black

            //MJDIS(22, MJPW, MJPH,MJPX[5], MJPY[5], 1);
            //MJPBDIS(1);//重繪玩者牌區

            //for (p = 1; p <= 4; p++)
            //{
            //for (x = 1; x <= 16; x++)
            //{
            //    //MJDIS(MJnum[MJP[p, x]], MJPW, MJPH, MJPX[x], MJPY[x], p);
            //    MJDIS(MJnum[MJP[4, x]], MJPW, MJPH,MJPX[x], MJPY[x], 4);
            //    MJPBDIS(4);//重繪玩者牌區
            //}
            //}
            //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

            MJdistributed = 1;
            TEXTBOXDIS("分牌完成." + "  ");
            //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        }
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //arrange
        void 
            MJarrange() //理牌 arrange
        {
            int x = 0, y = 0; int px = 0, pnum = 0, player = 1;
            //--------------------------------------------------------
            for (player = 1; player <= 4; player++)
            {
                pnum = 16; //if (player == MJplayer) { pnum = 17; }
                for (x = 1; x <= pnum; x++) { MJDC[x] = 0; }
                for (x = 1; x <= pnum; x++)
                {
                    px = 0;
                    for (y = 1; y <= pnum; y++) { if (MJP[player, x] >= MJP[player, y]) { px++; } }
                    MJDC[px] = MJP[player, x];
                }
                for (x = 1; x <= pnum; x++) { MJP[player, x] = 0; }
                for (x = 1; x <= pnum; x++) { MJP[player, x] = MJDC[x]; }
                //for (x = 1; x <= pnum; x++) { MJDIS(MJnum[MJP[player, x]], MJPW, MJPH, MJPX[x], MJPY[x], player); }
                //MJPBDIS(player);
            }
        }
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //MJDIS(int mjicontype,int mjw,int mjh,int mjddx,int mjddy,int mjdisrect)
        void MJarrangeone() //理牌 arrange
        {
            int x = 0, y = 0; int px = 0;
            //-------------------------------------------------------
            for (x = 1; x <= 17; x++) { MJDC[x] = 0; }//資料轉換區歸0
            for (x = 1; x <= 17; x++)
            {
                //將第1列資料排列設至資料轉換區
                px = 0;
                for (y = 1; y <= 17; y++) { if (MJP[MJplayer, x] >= MJP[MJplayer, y]) { px++; } }
                MJDC[px] = MJP[MJplayer, x];
            }
            for (x = 1; x <= 17; x++) { MJP[MJplayer, x] = 0; }//將第1列資料歸0
            for (x = 1; x <= 17; x++) { MJP[MJplayer, x] = MJDC[x]; }//將資料轉換區資料重新設至第1列資料
                                                                     //重新繪製第1列1-16牌子
                                                                     //for (x = 1; x <= 16; x++)//{MJDIS(MJnum[MJPD[MJplayer,1,x]],MJBW,MJBH,MJPDBX[x],MJPDBY[x],MJplayer);}
                                                                     //{
                                                                     //    if (MJplayer > 1)
                                                                     //    {
                                                                     //        //MJDIS(51, MJPW, MJPH, MJPX[x], MJPY[x], MJplayer);
                                                                     //        MJDIS(MJnum[MJP[MJplayer, x]], MJPW, MJPH, MJPX[x], MJPY[x], MJplayer);
                                                                     //        MJdisTEXT = MJP[MJplayer, x].ToString();
                                                                     //        MJDIS(0, MJPW, MJPH, MJPX[x] + 5, MJPY[x] + 5, 900 + MJplayer);
                                                                     //        MJdisTEXT = MJnum[MJP[MJplayer, x]].ToString();
                                                                     //        MJDIS(0, MJPW, MJPH, MJPX[x] + 50, MJPY[x] + 5, 900 + MJplayer);
                                                                     //    }
                                                                     //    else
                                                                     //    { MJDIS(MJnum[MJP[MJplayer, x]], MJPW, MJPH, MJPX[x], MJPY[x], MJplayer); }
                                                                     //}
                                                                     //MJP[MJplayer, 17] = 0;//將第1列第17牌子歸0
                                                                     //MJDIS(MJnum[MJP[MJplayer,17]],0,0,0,0,200+MJplayer);
                                                                     //MJPBDIS(MJplayer);//重新顯示第MJplayer牌區
        }
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        void MJsupplement() //補牌 supplement
        {
            int c, d; int Geted = 0, player = 0, pnum = 0;
            //-----------------------------------------------
            MJsupplemented = 0;
            for (player = 1; player <= 4; player++)
            {
                pnum = 16; //if (player == MJplayer) { pnum = 17; }
                for (d = 1; d <= pnum; d++)
                {
                    Geted = 0;
                    if (MJnum[MJP[player, d]] > 40)
                    {//---------------------------
                        for (c = 1; c <= 8; c++)//for(c=1;c<=pnum;c++)
                        {
                            if (MJPF[player, c] == 0 && Geted == 0)//if(MJPD[player,2,c]==0 && Geted==0)
                            {
                                MJGet++; if (MJGet > 144) { MJGet = 1; }
                                MJPF[player, c] = MJP[player, d]; MJDIS(MJnum[MJPF[player, c]], MJPFW, MJPFH, MJPFX[c], MJPFY[c], player); Geted = 1;
                                MJP[player, d] = 0; MJDIS(0, MJPW, MJPH, MJPX[d], MJPY[d], player);
                                MJsupplemented = 1;
                                MJP[player, d] = MJran[MJGet]; MJDIS(MJnum[MJP[player, d]], MJPW, MJPH, MJPX[d], MJPY[d], player);
                                Geted = 1; 
                                //MJbmp0clear();//MJGet++;if(MJGet>144){MJGet=1;}Geted=1;MJbmp0clear();
                            }
                        }
                    }//---------------------------
                }
                MJPBDIS(player);
            }
        }
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        void MJsupplementone() //補牌 supplement
        {
            MJPF[MJplayer, 0]++;//玩者第2列花牌列花牌數量+1
            MJPF[MJplayer, MJPF[MJplayer, 0]] = MJP[MJplayer, 17];//將第1列第17位置花牌設定給第2列花牌列
                                                                  //繪製第2列花牌列新增花牌
            MJDIS(MJnum[MJPF[MJplayer, MJPF[MJplayer, 0]]],
                  MJPFW, MJPFH, MJPFX[MJPF[MJplayer, 0]], MJPFY[MJPF[MJplayer, 0]], MJplayer);
            MJP[MJplayer, 17] = 0;//將第1列第17位置數值歸0
            MJDIS(0, MJPW, MJPH, MJPX[17], MJPY[17], MJplayer);//刪除第1列第17位置圖形
            MJsupplemented = 0;//補牌動作未結束

            //MJsupplemented=1;
            //MJPD[MJplayer,1,17]=MJran[MJGet];
            //MJDIS(MJnum[MJPD[MJplayer,1,17]],MJBW,MJBH,MJPDBX[17],MJPDBY[17],MJplayer);
            //MJbmp0clear();

            MJPBDIS(MJplayer);//重繪玩者牌區

        }
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        void PUN()
        {
            int x = 0;
            int same1 = 0, same2 = 0, same3 = 0, same4 = 0;
            int isPUN = 0, PUNed = 0; ;
            //--------------------------------------
            int MJCN = MJCancelNum;

            for (x = 1; x <= 16; x++) { if (MJP[1, x] == MJCN) { same1++; } }
            for (x = 1; x <= 16; x++) { if (MJP[2, x] == MJCN) { same2++; } }
            for (x = 1; x <= 16; x++) { if (MJP[3, x] == MJCN) { same3++; } }
            for (x = 1; x <= 16; x++) { if (MJP[4, x] == MJCN) { same4++; } }


            if (same1 == 2 && PUNed == 0)
            {
                MJMSG1.Image = MJ6464.Images[2]; MJMSG1.Refresh();
                Thread.Sleep(2000); //Delay 2秒
                MJPed(1,3,MJCN,MJCN,MJCN);
                for (x = 1; x <= 16; x++)
                {
                    if (MJP[1, x] == MJCN)
                    {
                        MJP[1, x] = 0;
                    }
                }
                MJarrange();
                isPUN = 1;
                PUNed = 1;
            }
            if (same2 == 2 && PUNed == 0)
            {
                MJMSG2.Image = MJ6464.Images[2]; MJMSG2.Refresh();
                Thread.Sleep(2000); //Delay 2秒
                MJPed(2, 3, MJCN, MJCN, MJCN);
                for (x = 1; x <= 16; x++)
                {
                    if (MJP[2, x] == MJCN)
                    {
                        MJP[2, x] = 0;
                    }
                }
                MJarrange();
                isPUN = 2;
                PUNed = 1;
            }
            if (same3 == 2 && PUNed == 0)
            {
                MJMSG3.Image = MJ6464.Images[2]; MJMSG3.Refresh();
                Thread.Sleep(2000); //Delay 2秒
                MJPed(3, 3, MJCN, MJCN, MJCN);
                for (x = 1; x <= 16; x++)
                {
                    if (MJP[3, x] == MJCN)
                    {
                        MJP[3, x] = 0;
                    }
                }
                MJarrange();
                isPUN = 3;
                PUNed = 1;
            }
            if (same4 == 2 && PUNed == 0)
            {
                MJMSG4.Image = MJ6464.Images[2]; MJMSG4.Refresh();
                Thread.Sleep(2000); //Delay 2秒
                MJPed(4, 3, MJCN, MJCN, MJCN);
                for (x = 1; x <= 16; x++)
                {
                    if (MJP[4, x] == MJCN)
                    {
                        MJP[4, x] = 0;
                    }
                }
                MJarrange();
                isPUN = 4;
                PUNed = 1;
            }

            if (PUNed == 1)
            {
                MJdataDIS(isPUN);
            }
        }
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        void GAN()
        {
            int x = 0;
            int[] AR = new int[17] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] MJgan0 = new int[17] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] MJgan = new int[17] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            //-----------------------------------------

            AR[1] = MJP[MJplayer, 1];
            AR[2] = MJP[MJplayer, 2];
            AR[3] = MJP[MJplayer, 3];
            AR[4] = MJP[MJplayer, 4];
            AR[5] = MJP[MJplayer, 5];
            AR[6] = MJP[MJplayer, 6];
            AR[7] = MJP[MJplayer, 7];
            AR[8] = MJP[MJplayer, 8];
            AR[9] = MJP[MJplayer, 9];
            AR[10] = MJP[MJplayer, 10];
            AR[11] = MJP[MJplayer, 11];
            AR[12] = MJP[MJplayer, 12];
            AR[13] = MJP[MJplayer, 13];
            AR[14] = MJP[MJplayer, 14];
            AR[15] = MJP[MJplayer, 15];
            AR[16] = MJP[MJplayer, 16];


            //去掉数组中重复的项
            //先排序

            arrayAsc(AR);

            List<int> list = AR.ToList();

            AR[16] = list[16];

            for(x=0;x<=16;x++)
            {
                for (int i = x; i < list.Count - 1; i++)
                {
                    if (list[i] == list[i + 1] && i < (list.Count - 1))
                        list.RemoveAt(i + 1);
                    if (list[i] == list[i + 2] && i < (list.Count - 1))
                        list.RemoveAt(i + 2);
                    if (list[i] == list[i + 3] && i < (list.Count - 1))
                        list.RemoveAt(i + 3);
                    if (list[i] == list[i + 4] && i < (list.Count - 1))
                        list.RemoveAt(i + 4);
                }
            }

            MJgan0 = list.ToArray();

            for(int xx = 1;xx < MJgan0.Length-1;xx++)
            {
                for(int yy = 1;yy < AR.Length-1;yy++)
                {
                    if(AR[yy] == MJgan0[xx])
                    {
                        MJgan[xx]++;
                    }
                }
            }


        }

        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //---------------------------------------------------------------------
        private static void arrayAsc(int[] array)
        {
            int i, j, temp;
            for (i = 0; i < array.Length - 1; i++)
            {
                for (j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

        }
        //---------------------------------------------------------------------
        static void quickSort(int[] arrays, int low, int high)
        {
            // 樞紐元,一般以第一個元素為基準進行劃分 
            int i = low;
            int j = high;
            if (low < high)
            {
                // 從陣列兩端交替地向中間掃描 
                int key = arrays[low];
                // 進行掃描的指標i,j;i從左邊開始,j從右邊開始 
                while (i < j)
                {
                    while (i < j && arrays[j] > key) 
                    {
                        j--;
                    }// end while 
                    if (i < j)
                    {
                        // 比樞紐元素小的移動到左邊 
                        arrays[i] = arrays[j];
                        i++;
                    }// end if 
                    while (i < j && arrays[i] < key) 
                    {
                        i++;
                    }// end while 
                    if (i < j)
                    {
                        // 比樞紐元素大的移動到右邊 
                        arrays[j] = arrays[i];
                        j--;
                    }// end if 
                }// end while 
                // 樞紐元素移動到正確位置 
                arrays[i] = key;
                // 前半個子表遞迴排序 
                quickSort(arrays, low, i - 1);
                // 後半個子表遞迴排序 
                quickSort(arrays, i + 1, high);
            }// end if  
        }
        //---------------------------------------------------------------------


        private static void QuickSort(int[] arr, int begin, int end)
        {
            if (begin >= end) return;   //两个指针重合就返回，结束调用
            int pivotIndex = QuickSort_Once(arr, begin, end);  //会得到一个基准值下标

            QuickSort(arr, begin, pivotIndex - 1);  //对基准的左端进行排序  递归
            QuickSort(arr, pivotIndex + 1, end);   //对基准的右端进行排序  递归
        }

        private static int QuickSort_Once(int[] arr, int begin, int end)
        {
            int pivot = arr[begin];   //将首元素作为基准
            int i = begin;
            int j = end;
            while (i < j)
            {
                while (arr[j] >= pivot && i < j)  //从右到左，寻找第一个小于基准pivot的元素
                {
                    j--; //指针向前移
                }
                arr[i] = arr[j];  //执行到此，j已指向从右端起第一个小于基准pivot的元素，执行替换


                while (arr[i] <= pivot && i < j) //从左到右，寻找首个大于基准pivot的元素
                {
                    i++; //指针向后移
                }
                arr[j] = arr[i];  //执行到此,i已指向从左端起首个大于基准pivot的元素，执行替换
            }

            //退出while循环,执行至此，必定是 i= j的情况（最后两个指针会碰头）
            //i(或j)所指向的既是基准位置，定位该趟的基准并将该基准位置返回
            arr[i] = pivot;
            return i;
        }





        class ObjectOriented
        {
            static Random random = new Random();
            public static void Sort(int[] array)
            {
                Sort(array.ToList()).ToArray().CopyTo(array, 0);
            }

            public static List<int> Sort(List<int> list)
            {
                if (list.Count < 2)
                    return list;

                // random pivot
                //int pivot = list[random.Next(list.Count - 1)];

                // middle pivot
                int pivot = list[list.Count / 2];
                list.RemoveAt(list.Count / 2);
                List<int> less = new List<int>();
                List<int> greater = new List<int>();
                List<int> result = new List<int>();
                foreach (int n in list)
                {
                    if (n > pivot)
                        greater.Add(n);
                    else
                        less.Add(n);
                }
                result.AddRange(Sort(less));
                result.Add(pivot);
                result.AddRange(Sort(greater));
                return result;
            }
        }





        static void QuickSort(ref List<int> nums, int left, int right)
        {
            if (left < right)
            {
                int i = left;
                int j = right;
                int middle = nums[(left + right) / 2];
                while (true)
                {
                    while (i < right && nums[i] < middle) { i++; };
                    while (j > 0 && nums[j] > middle) { j--; };
                    if (i == j) break;
                    int temp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = temp;
                    if (nums[i] == nums[j]) j--;
                }
                QuickSort(ref nums, left, i);
                QuickSort(ref nums, i + 1, right);
            }
        }




        void test()
        {
            //产生随机数

            int[] array = new int[100000];

            for (int i = 0; i <= 99999; i++)
            {
                if (i == 0)
                    array[i] = (new Random()).Next(1000);
                else
                    array[i] = (new Random(array[i - 1])).Next(1000);

            }

            QuickSort(ref array, 0, array.Length - 1);

            foreach (int i in array)
                Console.Write(i.ToString() + " ");

            Console.ReadLine();
        }

        static void QuickSort(ref int[] array, int start, int end)

        {

            if (start == end - 1)
                return;

            if (start >= end)
                return;

            int i = 0, j = 0, k = 0, x = start, z = array[x];

            i = start;
            j = end;

            while (i < j)
            {

                while (array[j] >= z && j > i) j--;

                if (i < j) array[i] = array[j];

                while (array[i] <= z && j > i) i++;

                if (i < j) array[j] = array[i];

            }

            array[i] = z;

            QuickSort(ref array, start, i - 1);
            QuickSort(ref array, i + 1, end);

        }



        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        void MJPed(int z,int CPG,int x1,int x2,int x3)
        {
            MJPED[z, 0, 0]++;
            MJPED[z, MJPED[z, 0, 0], 0] = CPG;
            MJPED[z, MJPED[z, 0, 0], 1] = x1;
            MJPED[z, MJPED[z, 0, 0], 2] = x2;
            MJPED[z, MJPED[z, 0, 0], 3] = x3;
        }
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        void MJdataRead()
        {
            // xx:牌編號  aa:牌方法  bb:牌位置順序  range:牌資料範圍    
            // MJP: 1~4  1012095  1000000~1099999  xx:95  aa:0  bb:12  range:1
            // MJPED: 10~40  1301095  1100000~1999999  xx:95  aa:3  bb:1  range:10
            // MJPC: 5  5027095  5000000~5999999  xx:95  aa:0  bb:27  range:5
            // MJPF: 8  8203095  8000000~8999999  xx:95  aa:2  bb:3  range:8
            //--------------------------------------
            int x = 0;

            MJdataINIT();
            //--------------------------------------
            for(x=1;x<=144;x++)
            {
                // xx:牌編號  aa:牌方法  bb:牌位置順序  range:牌資料範圍    
                // MJP: 1~4  1012095  1000000~1099999  xx:95  aa:0  bb:12  range:1
                if (MJdata[x]>1000000 && MJdata[x]<1050999)
                {
                    int xx = 1;
                    int yy = (MJdata[x] - 1000000) / 1000;
                    int zz = MJdata[x] % 1000;
                    MJP[xx, yy] = zz;
                }
                if (MJdata[x] > 2000000 && MJdata[x] < 2050999)
                {
                    int xx = 2;
                    int yy = (MJdata[x] - 2000000) / 1000;
                    int zz = MJdata[x] % 1000;
                    MJP[xx, yy] = zz;
                }
                if (MJdata[x] > 3000000 && MJdata[x] < 3050999)
                {
                    int xx = 3;
                    int yy = (MJdata[x] - 3000000) / 1000;
                    int zz = MJdata[x] % 1000;
                    MJP[xx, yy] = zz;
                }
                if (MJdata[x] > 4000000 && MJdata[x] < 4050999)
                {
                    int xx = 4;
                    int yy = (MJdata[x] - 4000000) / 1000;
                    int zz = MJdata[x] % 1000;
                    MJP[xx, yy] = zz;
                }

                // xx:牌編號  aa:牌方法  bb:牌位置順序  range:牌資料範圍    
                // MJPED: 10~40  1351095  1100000~1999999  xx:95  yy:5  zz:1  aa:3  range:10
                if (MJdata[x] > 1050999 && MJdata[x] < 1999999)
                {
                    int xx = 1;
                    int yy = (MJdata[x] - 1000000) % 100000 / 1000 / 10;
                    int zz = (MJdata[x] - 1000000) % 100000 / 1000 % 10;  //牌順序
                    int aa = (MJdata[x] - 1000000) / 100000;  //牌方法
                    MJPED[xx, yy, 0] = aa;
                    MJPED[xx, yy, zz] = MJdata[x] % 1000;
                }
                if (MJdata[x] > 2050999 && MJdata[x] < 2999999)
                {
                    int xx = 2;
                    int yy = (MJdata[x] - 2000000) % 100000 / 1000 / 10;
                    int zz = (MJdata[x] - 2000000) % 100000 / 1000 % 10;  //牌順序
                    int aa = (MJdata[x] - 2000000) / 100000;  //牌方法
                    MJPED[xx, yy, 0] = zz;
                    MJPED[xx, yy, aa] = MJdata[x] % 1000;
                }
                if (MJdata[x] > 3050999 && MJdata[x] < 3999999)
                {
                    int xx = 3;
                    int yy = (MJdata[x] - 3000000) % 100000 / 1000 / 10;
                    int zz = (MJdata[x] - 3000000) % 100000 / 1000 % 10;  //牌順序
                    int aa = (MJdata[x] - 3000000) / 100000;  //牌方法
                    MJPED[xx, yy, 0] = zz;
                    MJPED[xx, yy, aa] = MJdata[x] % 1000;
                }
                if (MJdata[x] > 4050999 && MJdata[x] < 4999999)
                {
                    int xx = 4;
                    int yy = (MJdata[x] - 4000000) % 100000 / 1000 / 10;
                    int zz = (MJdata[x] - 4000000) % 100000 / 1000 % 10;  //牌順序
                    int aa = (MJdata[x] - 4000000) / 100000;  //牌方法
                    MJPED[xx, yy, 0] = zz;
                    MJPED[xx, yy, aa] = MJdata[x] % 1000;
                }

                // xx:牌編號  aa:牌方法  bb:牌位置順序  range:牌資料範圍    
                // MJPC: 5  5027095  5000000~5999999  xx:95  aa:0  bb:27  range:5
                if (MJdata[x] > 5000000 && MJdata[x] < 5999999)
                {
                    int xx = (MJdata[x] - 5000000) / 1000;
                    int zz = MJdata[x] % 1000;
                    MJPC[xx] = zz;
                }

                // xx:牌編號  aa:牌方法  bb:牌位置順序  range:牌資料範圍    
                // MJPF: 8  8203095  8000000~8999999  xx:95  aa:2  bb:3  cc:0  range:8
                if (MJdata[x] > 8000000 && MJdata[x] < 8999999)
                {
                    int xx = (MJdata[x] - 8000000) / 100000;
                    int yy = (MJdata[x] - 8000000) / 1000 % 100;
                    int zz = MJdata[x] % 1000;
                    MJPF[xx,yy] = zz;
                    //MessageBox.Show("MJPF Read ---> MJPF[" + xx.ToString() + ";" + yy.ToString() + "] = " + zz.ToString());
                    //TEXTBOXDIS("MJPF Read ---> MJPF[" + xx.ToString() + ";" + yy.ToString() + "] = " + zz.ToString());
                    //Thread.Sleep(3000);
                }


            }


        }
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        void MJdataWriteAll()
        {
            // xx:牌編號  aa:牌方法  bb:牌位置順序  range:牌資料範圍    
            // MJP: 1~4  1012095  1000000~1099999  xx:95  aa:0  bb:12  range:1
            // MJPED: 10~40  1301095  1100000~1999999  xx:95  aa:3  bb:1  range:10
            // MJPC: 5  5027095  5000000~5999999  xx:95  aa:0  bb:27  range:5
            // MJPF: 8  8203095  8000000~8999999  xx:95  aa:2  bb:3  range:8
            //--------------------------------------
            int x = 0, y = 0, z = 0, p = 0;
            //--------------------------------------
            // xx:牌編號  aa:牌方法  bb:牌位置順序1  cc:牌位置順序2  range:牌資料範圍    
            // MJP: 1~4  1012095  1000000~1099999  xx:95  aa:0  bb:12  cc:0  range:1
            for (p=1;p<=4;p++)  //登錄 MJP
            {
                for(x=1;x<=16;x++)
                {
                    MJdataWrite(MJP[p,x], 0, x, 0, p);
                }
            }

            // xx:牌編號  aa:牌方法  bb:牌位置順序1  cc:牌位置順序2  range:牌資料範圍    
            // MJPED: 10~40  1351095  1100000~1999999  xx:95  aa:3  bb:5  cc:1  range:10
            for (p=1;p<=4;p++)
            {
                for(y=1;y<=9;y++)
                {
                    for(z=1;z<=3;z++)
                    {
                        if (MJPED[p, y, 0] == 3)
                        {
                            MJdataWrite(MJPED[p, y, z], 3, y, z, p * 10);
                        }
                        if (MJPED[p, y, 0] == 4)
                        {
                            MJdataWrite(MJPED[p, y, z], 4, y, z, p * 10);
                        }
                        if (MJPED[p, y, 0] == 5)
                        {
                            MJdataWrite(MJPED[p, y, z], 5, y, z, p * 10);
                        }
                    }
                }
            }

            // xx:牌編號  aa:牌方法  bb:牌位置順序  range:牌資料範圍    
            // MJPC: 5  5027095  5000000~5999999  xx:95  aa:0  bb:27  cc:0  range:5
            for (x = 1; x <= 72; x++)
            {
                if(MJPC[x] > 0)
                {
                    MJdataWrite(MJPC[x], 0, x, 0, 5);
                }
            }

            // xx:牌編號  aa:牌方法  bb:牌位置順序  range:牌資料範圍    
            // MJPF: 8  8203095  8000000~8999999  xx:95  aa:2  bb:3  cc:0  range:8
            for (p = 1; p <= 4; p++)
            {
                for(x=1;x<=8;x++)
                {
                    if (MJPF[p,x] > 0)
                    {
                        MJdataWrite(MJPF[p,x], p, x, 0, 8);
                    }
                }
            }

        }
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        void MJdataWrite(int xx,int aa,int bb,int cc,int range)
        {

            //--------------------------------------
            // xx:牌編號  aa:牌方法  bb:牌位置順序  range:牌資料範圍    
            // MJP: 1~4  1012095  1000000~1099999  xx:95  aa:0  bb:12  range:1
            // MJPED: 10~40  1301095  1100000~1999999  xx:95  aa:3  bb:1  range:10
            // MJPC: 5  5027095  5000000~5999999  xx:95  aa:0  bb:27  range:5
            // MJPF: 8  8203095  8000000~8999999  xx:95  aa:2  bb:3  range:8

            switch (range)
            {
                // MJP: 1~4  1012095  1000000~1099999  xx:95  aa:0  bb:12  range:1
                case 1:
                    MJdata[xx] = 1000000 + 1000 * bb + xx;
                    break;
                case 2:
                    MJdata[xx] = 2000000 + 1000 * bb + xx;
                    break;
                case 3:
                    MJdata[xx] = 3000000 + 1000 * bb + xx;
                    break;
                case 4:
                    MJdata[xx] = 4000000 + 1000 * bb + xx;
                    break;

                // MJPED: 10~40  1351095  1100000~1999999  xx:95  aa:3  bb:5  cc:1  range:10
                case 10:
                    MJdata[xx] = 1000000 + 100000 * aa + 10000 * bb + 1000 * cc + xx;
                    break;
                case 20:
                    MJdata[xx] = 2000000 + 100000 * aa + 10000 * bb + 1000 * cc + xx;
                    break;
                case 30:
                    MJdata[xx] = 3000000 + 100000 * aa + 10000 * bb + 1000 * cc + xx;
                    break;
                case 40:
                    MJdata[xx] = 4000000 + 100000 * aa + 10000 * bb + 1000 * cc + xx;
                    break;

                // MJPC: 5  5027095  5000000~5999999  xx:95  aa:0  bb:27  cc:0  range:5
                case 5:
                    MJdata[xx] = 5000000 + 1000 * bb + xx;
                    break;

                // xx:牌編號  aa:牌方法  bb:牌位置順序  range:牌資料範圍    
                // MJPF: 8  8203095  8000000~8999999  xx:95  aa:2  bb:3  cc:0  range:8
                //MJdataWrite(MJPF[p,x], p, x, 0, 8);
                case 8:
                    MJdata[xx] = 8000000 + 100000 * aa + 1000 * bb + xx;
                    //MessageBox.Show("MJdata[" + xx.ToString() + "] = " + MJdata[xx].ToString());
                    //Thread.Sleep(20000);
                    break;

                default:
                    break;
            }


        }
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        void MJMSGLBDIS(string TBD)//GOMSGLB
        {
            string STR = "";
            string STRTRIM = "";
            STR = TBD;
            if ((TEXTMSG.Text.Length + STR.Length) > 120)
            {
                STRTRIM = TEXTMSG.Text.Substring(0, 120 - STR.Length);
                TEXTMSG.Text = STR + STRTRIM;
            }
            else
            {
                STRTRIM = TEXTMSG.Text;
            }
            TEXTMSG.Text = STR + " " + STRTRIM;
        }
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        void TEXTBOXDIS(string TBD)
        {//MJDATArichTextBox
            string STR = "";
            string STRTRIM = "";
            STR = TBD;
            if ((TEXTMSG.Text.Length + STR.Length) > 200)
            {
                STRTRIM = TEXTMSG.Text.Substring(0, 200 - STR.Length);
                TEXTMSG.Text = STR + STRTRIM;
            }
            else
            {
                STRTRIM = TEXTMSG.Text;
            }
            TEXTMSG.Text = STR + " " + STRTRIM;
        }
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        void MJDATADIS()
        {
            this.MJmain.Text = LBstatusText[1, 1];
            //牌位置ICON顯示
            MJDIS(112, 40, 40, MJPX[14], 0, 1); MJDIS(-1, 0, 0, 0, 0, 11); MJPBDIS(1);
            MJDIS(113, 40, 40, MJPX[14], MJPFY[1], 2); MJDIS(-1, 0, 0, 0, 0, 12); MJPBDIS(2);
            MJDIS(114, 40, 40, MJPX[14], MJPFY[1], 3); MJDIS(-1, 0, 0, 0, 0, 13); MJPBDIS(3);
            MJDIS(111, 40, 40, MJPX[14], MJPFY[1], 4); MJDIS(-1, 0, 0, 0, 0, 14); MJPBDIS(4);
            MJDIS(100, 104, 40, MJPX[14] - 108, 0, MJplayer); MJDIS(-1, 0, 0, 0, 0, 20 + MJplayer); MJPBDIS(MJplayer);
        }
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //public void MJDIS(int mjicontype,int mjrotate,int mjdisrect,int mjw,int mjh)
        void MJDIS(int mjicontype, int mjw, int mjh, int mjddx, int mjddy, int mjdisrect)
        {
            switch (mjicontype)
            {
                case 0: MJimg = MJP82128.Images[0]; break;
                case 1: MJimg = MJP82128.Images[1]; break;
                case 2: MJimg = MJP82128.Images[2]; break;
                case 3: MJimg = MJP82128.Images[3]; break;
                case 4: MJimg = MJP82128.Images[4]; break;
                case 5: MJimg = MJP82128.Images[5]; break;
                case 6: MJimg = MJP82128.Images[6]; break;
                case 7: MJimg = MJP82128.Images[7]; break;
                case 8: MJimg = MJP82128.Images[8]; break;
                case 9: MJimg = MJP82128.Images[9]; break;

                case 11: MJimg = MJP82128.Images[10]; break;
                case 12: MJimg = MJP82128.Images[11]; break;
                case 13: MJimg = MJP82128.Images[12]; break;
                case 14: MJimg = MJP82128.Images[13]; break;
                case 15: MJimg = MJP82128.Images[14]; break;
                case 16: MJimg = MJP82128.Images[15]; break;
                case 17: MJimg = MJP82128.Images[16]; break;
                case 18: MJimg = MJP82128.Images[17]; break;
                case 19: MJimg = MJP82128.Images[18]; break;

                case 21: MJimg = MJP82128.Images[19]; break;
                case 22: MJimg = MJP82128.Images[20]; break;
                case 23: MJimg = MJP82128.Images[21]; break;
                case 24: MJimg = MJP82128.Images[22]; break;
                case 25: MJimg = MJP82128.Images[23]; break;
                case 26: MJimg = MJP82128.Images[24]; break;
                case 27: MJimg = MJP82128.Images[25]; break;
                case 28: MJimg = MJP82128.Images[26]; break;
                case 29: MJimg = MJP82128.Images[27]; break;

                case 31: MJimg = MJP82128.Images[28]; break;
                case 32: MJimg = MJP82128.Images[29]; break;
                case 33: MJimg = MJP82128.Images[30]; break;
                case 34: MJimg = MJP82128.Images[31]; break;
                case 35: MJimg = MJP82128.Images[32]; break;
                case 36: MJimg = MJP82128.Images[33]; break;
                case 37: MJimg = MJP82128.Images[34]; break;

                case 41: MJimg = MJP82128.Images[35]; break;
                case 42: MJimg = MJP82128.Images[36]; break;
                case 43: MJimg = MJP82128.Images[37]; break;
                case 44: MJimg = MJP82128.Images[38]; break;
                case 45: MJimg = MJP82128.Images[39]; break;
                case 46: MJimg = MJP82128.Images[40]; break;
                case 47: MJimg = MJP82128.Images[41]; break;
                case 48: MJimg = MJP82128.Images[42]; break;

                case 50: MJimg = MJP82128.Images[50]; break;//立牌
                case 51: MJimg = MJP82128.Images[51]; break;//底背圖
                case 52: MJimg = MJP82128.Images[52]; break;//亮色底背圖
                case 53: MJimg = MJ82128.Images[5]; break;
                case 54: MJimg = MJ82128.Images[5]; break;
                case 55: MJimg = MJ82128.Images[5]; break;
                case 56: MJimg = MJ82128.Images[5]; break;
                case 57: MJimg = MJ82128.Images[5]; break;

                //case 100: MJimg = mjimage4040.Images[0]; break;
                //case 101: MJimg = MJnum4040.Images[1]; break;
                //case 102: MJimg = MJnum4040.Images[2]; break;
                //case 103: MJimg = MJnum4040.Images[3]; break;
                //case 104: MJimg = MJnum4040.Images[4]; break;
                //case 105: MJimg = MJnum4040.Images[5]; break;
                //case 106: MJimg = MJnum4040.Images[6]; break;
                //case 111: MJimg = mjimage4040.Images[1]; break;
                //case 112: MJimg = mjimage4040.Images[2]; break;
                //case 113: MJimg = mjimage4040.Images[3]; break;
                //case 114: MJimg = mjimage4040.Images[4]; break;

                case 900: break;
                default: break;
            }
            //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
            if (mjdisrect == 201) { this.MJMPB1.Image = MJimg; }
            if (mjdisrect == 202) { this.MJMPB2.Image = MJimg; }
            if (mjdisrect == 203) { this.MJMPB3.Image = MJimg; }
            if (mjdisrect == 204) { this.MJMPB4.Image = MJimg; }
            if (mjdisrect == 301) { this.MJMPB1.Image = MJimg; this.MJMPB2.Image = MJ82128.Images[2]; this.MJMPB3.Image = MJ82128.Images[3]; this.MJMPB4.Image = MJ82128.Images[4]; }
            if (mjdisrect == 302) { this.MJMPB1.Image = MJ82128.Images[1]; this.MJMPB2.Image = MJimg; this.MJMPB3.Image = MJ82128.Images[3]; this.MJMPB4.Image = MJ82128.Images[4]; }
            if (mjdisrect == 303) { this.MJMPB1.Image = MJ82128.Images[1]; this.MJMPB2.Image = MJ82128.Images[2]; this.MJMPB3.Image = MJimg; this.MJMPB4.Image = MJ82128.Images[4]; }
            if (mjdisrect == 304) { this.MJMPB1.Image = MJ82128.Images[1]; this.MJMPB2.Image = MJ82128.Images[2]; this.MJMPB3.Image = MJ82128.Images[3]; this.MJMPB4.Image = MJimg; }
            if (mjdisrect == 0)
            { Graphics g = Graphics.FromImage(MJbmp0); g.DrawImage(MJimg, mjddx, mjddy, mjw, mjh); }
            if (mjdisrect == 1)
            { Graphics g = Graphics.FromImage(MJbmp1); g.DrawImage(MJimg, mjddx, mjddy, mjw, mjh); }
            if (mjdisrect == 2)
            { Graphics g = Graphics.FromImage(MJbmp2); g.DrawImage(MJimg, mjddx, mjddy, mjw, mjh); }
            if (mjdisrect == 3)
            { Graphics g = Graphics.FromImage(MJbmp3); g.DrawImage(MJimg, mjddx, mjddy, mjw, mjh); }
            if (mjdisrect == 4)
            { Graphics g = Graphics.FromImage(MJbmp4); g.DrawImage(MJimg, mjddx, mjddy, mjw, mjh); }
            //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
            if (mjdisrect == 11)
            {
                Graphics g = Graphics.FromImage(MJbmp1);
                Font GFont = new Font("Arial", 14); // 字型
                string MJBUTTOMmtext = "$" + MJBUTTOMm.ToString();
                SizeF stringSize11 = g.MeasureString(MJBUTTOMmtext, GFont); // 文字字串的寬高;
                float X11 = MJPBX[15]; // 左上角的座標
                float Y11 = 0 + 40 - stringSize11.Height;
                g.DrawString(MJBUTTOMmtext, GFont, Brushes.Peru, X11, Y11);//Brushes.Black
            }

            if (mjdisrect == 12)
            {
                Graphics g = Graphics.FromImage(MJbmp2);
                Font GFont = new Font("Arial", 14); // 字型
                string MJLEFTmtext = "$" + MJLEFTm.ToString();
                SizeF stringSize12 = g.MeasureString(MJLEFTmtext, GFont); // 文字字串的寬高;
                float X12 = MJPBX[15]; // 左上角的座標
                float Y12 = 0 + 40 - stringSize12.Height;
                g.DrawString(MJLEFTmtext, GFont, Brushes.Peru, X12, Y12);//Brushes.Black
            }
            if (mjdisrect == 13)
            {
                Graphics g = Graphics.FromImage(MJbmp3);
                Font GFont = new Font("Arial", 14); // 字型
                string MJTOPmtext = "$" + MJTOPm.ToString();
                SizeF stringSize13 = g.MeasureString(MJTOPmtext, GFont); // 文字字串的寬高;
                float X13 = MJPBX[15]; // 左上角的座標
                float Y13 = 0 + 40 - stringSize13.Height;
                g.DrawString(MJTOPmtext, GFont, Brushes.Peru, X13, Y13);//Brushes.Black
            }
            if (mjdisrect == 14)
            {
                Graphics g = Graphics.FromImage(MJbmp4);
                Font GFont = new Font("Arial", 14); // 字型
                string MJRIGHTmtext = "$" + MJRIGHTm.ToString();
                SizeF stringSize14 = g.MeasureString(MJRIGHTmtext, GFont); // 文字字串的寬高;
                float X14 = MJPBX[15]; // 左上角的座標
                float Y14 = 0 + 40 - stringSize14.Height;
                g.DrawString(MJRIGHTmtext, GFont, Brushes.Peru, X14, Y14);//Brushes.Black
            }
            //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
            if (mjdisrect == 21)
            {
                Graphics g = Graphics.FromImage(MJbmp1);
                Font GFont = new Font("Arial", 16); // 字型
                string MJPLnumstr = MJPLnum.ToString();
                SizeF stringSize21 = g.MeasureString(MJPLnumstr, GFont); // 文字字串的寬高;
                float X21 = MJPBX[14] - 119 + 5 + 17 - stringSize21.Width / 2; ; // 左上角的座標
                float Y21 = 21 - stringSize21.Height / 2;
                g.DrawString(MJPLnumstr, GFont, Brushes.Lime, X21, Y21);//Brushes.Black
            }
            if (mjdisrect == 22)
            {
                Graphics g = Graphics.FromImage(MJbmp2);
                Font GFont = new Font("Arial", 16); // 字型
                string MJPLnumstr = MJPLnum.ToString();
                SizeF stringSize22 = g.MeasureString(MJPLnumstr, GFont); // 文字字串的寬高;
                float X22 = MJPBX[14] - 119 + 5 + 17 - stringSize22.Width / 2; ; // 左上角的座標
                float Y22 = 21 - stringSize22.Height / 2;
                g.DrawString(MJPLnumstr, GFont, Brushes.Lime, X22, Y22);//Brushes.Black
            }
            if (mjdisrect == 23)
            {
                Graphics g = Graphics.FromImage(MJbmp3);
                Font GFont = new Font("Arial", 16); // 字型
                string MJPLnumstr = MJPLnum.ToString();
                SizeF stringSize23 = g.MeasureString(MJPLnumstr, GFont); // 文字字串的寬高;
                float X23 = MJPBX[14] - 119 + 5 + 17 - stringSize23.Width / 2; ; // 左上角的座標
                float Y23 = 21 - stringSize23.Height / 2;
                g.DrawString(MJPLnumstr, GFont, Brushes.Lime, X23, Y23);//Brushes.Black
            }
            if (mjdisrect == 24)
            {
                Graphics g = Graphics.FromImage(MJbmp4);
                Font GFont = new Font("Arial", 16); // 字型
                string MJPLnumstr = MJPLnum.ToString();
                SizeF stringSize24 = g.MeasureString(MJPLnumstr, GFont); // 文字字串的寬高;
                float X24 = MJPBX[14] - 119 + 5 + 17 - stringSize24.Width / 2; ; // 左上角的座標
                float Y24 = 21 - stringSize24.Height / 2;
                g.DrawString(MJPLnumstr, GFont, Brushes.Lime, X24, Y24);//Brushes.Black
            }
            //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
            if (mjdisrect == 901)
            {
                Graphics g = Graphics.FromImage(MJbmp1);
                Font GFont = new Font("Arial", 8); // 字型
                SizeF TXYWH901 = g.MeasureString(MJdisTEXT, GFont); // 文字字串的寬高;
                g.DrawString(MJdisTEXT, GFont, Brushes.Blue, mjddx, mjddy);//Brushes.Black
            }
            if (mjdisrect == 902)
            {
                Graphics g = Graphics.FromImage(MJbmp2);
                Font GFont = new Font("Arial", 8); // 字型
                SizeF TXYWH902 = g.MeasureString(MJdisTEXT, GFont); // 文字字串的寬高;
                g.DrawString(MJdisTEXT, GFont, Brushes.Blue, mjddx, mjddy);//Brushes.Black
            }
            if (mjdisrect == 903)
            {
                Graphics g = Graphics.FromImage(MJbmp3);
                Font GFont = new Font("Arial", 8); // 字型
                SizeF TXYWH903 = g.MeasureString(MJdisTEXT, GFont); // 文字字串的寬高;
                g.DrawString(MJdisTEXT, GFont, Brushes.Blue, mjddx, mjddy);//Brushes.Black
            }
            if (mjdisrect == 904)
            {
                Graphics g = Graphics.FromImage(MJbmp4);
                Font GFont = new Font("Arial", 8); // 字型
                SizeF TXYWH904 = g.MeasureString(MJdisTEXT, GFont); // 文字字串的寬高;
                g.DrawString(MJdisTEXT, GFont, Brushes.Blue, mjddx, mjddy);//Brushes.Black
            }
            //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        }
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        void MJPBDIS(int PBNO)
        {
            switch (PBNO)
            {
                case 0: MJPB0.Image = MJbmp0; MJPB0.Refresh(); break;
                case 1: MJPB1.Image = MJbmp1; MJPB1.Refresh(); break;
                case 2: MJPB2.Image = MJbmp2; MJPB2.Refresh(); break;
                case 3: MJPB3.Image = MJbmp3; MJPB3.Refresh(); break;
                case 4: MJPB4.Image = MJbmp4; MJPB4.Refresh(); break;
                default: break;
            }
        }
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        void MJdataDIS(int player)
        {
            int x = 0, y = 0, z = 0;
            //int p = 0;
            //------------------------------------------
            //System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
            //System.Drawing.Graphics formGraphics;
            //formGraphics = this.CreateGraphics();
            //formGraphics.FillRectangle(myBrush, new Rectangle(0, 0, 200, 300));
            //myBrush.Dispose();
            //formGraphics.Dispose();

            Color BC = Color.FromArgb(0, 64, 0);//自訂RGB
            SolidBrush BrushBC = new SolidBrush(BC);//Graphics Brush使用方式

            //Graphics g0 = Graphics.FromImage(MJbmp0);
            //g0.FillRectangle(BrushBC, new Rectangle(0, 0, 1480, 130));
            //MJPBDIS(0);

            switch(player)
            {
                case 1:
                    Graphics g1 = Graphics.FromImage(MJbmp1);
                    g1.FillRectangle(BrushBC, new Rectangle(0, 0, 1325, 195));
                    MJPBDIS(1);
                    break;
                case 2:
                    Graphics g2 = Graphics.FromImage(MJbmp2);
                    g2.FillRectangle(BrushBC, new Rectangle(0, 0, 1325, 195));
                    MJPBDIS(2);
                    break;
                case 3:
                    Graphics g3 = Graphics.FromImage(MJbmp3);
                    g3.FillRectangle(BrushBC, new Rectangle(0, 0, 1325, 195));
                    MJPBDIS(3);
                    break;
                case 4:
                    Graphics g4 = Graphics.FromImage(MJbmp4);
                    g4.FillRectangle(BrushBC, new Rectangle(0, 0, 1325, 195));
                    MJPBDIS(4);
                    break;
                default:
                    break;
            }


            for (x = 1; x <= 8; x++)
            {
                if(MJPF[player, x] > 136)
                {
                    MJDIS(MJnum[MJPF[player, x]], MJPFW, MJPFH, MJPFX[x], MJPFY[x], player);
                }
            }

            for (y = 1; y <= 9; y++)
            {
                for (x = 1; x <= 3; x++)
                {
                    if (MJPED[player, y, x] > 0 && MJPED[player, y, x] < 137)
                    {
                        MJDIS(MJnum[MJPED[player, y, x]], MJPEDW, MJPEDH, MJPEDX[(y - 1) * 3 + x], MJPEDY[(y - 1) * 3 + x], player);
                    }
                }
            }
            
            for (x=16;x>0; x--)
            {
                if(MJP[player,x]>0 && MJP[player, x]<137)
                {
                    MJDIS(MJnum[MJP[player, x]], MJPW, MJPH, MJPX[x], MJPY[x], player);
                    MJdisTEXT = MJP[player, x].ToString();
                    MJDIS(0, MJPW, MJPH, MJPX[x] + 5, MJPY[x] + 5, 900 + player);
                    MJdisTEXT = MJnum[MJP[player, x]].ToString();
                    MJDIS(0, MJPW, MJPH, MJPX[x] + 50, MJPY[x] + 5, 900 + player);
                }
            }

            MJPBDIS(player);

        }
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        void MJdataDIS0()
        {
            Color BC = Color.FromArgb(0, 64, 0);//自訂RGB
            SolidBrush BrushBC = new SolidBrush(BC);//Graphics Brush使用方式

            Graphics g0 = Graphics.FromImage(MJbmp0);
            g0.FillRectangle(BrushBC, new Rectangle(0, 0, 1480, 130));
            //MJPBDIS(0);

            for (int x = 1; x <= 72; x++)
            {
                if(MJPC[x]>0 && MJPC[x]<137)
                {
                    MJDIS(MJnum[MJPC[x]], MJPCW, MJPCH, MJPCX[x], MJPCY[x], 0);
                }
            }

            for(int x = MJPMPOS ;x <= 72;x++)
            {
                MJDIS(50, MJPCW, MJPCH, MJPCX[x], MJPCY[x], 0);
            }

            if (MJGet % 2 == 0 && MJGet > 1)
            {
                MJPMPOS++; if (MJPMPOS > 72) { MJPMPOS = 72; }
                //MJDIS(0, MJPCW, MJPCH, MJPCX[MJPMPOS], MJPCY[MJPMPOS], 0);
                MJDIS(0, MJPCW, MJPCH, MJPCX[MJPMPOS - 1], MJPCY[MJPMPOS - 1], 0);
                MJDIS(52, MJPCW, MJPCH, MJPCX[MJPMPOS], MJPCY[MJPMPOS], 0);
            }
            else
            {
                MJDIS(51, MJPCW, MJPCH, MJPCX[MJPMPOS], MJPCY[MJPMPOS], 0);
            }

            if (MJGet == 144)
            {
                MJCPY = MJPCY[MJPCtotal];
                MJCPX = MJPCX[MJPCtotal] - 60;
                //MJDIS(MJnum[MJCancelNum], MJPCW, MJPCH, MJCPX, MJCPY, 0);
                MJDIS(MJnum[MJPC[MJPCtotal]], MJPCW, MJPCH, MJCPX, MJCPY, 0);
            }

            MJPBDIS(0);

        }

        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        //888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888





    }
    }
