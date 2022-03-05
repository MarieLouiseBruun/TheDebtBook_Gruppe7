using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using TheDebtBook_Gruppe7.Model; 

namespace TheDebtBook_Gruppe7.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DebitorFileHandler reader;

        public MainWindow()
        {

            InitializeComponent();

            //reader = new DebitorFileHandler();

            //Debt debt1 = new Debt(100, System.DateTime.Now);
            //Debt debt2 = new Debt(-100, System.DateTime.Now);

            //ObservableCollection<Debt> debtList = new ObservableCollection<Debt>();
            //debtList.Add(debt1);
            //debtList.Add(debt2);

            //Debitor debitor1 = new Debitor("Marie", debtList,0);
            //Debitor debitor2 = new Debitor("Dina", debtList,0);

            //ObservableCollection<Debitor> debitorList = new ObservableCollection<Debitor>();
            //debitorList.Add(debitor1);
            //debitorList.Add(debitor2);

            //reader.CreateFile(debitorList);
        }
    }
}
