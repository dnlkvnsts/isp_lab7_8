using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danilkova_453504.Application
{
    public static class DbInitializer
    {
        public static async Task Initialize(IServiceProvider services)
        {
            var unitOfWork = services.GetRequiredService<IUnitOfWork>();


            await unitOfWork.DeleteDataBaseAsync();
            await unitOfWork.CreateDataBaseAsync();


            var singer1 = new Singer("Freddie Mercury", 45, "Великобритания");
            var singer2 = new Singer("Michael Jackson", 50, "США");
            var singer3 = new Singer("Celine Dion", 56, "Канада");

            
            await unitOfWork.SingerRepository.AddAsync(singer1);
            await unitOfWork.SingerRepository.AddAsync(singer2);
            await unitOfWork.SingerRepository.AddAsync(singer3);


            await unitOfWork.SaveAllAsync();

            var details1 = new SongDetails("Bohemian Rhapsody", 5.55, "Rock");
            var details2 = new SongDetails("We Are the Champions", 2.59, "Rock");
            var details3 = new SongDetails("Billie Jean", 4.54, "Pop");
            var details4 = new SongDetails("My Heart Will Go On", 4.40, "Pop");

           
            var song1 = new Song(details1, 100);
            var song2 = new Song(details2, 95);
            var song3 = new Song(details3, 98);
            var song4 = new Song(details4, 90);

            song1.AddSongToSinger(singer1.Id);
            song2.AddSongToSinger(singer1.Id);
            song3.AddSongToSinger(singer2.Id);
            song4.AddSongToSinger(singer3.Id);


            await unitOfWork.SongRepository.AddAsync(song1);
            await unitOfWork.SongRepository.AddAsync(song2);
            await unitOfWork.SongRepository.AddAsync(song3);
            await unitOfWork.SongRepository.AddAsync(song4);

            await unitOfWork.SaveAllAsync();
        }
    }
}
