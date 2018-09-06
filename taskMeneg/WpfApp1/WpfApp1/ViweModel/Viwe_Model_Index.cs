using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1.ViweModel
{
    class Viwe_Model_Index: View_Model_Base
    {


        #region Text

        string connect;
        public string Connect
        {
            get{ return connect;  }
            set { connect = value; }
        }
        #endregion Text



        #region Button Connect

        private DelegateCommand _Command_button_Connect;
        public ICommand Button_connect
        {
            get
            {
                if (_Command_button_Connect == null)
                {
                    _Command_button_Connect = new DelegateCommand(Execute_button_Connect, CanExecute_button_Connect);
                }
                return _Command_button_Connect;
            }
        }
        private void Execute_button_Connect(object o)
        {
           


        }
        private bool CanExecute_button_Connect(object o)
        {
            if (connect != null && connect.Length > 0)
                return true;
            else
                return false;
        }

        #endregion Button Connect

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
            return true;
        }

        #endregion Button disconnect

        #region Button update

        private DelegateCommand _Command_button_update;
        public ICommand Button_update
        {
            get
            {
                if (_Command_button_update == null)
                {
                    _Command_button_update = new DelegateCommand(Execute_button_update, CanExecute_button_update);
                }
                return _Command_button_update;
            }
        }
        private void Execute_button_update(object o)
        {

        }
        private bool CanExecute_button_update(object o)
        {
            return true;
        }

        #endregion Button update

        #region Button create_task

        private DelegateCommand _Command_button_create_task;
        public ICommand Button_create_task
        {
            get
            {
                if (_Command_button_create_task == null)
                {
                    _Command_button_create_task = new DelegateCommand(Execute_button_create_task, CanExecute_button_create_task);
                }
                return _Command_button_create_task;
            }
        }
        private void Execute_button_create_task(object o)
        {

        }
        private bool CanExecute_button_create_task(object o)
        {
            return true;
        }

        #endregion Button create_task

        #region Button close_task

        private DelegateCommand _Command_button_close_task;
        public ICommand Button_close_task
        {
            get
            {
                if (_Command_button_close_task == null)
                {
                    _Command_button_close_task = new DelegateCommand(Execute_button_close_task, CanExecute_button_close_task);
                }
                return _Command_button_close_task;
            }
        }
        private void Execute_button_close_task(object o)
        {

        }
        private bool CanExecute_button_close_task(object o)
        {
            return true;
        }

        #endregion Button create_task



        private void Connect()
        {
            // соединяемся с удаленным устройством
            try
            {
                IPAddress ipAddr = IPAddress.Parse(ip_address.Text);

                // устанавливаем удаленную конечную точку для сокета
                // уникальный адрес для обслуживания TCP/IP определяется комбинацией IP-адреса хоста с номером порта обслуживания
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddr /* IP-адрес */, 49152 /* порт */);

                // создаем потоковый сокет
                sock = new Socket(AddressFamily.InterNetwork /*схема адресации*/, SocketType.Stream /*тип сокета*/, ProtocolType.Tcp /*протокол*/);
                /* Значение InterNetwork указывает на то, что при подключении объекта Socket к конечной точке предполагается использование IPv4-адреса.
                  SocketType.Stream поддерживает надежные двусторонние байтовые потоки в режиме с установлением подключения, без дублирования данных и 
                  без сохранения границ данных. Объект Socket этого типа взаимодействует с одним узлом и требует предварительного установления подключения 
                  к удаленному узлу перед началом обмена данными. Тип Stream использует протокол Tcp и схему адресации AddressFamily.
                */

                // соединяем сокет с удаленной конечной точкой
                sock.Connect(ipEndPoint);
                byte[] msg = Encoding.Default.GetBytes(Dns.GetHostName() /* имя узла локального компьютера */);// конвертируем строку, содержащую имя хоста, в массив байтов
                int bytesSent = sock.Send(msg); // отправляем серверу сообщение через сокет
                MessageBox.Show("Клиент " + Dns.GetHostName() + " установил соединение с " + sock.RemoteEndPoint.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Клиент: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(Connect));
            thread.IsBackground = true;
            thread.Start();
        }

        private void Exchange()
        {
            try
            {
                string theMessage = textBox1.Text; // получим текст сообщения, введенный в текстовое поле
                byte[] msg = Encoding.Default.GetBytes(theMessage); // конвертируем строку, содержащую сообщение, в массив байтов
                int bytesSent = sock.Send(msg); // отправляем серверу сообщение через сокет
                if (theMessage.IndexOf("<end>") > -1) // если клиент отправил эту команду, то принимаем сообщение от сервера
                {
                    byte[] bytes = new byte[1024];
                    int bytesRec = sock.Receive(bytes); // принимаем данные, переданные сервером. Если данных нет, поток блокируется
                    MessageBox.Show("Сервер (" + sock.RemoteEndPoint.ToString() + ") ответил: " + Encoding.Default.GetString(bytes, 0, bytesRec) /*конвертируем массив байтов в строку*/);
                    sock.Shutdown(SocketShutdown.Both); // Блокируем передачу и получение данных для объекта Socket.
                    sock.Close(); // закрываем сокет
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Клиент: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(Exchange));
            thread.IsBackground = true;
            thread.Start();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                sock.Shutdown(SocketShutdown.Both); // Блокируем передачу и получение данных для объекта Socket.
                sock.Close(); // закрываем сокет
            }
            catch (Exception ex)
            {
                MessageBox.Show("Клиент: " + ex.Message);
            }
        }
    }
}
