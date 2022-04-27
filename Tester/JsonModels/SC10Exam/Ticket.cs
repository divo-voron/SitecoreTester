using System.Collections.Generic;
using Tester.JsonModels.Common;

namespace Tester.JsonModels.SC10Exam
{
    public class Ticket
    {
        public int? Number { get; set; }

        public string Question { get; set; }

        public List<Answer> Answers { get; set; }

        public string Comment { get; set; }

        public bool? Multiselect { get; set; }
    }
}