using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Danilkova_453504.Application.SingerUseCases.Commands;
using System.ComponentModel.DataAnnotations; // Обязательно для атрибутов

namespace Danilkova_453504.UI.ViewModels
{
    [QueryProperty(nameof(SingerId), "SingerId")]
    public partial class UpdateSingerViewModel : ObservableValidator 
    {
        private readonly IMediator _mediator;

        public UpdateSingerViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ObservableProperty]
        private int singerId;

        [ObservableProperty]
        [Required(ErrorMessage = "Name is required")]
        [MinLength(2, ErrorMessage = "Name is too short")]
        [NotifyCanExecuteChangedFor(nameof(UpdateSingerCommand))] 
        private string name;

        [ObservableProperty]
        [Range(1, 120, ErrorMessage = "Age must be between 1 and 120")]
        [NotifyCanExecuteChangedFor(nameof(UpdateSingerCommand))]
        private int age;

        [ObservableProperty]
        [Required(ErrorMessage = "Country is required")]
        [RegularExpression(@"^[a-zA-Zа-яА-Я\s]+$", ErrorMessage = "Only letters are allowed")]
        [NotifyCanExecuteChangedFor(nameof(UpdateSingerCommand))]
        private string country;




        [RelayCommand(CanExecute = nameof(CanUpdate))]
        private async Task UpdateSinger()
        {
            var command = new UpdateSingerCommand(SingerId, Name, Age, Country);
            await _mediator.Send(command);
            await Shell.Current.GoToAsync("..");
        }

        // Логика проверки: валидны ли все поля
        private bool CanUpdate()
        {
            ValidateAllProperties();
            return !HasErrors;
        }

        [RelayCommand]
        private async Task Cancel() => await Shell.Current.GoToAsync("..");
    }
}
