using System;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Input;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;


namespace My_TeamViewer
{
    class View_model_translete : View_Model_Base
    {
        public View_model_translete(string ip,string port)
        {
            ConnectAndSend(ip,port);
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

        private async void ConnectAndSend(string ip, string port)
        {
            await Task.Run(() =>
            {
                try
                {

                

                    
                        ReadMessage(ip,port);
                    


                  // закрываем TCP-подключение и освобождаем все ресурсы, связанные с объектом TcpClient.

                }
                catch (Exception ex)
                {
                    //   MessageBox.Show("Клиент: " + ex.Message);
                }
            });
        }

        private async void ReadMessage(string ip, string port)
        {
            await Task.Run(() =>
            {
                
               
                TcpClient client = new TcpClient(ip /* имя хоста */, Convert.ToInt32(port));
                NetworkStream netstream = client.GetStream();
                MemoryStream stream;
                BinaryFormatter formatter;
                Image m;
                int len1=0;
                int len;
                while (true)
                {
                    try
                    {

                        // Получим объект NetworkStream, используемый для приема и передачи данных.
                     
                        byte[] arr1 = new byte[client.ReceiveBufferSize /* размер приемного буфера */];
                        // Читаем данные из объекта NetworkStream.
                        len1 = netstream.Read(arr1, 0, client.ReceiveBufferSize/*client.ReceiveBufferSize*/);
                        if (len1 >0 )
                        {
                            // Создадим поток, резервным хранилищем которого является память.
                            stream = new MemoryStream(arr1);
                            // BinaryFormatter сериализует и десериализует объект в двоичном формате 
                            formatter = new BinaryFormatter();

                            //len1 = (int)formatter.Deserialize(stream); // выполняем десериализацию
                            len1= BitConverter.ToInt32(arr1, 0);                                         // полученную от клиента информацию добавляем в список

                            formatter.Serialize(stream, "int"); // выполняем сериализацию
                            byte[] com1 = stream.ToArray();
                            netstream.Write(com1, 0, com1.Length);

                        }



                     
                        byte[] arr = new byte[len1 /* размер приемного буфера */];
                        // Читаем данные из объекта NetworkStream.
                        len = netstream.Read(arr, 0, len1/*client.ReceiveBufferSize*/);

                        if (len > 0)
                        {
                            // Создадим поток, резервным хранилищем которого является память.
                            stream = new MemoryStream(arr);
                            // BinaryFormatter сериализует и десериализует объект в двоичном формате 
                            formatter = new BinaryFormatter();

                            m = (Image)formatter.Deserialize(stream); // выполняем десериализацию
                                                                      // полученную от клиента информацию добавляем в список



                            // uiContext.Send отправляет синхронное сообщение в контекст синхронизации
                            // SendOrPostCallback - делегат указывает метод, вызываемый при отправке сообщения в контекст синхронизации. 
                            uiContext.Send(d => Image_my = m /* Вызываемый делегат SendOrPostCallback */,
                              null /* Объект, переданный делегату */);
                            uiContext.Send(d => OnPropertyChanged(nameof(Image_my)) /* Вызываемый делегат SendOrPostCallback */,
                               null /* Объект, переданный делегату */);
                           

                            formatter.Serialize(stream, "image"); // выполняем сериализацию
                            byte[] com1 = stream.ToArray();
                            netstream.Write(com1, 0, com1.Length);

                            stream.Close();
                            m.Dispose();
                        }


                        // закрываем TCP-подключение и освобождаем все ресурсы, связанные с объектом TcpClient.
                    }
                    catch (Exception ex)
                    {
                      // закрываем TCP-подключение и освобождаем все ресурсы, связанные с объектом TcpClient.
                                        //   MessageBox.Show("Сервер: " + ex.Message);
                    }
                }
                netstream.Close();
                client.Close();
            });

        }
        #endregion client
    }


}
