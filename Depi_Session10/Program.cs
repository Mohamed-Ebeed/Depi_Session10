using System.Collections;

namespace Depi_Session10
{
    class Program
    {
        static void Main(string[] args)
        {
            Q1_BubbleSort();
            Q2_Range();
            Q3_ReverseArrayList();
            Q4_EvenNumbers();
            Q5_FixedSizeList();
            Q6_FirstNonRepeatedChar();
        }

        static void Q1_BubbleSort()
        {
            Console.WriteLine("===== Q1: Optimized Bubble Sort =====");

            int[] numbers = { 64, 34, 25, 12, 22, 11, 90 };
            int passes = BubbleSorter.OptimizedBubbleSort(numbers);
            Console.WriteLine($"Random array   -> {string.Join(", ", numbers)}   (passes: {passes})");

            // Already sorted: the swapped flag stops after the FIRST pass
            int[] sorted = { 1, 2, 3, 4, 5, 6, 7 };
            passes = BubbleSorter.OptimizedBubbleSort(sorted);
            Console.WriteLine($"Sorted array   -> {string.Join(", ", sorted)}   (passes: {passes})");

            // Generic: works with strings too
            string[] names = { "Sara", "Ahmed", "Mona", "Khaled" };
            BubbleSorter.OptimizedBubbleSort(names);
            Console.WriteLine($"Strings        -> {string.Join(", ", names)}");
            Console.WriteLine();
        }

        static void Q2_Range()
        {
            Console.WriteLine("===== Q2: Range<T> =====");

            Range<int> intRange = new Range<int>(10, 50);
            Console.WriteLine($"Range {intRange}");
            Console.WriteLine($"IsInRange(25): {intRange.IsInRange(25)}");   // True
            Console.WriteLine($"IsInRange(60): {intRange.IsInRange(60)}");   // False
            Console.WriteLine($"Length: {intRange.Length()}");               // 40

            Range<double> doubleRange = new Range<double>(1.5, 4.0);
            Console.WriteLine($"Range {doubleRange}, IsInRange(2.2): {doubleRange.IsInRange(2.2)}, Length: {doubleRange.Length()}");

            Range<DateTime> dateRange = new Range<DateTime>(new DateTime(2026, 1, 1), new DateTime(2026, 1, 31));
            Console.WriteLine($"Date range length: {dateRange.Length()}");   // 30.00:00:00 (TimeSpan)

            try
            {
                Range<int> bad = new Range<int>(100, 1);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.WriteLine();
        }

        static void Q3_ReverseArrayList()
        {
            Console.WriteLine("===== Q3: Reverse ArrayList in place =====");

            ArrayList list = new ArrayList { 1, "two", 3.5, 'D', 5 };
            Console.WriteLine($"Before: {string.Join(", ", list.Cast<object>())}");

            ListHelper.ReverseInPlace(list);
            Console.WriteLine($"After : {string.Join(", ", list.Cast<object>())}");
            Console.WriteLine();
        }

        static void Q4_EvenNumbers()
        {
            Console.WriteLine("===== Q4: Even numbers =====");

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, -8, 0, 11 };
            List<int> evens = ListHelper.GetEvenNumbers(numbers);

            Console.WriteLine($"Original: {string.Join(", ", numbers)}");
            Console.WriteLine($"Evens   : {string.Join(", ", evens)}");
            Console.WriteLine();
        }

        static void Q5_FixedSizeList()
        {
            Console.WriteLine("===== Q5: FixedSizeList<T> =====");

            FixedSizeList<string> list = new FixedSizeList<string>(3);
            list.Add("A");
            list.Add("B");
            list.Add("C");
            Console.WriteLine($"Count = {list.Count}, Capacity = {list.Capacity}, Get(1) = {list.Get(1)}");

            try
            {
                list.Add("D");   // list is full
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            try
            {
                list.Get(5);     // invalid index
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.WriteLine();
        }

        static void Q6_FirstNonRepeatedChar()
        {
            Console.WriteLine("===== Q6: First non-repeated character =====");

            string[] tests = { "leetcode", "loveleetcode", "aabb", "" };

            foreach (string text in tests)
            {
                Console.WriteLine($"\"{text}\" -> {StringHelper.FirstNonRepeatedCharIndex(text)}");
            }
        }
    }
}
