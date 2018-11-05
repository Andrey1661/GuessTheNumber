using System;
using System.Linq;
using System.Text;
using GuessTheNumber.Models;

namespace GuessTheNumber.Service
{
    public class GameService : IGameService
    {
        private const int MinValue = 0;
        private const int MaxValue = 9999;
        private const int DigitsCount = 4;

        private readonly Random _random;

        public GameService()
        {
            _random = new Random();
        }

        public GameModel CreateNewGame()
        {
            string number = GetNumberString();

            return new GameModel
            {
                AttemptsCount = 0,
                Mask = "XXXX",
                Success = false,
                HiddenNumber = number
            };
        }

        public GameModel UpdateModel(AnswerModel answer)
        {
            string mask = GetMask(answer.HiddenNumber, answer.Value);

            return new GameModel
            {
                Mask = mask,
                HiddenNumber = answer.HiddenNumber,
                AttemptsCount = answer.AttemptsCount + 1,
                Success = answer.HiddenNumber == answer.Value
            };
        }

        private string GetMask(string hiddenNumber, string answer)
        {
            if (answer.Length != DigitsCount)
            {
                throw new ArgumentException($"Ответ должен состоять из {DigitsCount} цифр");
            }

            var sb = new StringBuilder();

            //Логика игры
            for (int i = 0; i < DigitsCount; i++)
            {
                char a = hiddenNumber[i];
                char b = answer[i];

                if (a == b)
                {
                    sb.Append('B');
                }
                else if (hiddenNumber.Contains(b))
                {
                    sb.Append('K');
                }
                else
                {
                    sb.Append('X');
                }
            }

            return sb.ToString();
        }

        private string GetNumberString()
        {
            int number = _random.Next(MinValue, MaxValue);
            return number.ToString("D4");
        }
    }
}