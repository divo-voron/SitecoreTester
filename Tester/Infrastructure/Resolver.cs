using Tester.Infrastructure.MapperRepository;
using Tester.Infrastructure.QuestionnaireRepository;

namespace Tester.Infrastructure
{
    public class Resolver
    {
        private string ResultString { get; set; }
        private string Folder { get; set; }
        private string SC93 { get; set; }
        private string SC102 { get; set; }
        private string SC10Exam { get; set; }

        public Resolver(string resultString, string folder, string sc93, string sc102, string sc10Exam)
        {
            ResultString = resultString;
            Folder = folder;
            SC93 = sc93;
            SC102 = sc102;
            SC10Exam = sc10Exam;
        }

        public string GetPath()
        {
            if (!int.TryParse(ResultString, out var result))
            {
                return null;
            }

            return result switch
            {
                1 => Folder + SC93,
                2 => Folder + SC102,
                3 => Folder + SC10Exam,
                _ => null
            };
        }

        public IQuestionnaire GetQuestionnaire()
        {
            if (!int.TryParse(ResultString, out var result))
            {
                return null;
            }

            return result switch
            {
                1 => new QuestionnaireSC93(),
                2 => new QuestionnaireSC102(),
                3 => new QuestionnaireSC10Exam(),
                _ => null
            };
        }

        public IMapper GetMapper()
        {
            if (!int.TryParse(ResultString, out var result))
            {
                return null;
            }

            return result switch
            {
                1 => new MapperSC93(),
                2 => new MapperSC102(),
                3 => new MapperSC10Exam(),
                _ => null
            };
        }
    }
}
