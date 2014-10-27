using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoDemoApp.DataAccessLayer;
using Windows.Storage;

namespace ToDoDemoApp.Data_Access_Layer
{
    internal class DalAsync
    {
        public List<ToDoItem> ToDoItemsList { get; set; }

        public async static Task StartDBOperationsAsync()
        {
            // Create Db if not exist
            bool dbExist = await CheckDbAsync("items.db");
            if (!dbExist)
            {
                await CreateDatabaseAsync();
                await AddSampleToDoItemsAsync();

            }
            //await GetAllToDoItemsAsync();            
        }

        private async static Task<bool> CheckDbAsync(string DbPath)
        {
            bool dbExist = true;

            try
            {
                StorageFile sf = await ApplicationData.Current.LocalFolder.GetFileAsync(DbPath);
            }
            catch (Exception)
            {
                dbExist = false;
            }

            return dbExist;
        }

        private async static Task CreateDatabaseAsync()
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("items.db");
            await conn.CreateTableAsync<ToDoItem>();
        }

        private async static Task AddSampleToDoItemsAsync()
        {
            // Create a todoitems list
            var userList = new List<ToDoItem>()
            {
                new ToDoItem()
                {
                    ToDoHeader = "MOUT z kumplami",
                    DoUntilDate = new DateTime(2014, 10, 18),
                    Description = "Skontaktować się z Szpakiem",
                },
                new ToDoItem()
                {
                    ToDoHeader = "Przygotować się na rozmowę",
                    DoUntilDate = new DateTime(2014, 10, 21),
                    Description = "Poczytac o technologiach, zapoznać się z firmą",
                },
                new ToDoItem()
                {
                    ToDoHeader = "Kupić części do samochodu",
                    DoUntilDate = new DateTime(2014, 10, 18),
                    Description = "Amortyzator przedni, sprężyna wachacza",
                }
            };

            // Add rows to the ToDoItems Table
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("items.db");
            await conn.InsertAllAsync(userList);
        }

        // Get items async
        public async Task<List<ToDoItem>> GetAllToDoItemsAsync()
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("items.db");
            var query = conn.Table<ToDoItem>();

            ToDoItemsList = await query.ToListAsync();
            return ToDoItemsList;
        }


        internal async void DeleteToDoItemAsync(ToDoItem toDoItemToDelete)
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("items.db");
            await conn.DeleteAsync(toDoItemToDelete);
        }

        internal async void SaveToDoItemAsync(ToDoItem toDoItem)
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("items.db");
           
                if (toDoItem.Id == 0)
                {
                    // New
                    await conn.InsertAsync(toDoItem);
                }
                else
                {
                    // Update
                    await conn.UpdateAsync(toDoItem);                    
                }

        }

    }
}
