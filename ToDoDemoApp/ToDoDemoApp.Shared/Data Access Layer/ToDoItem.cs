using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ToDoDemoApp.DataAccessLayer
{
    [Table("ToDoItems")]
    public class ToDoItem 
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string ToDoHeader { get; set; }

        public DateTime? DoUntilDate { get; set; }

        public string Description { get; set; }
        
    }
}
