using System;
using Tester.Models;

namespace Tester.Infrastructure.QuestionnaireRepository
{
    public class QuestionnaireSC102 : Questionnaire
    {
        protected override void PrintAnswers(QuestionModel data)
        {
            if (data.IsMatch)
            {
                // TODO: realize
            }
            else
            {
                base.PrintAnswers(data);
            }
        }

        protected override void PrintQuestion(QuestionModel data)
        {
            if (data.IsMatch)
            {
                Console.WriteLine("Skip this question");
                // TODO: realize
            }
            else
            {
                base.PrintQuestion(data);
            }
        }
    }
}
