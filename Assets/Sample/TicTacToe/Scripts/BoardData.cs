using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    // 棋盤資料
    public class BoardData
    {
        private int gridAmount = 3; // 格子3x3
        private CellData[,] grid = null;   // 二維陣列
        private float slashSlope = 1;   //斜線斜率

        // 建構子
        public BoardData()
        {
            this.grid = new CellData[this.gridAmount, this.gridAmount];
            // 二維陣列初始
            for (int i = 0; i < this.gridAmount; i++)
            {
                for (int j = 0; j < this.gridAmount; j++)
                {
                    this.grid[i, j] = new CellData();
                }
            }
        }

        public void setData(int x, int y, ChessType type)
        {
            this.grid[x, y].setData(type);
        }

        // 檢查是否合法
        public bool checkValid(int x, int y)
        {
            // 超出邊界
            if (x < 0 || y < 0)
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

        // 檢查輸贏
        public bool checkWin(int x, int y)
        {
            CellData cell = this.grid[x, y];
            int count = 0;
            // 橫向檢查 x:0~2
            for (int i = 0; i < 3; i++)
            {
                if (cell.type != this.grid[i, y].type)
                {
                    break;
                }
                else
                {
                    count++;
                }
            }
            if (count == 3)
            {
                Debug.Log("橫向");
                return true;
            }
            count = 0;
            // 直向檢查 y:0~2
            for (int i = 0; i < 3; i++)
            {
                if (cell.type != this.grid[x, i].type)
                {
                    break;
                }
                else
                {
                    count++;
                }
            }
            if (count == 3)
            {
                Debug.Log("直向");
                return true;
            }
            count = 0;
            // 左上右下 斜向檢查
            if (getSlope(new Vector2(0, 0), new Vector2(x, y)) == this.slashSlope)
            {
                if (this.grid[0, 0].type == cell.type)
                {
                    count++;
                }
                if (this.grid[1, 1].type == cell.type)
                {
                    count++;
                }
                if (this.grid[2, 2].type == cell.type)
                {
                    count++;
                }
                if (count == 3)
                {
                    Debug.Log("斜向");
                    return true;
                }
            }
            count = 0;
            // 右上左下 斜向檢查
            if (getSlope(new Vector2(0, 2), new Vector2(x, y)) == -this.slashSlope)
            {
                if (this.grid[0, 2].type == cell.type)
                {
                    count++;
                }
                if (this.grid[1, 1].type == cell.type)
                {
                    count++;
                }
                if (this.grid[2, 0].type == cell.type)
                {
                    count++;
                }
                if (count == 3)
                {
                    Debug.Log("斜向");
                    return true;
                }
            }
            return false;
        }
        // 斜率計算
        private float getSlope(Vector2 a, Vector2 b)
        {
            return (b.y - a.y) / (b.x - a.x);
        }
    }

    public class CellData
    {
        private ChessType _type = ChessType.Empty;
        public ChessType type
        {
            get { return this._type; }
            private set
            {
                this._type = ChessType.Empty;
            }
        }
        // 是否為空格
        public bool hasChess()
        {
            return this._type != ChessType.Empty;
        }
        public void setData(ChessType type)
        {
            this._type = type;
        }
    }

    public enum ChessType
    {
        Empty,  // 空格
        Black, // 黑棋
        White   // 白棋
    }
}
