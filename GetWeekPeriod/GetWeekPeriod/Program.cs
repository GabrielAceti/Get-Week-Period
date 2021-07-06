using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetWeekPeriod
{
    //Gabriel Aceti

    class Program
    {
        static void Main(string[] args)
        {
            int week = int.Parse(Console.ReadLine());
            Console.WriteLine("Monday: " + getPeriod(week)[0] +" Friday: " + getPeriod(week)[1]);
            Console.ReadLine();
        }

        private static string[] getPeriod(int week)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;
            
            //Gets the number of the current week
            int currentWeek = cal.GetWeekOfYear(DateTime.Today, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            
            //Subtracts the current week from the given week
            int weekSubtraction = week - currentWeek;
                        
            //Multiplies the difference of the weeks by 7 to get the difference in days.(1 week = 7 days)
            int weekMultiplication = weekSubtraction * 7;
                        
            //Gets the current day and adds the number of days to reach the given week. 
            DateTime diaAtual = DateTime.Now;
            diaAtual.AddDays(weekMultiplication);

            string dataAtual = diaAtual.ToString("ddd", new CultureInfo("pt-BR"));

            DateTime segunda = DateTime.Now;
            DateTime sexta = DateTime.Now;
            
            //Makes the calculations to reach Monday and Friday of the given week.
            if (dataAtual == "seg") { segunda = DateTime.Now.AddDays(weekMultiplication); sexta = DateTime.Now.AddDays(weekMultiplication + 4); }
            else if (dataAtual == "ter") { segunda = DateTime.Now.AddDays(weekMultiplication - 1); sexta = DateTime.Now.AddDays(weekMultiplication + 3); }
            else if (dataAtual == "qua") { segunda = DateTime.Now.AddDays(weekMultiplication - 2); sexta = DateTime.Now.AddDays(weekMultiplication + 2); }
            else if (dataAtual == "qui") { segunda = DateTime.Now.AddDays(weekMultiplication - 3); sexta = DateTime.Now.AddDays(weekMultiplication + 1); }
            else if (dataAtual == "sex") { segunda = DateTime.Now.AddDays(weekMultiplication - 4); sexta = DateTime.Now.AddDays(weekMultiplication + 0); }
            else if (dataAtual == "sáb") { segunda = DateTime.Now.AddDays(weekMultiplication - 5); sexta = DateTime.Now.AddDays(weekMultiplication - 1); }
            else if (dataAtual == "dom") { segunda = DateTime.Now.AddDays(weekMultiplication - 6); sexta = DateTime.Now.AddDays(weekMultiplication - 2); }

            string[] _return = new string[2];
            _return[0] = segunda.ToString("dd/MM/yyyy");
            _return[1] = sexta.ToString("dd/MM/yyyy");

            return _return; 
        }
    }
}
