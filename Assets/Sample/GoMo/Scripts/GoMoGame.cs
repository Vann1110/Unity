using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoMoGame : MonoBehaviour
{
    public ChessBoard chessBoard;

    void Start()
    {
        this.chessBoard.init();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 10, -1);
            if (hit.collider)
            {
                //畫出射線
                Debug.DrawLine(ray.origin, hit.transform.position, Color.red, 0.1f, true);
                this.chessBoard.playChess(hit.point.x, hit.point.y);
            }
        }
    }
}

enum GameStatus
{
    Playing,    // 遊戲中
    End     // 遊戲結束
}