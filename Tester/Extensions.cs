using System;
using System.Collections.Generic;
using Tester.Models;

namespace Tester
{
    public static class Extensions
    {
        public static List<QuestionModel> Random(this List<QuestionModel> questions)
        {
            var rand = new Random();
            for (var i = questions.Count - 1; i >= 1; i--)
            {
                var j = rand.Next(i + 1);

                var tmp = questions[j];
                questions[j] = questions[i];
                questions[i] = tmp;
            }

            return questions;
        }
    }
}
