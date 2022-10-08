using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Magisches_Quadrat
{
    public class Magic_Square
    {

        public static readonly int Arraymaxsize = 100;
        public List<List<int>> Square_Val { get; set; } = new List<List<int>>();


        public void Create()
        {
            Square_Val.Add(new List<int> { 15, 10, 3, 6 });
            Square_Val.Add(new List<int> { 4, 5, 16, 9 });
            Square_Val.Add(new List<int> { 14, 11, 2, 7 });
            Square_Val.Add(new List<int> { 1, 8, 13, 12 });
            int localsum = Square_Val[0].Where(x => x > 0).Sum(); // just get any row to calculate sum
            Checkverticalsum(Square_Val, localsum);
            Checkdiagonalsum(Square_Val, localsum);
        }

        public void Create(int n)
        {
            Random rnd = new();
            int sum = rnd.Next(0, 100);
            List<List<int>> square = new();
            while (true)
            {

                int checkSquare1 = Square_Val[1].Where(x => x > 0).Sum(); // just get any row to calculate sum
                int checkSquare2 = Square_Val[2].Where(x => x > 0).Sum(); // just get any row to calculate sum
                int checkSquare3 = Square_Val[3].Where(x => x > 0).Sum(); // just get any row to calculate sum

                if (checkSquare1.Equals(checkSquare2))
                {
                    if (checkSquare1.Equals(checkSquare3))
                    {

                    }
                   
                }

                for (int i = 0; i < n; i++) // for each n once
                {


                    List<int> vals = new();
                    for (int l = 0; l < n; l++) // for each row the value gets written.
                    {
                        int localsum = vals.Where(x => x > 0).Sum();
                        int horizontalsum = 0;
                        if (l != n - 1)
                        {
                            foreach (var row in square)
                            {
                                horizontalsum += row[l];
                            }
                            if (horizontalsum < localsum) // making it harder to overshoot horizontal
                            {
                                if (horizontalsum < 0)
                                {
                                    vals.Add(rnd.Next(0, sum - horizontalsum)); // fill the last box till the wished sum is reached.
                                }
                                vals.Add(0);

                            }
                            else
                            {
                                vals.Add(rnd.Next(0, sum - localsum)); ; 
                            }
                        }
                        else
                        {
                            vals.Add(sum - localsum); 
                            square.Add(vals);

                        }
                    }

                }
                if (!Checkverticalsum(square, sum))
                {
                    square.Clear();
                    continue;

                }
                if (!Checkdiagonalsum(square, sum))
                {
                    square.Clear();
                    continue;
                }
                break;
            }
            Square_Val = square;

        }

        private bool Checkdiagonalsum(List<List<int>> square, int sum)
        {
            for (int i = 0; i < square.Count; i++)
            {
                int localsum = 0;
                foreach (var row in square)
                {
                    localsum += row[i];
                }

                if (localsum != sum)
                {
                    return false;
                }
            }
            return true;
        }

        private bool Checkverticalsum(List<List<int>> square, int sum)
        {
            for (int i = 0; i < square.Count; i++)
            {
                int localsum = 0;
                foreach (var row in square)
                {
                    localsum += row[1];
                }

                if (localsum != sum)
                {
                    return false;
                }
            }
            return true;
        }

        //private bool Checkvaluesum(List<int> list,int rndsum)
        //{
        //    int localsum =0;
        //    foreach (var value in list)
        //    {
        //        localsum += value;
        //    }
        //    if (localsum == rndsum)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

    }
}
