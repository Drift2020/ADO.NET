using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using System.Windows;

namespace My_TeamViewer
{
    class View_model_main: View_Model_Base
    {
        public View_model_main()
        {
            var host = System.Net.Dns.GetHostName();

            var hosst = Dns.GetHostEntry(Dns.GetHostName());

            IP_my = hosst.AddressList[hosst.AddressList.Length - 1].ToString();

        }

        #region Pole

        #region IP con
        string ip;
        public string IP { get { return ip; }set { ip = value;OnPropertyChanged(nameof(IP)); } }
        #endregion IP con

        #region IP my
        string ip_my;
        public string IP_my { get { return ip_my; } set { ip_my = value; OnPropertyChanged(nameof(IP_my)); } }
        #endregion IP my

        #region Port
        string port;
        public string Port { get { return port; }set { port = value;OnPropertyChanged(nameof(Port)); } }
        #endregion Port

        #region Port_my
        string port_my;
        public string Port_my { get { return port_my; } set { port_my = value; OnPropertyChanged(nameof(Port_my)); } }
        #endregion Port_my

        #region status
        string status;
        public string Status { get { return status; } set { status = value; OnPropertyChanged(nameof(Status)); } }
        #endregion status


        public SynchronizationContext uiContext = new SynchronizationContext();

        #endregion Pole

        #region Command
        #region Button connect

        private DelegateCommand _Command_button_connect;
        public ICommand Button_connect
        {
            get
            {
                if (_Command_button_connect == null)
                {
                    _Command_button_connect = new DelegateCommand(Execute_button_connect, CanExecute_button_connect);
                }
                return _Command_button_connect;
            }
        }
        private void Execute_button_connect(object o)
        {

           


            Translete window2 = new Translete();
            View_model_translete view = new View_model_translete(ip,port);
            window2.DataContext = view;
            window2.ShowDialog();
        }
        private bool CanExecute_button_connect(object o)
        {
           
            return true;
        }

        #endregion Button connect

        #region Button open

        private DelegateCommand _Command_button_open;
        public ICommand Button_open
        {
            get
            {
                if (_Command_button_open == null)
                {
                    _Command_button_open = new DelegateCommand(Execute_button_open, CanExecute_button_open);
                }
                return _Command_button_open;
            }
        }
        private void Execute_button_open(object o)
        {
            Open_connect();
        }
        private bool CanExecute_button_open(object o)
        {

            return true;
        }

        #endregion Button open

        #region Button close

        private DelegateCommand _Command_button_close;
        public ICommand Button_close
        {
            get
            {
                if (_Command_button_close == null)
                {
                    _Command_button_close = new DelegateCommand(Execute_button_close, CanExecute_button_close);
                }
                return _Command_button_close;
            }
        }
        private void Execute_button_close(object o)
        {

        }
        private bool CanExecute_button_close(object o)
        {

            return false;
        }

        #endregion Button close

        #region Button disconnect

        private DelegateCommand _Command_button_disconnect;
        public ICommand Button_disconnect
        {
            get
            {
                if (_Command_button_disconnect == null)
                {
                    _Command_button_disconnect = new DelegateCommand(Execute_button_disconnect, CanExecute_button_disconnect);
                }
                return _Command_button_disconnect;
            }
        }
        private void Execute_button_disconnect(object o)
        {

        }
        private bool CanExecute_button_disconnect(object o)
        {

            return false;
        }

        #endregion Button disconnect

        #endregion Command


        #region code

        #region server

        async void Open_connect()
        {
            await Task.Run(() =>
            {
                try
                {
                    // TcpListener ожидает подключения от TCP-клиентов сети.
                    TcpListener listener = new TcpListener(
                    IPAddress.Any /* Предоставляет IP-адрес, указывающий, что сервер должен контролировать действия клиентов на всех сетевых интерфейсах.*/,
                    Convert.ToInt32(port_my) /* порт */);
                    listener.Start(); // Запускаем ожидание входящих запросов на подключение
                    
                    while (true)
                    {
                        TcpClient client = listener.AcceptTcpClient();
                        SendMessage(client);
                    }
                }
                catch (Exception ex)
                {
                   // MessageBox.Show("Сервер: " + ex.Message);
                }
            });
        }
 
        private async void SendMessage(TcpClient client)
        {
            await Task.Run(() =>
            {
                MemoryStream stream = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                NetworkStream netstream = client.GetStream();
                netstream = client.GetStream();
                while (true)
                {
                    try
                    {


                       
                        Image img = CopyScreen();
                        formatter.Serialize(stream, img); // выполняем сериализацию
                        byte[] arr = stream.ToArray(); // записываем содержимое потока в байтовый массив
                        stream.Close();
                        netstream.Write(arr, 0, arr.Length); // записываем данные в NetworkStream.

                    }
                    catch (Exception e)
                    {
                        
                    }
                }
                netstream.Close();
                        client.Close();
            });
        }

        private Bitmap CopyScreen()
        {
            var left = Screen.AllScreens.Min(screen => screen.Bounds.X);
            var top = Screen.AllScreens.Min(screen => screen.Bounds.Y);
            var right = Screen.AllScreens.Max(screen => screen.Bounds.X + screen.Bounds.Width);
            var bottom = Screen.AllScreens.Max(screen => screen.Bounds.Y + screen.Bounds.Height);
            var width = right - left;
            var height = bottom - top;

            using (var screenBmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
            {
                using (var bmpGraphics = Graphics.FromImage(screenBmp))
                {
                    bmpGraphics.CopyFromScreen(left, top, 0, 0, new System.Drawing.Size(width, height));
                    return new Bitmap(width, height, bmpGraphics);

                }
            }
        }

        #endregion server

        #region client


  
        #endregion client

        #endregion code
    }
}
