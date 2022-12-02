using MoreLinq;
using System.Collections.Generic;
using System;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;

string selection = string.Empty;
while (selection != "e")
{
    printMenu();

    switch (selection)
    {
        case "1a":
            day1a();
            break;
        case "1b":
            day1b();
            break;
        case "2a":
            day2a();
            break;
        case "2b":
            day2b();
            break;
        case "3a":
            day3a();
            break;
        case "3b":
            day3b();
            break;
        case "4a":
            day4a();
            break;
        case "4b":
            day4b();
            break;
        case "5a":
            day5a();
            break;
        case "5b":
            day5b();
            break;
        case "6a":
            day6a();
            break;
        case "6b":
            day6b();
            break;
        case "7a":
            day7a();
            break;
        case "7b":
            day7b();
            break;
        case "8a":
            day8a();
            break;
        case "8b":
            day8b();
            break;
        case "9a":
            day9a();
            break;
        case "9b":
            day9b();
            break;
        case "10a":
            day10a();
            break;
        case "10b":
            day10b();
            break;
        case "11a":
            day11a();
            break;
        case "11b":
            day11b();
            break;
        case "12a":
            day12a();
            break;
        case "12b":
            day12b();
            break;
        case "13a":
            day13a();
            break;
        case "13b":
            day13b();
            break;
        case "14a":
            day14a();
            break;
        case "14b":
            day14b();
            break;
        case "15a":
            day15a();
            break;
        case "15b":
            day15b();
            break;
        case "16a":
            day16a();
            break;
        case "16b":
            day16b();
            break;
        case "17a":
            day17a();
            break;
        case "17b":
            day17b();
            break;
        case "18a":
            day18a();
            break;
        case "18b":
            day18b();
            break;
        case "19a":
            day19a();
            break;
        case "19b":
            day19b();
            break;
        case "20a":
            day20a();
            break;
        case "20b":
            day20b();
            break;
        case "21a":
            day21a();
            break;
        case "21b":
            day21b();
            break;
        case "22a":
            day22a();
            break;
        case "22b":
            day22b();
            break;
        case "23a":
            day23a();
            break;
        case "23b":
            day23b();
            break;
        case "24a":
            day24a();
            break;
        case "24b":
            day24b();
            break;
        case "25a":
            day25a();
            break;
        case "25b":
            day25b();
            break;
    }
    Console.WriteLine("'e' to exit");
    selection = Console.ReadLine();
}

#region utility
void printMenu()
{
    Console.Clear();
    Console.WriteLine("Enter a day number and A or B");
}

void print(string message)
{
    Console.WriteLine(message);
}

string getData(string day)
{
    return File.ReadAllText("data\\day" + day + ".txt");
}

List<string> dataToList(string data, string splitOn)
{
    return data.Split(splitOn).ToList();
}

List<int> dataToIntList(string data, string splitOn)
{
    return data.Split(splitOn).Select(int.Parse).ToList();
}

List<double> dataToDoubleList(string data, string splitOn)
{
    return data.Split(splitOn).Select(double.Parse).ToList();
}
#endregion

#region day 1
void day1a() //68787
{
    List<string> calories = dataToList(getData("1"), Environment.NewLine);
    int currentTotal = 0;
    int maxTotal = 0;
    foreach (string s in calories)
    {
        if (s != "")
        {
            int x = int.Parse(s);
            currentTotal += x;
        }
        else
        {
            if (currentTotal > maxTotal)
                maxTotal = currentTotal;
            currentTotal = 0;
        }
    }

    print(maxTotal.ToString());

}

void day1b() //198041
{
    List<string> calories = dataToList(getData("1"), Environment.NewLine);
    List<int> totals = new List<int>();
    int currentTotal = 0;
    int maxTotal = 0;
    foreach (string s in calories)
    {
        if (s != "")
        {
            int x = int.Parse(s);
            currentTotal += x;
        }
        else
        {
            totals.Add(currentTotal);
            if (currentTotal > maxTotal)
                maxTotal = currentTotal;
            currentTotal = 0;
        }
    }
    totals.Sort();
    totals.Reverse();

    print((totals[0] + totals[1] + totals[2]).ToString());
}
#endregion

