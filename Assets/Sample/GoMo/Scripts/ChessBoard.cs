using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    public Transform start = null;  // 棋盤原點
    public Transform end = null;    // 格子間隔
    public Transform chessPool = null;  // 棋子池
    public Transform[] x_anchor = null; // x軸定位點
    public Transform[] y_anchor = null; // y軸定位點
    public GameObject blackChess = null;// 黑棋prefab
    public GameObject whiteChess = null;// 白棋prefab

    private float gridLength = 0;   //格子長度
    private ChessType curType = ChessType.Empty;      //當前棋子類型
    private float threshold = 0;    //棋子需小於值才可下

    private ChessBoardData chessBoardData;  // 棋盤資料
    // 初始
    public void init()
    {
        this.gridLength = Vector2.Distance(start.position, end.position);
        this.threshold = this.gridLength / 3;
        this.chessBoardData = new ChessBoardData();  // 棋盤資料
        this.curType = ChessType.Black; //黑先
    }
    public void reset()
    {
        this.init();
        for (int i = 0; i < this.chessPool.childCount; i++)
        {
            GameObject obj = this.chessPool.GetChild(i).gameObject;
            Destroy(obj);
        }
    }
    // 執行下棋
    public void playChess(float _x, float _y)
    {
        int x = this.getXNearestPoint(_x);
        int y = this.getYNearestPoint(_y);
        // 檢查該格是否合法
        if (this.chessBoardData.checkValid(x, y))
        {
            // 放置棋子
            this.dropChess(x, y);
            // 設置格子資料
            this.chessBoardData.setData(x, y, this.curType);
            // 檢查輸贏
            this.chessBoardData.checkWin(x, y);
        }
    }
    // 放置棋子
    private void dropChess(int x, int y)
    {
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
    // 取得x軸最接近之定位點
    private int getXNearestPoint(float x)
    {
        for (int i = 0; i < this.x_anchor.Length; i++)
        {
            if (Mathf.Abs(x - this.x_anchor[i].position.x) < this.threshold)
            {
                return i;
            }
        }
        return -1;
    }
    // 取得y軸最接近之定位點
    private int getYNearestPoint(float x)
    {
        for (int i = 0; i < this.y_anchor.Length; i++)
        {
            if (Mathf.Abs(x - this.y_anchor[i].position.y) < this.threshold)
            {
                return i;
            }
        }
        return -1;
    }
}