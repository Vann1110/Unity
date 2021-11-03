using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.ComponentModel;

namespace PSS
{
    public class Main : MonoBehaviour
    {
        private Computer c1 = new Computer();   //電腦
        private Judge judge = new Judge();      //裁判
        public PlayerPanel playerPanel = null;  //玩家UI
        public Text computerDecision = null;    //電腦出拳
        public Text result = null;              //輸贏結果

        private void Start()
        {
            this.playerPanel.init();
        }

        // 判輸贏
        public void checkResult()
        {
            int c1_type = this.c1.action(); //電腦出拳
            this.computerDecision.text = PSS.Function.GetTypeName(c1_type);     //顯示電腦的出拳
            string result = this.judge.checkWin(this.playerPanel.type, c1_type);//判斷輸贏
            this.result.text = result;
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
        public string checkWin(int p1, int p2)
        {
            string result = "";
            // 只計算玩家A出剪刀、石頭、布 贏的情況
            if (p1 - p2 == -2 || p1 - p2 == 1)
            {
                result = "玩家勝利!";
            }
            else if (p1 == p2)
            {
                result = "平局";
            }
            else
            {
                result = "玩家失敗!";
            }
            return result;
        }
    }

    public enum GuessingType
    {
        Siccors = 1,
        Rock = 2,
        Paper = 3
    }

    // 靜態類別  任何地方都可存取
    public static class Function
    {
        // 將type 轉換為 字串
        public static string GetTypeName(int type)
        {
            switch ((PSS.GuessingType)type)
            {
                case PSS.GuessingType.Siccors:
                    return "剪刀";
                case PSS.GuessingType.Rock:
                    return "石頭";
                case PSS.GuessingType.Paper:
                    return "布";
                default:
                    return "";
            }
        }
    }
}