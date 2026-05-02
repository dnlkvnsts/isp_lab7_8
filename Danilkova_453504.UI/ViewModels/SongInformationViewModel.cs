using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danilkova_453504.UI.ViewModels
{
    [QueryProperty(nameof(Song), "Song")]
    public partial class SongInformationViewModel : ObservableObject
    {
        [ObservableProperty]
        private Song song;


        public SongInformationViewModel()
        {
        }


        [RelayCommand]

        async Task UpdateSongOnPage() => await UpdateSong();



        private async Task UpdateSong()
        {
            if (Song == null)
            {
                return;
            }

            await Shell.Current.GoToAsync($"{nameof(UpdateSong)}?SongId={Song.Id}");
        }
    }
}
