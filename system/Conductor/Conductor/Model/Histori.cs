using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conductor
{
    class Histori
    {
        private List<string> list;
        private List<string> openTree;
        private int element_l;
        private int element_o;
        public Histori()
        {
            element_l = 0;
            list = new List<string>();
            openTree = new List<string>();
        }
        public void Add_Tree(string s)
        {
            
           
            openTree.Add(s);
        }
        public void Dell_Tree(string s)
        {
            openTree.Remove(s);
        }
        public void Clean_Tree()
        {
            openTree.Clear();
        }
        public string Move_Tree()
        {
            if (element_o < openTree.Count)
            {
             

                return openTree[element_o++];
            }
            else
            {
                element_o = 0;
                return "none";
            }
        }

        public void Add_Histori(string s)
        {
            if(list.Count>0)
            element_l++;

            list.Add(s);
        }
        public string Move_Histori()
        {
            if (element_l < list.Count-1)
            {
                ++element_l;
                return list[element_l];
            }
            else
                return "none";
        }
        public string Back_Histori()
        {
            if (element_l > 0)
            {
                --element_l;
                return list[element_l];
            }
            else
                return "none";
        }
        public string Now_Histori()
        {
            return list[element_l];
        }
        public void Clean_Histori()
        {
            list.Clear();
        }
        public void Dell_Histori_element(string s)
        {
            element_l--;
            list.Remove(s);
        }
    }
}
