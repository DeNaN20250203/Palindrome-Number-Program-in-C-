using System.Collections;

namespace ConsoleStringPalindromeCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            	// 1 вариант Пример с видео
            	{
			int num, temp, revNum = 0, rem;
			Console.WriteLine("Enter a number: ");
			num = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine();
			temp = num;
			while (num > 0)
			{
				rem = num % 10;
				revNum = revNum * 10 + rem;
				num = num / 10;
			}

			if (revNum == temp)
				Console.WriteLine("Number is Palindrome.");
			else
				Console.WriteLine("Number is not Palindrome.");
		}

		// 2 вариант
		/*
		 	* Для данного вариант введем два метода IsPalindrome(string) и IsPalindrome(T)
		 	* Оба имеют одну основу, просто один вариант сделан чисто для строк, 
		 	* а вот второй вариант уже Generic
		 	* При этом можно из данных методов сделать расширение
		 */
		 {
			var str1 = "тест";
			var str2 = "шалаш";
			Console.WriteLine(String.Join("", str1.ToCharArray().Reverse())); // тсет
			Console.WriteLine(String.Join("", str2.ToCharArray().Reverse())); // шалаш

			Console.WriteLine(IsPalindrome(str1)); // False
			Console.WriteLine(IsPalindrome(str2)); // True
			Console.WriteLine(IsPalindrome(123.ToString())); // False
			Console.WriteLine(IsPalindrome(121.ToString())); // True

			Console.WriteLine(IsPalindrome("шалаш")); // True
			Console.WriteLine(IsPalindrome("привет")); // False

			Console.WriteLine((new int[] { 1, 2, 3, 2, 1 }).IsPalindrome()); // True
			Console.WriteLine((new int[] { 1, 2, 3, 4, 5 }).IsPalindrome()); // False

			Console.WriteLine((new List<char> { 'а', 'б', 'а' }).IsPalindrome()); // True
			Console.WriteLine((new List<char> { 'а', 'б', 'в' }).IsPalindrome()); // False
		}

		Console.ReadKey();
        }

	/// <summary>
	/// Проверяет, является ли входная последовательность палиндромом.
	/// </summary>
	/// <typeparam name="string">Тип входной последовательности.</typeparam>
	/// <param name="input">Последовательность для проверки на палиндром.</param>
	/// <returns>Возвращает true, если последовательность является палиндромом, 
	/// и false в противном случае.</returns>
	public static bool IsPalindrome (string str)
		=> str == String.Join("", str.ToCharArray().Reverse());		
	}

	public static class Extensions
	{
		/// <summary>
		/// Проверяет, является ли входная последовательность палиндромом.
		/// </summary>
		/// <typeparam name="T">Тип входной последовательности, 
		/// который должен реализовывать интерфейс IEnumerable.</typeparam>
		/// <param name="input">Последовательность для проверки на палиндром.</param>
		/// <returns>Возвращает true, если последовательность является палиндромом, 
		/// и false в противном случае.</returns>
		public static bool IsPalindrome<T>(this T input)
			where T : IEnumerable
		{
			/// Преобразуем входную последовательность в массив объектов
			var array = input.Cast<object>().ToArray();

			/// Сравниваем исходную последовательность с её обратным порядком
			return array.SequenceEqual(array.Reverse());
		}
	}
}
