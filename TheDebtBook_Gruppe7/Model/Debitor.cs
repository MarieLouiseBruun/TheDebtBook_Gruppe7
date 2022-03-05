using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TheDebtBook_Gruppe7.Model
{
    
    public class Debitor
    {
        private string name;
        private ObservableCollection<Debt> debtList;

        public Debitor()
        {

        }

        public Debitor(string name,ObservableCollection<Debt> debtList)
        {
            this.name = name;
            this.debtList = debtList;           
        }

        public string Name
        {
            get
            {
                return name; 
            }
            set
            {
                name = value; 
            }
        }

        public ObservableCollection<Debt> DebtList
        {
            get
            {
                return debtList;
            }
            set
            {
                debtList = value;
            }
        }        

    }
}
