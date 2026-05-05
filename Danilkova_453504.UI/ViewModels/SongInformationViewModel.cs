using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Danilkova_453504.Application.SongUseCases.Commands;
using Danilkova_453504.Application.SongUseCases.Queries;
using Danilkova_453504.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danilkova_453504.UI.ViewModels
{
    [QueryProperty(nameof(SongId), "SongId")]
    public partial class SongInformationViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        [ObservableProperty]
        private Song song;

        [ObservableProperty]
        private int songId;



        public SongInformationViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }


        [RelayCommand]

        async Task UpdateSongOnPage() => await UpdateSong();


        [RelayCommand]

        async Task DeleteSongOnPage() => await DeleteSong();


        private async Task DeleteSong()
        {

            bool answer = await Shell.Current.DisplayAlert("Удаление", "Вы уверены, что хотите удалить эту песню?", "Да", "Нет");

            if (answer)
            {
                await _mediator.Send(new DeleteSongCommand(SongId));

                await Shell.Current.GoToAsync("..");

            }
        }

        private async Task UpdateSong()
        {
            if (Song == null)
            {
                return;
            }

            await Shell.Current.GoToAsync($"{nameof(UpdateSong)}?SongId={SongId}");
        }

        [RelayCommand]
        public async Task LoadSongData()
        {
            
            Song = await _mediator.Send(new GetSongByIdQuery(SongId));
        }
    }
}
