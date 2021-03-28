using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    public Transform start = null;
    public Transform end = null;
    public GameObject blackChess = null;
    public GameObject whiteChess = null;
    public Transform chessPool = null;

    private int gridAmount = 15;    //格子數
    public float gridLength = 0;   //格子長度
    private RaycastHit hit;
    private GridData[,] grid;
    private int chessIndex = 0;     //棋子數量
    private ChessType curType = ChessType.Empty;      //當前棋子類型

    private void Start()
    {
        this.gridLength = Vector2.Distance(start.position, end.position);
        this.init();
    }

    public void init()
    {
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
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                int x = Mathf.RoundToInt((hit.point.x - this.start.position.x) / this.gridLength);
                int y = Mathf.RoundToInt((hit.point.y - this.start.position.y) / this.gridLength);
                if (checkValid(x, y))
                {
                    this.playChess(x, y);
                    this.checkWin_a(x, y);
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
        Vector3 pos = this.start.position + new Vector3(x * this.gridLength, y * this.gridLength, -1);
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