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
