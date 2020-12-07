using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using XamFormsAwaitablePopup.Page;
using XamFormsAwaitablePopup.Resource;

namespace XamFormsAwaitablePopup.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {

            XamarinFormsPopupCommand = new Command(async () => {
                await Application.Current.MainPage.DisplayAlert(AppResource.Attention, AppResource.XamarinFormsPopup, AppResource.Ok);
                await Application.Current.MainPage.DisplayAlert(AppResource.Attention, AppResource.IsAwaitable, AppResource.Ok);
            });

            NotAwaitablePopupCommand = new Command(async () => {
                await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new DisplayAlertPage(AppResource.Attention, AppResource.RGNotAwaitablePopup, DisplayAlertViewModel.EnumInputType.Ok));
                await Application.Current.MainPage.DisplayAlert(AppResource.Attention, AppResource.IsNotAwaitable, AppResource.Ok);
            });
        }

        public ICommand XamarinFormsPopupCommand { get; protected set; }
        public ICommand NotAwaitablePopupCommand { get; protected set; }
        public ICommand AwaitablePopupCommand { get; protected set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
