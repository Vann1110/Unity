using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [SerializeField]
    private Text display = null;
    private string initValue = "0";
    private int maxInputLength = 9;

    private string inputValue = "";
    private string op = "";
    private decimal calNum = 0;
    private bool hasDot = false;

    private void Start()
    {
        this.init();
    }
    private void init()
    {
        this.inputValue = "";
        this.op = "";
        this.calNum = 0;
        this.hasDot = false;
        this.display.text = this.initValue;
    }

    // btn event
    public void input(string value)
    {
        if (this.inputValue.Length >= this.maxInputLength)
        {
            return;
        }
        if (value == ".")
        {
            if (this.hasDot)
            {
                return;
            }
            else
            {
                // 直接输入"."
                if (string.IsNullOrEmpty(this.inputValue))
                {
                    this.inputValue = this.initValue;
                }
                this.hasDot = true;
            }
        }
        this.inputValue += value;
        this.display.text = this.convertToCurrency(decimal.Parse(this.inputValue));
    }

    public void setOperator(string op)
    {
        this.cal();
        this.op = op;
    }
    private void cal()
    {
        if (this.inputValue != "")
        {
            switch (this.op)
            {
                case "+":
                    this.calNum += decimal.Parse(this.inputValue);
                    break;
                case "-":
                    this.calNum -= decimal.Parse(this.inputValue);
                    break;
                case "x":
                    this.calNum *= decimal.Parse(this.inputValue);
                    break;
                case "/":
                    this.calNum /= decimal.Parse(this.inputValue);
                    break;
                default:
                    this.calNum = decimal.Parse(this.inputValue);
                    break;
            }
            this.inputValue = "";
            this.hasDot = false;
            this.display.text = this.convertToCurrency(this.calNum);
        }
    }
    private string convertToCurrency(decimal num)
    {
        int integer = (int)num;
        decimal floatNum = num - integer;
        string output = integer.ToString("N0") + floatNum.ToString().Remove(0, 1);
        return output;
    }
    public void clear()
    {
        this.init();
    }
}