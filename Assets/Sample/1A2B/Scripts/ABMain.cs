using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ABMain : MonoBehaviour
{
    [SerializeField]
    private Text quizOutput = null;

    void Start() { }

    public void smartRandom()
    {
        List<int> numbers = new List<int>();
        for (int i = 0; i < 10; i++)
        {
            numbers.Add(i);
        }

        List<int> quiz = new List<int>();
        for (int i = 0; i < 4; i++)
        {
            int index = Random.Range(0, numbers.Count);
            quiz.Add(numbers[index]);
            numbers.RemoveAt(index);
        }

        string quizStr = "";
        for (int i = 0; i < quiz.Count; i++)
        {
            string comma = "";
            if (i < quiz.Count - 1)
            {
                comma = ",";
            }
            quizStr += quiz[i].ToString() + comma;
        }
        this.quizOutput.text = quizStr;
    }

    private void violateRandom()
    {
        int[] ary = new int[4];
        int index = 0;
        while (index < 4)
        {
            int a = Random.Range(0, 10);
            bool isRepeat = false;
            for (int i = 0; i < ary.Length; i++)
            {
                if (ary[i] == a)
                {
                    isRepeat = true;
                    break;
                }
            }
            if (!isRepeat)
            {
                ary[index] = a;
                index++;
                Debug.Log(a);
            }
        }
    }
}
