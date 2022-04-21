using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Tester.JsonModels;
using Tester.Models;

namespace Tester
{
    public static class Converter
    {
        public static Root ReadFromFile(string path)
        {
            using var r = new StreamReader(path);
            var json = r.ReadToEnd();
            var root = JsonConvert.DeserializeObject<Root>(json);

            return root;
        }

        public static List<QuestionModel> Map(Root root)
        {
            var questions = new List<QuestionModel>();
            foreach (var data in root.Data)
            {
                questions.AddRange(data.Tickets.Select(x => new QuestionModel()
                {
                    Theme = data.Theme,
                    Answers = x.Answers,
                    AnswersLeft = x.AnswersLeft,
                    AnswersRight = x.AnswersRight,
                    Question = x.Question,
                    IsMultiselect = x.Multiselect ?? false,
                    IsMatch = x.Match ?? false,
                    Comment = x.Comment
                }));
            }

            return questions;
        }

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
