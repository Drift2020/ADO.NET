using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chat
{
    class View_model_main:View_Model_Base
    {
       
        public View_model_main()
        {
            var host = System.Net.Dns.GetHostName();

            var hosst = Dns.GetHostEntry(Dns.GetHostName());

            var ip_my = hosst.AddressList[hosst.AddressList.Length - 1].ToString();
            var i = GetSubnetMask(hosst.AddressList[hosst.AddressList.Length - 1]);
            IP_my=  GetIP(i, ip_my);
            uiContext = SynchronizationContext.Current;
            WaitClientQuery();
        }
        #region Pole
        string name;
        public string Name { get { return name; } set { name = value;OnPropertyChanged(nameof(Name)); } }


        string IP_my;



        string message;
        public string Messege
        {
            get { return message; }
            set { message = value; OnPropertyChanged(nameof(Messege)); }
        }

        

        public SynchronizationContext uiContext;
        #endregion Pole

        #region Command

        #region Button send

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

        #endregion Button send

        #endregion Command

        #region code
        // прием сообщения
        private async void WaitClientQuery()
        {
            await Task.Run(() =>
            {
                try
                {
                    // Инициализируем новый экземпляр класса UdpClient и связываем его с заданным номером локального порта.
                    UdpClient client = new UdpClient(49185 /* порт */); // принимаются все входящие соединения с локальной конечной точкой
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
                            Date_massege m = (Date_massege)formatter.Deserialize(stream); // выполняем десериализацию
                           
                            // полученную от удаленного узла информацию добавляем в список
                            uiContext.Send(d => List_messege.Add(m), null);
                            uiContext.Send(d => OnPropertyChanged(nameof(List_messege)), null);

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

        // отправление сообщения
        private async void Send()
        {
            await Task.Run(() =>
            {
                try
                {
                    // Инициализируем новый экземпляр класса UdpClient и устанавливаем удаленный узел
                    
                    UdpClient client = new UdpClient("10.2.220.255", 49185);
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
                  //  MessageBox.Show("Отправитель: " + ex.Message);
                }
            });
        }



        string GetIP(IPAddress masc,string ip )
        {
            string temp= masc.Address.ToString(); ;
            string[] words_masc = temp.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
          
            string[] words_ip = ip.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

            for(var i=0;i< words_masc.Length; i++)
            {
                if(words_masc[i] == "255")
                {
                    temp += words_ip[i] + '.';
                }
                else if(words_masc[i] == "0")
                {
                    temp += "255.";
                }
            }
            temp=temp.Remove(temp.Length - 1);
            return temp;
         
        }


        IPAddress GetSubnetMask(IPAddress address)
        {
            foreach (NetworkInterface adapter in NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach (UnicastIPAddressInformation unicastIPAddressInformation in adapter.GetIPProperties().UnicastAddresses)
                {
                    if (unicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        if (address.Equals(unicastIPAddressInformation.Address))
                        {
                            return unicastIPAddressInformation.IPv4Mask;
                        }
                    }
                }
            }
            throw new ArgumentException($"Can't find subnetmask for IP address '{address}'");
        }

        #endregion code

        #region list


        #region My_Date
        ObservableCollection<Date_massege> list_messege = new ObservableCollection<Date_massege>();
        public ObservableCollection<Date_massege> List_messege
        {
            set
            {
                list_messege = value;
                OnPropertyChanged(nameof(List_messege));
            }
            get
            {
                return list_messege;
            }
        }

        #endregion My_Date

        #region User
        ObservableCollection<User> list_user = new ObservableCollection<User>();
        public ObservableCollection<User> List_user
        {
            set
            {
                list_user = value;
                OnPropertyChanged(nameof(List_user));
            }
            get
            {
                return list_user;
            }
        }

        #endregion User



        #endregion list
    }
}
