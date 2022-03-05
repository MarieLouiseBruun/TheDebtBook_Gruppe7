using Prism.Ioc;
using System.Windows;
using TheDebtBook_Gruppe7.Model; 
using TheDebtBook_Gruppe7.Views;
using TheDebtBook_Gruppe7.ViewModels;  

namespace TheDebtBook_Gruppe7
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public Debitor Debitor { get; set; }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<DebitorDetails, DebitorDetailsViewModel>();
            containerRegistry.RegisterDialog<AddNewDebitor, AddNewDebitorViewModel>();
        }
    }
}
