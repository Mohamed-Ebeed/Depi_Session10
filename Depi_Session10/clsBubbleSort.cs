namespace Depi_Session10
{
    // ------------------------------------------------------------------------------------
    // Q1) How can we optimize Bubble Sort?
    //
    // Normal Bubble Sort always does n-1 passes and compares every pair in every pass,
    // even if the array is already sorted => always about n^2 comparisons.
    //
    // Optimizations:
    // 1) "swapped" flag (early exit): if a full pass makes NO swap, the array is already
    //    sorted, so we stop immediately. Best case (already sorted array) becomes O(n)
    //    instead of O(n^2).
    // 2) Shrink the inner loop: after each pass, the biggest element of that pass is placed
    //    at its final position at the end, so the next pass doesn't need to compare it again
    //    (the inner loop runs to n - 1 - pass).
    // 3) (Extra idea) remember the position of the LAST swap: everything after it is already
    //    sorted, so the next pass can stop there. Or use Cocktail Shaker Sort (bubble in both directions).
    //
    // Complexity: worst and average case are still O(n^2) (e.g. a reverse-sorted array),
    // the optimization only improves the best case / nearly sorted data. For big data
    // we should use better algorithms like Merge Sort or Quick Sort: O(n log n).
    // ------------------------------------------------------------------------------------
    public static class BubbleSorter
    {
        // Generic: works with any type that can be compared (int, string, double, ...).
        // Returns the number of passes made, just to show the effect of the optimization.
        public static int OptimizedBubbleSort<T>(T[] array) where T : IComparable<T>
        {
            int passes = 0;

            for (int pass = 0; pass < array.Length - 1; pass++)
            {
                passes++;
                bool swapped = false;

                // Optimization 2: last "pass" elements are already in their final place
                for (int i = 0; i < array.Length - 1 - pass; i++)
                {
                    if (array[i].CompareTo(array[i + 1]) > 0)
                    {
                        (array[i], array[i + 1]) = (array[i + 1], array[i]);   // swap
                        swapped = true;
                    }
                }

                // Optimization 1: no swaps in this pass => already sorted => stop
                if (!swapped)
                    break;
            }

            return passes;
        }
    }
}
