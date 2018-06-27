using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conductor
{
    class P_Global
    {
         FileInfo fi;
        private readonly I_Global _viwe;
        private readonly Histori model;
        //  private readonly 
        public P_Global(I_Global viwe)
        {
            model = new Histori();
            _viwe = viwe;
            _viwe.Close_Program += new EventHandler<EventArgs>(Close_Program);
            _viwe.Open_Tree += new EventHandler<EventArgs>(Open_Tree);
            _viwe.Close_Tree += new EventHandler<EventArgs>(Close_Tree);
            _viwe.Open_Folder_in_Tree += new EventHandler<EventArgs>(Open_Folder_in_Tree);
            _viwe.Edit_List_Viwe += new EventHandler<EventArgs>(Edit_List_Viwe);
            _viwe.Up += new EventHandler<EventArgs>(Up);
            _viwe.End += new EventHandler<EventArgs>(End);
            _viwe.Move_ += new EventHandler<EventArgs>(Move_);
            _viwe.Start_program += new EventHandler<EventArgs>(Start_program);
            _viwe.Renewal += new EventHandler<EventArgs>(Renewal);
            _viwe.Remove_Die_Path += new EventHandler<EventArgs>(Remove_Die_Path);
            _viwe.ViweItem += new EventHandler<EventArgs>(ViweItem);
        }
        public void Remove_Die_Path(object sender, EventArgs e)
        {
            model.Dell_Histori_element(model.Now_Histori());
        }

        public void Close_Program(object sender, EventArgs e)
        {

        }
        public void Close_Tree(object sender, EventArgs e)
        {
            model.Dell_Tree(_viwe.Full_Path_Note);
        }
        public void ViweItem(object sender, EventArgs e)
        {
            if(_viwe.NameItem== "ToolStripMenuItem1")
            {

            }
            else if(_viwe.NameItem == "ToolStripMenuItem2")
            {
                //




            }
            else if (_viwe.NameItem == "ToolStripMenuItem3")
            {

            }
            else if (_viwe.NameItem == "ToolStripMenuItem4")
            {

            }
        }
        public void Open_Tree(object sender, EventArgs e)
        {
            string[] str = Directory.GetDirectories((@"" + _viwe.Full_Path_Note), "*.*");
          

            model.Add_Tree(_viwe.Full_Path_Note);
            

            for (int i = 0; i < str.Length; i++)
            {
                try
                {
                    fi = new FileInfo(str[i]);
                    string[] str2 = Directory.GetDirectories((@"" + fi.FullName), "*.*");
                    _viwe.Name_Notee_List.Add(fi.Name);
                    _viwe.Full_Path_Note_List.Add(fi.FullName);

                    if (str2.Length > 0)
                    {
                        _viwe.Name_Notee_element_List.Add(1);
                    }
                    else
                        _viwe.Name_Notee_element_List.Add(0);
                }
                catch (Exception ex)
                {

                };
            }
        }

        public void Open_Folder_in_Tree(object sender, EventArgs e)
        {
            
            model.Add_Histori(_viwe.Full_Path_Note.Replace("\\\\", "\\"));

            string temp = _viwe.Full_Path_Note.Replace("\\\\", "\\");
            string[] str1 = Directory.GetDirectories(@"" + temp, "*.*");
            string[] str2 = Directory.GetFiles(@"" + temp, "*.*");
            int length = str1.Length;
            Array.Resize(ref str1, str1.Length + str2.Length);
            Array.Copy(str2, 0, str1, length, str2.Length);


            Info(str1);
            _viwe.str = str1;

        }
        public void Edit_List_Viwe(object sender, EventArgs e)
        {

        }
        //g - LogicalDrives

        private void Info(string[] str1)
        {
            for (int i = 0; i < str1.Length; i++)
            {
                fi = new FileInfo(str1[i]);
                try
                {
                  
                    _viwe.Date_Edit_element_List.Add(fi.LastWriteTimeUtc.ToString());                                     
                }
                catch
                {
                    _viwe.Date_Edit_element_List.Add("");                   
                }
                try
                {                 
                    _viwe.Type_element_List.Add(File.GetAttributes(str1[i]).ToString());                   
                }
                catch
                {                
                    _viwe.Type_element_List.Add("");                  
                }
                try
                {
                    _viwe.Size_element_List.Add(fi.Length.ToString());
                }
                catch
                {               
                    _viwe.Size_element_List.Add("none");
                }
            }
        }
        public void Up(object sender, EventArgs e)
        {

            string _temp;
            string temp = _temp = model.Now_Histori();
            string[] str1;
            string[] str2;
            if ("none" != temp)
            {
                if(temp != "g")
                {
                    int i = temp.LastIndexOf('\\');
                    if(temp.Length-1==i)
                    {
                        temp = temp.Substring(0, i);
                    }
                    else
                    {
                        temp = temp.Substring(0, i);
                        if (temp[temp.Length - 1] == ':')
                            temp += '\\';
                    }
                   
                }

                ////// ////// ////// ////// ////// ////// ////// //////
                if (temp == "g")
                {
                    str1 = Directory.GetLogicalDrives();
                }
                else if (temp[temp.Length - 1] == ':')
                {
                    str1 = Directory.GetLogicalDrives();
                    temp = _temp;
                }
                else
                {
                    str1 = Directory.GetDirectories(@"" + temp, "*.*");
                    str2 = Directory.GetFiles(@"" + temp, "*.*");

                    int length = str1.Length;

                    Array.Resize(ref str1, str1.Length + str2.Length);
                    Array.Copy(str2, 0, str1, length, str2.Length);

                }
                Info(str1);

                ////// ////// ////// ////// ////// ////// ////// //////
                _viwe.str = str1;
                model.Add_Histori(temp);
            }
            else
            {
                _viwe.str = null;
            }
        }
        public void End(object sender, EventArgs e)
        {
            string _temp;
            string temp = _temp = model.Back_Histori();
          
            string[] str1;
            string[] str2;
            if ("none" != temp)
            {
               


                if (temp == "g")
                {
                    str1 = Directory.GetLogicalDrives();
                }
             
                else
                {
                    str1 = Directory.GetDirectories(@"" + temp, "*.*");
                    str2 = Directory.GetFiles(@"" + temp, "*.*");

                    int length = str1.Length;

                    Array.Resize(ref str1, str1.Length + str2.Length);
                    Array.Copy(str2, 0, str1, length, str2.Length);

                  
                }
                Info(str1);
                _viwe.str = str1;
               
            }
            else
            {
                _viwe.str = null;
            }
        }
        public void Move_(object sender, EventArgs e)
        {
            string _temp;
            string temp = _temp = model.Move_Histori();
            string[] str1;
            string[] str2;
            if ("none" != temp)
            {
                


                if (temp == "g")
                {
                    str1 = Directory.GetLogicalDrives();
                }             
                else
                {
                    str1 = Directory.GetDirectories(@"" + temp, "*.*");
                    str2 = Directory.GetFiles(@"" + temp, "*.*");

                    int length = str1.Length;

                    Array.Resize(ref str1, str1.Length + str2.Length);
                    Array.Copy(str2, 0, str1, length, str2.Length);
                }
                Info(str1);
                _viwe.str = str1;
            }
            else
            {
                _viwe.str = null;
            }
        }
        public void Start_program(object sender, EventArgs e)
        {
            string[] str1 = Directory.GetLogicalDrives();
            int length = str1.Length;
            _viwe.str = str1;




            ////////////////////////////////////
          



                string[] astrLogicalDrives = System.IO.Directory.GetLogicalDrives(); // System.Environment.GetLogicalDrives();    

            foreach (string disk in astrLogicalDrives)
                _viwe.Name_Notee_List.Add(disk);
            string[] str = null;
            for (int element = 0; element < astrLogicalDrives.Length; element++)
            {
                try
                {
                    str = System.IO.Directory.GetDirectories((@"" + astrLogicalDrives[element]), "*.*");
                    if (str.Length > 0)
                    {
                        _viwe.Name_Notee_element_List.Add(1);
                    }
                    else
                        _viwe.Name_Notee_element_List.Add(0);
                }
                catch
                {
                    _viwe.Name_Notee_element_List.Add(0);
                }
            }
            Info(str1);

            model.Add_Histori("g");
        }
      

        public void Renewal(object sender, EventArgs e)
        {
           
            for (string s = model.Move_Tree(); s != "none"; s = model.Move_Tree())
            {
                _viwe.Name_Notee_element_List_Tree.Add(s);
                string[] str = System.IO.Directory.GetDirectories((@"" +s ), "*.*");
                FileInfo fi;

                for (int i = 0; i < str.Length; i++)
                {
                    try
                    {
                        fi = new FileInfo(str[i]);
                        string[] str2 = System.IO.Directory.GetDirectories((@"" + fi.FullName), "*.*");
                        _viwe.Name_Notee_List.Add(fi.Name);
                        _viwe.Full_Path_Note_List.Add(fi.FullName);

                        if (str2.Length > 0)
                        {
                            _viwe.Name_Notee_element_List.Add(1);
                        }
                        else
                            _viwe.Name_Notee_element_List.Add(0);
                    }
                    catch (Exception ex)
                    {

                    };
                }
            }

            string temp = model.Now_Histori().Replace("\\\\", "\\");
            string[] str1, str3;
            if (temp == "g")
            {
                str1 = Directory.GetLogicalDrives();
            }
            else
            {
                str1 = Directory.GetDirectories(@"" + temp, "*.*");
                str3 = Directory.GetFiles(@"" + temp, "*.*");

                int length = str1.Length;

                Array.Resize(ref str1, str1.Length + str3.Length);
                Array.Copy(str3, 0, str1, length, str3.Length);
            }
            _viwe.str = str1;



        }
    }
}


