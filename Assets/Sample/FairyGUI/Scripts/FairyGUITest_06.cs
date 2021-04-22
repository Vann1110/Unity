using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using System;

public class FairyGUITest_06 : MonoBehaviour
{
    private GComponent mainUI;
    private GProgressBar progressBar;
    private GComboBox comboBox;

    // Start is called before the first frame update
    void Start()
    {
        this.mainUI = this.GetComponent<UIPanel>().ui;
        this.progressBar = this.mainUI.GetChild("n0").asProgress;
        this.progressBar.value = 0;
        this.progressBar.TweenValue(100, 5);
        this.comboBox = this.mainUI.GetChild("n2").asComboBox;
        this.comboBox.onChanged.Add(this.setCompleteTime);
    }

    private void setCompleteTime()
    {
        this.progressBar.value = 0;
        this.progressBar.TweenValue(100, Convert.ToInt32(this.comboBox.value));
    }
}
