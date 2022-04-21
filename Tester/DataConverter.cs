using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Tester.JsonModels;
using Tester.Models;

namespace Tester
{
    public class DataConverter
    {
        public static Root ReadData(string path)
        {
            using var r = new StreamReader(path);
            var json = r.ReadToEnd();
            var root = JsonConvert.DeserializeObject<Root>(json);

            return root;
        }

        public static List<Question> ConvertData(Root root)
        {
            var questions = new List<Question>();
            foreach (var data in root.Data)
            {
                questions.AddRange(data.Tickets.Select(x => new Question()
                {
                    Theme = data.Theme,
                    answers = x.answers,
                    question = x.question,
                    isMultiselect = x.multiselect,
                    comment = x.comment
                }));
            }

            return questions;
        }
    }
}
