using System;
using System.Collections.Generic;

namespace TicTacToe
{
    // GameStateX class responsible for the actual implementation
    // of the game
    public class GameStatePlay : GameState
    {
        char[] fields;      // will store the status of all 9 fields
        bool playerHasTurn;
        readonly char playerShape;
        readonly char aiShape;
        int turn;
        Random rnd;         // Random number generator

        public GameStatePlay(ref Game game)
        {
            this.game = game;
            rnd = new Random();

            // Set up a new game
            turn = 0;
            fields = new char[9];
            for (int i = 0; i < fields.Length; i++)
            {
                fields[i] = 'n'; // 'n' refers to an empty field
            }

            // The player that starts the game will have their turn
            // in the first round#
            // Fun: uses ternary operator instead of if/else
            playerHasTurn = game.settings.playerTurn == 1 ? true : false;

            // Set the shapes for player and computer
            playerShape = game.settings.playerShape;
            aiShape = playerShape == 'X' ? 'O' : 'X';   // Fun: ternary operator
        }

        public override void Draw()
        {
            // Draw board (create separated method)
            List<string> board = new List<string>();
            string[] newElement;

            // Loop over rows
            for (int i = 0; i < 3; i++)
            {
                string[] row = new string[6];
                // Loop fields in row
                for (int j = 0; j < 3; j++)
                {
                    int index = 3 * i + j;
                    if (fields[index] == 'O')
                    {
                        newElement = Shapes.ShapeByIndex(9);
                    }
                    else if (fields[index] == 'X')
                    {
                        newElement = Shapes.ShapeByIndex(10);
                    }
                    else
                    {
                        newElement = Shapes.ShapeByIndex(index);
                    }

                    row = CharacterPicture.HCat(row, newElement);
                    if (j != 2)
                    {
                        row = CharacterPicture.HCat(row, new string[6] { "|", "|", "|", "|", "|", "|" });
                    }
                }
                board.AddRange(row);
                if (i != 2)
                {
                    board.Add("-----------------------------------------");
                }
            }

            // Write the board to the screen
            foreach (var item in board)
            {
                Console.WriteLine(item);
            }

            // Move to HandleInput???
            if (playerHasTurn && !IsGameOver())
            {
                Console.Write("Please choose a field by entering the number: ");
            }
        }

        // Checks for end of game conditions and induced an AI decision
        public override void Update()
        {
            // Either player won the game
            if (IsGameOver())
            {
                if (!playerHasTurn) Console.WriteLine("Congratulations, you won the game.");
                else Console.WriteLine("Sorry, you lost the game. Better luck next time.");
                Console.ReadLine();
                game.PopState();
            }
            // Game ended in a draw
            else if (turn == 9)
            {
                Console.WriteLine("The game ended in a draw. Play again for a new chance.");
                Console.WriteLine("Press enter to continue to the menu.");
                Console.ReadLine();
                game.PopState();
            }
            // Computer needs to make a choice
            else
            {
                if (!playerHasTurn)
                {
                    if (turn == 0)
                    {
                        Console.Clear();
                        DrawHeader();
                        Draw();
                    }
                    Console.Write("Computer is choosing");
                    Console.Write(".");
                    System.Threading.Thread.Sleep(400);
                    Console.Write(".");
                    System.Threading.Thread.Sleep(400);
                    Console.Write(".");
                    System.Threading.Thread.Sleep(400);
                    Console.Write(".");
                    System.Threading.Thread.Sleep(400);
                    Console.Write(".");
                    System.Threading.Thread.Sleep(400);
                    Console.Write(".");
                    Console.WriteLine();
                    AiDecision();
                    // Check whether AI won the game
                    // Possibly double code -> implement elsewhere
                    if (IsGameOver())
                    {
                        Console.Clear();
                        DrawHeader();
                        Draw();
                        Console.WriteLine();
                        // Test if redundant
                        if (!playerHasTurn) Console.WriteLine("Congratulations, you won the game.");
                        else Console.WriteLine("Sorry, you lost the game. Better luck next time.");
                        Console.ReadLine();
                        game.PopState();
                    }
                    else if (turn == 9)
                    {
                        Console.WriteLine("The game ended in a draw. Play again for a new chance.");
                        Console.WriteLine("Press enter to continue to the menu.");
                        Console.ReadLine();
                        game.PopState();
                    }
                }
            }
        }

        public override void HandleInput()
        {
            // Allow the user to choose a field
            if (playerHasTurn)
            {
                string input = Console.ReadLine();
                // Validate input
                try
                {
                    int choice = Int32.Parse(input);
                    PlayerChoice(choice);
                }
                catch (Exception ex)
                {
                    if (ex is ArgumentException || ex is FormatException)
                        game.PushState(new GameStateInputError(ref game, input));
                }
            }
        }

