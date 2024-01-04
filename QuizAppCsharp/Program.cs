using System;
using System.Collections.Generic;

namespace QuizAppCsharp
{
    internal class Program
    {
        // Class to represent a question and its correct answer
        private class QuestionWithAnswer
        {
            public string Question { get; set; }
            public string[] Answers { get; set; }
            public int CorrectAnswerIndex { get; set; }
        }

        static void Main()
        {
            // Always Sunny in Philadelphia Questions
            List<QuestionWithAnswer> questionsWithAnswers = new List<QuestionWithAnswer>
            {
                new QuestionWithAnswer { Question = "What is the name of the bar?", Answers = new[] {"A. Pappy's Pub", "B. Paddy's Pub", "C. Player's Pub"}, CorrectAnswerIndex = 1 },
                new QuestionWithAnswer { Question = "What play does Charlie write and produce?", Answers = new[] {"A. The Dayman Cometh", "B. Charlie Cometh", "C. The Nightman Cometh"}, CorrectAnswerIndex = 2 },
                new QuestionWithAnswer { Question = "What is Mac's last name?", Answers = new[] {"A. McDonald", "B. Laswell", "C. MaCafee"}, CorrectAnswerIndex = 0 },
                new QuestionWithAnswer { Question = "What is the gang's favorite pastime and unofficial game in many episodes?", Answers = new[] {"A. Deedennis MacChar", "B. Chardee MacDennis", "C. MacDee Chardennis"}, CorrectAnswerIndex = 1 },
                new QuestionWithAnswer { Question = "What is Charlies favorite food?", Answers = new[] {"A. Cheese", "B. Milk Steak", "C. Rum Ham"}, CorrectAnswerIndex = 1 },
                new QuestionWithAnswer { Question = "What does the 'S' in the DENNIS system stand for?", Answers = new[] {"A. Seperate Entirely", "B. Support Emotionally", "C. Strive Excellence"}, CorrectAnswerIndex = 0 },
                new QuestionWithAnswer { Question = "Dennis is asshole, why Charlie hate?", Answers = new[] {"A. Because he slept with the waitress", "B. Because he didn't care his mom had cancer", "C. Because Dennis is a bastardman"}, CorrectAnswerIndex = 2 },
                new QuestionWithAnswer { Question = "What is the name of Frank's shell company?", Answers = new[] {"A. Fight Milk", "B. Wolf Cola", "C. Frank's Fluids"}, CorrectAnswerIndex = 2 },
                new QuestionWithAnswer { Question = "Who pooped the bed?", Answers = new[] {"A. Rickety Cricket", "B. Charlie", "C. Frank"}, CorrectAnswerIndex = 2 },
                new QuestionWithAnswer { Question = "Who slept with Dennis's prom date?", Answers = new[] {"A. Mac", "B. Tim Murphy", "C. Charlie"}, CorrectAnswerIndex = 0 }
            };

            // Shuffle questions and answers together
            ShuffleQuestions(questionsWithAnswers);

            int playerScore = 0;

            Console.WriteLine("So you think you're an Always Sunny fan?");
            Console.WriteLine("Please choose your answers by selecting A, B, or C");
            Console.Write("\n");

            // Loop through the questions
            for (int i = 0; i < questionsWithAnswers.Count; i++)
            {
                Console.WriteLine($"Question {i + 1}");
                Console.WriteLine(questionsWithAnswers[i].Question);
                Console.WriteLine(string.Join("\n", questionsWithAnswers[i].Answers));
                Console.WriteLine("\n");
                string playerAnswer = Console.ReadLine();

                if (string.Equals(playerAnswer, "A", StringComparison.OrdinalIgnoreCase) && questionsWithAnswers[i].CorrectAnswerIndex == 0)
                {
                    playerScore++;
                }
                else if (string.Equals(playerAnswer, "B", StringComparison.OrdinalIgnoreCase) && questionsWithAnswers[i].CorrectAnswerIndex == 1)
                {
                    playerScore++;
                }
                else if (string.Equals(playerAnswer, "C", StringComparison.OrdinalIgnoreCase) && questionsWithAnswers[i].CorrectAnswerIndex == 2)
                {
                    playerScore++;
                }
            }

            int playerAverage = playerScore * 100 / questionsWithAnswers.Count;

            // Print good job or not so good job
            if (playerScore == questionsWithAnswers.Count)
            {
                Console.WriteLine($"Great job you got all the answer correct! You scored a {playerAverage}%");
            }
            else if (playerScore >= questionsWithAnswers.Count / 2)
            {
                Console.WriteLine($"Good job you got most of the questions right! You scored a {playerAverage}%");
            }
            else
            {
                Console.WriteLine($"Stupid science b****** could even make you more smarter.  You scored a {playerAverage}%");
            }

            // Print the player's score
            Console.WriteLine($"You got {playerScore} out of {questionsWithAnswers.Count} correct.");
            Console.ReadLine();
        }

        // Fisher-Yates shuffle algorithm for questions
        static void ShuffleQuestions(List<QuestionWithAnswer> list)
        {
            Random random = new Random();
            int n = list.Count;
            for (int i = n - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);                
                QuestionWithAnswer temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }
    }
}
