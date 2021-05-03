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
