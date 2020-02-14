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
            request.Email = "ma9@ma9.com";
            request.Password = "ma91234";


            var addRequest = new AddPlayerRequest()
            {
                Email = "ian@ma9.com.br",
                FirstName = "Ian",
                LastName = "Sandes Alves",
                Password = "ianma91234"
            };

            // var Addresponse = service.AddPlayer(addRequest);

            var response = service.PlayerAuthentication(request);

            Console.WriteLine("Serviço é válido ->  " + service.IsValid());

            service.Notifications.ToList().ForEach(x =>
            {
                Console.WriteLine(x.Message);
            });

            Console.ReadKey();
        }
    }
}