//public void Up(object sender, EventArgs e)
//{
//    //string temp1 = model.Now_Histori();
//    string temp = model.Back_Histori();
//    //string _temp = temp;
//    //string _temp1 = temp;

//    if ("none" != temp)
//    {

//        /*if (temp != "g")
//        {
//            int i = temp.LastIndexOf('\\');
//            temp = temp.Substring(0, i);
//            _temp1 = _temp1.Substring(0, i);
//            _temp1 += "\\";
//        }
//        if (_temp1 == _temp)
//        {
//            string[] temps = Directory.GetLogicalDrives();
//            _viwe.str = temps;
//            model.Add_Histori("g");
//            return;
//        }
//        else if (temp[temp.Length - 1] == ':')
//        {
//            temp += "\\";
//        }*/
//        model.Add_Histori(temp);

//        string[] str1 = Directory.GetDirectories(@"" + temp, "*.*");
//        string[] str2 = Directory.GetFiles(@"" + temp, "*.*");

//        int length = str1.Length;

//        Array.Resize(ref str1, str1.Length + str2.Length);
//        Array.Copy(str2, 0, str1, length, str2.Length);

//        _viwe.str = str1;
//    }
//    else
//    {
//        _viwe.str = null;
//    }
//}
//public void End(object sender, EventArgs e)
//{
//    // string temp1 = model.Now_Histori();
//    string temp = model.Back_Histori();
//    //string _temp = temp;
//    //string _temp1 = temp;

