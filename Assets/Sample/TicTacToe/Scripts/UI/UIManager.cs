using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        public ControlPanel controlPanel = null;
        [SerializeField]
        public TopPanel topPanel = null;

        public void init()
        {
            this.controlPanel.init();
            this.topPanel.init();
        }

        public void gameStart()
        {
            this.controlPanel.gameStart();
        }
    }
}
