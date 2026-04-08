using RogueLib.Dungeon;
using RogueLib.Engine;
using RogueLib.Utilities;
using SandBox01;
using Spectre.Console;
using System.Linq;
using TileSet = System.Collections.Generic.HashSet<RogueLib.Utilities.Vector2>;

namespace RlGameNS;
class Program
{

    static void Main(string[] args)
    {
        Console.Clear();
       // Game game = new MyGame();
        //game.run();
        bool isRunning = false;
        while (!isRunning)
        {
            AnsiConsole.MarkupLine("[bold red]Welcome to the RogueLike Game![/]\n");
            string userChoice = AnsiConsole.Prompt( new SelectionPrompt<string>()
                                .Title("\nMain menu:")
                                .AddChoices(
                                [
                                    "(1) new Game:",
                                    "(2) Load Game:",
                                    "(3) Characters:",
                                    "(4) Rules:",

                                    "(Q) Quit"
                                ])
                            );


            switch (userChoice)
            {
                case "(1) New Game:":
                    Game game = new MyGame();
                    game.run();
                    break;
                case "(2) Load Game:":
                    Console.WriteLine("Load Game");
                    break;
                case "(3) Characters:":
                    Console.WriteLine("Characters");
                    break;
                case "(4) Rules:":
                    Console.WriteLine("Rules");
                    break;
                case "(5) Quit":
                    isRunning = true;
                    break;
            }

        }
    }
    //option for menu 
    /**
     *      var choices = new[]
             {
                 "(1) New Game:",
                 "(2) Load Game:",
                 "(3) Characters:",
                 "(4) Rules:",
                 "(5) Quit"
             };

             //string userChoice = ShowCenteredMenu("Main Menu:", choices);
     * static string ShowCenteredMenu(string title, string[] choices)
     {
         int maxLen = choices.Max(s => s.Length);
         int width = Math.Max(maxLen, title.Length) + 4;
         int height = choices.Length + 4;
         int left = Math.Max((Console.WindowWidth - width) / 2, 0);
         int top = Math.Max((Console.WindowHeight - height) / 2, 0);

         try { Console.SetCursorPosition(left, top); } catch { }

         int titleLeft = left + Math.Max((width - title.Length) / 2, 0);
         try { Console.SetCursorPosition(titleLeft, Console.CursorTop); } catch { }
         Console.WriteLine(title);
         Console.WriteLine();

         for (int i = 0; i < choices.Length; i++)
         {
             string text = choices[i];
             int textLeft = left + Math.Max((width - text.Length) / 2, 0);
             try { Console.SetCursorPosition(textLeft, Console.CursorTop); } catch { }
             Console.WriteLine(text);
         }

         Console.WriteLine();
         string prompt = $"Enter choice [1-{choices.Length}]: ";
         int promptLeft = left + Math.Max((width - prompt.Length) / 2, 0);

         while (true)
         {
             try { Console.SetCursorPosition(promptLeft, Console.CursorTop); } catch { }
             Console.Write(prompt);
             string input = Console.ReadLine();
             if (int.TryParse(input, out int idx) && idx >= 1 && idx <= choices.Length)
                 return choices[idx - 1];

             string err = "Invalid choice. Try again.";
             int errLeft = left + Math.Max((width - err.Length) / 2, 0);
             try { Console.SetCursorPosition(errLeft, Console.CursorTop); } catch { }
             Console.WriteLine(err);
         }
     }*/
}