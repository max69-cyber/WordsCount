using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "Это пример текста. Текст должен быть проанализирован. Это важно.";
            Dictionary<string, int> wordCounts = WordFrequency(text);
             
            foreach (var item in wordCounts)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
            Console.ReadKey(); // чтобы консоль не закрывалась сразу после выполнения программы и результат был виден
        }

        static Dictionary<string, int> WordFrequency(string text)
        {
            //Dictionary<string, int> result = new Dictionary<string, int>(); // создание Dictionary для способа решения без LINQ

            string[] words = text
                .Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries) // добавим запятые и точки, чтобы они не считались частями слов, также с помощьюRemove EmptyEntries избавимся от пустых элементов
                .Select(w => w.ToLower())                                                   // каждый элемент приводим в форму, где слово начинается с маленькой буквы
                .ToArray();                                                                 // преобразуем в массив
                                                                                            // результат - массив всех слов из текста с маленькой буквы.

            // подсчет слов c использованием методов LINQ
            Dictionary<string, int> result = words                  // чтобы посчитать количество каждого слова используем методы:
                .GroupBy(word => word)                              //GroupBy - создаст группы по словам - одинаковые слова окажутся в одной группе
                .ToDictionary(group => group.Key, group => group    // преобразование в Dictionary, ключом становится ключ из каждой группы слов
                .Count());                                          //метод Count считает количество слов, которые оказались в каждой группе, это значение записывается в Value в Dictionary

            // подсчет количества слов без LINQ
            //foreach (string word in words)
            //{
            //    if (result.ContainsKey(word))
            //    {
            //        result[word]++; //сокращение записи result[word] = result[word] + 1;
            //    }
            //    else
            //    {
            //        result.Add(word, 1);
            //    }
            //}

            return result;
        }

    }
}
