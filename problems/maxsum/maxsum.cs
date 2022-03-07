using System;
using System.IO;
using System.Collections.Generic;

class MaxSum
{
    static Dictionary<ValueTuple<int, int>, long> lookup = new Dictionary<ValueTuple<int, int>, long>();
    static long count = 0;
    static void Main(string[] args)
    {
        long ans = 0;
        List<List<int>> numbers = new List<List<int>>();
        foreach (string line in File.ReadLines("input.txt")) numbers.Add(getNumbers(line));

        long[][] table = new long[numbers.Count][];
        for (int i = 0; i < numbers.Count; ++i) table[i] = new long[numbers[i].Count];
        table[0][0] = numbers[0][0];
        for (int i = 0; i < numbers.Count - 1; ++i) propagateSum(numbers, table, i);
        foreach (long num in table[numbers.Count - 1]) ans = Math.Max(ans, num);
        Console.WriteLine(ans);



        // long downSum = dfs(numbers, 1, 0, numbers[0][0]);
        // long rightSum = dfs(numbers, 1, 1, numbers[0][0]);
        // ans = Math.Max(downSum, rightSum);
        // Console.Write(ans);
    }

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

    static List<int> getNumbers(string line)
    {
        List<int> list = new List<int>();
        foreach (string num in line.Split(' ')) list.Add(int.Parse(num));
        return list;
    }

    static long dfs(List<List<int>> numbers, int i, int j, int sum)
    {
        Console.WriteLine(count++);
        // if (lookup.ContainsKey((i, j))) return lookup[(i, j)];
        if (i >= numbers.Count || j < 0 || j >= numbers[i].Count) return -1;
        if (!isNotPrime(numbers[i][j])) return -1;
        if (i == numbers.Count - 1) return sum + numbers[i][j];
        long leftSum = dfs(numbers, i + 1, j - 1, sum + numbers[i][j]);
        long downSum = dfs(numbers, i + 1, j, sum + numbers[i][j]);
        long rightSum = dfs(numbers, i + 1, j + 1, sum + numbers[i][j]);
        long max = Math.Max(Math.Max(leftSum, downSum), rightSum);
        lookup[(i, j)] = max;
        return max;
    }

    //added this to avoid double negation which is confusing
    static bool isPrime(int num)
    {
        return !isNotPrime(num);
    }

    static bool isNotPrime(int num)
    {
        if (num == 2 || num == 1) return false;
        if (num % 2 == 0) return true;
        for (int i = 3; i < num / 2; i += 2) if (num % i == 0) return true;
        return false;
    }
}