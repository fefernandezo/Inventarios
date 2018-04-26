using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace App2
{
	public partial class MainPage : ContentPage
	{
        ZXingScannerPage scanPage;
		public MainPage()
		{
			InitializeComponent();
            btnScann.Clicked += BtnScann_Clicked;
		}

        private async void BtnScann_Clicked(object sender, EventArgs e)
        {
            scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += (result) => {
                scanPage.IsScanning = false;

                Device.BeginInvokeOnMainThread(() =>
                {
                    Navigation.PopModalAsync();
                    DisplayAlert("Codigo", result.Text, "OK");
                });
            };

            await Navigation.PushModalAsync(scanPage);
        }
    }
}
