using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Tester.JsonModels.SC93;
using Tester.Models;

namespace Tester.Infrastructure.MapperRepository
{
    public class MapperSC93 : IMapper
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
                    Question = x.Question,
                    IsMultiselect = x.Multiselect ?? false,
                    Comment = x.Comment
                }));
            }

            return questions;
        }
    }
}
