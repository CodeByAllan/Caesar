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
            if (!string.IsNullOrEmpty(Result))
            {
                try
                {
                    await Clipboard.Default.SetTextAsync(Result);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error copying: {ex.Message}");
                }
            }
        }
    }
}