//    if ("none" != temp)
//    {
//        //if (temp != "g" && temp1 != "g")
//        //{

//        //    int i = temp.LastIndexOf('\\');
//        //    temp = temp.Substring(0, i);

//        //    _temp1 = _temp1.Substring(0, i);
//        //    _temp1 += "\\";
//        //}

//        //if (_temp1 == _temp&& temp1!="g")
//        //{
//        //    string[] temps = Directory.GetLogicalDrives();
//        //    _viwe.str = temps;
//        //    model.Add_Histori("g");
//        //    return;
//        //}
//        //else if (temp[temp.Length - 1] == ':')
//        //{
//        //    temp += "\\";
//        //}

//        string[] str1 = Directory.GetDirectories(@"" + temp, "*.*");
//        string[] str2 = Directory.GetFiles(@"" + temp, "*.*");
//        int length = str1.Length;
//        Array.Resize(ref str1, str1.Length + str2.Length);
//        Array.Copy(str2, 0, str1, length, str2.Length);
//        _viwe.str = str1;
//    }
//    else
//    {
//        _viwe.str = null;
//    }
//}
//public void Move_(object sender, EventArgs e)
//{
//    //string temp1 = model.Now_Histori();
//    string temp = model.Move_Histori();
//    // string _temp = temp;
//    // string _temp1 = temp;

//    if ("none" != temp)
//    {
//        //if (temp != "g" && temp1 != "g")
//        //{


//        //    int i = temp.LastIndexOf('\\');
//        //    temp = temp.Substring(0, i);

//        //    _temp1 = _temp1.Substring(0, i);
//        //    _temp1 += "\\";
//        //}

//        //if (_temp1 == _temp)
//        //{
//        //    string[] temps = Directory.GetLogicalDrives();
//        //    _viwe.str = temps;
//        //    model.Add_Histori("g");
//        //    return;
//        //}
//        //else if (temp[temp.Length - 1] == ':')
//        //{
//        //    temp += "\\";
//        //}

//        string[] str1 = Directory.GetDirectories(@"" + temp, "*.*");
//        string[] str2 = Directory.GetFiles(@"" + temp, "*.*");
//        int length = str1.Length;
//        Array.Resize(ref str1, str1.Length + str2.Length);
//        Array.Copy(str2, 0, str1, length, str2.Length);
//        _viwe.str = str1;
//    }
//    else
//    {
//        _viwe.str = null;
//    }
//}