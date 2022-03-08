using System;
using System.IO;
using System.Collections.Generic;

class MaxSum
{
    static void Main(string[] args)
    {
        long ans = 0;
        List<List<int>> numbers = new List<List<int>>();
        foreach (string line in File.ReadLines("input.txt")) numbers.Add(getNumbers(line));

        //initialise a lookup table filled with 0
        long[][] table = new long[numbers.Count][];
        for (int i = 0; i < numbers.Count; ++i) table[i] = new long[numbers[i].Count];

        //first entry is the top number
        table[0][0] = numbers[0][0];

        //propagate sum starting from top to last second row
        for (int i = 0; i < numbers.Count - 1; ++i) propagateSum(numbers, table, i);

        //answer is the maximum of numbers in last row
        foreach (long num in table[numbers.Count - 1]) ans = Math.Max(ans, num);

        //if ans is -1 or 0 -> No answer found.
        Console.WriteLine(ans);
    }

    //propagate sum down, left and right
    static void propagateSum(List<List<int>> numbers, long[][] table, int index)
    {
        for (int j = 0; j < numbers[index].Count; ++j)
        {
            //number is prime nothing will pass here.
            if (table[index][j] == -1) continue;

            if (isPrime(numbers[index + 1][j])) table[index + 1][j] = -1;
            else
            {
                long downSum = table[index][j] + numbers[index + 1][j];
                table[index + 1][j] = Math.Max(table[index + 1][j], downSum);
            }

            if (j != 0 && isPrime(numbers[index + 1][j - 1])) table[index + 1][j - 1] = -1;
            else if (j != 0)
            {
                long leftSum = table[index][j] + numbers[index + 1][j - 1];
                table[index + 1][j - 1] = Math.Max(table[index + 1][j - 1], leftSum);
            }

            if (j != numbers[index].Count - 1 && isPrime(numbers[index + 1][j + 1])) table[index + 1][j + 1] = -1;
            else
            {
                long rightSum = table[index][j] + numbers[index + 1][j + 1];
                table[index + 1][j + 1] = Math.Max(table[index + 1][j + 1], rightSum);
            }



        }
    }

    //parse a line into an array of numbers
    static List<int> getNumbers(string line)
    {
        List<int> list = new List<int>();
        foreach (string num in line.Split(' ')) list.Add(int.Parse(num));
        return list;
    }

    static bool isPrime(int num)
    {
        if (num == 2 || num == 1) return true;
        if (num % 2 == 0) return false;
        for (int i = 3; i < num / 2; i += 2) if (num % i == 0) return false;
        return true;
    }
}