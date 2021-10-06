using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class BoardData
    {
        private int gridAmount = 3; // 格子3x3
        private CellData[,] grid = null;   // 二維陣列

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

        public bool checkWin(int x, int y)
        {
            CellData cell = this.grid[x, y];
            // 順時鐘搜尋 擴展兩格
            // 向上
            int count = 0;
            for (int i = y + 1; i < this.gridAmount; i++)
            {
                if (cell.getType() != this.grid[x, i].getType())
                {
                    Debug.Log("test");
                    break;
                }
                else
                {
                    count++;
                }
            }
            if (count == 2)
            {
                return true;
            }
            return false;
        }
    }

    public class CellData
    {
        private ChessType type = ChessType.Empty;
        // 是否為空格
        public bool hasChess()
        {
            return this.type != ChessType.Empty;
        }
        public void setData(ChessType type)
        {
            this.type = type;
        }
        public ChessType getType()
        {
            return this.type;
        }
    }

    public enum ChessType
    {
        Empty,  // 空格
        Black, // 黑棋
        White   // 白棋
    }
}
