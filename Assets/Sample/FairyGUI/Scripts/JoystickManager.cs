using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class JoystickManager : MonoBehaviour
{
    private GComponent mainUI;
    private GTextField gTextField;
    private Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        this.mainUI = this.GetComponent<UIPanel>().ui;
        this.gTextField = this.mainUI.GetChild("n4").asTextField;
        this.joystick = new Joystick(this.mainUI);
        this.joystick.onMove.Add(this.joystickMove);
        this.joystick.onEnd.Add(this.joystickEnd);
    }
    
    private void joystickMove(EventContext context)
    {
        float degree = (float)context.data;
        this.gTextField.text = degree.ToString();
    }
    private void joystickEnd()
    {
        this.gTextField.text = "";
    }
}
