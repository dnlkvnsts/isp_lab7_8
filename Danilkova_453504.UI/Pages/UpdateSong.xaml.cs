using Danilkova_453504.UI.ViewModels;

namespace Danilkova_453504.UI.Pages;

public partial class UpdateSong : ContentPage
{
	public UpdateSong(UpdateSongViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}