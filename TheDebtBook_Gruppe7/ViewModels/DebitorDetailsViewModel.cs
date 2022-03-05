using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using TheDebtBook_Gruppe7.Model;

namespace TheDebtBook_Gruppe7.ViewModels
{
    public class DebitorDetailsViewModel : BindableBase, IDialogAware
    {
        // Properties 
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private string _title = "Debitor Details";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private Debitor debitor;
        public Debitor Debitor
        {
            get { return debitor; }
            set { SetProperty(ref debitor, value); }
        }

        private double newDebt;
        public double NewDebt
        {
            get { return newDebt; }
            set { SetProperty(ref newDebt, value); }
        }

        public event Action<IDialogResult> RequestClose;

        //Inherited and custom methods
        void AddDebt()
        {
            // --------- Fix værdi!! 
            ObservableCollection<Debt> debtList = Debitor.DebtList;
            Debt debt = new Debt(NewDebt, DateTime.Now);
            debtList.Add(debt);

            //Debitor.DebtList = debtList; 
            ((App)Application.Current).Debitor = Debitor;
        }

        protected virtual void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;

            if (parameter?.ToLower() == "true")
                result = ButtonResult.OK;
            else if (parameter?.ToLower() == "false")
                result = ButtonResult.Cancel;

            RaiseRequestClose(new DialogResult(result));
        }

        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }

        public virtual bool CanCloseDialog()
        {
            return true;
        }

        public virtual void OnDialogClosed()
        {

        }

        public virtual void OnDialogOpened(IDialogParameters parameters)
        {
            Message = parameters.GetValue<string>("message");

            Debitor = ((App)Application.Current).Debitor;
        }

        //Commands 
        private DelegateCommand<string> closeDialogCommand;
        public DelegateCommand<string> CloseDialogCommand =>
            closeDialogCommand ?? (closeDialogCommand = new DelegateCommand<string>(CloseDialog));

        private DelegateCommand addDebtCommand;
        public DelegateCommand AddDebtCommand =>
            addDebtCommand ?? (addDebtCommand = new DelegateCommand(AddDebt));
    }
}
