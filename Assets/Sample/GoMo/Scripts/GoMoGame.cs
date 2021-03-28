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
}