#region day 2
void day2a() //12772
{
    List<string> rounds = dataToList(getData("2"), Environment.NewLine);
    int score = 0;
    //A X = ROCK
    //B Y = PAPER
    //C Z = SCISSORS
    foreach(string r in rounds)
    {
        List<string> x = r.Split(" ").ToList();
        score += x[1] == "X" ? 1 : x[1] == "Y" ? 2 : 3;
        if (x[0] == "A")
        {
            score += x[1] == "X" ? 3 : x[1] == "Y" ? 6 : 0;
        }
        else if (x[0] == "B")
        {
            score += x[1] == "X" ? 0 : x[1] == "Y" ? 3 : 6;
        }
        else
        {
            score += x[1] == "X" ? 6 : x[1] == "Y" ? 0 : 3;
        }
    }

    print(score.ToString());
}

void day2b() //11618
{
    List<string> rounds = dataToList(getData("2"), Environment.NewLine);
    int score = 0;
    //A = ROCK
    //B = PAPER
    //C = SCISSORS
    //X = WIN
    //Y = TIE
    //Z = LOSE
    foreach (string r in rounds)
    {
        List<string> x = r.Split(" ").ToList();

        if (x[0] == "A")
        {
            x[1] = x[1] == "X" ? "Z" : x[1] == "Y" ? "X" : "Y";
        }
        else if (x[0] == "B")
        {
            x[1] = x[1] == "X" ? "X" : x[1] == "Y" ? "Y" : "Z";
        }
        else
        {
            x[1] = x[1] == "X" ? "Y" : x[1] == "Y" ? "Z" : "X";
        }

        score += x[1] == "X" ? 1 : x[1] == "Y" ? 2 : 3;

        if (x[0] == "A")
        {
            score += x[1] == "X" ? 3 : x[1] == "Y" ? 6 : 0;
        }
        else if (x[0] == "B")
        {
            score += x[1] == "X" ? 0 : x[1] == "Y" ? 3 : 6;
        }
        else
        {
            score += x[1] == "X" ? 6 : x[1] == "Y" ? 0 : 3;
        }
    }

    print(score.ToString());
}
#endregion

#region day 3
void day3a() //
{
    
}

void day3b() //
{
    

}
#endregion

#region day 4
void day4a() //
{
    
}

void day4b() //
{
    
}
#endregion

#region day 5
void day5a() //
{
    
}

void day5b() //
{
    
}
#endregion

#region day 6
void day6a() //
{
    
}

void day6b() //
{
    
}
#endregion

#region day 7
void day7a() //
{
    
}

void day7b() //
{
    
}
#endregion

#region day 8
void day8a() //
{
    
}

void day8b() //
{
    
}
#endregion

#region day[9]
void day9a() //
{
    
}

void day9b() //
{
    
}
#endregion

#region day 10
void day10a() //
{
    
}

void day10b() //
{
    
}
#endregion

#region day 11
void day11a() //
{

}

void day11b() //
{
    
}
#endregion

#region day 12
void day12a() // 
{
    
}

void day12b() // 
{

}
#endregion

#region day 13
void day13a() //
{
    
}

void day13b() //
{

}
#endregion

#region day 14
void day14a() //
{
    
}

void day14b() //
{
    
}
#endregion

#region day15
void day15a() //
{
    
}

void day15b() //
{
    
}
#endregion

#region day16
void day16a() // 
{

}

void day16b() // 
{

}
#endregion

#region day17
void day17a() // 
{

}

void day17b() // 
{

}
#endregion

#region day18
void day18a() // 
{

}

void day18b() // 
{

}
#endregion

#region day19
void day19a() // 
{

}

void day19b() // 
{

}
#endregion

#region day20
void day20a() // 
{

}

void day20b() // 
{

}
#endregion

#region day21
void day21a() // 
{
    
}

void day21b() // 
{
    
}
#endregion

#region day22
void day22a() // 
{

}

void day22b() // 
{

}
#endregion

#region day23
void day23a() // 
{

}

void day23b() // 
{

}
#endregion

#region day24
void day24a() // 
{

}

void day24b() // 
{

}
#endregion

#region day25
void day25a() // 
{

}

void day25b() // 
{

}
#endregion

record struct Point(int X, int Y);