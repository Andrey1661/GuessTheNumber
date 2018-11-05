using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuessTheNumber.Models
{
    public class AnswerModel
    {
        [Required]
        public string HiddenNumber { get; set; }

        [Required(ErrorMessage = "Ответ не должен быть пустым")]
        [RegularExpression(@"\d{4}", ErrorMessage = "Ответом должны быть четыре цифры")]
        public string Value { get; set; }

        public int AttemptsCount { get; set; }
    }
}