using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeWork : MonoBehaviour
{
    public Text output = null;
    public Text maxOutput = null;

    public void btnClick()
    {
        string content = "I am coin master.";
        int index = UnityEngine.Random.Range(0, content.Length - 1);
        string str = this.cutString(content, index);
        Debug.Log("原字串:" + content);
        Debug.Log("index:" + index + " 字串分割:" + str);
    }

    public void getMaxBtn()
    {
        int num = UnityEngine.Random.Range(-1000, 1000);
        int maxNum = this.getMaxNumber(num);
        this.maxOutput.text = "最大值:" + maxNum;
    }

    private int getMaxNumber(int num)
    {
        int integer = Mathf.Abs(num);
        string insertNum = "5";
        string str = integer.ToString();
        int[] mergeAry = new int[str.Length + 1];
        string output = "";
        for (int i = 0; i <= str.Length; i++)
        {
            string temp = str.Insert(i, insertNum);
            if (num < 0)
            {
                temp = "-" + temp;
            }
            mergeAry[i] = int.Parse(temp);
            output += mergeAry[i] + " ";
        }
        Array.Sort(mergeAry);
        this.output.text = "原數值:" + num + " | " + output;
        return mergeAry[mergeAry.Length - 1];
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
