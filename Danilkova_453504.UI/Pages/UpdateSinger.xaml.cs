using Danilkova_453504.UI.ViewModels;

namespace Danilkova_453504.UI.Pages;

public partial class UpdateSinger : ContentPage
{
	public UpdateSinger(UpdateSingerViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}