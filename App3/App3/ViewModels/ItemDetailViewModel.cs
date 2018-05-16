using System;

using App3.Models;

namespace App3.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Employee Employee { get; set; }
        public ItemDetailViewModel(Employee employee = null)
        {
            Title = employee?.Name;
            Employee = employee;
        }
    }
}
