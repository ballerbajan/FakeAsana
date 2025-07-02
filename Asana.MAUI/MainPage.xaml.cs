using Asana.MAUI.ViewModels;

namespace Asana.MAUI
{
    public partial class MainPage : ContentPage
    // patial class means that this class is defined in multiple files,
    // which is common in MAUI projects to separate concerns
    // in cpp we already have partial classes without the need for a keyword
    // header file and implementation file
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }

        private void AddNewClicked(object sender, EventArgs e)
        {
            // next layer down in folder layout
            Shell.Current.GoToAsync("//ToDoDetails");
        }
        private void EditClicked(object sender, EventArgs e)
        {
            // get id from selected and pass it to the todo deatail view
            var selectedId = (BindingContext as MainPageViewModel)?.SelectedToDoId;
            Shell.Current.GoToAsync($"//ToDoDetails?toDoId={selectedId}");
        }
        private void DeleteClicked(object sender, EventArgs e)
        {
            (BindingContext as MainPageViewModel)?.DeleteToDo();
        }

        private void LineDeleteClicked(object sender, EventArgs e)
        {
            (BindingContext as MainPageViewModel)?.RefreshPage();

        }
        private void ProjectClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync($"//ProjectPage");

        }

        private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
        {
            (BindingContext as MainPageViewModel)?.RefreshPage();
        }

        private void ContentPage_NavigatedFrom(object sender, NavigatedFromEventArgs e)
        {

        }

        
    }
}
