using System;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Input;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Net;
using System.Windows;

namespace My_TeamViewer
{
    class View_model_translete : View_Model_Base
    {
        public View_model_translete(TcpClient client)
        {
            ConnectAndSend(client);
        }
        #region pole

        Image image_my;
        public Image Image_my
        {
            get
            {
                return image_my;
            }
            set
            {
               // image_my.Dispose();
                image_my = value;
                OnPropertyChanged(nameof(Image_my));
            }
        }


        #region IP con
        string ip;
        public string IP { get { return ip; } set { ip = value; OnPropertyChanged(nameof(IP)); } }
        #endregion IP con

        #region Port
        string port;
        public string Port { get { return port; } set { port = value; OnPropertyChanged(nameof(Port)); } }
        #endregion Port

        public SynchronizationContext uiContext=new SynchronizationContext();
        #endregion pole 

        #region Command

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


        #region client

        private async void ConnectAndSend(TcpClient client)
        {
            await Task.Run(() =>
            {
                try
                {




                    ReadMessage(client);



                    // закрываем TCP-подключение и освобождаем все ресурсы, связанные с объектом TcpClient.

                }
                catch (Exception ex)
                {
                    //   MessageBox.Show("Клиент: " + ex.Message);
                }
            });
        }

        private async void ReadMessage(TcpClient client)
        {
            await Task.Run(() =>
            {


              
                NetworkStream netstream = client.GetStream();
                MemoryStream stream;
                BinaryFormatter formatter;
                Image m;
                int len1 = 0;
                int len;
                while (true)
                {
                    try
                    {

                        ////////////размер/////////////////////<-
                        //  byte[] arr1 = new byte[client.ReceiveBufferSize ];                
                        //  len1 = netstream.Read(arr1, 0, client.ReceiveBufferSize);
                        ////////////размер/////////////////////<-
                        //if (len1 >0 )
                        //{  
                        //    stream = new MemoryStream(arr1);

                        //    formatter = new BinaryFormatter();


                        //    len1= BitConverter.ToInt32(arr1, 0);              

                        //    formatter.Serialize(stream, "int"); 
                        //    byte[] com1 = stream.ToArray();

                        //    ////////////размер ответ/////////////////////->
                        //    netstream.Write(com1, 0, client.ReceiveBufferSize);
                        //    ////////////размер ответ/////////////////////->

                        //}




                        byte[] arr = new byte[4000000];
                        ////////////image/////////////////////<-

                        len = netstream.Read(arr, 0, 4000000);
                        ////////////image/////////////////////<-
                        if (len > 0)
                        {

                            stream = new MemoryStream(arr);
                            formatter = new BinaryFormatter();

                            m = (Image)formatter.Deserialize(stream);
                            uiContext.Send(d => Image_my = ((Image)m.Clone()), null);
                            uiContext.Send(d => OnPropertyChanged(nameof(Image_my)), null);


                            // formatter.Serialize(stream, "image"); 
                            // byte[] com1 = stream.ToArray();
                            ////////////image otv/////////////////////->

                            // netstream.Write(com1, 0, client.ReceiveBufferSize);
                            ////////////image otv/////////////////////->
                            stream.Close();
                            m.Dispose();

                        }



                    }
                    catch (Exception ex)
                    {

                    }
                }
                netstream.Close();
                client.Close();
            });

        }
        Socket sock;
        void Conect(string ip, string port)
        {
            // соединяемся с удаленным устройством
            try
            {

                IPEndPoint ipEndPoint = new IPEndPoint(
                    IPAddress.Parse(ip),
                    Convert.ToInt32(port));


                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                sock.BeginConnect(ipEndPoint, new AsyncCallback(ConnectCallback),
                    sock);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сервер: " + ex.Message);
            }
        }

        public void ConnectCallback(IAsyncResult ar /* информация о состоянии асинхронной операции */)
        {
            try
            {
                Socket sclient = (Socket)ar.AsyncState;
                sclient.EndConnect(ar);
                MessageBox.Show("Клиент " + Dns.GetHostName() + " установил соединение с " + sclient.RemoteEndPoint.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Клиент: " + ex.Message);
            }
        }
        #endregion client
    }


}
