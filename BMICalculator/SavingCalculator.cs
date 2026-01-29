using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    internal class SavingCalculator
    {
        private double years;
        private double months;
        private double deposit;
        private double yearly_interest=0.1;
        private double amount_paid;
        private double balance;
         
        public SavingCalculator() { 
        }

        public double calculateSaving(out bool pass) {
            double rate = this.yearly_interest / 12;
            pass = false;
            this.months = 12*this.years;
            this.amount_paid = this.months * this.deposit;
            this.balance = 0;

            if (this.deposit > 0 && this.years > 0)
            {
               for (int i = 1; i <= months; i++)
                {
                    double interest = rate * this.balance;
                    this.balance += interest + this.deposit;
                }
                pass = true;
            }
            return this.balance; }
        





        public double getYears() { return this.years; }
        public double getMonths() { return this.months;}
        public double getDeosit() {  return this.deposit; }
        public double getAmount_paid() {  return this.amount_paid; }
        public double getBalance() { return this.balance; }


        public void setYears(double years) {  this.years = years; }
        public void setDeposit(double deposit) { this.deposit = deposit; }
        
    }
}
