using Galery.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Galery.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageViewerPage : ContentPage
    {
        ImgData pictureInfo;
        public ImageViewerPage(ImgData picture)
        {
            pictureInfo = picture;
            InitializeComponent();
            this.BindingContext = pictureInfo;
        }
    }
}