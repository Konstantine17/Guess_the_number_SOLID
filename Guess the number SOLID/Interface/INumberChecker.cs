namespace Guess_the_number_SOLID.Interface;

public interface INumberChecker
{
    bool IsCorrect(int guess, int number);
}