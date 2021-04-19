using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class FairyGUITest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GRoot.inst.SetContentScaleFactor(800, 600);
        UIPackage.AddPackage("FGUI/Package1");
        GComponent component = UIPackage.CreateObject("Package1", "Component2").asCom;
        GRoot.inst.AddChild(component);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
