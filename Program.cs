Dictionary<string, decimal[]> studentGradesMap = new()
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

var getGrade = (decimal grade) =>
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
};

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

    var examPoints = (decimal)studentGrades[..N_ASSIGNMENTS].Sum() / N_ASSIGNMENTS;
    var overallPoints = (decimal)studentGrades.Aggregate(aggregator) / N_ASSIGNMENTS;
    var examScore = getGrade(overallPoints);

    var extraGrades = studentGrades[N_ASSIGNMENTS..];
    var extraCredit = extraGrades.Sum() / extraGrades.Length;
    var extraPoints = overallPoints - examPoints;

    Console.WriteLine($"{studentName}:\t\t{examPoints}\t\t{overallPoints}\t{examScore}\t{extraCredit} ({extraPoints} pts)");
}

Console.Write("Press the Enter key to continue");
Console.ReadLine();
