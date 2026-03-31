using System;
using System.Threading;
using System.Media; // Required for playing WAV files

namespace CyberBot
{
    public class Chatbot
    {
        public string BotName { get; set; } = "ShieldBot";
        public string UserName { get; set; }

        // Method to play the voice greeting
        public void PlayGreetingAudio()
        {
            try
            {
                // Ensure welcome.wav is in the output folder (bin/Debug)
                SoundPlayer player = new SoundPlayer("welcome2.wav");
                player.Play();
            }
            catch (Exception)
            {
                Console.WriteLine("[Audio file not found, skipping voice greeting...]");
            }
        }

        // Method for the typing effect to make it feel conversational
        public void TypeLine(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(30); // 30ms delay per character
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        public void DisplayAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
              _______
             /       \
            |  [###]  |  CYBER AWARENESS BOT
             \_______/   v1.0
            ");
            Console.ResetColor();
            Console.WriteLine("============================================");
        }

        public void HandleUserQuery(string input)
        {
            string cleanInput = input.ToLower().Trim();

            if (string.IsNullOrEmpty(cleanInput))
            {
                TypeLine("I didn't quite catch that. Could you say something?", ConsoleColor.Red);
                return;
            }

            // Basic Response System logic
            if (cleanInput.Contains("purpose"))
            {
                TypeLine($"My purpose is to help you, {UserName}, stay safe from South African cyber threats!");
            }
            else if (cleanInput.Contains("phishing"))
            {
                TypeLine("Phishing is when scammers send fake emails to steal your bank login. Always check the sender's address!", ConsoleColor.Yellow);
            }
            else if (cleanInput.Contains("password"))
            {
                TypeLine("Use a passphrase like 'Blue-Elephant-2026!' instead of simple passwords.", ConsoleColor.Green);
            }
            else if (cleanInput.Contains("how are you"))
            {
                TypeLine("I'm running at 100% efficiency! Ready to protect your data.");
            }
            else
            {
                TypeLine("I'm not sure about that yet, but I'm learning! Ask me about phishing or passwords.", ConsoleColor.Gray);
            }
        }
    }
}