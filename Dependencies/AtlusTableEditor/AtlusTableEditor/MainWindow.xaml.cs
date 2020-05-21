using AtlusTableEditor.Serialization;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AtlusTableEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var serializer = new TableSerializer();
            dynamic table = serializer.Deserialize<Persona5PS3EncounterTable>(@"D:\Modding\Persona 5\Dump\battle\table.pac files\table\ENCOUNT.TBL");
            serializer.Serialize(table, @"D:\Modding\Persona 5\Dump\battle\table.pac files\table\ENCOUNT.TBL_");

            table = serializer.Deserialize<Persona4.MessageTable>(@"D:\Modding\Persona 3 & 4\Persona4\CVM_BTL\BATTLE\MSG.TBL");
            serializer.Serialize(table, @"D:\Modding\Persona 3 & 4\Persona4\CVM_BTL\BATTLE\MSG.TBL_");


            InitializeComponent();
        }
    }
}
