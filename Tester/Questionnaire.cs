using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Tester.Models;

namespace Tester
{
    public class Questionnaire
    {
        private readonly List<QuestionModel> _questions;

        public Questionnaire(List<QuestionModel> questions)
        {
            _questions = questions;
        }

        public void Start()
        {
            var maxScore = _questions.Count;

            for (var index = 0; index < _questions.Count; index++)
            {
                Console.WriteLine($"QuestionModel {index + 1} from {maxScore}");
                Console.WriteLine();

                var data = _questions[index];
                PrintQuestion(data);
                PrintAnswers(data);

                if (data.IsMultiselect == true)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("There is several correct Answers");
                }

                var numbers = ReadAnswers();

                CountScore(numbers, data);

                Console.Clear();
            }
        }

        public void GetResult()
        {
            var score = _questions.Count(x => x.IsCorrect);
            var round = Math.Round(decimal.Divide(score, _questions.Count) * 100, 0);
            Console.WriteLine($"Score: {round}%");

            var testResults = _questions
                .Where(x => x.IsCorrect == false)
                .GroupBy(x => x.Theme)
                .OrderBy(x => x.Key);

            foreach (var result in testResults)
            {
                Console.WriteLine(result.Key);
            }
        }

        private void PrintQuestion(QuestionModel data)
        {
            var regex = new Regex("(.*)\\{(\\w+)\\|bold}(.*)");
            var m = regex.Match(data.Question);

            if (data.IsMatch)
            {
                Console.WriteLine("Skip this question");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                if (m.Success && m.Groups.Count == 4)
                {
                    Console.Write(m.Groups[1]);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(m.Groups[2]);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(m.Groups[3]);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine(data.Question);
                    Console.WriteLine();
                }
            }

            
            Console.ResetColor();
        }

        private void PrintAnswers(QuestionModel data)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (data.IsMatch)
            {
                //for (var i = 0; i < data.AnswersLeft.Count; i++)
                //{
                //    var answer = data.AnswersLeft[i];
                //    Console.WriteLine($"{i + 1}. {answer.Text}");
                //    Console.WriteLine();
                //}
                //Console.WriteLine();
                //Console.ForegroundColor = ConsoleColor.Yellow;
                //for (var i = 0; i < data.AnswersRight.Count; i++)
                //{
                //    var answer = data.AnswersRight[i];
                //    Console.WriteLine($"{i + 1}. {answer.Text}");
                //    Console.WriteLine();
                //}
            }
            else
            {
                for (var i = 0; i < data.Answers.Count; i++)
                {
                    var answer = data.Answers[i];
                    Console.WriteLine($"{i + 1}. {answer.Text}");
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            Console.ResetColor();
        }

        private IEnumerable<int> ReadAnswers()
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

        private void CountScore(IEnumerable<int> numbers, QuestionModel data)
        {
            var isCorrect = numbers.Any();
            if (numbers.Any())
            {
                isCorrect = numbers.Max() > data.Answers.Count ? false : true;
            }

            foreach (var number in numbers)
            {
                if (data.Answers.Count >= number && data.Answers[number - 1].IsCorrect == false)
                {
                    isCorrect = false;
                }
            }

            data.IsCorrect = isCorrect;
        }
    }
}
