#pragma warning disable CS8321

void GradesExample()
{
    var studentGradesMap = new Dictionary<string, decimal[]>()
    {
        { "sophia", new decimal[] { 90, 86, 87, 98, 100, 94, 90 } },
        { "andrew", new decimal[] { 92, 89, 81, 96, 90, 89 } },
        { "emma", new decimal[] { 90, 85, 87, 98, 68, 89, 89, 89 } },
        { "logan", new decimal[] { 90, 95, 87, 88, 96, 96 } },
        { "becky", new decimal[] { 92, 91, 90, 91, 92, 92, 92 } },
        { "chris", new decimal[] { 84, 86, 88, 90, 92, 94, 96, 98 } },
        { "eric", new decimal[] { 80, 90, 100, 80, 90, 100, 80, 90 } },
        { "gregor", new decimal[] { 91, 91, 91, 91, 91, 91, 91} }
    };

    string GetGrade(decimal grade)
    {
        /**
        97 - 100   A+
        93 - 96    A
        90 - 92    A-
        87 - 89    B+
        83 - 86    B
        80 - 82    B-
        77 - 79    C+
        73 - 76    C
        70 - 72    C-
        67 - 69    D+
        63 - 66    D
        60 - 62    D-
        0  - 59    F
        */

        string gradeStr = grade switch
        {
            >= 97 => "A+",
            >= 93 => "A",
            >= 90 => "A-",
            >= 87 => "B+",
            >= 83 => "B",
            >= 80 => "B-",
            >= 77 => "C+",
            >= 73 => "C",
            >= 70 => "C-",
            >= 67 => "D+",
            >= 63 => "D",
            >= 60 => "D-",
            >= 0 => "F",
            _ => "Invalid",
        };
        return gradeStr;
    }

    Console.WriteLine("Student\t\tExam Score\tOverall Grade\tExtra Credit\n");
    foreach (var entry in studentGradesMap)
    {
        const int N_ASSIGNMENTS = 5;

        var studentName = entry.Key;
        var studentGrades = entry.Value;

        int collected = 0;
        decimal aggregator(decimal total, decimal next)
        {
            if (++collected >= 5)
            {
                return total + (next / 10.0M);
            }
            else
            {
                return total + next;
            }
        }

        decimal examPoints = studentGrades[..N_ASSIGNMENTS].Sum() / N_ASSIGNMENTS;
        decimal overallPoints = studentGrades.Aggregate(aggregator) / N_ASSIGNMENTS;
        string examScore = GetGrade(overallPoints);

        var extraGrades = studentGrades[N_ASSIGNMENTS..];
        var extraCredit = extraGrades.Sum() / extraGrades.Length;
        var extraPoints = overallPoints - examPoints;

        Console.WriteLine($"{studentName}:\t\t{examPoints}\t\t{overallPoints}\t{examScore}\t{extraCredit} ({extraPoints} pts)");
    }
}

void HeadsOrTails()
{
    Console.WriteLine($"{(new Random().Next() % 2 == 0 ? "Heads" : "Tails")}");
}

void PermissionExample()
{
    const string permission = "Admin";
    const int level = 56;

    switch ((permission, level))
    {
        case ("Admin", > 55):
            Console.WriteLine("Welcome, Super Admin user.");
            break;

        case ("Admin", <= 55):
            Console.WriteLine("Welcome, Admin user.");
            break;

        case ("Manager", >= 20):
            Console.WriteLine("Contact an Admin for access.");
            break;

        case ("Manager", < 20):
            Console.WriteLine("You do not have sufficient privileges.");
            break;

        default:
            Console.WriteLine("You do not have sufficient privileges.");
            break;
    }
}

void ClothesProductExample()
{
    // SKU = Stock Keeping Unit.
    // SKU value format: <product #>-<2-letter color code>-<size code>
    string sku = "01-MN-L";

    string[] product = sku.Split('-');

    string type = product[0] switch
    {
        "01" => "Sweat shirt",
        "02" => "T-Shirt",
        "03" => "Sweat pants",
        _ => "Other",
    };

    string color = product[1] switch
    {
        "BL" => "Black",
        "MN" => "Maroon",
        _ => "White",
    };

    string size = (product[2]) switch
    {
        "S" => "Small",
        "M" => "Medium",
        "L" => "Large",
        _ => "One Size Fits All"
    };

    Console.WriteLine($"Product: {size} {color} {type}");
}

void FizzBuzzExample()
{
    for (uint i = 1; i <= 100; ++i)
    {
        if ((i % (3 * 5)) == 0)
        {
            Console.WriteLine($"{i} - FizzBuzz");
        }
        else if (i % 3 == 0)
        {
            Console.WriteLine($"{i} - Fizz");
        }
        else if (i % 5 == 0)
        {
            Console.WriteLine($"{i} - Buzz");
        }
        else
        {
            Console.WriteLine(i);
        }
    }
}


void RPGExample()
{
    var random = new Random();
    var playerHealth = 10;
    var monsterHealth = 10;
    var isPlayersTurn = true;
    var gameOver = false;

    do
    {
        var attackValue = random.Next(1, 11);
        if (isPlayersTurn)
        {
            monsterHealth -= attackValue;
            Console.WriteLine($"Monster lost {attackValue} health. Remaining health: {monsterHealth}");
        }
        else
        {
            playerHealth -= attackValue;
            Console.WriteLine($"Player lost {attackValue} health. Remaining health: {playerHealth}");
        }

        isPlayersTurn = !isPlayersTurn;
        gameOver = playerHealth <= 0 || monsterHealth <= 0;
    } while (!gameOver);

    Console.WriteLine($"Winner is {(playerHealth >= 0 ? "Player" : "Monster")}");
}

void Valid5To10InputExample()
{
    string? input;
    int choice;
    var validEntry = false;
    var validRange = new Range(5, 10);

    Console.WriteLine("Enter a number between 5 - 10");
    do
    {
        input = Console.ReadLine();
        validEntry = int.TryParse(input, out choice) && choice >= 5 && choice <= 10;
        if (!validEntry)
        {
            Console.WriteLine($"Invalid Choice: {choice}. Enter a number between 5 - 10");
        }
    } while (!validEntry);

    Console.WriteLine($"Your choice is {choice}");
}

void PeriodsSubstringExample()
{
    string[] myStrings = { "I like pizza. I like roast chicken. I like salad", "I like all three of the menu choices" };

    foreach (var str in myStrings)
    {
        foreach (var separatedStr in str.Split("."))
        {
            Console.WriteLine(separatedStr.Trim());
        }
    }

}

void RunTest()
{
    // GradesExample();
    // HeadsOrTails();
    // PermissionExample();
    // ClothesProductExample();
    // FizzBuzzExample();
    // RPGExample();
    // Valid5To10InputExample();
    PeriodsSubstringExample();
}

RunTest();
