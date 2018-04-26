using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App2.Models;


namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
	{
       
		public MainPage()
		{
			InitializeComponent();
            
            Master = masterPage;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Principal)));
            masterPage.ListView.ItemSelected += OnItemSelected;
            MasterBehavior = MasterBehavior.Popover;

        }
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.Target));
                masterPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }

    }
}
