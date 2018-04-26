using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;
using App2.Models;

namespace App2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Inventario : ContentPage
	{
        ZXingScannerPage scanPage;
        public Inventario()
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