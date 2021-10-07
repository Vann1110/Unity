using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class Main : MonoBehaviour
    {
        [SerializeField]
        public TicTacToe.UIManager uiManager = null;
        [SerializeField]
        public TicTacToe.GameBoard board = null;

        // 遊戲初始化
        private void Start()
        {
            this.board.start();
            this.uiManager.init();
            GameData.Inst.init();
            GameData.Inst.registerUI(this.uiManager);
        }

        void Update()
        {
            if (GameData.Inst.gameState == GameState.Loop)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 10, -1);
                    if (hit.collider)
                    {
                        //畫出射線
                        Debug.DrawLine(ray.origin, hit.point, Color.red, 0.1f, true);
                        this.board.playChess(hit.point.x, hit.point.y);
                    }
                }
            }
        }

        public void gameStart()
        {
            this.board.init();
            this.uiManager.gameStart();
            GameData.Inst.gameStart();
        }
    }
}
