using System.Collections.Generic;
using Tester.JsonModels;

namespace Tester.Models
{
    public class Question
    {
        public string Theme { get; set; }
        public string question { get; set; }
        public List<Answer> answers { get; set; }

        public bool isCorrect { get; set; } = false;

        public bool? isMultiselect { get; set; } = false;

        public string comment { get; set; }
    }
}
