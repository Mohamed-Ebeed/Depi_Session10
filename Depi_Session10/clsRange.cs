namespace Depi_Session10
{
    // Q2) Generic Range<T>.
    // We assume T implements IComparable<T> so we can compare values.
    public class Range<T> where T : IComparable<T>
    {
        public T Min { get; }
        public T Max { get; }

        // Constructor takes the minimum and maximum values
        public Range(T min, T max)
        {
            if (min.CompareTo(max) > 0)
                throw new ArgumentException("Minimum value cannot be greater than the maximum value.");

            Min = min;
            Max = max;
        }

        // true if Min <= value <= Max (both ends are included)
        public bool IsInRange(T value)
        {
            return value.CompareTo(Min) >= 0 && value.CompareTo(Max) <= 0;
        }

        // Length = Max - Min
        // IComparable<T> gives us comparison only, NOT the "-" operator, so the compiler
        // doesn't know how to subtract two T values. We use "dynamic": the subtraction is
        // resolved at RUN time, so it works for int, double, decimal, DateTime (returns TimeSpan), ...
        // (For a type that has no "-" operator, like string, it throws RuntimeBinderException.)
        public dynamic Length()
        {
            return (dynamic)Max - (dynamic)Min;
        }

        public override string ToString()
        {
            return $"[{Min} .. {Max}]";
        }
    }
}
