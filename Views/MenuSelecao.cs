namespace ProjectPlanner.Views
{
    internal class MenuSelecao
    {
        internal static int[] Read(IList<string> options, string? title)
        {
            int[] selected = new int[2] { 0, 0 };
            ConsoleKeyInfo key;
            do
            {
                Print(options, selected[0], title);
                key = Console.ReadKey(true);
                selected = UpdateSelected(options, selected, key);
            } while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Delete && key.Key != ConsoleKey.R);
            return selected;
        }

        private static void Print(IList<string> options, int selected, string? title)
        {
            TopBar.Printer();
            if (title != null)
            {
                Console.WriteLine("== " + title + " ==");
            }
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{(selected == i ? ">" : " ")} {options[i]}");
            }
        }

        private static int[] UpdateSelected(IList<string> options, int[] selected, ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.DownArrow)
            {
                if (selected[0] == options.Count - 1)
                {
                    selected[0] = 0;
                }
                else
                {
                    selected[0]++;
                }
            }
            if (key.Key == ConsoleKey.UpArrow)
            {
                if (selected[0] == 0)
                {
                    selected[0] = options.Count - 1;
                }
                else
                {
                    selected[0]--;
                }
            }
            if (key.Key == ConsoleKey.R)
            {
                selected[1] = 1;
            }
            if (key.Key == ConsoleKey.Delete)
            {
                selected[1] = 2;
            }
            return selected;
        }
    }
}
