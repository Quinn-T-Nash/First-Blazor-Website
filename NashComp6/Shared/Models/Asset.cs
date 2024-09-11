using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NashComp6.Shared.Models
{
    public class Asset
    {
        //Id for table
        public int Id { get; set; }

        //title for asset
        [Required]
        [MinLength(5)]
        public string Title { get; set; } = "";

        //value assest started at
        [Required]
        [Range(1, float.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public float StartingValue { get; set; } = 0;

        //Minimum value asset hits over its lifetime
        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public float SalvageValue { get; set; } = 0;

        [Required]
        public DateTime EnteredInventory {  get; set; } = DateTime.Now;

        [Required]
        private DateTime _leftInventory;
        public DateTime LeftInventroy 
        { 
            get { return _leftInventory; }
            set
            {
                if (value > EnteredInventory)
                {
                    _leftInventory = value;
                    CalcAnnualDeprec();
                }                

            }
        }

        //Annual Depreciation is Cost of Asset - Salvage Value
        private float _annualDeprec;

        public float AnnualDeprec
        {
            get { return _annualDeprec; }
            private set {  _annualDeprec = value; }
        }

        private void CalcAnnualDeprec()
        {
            //probaly have to do a year check for days rounding
            if (LeftInventroy.Year - EnteredInventory.Year > 0)
            {
                _annualDeprec = (StartingValue - SalvageValue) / (LeftInventroy.Year - EnteredInventory.Year);
            }
            else
            {
                _annualDeprec = (StartingValue - SalvageValue);
            }
            
        }


    }
}
