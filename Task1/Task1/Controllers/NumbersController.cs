using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace Task1.Controllers
{
    public class numbersController : ApiController
    {

        /*
            Функционал сложения каждого второго нечетного числа из массива чисел тела запроса и возврат их суммы по модулю.
         
            // GET: api/numbers/getItems?value=1&value=2&value=3
        */
        [HttpGet]
        public string getItems([ModelBinder] int[] value)
        {
            bool isSecond = false;
            int result = 0;

            foreach (var number in value)
            {
                if (number % 2 != 0)
                    if (isSecond)
                    {
                        result += number;
                        isSecond = false;
                    }
                    else
                        isSecond = true;

            }
            return Math.Abs(result).ToString();
        }

        /*
            Функционал сложения двух непустых связанных списков, представляющих два неотрицательных целых и больших нуля числа. 
            Цифры хранятся в обратном порядке, и каждый из их узлов содержит одну цифру. 
            Сложить два числа и вернуть их в виде связанного списка.

            // GET: api/numbers/sumList
         */
        [HttpGet]
        public LinkedList<int> sumList([ModelBinder] LinkedList<int>[] values)
        {

            /*
            //Код для проверки работы функцтонала
            //123 + 532 = 655
             
            LinkedList<int>[] values = new LinkedList<int>[2];
            values[0] = new LinkedList<int>();
            values[0].AddLast(3);
            values[0].AddLast(2);
            values[0].AddLast(1);

            values[1] = new LinkedList<int>();
            values[1].AddLast(2);
            values[1].AddLast(3);
            values[1].AddLast(5);
            */
            LinkedList<int> resultList = new LinkedList<int>();
            int result = 0;
            for (int i = 0; i < 2; i++)
            {
                int number = 0;
                int koef = 1; // коэф. десятков (1,10,100...)
                var temp = values[i].First;
                while (temp != null)
                {
                    number += temp.Value * koef;
                    temp = temp.Next;
                    koef *= 10;
                }
                result += number;

            }
            // преобразование реузльтата в список
            foreach (char number in result.ToString())
            {
                resultList.AddLast(number - '0');
            }
            return resultList;
        }


        /*
            Функционал проверки является ли строка палиндромом .

            // GET: api/numbers/isPalindrom?value=Идем, молод, долом меди
         */
        [HttpGet]
        public bool isPalindrom(string value)
        {
            String clean = Regex.Replace(value, @"\W+", "").ToLower();
            String reverse = new string(clean.ToCharArray().Reverse().ToArray());
            return (reverse.Equals(clean));

        }

    }
}
