using System;
using System.Collections.Generic;
using System.Text;

namespace TheDebtBook_Gruppe7.Model
{
   
    public class Debt
    {
        private double amount;
        private DateTime date; 

        public Debt()
        {

        }

        public Debt(double amount,DateTime date)
        {
            this.amount = amount;
            this.date = date; 
        }
        
        public double Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }
    }
}
