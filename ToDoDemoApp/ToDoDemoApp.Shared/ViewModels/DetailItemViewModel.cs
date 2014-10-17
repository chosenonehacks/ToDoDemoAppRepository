using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoDemoApp.Entities;

namespace ToDoDemoApp.ViewModels
{
    public class DetailItemViewModel : Screen
    {
        private readonly INavigationService _navigationService;
        private readonly WinRTContainer _container;
        

        public DetailItemViewModel(INavigationService navigationService, WinRTContainer container )
        {
            _navigationService = navigationService;
            _container = container;
        }

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

        private string btnContent;

        public string BtnContent
        {
            get { return btnContent; }
            set
            {
                btnContent = value;
                NotifyOfPropertyChange(() => BtnContent);
            }
        }

        protected override void OnActivate()
        {
            if (Parameter != null)
            {
                ToDoItem = Parameter;
                BtnContent = "Update";
            }
            else
            {
                ToDoItem = new ToDoItem();                
                ToDoItem.DoUntilDate = DateTime.Now;
                BtnContent = "Add";

            }
        }

        public void GoBack(ToDoItem selectedToDoItem)
        {            
                _navigationService.GoBack();            
        }

        public bool CanGoBack(ToDoItem selectedToDoItem)
        {
            return _navigationService.CanGoBack;
        }

        public void AddOrUpdate()
        {
            if (Parameter == null && BtnContent == "Add")
            {
                var mainVM = _container.GetInstance<MainPageViewModel>();
                mainVM.ToDoItems.Add(ToDoItem);
            }
        }

        public bool CanAddOrUpdate()
        {
            if (Parameter == null && BtnContent == "Add")
                return true;
            else                
                return false;
        }
    }
}
