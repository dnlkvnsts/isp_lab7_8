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

        // Это свойство заполнится автоматически при переходе
        [ObservableProperty]
        private int singerId;

        // Свойства для полей ввода (связаны с Entry в XAML)
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private double continuation;

        [ObservableProperty]
        private string genre;

        [ObservableProperty]
        private int rate;

        // Команда сохранения
        [RelayCommand]
        private async Task SaveSong()
        {
            // 1. Создаем команду для Application слоя (ту, которую мы писали в начале)
            var command = new AddSongCommand(
                Name,
                Continuation,
                Genre,
                Rate,
                SingerId);

            // 2. Отправляем её через MediatR в AddSongCommandHandler
            await _mediator.Send(command);

            // 3. Возвращаемся на предыдущую страницу
            await Shell.Current.GoToAsync("..");
        }

        // Команда отмены
        [RelayCommand]
        private async Task Cancel() => await Shell.Current.GoToAsync("..");
    }
}
