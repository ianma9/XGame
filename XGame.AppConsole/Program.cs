using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XGame.Domain.Arguments.Player;
using XGame.Domain.Services;

namespace XGame.AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando...");

            var service = new ServicePlayer();
            Console.WriteLine("Criou a instancia do serviço");

            PlayerAuthenticationRequest request = new PlayerAuthenticationRequest();
            Console.WriteLine("Criou a instancia do objeto request");
           
            var response = service.PlayerAuthentication(request);
            Console.ReadKey();
        }
    }
}
