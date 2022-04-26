using System;
using System.IO;
using Tester.Infrastructure;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            var folder = "c:\\Mentoring\\Sitecore\\SitecoreTesterData\\files\\";
            var sc93 = "SC9.3.json";
            var sc102 = "SC10.2.json";
            var sc10Exam = "SC10_exam.json";

            Console.WriteLine("Load exam:");
            Console.WriteLine("1. " + sc93);
            Console.WriteLine("2. " + sc102);
            Console.WriteLine("3. " + sc10Exam);
            var resultString = Console.ReadLine();
            Console.Clear();

            var resolver = new Resolver(resultString, folder, sc93, sc102, sc10Exam);

            var path = resolver.GetPath();
            var questionnaire = resolver.GetQuestionnaire();
            var mapper = resolver.GetMapper();

            if (string.IsNullOrWhiteSpace(path))
            {
                return;
            }

            using var r = new StreamReader(path);
            var json = r.ReadToEnd();
            var questions = mapper.MapToObject(json);//.Random();

            questionnaire.Init(questions);
            questionnaire.Start();
            questionnaire.GetResult();
        }
    }
}
