using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Danilkova_453504.Application.SongUseCases.Commands;
using System.ComponentModel.DataAnnotations; // Необходим для валидации

namespace Danilkova_453504.UI.ViewModels
{
    [QueryProperty(nameof(SongId), "SongId")]
    public partial class UpdateSongViewModel : ObservableValidator // Наследуемся от Validator
    {
        private readonly IMediator _mediator;

        public UpdateSongViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ObservableProperty]
        private int songId;

        [ObservableProperty]
        [Required(ErrorMessage = "Title is required")]
        [MinLength(2, ErrorMessage = "Title is too short")]

        [NotifyCanExecuteChangedFor(nameof(UpdateSongCommand))]
        private string name;

        [ObservableProperty]
        [Range(0.1, 60.0, ErrorMessage = "Duration must be between 0.1 and 60")]
        [NotifyCanExecuteChangedFor(nameof(UpdateSongCommand))]
        private string continuation;

        [ObservableProperty]
        [Required(ErrorMessage = "Genre is required")]
        [RegularExpression(@"^[a-zA-Zа-яА-Я\s]+$", ErrorMessage = "Only letters are allowed")]
        [NotifyCanExecuteChangedFor(nameof(UpdateSongCommand))]
        private string genre;

        [ObservableProperty]
        [Range(1, 100, ErrorMessage = "Rate must be between 1 and 100")]
        [NotifyCanExecuteChangedFor(nameof(UpdateSongCommand))]
        private int rate;

        [RelayCommand(CanExecute = nameof(CanUpdate))]
        private async Task UpdateSong()
        {
            var duration = double.Parse(Continuation.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
            var command = new UpdateSongCommand(SongId, Name, duration, Genre, Rate);
            await _mediator.Send(command);
            await Shell.Current.GoToAsync("..");
        }

        private bool CanUpdate()
        {
            ValidateAllProperties();
            return !HasErrors;
        }

        [RelayCommand]
        private async Task Cancel() => await Shell.Current.GoToAsync("..");
    }
}
