﻿using Caliburn.Micro;
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
        

        //private int _id;
        //public int Id
        //{
        //    get
        //    {
        //        return _id;
        //    }
        //    set
        //    {
        //        _id = value;
        //        NotifyOfPropertyChange(() => Id);
        //    }
        //}

        //private string _toDoHeader;
        //public string ToDoHeader
        //{
        //    get
        //    {
        //        return _toDoHeader;
        //    }
        //    set
        //    {
        //        _toDoHeader = value;
        //        NotifyOfPropertyChange(() => ToDoHeader);
        //    }
        //}

        //private DateTime? _doUntilDate;
        //public DateTime? DoUntilDate
        //{
        //    get
        //    {
        //        return _doUntilDate;
        //    }
        //    set
        //    {
        //        _doUntilDate = value;
        //        NotifyOfPropertyChange(() => DoUntilDate);
        //    }
        //}

        //private string _description;
        //public string Description
        //{
        //    get
        //    {
        //        return _description;
        //    }
        //    set
        //    {
        //        _description = value;
        //        NotifyOfPropertyChange(() => Description);
        //    }
        //}

        //private bool _isDone;
        //public bool IsDone
        //{
        //    get
        //    {
        //        return _isDone;
        //    }
        //    set
        //    {
        //        _isDone = value;
        //        NotifyOfPropertyChange(() => IsDone);
        //    }
        //}
        
    }
}