using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MyProcess;
namespace Server
{
   public class box
    {
        My_Process[] my_proc;
        int port= 49158;
        string host;
        System.Net.IPAddress ip;
        public bool isNewSocet = false;
        public bool isConect = false;
        public IPAddress GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip;
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        public string Host { get { return host; }  }
        public string IP { get { return ip.ToString(); } }
        public string Port { get { return port.ToString(); } set { port = Convert.ToInt32(value); } }
        public box()
        {
            host = System.Net.Dns.GetHostName();

            var hosst = Dns.GetHostEntry(Dns.GetHostName());

            ip = hosst.AddressList[hosst.AddressList.Length-1];
           
        }
        public static byte[] Serialize(object Obj)
        {
            BinaryFormatter bin = new BinaryFormatter();
            MemoryStream mem = new MemoryStream();
            bin.Serialize(mem, Obj);
            return mem.GetBuffer();
        }
        void Update(Socket handler)
        {
          
             Process[] temp_proc = Process.GetProcesses();
            my_proc = new My_Process[temp_proc.Length];

            //my_proc = new My_Process[2];
            //my_proc[0] =new My_Process( "hh", "hh");
            //my_proc[1] = new My_Process("hh1", "hh1");         

            for (int i = 0; i < temp_proc.Length; i++)
                my_proc[i] = new My_Process(temp_proc[i].ProcessName, temp_proc[i].Id);

            byte[] msg = Serialize(my_proc);

            //размер MailBox
            int MyProcSize = msg.Length;
           
            //Отправляем размер
            byte[] msgSize = BitConverter.GetBytes(MyProcSize);
         
            handler.Send(msgSize);

            //Отправляем Почт ящик
            handler.Send(msg);

          
        }
        void Close(Socket handler)
        {
           
            string data = null;
            byte[] bytes = new byte[1024];
            int bytesRec = handler.Receive(bytes);
            data = Encoding.Default.GetString(bytes, 0, bytesRec);
            Process[] local_procs = Process.GetProcesses();

            Process target_proc = local_procs.First(p => p.ProcessName == data);
            target_proc.Kill();
            byte[] msgSize = Serialize("Complete kill");
            //Отправляем Почт ящик
            handler.Send(msgSize);


        }
        void New(Socket handler)
        {

            string data = null;
            byte[] bytes = new byte[1024];
            int bytesRec = handler.Receive(bytes);
            data = Encoding.Default.GetString(bytes, 0, bytesRec);

            Process myProcess = new Process();

            try
            {
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = data;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.Start();
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }


        }

        void ThreadForReceive(object param)
        {
            Socket handler = (Socket)param;
            isConect = true;
            try
            {
                
                string client = null;
                string data = null;
                byte[] bytes = new byte[1024];
                // Получим от клиента DNS-имя хоста.
                // Метод Receive получает данные от сокета и заполняет массив байтов, переданный в качестве аргумента
                int bytesRec = handler.Receive(bytes); // Возвращает фактически считанное число байтов
                client = Encoding.Default.GetString(bytes, 0, bytesRec); // конвертируем массив байтов в строку
                client += "(" + handler.RemoteEndPoint.ToString() + ")";
                while (true)
                {
                    bytesRec = handler.Receive(bytes); // принимаем данные, переданные клиентом. Если данных нет, поток блокируется
                    if (bytesRec == 0)
                    {
                        handler.Shutdown(SocketShutdown.Both); // Блокируем передачу и получение данных для объекта Socket.
                        handler.Close(); // закрываем сокет
                        return;
                    }
                    data = Encoding.Default.GetString(bytes, 0, bytesRec); // конвертируем массив байтов в строку                  
          


                    if (data.IndexOf("end") > -1) // если клиент отправил эту команду, то заканчиваем обработку сообщений
                        break;
                    else if(data.IndexOf("update") > -1)
                        Update(handler);
                    else if (data.IndexOf("Close") > -1)
                        Close(handler);
                    else if (data.IndexOf("New") > -1)
                        New(handler);
                }

                //string theReply = "Я завершаю обработку сообщений";
                //byte[] msg = Encoding.Default.GetBytes(theReply); // конвертируем строку в массив байтов
                //handler.Send(msg); // отправляем клиенту сообщение
                isConect = false;
                isNewSocet = false;
                handler.Shutdown(SocketShutdown.Both); // Блокируем передачу и получение данных для объекта Socket.
                handler.Close(); // закрываем сокет
            }
            catch (Exception ex)
            {
               
                handler.Shutdown(SocketShutdown.Both); // Блокируем передачу и получение данных для объекта Socket.
                handler.Close(); // закрываем сокет

               // MessageBox.Show("Сервер: " + ex.Message);
            }
        }

        //  ожидать запросы на соединение будем в отдельном потоке
         void ThreadForAccept()
        {
            try
            {
           
                // установим для сокета адрес локальной конечной точки
                // уникальный адрес для обслуживания TCP/IP определяется комбинацией IP-адреса хоста с номером порта обслуживания
                IPEndPoint ipEndPoint = new IPEndPoint(
                    IPAddress.Any /* Предоставляет IP-адрес, указывающий, что сервер должен контролировать действия клиентов на всех сетевых интерфейсах.*/,
                    port /* порт */);

                // создаем потоковый сокет
                Socket sListener = new Socket(AddressFamily.InterNetwork /*схема адресации*/, SocketType.Stream /*тип сокета*/, ProtocolType.Tcp /*протокол*/ );
                /* Значение InterNetwork указывает на то, что при подключении объекта Socket к конечной точке предполагается использование IPv4-адреса.
                   SocketType.Stream поддерживает надежные двусторонние байтовые потоки в режиме с установлением подключения, без дублирования данных и 
                   без сохранения границ данных. Объект Socket этого типа взаимодействует с одним узлом и требует предварительного установления подключения 
                   к удаленному узлу перед началом обмена данными. Тип Stream использует протокол Tcp и схему адресации AddressFamily.
                 */
                isNewSocet = true;
                // Чтобы сокет клиента мог идентифицировать потоковый сокет TCP, сервер должен дать своему сокету имя
                sListener.Bind(ipEndPoint); // Свяжем объект Socket с локальной конечной точкой.

                // Установим объект Socket в состояние прослушивания.
                sListener.Listen(10 /* Максимальная длина очереди ожидающих подключений.*/ );
                while (true)
                {
                    /* Блокируется поток до поступления от клиента запроса на соединение. При этом устанавливается связь имен клиента и сервера. 
                       Метод Accept извлекает из очереди ожидающих запросов первый запрос на соединение и создает для его обработки новый сокет.
                       Хотя новый сокет создан, первоначальный сокет продолжает слушать и может использоваться с многопоточной обработкой для 
                       приема нескольких запросов на соединение от клиентов. Сервер не должен закрывать слушающий сокет, который продолжает работать
                       наряду с сокетами, созданными методом Accept для обработки входящих запросов клиентов.
                     */
                    Socket handler = sListener.Accept();
                    // обслуживание текущего запроса будем выполнять в отдельном потоке
                    Thread thread = new Thread(new ParameterizedThreadStart(ThreadForReceive));
                    thread.IsBackground = true;
                    thread.Start(handler);
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Сервер: " + ex.Message);
            }
        }


        public void New_connect()
        {
            isConect = false;
            Thread thread = new Thread(new ThreadStart(ThreadForAccept));
            thread.IsBackground = true;
            thread.Start();
        }
      
    }
}
