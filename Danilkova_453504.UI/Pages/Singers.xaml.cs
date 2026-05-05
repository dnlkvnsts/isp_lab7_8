using Danilkova_453504.UI.ViewModels;

namespace Danilkova_453504.UI.Pages;

public partial class Singers : ContentPage
{
	public Singers(SingersViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Берем нашу ViewModel
        var viewModel = BindingContext as SingersViewModel;

        // Если исполнитель выбран, обновляем список его песен
        if (viewModel?.SelectedSinger != null)
        {
            // Вызываем команду обновления списка песен
            viewModel.UpdateSongsListCommand.Execute(null);
        }

        // Также можно обновить список певцов, если это нужно
        // viewModel.UpdateSingerListCommand.Execute(null);
    }
}