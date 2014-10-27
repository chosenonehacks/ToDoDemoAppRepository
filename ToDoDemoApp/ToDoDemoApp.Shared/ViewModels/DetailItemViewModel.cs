using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ToDoDemoApp.DataAccessLayer;
using ToDoDemoApp.Data_Access_Layer;

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
                

        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                NotifyOfPropertyChange(() => Id);
            }
        }

        private string _toDoHeader;
        public string ToDoHeader
        {
            get
            {
                return _toDoHeader;
            }
            set
            {
                _toDoHeader = value;
                NotifyOfPropertyChange(() => ToDoHeader);
                NotifyOfPropertyChange(() => CanSave);
            }
        }

        private DateTime? _doUntilDate;
        public DateTime? DoUntilDate
        {
            get
            {
                return _doUntilDate;
            }
            set
            {
                _doUntilDate = value;
                NotifyOfPropertyChange(() => DoUntilDate);
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }       

        protected override void OnActivate()
        {
            if (Parameter != null)
            {
                this.Id = Parameter.Id;
                this.ToDoHeader = Parameter.ToDoHeader;
                this.DoUntilDate = Parameter.DoUntilDate;
                this.Description = Parameter.Description;
            }
            else
            {
                this.DoUntilDate = DateTime.Now;
            }
        }

        public void GoBack()
        {            
                _navigationService.GoBack();            
        }

        public bool CanGoBack()
        {
            return _navigationService.CanGoBack;
        }
           
        public void Save()
        {
            DalAsync dalAsync = new DalAsync();
            var mainVM = _container.GetInstance<MainPageViewModel>();

            if (Parameter == null)
            {
                ToDoItem _toDoItem = new ToDoItem();
                _toDoItem.ToDoHeader = this.ToDoHeader;
                _toDoItem.DoUntilDate = this.DoUntilDate;
                _toDoItem.Description = this.Description;

                mainVM.ToDoItemsList.Add(_toDoItem);           


                //Dal.SaveToDoItem(_toDoItem);
                dalAsync.SaveToDoItemAsync(_toDoItem);
            }
            else
            {
                var toDoItemToUpdate = mainVM.ToDoItemsList.FirstOrDefault(a => a.Id == this.Parameter.Id);
                if(toDoItemToUpdate != null)
                {
                    toDoItemToUpdate.ToDoHeader = this.ToDoHeader;
                    toDoItemToUpdate.DoUntilDate = this.DoUntilDate;
                    toDoItemToUpdate.Description = this.Description;
                    //Dal.SaveToDoItem(toDoItemToUpdate);
                    dalAsync.SaveToDoItemAsync(toDoItemToUpdate);
                    
                }

            }
            RefreshToDotList();

            _navigationService.GoBack();
        }

        public bool CanSave
        {
            get { return !String.IsNullOrWhiteSpace(this.ToDoHeader); }
        }

        public void Delete()
        {
            var mainVM = _container.GetInstance<MainPageViewModel>();

            var toDoItemToDelete = mainVM.ToDoItemsList.FirstOrDefault(a => a.Id == this.Parameter.Id);
                if (toDoItemToDelete != null)
                {
                    mainVM.ToDoItemsList.Remove(toDoItemToDelete);
                    //Dal.DeleteToDoItem(toDoItemToDelete);

                    DalAsync dalAsync = new DalAsync();
                    dalAsync.DeleteToDoItemAsync(toDoItemToDelete);
                }
                //RefreshToDotList();
                RefreshToDotListAsync();
                        
            _navigationService.GoBack();
        }

        public bool CanDelete
        {
            get
            {
                if (Parameter != null)
                    return true;
                else
                    return false;
            }
        }

        private void RefreshToDotList()
        {
            var mainVM = _container.GetInstance<MainPageViewModel>();
            mainVM.ToDoItemsList = null;
            mainVM.ToDoItemsList = Dal.GetAllToDoItems();
        }

        private async void RefreshToDotListAsync()
        {
            var mainVM = _container.GetInstance<MainPageViewModel>();
            mainVM.ToDoItemsList = null;

            DalAsync dalAsync = new DalAsync();
            mainVM.ToDoItemsList = await dalAsync.GetAllToDoItemsAsync();
        }
    }
}
