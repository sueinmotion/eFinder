using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using App3.Models;
using App3.ViewModels;

namespace App3.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemDetailPage : ContentPage
	{
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var employee = new Employee
            {
                Name = "",
                Location = ""
            };

            viewModel = new ItemDetailViewModel(employee);
            BindingContext = viewModel;
        }
    }
}