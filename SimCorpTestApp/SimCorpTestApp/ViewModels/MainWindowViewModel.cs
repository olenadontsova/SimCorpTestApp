using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimCorpTestApp
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public decimal BankRate { get => 2.5M; }
        private BussinessInterestRateCalculation BussinessInterestRateCalculation { get; }

        private DateTime agreementtDate;
        public DateTime AgreementtDate
        {
            get { return agreementtDate; }
            set
            {
                agreementtDate = value;
                OnPropertyChanged(nameof(AgreementtDate));
            }
        }

        private uint term = 0;
        public uint Term
        {
            get { return term; }
            set
            {
                term = value;

                OnPropertyChanged(nameof(Term));
            }
        }

        private decimal investments = 0;
        public decimal Investments
        {
            get { return investments; }
            set
            {
                investments = value;
                OnPropertyChanged(nameof(Investments));
            }
        }

        private decimal bussinessRate = 0;
        public decimal BussinessRate
        {
            get { return bussinessRate; }
            set
            {
                bussinessRate = value;
                OnPropertyChanged(nameof(BussinessRate));
            }
        }

        private decimal totalSum;
        public decimal TotalSum
        {
            get { return totalSum; }

        }
        private decimal profit;
        public decimal Profit
        {
            get { return profit; }
        }

        public MainWindowViewModel()
        {
            BussinessInterestRateCalculation = new BussinessInterestRateCalculation();
            IsValid = true;
        }
        public void Calculate()
        {
            Validating();
            
            if (IsValid)
            {
                decimal result = 0;
                result = BussinessInterestRateCalculation.GetTotalSumOfPersents(Term, BussinessRate, Investments);

                totalSum = result;
                profit = result - Investments;

                OnPropertyChanged(nameof(TotalSum));
                OnPropertyChanged(nameof(Profit));
            }
        }

        //Validation
        private ICollection<string> errorList;
        public ICollection<string> ErrorList
        {
            get => errorList;
            set { errorList = value; OnPropertyChanged(nameof(ErrorList)); }
        }
        private bool isValid;
        public bool IsValid
        {
            get => isValid;
            set { isValid = value; OnPropertyChanged(nameof(IsValid)); }
        }

        private bool Validating()
        {
            IsValid = true;
            ErrorList = new List<string>();

            if (BussinessRate > 20) ErrorList.Add($"Bussiness rate can not be more than 20%.");
            if (BussinessRate < BankRate) ErrorList.Add($"Bussiness rate can not be lower than Bank rate.");
            if (Term == 0) ErrorList.Add("Term should be more than 0.");
            if (Term > 10) ErrorList.Add("Term can not be more than 10 years.");
            if (Investments < 1000) ErrorList.Add("Summ should be al least 1000");

            if (ErrorList.Any())
            {
                isValid = false;
                OnPropertyChanged(nameof(IsValid));
               
            }

            return IsValid;
        }
        //Implemenation INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
