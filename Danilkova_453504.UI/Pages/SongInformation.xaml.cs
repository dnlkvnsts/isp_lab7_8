using Danilkova_453504.UI.ViewModels;

namespace Danilkova_453504.UI.Pages;


public partial class SongInformation : ContentPage
{
	public SongInformation(SongInformationViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}