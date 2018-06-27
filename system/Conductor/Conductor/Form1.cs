using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Conductor
{

    public partial class Form1 : Form, I_Global
    {
        public event EventHandler<EventArgs> Close_Program;
        public event EventHandler<EventArgs> Open_Tree;
        public event EventHandler<EventArgs> Close_Tree;
        public event EventHandler<EventArgs> Remove_Die_Path;
        public event EventHandler<EventArgs> Open_Folder_in_Tree;
        public event EventHandler<EventArgs> Edit_List_Viwe;
        public event EventHandler<EventArgs> Up;
        public event EventHandler<EventArgs> End;
        public event EventHandler<EventArgs> Move_;
        public event EventHandler<EventArgs> Start_program;
        public event EventHandler<EventArgs> Renewal;
        public event EventHandler<EventArgs> ViweItem;

        #region Pole

        // 1 element , 2 name, 3 full path, 4 elements element's, 5 name, 6 full path
        ImageList list = new ImageList();
        Size start_point,smal_size,big_size;
        bool start = true;
        List<int> name_Notee_element_List = new List<int>();
        List<string> full_Path_Note_List = new List<string>();
        List<string> name_Notee_element_List_Tree = new List<string>();
        List<string> name_Notee_List = new List<string>();
        List<string> date_Edit_element_List = new List<string>();
        List<string> size_element_List = new List<string>();
        List<string> type_element_List = new List<string>();

        ToolStripMenuItem tempMenuItem = null;
        public string[] str { set; get; }
        public string Name_Note { set; get; }
        public string Full_Path_Note { set; get; }

        public string NameItem { set; get; }
        public List<string> Full_Path_Note_List { set { full_Path_Note_List = value; } get { return full_Path_Note_List; } }
        public List<string> Name_Notee_List { set { name_Notee_List = value; } get { return name_Notee_List; } }
        public List<int> Name_Notee_element_List { set { name_Notee_element_List = value; } get { return name_Notee_element_List; } }
        public List<string> Name_Notee_element_List_Tree { set { name_Notee_element_List_Tree = value; } get { return name_Notee_element_List_Tree; } }
        public List<string> Date_Edit_element_List { set { date_Edit_element_List = value; } get { return date_Edit_element_List; } }
        public List<string> Size_element_List { set { size_element_List = value; } get { return size_element_List; } }
        public List<string> Type_element_List { set { type_element_List = value; } get { return type_element_List; } }
        #endregion Pole
        private void Form1_Load(object sender, EventArgs e)
        {
            Start_program?.Invoke(this, EventArgs.Empty);

            TreeNode node;

            // string[] astrLogicalDrives = System.IO.Directory.GetLogicalDrives(); // System.Environment.GetLogicalDrives();          
            for (int disk = 0; disk < name_Notee_List.Count; disk++)
            {
                node = treeViewPath1.Nodes.Add(name_Notee_List[disk]);


                node.Name = name_Notee_List[disk];
                if (name_Notee_element_List[disk] > 0)
                    node.Nodes.Add("1");
            }


            DravItem();
        }
        public Form1()
        {
            smal_size = new Size(18, 18);
            big_size = new Size(48, 48);
            start_point = new Size(32, 32);
            InitializeComponent();
            list.ColorDepth = ColorDepth.Depth32Bit;
            list.ImageSize = start_point;
            list.TransparentColor = Color.Transparent;
            listViewFolder1.FullRowSelect = true;
            listViewFolder1.LargeImageList = list;
            listViewFolder1.SmallImageList = list;
            ToolStripMenuItem3.Checked = true;
            NameItem = "ToolStripMenuItem3";
            tempMenuItem = ToolStripMenuItem3;
        }

        #region Button
       

        private void toolStripButtonEnd_Click(object sender, EventArgs e)
        {
            try
            {
                End?.Invoke(this, EventArgs.Empty);

                if (str != null)
                {

                    DravItem();
                }             
            }
            catch (Exception ex) { Remove_Die_Path?.Invoke(this, EventArgs.Empty);
                MessageBox.Show(ex.Message); }
        }

        private void toolStripButtonMove_Click(object sender, EventArgs e)
        {
            try
            {
                Move_?.Invoke(this, EventArgs.Empty);

                if (str != null)
                {

                    DravItem();
                }
            }
            catch (Exception ex) { Remove_Die_Path?.Invoke(this, EventArgs.Empty); MessageBox.Show(ex.Message); }
        }

        private void toolStripButtonUp_Click(object sender, EventArgs e)
        {
           
            try
            {
                Up?.Invoke(this, EventArgs.Empty);
                if (str != null)
                {

                    DravItem();
                }
            }
            catch (Exception ex) { Remove_Die_Path?.Invoke(this, EventArgs.Empty); MessageBox.Show(ex.Message); }
        }

        private void toolStripButtonRenewal_Click(object sender, EventArgs e)
        {
            Name_Notee_List.Clear();
            Full_Path_Note_List.Clear();
            Name_Notee_element_List.Clear();
            Name_Notee_element_List_Tree.Clear();

            Renewal?.Invoke(this, EventArgs.Empty);


            TreeNode node;



            for (int i1 = 0 ; i1 < Name_Notee_element_List_Tree.Count; i1++)
            {
                //.Find(Name_Notee_element_List_Tree[i1], true);
                TreeNodeCollection findTreeNodes = treeViewPath1.Nodes;
                TreeNode[] node1 = findTreeNodes.Find(Name_Notee_element_List_Tree[i1], false);
                node1[0].Nodes.Clear();
               //TreeNode[] findTreeNodes = treeViewPath1.Nodes.Find(Name_Notee_element_List_Tree[i1], false);

                // findTreeNodes[0].Nodes.Clear();

                for (int i = 0; i < name_Notee_List.Count; i++)
                {
                    if (Full_Path_Note_List[i].Contains(Name_Notee_element_List_Tree[i1]))
                    {
                        node = node1[0].Nodes.Add(name_Notee_List[i]);
                        node.Name = name_Notee_List[i];

                        if (name_Notee_element_List[i] > 0)
                            node.Nodes.Add("1");
                    }
                }
                ///////////////////
                //тут нужено добавление
                //////////
            }

            try
            {
                DravItem();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void DravItem()
        {
            list.Images.Clear();
            listViewFolder1.Clear();

            Win32.SHFILEINFO sh = new Win32.SHFILEINFO();
            if (str.Length == 0)
            {
                return;
            }         

            if (NameItem == "ToolStripMenuItem1")
            {
                listViewFolder1.View = View.List;
                list.ImageSize = smal_size;
                for (int i = 0; i < str.Length; i++)
                {
                    Win32.SHGetFileInfo(str[i], 0, ref sh, (uint)Marshal.SizeOf(sh),
                     Win32.SHGFI_ICON | Win32.SHGFI_LARGEICON | Win32.SHGFI_DISPLAYNAME);
                    Icon icon = Icon.FromHandle(sh.hIcon);
                    list.Images.Add(icon);
                    listViewFolder1.Items.Add(sh.szDisplayName, i);
                }
            }
            else if (NameItem == "ToolStripMenuItem2")
            {
             

                listViewFolder1.View = View.Details;



                listViewFolder1.Columns.Add("Имя", 100, HorizontalAlignment.Left);
                listViewFolder1.Columns.Add("Дата изменения", 60, HorizontalAlignment.Left);
                listViewFolder1.Columns.Add("Тип", 60, HorizontalAlignment.Left);
                listViewFolder1.Columns.Add("Размер", 60, HorizontalAlignment.Center);
                list.ImageSize = smal_size;
                for (int i = 0; i < str.Length; i++)
                {
                    Win32.SHGetFileInfo(str[i], 0, ref sh, (uint)Marshal.SizeOf(sh),
                     Win32.SHGFI_ICON | Win32.SHGFI_SMALLICON | Win32.SHGFI_DISPLAYNAME);
                    Icon icon = Icon.FromHandle(sh.hIcon);
                    list.Images.Add(icon);
                  

                    ListViewItem temp = listViewFolder1.Items.Add(sh.szDisplayName, i);
                    temp.SubItems.Add(date_Edit_element_List[i]);
                    temp.SubItems.Add(type_element_List[i]);
                    temp.SubItems.Add(size_element_List[i]);
                }

            }
            else if (NameItem == "ToolStripMenuItem3")
            {
                listViewFolder1.View = View.Tile;
                list.ImageSize = start_point;
                for (int i = 0; i < str.Length; i++)
                {
                    Win32.SHGetFileInfo(str[i], 0, ref sh, (uint)Marshal.SizeOf(sh),
                     Win32.SHGFI_ICON | Win32.SHGFI_LARGEICON | Win32.SHGFI_DISPLAYNAME);
                    Icon icon = Icon.FromHandle(sh.hIcon);
                    list.Images.Add(icon);
                    listViewFolder1.Items.Add(sh.szDisplayName, i);
                }
            }
            else if (NameItem == "ToolStripMenuItem4")
            {
                listViewFolder1.View = View.LargeIcon;
                list.ImageSize = big_size;
                for (int i = 0; i < str.Length; i++)
                {
                    Win32.SHGetFileInfo(str[i], 0, ref sh, (uint)Marshal.SizeOf(sh),
                     Win32.SHGFI_ICON | Win32.SHGFI_LARGEICON | Win32.SHGFI_DISPLAYNAME);
                    Icon icon = Icon.FromHandle(sh.hIcon);
                    list.Images.Add(icon);
                    listViewFolder1.Items.Add(sh.szDisplayName, i);
                }
            }
        }
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem nowItem = sender as ToolStripMenuItem;
            if (tempMenuItem != null)
                tempMenuItem.Checked = false;

            nowItem.Checked = true;
            NameItem = nowItem.Name;
            ViweItem?.Invoke(this, EventArgs.Empty);

            DravItem();


            tempMenuItem = nowItem;

        }
     
        #endregion Button

        private void treeViewPath1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            Name_Notee_List.Clear();
            Full_Path_Note_List.Clear();
            Name_Notee_element_List.Clear();

            TreeNode node;
            Name_Note = e.Node.Name;
            Full_Path_Note = e.Node.FullPath;

            Open_Tree?.Invoke(this, EventArgs.Empty);
            e.Node.Nodes.Clear();

            for (int i = 0; i < name_Notee_List.Count; i++)
            {
                node = e.Node.Nodes.Add(name_Notee_List[i]);
                node.Name = name_Notee_List[i];

                if (name_Notee_element_List[i] > 0)
                    node.Nodes.Add("1");
            }
            

        }
        private void treeViewPath1_AfterCollapse(object sender, TreeViewEventArgs e)
        {
          
            bool i = false;
            if (e.Node.Nodes.Count > 0)
                i = !i;
            e.Node.Nodes.Clear();

            Full_Path_Note = e.Node.FullPath;

            Close_Tree?.Invoke(this, EventArgs.Empty);

            if (i)
            {
                e.Node.Nodes.Add("1");
            }
            Name_Notee_List.Clear();
            Full_Path_Note_List.Clear();
            Name_Notee_element_List.Clear();
        }

        private void treeViewPath1_AfterSelect(object sender, TreeViewEventArgs e)
        {
           
            if (start)
            {
                start = !start;
                return;
            }
            try
            {
                date_Edit_element_List.Clear();
                size_element_List.Clear();
                type_element_List.Clear();

                Full_Path_Note = e.Node.FullPath;

                Open_Folder_in_Tree?.Invoke(this, EventArgs.Empty);

              
                DravItem();
                
            }
            catch (Exception ex) {
             
                    MessageBox.Show(ex.Message);
            }
        }

        private void toolStripSplitButtonTabl_ButtonClick(object sender, EventArgs e)
        {
            try
            {
                Edit_List_Viwe?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex) { Remove_Die_Path?.Invoke(this, EventArgs.Empty); MessageBox.Show(ex.Message); }
        }

       
    }
}