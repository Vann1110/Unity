using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe
{
    public class ControlPanel : MonoBehaviour
    {
        [SerializeField]
        private GameObject start = null;
        [SerializeField]
        private GameObject restart = null;
        [SerializeField]
        private Text result = null;
        [SerializeField]
        private Image bg = null;

        private GameData data = GameData.Inst;

        public void init()
        {
            this.result.text = "";
            this.restart.SetActive(false);
        }

        public void gameStart()
        {
            this.start.SetActive(false);
            this.hide();
        }

        public void showRestart(string result)
        {
            this.show();
            this.restart.SetActive(true);
            this.result.text = result;
        }

        private void show()
        {
            this.gameObject.SetActive(true);
        }

        private void hide()
        {
            this.gameObject.SetActive(false);
        }
    }
}
