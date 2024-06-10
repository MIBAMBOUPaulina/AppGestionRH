using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;

namespace AppGestionRH.ViewModels
{
    public class MainViewModel
    {
        public ICommand MyCommand { get; }

        public MainViewModel()
        {
            MyCommand = new RelayCommand(ExecuteMyCommand, CanExecuteMyCommand);
        }

        private bool CanExecuteMyCommand()
        {
            // Logique pour vérifier si la commande peut être exécutée
            return true; // Modifiez cette logique selon vos besoins
        }

        private void ExecuteMyCommand()
        {
            // Logique d'exécution de la commande
            Console.WriteLine("MyCommand executed!");
        }

        public void UpdateCanExecute()
        {
            // Mettre à jour l'état de l'exécution de la commande
            ((RelayCommand)MyCommand).RaiseCanExecuteChanged();
        }
    }
}

