using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Tester.JsonModels;
using Tester.Models;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            var folder = "c:\\Mentoring\\Sitecore\\SitecoreTesterData\\files\\";
            var sc93 = "SC9.3.json";
            var sc102 = "SC10.2.json";
            var path = folder + sc93;

            var root = DataConverter.ReadData(path);
            var questions = DataConverter.ConvertData(root);

            var rand = new Random();
            for (var i = questions.Count - 1; i >= 1; i--)
            {
                var j = rand.Next(i + 1);

                var tmp = questions[j];
                questions[j] = questions[i];
                questions[i] = tmp;
            }

            var maxScore = questions.Count;
            var score = 0;

            for (var index = 0; index < questions.Count; index++)
            {
                Console.WriteLine($"Question {index + 1} from {maxScore}");
                Console.WriteLine();

                var data = questions[index];
                PrintQuestion(data);
                PrintAnswers(data);

                if (data.isMultiselect == true)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("There is several correct answers");
                }

                var numbers = ReadAnswers();

                CountScore(numbers, data, ref score);

                //Console.ReadKey();
                Console.Clear();
            }

            var scoreG = questions.Count(x => x.isCorrect);
            var round = Math.Round(decimal.Divide(scoreG, maxScore) * 100, 0);
            Console.WriteLine($"Score: {round}%");

            var testResults = questions
                .Where(x => x.isCorrect == false)
                .GroupBy(x => x.Theme)
                .OrderBy(x => x.Key);
            foreach (var result in testResults)
            {
                Console.WriteLine(result.Key);
            }
        }

        private static void PrintQuestion(Question data)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(data.question);
            Console.WriteLine();
            Console.ResetColor();
        }

        private static void PrintAnswers(Question data)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (var i = 0; i < data.answers.Count; i++)
            {
                var answer = data.answers[i];
                Console.WriteLine($"{i + 1}. {answer.text}");
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.ResetColor();
        }

        private static IEnumerable<int> ReadAnswers()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            var numberStr = Console.ReadLine()?.Split(' ', ',').ToList();
            var numbers = new List<int>();
            if (numberStr == null || !numberStr.Any())
            {
                return numbers;
            }

            foreach (var numberValue in numberStr)
            {
                if (int.TryParse(numberValue, out var number))
                {
                    numbers.Add(number);
                }
            }

            return numbers;
        }

        private static void CountScore(IEnumerable<int> numbers, Question data, ref int score)
        {
            var isCorrect = numbers.Any();
            if (numbers.Any())
            {
                isCorrect = numbers.Max() > data.answers.Count ? false : true;
            }

            foreach (var number in numbers)
            {
                if (data.answers.Count >= number && data.answers[number - 1].isCorrect == false)
                {
                    isCorrect = false;
                }
            }

            data.isCorrect = isCorrect;
            if (isCorrect)
            {
                score++;
            }
        }
    }
}
