using System.Collections.Generic;
using Tester.Models;

namespace Tester.Infrastructure.QuestionnaireRepository
{
    public interface IQuestionnaire
    {
        public void Init(List<QuestionModel> questions);

        public void Start();

        public void GetResult();
    }
}
