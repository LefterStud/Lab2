namespace Lab2
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Task48();
            Task55();
            Task74();
            Task111();
            Task172();
        }

        /// <summary>
        /// Задана последовательность N вещественных чисел. Вычислить сумму чисел, порядковые номера которых являются:
        /// а) простыми числами;
        /// б) числами Фибоначчи.
        /// </summary>
        /// <remarks>
        /// Послідовність чисел sequence генерується випадковим чином в заданому діапазоні від MIN_NUMBER до MAX_NUMBER,
        /// довжину послідовності зазначає LENGTH_OF_SEQUENCE.
        /// </remarks>
        static void Task48()
        {
            Console.WriteLine(
                "Task 48: Задана последовательность N вещественных чисел. Вычислить сумму чисел, порядковые номера которых являются:" +
                "\nа) простыми числами;" +
                "\nб) числами Фибоначчи.\n");
            double sumOfPrime = 0;
            double sumOfFibonacci = 0;
            const int LENGTH_OF_SEQUENCE = 15;
            const int MIN_NUMBER = -20;
            const int MAX_NUMBER = 100;
            double[] sequence = ArrayGenerator(LENGTH_OF_SEQUENCE, MIN_NUMBER, MAX_NUMBER);
            PrintArray(sequence, "Масив чисел:");
            for (int i = 0; i < sequence.Length; i++)
            {
                if (IsPrime(i))
                {
                    sumOfPrime += sequence[i];
                }
            }
            for (int i = 0; i < sequence.Length; i++)
            {
                if (IsFibonacci(i))
                {
                    sumOfFibonacci += sequence[i];
                }
            }

            Console.WriteLine($"A) Sum =  {sumOfPrime}");
            Console.WriteLine($"B) Sum = {sumOfFibonacci}\n\n");
        }

        /// <summary>
        /// Сформировать массив простых множителей заданного числа.
        /// </summary>
        /// <remarks>
        /// Число number генерується випадковим чином в заданому діапазоні від MIN до MAX,
        /// </remarks>
        static void Task55()
        {
            Console.WriteLine("Taks 55: Сформировать массив простых множителей заданного числа.");
            const int MIN = 0;
            const int MAX = 1000;
            Random r = new Random();
            int number = r.Next(MIN, MAX + 1);
            double[] primeFactors = new double[0];
            int counter = 0;
            int divisor = 2;
            int tempNumber = number;
            Console.WriteLine($"Specified number is: {number}");
            while (tempNumber != 1)
            {
                if (tempNumber % divisor == 0)
                {
                    counter++;
                    Array.Resize(ref primeFactors, counter);
                    primeFactors[counter - 1] = divisor;
                    tempNumber /= divisor;
                }
                else
                {
                    divisor++;
                }
            }
            Console.WriteLine($"Prime factors of specified number {number} is: ");
            PrintArray(primeFactors, "Масив чисел:");
            Console.WriteLine("");
        }

        /// <summary>
        /// Дана последовательность вещественных чисел а1, a2, ..., а15. Определить, 
        /// есть ли в последовательности отрицательные числа. 
        /// В случае положительного ответа определить порядковый номер первого из них.
        /// </summary>
        /// <remarks>
        /// Послідовність чисел sequence генерується випадковим чином в заданому діапазоні від MIN_NUMBER до MAX_NUMBER,
        /// довжину послідовності зазначає LENGTH_OF_SEQUENCE.
        /// </remarks>
        static void Task74()
        {
            Console.WriteLine("Task 74: Дана последовательность вещественных чисел а1, a2, ..., а15." +
                "\nОпределить, есть ли в последовательности отрицательные числа." +
                "\nВ случае положительного ответа определить порядковый номер первого из них.\n");
            const int LENGTH_OF_SEQUENCE = 15;
            const int MIN_NUMBER = -20;
            const int MAX_NUMBER = 100;
            bool foundNegative = false;
            int indexOfFirstNegative = -1;
            double[] sequence = ArrayGenerator(LENGTH_OF_SEQUENCE, MIN_NUMBER, MAX_NUMBER); ;
            PrintArray(sequence, "Масив чисел:");
            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] < 0)
                {
                    foundNegative = true;
                    indexOfFirstNegative = i;
                    break;
                }
            }
            if (foundNegative)
            {
                Console.WriteLine($"The sequence number of a first negative number is {indexOfFirstNegative + 1}.\n\n");
            }
            else
            {
                Console.WriteLine("Negative numbers are not available.\n\n");
            }
        }

        /// <summary>
        /// На k-e место одномерного массива вещественных чисел вставить элемент,
        /// равный среднему арифметическому элементов массива.
        /// </summary>
        /// <remarks>
        /// Масив чисел realNumbers генерується випадковим чином в заданому діапазоні від MIN_NUMBER до MAX_NUMBER,
        /// довжину масива зазначає LENGTH_OF_SEQUENCE.
        /// </remarks>
        static void Task111()
        {
            Console.WriteLine("Task 111: На k-e место одномерного массива вещественных чисел вставить элемент," +
                "\nравный среднему арифметическому элементов массива.\n");
            const int LENGTH_OF_ARRAY = 15;
            const int MIN_NUMBER = -20;
            const int MAX_NUMBER = 100;
            int kPosition = 8;
            double[] realNumbers = ArrayGenerator(LENGTH_OF_ARRAY, MIN_NUMBER, MAX_NUMBER); ;
            double sum = 0;
            double average = 0;
            PrintArray(realNumbers, "Масив чисел:");
            for (int i = 0; i < realNumbers.Length; i++)
            {
                sum += realNumbers[i];
            }
            average = sum / LENGTH_OF_ARRAY;
            Console.WriteLine($"Average of array elements is - {average} .\nPosition for insert is - {kPosition + 1}.\n");
            if (kPosition > 0 && kPosition <= LENGTH_OF_ARRAY)
            {
                double[] supplementedRealNumbers = new double[LENGTH_OF_ARRAY + 1];
                for (int i = 0; i < kPosition; i++)
                {
                    supplementedRealNumbers[i] = realNumbers[i];
                }
                supplementedRealNumbers[kPosition] = average;
                for (int i = kPosition + 1; i < supplementedRealNumbers.Length; i++)
                {
                    supplementedRealNumbers[i] = realNumbers[i - 1];
                }
                PrintArray(supplementedRealNumbers , "Оновлений масив чисел:");
            }
            else
            {
                Console.WriteLine("Incorrect index.\n\n");
            }
        }

        /// <summary>
        /// Написать алгоритм смены мест в заданном массиве 1-го элемента с последним,
        /// 2-го с предпоследним и так далее.
        /// </summary>
        /// <remarks>
        /// Масив чисел numbersArray генерується випадковим чином в заданому діапазоні від MIN_NUMBER до MAX_NUMBER,
        /// довжину масива зазначає LENGTH_OF_SEQUENCE.
        /// </remarks>
        static void Task172()
        {
            Console.WriteLine("\nTask 172: Написать алгоритм смены мест в заданном массиве 1-го элемента с последним," +
                "\n2-го с предпоследним и так далее.\n");
            const int LENGTH_OF_ARRAY = 15;
            const int MIN_NUMBER = -20;
            const int MAX_NUMBER = 100;
            double[] numbersArray = ArrayGenerator(LENGTH_OF_ARRAY, MIN_NUMBER, MAX_NUMBER); ;
            PrintArray(numbersArray, "Масив чисел:");
            for (int i = 0; i < LENGTH_OF_ARRAY / 2; i++)
            {
                double tempArr = numbersArray[i];
                numbersArray[i] = numbersArray[LENGTH_OF_ARRAY - 1 - i];
                numbersArray[LENGTH_OF_ARRAY - 1 - i] = tempArr;
            }
            PrintArray(numbersArray , "Оновлений масив чисел:");
        }

        /// <summary>
        /// Функція для перевірки, чи задане число є простим.
        /// </summary>
        /// <param name="number">Число, яке перевіряється</param>
        /// <returns>Значення true, якщо число є простим; в іншому випадку - false</returns>
        static bool IsPrime(int number)
        {
            if (number <= 1)
            {
                return false;
            }

            if (number <= 3)
            {
                return true;
            }

            if (number % 2 == 0 || number % 3 == 0)
            {
                return false;
            }

            for (int i = 5; i * i <= number; i += 6)
            {
                if (number % i == 0 || number % (i + 2) == 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Функція для перевірки, чи задане число є числом Фібоначчі.
        /// </summary>
        /// <param name="number">Число, яке перевіряється</param>
        /// <returns>Значення true, якщо число є числом Фібоначчі; в іншому випадку - false</returns>
        static bool IsFibonacci(int number)
        {
            if (number < 0)
                return false;

            if (number == 0 || number == 1)
                return true;

            int a = 0;
            int b = 1;
            while (b < number)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }

            return b == number;
        }

        static double[] ArrayGenerator(int length, int min, int max)
        {
            Random r = new Random();
            double[] resultArray = new double[length];

            for (int i = 0; i < length; i++)
            {
                resultArray[i] = r.NextDouble() * (max - min) + min;
            }

            return resultArray;
        }

        /// <summary>
        /// Функція для виведення на друк вмісту масиву.
        /// </summary>
        /// <param name="array">Масив, який буде виведено на друк</param>
        static void PrintArray(double[] array, string title)
        {
            Console.WriteLine($"{title}");
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {array[i]}");
            }
            Console.WriteLine("");
        }
    }
}



