using System;

namespace Program
{
    class Game
    {

        public static string[] board = new string[9];
        public static bool isPlaying = false;
        static void Main(string[] args)
        {
            isPlaying = true;
            Player player = new Player();
            AI ai = new AI();
            

            while(isPlaying){
                int x = player.Move();
                while(board[x] != null){
                    Console.WriteLine("Cannot Select an Occupied Space");
                    x = player.Move();
                }
                board[x] = "X";
                
                printBoard(board);

                isPlaying = !CheckForWinner(board);

                int y = ai.Move(board);
                Console.WriteLine(y);
                board[y] = "O";

                printBoard(board);

                isPlaying = !CheckForWinner(board);
            }
            // Console.WriteLine(pos.GetType()); 
        }

        public static void printBoard(string[] board){
            Console.WriteLine(" ");
            Console.WriteLine(board[0] + " | " + board[1] + " | " + board[2]);
            Console.WriteLine("---------");
            Console.WriteLine(board[3] + " | " + board[4] + " | " + board[5]);
            Console.WriteLine("---------");
            Console.WriteLine(board[6] + " | " + board[7] + " | " + board[8]);
            Console.WriteLine(" ");
        }

        public static bool CheckForWinner(string[] board){
            bool Win = false;

            //Check Columns
            for(int i = 0; i < 3; i++){
                if(board[i] != null){
                    if(board[i] == board[i+3] && board[i] == board[i+6]){
                        Win = true;
                    }
                }
            }

            //Check Rows
            for(int i = 0; i < board.Length; i+=3){
                if(board[i] != null){
                    if(board[i] == board[i+1] && board[i] == board[i+2]){
                        Win = true;
                    }
                }
            }

            //Checks Horizontal Left
            if(board[0] != null && board[0] == board[4] && board[0] == board[8]){
                Win = true;
            }
            //Checks Horizontal Right
            if(board[2] != null && board[2] == board[4] && board[2] == board[6]){
                Win = true;
            }
            return Win;
        }
    }
}
