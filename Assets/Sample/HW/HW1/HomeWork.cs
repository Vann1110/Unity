using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeWork : MonoBehaviour
{
    private string content = "Thorough summaries and insightful critical analyses of classic and contemporary literature. Our most popular guides include quick quizzes, so you can test your retention before the test.";

    public void stringCut()
    {
        int index = Random.Range(0, this.content.Length);
        string str = "";
        // 如果擷取位置超過字串長度 回傳整個字串
        if (index >= this.content.Length)
        {
            str = this.content;
        }
        else
        {
            // 若該位置為空格或"." 直接回傳整個字串
            if (this.content[index] == ' ' || this.content[index] == '.')
            {
                str = this.content.Substring(0, index + 1);
            }
            else
            {
                // 向前檢查 直到字元為空格 或 "."
                for (int i = index; i >= 0; i--)
                {
                    if (this.content[i] == ' ' || this.content[i] == '.')
                    {
                        str = this.content.Substring(0, i);
                        break;
                    }
                }
            }
        }
        Debug.Log("原字串:" + this.content);
        Debug.Log("index:" + index + " 字串分割:" + str);
    }
}
