using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using TheDebtBook_Gruppe7.Model; 

namespace TheDebtBook_Gruppe7.ViewModels
{
    public class MainWindowViewModel : BindableBase, INotifyPropertyChanged
    {
        //------- TO-DO: 
        // 1. DetailsDialog - Data skal indsættes og trækkes ud 
        // 2. Listbox x 2 skal vise flere værdier på samme tid
        // 3. Rediger/gem ny fil
        // 4. Layout vha.resources


        private IDialogService dialogService; 
        private DebitorFileHandler fileHandler; 
        public ObservableCollection<Debitor> DebitorList { get; set; }

        private string _title = "The Debt Book";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            fileHandler = new DebitorFileHandler();

            DebitorList = fileHandler.ReadFromFile(); 

        }

        private Debitor currentDebitor;
        public Debitor CurrentDebitor
        {
            get
            {
                return currentDebitor;
            }
            set
            {
                SetProperty(ref currentDebitor, value);
                NotifyPropertyChanged();
            }
        }

        private int currentIndex;
        public int CurrentIndex
        {
            get
            {
                return currentIndex;
            }
            set
            {
                SetProperty(ref currentIndex, value);
                NotifyPropertyChanged();
            }
        }

        //Eventhandler and invoking event 
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        //Custom methods 
        public void AddNewDebitor(Debitor newDebitor)
        {
            DebitorList.Add(newDebitor);

        }

        //Commands

        private DelegateCommand addDebitorCommand;
        public DelegateCommand AddDebitorCommand =>
            addDebitorCommand ?? (addDebitorCommand = new DelegateCommand(ExecuteAddDebitorCommand));

        void ExecuteAddDebitorCommand()
        {
           
            var tempDebitor = new Debitor();

            ((App)Application.Current).Debitor = tempDebitor;

            //------ Titlen ændrer sig ikke! 

            dialogService.ShowDialog("AddNewDebitor", new DialogParameters(""), r =>
            {
                if (r.Result == ButtonResult.None)
                {
                    Title = "Result is None"; 
                }

                else if (r.Result == ButtonResult.OK)
                {
                    Title = "Result is OK";

                    Debitor newDebitor = ((App)Application.Current).Debitor; 
                    AddNewDebitor(newDebitor);
                }
                else if (r.Result == ButtonResult.Cancel)
                    Title = "Result is Cancel";
                else
                    Title = "I Don't know what you did!?";
            });

        }

        private DelegateCommand openDetailsCommand;
        public DelegateCommand OpenDetailsCommand =>
            openDetailsCommand ?? (openDetailsCommand = new DelegateCommand(ExecuteOpenDetailsCommand));

        void ExecuteOpenDetailsCommand()
        {
            ((App)Application.Current).Debitor = CurrentDebitor; 

            dialogService.ShowDialog("DebitorDetails", new DialogParameters(""), r =>
            {
                if (r.Result == ButtonResult.None)
                {
                    Title = "Result is None";
                }

                else if (r.Result == ButtonResult.OK)
                {
                    Title = "Result is OK";                  
                }
                else if (r.Result == ButtonResult.Cancel)
                    Title = "Result is Cancel";
                else
                    Title = "I Don't know what you did!?";
            });

        }
    }
}
