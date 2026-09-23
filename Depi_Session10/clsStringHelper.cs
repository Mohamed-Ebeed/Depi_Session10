namespace Depi_Session10
{
    public static class StringHelper
    {
        // Q6) Index of the first non-repeated character, or -1 if there is none.
        // Step 1: count every character using a Dictionary.
        // Step 2: go through the string again and return the index of the first char whose count is 1.
        // Time: O(n), extra space: O(k) where k = number of different characters.
        public static int FirstNonRepeatedCharIndex(string text)
        {
            if (string.IsNullOrEmpty(text))
                return -1;

            Dictionary<char, int> counts = new Dictionary<char, int>();

            foreach (char c in text)
            {
                if (counts.ContainsKey(c))
                    counts[c]++;
                else
                    counts[c] = 1;
            }

            for (int i = 0; i < text.Length; i++)
            {
                if (counts[text[i]] == 1)
                    return i;
            }

            return -1;
        }
    }
}
