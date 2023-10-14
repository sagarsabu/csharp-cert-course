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

void MinMaxValues()
{
    Console.WriteLine("Signed integral types:");

    Console.WriteLine($"sbyte   : {sbyte.MinValue} to {sbyte.MaxValue}");
    Console.WriteLine($"short   : {short.MinValue} to {short.MaxValue}");
    Console.WriteLine($"int     : {int.MinValue} to {int.MaxValue}");
    Console.WriteLine($"long    : {long.MinValue} to {long.MaxValue}");

    Console.WriteLine();
    Console.WriteLine("Unsigned integral types:");

    Console.WriteLine($"byte   : {byte.MinValue} to {byte.MaxValue}");
    Console.WriteLine($"ushort : {ushort.MinValue} to {ushort.MaxValue}");
    Console.WriteLine($"uint   : {uint.MinValue} to {uint.MaxValue}");
    Console.WriteLine($"ulong  : {ulong.MinValue} to {ulong.MaxValue}");

    Console.WriteLine();
    Console.WriteLine("Floating point types:");
    Console.WriteLine($"float  : {float.MinValue} to {float.MaxValue} (with ~6-9 digits of precision)");
    Console.WriteLine($"double : {double.MinValue} to {double.MaxValue} (with ~15-17 digits of precision)");
    Console.WriteLine($"decimal: {decimal.MinValue} to {decimal.MaxValue} (with 28-29 digits of precision)");
}

void ConvertExample()
{
    string[] values = { "12.3", "45", "ABC", "11", "DEF" };
    string msg = "";
    double num = 0.0D;
    foreach (var val in values)
    {
        if (double.TryParse(val, out double numVal))
        {
            num += numVal;
        }
        else
        {
            msg += val;
        }
    }
    Console.WriteLine($"Msg: {msg} Total: {num}");
}

void ReverseWordsInSentence()
{
    string pangram = "The quick brown fox jumps over the lazy dog";
    string[] pangramArray = pangram.Split(" ");
    for (uint idx = 0; idx < pangramArray.Length; ++idx)
    {
        pangramArray[idx] = new string(pangramArray[idx].Reverse().ToArray());
    }
    pangram = string.Join(' ', pangramArray);
    Console.WriteLine(pangram);
}

void SortedOrdersExample()
{
    string orderStream = "B123,C234,A345,C15,B177,G3003,C235,B179";
    string[] sortedOrderStream = orderStream.Split(',');
    Array.Sort(sortedOrderStream);
    foreach (var item in sortedOrderStream)
    {
        if (item.Length == 4)
        {
            Console.WriteLine(item);
        }
        else
        {
            Console.WriteLine($"{item} - Error");
        }
    }
}

void MarketingLetterExample()
{
    string customerName = "Ms. Barros";

    string currentProduct = "Magic Yield";
    int currentShares = 2975000;
    decimal currentReturn = 0.1275m;
    decimal currentProfit = 55000000.0m;

    string newProduct = "Glorious Future";
    decimal newReturn = 0.13125m;
    decimal newProfit = 63000000.0m;

    string comparisonMessage =
$@"Dear {customerName},
As a customer of our {currentProduct} offering we are excited to tell you about a new financial product that would dramatically increase your return.

Currently, you own {currentShares:N2} shares at a return of {currentReturn:P2}.

Our new product, {newProduct} offers a return of {newReturn:P2}.  Given your current volume, your potential profit would be {newProfit:C2}.

Here's a quick comparison:

{currentProduct,-20}  {currentReturn:P2}  {currentProfit:C2}
{newProduct,-20}  {newReturn:P2}  {newProfit:C2}";

    Console.WriteLine(comparisonMessage);
}

void AllParenSubstrings()
{
    const string message = "(What if) there are (more than) one (set of parentheses)?";
    int seekIdx = 0;
    int parenStartIdx;
    int parentEndIdx;
    do
    {
        parenStartIdx = message.IndexOf('(', seekIdx);
        parentEndIdx = message.IndexOf(')', seekIdx);
        if (parenStartIdx != -1 && parentEndIdx != -1)
        {
            seekIdx = parentEndIdx + 1;
            var substringLength = parentEndIdx - 1 - parenStartIdx;
            Console.WriteLine(message.Substring(parenStartIdx + 1, substringLength));
        }
    } while (parenStartIdx != -1 && parentEndIdx != -1);
}

void MultipleSubstrCaptures()
{
    const string message = "(What if) I have [different symbols] but every {open symbol} needs a [matching closing symbol]?";
    char[] openSymbols = { '[', '{', '(' };
    char[] closeSymbols = { ']', '}', ')' };
    int seekIdx = 0;
    int parenStartIdx;
    int parentEndIdx;

    while (true)
    {
        parenStartIdx = message.IndexOfAny(openSymbols, seekIdx);
        parentEndIdx = message.IndexOfAny(closeSymbols, seekIdx);

        if (parenStartIdx == -1 || parentEndIdx == -1)
            break;

        bool matchedCapture = (message[parenStartIdx], message[parentEndIdx]) switch
        {
            ('(', ')') => true,
            ('{', '}') => true,
            ('[', ']') => true,
            _ => false,
        };

        if (!matchedCapture)
            break;

        seekIdx = parentEndIdx + 1;
        var substringLength = parentEndIdx - 1 - parenStartIdx;
        Console.WriteLine(message.Substring(parenStartIdx + 1, substringLength));
    };

}

void HTMLSubstrExample()
{
    const string input = "<div><h2>Widgets &trade;</h2><span>5000</span></div>";

    const string spanStartTag = "<span>";
    const string spanEndTag = "</span>";

    var spanStartIdx = input.IndexOf(spanStartTag);
    var spanEndIdx = input.IndexOf(spanEndTag);
    var quantityStartIdx = spanStartIdx + spanStartTag.Length;
    var quantityLen = spanEndIdx - quantityStartIdx;

    string quantity = input.Substring(quantityStartIdx, quantityLen);
    string output = input.Replace("<div>", "").Replace("</div>", "").Replace("&trade;", "&reg;");

    Console.WriteLine(quantity);
    Console.WriteLine(output);
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
    // MinMaxValues();
    // PeriodsSubstringExample();
    // ConvertExample();
    // ReverseWordsInSentence();
    // SortedOrdersExample();
    // MarketingLetterExample();
    AllParenSubstrings();
    MultipleSubstrCaptures();
    HTMLSubstrExample();
}

RunTest();
