using Asana.Library.Models;
using Asana.MAUI.ViewModels;

namespace Asana.MAUI.Views;

[QueryProperty(nameof(ProjectId), "projectId")]

public partial class ProjectDetailView : ContentPage
{
    public int ProjectId { get; set; }

    public ProjectDetailView()
	{
		InitializeComponent();
	}

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectDetailViewModel)?.AddOrUpdateProject();

        Shell.Current.GoToAsync("//ProjectPage");
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ProjectPage");

    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ProjectDetailViewModel(ProjectId);
    }

    private void ContentPage_NavigatedFrom(object sender, NavigatedFromEventArgs e)
    {

    }
}