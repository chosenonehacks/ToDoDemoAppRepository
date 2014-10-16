using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoDemoApp.Entities;

namespace ToDoDemoApp.ViewModels
{
    public class DetailItemViewModel : Screen
    {
        public ToDoItem Parameter { get; set; }

        private ToDoItem toDoItem;

        public ToDoItem ToDoItem
        {
            get { return toDoItem; }
            set
            {
                toDoItem = value;
                NotifyOfPropertyChange(() => ToDoItem);
            }
        }

        protected override void OnActivate()
        {
            ToDoItem = Parameter;
            
        }
    }
}
