using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe
{
    // 棋盤實體
    public class GameBoard : MonoBehaviour
    {
        [SerializeField]
        private Sprite black = null;
        [SerializeField]
        private Sprite white = null;
        [SerializeField]
        private Transform[] xPoints = null;
        [SerializeField]
        private Transform[] yPoints = null;
        [SerializeField]
        private GameObject chessPrefab = null;
        [SerializeField]
        private Transform objPool = null;

        private float threshold = 1.5f; //棋子與定位點需小於該值才可下

        private BoardData boardData = null;  //棋盤資料
        private ChessType curType = TicTacToe.ChessType.Empty;    // 當前棋子類型

        private int chessCount = 0; //棋子個數

        public void start()
        {
            foreach (Transform point in this.xPoints)
            {
                point.gameObject.SetActive(false);
            }
            foreach (Transform point in this.yPoints)
            {
                point.gameObject.SetActive(false);
            }
        }

        // 棋盤初始
        public void init()
        {
            this.chessCount = 0;
            this.boardData = new BoardData();
            this.curType = TicTacToe.ChessType.Black;  //黑先
            // 清除棋盤
            foreach (Transform obj in this.objPool.transform)
            {
                GameObject.Destroy(obj.gameObject);
            }
        }

        // 執行下棋
        public void playChess(float _x, float _y)
        {
            int x = this.getXNearestPoint(_x);
            int y = this.getYNearestPoint(_y);
            if (this.boardData.checkValid(x, y))
            {
                this.dropChess(x, y);
                // 設置格子資料
                this.boardData.setData(x, y, this.curType);
                // 檢查輸贏
                if (this.boardData.checkWin(x, y))
                {
                    if (this.curType == ChessType.Black)
                    {
                        // 重新開始
                        Debug.Log(this.curType + " a 贏了!!!");
                        GameData.Inst.setBlackWin();
                    }
                    else
                    {
                        // 重新開始
                        Debug.Log(this.curType + " b 贏了!!!");
                        GameData.Inst.setWhiteWin();
                    }
                }
                else
                {
                    // 切換回合
                    if (this.curType == ChessType.Black)
                    {
                        this.curType = ChessType.White;
                    }
                    else
                    {
                        this.curType = ChessType.Black;
                    }
                }
                this.chessCount++;
                if (this.chessCount == 9)
                {
                    GameData.Inst.setDraw();
                }
                Debug.Log("x:" + x + " " + "y" + y);
            }
        }

        // 放置棋子
        private void dropChess(int x, int y)
        {
            Vector3 pos = new Vector3(this.xPoints[x].position.x, this.yPoints[y].position.y, -1);
            GameObject obj = Instantiate(this.chessPrefab, pos, Quaternion.identity);
            obj.transform.parent = this.objPool;
            if (this.curType == ChessType.Black)
            {
                obj.GetComponent<SpriteRenderer>().sprite = this.black;
            }
            else
            {
                obj.GetComponent<SpriteRenderer>().sprite = this.white;
            }
        }

        // x座標定位
        private int getXNearestPoint(float _x)
        {
            for (int i = 0; i < this.xPoints.Length; i++)
            {
                if (Mathf.Abs(_x - this.xPoints[i].position.x) < this.threshold)
                {
                    return i;
                }
            }
            return -1;
        }

        // y座標定位
        private int getYNearestPoint(float _y)
        {
            for (int i = 0; i < this.yPoints.Length; i++)
            {
                if (Mathf.Abs(_y - this.yPoints[i].position.y) < this.threshold)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
