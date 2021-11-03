using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPanel : MonoBehaviour
{
    public Text playerDecision = null;
    public Button confirm = null;
    public int type { get; private set; }

    public void init()
    {
        this.playerDecision.text = "請選擇";
        this.hideConfirm();
    }

    public void playerInput(int type)
    {
        this.type = type;
        this.playerDecision.text = PSS.Function.GetTypeName(type);
        this.showConfirm();
    }

    public void showConfirm()
    {
        this.confirm.gameObject.SetActive(true);
    }

    public void hideConfirm()
    {
        this.confirm.gameObject.SetActive(false);
    }
}
