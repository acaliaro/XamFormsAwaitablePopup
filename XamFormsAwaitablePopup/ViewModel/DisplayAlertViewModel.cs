using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamFormsAwaitablePopup.ViewModel
{
    public class DisplayAlertViewModel : INotifyPropertyChanged
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string InputValue { get; set; }
        public EnumInputType InputType { get; set; }

        public enum EnumInputType { Ok, YesNo, OkCancel, OkCancelWithInput}
        public enum EnumOutputType { Ok, Yes, No, Cancel}
        public Tuple<EnumOutputType, string> ReturnValue;

        public DisplayAlertViewModel(string title, string message, EnumInputType inputType)
        {
            Title = title;
            Message = message;
            InputType = inputType;

            YesCommand = new Command(async () =>
            {
                await ClosePopUp(EnumOutputType.Yes, InputValue);
            });

            NoCommand = new Command(async () =>
            {
                await ClosePopUp(EnumOutputType.No, InputValue);
            });

            OkCommand = new Command(async () =>
            {
                await ClosePopUp(EnumOutputType.Ok, InputValue);
            });

            CancelCommand = new Command(async () =>
            {
                await ClosePopUp(EnumOutputType.Cancel, InputValue);
            });
        }

        private async Task ClosePopUp(EnumOutputType outputType, string inputValue)
        {
            ReturnValue = new Tuple<EnumOutputType, string>(outputType, inputValue);
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand YesCommand { get; protected set; }
        public ICommand NoCommand { get; protected set; }
        public ICommand OkCommand { get; protected set; }
        public ICommand CancelCommand { get; protected set; }

    }
}
