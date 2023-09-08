using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Services
{
    internal interface IPokemonsService
    {
        //Task<ResultAPI> GetResults();
        Task<Pokemon> GetPokemon(string name);
    }
}
