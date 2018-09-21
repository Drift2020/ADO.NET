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
    class View_model_main : View_Model_Base
    {

        public View_model_main()
        {
            var host = System.Net.Dns.GetHostName();

            var hosst = Dns.GetHostEntry(Dns.GetHostName());

            ip_my1 = hosst.AddressList[hosst.AddressList.Length - 1].ToString();
            My_acc = new User();
            My_acc.Name = ip_my1;
            var i = GetSubnetMask(hosst.AddressList[hosst.AddressList.Length - 1]);
            IP_my = GetIP(i, ip_my1);
            uiContext = SynchronizationContext.Current;
            WaitClientQuery();
            Update();
        }
        #region Pole
        string name;
        public string Name { get { return name; } set { name = value; OnPropertyChanged(nameof(Name)); } }

        string ip_my1;
        string IP_my;
        User My_acc;


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
            if (name != null && name.Length > 0)
                return true;
            return false;
        }

        #endregion Button send

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
            try
            {
                Close();
            }
            catch
            {

            }
        }
        private bool CanExecute_button_close(object o)
        {
           
                return true;
            
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

                    UdpClient client = new UdpClient(49185 /* порт */);
                    client.EnableBroadcast = true;
                    while (true)
                    {
                        try
                        {
                            IPEndPoint remote = null;
                            byte[] arr = client.Receive(ref remote);
                            if (arr.Length > 0)
                            {

                                MemoryStream stream = new MemoryStream(arr);

                                BinaryFormatter formatter = new BinaryFormatter();

                                string my_str = (string)formatter.Deserialize(stream);

                                if (my_str == "messege")
                                {
                                    remote = null;
                                    byte[] arr1 = client.Receive(ref remote);
                                    stream = new MemoryStream(arr1);
                                    formatter = new BinaryFormatter();
                                    Date_massege m = (Date_massege)formatter.Deserialize(stream);
                                    uiContext.Send(d => List_messege.Add(m), null);
                                }
                                else if (my_str == "User")
                                {
                                    remote = null;
                                    byte[] arr2 = client.Receive(ref remote);
                                    stream = new MemoryStream(arr2);
                                    formatter = new BinaryFormatter();
                                    User m1 = (User)formatter.Deserialize(stream);
                                    uiContext.Send(d => List_user.Add(m1), null);
                                }
                                else if (my_str == "Disconnect")
                                {
                                    remote = null;
                                    byte[] arr2 = client.Receive(ref remote);
                                    stream = new MemoryStream(arr2);
                                    formatter = new BinaryFormatter();
                                    User m1 = (User)formatter.Deserialize(stream);
                                    uiContext.Send(d => List_user.Remove(m1), null);
                                }


                                stream.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            //  MessageBox.Show("Получатель: " + ex.Message);
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

                    UdpClient client = new UdpClient(IP_my, 49185);
                    client.EnableBroadcast = true;
                    // Создадим поток, резервным хранилищем которого является память.
                    MemoryStream stream = new MemoryStream();
                    // BinaryFormatter сериализует и десериализует объект в двоичном формате 
                    BinaryFormatter formatter = new BinaryFormatter();



                    Date_massege m = new Date_massege();
                    m.Name = Name; // текст сообщения
                    m.Messege = Messege; // имя пользователя
                    m.Time = DateTime.Now.ToString();

                    formatter.Serialize(stream, m);
                    byte[] arr = stream.ToArray();

                    stream.SetLength(0);
                    formatter.Serialize(stream, "messege");
                    byte[] arr1 = stream.ToArray();


                    client.Send(arr1, arr1.Length);
                    client.Send(arr, arr.Length);


                    client.Close();
                    stream.Close();
                }
                catch (Exception ex)
                {
                    //  MessageBox.Show("Отправитель: " + ex.Message);
                }
            });
        }

        //connect
        private async void Update()
        {
            await Task.Run(() =>
            {
                try
                {
                    // Инициализируем новый экземпляр класса UdpClient и устанавливаем удаленный узел

                    UdpClient client = new UdpClient(IP_my, 49185);
                    client.EnableBroadcast = true;
                    // Создадим поток, резервным хранилищем которого является память.
                    MemoryStream stream = new MemoryStream();
                    // BinaryFormatter сериализует и десериализует объект в двоичном формате 
                    BinaryFormatter formatter = new BinaryFormatter();




                    formatter.Serialize(stream, My_acc);
                    byte[] arr = stream.ToArray();

                    stream.SetLength(0);
                    formatter.Serialize(stream, "User");
                    byte[] arr1 = stream.ToArray();


                    client.Send(arr1, arr1.Length);
                    client.Send(arr, arr.Length);


                    client.Close();
                    stream.Close();
                }
                catch (Exception ex)
                {
                    //  MessageBox.Show("Отправитель: " + ex.Message);
                }
            });
        }

        //close
       
            private async void Close()
            {
                await Task.Run(() =>
                {
                    try
                    {
                        // Инициализируем новый экземпляр класса UdpClient и устанавливаем удаленный узел

                        UdpClient client = new UdpClient(IP_my, 49185);
                        client.EnableBroadcast = true;
                        // Создадим поток, резервным хранилищем которого является память.
                        MemoryStream stream = new MemoryStream();
                        // BinaryFormatter сериализует и десериализует объект в двоичном формате 
                        BinaryFormatter formatter = new BinaryFormatter();




                        formatter.Serialize(stream, My_acc);
                        byte[] arr = stream.ToArray();

                        stream.SetLength(0);
                        formatter.Serialize(stream, "Disconnect");
                        byte[] arr1 = stream.ToArray();


                        client.Send(arr1, arr1.Length);
                        client.Send(arr, arr.Length);


                        client.Close();
                        stream.Close();
                    }
                    catch (Exception ex)
                    {
                        //  MessageBox.Show("Отправитель: " + ex.Message);
                    }
                });
            }
        

        string GetIP(IPAddress masc, string ip)
        {
            string temp = "";
            String[] words_masc = masc.ToString().Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

            String[] words_ip = ip.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < words_masc.Length; i++)
            {
                if (words_masc[i] == "255")
                {
                    temp += words_ip[i] + '.';
                }
                else if (words_masc[i] == "0")
                {
                    temp += "255.";
                }
            }
            temp = temp.Remove(temp.Length - 1);
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
