using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using AppGestionRH.Models;


namespace AppGestionRH.ViewModels
{
    public class EmployeeViewModel
    {
        public ObservableCollection<Employee> Employees { get; set; }
        public ICommand AddEmployeeCommand { get; }

        public EmployeeViewModel()
        {
            Employees = new ObservableCollection<Employee>();
            AddEmployeeCommand = new RelayCommand(AddEmployee, CanAddEmployee);
        }

        private void AddEmployee()
        {
            // Logique pour ajouter un employé
        }

        private bool CanAddEmployee()
        {
            // Logique pour déterminer si l'ajout d'un employé est possible
            return true; // Modifiez cette logique selon vos besoins
        }

        public void UpdateCanExecuteCommands()
        {
            ((RelayCommand)AddEmployeeCommand).RaiseCanExecuteChanged();
        }
    }
}
