using System;
using System.CodeDom;
using System.Web.DynamicData;

namespace prjAspNetMvcDemo.Controllers
{
    internal class CLotto
    {
        public CLotto()
        {
        }

        internal string getNumbers()
        {
            Random rand = new Random();
            int[] numbers = new int[6];
            int count = 0;//記錄放到第幾個數字

            while(count < 6){
                int temp = rand.Next(1, 50);
                if (!is亂數是否重複(temp, numbers))
                {
                    numbers[count] = temp;
                    count++;
                }

            }

            //從小排到大
            for(int i=0; i <numbers.Length; i++)
            {
                for(int j=0; j < numbers.Length - 1; j++)
                {
                    if (numbers[j + 1] < numbers[j])
                    {
                        int big = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = big;
                    }
                }
            }

            string s = "";
            foreach (int number in numbers)
                s += number.ToString() + " ";
            return s;
        }

        private bool is亂數是否重複(int temp, int[] numbers)
        {
            //若亂數有重複則回傳true，沒重複就回傳false
            foreach(int i in numbers)
            {
                if (i == temp)
                    return true;
            }
            return false;
        }

        //---我的做法:亂數--
        //string result;
        //public string getRandoms()
        //{
        //    int[] randArray = new int[6];
        //    Random a = new Random();
        //    for (int i = 0; i < 6; i++)
        //    {
        //        randArray[i] = a.Next(1, 49);

        //        //不重複者加入陣列
        //        for (int j = 0; j < i; j++)
        //        {
        //            while (randArray[j] == randArray[i])
        //            {
        //                j = 0;
        //                randArray[i] = a.Next(1, 49);
        //            }
        //        }

        //        //未完成的排大小
        //        //    while (randArray[j] > randArray[i])
        //        //    {
        //        //        if (j < randArray.Length)
        //        //            j = i + 1;
        //        //    }
        //        result += Convert.ToString(randArray[i]) + "  ";
        //    }

        //    //for (int i = 0; i < 6; i++)
        //    //{
        //    //    randArray[i] = a.Next(1, 49);

        //    //    result += Convert.ToString(randArray[i]) + "  ";
        //    //    //}


        //    //}
        //    return result;
        //}
    }
}