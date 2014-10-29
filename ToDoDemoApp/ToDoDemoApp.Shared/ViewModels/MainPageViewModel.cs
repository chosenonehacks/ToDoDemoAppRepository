using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ToDoDemoApp.Data_Access_Layer;
using ToDoDemoApp.DataAccessLayer;
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

            //InitializeDB();
            //DalAsync.StartDBOperationsAsync();
            Dal.CreateDatabase();
            ToDoItemsList = Dal.GetAllToDoItems();            
            
        }

        private async void InitializeDB()
        {
            await DalAsync.StartDBOperationsAsync();
            DalAsync dalAsync = new DalAsync();
            ToDoItemsList = await dalAsync.GetAllToDoItemsAsync(); 
        }

        //For DesingData
        public MainPageViewModel()
        {
            if (Execute.InDesignMode)
            {
                ToDoItemsList = new List<ToDoItem>();
                ToDoItemsList.Add(new ToDoItem {ToDoHeader = "To Do Item 1", Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Proin nibh augue, suscipit a, scelerisque sed, lacinia in, mi. Cras vel lorem. Etiam pellentesque aliquet tellus.", DoUntilDate = DateTime.Now});
                ToDoItemsList.Add(new ToDoItem {ToDoHeader = "To Do Item 2", Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Proin nibh augue, suscipit a, scelerisque sed, lacinia in, mi. Cras vel lorem. Etiam pellentesque aliquet tellus.", DoUntilDate = DateTime.Now});
                ToDoItemsList.Add(new ToDoItem {ToDoHeader = "To Do Item 2", Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Proin nibh augue, suscipit a, scelerisque sed, lacinia in, mi. Cras vel lorem. Etiam pellentesque aliquet tellus.", DoUntilDate = DateTime.Now});
                ToDoItemsList.Add(new ToDoItem {ToDoHeader = "To Do Item 3", Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Proin nibh augue, suscipit a, scelerisque sed, lacinia in, mi. Cras vel lorem. Etiam pellentesque aliquet tellus.", DoUntilDate = DateTime.Now});                
            }
        }

        private List<ToDoItem> toDoItem;

        public List<ToDoItem> ToDoItemsList
        {
            get { return toDoItem; }
            set
            {
                toDoItem = value;
                NotifyOfPropertyChange(() => ToDoItemsList);
            }
        }

        public async void About()
        {
            MessageDialog dialog = new MessageDialog("Aplikacja napisana w celu nauki frameworka MVVM Caliburn.Micro oraz bazy SQLite w aplikacjach uniwersalnych");
            await dialog.ShowAsync();
        }
        
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
    }
}
