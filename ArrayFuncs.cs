namespace Challenge_5 {
    internal class ArrayFuncs {

        public static int UnpairedNested(int[] numbers) {

            for (int outer = 0; outer < numbers.Length; outer++) {

                int matches = 0;

                for (int inner = 0; inner < numbers.Length; inner++) {
                    if (numbers[outer] == numbers[inner])
                        matches++;
                }

                if (matches == 1)
                    return numbers[outer];

            }

            return 0;

        }

        public static int UnpairedDictionary(int[] numbers) {

            Dictionary<int, int> counts = new();

            foreach (int number in numbers) {
                if (counts.ContainsKey(number))
                    counts[number]++;
                else
                    counts[number] = 1;
            }

            foreach (var count in counts) {
                if (count.Value == 1)
                    return count.Key;
            }

            return 0;

        }

        public static int UnpairedHashSet(int[] numbers) {

            HashSet<int> seen = new();

            foreach (int number in numbers) {
                if (!seen.Add(number))
                    seen.Remove(number);
            }

            return seen.Count == 1 ? seen.First() : 0;

        }

        public static int MissingValue(int[] numbers) {

            int highest = numbers.Length;
            int expected = highest * (highest + 1) / 2;
            int actual = 0;

            foreach (int number in numbers)
                actual += number;

            return expected - actual;

        }

        public static int BestTotal(int[] values) {

            int twoBack = 0;
            int oneBack = 0;

            foreach (int value in values) {

                int best = Math.Max(oneBack, twoBack + value);

                twoBack = oneBack;
                oneBack = best;

            }

            return oneBack;

        }
    }
}
