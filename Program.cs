namespace Challenge_5 {
    internal class Program {

        static void Main(string[] args) {

            Console.WriteLine("Select an option:");

            while (true) {

                Console.WriteLine();
                Console.WriteLine("  1 - Unpaired Number");
                Console.WriteLine("  2 - Missing Value");
                Console.WriteLine("  3 - Best Total Without Neighbors");
                Console.WriteLine("  x - Quit");

                var choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice) {
                    case '1':
                        UnpairedNumber();
                        break;
                    case '2':
                        MissingValue();
                        break;
                    case '3':
                        BestTotal();
                        break;
                    case 'x':
                        return;
                    default:
                        Console.WriteLine("That is not one of the options, please select something from the list.");
                        continue;
                }

                if (EndPrompt())
                    return;

            }

        }

        static void UnpairedNumber() {

            Console.WriteLine();
            Console.WriteLine("Every value shows up twice except one. The same set runs through three approaches.");

            int[] numbers = ReadNumbers("Numbers separated by spaces: ");

            Console.WriteLine($"Nested loop: {ArrayFuncs.UnpairedNested(numbers)}");
            Console.WriteLine($"Dictionary:  {ArrayFuncs.UnpairedDictionary(numbers)}");
            Console.WriteLine($"Hash set:    {ArrayFuncs.UnpairedHashSet(numbers)}");

        }

        static void MissingValue() {

            Console.WriteLine();
            Console.WriteLine("The numbers run from 0 up with one of them missing. Any order is fine.");

            int[] numbers = ReadNumbers("Numbers separated by spaces: ");

            Console.WriteLine($"Missing value: {ArrayFuncs.MissingValue(numbers)}");

        }

        static void BestTotal() {

            Console.WriteLine();
            Console.WriteLine("Each number is a house worth that much. No two houses next to each other can both be taken.");

            int[] values = ReadNumbers("House values separated by spaces: ");

            Console.WriteLine($"Best total: {ArrayFuncs.BestTotal(values)}");

        }

        static bool EndPrompt() {

            Console.WriteLine();
            Console.Write("Press enter to go back to the menu, or 'x' to quit: ");

            var choice = Console.ReadKey().KeyChar;
            Console.WriteLine();

            return choice == 'x';

        }

        static int[] ReadNumbers(string prompt) {

            while (true) {

                Console.Write(prompt);
                string[] numInputs = (Console.ReadLine() ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);

                List<int> parsedNums = new();

                foreach (string numInput in numInputs) {
                    if (int.TryParse(numInput, out int value))
                        parsedNums.Add(value);
                }

                if (parsedNums.Count > 0 && parsedNums.Count == numInputs.Length)
                    return parsedNums.ToArray();

                Console.WriteLine("Need at least one number, and only whole numbers.");

            }

        }
    }
}
