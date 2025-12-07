using Timer = System.Windows.Forms.Timer;

namespace WinForms_Life
{
    public partial class Form1 : Form
    {
        private static int mapSize = 20;
        private static int cellSize = 20;

        int[,] currentState;
        int[,] nextState;

        int[] mapSizes = { 20, 40, 50 };
        int[] cellSizes = { 10, 20, 40 };

        int bitmapX, bitmapY;

        bool isPlaying = false;
        bool isMouseDown = false;

        private Bitmap bufferBitmap;
        Rectangle oldRect = new Rectangle();

        Timer timer;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SetFormSize();
            Initialize();
        }

        void SetFormSize()
        {
            this.Width = mapSize * cellSize + 40;
            this.Height = mapSize * cellSize + 100;

            bitmapX = (this.ClientSize.Width - mapSize * cellSize) / 2;
            bitmapY = (this.ClientSize.Height - mapSize * cellSize) / 2 + 15;
        }

        private void Initialize()
        {
            bufferBitmap = new Bitmap(mapSize * cellSize + 1, mapSize * cellSize + 1);
            currentState = new int[mapSize, mapSize];
            nextState = new int[mapSize, mapSize];

            currentState = InitializeMap();
            nextState = InitializeMap();

            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += new EventHandler(UpdateStates);
        }

        private void UpdateStates(object? sender, EventArgs e)
        {
            CalculateNextState();
        }

        private void CalculateNextState()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    int countNeighboors = CountNeighboors(i, j);

                    if (currentState[i, j] == 0 && countNeighboors == 3)
                        nextState[i, j] = 1;
                    else if (currentState[i, j] == 1 && (countNeighboors > 3 && countNeighboors < 2))
                        nextState[i, j] = 0;
                    else if (currentState[i, j] == 1 && (countNeighboors <= 3 && countNeighboors >= 2))
                        nextState[i, j] = 1;
                    else
                        nextState[i, j] = 0;
                }
            }
            Invalidate();
            currentState = nextState;
            nextState = InitializeMap();
        }

        int CountNeighboors(int i, int j)
        {
            int count = 0;
            for (int k = i - 1; k <= i + 1; k++)
            {
                for (int l = j - 1; l <= j + 1; l++)
                {
                    if (!InMap(k, l))
                        continue;
                    if (k == i && l == j)
                        continue;
                    if (currentState[k, l] == 1)
                        count++;
                }
            }
            return count;
        }

        bool InMap(int i, int j)
        {
            if (i < 0 || j < 0 || i >= mapSize || j >= mapSize)
                return false;
            return true;
        }

        private int[,] InitializeMap()
        {
            int[,] array = new int[mapSize, mapSize];

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    array[i, j] = 0;
                }
            }
            return array;
        }

        private void buttonPlayPause_Click(object sender, EventArgs e)
        {
            isPlaying = !isPlaying;

            Save.Enabled = !isPlaying;
            Load.Enabled = !isPlaying;
            comboBox1.Enabled = !isPlaying;
            comboBox2.Enabled = !isPlaying;

            if (isPlaying)
            {
                buttonPlayPause.Text = "Пауза";
                timer.Start();
            }
            else
            {
                buttonPlayPause.Text = "Играть";
                timer.Stop();
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                saveFileDialog.Title = "Сохранить состояние игры";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    GameStateManager.SaveGameState(saveFileDialog.FileName, currentState);
                }
            }
        }

        private void Load_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                openFileDialog.Title = "Загрузить сохранение";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var gameState = GameStateManager.LoadGameState("save.json");

                    ResizeMap(gameState.Rows);
                    comboBox1.Text = $"{gameState.Rows}x{gameState.Rows}";

                    for (int i = 0; i < gameState.Rows; i++)
                        for (int j = 0; j < gameState.Columns; j++)
                            currentState[i, j] = gameState.Data[i * gameState.Columns + j];

                    Invalidate();
                }
            }
        }

        private void ToggleCell(int x, int y)
        {
            int j = (x - bitmapX) / cellSize;
            int i = (y - bitmapY) / cellSize;

            if (!InMap(i, j)) return; // Проверяем, чтобы не выйти за границы массива

            Rectangle newRect = new Rectangle(j * cellSize + bitmapX, i * cellSize + bitmapY, cellSize, cellSize);

            if (newRect != oldRect)
            {
                currentState[i, j] = currentState[i, j] == 1 ? 0 : 1; // Делаем клетку мертвой/живой
                Invalidate(newRect); // Перерисовываем только клетку
                oldRect = newRect;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) => ResizeMap();
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) => ResizeMap();
        void ResizeMap() => ResizeMap(-1);
        void ResizeMap(int saveMapSize)
        {
            mapSize = saveMapSize == -1 ? mapSizes[comboBox1.SelectedIndex] : saveMapSize;
            cellSize = cellSizes[comboBox2.SelectedIndex];

            SetFormSize();
            if (saveMapSize == -1) Invalidate();
            Initialize();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = Graphics.FromImage(bufferBitmap))
            {
                for (int i = 0; i < mapSize; i++)
                {
                    for (int j = 0; j < mapSize; j++)
                    {
                        Rectangle cellRect = new Rectangle(j * cellSize, i * cellSize, cellSize, cellSize);
                        g.FillRectangle(currentState[i, j] == 1 ? Brushes.Black : Brushes.White, cellRect);
                        g.DrawRectangle(Pens.Gray, cellRect);
                    }
                }
            }

            // Отображаем отрисованный на Bitmap на экране
            e.Graphics.DrawImage(bufferBitmap, bitmapX, bitmapY);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isPlaying)
            {
                isMouseDown = true;
                ToggleCell(e.X, e.Y);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
                ToggleCell(e.X, e.Y);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            oldRect = new Rectangle();
        }

        private void Clear_Click(object sender, EventArgs e) => ResizeMap();
    }
}