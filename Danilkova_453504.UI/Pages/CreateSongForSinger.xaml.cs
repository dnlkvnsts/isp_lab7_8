using Danilkova_453504.UI.ViewModels;

namespace Danilkova_453504.UI.Pages;

public partial class CreateSongForSinger : ContentPage
{
	public CreateSongForSinger(CreateSongForSingerViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}