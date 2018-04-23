using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public delegate void invoker(string msg);

    public enum State
    {
        Zero,
        AccumulateDigits,
        AccumulateDigitsWithDecimal,
        ComputeWithPending,
        ComputeNoPending,
        ShowError
    }

    class Brain //FSM for standart calculator
    {
        public invoker invoker;

        string first;   //first number
        string second;  //second number
        string current; //current number
        string result;  //result number
        string op;      //last operation
        string save;    //saved number

        bool isResult;  //is result computed or not
        bool isDecimal; //is current end to ',' or not
        bool isFirst;   //is first operation or not
        bool isPercent; //is multiplication of numbers decimal or not
        bool isSecond;  //is second number equal to some nonzero or not

        State state;    //current state

        string[] all = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" }; //all numbers
        string[] nonzero = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };  //all nonzero numbers
        string[] zero = { "0" };                                             //single zero
        string[] equal = { "=" };                                            //equal
        string[] operations = { "+", "—", "×", "/" };                        //standart operations
        string[] functions = { "√", "x²", "1/x" };                           //current number fucntions
        string[] percent = { "%" };                                          //percent
        string[] reverse = { "±" };                                          //plus-minus
        string[] clear = { "С" };                                            //clear all
        string[] cleare = { "CE" };                                          //clear current
        string[] backspace = { "⌫" };                                       //clear last digit
        string[] separator = { "·" };                                        //decimal separator
        string[] memory = { "MC", "MR", "M+", "M-", "MS" };                  //memory options

        public Brain() => SetStart(); //constructor

        public void Process(string msg) //main function for porocessing
        {
            switch (state)
            {
                case State.Zero:
                    Zero(false, msg);
                    break;

                case State.AccumulateDigits:
                    AccumulateDigits(false, msg);
                    break;

                case State.AccumulateDigitsWithDecimal:
                    AccumulateDigitsWithDecimal(false, msg);
                    break;

                case State.ComputeNoPending:
                    ComputeNoPending(false, msg);
                    break;

                case State.ComputeWithPending:
                    ComputeWithPending(false, msg);
                    break;

                case State.ShowError:
                    ShowError(false, msg);
                    break;
            }
        }

        private void Zero(bool isInput, string msg)
        {
            if (isInput)
            {
                SetStart();

                invoker.Invoke(current);
                state = State.Zero;
            }

            else
            {
                if (nonzero.Contains(msg))
                    AccumulateDigits(true, msg);

                else if (separator.Contains(msg))
                    AccumulateDigitsWithDecimal(true, msg);

                else if (msg == "1/x")
                    ShowError(true, msg);
            }
        }

        private void AccumulateDigits(bool isInput, string msg)
        {
            if (isInput)
            {
                CheckMemory(msg);

                CheckPercent();

                if (isResult)
                {
                    first = "0";
                    second = "0";
                    current = msg;
                    result = "0";
                    op = ";";
                    isFirst = true;
                    isSecond = false;
                    isResult = false;
                }

                else if (cleare.Contains(msg))
                {
                    current = "0";

                    if (first != "0")
                        second = "0";

                    else
                        first = "0";
                }

                else if (backspace.Contains(msg))
                    current = current.Remove(current.Length - 1);

                else if (reverse.Contains(msg))
                    current = (double.Parse(current, NumberStyles.Number) * (-1)).ToString();

                else if (percent.Contains(msg))
                {
                    if (isSecond)
                        current = (double.Parse(first) * double.Parse(current) / 100).ToString();

                    else
                        current = (double.Parse(first) * double.Parse(first) / 100).ToString();
                }

                else if (nonzero.Contains(msg))
                {
                    if (current == "0")
                        current = msg;

                    else
                        current = current + msg;
                }

                if (current == "" || current == "-")
                    current = "0";

                invoker.Invoke(current);
                state = State.AccumulateDigits;
            }

            else
            {
                if (clear.Contains(msg))
                    Zero(true, msg);

                else if (all.Contains(msg) || cleare.Contains(msg) || backspace.Contains(msg) || reverse.Contains(msg))
                    AccumulateDigits(true, msg);

                else if (separator.Contains(msg))
                    AccumulateDigitsWithDecimal(true, msg);

                else if (operations.Contains(msg))
                {
                    if (current == "0" && op == "/")
                        ShowError(true, msg);

                    else
                        ComputeWithPending(true, msg);
                }

                else if (memory.Contains(msg))
                    ComputeNoPending(true, msg);

                else if (functions.Contains(msg))
                {
                    if (msg == "√" && double.Parse(current) / Math.Abs(double.Parse(current)) == -1)
                        ShowError(true, msg);

                    else
                        ComputeNoPending(true, msg);
                }

                else if (equal.Contains(msg))
                {
                    if (op == "/" && current == "0")
                        ShowError(true, msg);

                    else
                    {
                        isSecond = true;
                        ComputeNoPending(true, msg);
                    }
                }

                else if (percent.Contains(msg))
                {
                    if (op == ";")
                        Zero(true, msg);

                    else
                    {
                        isSecond = true;

                        if (isPercent)
                            AccumulateDigitsWithDecimal(true, msg);

                        else
                            AccumulateDigits(true, msg);
                    }
                }
            }
        }

        private void AccumulateDigitsWithDecimal(bool isInput, string msg)
        {
            if (isInput)
            {
                CheckMemory(msg);

                CheckDecimal();

                CheckPercent();

                if (percent.Contains(msg))
                {
                    if (isSecond)
                        current = (double.Parse(first) * double.Parse(current) / 100).ToString();

                    else
                        current = (double.Parse(first) * double.Parse(first) / 100).ToString();
                }

                else if (isResult)
                {
                    first = "0";
                    second = "0";
                    current = "0,";
                    result = "0";
                    op = ";";
                    isFirst = true;
                    isSecond = false;
                    isResult = false;
                }

                else if (all.Contains(msg))
                {
                    isDecimal = true;
                    current = current + msg;
                }

                else if (backspace.Contains(msg))
                    current = current.Remove(current.Length - 1);

                else if (reverse.Contains(msg))
                    current = (double.Parse(current, NumberStyles.Number) * (-1)).ToString();

                else if (separator.Contains(msg))
                    current = current + ",";

                invoker.Invoke(current);
                state = State.AccumulateDigitsWithDecimal;
            }

            else
            {
                if (clear.Contains(msg))
                    Zero(true, msg);

                else if (cleare.Contains(msg))
                    AccumulateDigits(true, msg);

                else if (all.Contains(msg) || reverse.Contains(msg))
                    AccumulateDigitsWithDecimal(true, msg);

                else if (operations.Contains(msg))
                    ComputeWithPending(true, msg);

                else if (memory.Contains(msg))
                    ComputeNoPending(true, msg);

                else if (functions.Contains(msg))
                {
                    if (msg == "√" && double.Parse(current) / Math.Abs(double.Parse(current)) == -1)
                        ShowError(true, msg);

                    else
                        ComputeNoPending(true, msg);
                }

                else if (equal.Contains(msg))
                {
                    if (op != ";")
                    {
                        isSecond = true;
                        ComputeNoPending(true, msg);
                    }
                }

                else if (backspace.Contains(msg))
                {
                    if (!isDecimal)
                        AccumulateDigits(true, msg);

                    else
                        AccumulateDigitsWithDecimal(true, msg);
                }

                else if (percent.Contains(msg))
                {
                    if (op == ";")
                        Zero(true, msg);

                    else
                    {
                        isSecond = true;

                        if (isPercent)
                            AccumulateDigitsWithDecimal(true, msg);

                        else
                            AccumulateDigits(true, msg);
                    }
                }
            }
        }

        private void ComputeWithPending(bool isInput, string msg)
        {
            if (isInput)
            {
                CheckMemory(msg);

                if (operations.Contains(msg))
                {
                    if (isFirst)
                    {
                        isFirst = false;

                        if (result != "0")
                            first = result;

                        else
                            first = current;
                    }

                    else
                    {
                        second = current;

                        Op();

                        first = result;
                    }

                    op = msg;

                    isResult = false;
                    current = "0";
                }

                invoker.Invoke(current);
                state = State.ComputeWithPending;
            }

            else
            {
                if (clear.Contains(msg))
                    Zero(true, msg);

                else if (all.Contains(msg))
                    AccumulateDigits(true, msg);

                else if (separator.Contains(msg))
                    AccumulateDigitsWithDecimal(true, msg);

                else if (memory.Contains(msg) || equal.Contains(msg))
                    ComputeNoPending(true, msg);

                else if (percent.Contains(msg))
                {
                    if (op == ";")
                        Zero(true, msg);

                    else
                    {
                        isSecond = true;

                        if (isPercent)
                            AccumulateDigitsWithDecimal(true, msg);

                        else
                            AccumulateDigits(true, msg);
                    }
                }
            }
        }

        private void ComputeNoPending(bool isInput, string msg)
        {
            if (isInput)
            {
                CheckMemory(msg);

                if (functions.Contains(msg))
                {
                    Function(msg);
                    current = result;
                }

                else if (equal.Contains(msg))
                {
                    if (isSecond)
                        second = current;

                    else
                        second = first;

                    Op();

                    current = result;
                }

                else if (reverse.Contains(msg))
                {
                    current = (double.Parse(current, NumberStyles.Number) * (-1)).ToString();
                    result = current;
                }

                isResult = true;
                isFirst = true;

                invoker.Invoke(current);
                state = State.ComputeNoPending;
            }

            else
            {
                if (zero.Contains(msg) || clear.Contains(msg) || cleare.Contains(msg) || percent.Contains(msg))
                    Zero(true, msg);

                else if (nonzero.Contains(msg))
                    AccumulateDigits(true, msg);

                else if (separator.Contains(msg))
                    AccumulateDigitsWithDecimal(true, msg);

                else if (operations.Contains(msg))
                    ComputeWithPending(true, msg);

                else if (functions.Contains(msg) || memory.Contains(msg) || reverse.Contains(msg))
                    ComputeNoPending(true, msg);
            }
        }

        private void ShowError(bool isInput, string msg)
        {
            if (isInput)
            {
                current = "0";
                invoker.Invoke("ERROR");
                state = State.ShowError;
            }

            else
            {
                if (zero.Contains(msg) || clear.Contains(msg) || cleare.Contains(msg))
                    Zero(true, msg);

                else if (nonzero.Contains(msg))
                    AccumulateDigits(true, msg);

                else if (separator.Contains(msg))
                    AccumulateDigitsWithDecimal(true, msg);
            }
        }

        private void CheckDecimal()
        {
            if (current.Last() == ',')
                isDecimal = false;
        }

        private void CheckMemory(string msg)
        {
            if (memory.Contains(msg))
            {
                switch (msg)
                {
                    case "M+":
                        save = (double.Parse(save, NumberStyles.Number) + double.Parse(current, NumberStyles.Number)).ToString();
                        break;

                    case "M-":
                        save = (double.Parse(save, NumberStyles.Number) - double.Parse(current, NumberStyles.Number)).ToString();
                        break;

                    case "MS":
                        save = current;
                        break;

                    case "MC":
                        save = "0";
                        break;

                    case "MR":
                        current = save;
                        break;
                }
            }
        }

        private void Op()
        {
            switch (op)
            {
                case "+":
                    result = (double.Parse(first, NumberStyles.Number) + double.Parse(second, NumberStyles.Number)).ToString();
                    break;

                case "—":
                    result = (double.Parse(first, NumberStyles.Number) - double.Parse(second, NumberStyles.Number)).ToString();
                    break;

                case "×":
                    result = (double.Parse(first, NumberStyles.Number) * double.Parse(second, NumberStyles.Number)).ToString();
                    break;

                case "/":
                    result = (double.Parse(first, NumberStyles.Number) / double.Parse(second, NumberStyles.Number)).ToString();
                    break;
            }
        }

        private void Function(string msg)
        {
            switch (msg)
            {
                case "√":
                    result = Math.Sqrt(double.Parse(current, NumberStyles.Number)).ToString();
                    break;

                case "x²":
                    result = Math.Pow(double.Parse(current, NumberStyles.Number), 2).ToString();
                    break;

                case "1/x":
                    result = (1 / double.Parse(current, NumberStyles.Number)).ToString();
                    break;
            }
        }

        private void CheckPercent()
        {
            if (second != "0")
            {
                if ((double.Parse(first) * double.Parse(second)).ToString().Contains(','))
                    isPercent = true;

                else
                    isPercent = false;
            }
            else
            {
                if ((double.Parse(first) * double.Parse(first)).ToString().Contains(','))
                    isPercent = true;

                else
                    isPercent = false;
            }
        }

        private void SetStart()
        {
            first = "0";
            second = "0";
            current = "0";
            result = "0";
            op = ";";
            save = "0";
            isResult = false;
            isDecimal = false;
            isFirst = true;
            isPercent = false;
            isSecond = false;
        }
    }
}