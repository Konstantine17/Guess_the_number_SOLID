using Guess_the_number_SOLID.Interface;

namespace Guess_the_number_SOLID;

public class NumberChecker: INumberChecker
{
    public bool IsCorrect(int guess, int number)
    {
        return guess == number;
    }
}