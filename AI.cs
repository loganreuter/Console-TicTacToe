using System;
using System.Collections.Generic;

namespace Program
{
    class AI
    {
        public void Init()
        {
            Console.WriteLine("This is the AI");
        }

        public int Move(string[] board){
            int bestMove = findBestMove(board);

            Console.WriteLine("The optimal value is : " + bestMove);
            return bestMove;
        }

        static int minimax(string[] board, int depth, Boolean isMax)
        {
            bool GameOver = Game.CheckForWinner(board);

            // If Maximizer has won the game
            // return his/her evaluated score
            if (GameOver == true && !isMax)
                return 10;

            // If Minimizer has won the game
            // return his/her evaluated score
            if (GameOver == true && isMax )
                return -10;

            // If there are no more moves and
            // no winner then it is a tie
            if (EmptyIndexes(board).Length == 0)
                return 0;

            // If this maximizer's move
            if (isMax)
            {
                int best = -1000;

                // Traverse all cells
                for (int i = 0; i < board.Length; i++)
                {
                    // Check if cell is empty
                    if (board[i] == null)
                    {
                        // Make the move
                        board[i] = "O";

                        // Call minimax recursively and choose
                        // the maximum value
                        best = Math.Max(best, minimax(board,
                                        depth + 1, !isMax));

                        // Undo the move
                        board[i] = null;
                    }
                }
                return best;
            }

            // If this minimizer's move
            else
            {
                int best = 1000;

                // Traverse all cells
                for (int i = 0; i < board.Length; i++)
                {
                    // Check if cell is empty
                    if (board[i] == null)
                    {
                        // Make the move
                        board[i] = "X";

                        // Call minimax recursively and choose
                        // the minimum value
                        best = Math.Min(best, minimax(board,
                                        depth + 1, !isMax));

                        // Undo the move
                        board[i] = null;
                    }
                }
                return best;
            }
        }

        static int findBestMove(string[] board){
            int bestVal = -1000;
            int bestMove = -1;

            // Traverse all cells, evaluate minimax function
            // for all empty cells. And return the cell
            // with optimal value.
            for (int i = 0; i < board.Length; i++)
            {
                // Check if cell is empty
                if (board[i] == null)
                {
                    // Make the move
                    board[i] = "O";

                    // compute evaluation function for this
                    // move.
                    int moveVal = minimax(board, 0, false);

                    // Undo the move
                    board[i] = null;

                    // If the value of the current move is
                    // more than the best value, then update
                    // best/
                    if (moveVal > bestVal)
                    {
                        bestMove = i;
                        bestVal = moveVal;
                    }
                }
            }

            Console.Write("The value of the best Move " +
                                "is : {0}\n\n", bestVal);

            return bestMove;
        }
        
        //Gathers all of the empty board spaces for the MiniMax algorithm
        private static int[] EmptyIndexes(string[] board){
            List<int> Array = new List<int>();

            for(int i = 0; i < board.Length; i++){
                if(board[i] == null){
                    Array.Add(i);
                }
            }

            int[] Indexes = Array.ToArray();
            return Indexes;
        }
    }
}