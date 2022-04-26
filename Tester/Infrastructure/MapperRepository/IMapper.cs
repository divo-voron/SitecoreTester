using System.Collections.Generic;
using Tester.Models;

namespace Tester.Infrastructure.MapperRepository
{
    public interface IMapper
    {
        public List<QuestionModel> MapToObject(string json);
    }
}
