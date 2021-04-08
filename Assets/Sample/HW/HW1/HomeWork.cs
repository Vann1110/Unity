using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeWork : MonoBehaviour
{
    public void btnClick()
    {
        string content = "I am coin master.";
        int index = Random.Range(0, content.Length - 1);
        string str = this.cutString(content, index);
        Debug.Log("原字串:" + content);
        Debug.Log("index:" + index + " 字串分割:" + str);
    }

    private string cutString(string str, int index)
    {
        // 如果擷取位置超過字串長度 回傳整個字串
        if (index == str.Length - 1 || str[index] == ' ' || str[index] == '.' || str[index] == ',')
        {
            return str.Substring(0, index);
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
