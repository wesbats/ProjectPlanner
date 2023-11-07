using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPlanner.Views
{
    internal class MenuSelecao
    {
        internal static int Read(IList<string> options, string? title)
        {
            int selected = 0;
            ConsoleKeyInfo key;
            do
            {
                Print(options, selected, null);
                key = Console.ReadKey(true);
                selected = UpdateSelected(options, selected, key);
            } while (key.Key != ConsoleKey.Enter);
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

        private static int UpdateSelected(IList<string> options, int selected, ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.DownArrow)
            {
                if (selected == options.Count - 1)
                {
                    selected = 0;
                }
                else
                {
                    selected++;
                }
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                if (selected == 0)
                {
                    selected = options.Count - 1;
                }
                else
                {
                    selected--;
                }
            }
            return selected;
        }
    }
}
