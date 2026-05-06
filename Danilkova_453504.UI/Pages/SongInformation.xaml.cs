using Danilkova_453504.UI.ViewModels;

namespace Danilkova_453504.UI.Pages;


public partial class SongInformation : ContentPage
{
	public SongInformation(SongInformationViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}

    protected override async void OnAppearing() // добавили async
    {
        base.OnAppearing();

        var viewModel = BindingContext as SongInformationViewModel;

        if (viewModel != null)
        {
            await viewModel.LoadSongDataCommand.ExecuteAsync(null); // используем ExecuteAsync
        }
    }
}