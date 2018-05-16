using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace App3.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://cdn.pixabay.com/photo/2016/12/01/01/22/dog-1874256_960_720.jpg")));
        }

        public ICommand OpenWebCommand { get; }
    }
}