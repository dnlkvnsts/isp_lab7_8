using CommunityToolkit.Mvvm.ComponentModel;
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

    }
}
