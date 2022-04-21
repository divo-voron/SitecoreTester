using System.Collections.Generic;

namespace Tester.JsonModels
{
    public class Ticket
    {
        public string Question { get; set; }

        public List<Answer> Answers { get; set; }

        public string Comment { get; set; }

        public List<AnswersLeft> AnswersLeft { get; set; }

        public List<AnswersRight> AnswersRight { get; set; }

        public bool? Multiselect { get; set; }

        public bool? Match { get; set; }
    }
}