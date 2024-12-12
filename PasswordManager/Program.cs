﻿namespace PasswordManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Password Manager");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Designed by Tim Dladla and Dylan Hall");

            string filePath = "google_passwords.txt"; // Change to your file path

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return;
            }

            try
            {
                List<string> passwords = ExtractPasswords(filePath);

                Console.WriteLine("Passwords in the file:");
                foreach (var password in passwords)
                {
                    Console.WriteLine(password);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // Function to extract passwords from the file
        static List<string> ExtractPasswords(string filePath)
        {
            var passwords = new List<string>();

            // Read all lines from the file
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                // Assuming passwords are stored in "Password:" prefix format
                if (line.StartsWith("Password:", StringComparison.OrdinalIgnoreCase))
                {
                    // Extract the password value after "Password:"
                    string password = line.Substring("Password:".Length).Trim();
                    passwords.Add(password);
                }
            }

            return passwords;
        }



    }
}