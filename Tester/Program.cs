namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            var folder = "c:\\Mentoring\\Sitecore\\SitecoreTesterData\\files\\";
            var sc93 = "SC9.3.json";
            var sc102 = "SC10.2.json";
            var path = folder + sc102;

            var root = Converter.ReadFromFile(path);
            var questions = Converter.Map(root).Random();

            var questionnaire = new Questionnaire(questions);
            questionnaire.Start();
            questionnaire.GetResult();
        }
    }
}
