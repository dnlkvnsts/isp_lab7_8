using Danilkova_453504.UI.ViewModels;

namespace Danilkova_453504.UI.Pages;

public partial class Singers : ContentPage
{
	public Singers(SingersViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}

    protected override async void OnAppearing() 
    {
        base.OnAppearing();

        var viewModel = BindingContext as SingersViewModel;
        if (viewModel == null) return;

        
        await viewModel.UpdateSingerListCommand.ExecuteAsync(null);

        
        if (viewModel.SelectedSinger != null)
        {
            await viewModel.UpdateSongsListCommand.ExecuteAsync(null);
        }
    }
}