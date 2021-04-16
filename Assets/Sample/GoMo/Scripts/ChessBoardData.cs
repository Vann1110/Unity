/*棋盤資料*/
class ChessBoardData
{
    int index = 0;  // 棋子個數
    private int gridAmount = 15;
    // ChessType type = ChessType.Empty;
    private CellData[,] grid;
    // 建構子
    public ChessBoardData()
    {
        this.grid = new CellData[this.gridAmount, this.gridAmount];
        for (int i = 0; i < this.gridAmount; i++)
        {
            for (int j = 0; j < this.gridAmount; j++)
            {
                this.grid[i, j] = new CellData();
            }
        }
    }
    // 檢查該座標是否合法
    public bool checkValid(int x, int y)
    {
        // 超出邊界
        if (x < 0 || y < 0 || x > this.gridAmount || y > this.gridAmount)
        {
            return false;
        }
        // 已有棋子
        if (this.grid[x, y].hasChess())
        {
            return false;
        }
        return true;
    }
    public void setData(int x, int y, ChessType type)
    {
        this.index++;
        this.grid[x, y].setData(index, type);
    }
    public bool checkWin(int x, int y)
    {
        if (this.checkWin_a(x, y) || this.checkwin_d(x, y) || this.checkWin_b(x, y) || this.checkWin_c(x, y))
        {
            return true;
        }
        return false;
    }
    // 橫向檢查
    private bool checkWin_a(int x, int y)
    {
        ChessType curType = this.grid[x, y].getType();
        int count = 1;
        int i = x - 1;
        // 向左檢查是否為同色棋
        while (i > 0 && i >= x - 4 && this.grid[i, y].getType() == curType)
        {
            count += 1;
            i = i - 1;
        }
        // 向右檢查是否為同色棋
        if (count < 5)
        {
            i = x + 1;
            while (i < this.gridAmount && i <= x + 4 && this.grid[i, y].getType() == curType)
            {
                count += 1;
                i = i + 1;
            }
        }
        if (count >= 5)
        {
            return true;
        }

        return false;
    }
    // 直向檢查
    private bool checkWin_b(int x, int y)
    {
        ChessType curType = this.grid[x, y].getType();
        int count = 1;
        int i = y - 1;
        // 向下檢查
        while (i > 0 && i >= y - 4 && this.grid[x, i].getType() == curType)
        {
            count += 1;
            i = i - 1;
        }
        // 向上檢查
        if (count < 5)
        {
            i = y + 1;
            while (i < this.gridAmount && i <= y + 4 && this.grid[x, i].getType() == curType)
            {
                count += 1;
                i = i + 1;
            }
        }
        if (count >= 5)
        {
            return true;
        }
        return false;
    }
    // 左上右下檢查
    private bool checkWin_c(int x, int y)
    {
        ChessType curType = this.grid[x, y].getType();
        int count = 1;
        int i = x - 1;
        int j = y + 1;
        // 左上檢查
        while (i > 0 && i >= x - 4 && j < this.gridAmount && j <= y + 4 && this.grid[i, j].getType() == curType)
        {
            count++;
            i = i - 1;
            j = j + 1;
        }
        // 右下檢查
        if (count < 5)
        {
            i = x + 1;
            j = y - 1;
            while (i < this.gridAmount && i <= x + 4 && j > 0 && j >= y - 4 && this.grid[i, j].getType() == curType)
            {
                count++;
                i = i + 1;
                j = j - 1;
            }
        }
        if (count >= 5)
        {
            return true;
        }

        return false;
    }
    // 右上左下檢查
    private bool checkwin_d(int x, int y)
    {
        ChessType curType = this.grid[x, y].getType();
        int count = 1;
        int i = x + 1;
        int j = y + 1;
        // 右上檢查
        while (i < this.gridAmount && i <= x + 4 && j < this.gridAmount && j <= y + 4 && this.grid[i, j].getType() == curType)
        {
            count++;
            i++;
            j++;
        }
        // 左下檢查
        if (count < 5)
        {
            i = x - 1;
            j = y - 1;
            while (i > 0 && i >= x - 4 && j > 0 && j >= y - 4 && this.grid[i, j].getType() == curType)
            {
                count++;
                i--;
                j--;
            }
        }
        if (count >= 5)
        {
            return true;
        }
        return false;
    }
}
// 棋格資料
class CellData
{
    private ChessType type = ChessType.Empty;
    private int index = 0;
    public bool hasChess()
    {
        return this.type != ChessType.Empty;
    }
    public void setData(int index, ChessType type)
    {
        this.index = index;
        this.type = type;
    }
    public ChessType getType()
    {
        return this.type;
    }
}

enum ChessType
{
    Empty = 0,
    Black = 1,
    White = 2
}
