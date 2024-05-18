using Guess_the_number_SOLID.Interface;

namespace Guess_the_number_SOLID;

public class HumanGuesser: IGuesser
{
    public int GetGuess()
    {
        Console.WriteLine("Введите ваше число");
        return int.Parse(Console.ReadLine());
    }
}