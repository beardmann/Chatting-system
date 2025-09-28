using System;

class Chatappp
{
    private string User1 { get; set; }
    private string User2 { get; set; }

    public Chatappp(string user1, string user2)
    {
        User1 = user1;
        User2 = user2;
    }

    public void StartChat()
    {
        Console.WriteLine($" Chat started between {User1} and {User2}");
        Console.WriteLine("Type 'exit' to end chat.\n");

        bool turn = true; // true = User1's turn, false = User2's turn

        while (true)
        {
            string currentUser = turn ? User1 : User2;
            Console.Write($"{currentUser}: ");
            string message = Console.ReadLine();

            if (string.Equals(message, "bye", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("🚪 Chat ended.");
                break;
            }

            Console.WriteLine($"📩 {currentUser} says: {message}");
            turn = !turn; // switch turn
        }
    }
}

