using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using XGame.Api.Controllers.Base;
using XGame.Domain.Arguments.Game;
using XGame.Domain.Interfaces.Services;
using XGame.Infra.Transactions;

namespace XGame.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/game")]
    public class GameController : ControllerBase
    {
        private readonly IServiceGame _serviceGame;

        public GameController(IUnitOfWork unitOfWork, IServiceGame serviceGame) : base(unitOfWork)
        {
            _serviceGame = serviceGame;
        }

        [Route("list")]
        [HttpGet]
        public async Task<HttpResponseMessage> List()
        {
            try
            {
                var response = _serviceGame.ListGame();
                return await ResponseAsync(response, _serviceGame);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("add")]
        [HttpPost]
        public async Task<HttpResponseMessage> Add(AddGameRequest request)
        {
            try
            {
                var response = _serviceGame.AddGame(request);
                return await ResponseAsync(response, _serviceGame);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("update")]
        [HttpPut]
        public async Task<HttpResponseMessage> Update(UpdateGameRequest request)
        {
            try
            {
                var response = _serviceGame.UpdateGame(request);
                return await ResponseAsync(response, _serviceGame);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            try
            {
                var response = _serviceGame.RemoveGame(id);
                return await ResponseAsync(response, _serviceGame);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}