using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using XGame.Api.Controllers.Base;
using XGame.Domain.Arguments.Player;
using XGame.Domain.Interfaces.Services;
using XGame.Infra.Transactions;

namespace XGame.Api.Controllers
{
    [RoutePrefix("api/player")]
    public class PlayerController : ControllerBase
    {
        private readonly IServicePlayer _servicePlayer;
        public PlayerController(IUnitOfWork unitOfWork, IServicePlayer servicePlayer) : base(unitOfWork)
        {
            _servicePlayer = servicePlayer;
        }

        [Route("add")]
        [HttpPost]
        public async Task<HttpResponseMessage> Add(AddPlayerRequest request)
        {
            try
            {
                var response = _servicePlayer.AddPlayer(request);
                return await ResponseAsync(response, _servicePlayer);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("list")]
        [HttpGet]
        public async Task<HttpResponseMessage> List()
        {
            try
            {
                var response = _servicePlayer.ListPlayer();
                return await ResponseAsync(response, _servicePlayer);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}