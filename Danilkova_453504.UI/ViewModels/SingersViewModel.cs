using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Danilkova_453504.Application.SingerUseCases.Queries;
using Danilkova_453504.Application.SongUseCases.Queries;
using Danilkova_453504.UI.Pages;

namespace Danilkova_453504.UI.ViewModels
{
    public partial class SingersViewModel : ObservableObject
    {
        private readonly IMediator _mediator;


       
        public SingersViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }


        public ObservableCollection<Singer> Singers { get; set; } = new();
        public ObservableCollection<Song> Songs { get; set; } = new();


        [ObservableProperty]
        Singer selectedSinger;


        [RelayCommand]
        async Task UpdateSingerList() => await GetSingers();


        [RelayCommand]
        async Task UpdateSongsList() => await GetSongs();


        [RelayCommand]
        async void ShowSongInformation(Song song) => await GoToSongInformationPage(song);


        [RelayCommand]

        async Task AddSingerToList() => await AddSinger();


        [RelayCommand]

        async Task AddSongToSinger() => await AddSong();

        [RelayCommand]

        async Task UpdateSingerFromList() => await UpdateSinger();



        private async Task UpdateSinger()
        {
            if (SelectedSinger == null)
            {
                await Shell.Current.DisplayAlert("Ошибка", "Сначала выберите исполнителя из списка!", "OK");
                return;
            }

            await Shell.Current.GoToAsync($"{nameof(UpdateSinger)}?SingerId={SelectedSinger.Id}");
        }

        private async Task AddSong()
        {
            if (SelectedSinger == null)
            {
                await Shell.Current.DisplayAlert("Ошибка", "Сначала выберите исполнителя из списка!", "OK");
                return;
            }

           
            await Shell.Current.GoToAsync($"{nameof(CreateSongForSinger)}?SingerId={SelectedSinger.Id}");
        }


        private async Task AddSinger()
        {
            await Shell.Current.GoToAsync(nameof(CreateSinger));
        }
        

        private async Task GoToSongInformationPage(Song song)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"Song", song }
            };

            await Shell.Current.GoToAsync(nameof(SongInformation), parameters);
        }

        public async Task GetSingers()
        {
            var singers = await _mediator.Send(new GetSingersRequest());
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Singers.Clear();
                foreach(var singer in singers)
                {
                    Singers.Add(singer);
                }
            });
        }

        public async Task GetSongs()
        {

            if (SelectedSinger == null)
            {
                return;
            }

            var songs = await _mediator.Send(new GetSongsBySingerRequest(SelectedSinger.Id));
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Songs.Clear();
                foreach (var song in songs)
                {
                    Songs.Add(song);
                }
            });
        }




    }
}
