using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MyProcess;
namespace Server
{
   public class box
    {
        My_Process[] my_proc;
        int port= 49152;
        string host;
        System.Net.IPAddress ip;
       

        public string Host { get { return host; } }
        public string IP { get { return ip.ToString(); } }
        public string Port { get { return port.ToString(); } }
        public box()
        {
            host = System.Net.Dns.GetHostName();
            ip = System.Net.Dns.GetHostByName(host).AddressList[0];
            my_proc =new 
        }

        

         void ThreadForReceive(object param)
        {
            Socket handler = (Socket)param;
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
                    // uiContext.Send отправляет синхронное сообщение в контекст синхронизации
                    // SendOrPostCallback - делегат указывает метод, вызываемый при отправке сообщения в контекст синхронизации. 



                    //uiContext.Send(d => listBox1.Items.Add(client) /* Вызываемый делегат SendOrPostCallback */,
                    //    null /* Объект, переданный делегату */); // добавляем в список имя клиента


                    //uiContext.Send(d => listBox1.Items.Add(data), null); // добавляем в список сообщение от клиента


                    if (data.IndexOf("<end>") > -1) // если клиент отправил эту команду, то заканчиваем обработку сообщений
                        break;
                }
                string theReply = "Я завершаю обработку сообщений";
                byte[] msg = Encoding.Default.GetBytes(theReply); // конвертируем строку в массив байтов
                handler.Send(msg); // отправляем клиенту сообщение
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
            Thread thread = new Thread(new ThreadStart(ThreadForAccept));
            thread.IsBackground = true;
            thread.Start();
        }
      
    }
}
