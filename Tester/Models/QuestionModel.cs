using System.Collections.Generic;
using Tester.JsonModels;

namespace Tester.Models
{
    public class QuestionModel
    {
        public string Theme { get; set; }

        public string Question { get; set; }

        public List<Answer> Answers { get; set; }

        public List<AnswersLeft> AnswersLeft { get; set; }

        public List<AnswersRight> AnswersRight { get; set; }

        public bool IsCorrect { get; set; } = false;

        public bool IsMultiselect { get; set; } = false;

        public bool IsMatch { get; set; }

        public string Comment { get; set; }
    }
}
