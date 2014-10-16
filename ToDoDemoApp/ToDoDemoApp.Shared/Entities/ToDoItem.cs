using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoDemoApp.Entities
{
    public class ToDoItem
    {
        public string ToDoHeader { get; set; }
        public DateTime? DoUntilDate { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
}
