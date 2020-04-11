namespace kiralyno
{
  using System;
  using System.Collections.Generic;

  public static class ListExtension
  {
    public static List<int> InitializeRandomList(this List<int> list, int size)
    {
      Random rand = new Random();
      List<int> numbers = new List<int>();
      HashSet<int> set = new HashSet<int>();

      while (numbers.Count < size)
      {
        int num;
        do
        {
          num = rand.Next(0, size);
        } while (set.Contains(num));
        set.Add(num);
        numbers.Add(num);
      }

      return numbers;
    }

    public static void Swap(this List<int> list, int i, int j)
    {
      List<int> temp = CopyList(list);

      int v = temp[i];
      list[i] = list[j];
      list[j] = v;
    }

    public static List<int> CopyList(this List<int> list)
    {
      List<int> temp = new List<int>();

      for (int i = 0; i < list.Count; ++i)
      {
        temp.Add(list[i]);
      }

      return temp;
    }

    public static void Print(this List<int> list)
    {
      for (int i = 0; i < list.Count; ++i)
      {
        Console.Write($"{list[i]} ");
      }

      Console.WriteLine();
      Console.WriteLine();
    }

    public static void PrintBoard(this List<int> list)
    {
      int n = list.Count;
      for (int i = 0; i < n; ++i)
      {
        for (int j = 0; j < n; ++j)
        {
          if (list[i] != j)
          {
            Console.Write(" * ");
            continue;
          }

          Console.Write($" {list[i]} ");
        }

        Console.WriteLine();
      }

      Console.WriteLine();
    }
  }
}