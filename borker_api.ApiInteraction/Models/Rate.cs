using borker_api.ApiInteraction.JsonObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace borker_api.ApiInteraction.Models
{
    public class Rate
    {
        public DateTime Date { get; set; }
        public Currency Currency { get; set; }
    }
}
