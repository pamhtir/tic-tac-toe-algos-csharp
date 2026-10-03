class Program
{
    static void Main()
    {
        char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        char currentPlayer = 'X';
        int movesMade = 0;

        while (movesMade < 9)
        {
            
            DrawBoard(board);

            Console.WriteLine($"Player {currentPlayer}'s turn.");

            int index = GetValidMove(board);
            
            board[index] = currentPlayer;
            movesMade++;
            
            if (CheckWinner(board, currentPlayer))
            {
                DrawBoard(board);
                Console.WriteLine($"Player {currentPlayer} wins!");
                break;
            }
            else if (movesMade == 9)
            {
                DrawBoard(board);
                Console.WriteLine("It's a draw!");
                break;
            }
            else
            {
                currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
            }
        }
    }

    static void DrawBoard(char[] board)
    {
        Console.WriteLine($"{board[0]} | {board[1]} | {board[2]}");
        Console.WriteLine("---------");
        Console.WriteLine($"{board[3]} | {board[4]} | {board[5]}");
        Console.WriteLine("---------");
        Console.WriteLine($"{board[6]} | {board[7]} | {board[8]}");
    }

    static int GetValidMove(char[] board)
    {
        while(true)
        {
            Console.WriteLine("Make a move by entering a number between 1-9");
            
            if (!int.TryParse(Console.ReadLine(), out int position))
            {
                Console.WriteLine("Invalid move!");
                continue;
            }
            if (position < 1 || position > 9)
            {
                Console.WriteLine("Number must be between 1-9!");
                continue;
            }

            int index = position - 1;

            if (board[index] == 'X' || board[index] == 'O')
            {
                Console.WriteLine("Position already taken!");
                continue;
            }
            
            return index;
        }
    }

    static bool IsWinningLine(char[] board, char player, int a, int b, int c)
    {
        return board[a] == player &&
               board[b] == player &&
               board[c] == player;
    }

    static bool CheckWinner(char[] board, char player)
    {
        return IsWinningLine(board, player, 0, 1, 2) ||
            IsWinningLine(board, player, 3, 4, 5) ||
            IsWinningLine(board, player, 6, 7, 8) ||

            IsWinningLine(board, player, 0, 3, 6) ||
            IsWinningLine(board, player, 1, 4, 7) ||
            IsWinningLine(board, player, 2, 5, 8) ||

            IsWinningLine(board, player, 0, 4, 8) ||
            IsWinningLine(board, player, 2, 4, 6);
    }
}