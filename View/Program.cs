using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View_Debug;

namespace View
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                using (MonitoringModelContainer db = new MonitoringModelContainer())
                {
                    // добавление элементов
                    db.HostSet.Add(new Host(true, "TestHost2", DateTime.Now));
                    db.SaveChanges();
                    // получение элементов
                    var users = db.HostSet;
                    foreach (Host u in users)
                        Console.WriteLine($"{u.Id}, {u.Last_Appeal}, {u.Display_Name}");
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
            }
            Console.Read();
        }
    }
}
