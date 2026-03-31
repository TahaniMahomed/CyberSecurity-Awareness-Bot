using System;

namespace CyberBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Chatbot myBot = new Chatbot();

            // 1. Initial Launch Multimedia
            myBot.DisplayAsciiArt();
            myBot.PlayGreetingAudio();

            // 2. Personalization
            myBot.TypeLine("Hello! I am your Cybersecurity Assistant. What is your name?");
            string name;
            do
            {
                Console.Write("Your Name: ");
                name = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(name));

            myBot.UserName = name;

            myBot.TypeLine($"Nice to meet you, {myBot.UserName}! How can I help you stay safe today?", ConsoleColor.Cyan);
            Console.WriteLine("--------------------------------------------");

            // 3. Main Chat Loop
            bool running = true;
            while (running)
            {
                Console.Write($"{myBot.UserName}: ");
                string input = Console.ReadLine();
                if (input.ToLower() == "exit" || input.ToLower() == "quit")
                {
                    running = false;
                    myBot.TypeLine($"GOODBYE {myBot.UserName}, STAY CYBER SAFE!", ConsoleColor.Green);
                
            }
                else
                {
                    myBot.HandleUserQuery(input);
                }
            }
        }
    }
}