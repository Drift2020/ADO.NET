﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Market
{
    /// <summary>
    /// Interaction logic for Add_and_Edit_Firm.xaml
    /// </summary>
    public partial class Add_and_Edit_Firm : Window
    {
        public Add_and_Edit_Firm()
        {
            InitializeComponent();
          //  txtNum.Text = _numValue.ToString();
        }


        //#region UpDown
        //private int _numValue = 0;

        //public int NumValue
        //{
        //    get { return _numValue; }
        //    set
        //    {
        //        _numValue = value;
        //        txtNum.Text = value.ToString();
        //    }
        //}



        //private void cmdUp_Click(object sender, RoutedEventArgs e)
        //{
        //    NumValue++;
        //}

        //private void cmdDown_Click(object sender, RoutedEventArgs e)
        //{
        //    NumValue--;
        //}

        //private void txtNum_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (txtNum == null)
        //    {
        //        return;
        //    }

        //    if (!int.TryParse(txtNum.Text, out _numValue))
        //        txtNum.Text = _numValue.ToString();
        //}
        //#endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
