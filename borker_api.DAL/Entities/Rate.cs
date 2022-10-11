using borker_api.DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace borker_api.DAL.Entities
{
    public class Rate : Entity
    {
        public DateTime Date { get; set; }
        public double RUB { get; set; }
        public double EUR { get; set; }
        public double GBP { get; set; }
        public double JPY { get; set; }
        [NotMapped]
        public bool IsApiDataNeed { get; set; }
        public IEnumerable<string> GetListOfCurrencyString()
        {
            return new List<string>() { nameof(RUB), nameof(EUR), nameof(GBP), nameof(JPY) };
        }
        public double GetCurrencyOf(string name) => (double)GetType().GetProperty(name).GetValue(this);
    }
}
