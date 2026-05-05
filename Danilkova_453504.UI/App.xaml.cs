namespace Danilkova_453504.UI
{
    public partial class App : Microsoft.Maui.Controls.Application
    {
        public App()
        {
            InitializeComponent();

            // Устанавливаем главную страницу сразу
            MainPage = new AppShell();
        }

        // OnStart срабатывает, когда приложение запускается
        protected override async void OnStart()
        {
            base.OnStart();
            await SeedImagesAsync();
        }

        private async Task SeedImagesAsync()
        {
            string targetFolder = Path.Combine(FileSystem.AppDataDirectory, "Images");

            
            if (!Directory.Exists(targetFolder))
            {
                Directory.CreateDirectory(targetFolder);
            }

           
            string[] images = { "1.jpg", "2.jpg", "3.jpg", "4.jpg" };

            foreach (var imageName in images)
            {
                string targetPath = Path.Combine(targetFolder, imageName);

                
                if (!File.Exists(targetPath))
                {
                    try
                    {
                        using Stream inputStream = await FileSystem.Current.OpenAppPackageFileAsync(imageName);
                        using FileStream outputStream = File.Create(targetPath);
                        await inputStream.CopyToAsync(outputStream);
                    }
                    catch (Exception ex)
                    {
                        // Вывод ошибки в консоль отладки, если что-то пошло не так
                        System.Diagnostics.Debug.WriteLine($"Ошибка копирования {imageName}: {ex.Message}");
                    }
                }
            }
        }
    }
}