using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Quiz_med_JSON_serialisering {
    class MainClass {
        public static int choices {get; set; }
        public static string path { get; set; }
        public static void Main() {
           

            Console.WriteLine("1. Start Sql Quiz");
            Console.WriteLine("2. Start vandværk Quiz");
            Console.WriteLine("3. Exit");
            try {
                choices = int.Parse(Console.ReadLine());
            }
            catch (Exception) {
                Console.WriteLine("Invalid input, please try again.");
                Main();
            }
            
            string filePath = @"C:\Users\salih\source\repos\Quiz-med-JSON-serialisering\Quiz-med-JSON-serialisering\MultiKeyValue.json";
            string filePathSql = @"C:\Users\salih\source\repos\Quiz-med-JSON-serialisering\Quiz-med-JSON-serialisering\MutliKeyValueSql.json";

            switch (choices) {
                case 1:
                    path = filePathSql;
                    break;
                case 2:
                    path = filePath;
                    break;
                case 3:
                    Console.WriteLine("3. Exit");
                    Environment.Exit(0);
                    break;
            }

            int i = 0;
            string jsonString = File.ReadAllText(path);

            Quiz? quizData = JsonSerializer.Deserialize<Quiz>(jsonString);
                  
            foreach (var question in quizData.quiz) {
                Console.Clear();
                Console.WriteLine($"Question: {question.question}");
                Console.WriteLine("Choices:");

                    foreach (var choice in question.choices) {
                        i++;
                        Console.WriteLine($"{i} - {choice}");
                        if (i == question.choices.Count) {
                            i = 0;
                        }
                    }
                    try {
                        string answer = Console.ReadLine();
                        if (question.correct == question.choices[int.Parse(answer) - 1]) {
                            Console.WriteLine("Correct!");
                        }
                        else {
                            Console.WriteLine("Incorrect!");
                        }
                        Console.WriteLine($"Correct Answer: {question.correct}\n");
                    }
                    catch (Exception) {
                        Console.WriteLine("Invalid input, please try again.");
                       
                    }
                    Console.ReadKey();
            }
            choices = 0;
        }
    }

    public class Quiz {
        public List<Question> quiz { get; set; }
    }

    public class Question {
        public string question { get; set; }
        public List<string> choices { get; set; }
        public string correct { get; set; }
    }
}
