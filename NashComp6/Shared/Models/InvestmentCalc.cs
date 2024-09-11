using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NashComp6.Shared.Models
{
    public class InvestmentCalc
    {
        //Fields
        private int compPerYr;
        private int years;
        private double principal;
        private double interest;
        public bool errors { get; set; }

        //Properties
        public int CompPerYr
        {
            get { return compPerYr; }
            set
            {
                compPerYr = value;
                NegativeCheck();
                if (value < 0)
                {
                    throw new Exception("Must be positive values");
                }
                
                Calc();
            }
        }

        public int Years
        {
            get { return years; }
            set
            {
                years = value;
                NegativeCheck();
                if (value < 0)
                {
                    throw new Exception("Must be positive values");
                }
                
                Calc();
            }
        }

        public double Principal
        {
            get { return principal; }
            set 
            {
                principal = value;
                NegativeCheck();
                if (value < 0)
                {
                    throw new Exception("Must be positive values");
                }
                
                Calc(); 
            }
        }

        public double Interest
        {
            get { return interest; }
            set 
            {
                interest = value;
                NegativeCheck();
                if (value < 0)
                {                    
                    throw new Exception("Must be positive values");
                }
                
                Calc();
            }
        }

        public double FutureValue { get; private set; }

        //Constructors
        public InvestmentCalc()
        {

        }

        public InvestmentCalc(double principle, int years, double interest, int compPerYr)
        {
            Principal = principle;
            Years = years;
            Interest = interest;
            CompPerYr = compPerYr;
        }

        //Methods
        private void Calc()
        {
            FutureValue = Principal * Math.Pow((1 + (Interest / CompPerYr)), (CompPerYr * Years));

            FutureValue = Math.Round(FutureValue, 2);
        }

        private bool NegativeCheck()
        {
            if (principal >= 0 && years >= 0 && interest >= 0 && compPerYr >= 0)
            {
                errors = false;
            }
            else
            {
                errors = true;
            }
            return errors;
        }
    }
}
