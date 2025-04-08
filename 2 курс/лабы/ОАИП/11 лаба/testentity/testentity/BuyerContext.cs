using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Diagnostics.Eventing.Reader;

namespace WinFormsApp1
{
    public class BuyerContext : DbContext
    {
        public BuyerContext() : base() { }
        public DbSet<Buyer> Buyers { get; set; }

        public static bool email_check(string email, bool flag = true)
        {
            // flag - переменная, обозначающая проверку на наличие в бд
            // true - проверять, что такого пользователя нет (регистрация)
            // false - проверять, что такой пользователь точно есть (авторизация и почта)
            if (flag)
            {
                using (BuyerContext db = new BuyerContext())
                {
                    if (db.Buyers.Any(x => x.Email == email)) return false;
                }
            } else {
                using (BuyerContext db = new BuyerContext())
                {
                    if (!(db.Buyers.Any(x => x.Email == email))) return false;
                }
            }

            return (email != "" && email.Contains("@") && email.Contains("."));
        }

        public static bool date_check(string date)
        {
            string[] dates = date.Split(".");
            if (dates.Length == 3)
            {
                if (int.TryParse(dates[0], out int day) &&
                    int.TryParse(dates[1], out int month) &&
                    int.TryParse(dates[2], out int year)
                ) {
                    int[] months31 = { 1, 3, 5, 7, 8, 10, 12 };
                    int[] months30 = { 4, 6, 9, 11 };
                    int feb = 2;

                    if (months30.Contains(month))
                    {
                        if (!(day > 0 && day <= 30)) return false;
                    }
                    else if (months31.Contains(month))
                    {
                        if (!(day > 0 && day <= 31)) return false;
                    }

                    if (month == feb) {
                        if (year % 4 == 0 || year % 400 == 0)
                        { // если год високосный
                            if (!(day > 0 && day <= 29)) return false;
                        } else if (!(day > 0 && day <= 28)) return false;
                    }

                   if (!(year <= DateTime.Now.Year && year > 0 &&
                        month > 0 && month <= 12)) return false;

                   return true;
                } else return false;
            } else return false;

        }

        public static DateOnly to_date(string date)
        {
            string[] nbrs = date.Split('.');
            int.TryParse(nbrs[2], out int year);
            int.TryParse(nbrs[1], out int month);
            int.TryParse(nbrs[0], out int day);

            return new DateOnly(year, month, day);
        }
    }
}
