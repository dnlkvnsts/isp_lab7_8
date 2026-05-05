using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Danilkova_453504.Application.SingerUseCases.Queries;
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


        private string ImagesPath => Path.Combine(FileSystem.AppDataDirectory, "Images");

        [ObservableProperty]
        private Song song;

        [ObservableProperty]
        private int songId;


        [ObservableProperty]
        private IEnumerable<Singer> singers;

        [ObservableProperty]
        private Singer selectedSinger;

        public SongInformationViewModel(IMediator mediator)
        {
            _mediator = mediator;

            if (!Directory.Exists(ImagesPath))
            {
                Directory.CreateDirectory(ImagesPath);
            }
        }


        [RelayCommand]

        async Task UpdateSongOnPage() => await UpdateSong();


        [RelayCommand]

        async Task DeleteSongOnPage() => await DeleteSong();


        [RelayCommand]

        async Task LoadSongData() => await LoadSong();

        [RelayCommand]

        async Task AlterSingerOfSong() => await AlterSinger();

        [RelayCommand]

        async Task PickImageOnPage() => await PickImage();

      

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

        
        private async Task LoadSong()
        {


            var songTask = _mediator.Send(new GetSongByIdQuery(SongId));
            var singersTask = _mediator.Send(new GetSingersRequest());

            await Task.WhenAll(songTask, singersTask);

            var updatedSong = await songTask;
            Singers = await singersTask;

            if (updatedSong != null)
            {
                Song = null;
                Song = updatedSong;
            }
        }

        private async Task AlterSinger()
        {
            if (SelectedSinger == null)
            {
                await Shell.Current.DisplayAlert("Ошибка", "Выберите певца из списка", "OK");
                return;
            }

            var result = await _mediator.Send(new AlterSingerCommand(SongId, SelectedSinger.Id));

            if (result)
            {
                await LoadSong(); 
                await Shell.Current.DisplayAlert("Успех", "Исполнитель изменен", "OK");

                await Shell.Current.GoToAsync("..");
            }

        }
        

        private async Task PickImage()
        {
            var result = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Выберите обложку песни",
                FileTypes = FilePickerFileType.Images
            });

            if (result != null)
            {
               
                var extension = Path.GetExtension(result.FileName);
                var targetFileName = Path.Combine(ImagesPath, $"{SongId}{extension}");

               
                string[] extensions = { ".jpg", ".png", ".jpeg" };
                foreach (var ext in extensions)
                {
                    var oldFile = Path.Combine(ImagesPath, $"{SongId}{ext}");
                    if (File.Exists(oldFile)) File.Delete(oldFile);
                }

               
                using (var stream = await result.OpenReadAsync())
                using (var newStream = File.OpenWrite(targetFileName))
                {
                    await stream.CopyToAsync(newStream);
                }

               
                var tempId = SongId;
                SongId = 0;
                SongId = tempId;

                await Shell.Current.DisplayAlert("Успех", "Обложка песни обновлена", "OK");
            }
        }

    }
}
