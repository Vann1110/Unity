using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    public Transform start = null;
    public Transform end = null;
    public Transform chessPool = null;
    public Transform[] x_anchor = null;
    public Transform[] y_anchor = null;
    public GameObject blackChess = null;
    public GameObject whiteChess = null;

    private int gridAmount = 15;    //格子數
    private float gridLength = 0;   //格子長度
    private RaycastHit hit;
    private GridData[,] grid;
    private int chessIndex = 0;     //棋子數量
    private ChessType curType = ChessType.Empty;      //當前棋子類型

    public void init()
    {
        this.gridLength = Vector2.Distance(start.position, end.position);
        this.curType = ChessType.Black; //黑先
        this.chessIndex = 0;
        this.grid = new GridData[this.gridAmount, this.gridAmount];
        for (int i = 0; i < this.gridAmount; i++)
        {
            for (int j = 0; j < this.gridAmount; j++)
            {
                this.grid[i, j] = new GridData();
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 10, -1);
            if (hit.collider)
            {
                //畫出射線
                Debug.DrawLine(ray.origin, hit.transform.position, Color.red, 0.1f, true);
                int x = Mathf.RoundToInt((hit.point.x - this.start.position.x) / this.gridLength);
                int y = Mathf.RoundToInt((hit.point.y - this.start.position.y) / this.gridLength);
                //檢查該陣列是否可下
                if (checkValid(x, y))
                {
                    this.playChess(x, y);
                    if (this.checkWin_a(x, y))
                    {
                        return;
                    }
                    if (this.checkWin_b(x, y))
                    {
                        return;
                    }
                    if (this.checkWin_c(x, y))
                    {
                        return;
                    }
                    if (this.checkwin_d(x, y))
                    {
                        return;
                    }
                }
            }
        }
    }
    private bool checkValid(int x, int y)
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
    private void playChess(int x, int y)
    {
        this.chessIndex++;
        this.grid[x, y].setData(this.chessIndex, this.curType);
        Vector3 pos = new Vector3(this.x_anchor[x].position.x, this.y_anchor[y].position.y, -1);
        if (this.curType == ChessType.Black)
        {
            Instantiate(this.blackChess, pos, Quaternion.identity).transform.parent = this.chessPool;
            this.curType = ChessType.White;
        }
        else
        {
            Instantiate(this.whiteChess, pos, Quaternion.identity).transform.parent = this.chessPool;
            this.curType = ChessType.Black;
        }
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
            Debug.Log(curType + "  WIN!!!");
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
            Debug.Log(curType + "  WIN!!!");
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
            Debug.Log(curType + "  WIN!!!");
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
            Debug.Log(curType + "  WIN!!!");
            return true;
        }
        return false;
    }
}

class GridData
{
    int index = 0;
    ChessType type = ChessType.Empty;
    public void setData(int index, ChessType type)
    {
        this.index = index;
        this.type = type;
    }
    public bool hasChess()
    {
        return this.type != ChessType.Empty;
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