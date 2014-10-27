using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using ToDoDemoApp.DataAccessLayer;
using Windows.Storage;
using System.Linq;

namespace ToDoDemoApp.Data_Access_Layer
{
    internal static class Dal
    {
        

        private static string dbPath = string.Empty;
        private static string DbPath
        {
            get
            {
                if (string.IsNullOrEmpty(dbPath))
                {
                    dbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "items.db");
                }

                return dbPath;
            }
        }

        

        public static void CreateDatabase()
        {
            // Create a new connection
            var db = new SQLiteConnection(DbPath);

            // Activate Tracing
            db.Trace = true;

            // Create the table if it does not exist
            var c = db.CreateTable<ToDoItem>();
            // var info = db.GetMapping(typeof(Person));



            ToDoItem toDoItem = new ToDoItem();
            toDoItem.Id = 1;
            toDoItem.ToDoHeader = "Części do samochodu";
            toDoItem.DoUntilDate = new DateTime(2014, 10, 18);
            toDoItem.Description = "Amortyzator przedni, sprężyna wachacza";
            var i = db.InsertOrReplace(toDoItem);

            toDoItem.Id = 2;
            toDoItem.ToDoHeader = "Przygotować się na rozmowę";
            toDoItem.DoUntilDate = new DateTime(2014, 10, 21);
            toDoItem.Description = "Poczytac o technologiach, zapoznać się z firmą";
            i = db.InsertOrReplace(toDoItem);

            toDoItem.Id = 3;
            toDoItem.ToDoHeader = "MOUT z kumplami";
            toDoItem.DoUntilDate = new DateTime(2014, 10, 17);
            toDoItem.Description = "Skontaktować się z Szpakiem";
            i = db.InsertOrReplace(toDoItem);
        }

        public static List<ToDoItem> GetAllToDoItems()
        {
            List<ToDoItem> models;

            using (var db = new SQLiteConnection(DbPath))
            {
                // Activate Tracing
                db.Trace = true;

                models = (from t in db.Table<ToDoItem>()
                          select t).ToList();
            }

            return models;
        }

        

        public static void DeleteToDoItem(ToDoItem toDoItem)
        {
            using (var db = new SQLiteConnection(DbPath))
            {
                // Activate Tracing
                db.Trace = true;

                // Object model:
                db.Delete(toDoItem);

                // SQL Syntax:
                //db.BeginTransaction();
                //db.Execute("DELETE FROM ToDoItems WHERE Id = ?", toDoItem.Id);
                //db.Commit();
            }
        }

        public static void SaveToDoItem(ToDoItem toDoItem)
        {
            using (var db = new SQLiteConnection(DbPath))
            {
                // Activate Tracing
                db.Trace = true;

                if (toDoItem.Id == 0)
                {
                    // New
                    db.Insert(toDoItem);
                }
                else
                {
                    // Update
                    db.Update(toDoItem);
                }
            }
        }
    }
}
