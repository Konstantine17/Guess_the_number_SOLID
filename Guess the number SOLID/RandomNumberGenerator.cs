using Guess_the_number_SOLID.Interface;

namespace Guess_the_number_SOLID;

public class RandomNumberGenerator: INumberGenerator
{
    public int GenerateNumber()
    {
        return new Random().Next(1, 11);
    }
}