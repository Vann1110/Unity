using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using DG.Tweening;

public class FairyGUITest_02 : MonoBehaviour
{
    private GComponent mainUI;
    private GComponent addValueCom;
    private float startValue;
    private float targetValue;

    // Start is called before the first frame update
    void Start()
    {
        this.mainUI = this.GetComponent<UIPanel>().ui;
        this.addValueCom = UIPackage.CreateObject("Package1", "AddAnim").asCom;
        this.addValueCom.GetTransition("t0").SetHook("AddValue", this.addAttackValue);
        this.mainUI.GetChild("n0").onClick.Add(() => { this.playUI(this.addValueCom); });
    }

    private void playUI(GComponent target)
    {
        this.mainUI.GetChild("n0").visible = false;
        GRoot.inst.AddChild(target);
        Transition t = target.GetTransition("t0");
        this.startValue = 10000;
        int add = Random.Range(1000, 3000);
        this.targetValue = this.startValue + add;
        target.GetChild("n4").text = this.startValue.ToString();
        target.GetChild("n5").text = "+" +add.ToString();
        t.Play(() =>
        {
            this.mainUI.GetChild("n0").visible = true;
             GRoot.inst.RemoveChild(target);
        });
    }

    private void addAttackValue()
    {
        DOTween.To(() => this.startValue, x => { this.addValueCom.GetChild("n4").text = Mathf.Floor(x).ToString(); }, this.targetValue, 0.3f).SetEase(Ease.Linear).SetUpdate(true);
    }
}
