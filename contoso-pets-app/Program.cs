using Animals;

// variables that support data entry
int maxPets = 3;
// array used to store runtime data, there is no persisted data
List<Animal> ourAnimals = new();

// create some initial ourAnimals array entries
for (int i = 0; i < maxPets; i++)
{
    Animal animal = i switch
    {
        0 => new()
        {
            Species = "dog",
            ID = "d1",
            Age = "2",
            PhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.",
            PersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.",
            Nickname = "lola",
            SuggestedDonation = "83.00",
        },
        1 => new()
        {
            Species = "dog",
            ID = "d2",
            Age = "9",
            PhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.",
            PersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.",
            Nickname = "loki",
            SuggestedDonation = "38.00",
        },
        2 => new()
        {
            Species = "cat",
            ID = "c3",
            Age = "1",
            PhysicalDescription = "small white female weighing about 8 pounds. litter box trained.",
            PersonalityDescription = "friendly",
            Nickname = "Puss",
            SuggestedDonation = "50.00",
        },
        3 => new()
        {
            Species = "cat",
            ID = "c4",
            Age = "?",
            PhysicalDescription = "",
            PersonalityDescription = "",
            Nickname = "",
            SuggestedDonation = "17.00",
        },
        _ => new()
        {
            Species = "",
            ID = "",
            Age = "",
            PhysicalDescription = "",
            PersonalityDescription = "",
            Nickname = "",
            SuggestedDonation = "",
        }
    };

    ourAnimals.Add(animal);
}

void PrintAnimals()
{
    foreach (var animal in ourAnimals)
    {
        Console.WriteLine(animal.Details());
    }
}

void AddNewAnimal()
{
    string[] allowsSpecies = { "dog", "cat" };

    string? species;
    string? name;
    uint? age = null;
    string? personality;
    string? description;
    float suggestedDonation;

    do
    {
        Console.WriteLine("Enter Species: ");
        species = Console.ReadLine();
        if (species == null || !allowsSpecies.Contains(species.ToLower()))
        {
            species = null;
            Console.WriteLine("Invalid Input. Try again.");
        }
        else
        {
            species = species.ToLower();
        }
    } while (species == null);


    do
    {
        Console.WriteLine("Enter Name: ");
        name = Console.ReadLine();
        if (name == null || name == "")
        {
            name = null;
            Console.WriteLine("Invalid Input. Try again.");
        }
    } while (name == null);

    do
    {
        Console.WriteLine("Enter Age: ");
        string? tempAge = Console.ReadLine();
        if (tempAge != null && uint.TryParse(tempAge, out uint tempAgeNum))
        {
            age = tempAgeNum;
        }
        else
        {
            Console.WriteLine("Invalid Input. Try again.");
        }
    } while (age == null);

    do
    {
        Console.WriteLine("Enter Personality Description: ");
        personality = Console.ReadLine();
        if (personality == null || personality == "")
        {
            personality = null;
            Console.WriteLine("Invalid Input. Try again.");
        }
    } while (personality == null);

    do
    {
        Console.WriteLine("Enter Physical Description: ");
        description = Console.ReadLine();
        if (description == null || description == "")
        {
            description = null;
            Console.WriteLine("Invalid Input. Try again.");
        }
    } while (description == null);

    Console.WriteLine("Enter Suggested Donation: ");
    string? tempDonation = Console.ReadLine();
    if (!float.TryParse(tempDonation, out suggestedDonation))
    {
        suggestedDonation = 45.0F;
    }

    ourAnimals.Add(new()
    {
        ID = $"#{species}-{ourAnimals.Count}",
        Species = species,
        Nickname = name,
        Age = $"{age}",
        PersonalityDescription = personality,
        PhysicalDescription = description,
        SuggestedDonation = $"{suggestedDonation}",
    });
}

void DisplayMatchedDogCharacteristics()
{
    Console.WriteLine("Enter a desired dog characteristics to search for (separated by ',')");

    string[] dogCharacteristics;
    string fullDogChars;
    string[] searchDots = { ".", "..", "..." };
    string[] searchSpin = { "\\", "|", "/" };

    while (true)
    {
        string? input = Console.ReadLine();
        if (input != null && input.Trim().Length != 0)
        {
            fullDogChars = input.ToLower().Trim();
            dogCharacteristics = fullDogChars.Split(',');
            for (uint idx = 0; idx < dogCharacteristics.Length; ++idx)
            {
                dogCharacteristics[idx] = dogCharacteristics[idx].Trim().ToLower();
            }
            break;
        }

        Console.WriteLine("Invalid search characteristics. Try Again.");
    }


    bool DogsSearchPredicate(Animal animal)
    {
        if (animal.Species.ToLower() != "dog")
            return false;

        var matched = false;
        foreach (var dogChar in dogCharacteristics)
        {
            var cntr = 0;
            while (cntr++ < 6)
            {
                var searchIdx = cntr % 3;
                var dots = searchDots[searchIdx];
                var spin = searchSpin[searchIdx];
                // No new line
                Console.Write($"Searching Dog '{animal.Nickname}' for '{dogChar}' {dots,-3} {dogChar} {spin} {searchIdx}");
                Thread.Sleep(200);
                // Use carriage return to jump to start, zero-ize, the jump back to start
                Console.Write($"\r{new string(' ', Console.WindowWidth - 1)}\r");
            }

            if (animal.PhysicalDescription.ToLower().Contains(dogChar))
            {
                Console.WriteLine($"Dog '{animal.Nickname}' match found for: '{dogChar}'");
                matched = true;
            }
        }

        return matched;
    }

    var matchedDogs = 0;

    foreach (var dog in ourAnimals)
    {
        if (DogsSearchPredicate(dog))
        {
            Console.WriteLine(dog.Details());
            matchedDogs++;
        }

    }

    if (matchedDogs == 0)
    {
        Console.WriteLine($"None of our dogs are a match found for: {fullDogChars}");

    }
}

string? readResult;
string menuSelection;
Console.Clear();
// display the top-level menu options
while (true)
{
    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Edit an animal's age");
    Console.WriteLine(" 4. Edit an animal's personality description");
    Console.WriteLine(" 5. Display all cats with a specified characteristic");
    Console.WriteLine(" 6. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        Console.Clear();
        menuSelection = readResult.ToLower();
        Console.WriteLine($"You selected menu option {menuSelection}.");
        switch (menuSelection)
        {
            case "1":
                {
                    PrintAnimals();
                    break;
                }

            case "2":
                {
                    AddNewAnimal();
                    break;
                }

            case "3":
            case "4":
                break;

            case "5":
                break;

            case "6":
                {
                    DisplayMatchedDogCharacteristics();
                    break;
                }

            case "exit":
                {
                    return 0;
                }

            default:
                Console.WriteLine($"Invalid Menu selection: {menuSelection}");
                break;
        }
    }

    Console.WriteLine("Press the Enter key to continue.");
    readResult = Console.ReadLine();
}

