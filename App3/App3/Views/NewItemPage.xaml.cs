using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using App3.Models;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public Employee Employee { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Employee = new Employee
            {
                Name = "",
                Location = ""
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Employee);
            await Navigation.PopModalAsync();
        }
    }
}