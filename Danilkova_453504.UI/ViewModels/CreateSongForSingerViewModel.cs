using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Danilkova_453504.Application.SongUseCases.Commands;
using System.ComponentModel.DataAnnotations; // Не забудь этот using

namespace Danilkova_453504.UI.ViewModels
{
    [QueryProperty(nameof(SingerId), "SingerId")]
    public partial class CreateSongForSingerViewModel : ObservableValidator // Наследуемся от Validator
    {
        private readonly IMediator _mediator;

        public CreateSongForSingerViewModel(IMediator mediator)
        {
            _mediator = mediator;
            ValidateAllProperties(); // Инициализируем проверку
        }

        [ObservableProperty]
        private int singerId;

        [ObservableProperty]
        [Required]
        [MinLength(2)]
        [NotifyCanExecuteChangedFor(nameof(SaveSongCommand))]
        private string name;

        [ObservableProperty]
        [RegularExpression(@"^[0-9]+([.,][0-9]+)?$", ErrorMessage = "Invalid input")]
        [NotifyCanExecuteChangedFor(nameof(SaveSongCommand))]
        private string continuation;

        [ObservableProperty]
        [Required]
        [RegularExpression(@"^[a-zA-Zа-яА-Я\s]+$", ErrorMessage = "Only letters are allowed")]
        [NotifyCanExecuteChangedFor(nameof(SaveSongCommand))]
        private string genre;

        [ObservableProperty]
        [Range(1, 100, ErrorMessage = "Rate must be between 1 and 100")]
        [NotifyCanExecuteChangedFor(nameof(SaveSongCommand))]
        private int rate;

        [RelayCommand(CanExecute = nameof(CanSave))]
        private async Task SaveSong()
        {

            var duration = double.Parse(Continuation.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);

            var command = new AddSongCommand(
                Name,
                duration,
                Genre,
                Rate,
                SingerId);

            await _mediator.Send(command);
            await Shell.Current.GoToAsync("..");
        }

        private bool CanSave()
        {
            ValidateAllProperties();
            return !HasErrors;
        }

        [RelayCommand]
        private async Task Cancel() => await Shell.Current.GoToAsync("..");
    }
}