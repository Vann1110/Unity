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
        this.list.scrollPane.onScroll.Add(this.zoomEffect);
        this.zoomEffect();
    }

    private void zoomEffect()
    {
        float listCenter = this.list.scrollPane.posX + this.list.viewWidth / 2;
        // 當前渲染之物件
        for (int i = 0; i < list.numChildren; i++)
        {
            GObject item = this.list.GetChildAt(i);
            float itemCenter = item.x + item.width / 2;
            float itemWidth = item.width;
            float dist = Mathf.Abs(listCenter - itemCenter);
            if (dist < itemWidth)
            {
                float distRange = 1 + (1 - dist / itemWidth) * 0.2f;
                item.SetScale(distRange, distRange);
            }
            else
            {
                item.SetScale(1, 1);
            }
        }
    }

    private void renderListItem(int index, GObject obj)
    {
        GButton btn = obj.asButton;
        btn.SetPivot(0.5f, 0.5f);
        btn.icon = UIPackage.GetItemURL("LoopListPack", "n" + (index + 1));
    }
}
