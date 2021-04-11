using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetMaxNum : MonoBehaviour
{
    public Text display = null;
    public Text output = null;

    public void btnClick()
    {
        int num = UnityEngine.Random.Range(-1000, 1000);
        int maxNum = this.getMaxNumber(num);
        this.output.text = "最大值:" + maxNum;
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
            if(num < 0){
                temp = "-" + temp;
            }
            
            mergeAry[i] = int.Parse(temp);
            output += mergeAry[i] + ",";
        }

        Array.Sort(mergeAry);
        this.display.text = "原數值:" + num + " | " + output;
        return mergeAry[mergeAry.Length - 1];
    }
}
