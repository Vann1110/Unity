using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class FairyGUITest : MonoBehaviour
{
    private GComponent mainUI;
    private GComponent effect;
    private GGroup group;

    // Start is called before the first frame update
    void Start()
    {
        this.mainUI = this.GetComponent<UIPanel>().ui;
        this.effect = UIPackage.CreateObject("Package1", "Boss").asCom;
        this.mainUI.GetChild("n3").onClick.Add(() => { this.playUI(this.effect); });
        this.group = this.mainUI.GetChild("n2").asGroup;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void playUI(GComponent target)
    {
        this.group.visible = false;
        GRoot.inst.AddChild(target);
        Transition t = target.GetTransition("t0");
        t.Play(() =>
        {
            this.group.visible = true;
            GRoot.inst.RemoveChild(target);
        });
    }

}
