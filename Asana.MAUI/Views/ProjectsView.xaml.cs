using Asana.MAUI.ViewModels;

namespace Asana.MAUI.Views;

public partial class ProjectsView : ContentPage
{
	public ProjectsView()
	{
		InitializeComponent();
        BindingContext = new ProjectsPageViewModel();
    }

   
    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//MainPage");

    }

    private void SwapClicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectsPageViewModel)?.SwapCurrentProject();
        Shell.Current.GoToAsync($"//MainPage");

    }

    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ProjectDetails");
    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectsPageViewModel)?.DeleteProject();

    }

    private void UpdateClicked(object sender, EventArgs e)
    {
        var selectedId = (BindingContext as ProjectsPageViewModel)?.SelectedProjectId;
        Shell.Current.GoToAsync($"//ProjectDetails?projectId={selectedId}");

    }

    public void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as ProjectsPageViewModel)?.RefreshPage();
    }

    private void ContentPage_NavigatedFrom(object sender, NavigatedFromEventArgs e)
    {

    }
}