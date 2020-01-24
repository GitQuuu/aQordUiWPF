using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace aQordUiWPF
{
    public class Craftsman
    {
        public int Id { get; set; }
        public string Profession { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal HourlyRate { get; set; }
        public double WorkingHourDaily { get; set; }
        public double WorkingHourWeekly { get; set; }


        public void PrintInfo()
        {
            Console.WriteLine($"{Id},{Profession},{FirstName},{LastName},{HourlyRate},{WorkingHourDaily},{WorkingHourWeekly}");
        }
    }
}
