using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;


namespace App2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Inventario : ContentPage
	{
		//ZXingScannerPage scanPage;
		public Inventario()
		{
		   
			InitializeComponent();
			btnScann.Clicked += BtnScann_Clicked;
			
			
			
		}

		private async void BtnScann_Clicked(object sender, EventArgs e)
		{
			var scanPage = new ZXingScannerPage();
			scanPage.OnScanResult += (result) => {
				//stop scanning
				scanPage.IsScanning = false;

				//pop the page and show result
				Device.BeginInvokeOnMainThread(async() =>
				{
					await Navigation.PopModalAsync();
					await DisplayAlert("Codigo", result.Text, "OK");
				});
			};

			//navega hacia la scannerpage
			await Navigation.PushModalAsync(scanPage);
		}
	}
}