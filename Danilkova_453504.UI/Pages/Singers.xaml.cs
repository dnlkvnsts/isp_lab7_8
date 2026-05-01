using Danilkova_453504.UI.ViewModels;

namespace Danilkova_453504.UI.Pages;

public partial class Singers : ContentPage
{
	public Singers(SingersViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}