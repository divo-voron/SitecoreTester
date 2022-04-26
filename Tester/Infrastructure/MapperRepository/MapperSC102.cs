using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Tester.JsonModels.SC102;
using Tester.Models;

namespace Tester.Infrastructure.MapperRepository
{
    public class MapperSC102 : IMapper
    {
        public List<QuestionModel> MapToObject(string json)
        {
            var root = JsonConvert.DeserializeObject<Root>(json);

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
    }
}
