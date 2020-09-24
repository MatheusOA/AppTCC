using AppTCC.Models;
using AppTCC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTCC.Views
{
    public partial class SupportPage : ContentPage
    {
        SupportViewModel page;
        public SupportPage()
        {
            InitializeComponent();

            BindingContext = page = new SupportViewModel();

            page.ListMessages.CollectionChanged += (sender, e) =>
            {
                var target = page.ListMessages[page.ListMessages.Count - 1];
                MessagesListView.ScrollTo(target, ScrollToPosition.End, true);

                OnPropertyChanged();
                OnPropertyChanged(nameof(SupportViewModel.OutText));
            };

        }
    }
}