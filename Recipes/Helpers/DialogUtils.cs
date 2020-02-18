using Xamarin.Forms;
using Acr.UserDialogs;

namespace Recipes.Helpers
{
    public static class DialogUtils
    {
        public static ToastConfig GetToastConfig(string message)
        {
            return GetToastConfig(DialogType.DEFAULT, message);
        }

        public static ToastConfig GetToastConfig(DialogType dialogType, string message)
        {
            var toastConfig = new ToastConfig(message);
            switch (dialogType)
            {
                case DialogType.ERROR:
                    toastConfig.BackgroundColor = Color.DarkRed;
                    toastConfig.MessageTextColor = Color.White;
                    break;
                case DialogType.WARNING:
                    toastConfig.BackgroundColor = Color.DarkOrange;
                    toastConfig.MessageTextColor = Color.White;
                    break;
                case DialogType.DEFAULT:
                    toastConfig.BackgroundColor = (Color)Application.Current.Resources["overstock_primary"];
                    toastConfig.MessageTextColor = Color.White;
                    break;
                case DialogType.SUCCESS:
                    toastConfig.BackgroundColor = Color.DarkGreen;
                    toastConfig.MessageTextColor = Color.White;
                    break;
            }
            return toastConfig;
        }

        public static ConfirmConfig GetConfirmConfig(string title, string message, string confirmText, string cancelText)
        {
            var confirmConfig = new ConfirmConfig();
            confirmConfig.Title = title;
            confirmConfig.Message = message;
            confirmConfig.OkText = confirmText;
            confirmConfig.CancelText = cancelText;

            return confirmConfig;
        }
    }
}
