using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Tester.JsonModels.SC10Exam;
using Tester.Models;

namespace Tester.Infrastructure.MapperRepository
{
    public class MapperSC10Exam : IMapper
    {
        public List<QuestionModel> MapToObject(string json)
        {
            var root = JsonConvert.DeserializeObject<Root>(json);

            return root.Tickets.Select(ticket => new QuestionModel()
                {
                    Answers = ticket.Answers,
                    Question = ticket.Question,
                    IsMultiselect = ticket.Multiselect ?? false,
                    Comment = ticket.Comment
                })
                .ToList();
        }
    }
}
