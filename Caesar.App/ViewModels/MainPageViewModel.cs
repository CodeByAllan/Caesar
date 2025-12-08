using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
namespace Caesar.App.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private int _key = 3;
        [ObservableProperty]
        private string _text = string.Empty;
        [ObservableProperty]
        private bool _isCrypt = true;
        [ObservableProperty]
        private string _result = string.Empty;

        private readonly CancellationTokenSource _cancellationTokenSource = new();
        private string _toastText = string.Empty;

        [RelayCommand]
        private void Run()
        {
            if (string.IsNullOrWhiteSpace(Text))
            {
                return;
            }
            Result = IsCrypt
                ? Cipher.lib.Cipher.Crypt(Key, Text)
                : Cipher.lib.Cipher.DeCrypt(Key, Text);
        }
        [RelayCommand]
        private async Task Copy()
        {
            ToastDuration duration = ToastDuration.Short;
            double fontSize = 14;
            if (!string.IsNullOrEmpty(Result))
            {
                try
                {
                    await Clipboard.Default.SetTextAsync(Result);
                    _toastText = "Sucess to copy text to clipboard!";
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error copying: {ex.Message}");
                    _toastText = "Failed to copy text to clipboard!";
                }
                finally
                {
                    var toast = Toast.Make(_toastText, duration, fontSize);
                    await toast.Show(_cancellationTokenSource.Token);
                }
            }
        }
    }
}
