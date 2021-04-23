using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class BagManager : MonoBehaviour
{
    private GComponent mainUI;
    private GButton playerView;
    private BagListWindow bagListWindow;
    // private 
    // Start is called before the first frame update
    void Start()
    {
        this.mainUI = this.GetComponent<UIPanel>().ui;
        this.playerView = this.mainUI.GetChild("playerView").asButton;
        this.playerView.onClick.Add(this.userItem);
        this.bagListWindow = new BagListWindow(this.playerView);
        this.bagListWindow.SetXY(121, 63);
        this.mainUI.GetChild("bagButton").onClick.Add(() =>
        {
            this.bagListWindow.Show();
        });
    }

    private void userItem()
    {
        this.playerView.icon = null;
        this.playerView.title = "空白";
    }
}
