using System.Text;

namespace Lab2;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        var text = new StringText("Кожна людина з великою любов’ю згадує те місце, де вона народилася. Це маленька батьківщина кожного з нас.\nКоли їх скласти разом, вийде велика держава — Україна. Це наша земля з її славною історією і мудрими, талановитими людьми. Протягом багатьох віків наш народ боровся за свою незалежність і переміг.\nУкраїна в усьому, що нас оточує. Це і ясне небо над пшеничними ланами, і червона калина в лузі, і криниця на подвір’ї, і рушничок, вишитий бабусею. Любіть свою Батьківщину!");
        var sortedSentences = text.GetSortedSentences();

        Console.WriteLine($"1. Text:\n{text.Data}\n");
        Console.WriteLine("2. Sorted sentences");
        foreach (var sentence in sortedSentences)
        {
            Console.WriteLine($"({sentence.WordsCount}) {sentence.Data}");
        }

        Console.ReadKey();
    }
}

