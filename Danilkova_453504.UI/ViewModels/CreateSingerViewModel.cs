using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Danilkova_453504.Application.SingerUseCases.Commands;
using System.ComponentModel.DataAnnotations;


namespace Danilkova_453504.UI.ViewModels
{
    public partial class CreateSingerViewModel : ObservableValidator
    {
        private readonly IMediator _mediator;

        public CreateSingerViewModel(IMediator mediator)
        {
            _mediator = mediator;

           
            ValidateAllProperties();
        }

        [ObservableProperty]
        [Required]
        [MinLength(2)]
        
        [NotifyCanExecuteChangedFor(nameof(SaveSingerCommand))]
        private string name;

        [ObservableProperty]
        [Range(1, 120)]
        [NotifyCanExecuteChangedFor(nameof(SaveSingerCommand))]
        private int age;

        [ObservableProperty]
        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Zа-яА-Я\s]+$", ErrorMessage = "Only letters are allowed")]
        [NotifyCanExecuteChangedFor(nameof(SaveSingerCommand))]
        private string country;


       
        [RelayCommand(CanExecute = nameof(CanSave))]
        private async Task SaveSinger()
        {
            var command = new CreateSingerCommand(Name, Age, Country);

            await _mediator.Send(command);
            await Shell.Current.GoToAsync("..");
        }

        
        private bool CanSave()
        {
            
            ValidateAllProperties();

           
            return !HasErrors;
        }
    }
}
