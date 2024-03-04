using Galery.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Galery.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GaleryPage : ContentPage
    {
        public ObservableCollection<ImgData> imgDatas;
        public int count = 0;
        string path = @"/storage/emulated/0/DCIM/Camera/";

        public GaleryPage()
        {
            imgDatas = new ObservableCollection<ImgData>();
            InitializeComponent();
            FillGrid();
        }

        void FillGrid()
        {

            DirectoryInfo dirInfo = new DirectoryInfo(path);

            foreach (var dir in dirInfo.GetFileSystemInfos("*.jpg"))
            {
                imgDatas.Add(new ImgData(dir.Name, dir.FullName, dir.CreationTime));
                count++;
            }
            pictures.ItemsSource = imgDatas;
        }

        private void ViewPicrure(object sender, EventArgs e)
        {
            if (pictures.SelectedItem is null)
                return;

            Navigation.PushAsync(new ImageViewerPage(pictures.SelectedItem as ImgData));
        }

        async void DeleteImage(object sender, EventArgs e)
        {
            if (pictures.SelectedItem is null)
                return;
            ImgData pic = pictures.SelectedItem as ImgData;
            var answer = await DisplayAlert("Внимание!", $"Удалить {pic.FileName}", "Да", "Нет");
            if (answer == false)
            {
                return;
            }
            try
            {
                if (File.Exists(pic.FilePath))
                {
                    File.Delete(pic.FilePath);
                }
                imgDatas.Remove(pic);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка!", ex.Message, "OK");
            }
        }
    }
}