using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeWork : MonoBehaviour
{
    private int index = 0;
    public void btnClick()
    {
        string content = "I am coin master.";
        string str = this.cutString(content);
        Debug.Log("原字串:" + content);
        Debug.Log("index:" + this.index + " 字串分割:" + str);
    }

    private string cutString(string str)
    {
        this.index = Random.Range(0, str.Length - 1);

        // 如果擷取位置超過字串長度 回傳整個字串
        if (this.index == str.Length - 1 || str[this.index] == ' ' || str[this.index] == '.' || str[this.index] == ',')
        {
            return str.Substring(0, this.index);
        }
        else
        {
            // 向前檢查 直到字元為空格 或 "."
            for (int i = index - 1; i >= 0; i--)
            {
                if (str[i] == ' ' || str[i] == '.' || str[i] == ',')
                {
                    return str.Substring(0, i);
                }
            }
            return "无字段可截取";
        }
    }
}
