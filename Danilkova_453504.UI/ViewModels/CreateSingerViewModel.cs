using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Danilkova_453504.Application.SingerUseCases.Commands;


namespace Danilkova_453504.UI.ViewModels
{
    public partial  class CreateSingerViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        public CreateSingerViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private int age;

        [ObservableProperty]
        private string country;


        [RelayCommand]

        private async Task SaveSinger()
        {
            var command = new CreateSingerCommand(Name, Age, Country);

            await _mediator.Send(command);
            await Shell.Current.GoToAsync("..");
        }




    }
}
