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
            var details5 = new SongDetails("Hotel California", 6.30, "Rock");
            var details6 = new SongDetails("Shape of You", 3.53, "Pop");
            var details7 = new SongDetails("Smells Like Teen Spirit", 5.01, "Rock");
            var details8 = new SongDetails("Thriller", 5.57, "Pop");
            var details9 = new SongDetails("Imagine", 3.03, "Rock");
            var details10 = new SongDetails("Rolling in the Deep", 3.48, "Pop");
            var details11 = new SongDetails("Stairway to Heaven", 8.02, "Rock");
            var details12 = new SongDetails("Hallelujah", 4.39, "Pop");
            var details13 = new SongDetails("Yesterday", 2.05, "Rock");
            var details14 = new SongDetails("Lose Yourself", 5.26, "Hip Hop");
            var details15 = new SongDetails("Nothing Else Matters", 6.28, "Metal");


            var song1 = new Song(details1, 100);
            var song2 = new Song(details2, 95);
            var song3 = new Song(details3, 98);
            var song4 = new Song(details4, 90);
            var song5 = new Song(details5, 92);
            var song6 = new Song(details6, 88);
            var song7 = new Song(details7, 96);
            var song8 = new Song(details8, 99);
            var song9 = new Song(details9, 94);
            var song10 = new Song(details10, 91);
            var song11 = new Song(details11, 97);
            var song12 = new Song(details12, 85);
            var song13 = new Song(details13, 93);
            var song14 = new Song(details14, 89);
            var song15 = new Song(details15, 95);

            song1.AddSongToSinger(singer1.Id);
            song2.AddSongToSinger(singer2.Id);
            song3.AddSongToSinger(singer2.Id);
            song4.AddSongToSinger(singer3.Id);
            song5.AddSongToSinger(singer1.Id);
            song6.AddSongToSinger(singer2.Id);
            song7.AddSongToSinger(singer3.Id);
            song8.AddSongToSinger(singer1.Id);
            song9.AddSongToSinger(singer2.Id);
            song10.AddSongToSinger(singer3.Id);
            song11.AddSongToSinger(singer1.Id);
            song12.AddSongToSinger(singer2.Id);
            song13.AddSongToSinger(singer3.Id);
            song14.AddSongToSinger(singer1.Id);
            song15.AddSongToSinger(singer2.Id);


            await unitOfWork.SongRepository.AddAsync(song1);
            await unitOfWork.SongRepository.AddAsync(song2);
            await unitOfWork.SongRepository.AddAsync(song3);
            await unitOfWork.SongRepository.AddAsync(song4);
            await unitOfWork.SongRepository.AddAsync(song5);
            await unitOfWork.SongRepository.AddAsync(song6);
            await unitOfWork.SongRepository.AddAsync(song7);
            await unitOfWork.SongRepository.AddAsync(song8);
            await unitOfWork.SongRepository.AddAsync(song9);
            await unitOfWork.SongRepository.AddAsync(song10);
            await unitOfWork.SongRepository.AddAsync(song11);
            await unitOfWork.SongRepository.AddAsync(song12);
            await unitOfWork.SongRepository.AddAsync(song13);
            await unitOfWork.SongRepository.AddAsync(song14);
            await unitOfWork.SongRepository.AddAsync(song15);

            await unitOfWork.SaveAllAsync();
        }
    }
}
