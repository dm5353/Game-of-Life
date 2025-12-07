using System.Text.Json;

namespace WinForms_Life
{
    public static class GameStateManager
    {
        public static void SaveGameState(string path, int[,] state, int[,][] genomes)
        {
            int rows = state.GetLength(0);
            int cols = state.GetLength(1);
            int[] flatArray = new int[rows * cols];
            var genomeArray = new int[rows][][];

            // Распаковываем состояние
            for (int i = 0; i < rows; i++)
            {
                genomeArray[i] = new int[cols][];
                for (int j = 0; j < cols; j++)
                {
                    flatArray[i * cols + j] = state[i, j];
                    genomeArray[i][j] = genomes[i, j];
                }
            }

            var gameState = new GameState
            {
                Rows = rows,
                Columns = cols,
                Data = flatArray,
                Genomes = genomeArray
            };

            string json = JsonSerializer.Serialize(gameState, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }

        public static GameState LoadGameState(string path)
        {
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<GameState>(json);
        }
    }

    public class GameState
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int[] Data { get; set; }
        public int[][][] Genomes { get; set; }
    }
}