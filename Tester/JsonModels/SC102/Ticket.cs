using System.Collections.Generic;
using Tester.JsonModels.Common;
using Tester.JsonModels.SC93;

namespace Tester.JsonModels.SC102
{
    public class Ticket
    {
        public int? Number { get; set; }

        public string Question { get; set; }

        public List<Answer> Answers { get; set; }

        public string Comment { get; set; }

        public List<AnswersLeft> AnswersLeft { get; set; }

        public List<AnswersRight> AnswersRight { get; set; }

        public bool? Multiselect { get; set; }

        public bool? Match { get; set; }
    }
}