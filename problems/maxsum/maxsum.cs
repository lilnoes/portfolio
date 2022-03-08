/*
Author: Leon Emmanuel ISHIMWE
*/
using System;
using System.Collections.Generic;

public class MaxSum
{
    public static void Main(string[] args)
    {
        string lines = @"215
193 124
117 237 442
218 935 347 235
320 804 522 417 345
229 601 723 835 133 124
248 202 277 433 207 263 257
359 464 504 528 516 716 871 182
461 441 426 656 863 560 380 171 923
381 348 573 533 447 632 387 176 975 449
223 711 445 645 245 543 931 532 937 541 444
330 131 333 928 377 733 017 778 839 168 197 197
131 171 522 137 217 224 291 413 528 520 227 229 928
223 626 034 683 839 053 627 310 713 999 629 817 410 121
924 622 911 233 325 139 721 218 253 223 107 233 230 124 233";
        long ans = 0;
        List<List<int>> numbers = new List<List<int>>();
        foreach (string line in lines.Split('\n')) numbers.Add(getNumbers(line));

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