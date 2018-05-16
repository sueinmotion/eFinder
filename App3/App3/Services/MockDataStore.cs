using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using App3.Models;

[assembly: Xamarin.Forms.Dependency(typeof(App3.Services.MockDataStore))]
namespace App3.Services
{
    public class MockDataStore : IDataStore<Employee>
    {
        static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = Guid.NewGuid().ToString(), Name = "Sue Su", Location="1625N" },
            new Employee { Id = Guid.NewGuid().ToString(), Name = "Richard Alvarez", Location="1625M" },
        };

        public MockDataStore()
        {

        }

        public async Task<bool> AddItemAsync(Employee employee)
        {
            employees.Add(employee);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Employee employee)
        {
            var _employee = employees.Where((Employee arg) => arg.Id == employee.Id).FirstOrDefault();
            employees.Remove(_employee);
            employees.Add(employee);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _employee = employees.Where((Employee arg) => arg.Id == id).FirstOrDefault();
            employees.Remove(_employee);

            return await Task.FromResult(true);
        }

        public async Task<Employee> GetItemAsync(string id)
        {
            return await Task.FromResult(employees.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Employee>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(employees);
        }
    }
}