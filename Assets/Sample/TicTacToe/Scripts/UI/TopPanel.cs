using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe
{
    public class TopPanel : MonoBehaviour
    {
        [SerializeField]
        private Text gameSet = null;    //遊戲局數
        [SerializeField]
        private Text blackWins = null;  //黑棋贏局數
        [SerializeField]
        private Text whiteWins = null;  //白棋贏局數

        private GameData data = GameData.Inst;

        public void init()
        {
            this.updateInfo();
        }

        public void updateInfo()
        {
            this.gameSet.text = string.Format("第{0}局", this.data.gameSet.ToString());
            this.blackWins.text = string.Format("贏{0}局", this.data.blackWins.ToString());
            this.whiteWins.text = string.Format("贏{0}局", this.data.whiteWins.ToString());
        }
    }
}
