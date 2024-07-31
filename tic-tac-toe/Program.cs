class TicTacToe
{
  static char[,] board = new char[3, 3];
  static char[,] placeholders = new char[3, 3] { { 'a', 'b', 'c' }, { 'd', 'e', 'f' }, { 'g', 'h', 'i' } };
  static bool playing = true;

  static void Main(string[] args)
  {
    int turnChecker = 0;

    while (playing)
    {
      VisualizeBoard();
      char player = (turnChecker % 2 == 0) ? 'X' : 'O';

      Console.WriteLine($"\nPlayer {player}'s turn");

      int[] position = GetPlayerPosition();
      if (position.Length == 0)
      {
        continue;
      }

      PlaceMarker(position, player);

      if (IsBoardFull())
      {
        Console.WriteLine("It's a tie!");
        break;
      }

      char? winner = CheckWinner();
      if (winner != null)
      {
        Console.WriteLine($"Winner: {winner}");
        break;
      }

      turnChecker++;
    }
  }

  static int[] GetPositionFromPlaceholder(char placeholder)
  {
    for (int i = 0; i < 3; i++)
    {
      for (int j = 0; j < 3; j++)
      {
        if (placeholders[i, j] == placeholder)
        {
          return [i, j];
        }
      }
    }
    return [0];
  }

  static void VisualizeBoard()
  {
    for (int i = 0; i < 3; i++)
    {
      for (int j = 0; j < 3; j++)
      {
        char element = board[i, j];
        if (element == '\0')
        {
          element = placeholders[i, j];
        }
        Console.Write(element + " ");
      }
      Console.WriteLine();
    }
  }

  static void PlaceMarker(int[] position, char player)
  {
    if (position.Length == 2 && board[position[0], position[1]] == '\0')
    {
      board[position[0], position[1]] = player;
    }
    else
    {
      Console.WriteLine("Invalid position or already occupied!");
    }
  }

  static int[] GetPlayerPosition()
  {
    Console.Write("Enter your desired position: ");
    string? input = Console.ReadLine();

    if (string.IsNullOrEmpty(input) || input.Length != 1)
    {
      Console.WriteLine("Invalid input");
      return [];
    }

    int[] position = GetPositionFromPlaceholder(input[0]);
    if (position.Length == 0)
    {
      Console.WriteLine("Position not found!");
    }

    return position;
  }

  static bool IsBoardFull()
  {
    foreach (char spot in board)
    {
      if (spot == '\0')
      {
        return false;
      }
    }
    return true;
  }

  static char? CheckWinner()
  {
    // Check diagonals
    if (board[1, 1] != '\0' && ((board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2]) ||
                                (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])))
    {
      return board[1, 1];
    }

    for (int i = 0; i < 3; i++)
    {
      // Check rows and columns
      if ((board[i, 0] != '\0' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2]) ||
          (board[0, i] != '\0' && board[0, i] == board[1, i] && board[1, i] == board[2, i]))
      {
        return board[i, 0] != '\0' ? board[i, 0] : board[0, i];
      }
    }

    return null;
  }
}