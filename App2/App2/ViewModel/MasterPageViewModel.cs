using App2.Models;
using App2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.ViewModel
{
    public class MasterPageViewModel : ViewModelBase
    {
        private List<MasterPageItem> _items;

        public List<MasterPageItem> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        public MasterPageViewModel()
        {
            Items = new List<MasterPageItem>();
            Load();
        }

        private void Load()
        {
            Items.Add(new MasterPageItem
            {
                Title = "Inventario",
                Icon = "document.png",
                Target = typeof(Inventario)
            });
           
        }
    }
}
