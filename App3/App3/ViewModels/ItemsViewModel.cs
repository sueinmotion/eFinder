using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using App3.Models;
using App3.Views;

namespace App3.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Employee> Employees { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Employee Finder";
            Employees = new ObservableCollection<Employee>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Employee>(this, "AddItem", async (obj, employee) =>
            {
                var _employee = employee as Employee;
                Employees.Add(_employee);
                await DataStore.AddItemAsync(_employee);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Employees.Clear();
                var employees = await DataStore.GetItemsAsync(true);
                foreach (var employee in employees)
                {
                    Employees.Add(employee);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}