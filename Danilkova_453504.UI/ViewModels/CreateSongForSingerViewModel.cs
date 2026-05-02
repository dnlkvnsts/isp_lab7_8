using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Danilkova_453504.Application.SongUseCases.Commands;


namespace Danilkova_453504.UI.ViewModels
{

    [QueryProperty(nameof(SingerId), "SingerId")]
    public partial class CreateSongForSingerViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        public CreateSongForSingerViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

       
        [ObservableProperty]
        private int singerId;

        
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private double continuation;

        [ObservableProperty]
        private string genre;

        [ObservableProperty]
        private int rate;

       
        [RelayCommand]
        private async Task SaveSong()
        {
           
            var command = new AddSongCommand(
                Name,
                Continuation,
                Genre,
                Rate,
                SingerId);

           
            await _mediator.Send(command);

            
            await Shell.Current.GoToAsync("..");
        }

        
        [RelayCommand]
        private async Task Cancel() => await Shell.Current.GoToAsync("..");
    }
}
