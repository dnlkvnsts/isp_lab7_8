using Danilkova_453504.UI.Pages;

namespace Danilkova_453504.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(SongInformation), typeof(SongInformation));
            Routing.RegisterRoute(nameof(CreateSinger), typeof(CreateSinger));
            Routing.RegisterRoute(nameof(CreateSongForSinger), typeof(CreateSongForSinger));
            Routing.RegisterRoute(nameof(UpdateSinger), typeof(UpdateSinger));
            Routing.RegisterRoute(nameof(UpdateSong), typeof(UpdateSong));
        }
    }
}
