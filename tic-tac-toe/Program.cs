char[,] slots = new char[3, 3];
char[,] placeholders = new char[3, 3] { { 'a', 'b', 'c' }, { 'd', 'e', 'f' }, { 'g', 'h', 'i' } };

bool PLAYING = true;

// Get a certain position with a placeholder coordinate e.g: a
int[] GetPositionByCoordinate(string input)
{
  // If the input length is longer than 1 it's an invalid input 
  if (input.Length > 1)
  {
    return [];
  }

  for (int i = 0; i < 3; i++)
  {
    for (int j = 0; j < 3; j++)
    {
      // Check the first eleent, because it should only contain one element
      if (placeholders[i, j] == input.ToCharArray()[0])
      {
        return [i, j];
      }
    }
  }

  // Return an empty array if not found
  return [];
}

// Print the current board condition
void VisualizeBoardCondition()
{
  for (int i = 0; i < 3; i++)
  {
    for (int j = 0; j < 3; j++)
    {
      char element = slots[i, j];

      // Check if the element is empty
      if (element == '\0')
      {
        element = placeholders[i, j];
      }

      // Print out the validated element
      Console.Write(element + " ");
    }
    Console.WriteLine();
  }
}

void AssignPlayerTo(int[] index, char player)
{
  if (index.Length != 2)
  {
    return;
  }

  // Player can be any character
  slots[index[0], index[1]] = player;
}

// Main loop
while (PLAYING)
{
  VisualizeBoardCondition();

  Console.WriteLine("You are playing as X");
  Console.Write("Enter your desired position: ");

}
