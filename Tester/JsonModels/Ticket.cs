using System.Collections.Generic;

namespace Tester.JsonModels
{
    public class Ticket
    {
        public string question { get; set; }
        public List<Answer> answers { get; set; }
        public bool? multiselect { get; set; }
        public string comment { get; set; }
        public List<AnswersLeft> answersLeft { get; set; }
        public List<AnswersRight> answersRight { get; set; }
        public bool? match { get; set; }
    }
}