        bool IsGameOver()
        {
            if (fields[0] == fields[1] && fields[0] == fields[2] && fields[0] != 'n') return true;
            if (fields[3] == fields[4] && fields[3] == fields[5] && fields[3] != 'n') return true;
            if (fields[6] == fields[7] && fields[6] == fields[8] && fields[6] != 'n') return true;
            if (fields[0] == fields[3] && fields[0] == fields[6] && fields[0] != 'n') return true;
            if (fields[1] == fields[4] && fields[1] == fields[7] && fields[1] != 'n') return true;
            if (fields[2] == fields[5] && fields[2] == fields[8] && fields[2] != 'n') return true;
            if (fields[0] == fields[4] && fields[0] == fields[8] && fields[0] != 'n') return true;
            if (fields[2] == fields[4] && fields[2] == fields[6] && fields[2] != 'n') return true;
            return false;
        }

        // Validate and process player choice
        void PlayerChoice(int choice)
        {
            if (choice < 1 || choice > 9)
            {
                throw new ArgumentException();
            }
            if (fields[choice - 1] != 'n')
            {
                throw new ArgumentException();
            }
            else
            {
                playerHasTurn = false;
                fields[choice - 1] = playerShape;
                ++turn;
            }
            Console.Clear();
            DrawHeader();
            Draw();
        }

        void AiDecision()
        {
            if (game.settings.difficulty == 0)
            {
                RandomChoice();
            }
            if (game.settings.difficulty == 1)
            {
                if (!BlockChoice())
                {
                    RandomChoice();
                }
            }
            if (game.settings.difficulty == 2)
            {
                BestChoice();
            }
            playerHasTurn = true;
            ++turn;
        }
        void RandomChoice()
        {
            int choice = rnd.Next(8 - turn);
            for (int i = 0; i < 9; i++)
            {
                if (fields[i] == 'n')
                {
                    if (choice == 0)
                    {
                        fields[i] = aiShape;
                        break;
                    }
                    else
                    {
                        --choice;
                    }
                }
            }
        }

        bool BlockChoice()
        {
            for (int i = 0; i < fields.Length; i++)
            {
                if ((i % 3 == 0 && fields[i + 1] == playerShape && fields[i + 2] == playerShape) ||
                   (i % 3 == 1 && fields[i - 1] == playerShape && fields[i + 1] == playerShape) ||
                   (i % 3 == 2 && fields[i - 2] == playerShape && fields[i - 1] == playerShape) ||
                   (i / 3 == 0 && fields[i + 3] == playerShape && fields[i + 6] == playerShape) ||
                   (i / 3 == 1 && fields[i - 3] == playerShape && fields[i + 3] == playerShape) ||
                   (i / 3 == 2 && fields[i - 6] == playerShape && fields[i - 3] == playerShape) ||
                   (i == 0 && fields[4] == playerShape && fields[8] == playerShape) ||
                   (i == 2 && fields[4] == playerShape && fields[6] == playerShape) ||
                   (i == 4 && fields[0] == playerShape && fields[8] == playerShape) ||
                   (i == 4 && fields[2] == playerShape && fields[6] == playerShape) ||
                   (i == 6 && fields[2] == playerShape && fields[4] == playerShape) ||
                   (i == 8 && fields[0] == playerShape && fields[4] == playerShape))
                {
                    if (fields[i] == 'n')
                    {
                        fields[i] = aiShape;
                        return true;
                    }
                }
            }
            return false;
        }

        void BestChoice()
        {
            if (fields[4] == 'n')
            {
                fields[4] = aiShape;
                return;
            }
            if (CanWin())
            {
                return;
            }
            if (BlockChoice())
            {
                return;
            }
            GoodChoice();
        }

        bool CanWin()
        {
            for (int i = 0; i < fields.Length; i++)
            {
                if ((i % 3 == 0 && fields[i + 1] == aiShape && fields[i + 2] == aiShape) ||
                    (i % 3 == 1 && fields[i - 1] == aiShape && fields[i + 1] == aiShape) ||
                    (i % 3 == 2 && fields[i - 2] == aiShape && fields[i - 1] == aiShape) ||
                    (i / 3 == 0 && fields[i + 3] == aiShape && fields[i + 6] == aiShape) ||
                    (i / 3 == 1 && fields[i - 3] == aiShape && fields[i + 3] == aiShape) ||
                    (i / 3 == 2 && fields[i - 6] == aiShape && fields[i - 3] == aiShape) ||
                    (i == 0 && fields[4] == aiShape && fields[8] == aiShape) ||
                    (i == 2 && fields[4] == aiShape && fields[6] == aiShape) ||
                    (i == 4 && fields[0] == aiShape && fields[8] == aiShape) ||
                    (i == 4 && fields[2] == aiShape && fields[6] == aiShape) ||
                    (i == 6 && fields[2] == aiShape && fields[4] == aiShape) ||
                    (i == 8 && fields[0] == aiShape && fields[4] == aiShape))
                {
                    if (fields[i] == 'n')
                    {
                        fields[i] = aiShape;
                        return true;
                    }
                }
            }
            return false;
        }

        void GoodChoice()
        {
            RandomChoice();
        }
    }
}
