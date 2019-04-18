using System;
using System.Collections.Generic;

namespace TicTacToe
{
    // Class that is responsible for the main flow of the game.
    // The class is centered on a stack where Gamestate's can be stored.
    public class Game
    {
        public bool isActive = true;
        public Stack<GameState> states = new Stack<GameState>();
        public Settings settings = new Settings();

        // Pushes a new GameState to the stack
        public void PushState(GameState state)
        {
            states.Push(state);
        }
        // Removes the current GameState from the top of the stack
        public void PopState()
        {
            states.Pop();
        }
        // Replaces top of the stack with 'state'
        public void ChangeState(GameState state)
        {
            if (states.Count != 0)
            {
                PopState();
            }
            PushState(state);
        }

        // Polymorphism makes it possible that the correct versions
        // of functions Draw(), HandleInput() and Update() can be called
        // for each class without them actually being one specific funtion.
        public void GameLoop()
        {
            states.Peek().DrawHeader();
            states.Peek().Draw();

            while (isActive)
            {
                if (states.Count == 0) continue;

                // TODO Messy...
                Console.Clear();
                states.Peek().DrawHeader();
                states.Peek().Draw();

                states.Peek().HandleInput();
                states.Peek().Update();

                Console.Clear();
                states.Peek().DrawHeader();
                states.Peek().Draw();
            }
        }

        // Destructor removes all GameStates from the stack
        ~Game()
        {
            while (states.Count != 0)
            {
                PopState();
            }
        }
    }
}
