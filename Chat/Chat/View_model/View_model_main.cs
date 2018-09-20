using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chat
{
    class View_model_main:View_Model_Base, My_Date
    {

        public View_model_main()
        {
            uiContext = SynchronizationContext.Current;
            WaitClientQuery();
        }
        #region Pole
        string name;
        public string Name { get { return name; } set { name = value;OnPropertyChanged(nameof(Name)); } }
        string time;
        public string Time { get { return time; } set { time = value; OnPropertyChanged(nameof(Time)); } }
        string message;
        public string Messege
        {
            get { return message; }
            set { message = value; OnPropertyChanged(nameof(Messege)); }
        }
        public SynchronizationContext uiContext;
        #endregion Pole

        #region Command

        #region Button connect

        private DelegateCommand _Command_button_send;
        public ICommand Button_send
        {
            get
            {
                if (_Command_button_send == null)
                {
                    _Command_button_send = new DelegateCommand(Execute_button_send, CanExecute_button_send);
                }
                return _Command_button_send;
            }
        }
        
        private void Execute_button_send(object o)
        {
            try
            {
                Send();
            }
            catch
            {

            }
        }
        private bool CanExecute_button_send(object o)
        {
            if(name!=null&&name.Length>0)
            return true;
            return false;
        }

        #endregion Button connect

        #endregion Command

        #region code

        private async void WaitClientQuery()
        {
            await Task.Run(() =>
            {
                try
                {
                    // Инициализируем новый экземпляр класса UdpClient и связываем его с заданным номером локального порта.
                    UdpClient client = new UdpClient(49152 /* порт */); // принимаются все входящие соединения с локальной конечной точкой
                    client.EnableBroadcast = true;
                    while (true)
                    {
                        IPEndPoint remote = null; // информация об удаленном хосте, который отправил датаграмму
                        byte[] arr = client.Receive(ref remote); // получим UDP-датаграмму
                        if (arr.Length > 0)
                        {
                            // Создадим поток, резервным хранилищем которого является память.
                            MemoryStream stream = new MemoryStream(arr);
                            // BinaryFormatter сериализует и десериализует объект в двоичном формате 
                            BinaryFormatter formatter = new BinaryFormatter();
                            My_Date m = (My_Date)formatter.Deserialize(stream); // выполняем десериализацию
                            // полученную от удаленного узла информацию добавляем в список
                            uiContext.Send(d => List_messege.Add(m.Time+m.Name+m.Messege), null);
                          
                            stream.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                  //  MessageBox.Show("Получатель: " + ex.Message);
                }
            });
        }

        private async void Send()
        {
            await Task.Run(() =>
            {
                try
                {
                    // Инициализируем новый экземпляр класса UdpClient и устанавливаем удаленный узел
                    UdpClient client = new UdpClient(
                     
                        49152 );
                    client.EnableBroadcast = true;
                    // Создадим поток, резервным хранилищем которого является память.
                    MemoryStream stream = new MemoryStream();
                    // BinaryFormatter сериализует и десериализует объект в двоичном формате 
                    BinaryFormatter formatter = new BinaryFormatter();
                    Date_massege m = new Date_massege();
                    m.Name = Name; // текст сообщения
                    m.Messege = Messege; // имя пользователя
                    formatter.Serialize(stream, m); // выполняем сериализацию
                    byte[] arr = stream.ToArray(); // записываем содержимое потока в байтовый массив
                    stream.Close();
                    client.Send(arr, arr.Length); // передаем UDP-датаграмму на удаленный узел
                    client.Close(); // закрываем UDP-подключение и освобождаем все ресурсы, связанные с объектом UdpClient.
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Отправитель: " + ex.Message);
                }
            });
        }

        #endregion code

        #region list


        #region My_Date
        List<string> list_messege = new List<string>();
        public ICollection<string> List_messege
        {
            set
            {
                list_messege = value.ToList();
                OnPropertyChanged(nameof(List_messege));
            }
            get
            {
                return list_messege.ToList();
            }
        }

        #endregion My_Date

      

        #endregion list
    }
}
