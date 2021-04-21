using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class FairyGUILoopList : MonoBehaviour
{
    private GComponent mainUI;
    private GList list;
    // Start is called before the first frame update
    void Start()
    {
        this.mainUI = this.GetComponent<UIPanel>().ui;
        this.list = this.mainUI.GetChild("n0").asList;
        this.list.SetVirtualAndLoop();
        this.list.itemRenderer = this.renderListItem;
        this.list.numItems = 5;
    }

    private void renderListItem(int index, GObject obj)
    {
        GButton btn = obj.asButton;
        Debug.Log(index);
        btn.icon = UIPackage.GetItemURL("LoopListPack", "n" + (index + 1));
    }
}
