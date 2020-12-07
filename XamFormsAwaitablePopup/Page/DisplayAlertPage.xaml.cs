using System;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;
using XamFormsAwaitablePopup.ViewModel;

namespace XamFormsAwaitablePopup.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DisplayAlertPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        private TaskCompletionSource<Tuple<DisplayAlertViewModel.EnumOutputType, string>> _taskCompletionSource;
        public Task<Tuple<DisplayAlertViewModel.EnumOutputType, string>> PopupClosedTask => _taskCompletionSource.Task;


        public DisplayAlertPage(string title, string message, DisplayAlertViewModel.EnumInputType inputType)
        {
            InitializeComponent();
            BindingContext = new DisplayAlertViewModel(title, message, inputType);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _taskCompletionSource = new TaskCompletionSource<Tuple<DisplayAlertViewModel.EnumOutputType, string>>();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();          
            _taskCompletionSource.SetResult(((DisplayAlertViewModel)BindingContext).ReturnValue);
        }
    }
}