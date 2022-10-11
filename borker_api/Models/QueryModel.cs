using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace borker_api.Models
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double MoneyUSD { get; set; }

    }
}
