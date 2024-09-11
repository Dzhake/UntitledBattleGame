using System.Text;

namespace UntitledBattleGame;

class Program
{
    

    static void Main(string[] args)
    {
        try
        {

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "--seed" && args.Length > (i + 1))
                {
                    Utils.random = new Random(int.Parse(args[i + 1]));
                    i++;
                }
                else if (args[i] == "--default-settings")
                {
                    Settings.DefaultSettings = true;
                }
                else
                {
                    ColorConsole.WriteLine($"Unknown flag {{#red}}{args[i]}{{#}}!");
                }
            }

            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8; // it supports funny characters which allow to draw ascii art

        }
        catch (Exception e)
        {
            ColorConsole.WriteLine(e.ToString(), ConsoleColor.Red);
        }
    }

}