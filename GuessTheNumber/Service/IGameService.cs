using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GuessTheNumber.Models;

namespace GuessTheNumber.Service
{
    public interface IGameService
    {
        GameModel CreateNewGame();
        GameModel UpdateModel(AnswerModel answer);
    }
}