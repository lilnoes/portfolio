   long downSum = dfs(numbers, 1, 0, numbers[0][0]);
        long rightSum = dfs(numbers, 1, 1, numbers[0][0]);
        ans = Math.Max(downSum, rightSum);
        Console.Write(ans);