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
using System.Windows;
using System.Windows.Input;

namespace Chat
{
    enum Type_pacet
    {
        connect = 1,
        messege = 2,
        update = 3,
        exit = 4
    }
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

                    using (UdpClient client = new UdpClient(49185 /* порт */))
                    {
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
                                    byte[] command_b = new byte[4];
                                    BinaryFormatter formatter = new BinaryFormatter();
                                    //     byte[] arr1 = (byte[])formatter.Deserialize(stream);
                                    for (int i = 0; i < 4; i++)
                                    {
                                        command_b[i] = arr[i];
                                    }
                                    Type_pacet My_command = (Type_pacet)(BitConverter.ToInt32(command_b, 0));

                                    stream.Dispose();
                                    //   string my_str = (string)formatter.Deserialize(stream);
                                    switch (My_command)
                                    {
                                        case Type_pacet.messege:
                                            {
                                                byte[] arr2 = new byte[arr.Length - 4];
                                                Array.Copy(arr, 4, arr2, 0, arr.Length - 4);

                                                stream = new MemoryStream(arr2);
                                                formatter = new BinaryFormatter();
                                                Date_massege m = (Date_massege)formatter.Deserialize(stream);
                                                uiContext.Send(d => List_messege.Add(m), null);
                                            }
                                            break;

                                        case Type_pacet.update:
                                            {
                                                byte[] arr2 = new byte[arr.Length - 4];
                                                Array.Copy(arr, 4, arr2, 0, arr.Length - 4);

                                                stream = new MemoryStream(arr2);
                                                formatter = new BinaryFormatter();
                                                User m1 = (User)formatter.Deserialize(stream);

                                                bool isList = true;
                                                foreach (var i in List_user)
                                                    if (i.Name == m1.Name)
                                                    {
                                                        isList = false;
                                                        break;
                                                    }

                                                if (isList)
                                                    uiContext.Send(d => List_user.Add(m1), null);
                                            }
                                            break;

                                        case Type_pacet.connect:

                                            {
                                                byte[] arr2 = new byte[arr.Length - 4];

                                                Array.Copy(arr, 4, arr2, 0, arr.Length - 4);
                                                stream = new MemoryStream(arr2);
                                                formatter = new BinaryFormatter();
                                                User m1 = (User)formatter.Deserialize(stream);
                                                uiContext.Send(d => List_user.Add(m1), null);
                                                stream.Dispose();



                                                stream = new MemoryStream();
                                                formatter.Serialize(stream, My_acc);

                                                byte[] arr3 = BitConverter.GetBytes((Int32)Type_pacet.update);
                                                byte[] arr4 = stream.ToArray();
                                                byte[] arr5 = arr3.Concat(arr4).ToArray();

                                                using (UdpClient client1 = new UdpClient(IP_my, 49185))
                                                {
                                                    client1.EnableBroadcast = true;
                                                    client1.Send(arr5, arr5.Length);
                                                    client1.Close();
                                                }
                                            }
                                            break;

                                        case Type_pacet.exit:
                                            {

                                                byte[] arr2 = new byte[arr.Length - 4];
                                                Array.Copy(arr, 4, arr2, 0, arr.Length - 4);

                                                stream = new MemoryStream(arr2);
                                                formatter = new BinaryFormatter();
                                                User m1 = (User)formatter.Deserialize(stream);

                                                for (var i = 0; i < List_user.Count; i++)
                                                {
                                                    if (List_user[i].Name == m1.Name)

                                                        uiContext.Send(d => List_user.RemoveAt(i), null);
                                                }
                                            }
                                            break;
                                    }


                                    stream.Dispose();
                                    stream.Close();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Получатель: " + ex.Message);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Получатель: " + ex.Message);
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

                    using (UdpClient client = new UdpClient(IP_my, 49185))
                    {
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

                        byte[] arr = BitConverter.GetBytes((Int32)Type_pacet.messege);
                        byte[] arr2 = stream.ToArray();
                        byte[] arr1 = arr.Concat(arr2).ToArray();


                        client.Send(arr1, arr1.Length);
                        //  client.Send(arr, arr.Length);


                        client.Close();
                        stream.Close();
                    }
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

                    using (UdpClient client = new UdpClient(IP_my, 49185))
                    {
                        client.EnableBroadcast = true;
                        // Создадим поток, резервным хранилищем которого является память.
                        MemoryStream stream = new MemoryStream();
                        // BinaryFormatter сериализует и десериализует объект в двоичном формате 
                        BinaryFormatter formatter = new BinaryFormatter();




                        // Int32 a = 1;
                        //  formatter.Serialize(stream, a);
                        formatter.Serialize(stream, My_acc);



                        byte[] arr = BitConverter.GetBytes((Int32)Type_pacet.connect);
                        byte[] arr2 = stream.ToArray();
                        byte[] arr1 = arr.Concat(arr2).ToArray();


                        client.Send(arr1, arr1.Length);


                        client.Close();
                        //  stream.Dispose();
                        stream.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Отправитель: " + ex.Message);
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

                    using (UdpClient client = new UdpClient(IP_my, 49185))
                    {
                        client.EnableBroadcast = true;
                        // Создадим поток, резервным хранилищем которого является память.
                        MemoryStream stream = new MemoryStream();
                        // BinaryFormatter сериализует и десериализует объект в двоичном формате 
                        BinaryFormatter formatter = new BinaryFormatter();




                        formatter.Serialize(stream, My_acc);







                        byte[] arr = BitConverter.GetBytes((Int32)Type_pacet.exit);
                        byte[] arr2 = stream.ToArray();
                        byte[] arr1 = arr.Concat(arr2).ToArray();



                        client.Send(arr1, arr1.Length);



                        client.Close();
                        stream.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Отправитель: " + ex.Message);
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
