using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class PlayerView : MonoBehaviour
{
    private GComponent mainUI;
    private PlayerWindow playerWindow;
    public GameObject npc;

    // Start is called before the first frame update
    void Start()
    {
        this.mainUI = this.GetComponent<UIPanel>().ui;
        this.playerWindow = new PlayerWindow(this.npc);
        this.mainUI.GetChild("n0").onClick.Add(() => { this.playerWindow.Show(); });
    }
}
