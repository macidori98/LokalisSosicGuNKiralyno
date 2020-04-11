namespace kiralyno
{
  using System;
  using System.Collections.Generic;

  public class NonStatic
  {
    private int numberOfSwaps, colNo;
    private List<int> q = new List<int>();
    private List<int> q2 = new List<int>();
    private int n;
    private bool isAttacked = false;

    public void SusicGu(int n)
    {
      this.n = n;

      do
      {
        q = q.InitializeRandomList(this.n);
        Console.WriteLine("Init:");
        this.q.Print();
        this.q.PrintBoard();
        this.colNo = this.CollisionCalc(this.q);
        do
        {
          this.numberOfSwaps = 0;

          for (int i = 0; i < this.n; ++i)
          {
            for (int j = i + 1; j < this.n; ++j)
            {
              int a;
              bool A = this.IsAttack(out a, i, this.q);
              bool B = this.IsAttack(out a, j, this.q);
              if (A || B)
              {
                this.q2 = new List<int>();

                for (int k = 0; k < this.n; ++k)
                {
                  this.q2.Add(this.q[k]);
                }

                this.q2.Swap(i, j);
                int colNo2 = this.CollisionCalc(this.q2);
                if (this.colNo > colNo2)
                {
                  for (int k = 0; k < this.q.Count; ++k)
                  {
                    this.q[k] = this.q2[k];
                  }

                  this.numberOfSwaps = this.numberOfSwaps + 1;
                  this.colNo = colNo2;
                }
              }
            }
          }
        } while (this.numberOfSwaps != 0);
      } while (this.colNo != 0);

      Console.WriteLine("Found: ");
      this.q.Print();
      this.q.PrintBoard();
    }

    private bool IsAttack(out int aScore, int pos, List<int> table)
    {
      int d;//distance
      aScore = 0;
      bool a = false;

      for (int i = 0; i < this.q.Count; ++i)
      {
        if (i != pos)
        {
          d = Math.Abs(pos - i);

          if ((table[i] == table[pos] + d) || (table[i] == table[pos] - d))
          {
            a = true;
            aScore = aScore + 1;
          }
        }
      }

      return a;
    }

    private int CollisionCalc(List<int> table)
    {
      int fAttack = 0;

      List<int> temp = table.CopyList();

      for (int i = 0; i < this.n; ++i)
      {
        int a;
        this.isAttacked = this.IsAttack(out a, i, temp);
        if (this.isAttacked)
        {
          fAttack = fAttack + a;
        }
      }

      return fAttack;
    }
  }

  internal class Program
  {
    private static void Main(string[] args)
    {
      NonStatic nonStatic = new NonStatic();
      nonStatic.SusicGu(5);
      Console.ReadKey();
    }
  }
}