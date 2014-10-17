using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ToDoDemoApp.Entities;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace ToDoDemoApp.ViewModels
{
    public class MainPageViewModel : Screen //PropertyChangedBase
    {
        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            ToDoItems = new ObservableCollection<ToDoItem>
                {
                    new ToDoItem {ToDoHeader = "Części do samochodu", Description = "Amortyzator przedni, sprężyna wachacza", DoUntilDate = new DateTime(2014,10,18)},
                    new ToDoItem {ToDoHeader = "Przygotować się na rozmowę", Description = "Poczytac o technologiach, zapoznać się z firmą", DoUntilDate = new DateTime(2014,10,21)},
                    new ToDoItem {ToDoHeader = "MOUT z kumplami", Description = "Skontaktować się z Szpakiem", DoUntilDate = new DateTime(2014,10,17)}
                };
        }

        //For DesingData
        public MainPageViewModel()
        {
            if (Execute.InDesignMode)
            {
                ToDoItems = new ObservableCollection<ToDoItem>
                {
                    new ToDoItem {ToDoHeader = "To Do Item 1", Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Proin nibh augue, suscipit a, scelerisque sed, lacinia in, mi. Cras vel lorem. Etiam pellentesque aliquet tellus.", DoUntilDate = DateTime.Now},
                    new ToDoItem {ToDoHeader = "To Do Item 2", Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Proin nibh augue, suscipit a, scelerisque sed, lacinia in, mi. Cras vel lorem. Etiam pellentesque aliquet tellus.", DoUntilDate = DateTime.Now},
                    new ToDoItem {ToDoHeader = "To Do Item 3", Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Proin nibh augue, suscipit a, scelerisque sed, lacinia in, mi. Cras vel lorem. Etiam pellentesque aliquet tellus.", DoUntilDate = DateTime.Now},
                    new ToDoItem {ToDoHeader = "To Do Item 4", Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Proin nibh augue, suscipit a, scelerisque sed, lacinia in, mi. Cras vel lorem. Etiam pellentesque aliquet tellus.", DoUntilDate = DateTime.Now},                    
                };
            }
        }

        private ObservableCollection<ToDoItem> toDoItem;

        public ObservableCollection<ToDoItem> ToDoItems
        {
            get { return toDoItem; }
            set
            {
                toDoItem = value;
                NotifyOfPropertyChange(() => ToDoItems);
            }
        }

        //private ToDoItem _selectedToDoItem;

        //public ToDoItem SelectedToDoItem
        //{
        //    get { return _selectedToDoItem; }
        //    set
        //    {
        //        _selectedToDoItem = value;
        //        NotifyOfPropertyChange(() => SelectedToDoItem);
        //    }
        //}
        
        protected override void OnActivate()
        {
                            
        }

        public void GoToDetail(ToDoItem selectedToDoItem)
        {
            _navigationService.NavigateToViewModel<DetailItemViewModel>(selectedToDoItem);
        }

        public void AddNew()
        {
            _navigationService.NavigateToViewModel<DetailItemViewModel>();
        }

        public void Edit()
        {
            //_navigationService.NavigateToViewModel<DetailItemViewModel>(SelectedToDoItem);
        }
    }
}
