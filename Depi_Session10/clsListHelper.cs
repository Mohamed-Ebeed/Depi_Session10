using System.Collections;

namespace Depi_Session10
{
    public static class ListHelper
    {
        // Q3) Reverse an ArrayList IN PLACE (same list) without using Reverse().
        // Two pointers: one from the start, one from the end, swap and move towards the middle.
        public static void ReverseInPlace(ArrayList list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            for (int left = 0, right = list.Count - 1; left < right; left++, right--)
            {
                object temp = list[left];
                list[left] = list[right];
                list[right] = temp;
            }
        }

        // Q4) Returns a NEW list containing only the even numbers
        public static List<int> GetEvenNumbers(List<int> numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException(nameof(numbers));

            List<int> evens = new List<int>();

            foreach (int number in numbers)
            {
                if (number % 2 == 0)   // works for negative numbers too (-4 % 2 == 0)
                    evens.Add(number);
            }

            return evens;
        }
    }
}
