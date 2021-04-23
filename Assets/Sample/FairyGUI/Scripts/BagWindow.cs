using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class BagListWindow : Window
{
    private GList list;
    private GButton playerView;

    public BagListWindow(GButton targetBtn)
    {
        this.playerView = targetBtn;
    }

    protected override void OnInit()
    {
        this.contentPane = UIPackage.CreateObject("08-Bag", "BagWindow").asCom;
        this.list = this.contentPane.GetChild("itemList").asList;
        this.list.itemRenderer = this.renderItemList;
        this.list.numItems = 20;
        for (int i = 0; i < 10; i++)
        {
            GButton button = this.list.GetChildAt(i).asButton;
            button.onClick.Add(() =>
            {
                this.itemCLick(button);
            });
        }
    }

    private void renderItemList(int index, GObject obj)
    {
        GButton button = obj.asButton;
        button.icon = UIPackage.GetItemURL("08-Bag", "i" + index);
        button.title = index.ToString();
    }

    private void itemCLick(GButton btn)
    {
        this.playerView.title = btn.title;
        this.playerView.icon = btn.icon;
    }
}
