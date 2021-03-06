﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class GUI
    {
       
        bool work=true;
        enum state { menu,config,connect,exit, edit,none };
        state my_state = state.menu;
        readonly box my_box;
        string my_lime;
        public GUI(box _box)
        {
            my_box = _box;
          
        }
        void Print()
        {
            Console.Clear();
            Console.WriteLine("-----------------------------");
            switch (my_state)
            {
                case state.menu:
                    Console.Write("1.Config\n2.New Connect\n3.Exit\nChose:");
                    break;
                case state.config:
                    Console.WriteLine("My IP:" + my_box.IP);
                    Console.WriteLine("My Host:" + my_box.Host);
                    Console.WriteLine("My Port:" + my_box.Port);
                    Console.WriteLine("Socet:" + my_box.isNewSocet);
                    Console.WriteLine("Connect client:" + my_box.isConect);
                    Console.WriteLine("4.End menu");
                    Console.WriteLine("5.Edit port");
                    Console.Write("Chose:");
                    break;
                case state.connect:

                    break;
                case state.exit:

                    break;
                case state.edit:
                    Console.Write("Old port:{0}\nNew port:",my_box.Port);
                    break;
            }

        }
        void Chose(string c)
        {
            if (c == "1")
            {
                my_state = state.config;
            }
            else if (c == "2")
            {
                my_state = state.connect;
            }
            else if (c == "3")
            {
                my_state = state.exit;
            }
            else if (c == "4")
            {
                my_state = state.menu;

            }
            else if (c == "5")
            {
                my_state = state.edit;
            }
            else
            {
                my_state = state.none;
            }
        }

        void Logic()
        {

            switch (my_state)
            {
                case state.menu:
                  
                    break;
                case state.config:

                    break;
                case state.connect:
                    my_box.New_connect();
                    my_state = state.menu;
                    break;
                case state.exit:
                    work = false;
                    break;
                case state.edit:
                    my_box.Port= Console.ReadLine();
                    my_state = state.menu;
                    break;
            }
        }


        public void Start()
        {
            do
            {

                Print();
                Logic();
                Print();
                string my_lime = Console.ReadLine();
                Chose(my_lime);
                
            } while (work);
        }
    }
}
