using Xamarin.Forms;
using XamFormsAwaitablePopup.ViewModel;

namespace XamFormsAwaitablePopup.Page
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}
