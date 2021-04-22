using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class PlayerWindow : Window
{
    private GameObject npc;

    public PlayerWindow(GameObject npc)
    {
        this.npc = npc;
    }

    protected override void OnInit()
    {
        this.contentPane = UIPackage.CreateObject("07-PlayerView", "PlayerWindow").asCom;
        GGraph loader = this.contentPane.GetChild("n2").asGraph;
        RenderTexture renderTexture = Resources.Load<RenderTexture>("FGUI/07-PlayerView/PlayerRT");
        Material mat = Resources.Load<Material>("FGUI/07-PlayerView/PlayerMat");
        Image img = new Image();
        img.texture = new NTexture(renderTexture);
        img.material = mat;
        loader.SetNativeObject(img);
        this.contentPane.GetChild("n3").onClick.Add(() => { this.rotateLeft(); });
        this.contentPane.GetChild("n4").onClick.Add(() => { this.rotateRight();});
    }

    private void rotateLeft()
    {
        this.npc.transform.Rotate(Vector3.up * 30, Space.World);
    }
    private void rotateRight()
    {
        this.npc.transform.Rotate(Vector3.up * -30, Space.World);
    }
}
