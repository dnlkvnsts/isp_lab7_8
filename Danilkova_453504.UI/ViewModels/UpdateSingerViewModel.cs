using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Danilkova_453504.Application.SingerUseCases.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danilkova_453504.UI.ViewModels
{

    [QueryProperty(nameof(SingerId), "SingerId")]
    public partial  class UpdateSingerViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        public UpdateSingerViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }


        [ObservableProperty]
        private int singerId;



        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private int age;

        [ObservableProperty]
        private string country;


        [RelayCommand]

        private async Task UpdateSinger()
        {
            var command = new UpdateSingerCommand(SingerId, Name, Age, Country);

            await _mediator.Send(command);
            await Shell.Current.GoToAsync("..");
        }




    }
}
