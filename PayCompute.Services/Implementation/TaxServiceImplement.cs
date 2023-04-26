using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCompute.Services.Implementation
{
    public class TaxServiceImplement : ITaxService
    {
        private decimal taxRate;
        private decimal tax;
        public decimal TaxAmount(decimal totalAmount)
        {
            if (totalAmount <= 1042)  //tax according to uk gov.
            {
                //tax free rate
                taxRate = .0m;
                tax = totalAmount + taxRate;
            }
            else if (totalAmount > 1042 && totalAmount <= 3125)
            {
                //basic tax rate
                taxRate = .20m;
                //income tax
                tax = (1042 * .0m) + ((totalAmount - 1042) * taxRate);
            }
            else if (totalAmount > 3125 && totalAmount <= 12500)
            {
                //higher tax rate will apply
                taxRate = .40m;
                //income tax 
                tax = (1042 * .0m) + ((3125 - 1042) * .20m) + ((totalAmount - 3125) * taxRate);
            }
            else if (totalAmount > 12500)
            {
                //additional tax rate will apply
                taxRate = .45m;
                //income tax
                tax = (1042 * .0m) + ((3125 - 1042) * .20m) + ((12500 - 3125) * .40m) + 
                    ((totalAmount - 12500) * taxRate);
            }
            return tax;
        }
    }
}
