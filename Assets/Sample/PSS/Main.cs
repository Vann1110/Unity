using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PSS
{
    public class Main : MonoBehaviour
    {
        private Computer c1 = new Computer();
        private Computer c2 = new Computer();
        private Judge judge = new Judge();
        void Start()
        {
            for (int i = 0; i < 10; i++)
            {
                int p1 = c1.action();
                int p2 = c2.action();
                this.judge.checkWin(p1, p2);
            }
        }
    }
    // 電腦類別
    public class Computer
    {
        // 隨機出拳
        public int action()
        {
            return Random.Range(1, 4);
        }
    }
    // 裁判類別
    public class Judge
    {
        //1剪刀  2石頭 3布
        public void checkWin(int p1, int p2)
        {
            string output = "玩家A:" + (GuessingType)p1 + " 玩家B:" + (GuessingType)p2;
            string result = "";
            // 只計算玩家A出剪刀、石頭、布 贏的情況
            if (p1 - p2 == -2 || p1 - p2 == 1)
            {
                result = "=>玩家A勝利!";
            }
            else if (p1 == p2)
            {
                result = "=>平局";
            }
            else
            {
                result = "=>玩家A失敗!";
            }
            Debug.Log(output + result);
        }
    }

    enum GuessingType
    {
        Siccors = 1,
        Rock = 2,
        Paper = 3
    }
}