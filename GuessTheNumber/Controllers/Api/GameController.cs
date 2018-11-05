using System.Web.Http;
using GuessTheNumber.Models;
using GuessTheNumber.Service;
using Route = System.Web.Http.RouteAttribute;

namespace GuessTheNumber.Controllers.Api
{
    public class GameController : ApiController
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [@Route("api/new")]
        [HttpGet]
        public IHttpActionResult GetNew()
        {
            var model = _gameService.CreateNewGame();
            return Json(model);
        }

        [@Route("api/postanswer")]
        [HttpPost]
        public IHttpActionResult PostAnswer([FromBody]AnswerModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gameService.UpdateModel(model);
            return Json(result);
        }
    }
}
