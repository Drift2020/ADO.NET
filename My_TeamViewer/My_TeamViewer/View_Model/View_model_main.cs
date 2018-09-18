using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace My_TeamViewer
{
    class View_model_main: View_Model_Base
    {
        public View_model_main()
        {

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

        public SynchronizationContext uiContext;

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
         
        }
        private bool CanExecute_button_connect(object o)
        {
           
            return false;
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

        }
        private bool CanExecute_button_open(object o)
        {

            return false;
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
                        // Принимаем ожидающий запрос на подключение 
                        // Метод AcceptTcpClient — это блокирующий метод, возвращающий объект TcpClient, 
                        // который может использоваться для приема и передачи данных.
                        TcpClient client = listener.AcceptTcpClient();
                     //   ReadMessage(client);
                    }
                }
                catch (Exception ex)
                {
                   // MessageBox.Show("Сервер: " + ex.Message);
                }
            });
        }

        #endregion code
    }
}
