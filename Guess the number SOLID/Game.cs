using Guess_the_number_SOLID.Interface;

namespace Guess_the_number_SOLID;

public class Game
{
    private readonly INumberGenerator _numberGenerator;
    private readonly IGuesser _guesser;
    private readonly INumberChecker _numberChecker;

    public Game(INumberGenerator numberGenerator, INumberChecker numberChecker, IGuesser guesser)
    {
        _numberGenerator = numberGenerator;
        _numberChecker = numberChecker;
        _guesser = guesser;
    }

    public bool Play()
    {
        int number = _numberGenerator.GenerateNumber();
        while (true)
        {
            int guess = _guesser.GetGuess();
            if (_numberChecker.IsCorrect(guess, number))
            {
                return true;
            }
        }
    }
}