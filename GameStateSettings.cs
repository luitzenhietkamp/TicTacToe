using System;

namespace TicTacToe
{
    // GameStateX class responsible for the Settings screen
    // Here the user will be able to adjust important settings such
    // as difficulty, the preferred shape and which player starts the game
    public class GameStateSettings : GameState
    {
        public GameStateSettings(ref Game game)
        {
            this.game = game;
        }

        public override void Draw()
        {
            // Let the user set the difficulty
            Console.WriteLine("The current difficulty is " + game.settings.GetDifficulty() + ".");
            Console.WriteLine("To change the difficulty, choose");
            int diff = game.settings.difficulty;
            if (diff != 0)
                Console.WriteLine("  e) for Easy difficulty");
            if (diff != 1)
                Console.WriteLine("  m) for Medium difficulty");
            if (diff != 2)
                Console.WriteLine("  h) for Hard difficulty");

            // Let the user choose their shape
            Console.WriteLine();
            Console.WriteLine("Currently, your shape is a " + game.settings.ShapeAsString() + ".");
            Console.WriteLine("To change your shape type \"s\".");

            Console.WriteLine();
            Console.WriteLine("Currently, you play " + game.settings.TurnAsString() + ".");
            Console.WriteLine("To change the order, type \"o\".");

            // q to return to the main menu
            Console.WriteLine();
            Console.WriteLine("To quit the settings and return to the");
            Console.WriteLine("menu, type \"q\".");
        }

        public override void Update()
        {

        }

        public override void HandleInput()
        {
            string input = Console.ReadLine().ToLower();

            if (input == "q")
            {
                game.PopState();
            }
            else if (input == "e")
            {
                game.settings.difficulty = 0;
            }
            else if (input == "m")
            {
                game.settings.difficulty = 1;
            }
            else if (input == "h")
            {
                game.settings.difficulty = 2;
            }
            else if (input == "s")
            {
                game.settings.ChangeShape();
            }
            else if (input == "o")
            {
                game.settings.ChangeOrder();
            }
            else
            {
                // Incorrect input
                game.PushState(new GameStateInputError(ref game, input));
            }
        }
    }
}
