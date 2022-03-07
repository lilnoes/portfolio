  long[][] table = new long[numbers.Count][];
        for (int i = 0; i < numbers.Count; ++i) table[i] = new long[numbers[i].Count];
        for (int i = 0; i < numbers.Count - 1; ++i) propagateSum(numbers, table, i);
        foreach (long num in table[numbers.Count - 1]) ans = Math.Max(ans, num);
        Console.WriteLine(ans);