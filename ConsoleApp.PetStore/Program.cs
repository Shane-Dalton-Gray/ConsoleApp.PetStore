using ConsoleApp.PetStore.Classes;
using System.Text.Json;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Press 1 to add a product");
        Console.WriteLine("Type 'exit' to quit");

        string? userInput = Console.ReadLine();

        while (userInput?.ToLower() != "exit")
        {
            if (userInput?.ToLower() == "1")
            {
                CatFood catFood = new CatFood();

                Console.WriteLine("How much does the cat food weigh in pounds?");
                string? weightInput = Console.ReadLine();

                if (double.TryParse(weightInput, out double weight))
                {
                    catFood.WeightPounds = weight;
                }
                else
                {
                    Console.WriteLine("Invalid weight. Please enter a valid number.");
                    continue;
                }

                Console.WriteLine("Is this kitten food? Type 'yes' or 'no')");
                string? kittenFoodInput = Console.ReadLine()?.ToLower();

                if (kittenFoodInput == "yes")
                {
                    catFood.KittenFood = true;
                }
                else if (kittenFoodInput == "no")
                {
                    catFood.KittenFood = false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                    continue;
                }

                Console.WriteLine(JsonSerializer.Serialize(catFood));
            }
            Console.WriteLine("Press 1 to add a product");
            Console.WriteLine("Type 'exit' to quit");
            userInput = Console.ReadLine();
        }
    }
}