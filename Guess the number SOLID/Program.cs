using Guess_the_number_SOLID;
using RandomNumberGenerator = Guess_the_number_SOLID.RandomNumberGenerator;

Game game = new Game(new RandomNumberGenerator(), new NumberChecker(), new HumanGuesser());
bool result = game.Play();

if (result)
{ 
    Console.WriteLine("Вы угадали!");
}
else
{
    Console.WriteLine("Вы не угадали!");
}

