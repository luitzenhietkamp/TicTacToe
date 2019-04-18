using System;

namespace TicTacToe
{
    public class GameStateMenu : GameState
    {
        public GameStateMenu(ref Game game)
        {
            this.game = game;
        }
        public override void Draw()
        {
            Console.WriteLine("Welcome to TicTacToe");
            Console.WriteLine("Please choose an option from the menu below.");
            Console.WriteLine("  p) Play");
            Console.WriteLine("  s) Settings");
            Console.WriteLine("  i) Instructions");
            Console.WriteLine("  q) Quit");
        }

        public override void Update()
        {

        }

        public override void HandleInput()
        {
            string input = Console.ReadLine().ToLower();

            if (input == "q")
            {
                game.isActive = false;
            }
            else if (input == "i")
            {
                game.PushState(new GameStateInstructions(ref game));
            }
            else if (input == "s")
            {
                game.PushState(new GameStateSettings(ref game));
            }
            else if (input == "p")
            {
                game.PushState(new GameStatePlay(ref game));
            }
            else
            {
                game.PushState(new GameStateInputError(ref game, input));
            }
        }
    }
}
