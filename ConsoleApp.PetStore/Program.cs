using ConsoleApp.PetStore;
using ConsoleApp.PetStore.Classes;
using System.Text.Json;

internal class Program
{
    private static void Main()
    {
        var productLogic = new ProductLogic();

        Console.WriteLine("Press 1 to add a product");
        Console.WriteLine("Press 2 to view a dog leash");
        Console.WriteLine("Type 'exit' to quit");

        string? userInput = Console.ReadLine();

        while (userInput?.ToLower() != "exit")
        {
            if (userInput == "1")
            {
                Console.WriteLine("Is this product cat food or a dog leash?");
                string? productTypeInput = Console.ReadLine();

                if (productTypeInput?.ToLower().Trim() == "cat food")
                {
                    CatFood catFood = new CatFood();

                    Console.WriteLine("What is the name of the cat food?");
                    catFood.Name = Console.ReadLine();

                    Console.WriteLine("Describe the cat food concisely.");
                    catFood.Description = Console.ReadLine();

                    Console.WriteLine("How much does the cat food cost?");
                    string? priceInput = Console.ReadLine();

                    if (decimal.TryParse(priceInput, out decimal price))
                    {
                        catFood.Price = price;
                    }
                    else
                    {
                        Console.WriteLine("Invalid price. Please enter a valid number.");
                        continue;
                    }

                    Console.WriteLine("What quantity of this cat food are you adding?");
                    string? quantityInput = Console.ReadLine();

                    if(int.TryParse(quantityInput, out int quantity))
                    {
                        catFood.Quantity = quantity;
                    }
                    else
                    {
                        Console.WriteLine("Invalid quantity. Please enter a valid number.");
                        continue;
                    }

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

                    productLogic.AddProduct(catFood);

                    Console.WriteLine("Cat food product has been added.");
                }
                else if (productTypeInput?.ToLower().Trim() == "dog leash")
                {
                    DogLeash dogLeash = new DogLeash();

                    Console.WriteLine("What is the name of the dog leash?");
                    dogLeash.Name = Console.ReadLine();

                    Console.WriteLine("Describe the dog leash concisely.");
                    dogLeash.Description = Console.ReadLine();

                    Console.WriteLine("How much does the dog leash cost?");
                    string? priceInput = Console.ReadLine();

                    if (decimal.TryParse(priceInput, out decimal price))
                    {
                        dogLeash.Price = price;
                    }
                    else
                    {
                        Console.WriteLine("Invalid price. Please enter a valid number.");
                        continue;
                    }

                    Console.WriteLine("What quantity of this dog leash are you adding?");
                    string? quantityInput = Console.ReadLine();

                    if (int.TryParse(quantityInput, out int quantity))
                    {
                        dogLeash.Quantity = quantity;
                    }
                    else
                    {
                        Console.WriteLine("Invalid quantity. Please enter a valid number.");
                        continue;
                    }

                    Console.WriteLine("How long is the dog leash in inches?");
                    string? lengthInput = Console.ReadLine();

                    if (int.TryParse(lengthInput, out int length))
                    {
                        dogLeash.LengthInches = length;
                    }
                    else
                    {
                        Console.WriteLine("Invalid length. Please enter a valid number.");
                        continue;
                    }

                    Console.WriteLine("What material is this dog leash made of?");
                    dogLeash.Material = Console.ReadLine();

                    productLogic.AddProduct(dogLeash);

                    Console.WriteLine("Dog leash product has been added.");
                }
            }
            else if (userInput == "2")
            {
                Console.WriteLine("Enter the name of the product you want to view.");
                string? productName = Console.ReadLine();

                DogLeash dogLeash = productLogic.GetDogLeashByName(productName);
                Console.WriteLine(JsonSerializer.Serialize(dogLeash));
            }

            Console.WriteLine("Press 1 to add a product");
            Console.WriteLine("Press 2 to view a dog leash");
            Console.WriteLine("Type 'exit' to quit");
            userInput = Console.ReadLine();
        }
    }
}