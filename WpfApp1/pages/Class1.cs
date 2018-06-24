using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp4
{
    class Home :Page
    {
        public void   Upload () { 
        OpenFileDialog fileDialog = new OpenFileDialog();
        fileDialog.DefaultExt = ".txt"; // Required file extension 
        fileDialog.Filter = "Text documents (.txt)|*.txt"; // Optional file extensions

         fileDialog.ShowDialog(); 
        }
    }
}
