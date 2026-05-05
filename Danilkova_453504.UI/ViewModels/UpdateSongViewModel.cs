using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Danilkova_453504.Application.SongUseCases.Commands;


namespace Danilkova_453504.UI.ViewModels
{

    [QueryProperty(nameof(SongId), "SongId")]
    public partial class UpdateSongViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        public UpdateSongViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }



        [ObservableProperty] 
        private int songId;

        [ObservableProperty] 
        private string name;

        [ObservableProperty] 
        private double continuation;

        [ObservableProperty] 
        private string genre;

        [ObservableProperty] 
        private int rate;


        [RelayCommand]

        private async Task UpdateSong()
        {
            var command = new UpdateSongCommand(SongId,Name,Continuation, Genre, Rate);


            await _mediator.Send(command);
            await Shell.Current.GoToAsync("..");
        }



    }
}
