using System.ComponentModel;
using Xamarin.Forms;
using AppTCC.ViewModels;

namespace AppTCC.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}