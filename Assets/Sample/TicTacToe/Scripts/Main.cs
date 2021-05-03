using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class Main : MonoBehaviour
    {
        public TicTacToe.GameBoard board = null;

        // Start is called before the first frame update
        void Start()
        {
            this.board.init();
        }

        // Update is called once per frame
        void Update()
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
}
