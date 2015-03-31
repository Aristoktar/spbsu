using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace treeParse
{
    enum priorities : int { plus = 2, minus = 1, multiplication = 3, devision = 4, sin = 5, cos = 6, tg = 7, ctg = 8, log = 16, exp = 17, pow = 18, sqrt = 19, hook = 20 };
    public class treeParse : Component
    {
        private treeParse childLeft;
        private treeParse childRight;
        private string data;
        private string operatorString;
        private double value;
        private string variable;
        private double variableValue;
        int[] arrPriority;
        public treeParse(string input)
        {
            this.data = input;
            while (this.trim()) { }
        }
        public treeParse(string input, string var1, double value)
        {
            this.data = input;
            this.variable = var1;
            this.variableValue = value;
            while (this.trim()) { }
        }
        public void init()
        {
            this.correctData();
            this.build();
        }

        public bool trim()
        {
            if (this.data.Length == 0)
                return false;
            string s = this.data;
            Stack stack = new Stack();
            Stack stackInt = new Stack();
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s.Substring(i, 1) == "(")
                {
                    stack.Push("(");
                    stackInt.Push(i);
                }
                if (s.Substring(i, 1) == ")")
                {
                    if (stack.Count == 0)
                    {
                        throw new unbalancedStringExeption();
                    }
                    else
                    {
                        if (stack.Peek().ToString() == "(")
                        {
                            stack.Pop();
                            stackInt.Pop();
                        }
                        else
                            throw new unbalancedStringExeption();
                    }
                }
            }
            if (stack.Count == 1)
            {
                if (Convert.ToInt32(stackInt.Peek()) == 0)
                {
                    this.data = s.Substring(1, s.Length - 2);
                    return true;
                }
                else
                {
                    if (s.Substring(s.Length - 1, 1) == ")")
                    {
                        if (stack.Peek().ToString() == "(")
                        {
                            return false;
                        }
                        else
                            throw new unbalancedStringExeption();
                    }
                    else
                        throw new unbalancedStringExeption();
                }
            }
            else
            {
                if (s.Substring(s.Length - 1, 1) == ")" || s.Substring(s.Length - 1, 1) == "(")
                    throw new unbalancedStringExeption();
            }

            return false;
        }
        private void correctData()
        {
            this.data = this.data.ToLower();
            this.data = this.data.Replace("pi", Math.PI.ToString());
            //this.data = this.data.Replace("e", Math.E.ToString());
            this.data = this.data.Replace("[", "(");
            this.data = this.data.Replace("]", ")");
            this.data = this.data.Replace("sin", "s");      //sin->s
            this.data = this.data.Replace("cos", "c");      //cos->c
            this.data = this.data.Replace("tan", "t");      //tan->t
            this.data = this.data.Replace("tg", "t");      //tg-> t
            this.data = this.data.Replace("ctg", "g");      //ctg -> g
            this.data = this.data.Replace("ctan", "g");      //ctan -> g
            this.data = this.data.Replace("log", "l");      //log -> g
            this.data = this.data.Replace("exp", "|");      //exp -> |
            this.data = this.data.Replace("sqrt", "[");      //sqrt -> [
            this.data = this.data.Replace(".", ",");            //for correct double


        }
        public void calcArrPriority()
        {
            int addition = 0;
            this.arrPriority = new int[this.data.Length];
            for (int i = 0; i < this.data.Length; i++)
            {
                string currSymbol = this.data.Substring(i, 1);
                switch (currSymbol)
                {
                    case "+":
                        this.arrPriority[i] = addition + (int)priorities.plus;
                        break;
                    case "-":
                        this.arrPriority[i] = addition + (int)priorities.minus;
                        break;
                    case "*":
                        this.arrPriority[i] = addition + (int)priorities.multiplication;
                        break;
                    case "/":
                        this.arrPriority[i] = addition + (int)priorities.devision;
                        break;
                    case "s":
                        this.arrPriority[i] = addition + (int)priorities.sin;
                        break;
                    case "c":
                        this.arrPriority[i] = addition + (int)priorities.cos;
                        break;
                    case "t":
                        this.arrPriority[i] = addition + (int)priorities.tg;
                        break;
                    case "g":
                        this.arrPriority[i] = addition + (int)priorities.ctg;
                        break;
                    case "^":
                        this.arrPriority[i] = addition + (int)priorities.pow;
                        break;
                    case "[":
                        this.arrPriority[i] = addition + (int)priorities.sqrt;
                        break;
                    case "|":
                        this.arrPriority[i] = addition + (int)priorities.exp;
                        break;
                    case "l":
                        this.arrPriority[i] = addition + (int)priorities.log;
                        break;
                    case "(":
                        this.arrPriority[i] = -1;
                        addition += (int)priorities.hook;
                        break;
                    case ")":
                        this.arrPriority[i] = -1;
                        addition -= (int)priorities.hook;
                        break;
                    default:
                        this.arrPriority[i] = -1;
                        break;
                }
            }

        }
        private int calcMinPriorityPosition()
        {
            int ans = 0;
            int min = this.arrPriority[0];
            int max = this.arrPriority[0];

            for (int i = 0; i < this.data.Length; i++)
            {
                if (this.arrPriority[i] > max)
                {
                    max = this.arrPriority[i];
                    ans = i;
                }
            }
            min = max;
            for (int i = 0; i < this.data.Length; i++)
            {
                if (this.arrPriority[i] < min && this.arrPriority[i] > 0)
                {
                    min = this.arrPriority[i];
                    ans = i;
                }
            }

            return ans;
        }
        private bool operatorIsUnar(int position)
        {
            string s = this.data.Substring(position, 1);
            switch (s)
            {
                case "-":           //if the minus is first
                    if (position == 0)
                        return true;
                    else
                        return false;
                    break;
                case "s":            //sin
                    return true;
                case "c":           //cos
                    return true;
                case "t":           //tg
                    return true;
                case "g":           //ctg
                    return true;
                case "|":           //exp
                    return true;
                case "l":           //log
                    return true;
                case "[":           //sqrt
                    return true;
                default:
                    return false;
            }
        }
        public void build()
        {
            this.calcArrPriority();
            int minPrior = this.calcMinPriorityPosition();
            if (this.arrPriority[minPrior] != -1)
            {

                string leftChild;// = this.data.Substring(0,minPrior);
                string rightChild = this.data.Substring(minPrior + 1, this.data.Length - minPrior - 1);
                this.operatorString = this.data.Substring(minPrior, 1);
                if (this.operatorIsUnar(minPrior))
                {
                    this.childRight = new treeParse(rightChild, this.variable, this.variableValue);
                    this.childRight.build();
                }
                else
                {
                    leftChild = this.data.Substring(0, minPrior);
                    this.childLeft = new treeParse(leftChild, this.variable, this.variableValue);
                    this.childRight = new treeParse(rightChild, this.variable, this.variableValue);
                    this.childLeft.build();
                    this.childRight.build();
                }
            }
        }
        public treeParse getLeftChild()
        {
            return this.childLeft;
        }
        public treeParse getRightChild()
        {
            return this.childRight;
        }
        public string getData()
        {
            return this.data;
        }
        public string getOperator()
        {
            return this.operatorString;
        }

        public double calculate()
        {
            double leftValue;
            double rightValue;
            if (this.childLeft == null && this.childRight != null)
            {
                string oper = this.getOperator();
                rightValue = this.childRight.calculate();
                switch (oper)
                {
                    case "-":
                        this.value = 0 - rightValue;
                        break;
                    case "s":
                        this.value = Math.Sin(rightValue);
                        break;
                    case "c":
                        this.value = Math.Cos(rightValue);
                        break;
                    case "t":
                        this.value = Math.Tan(rightValue);
                        break;
                    case "|":
                        this.value = Math.Exp(rightValue);
                        break;
                    case "l":
                        this.value = Math.Log(rightValue);
                        break;
                    case "[":
                        this.value = Math.Sqrt(rightValue);
                        break;
                    case "g":
                        this.value = 1 / Math.Tan(rightValue);

                        break;
                    default:
                        break;
                }
            }
            else
            {
                if (this.childLeft != null && this.childRight != null)
                {
                    string oper = this.getOperator();
                    leftValue = this.childLeft.calculate();
                    rightValue = this.childRight.calculate();
                    switch (oper)
                    {
                        case "+":
                            this.value = leftValue + rightValue;
                            break;
                        case "-":
                            this.value = leftValue - rightValue;
                            break;
                        case "*":
                            this.value = leftValue * rightValue;
                            break;
                        case "/":
                            this.value = leftValue / rightValue;
                            break;
                        case "^":
                            this.value = Math.Pow(leftValue, rightValue);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    this.value = convertToDouble(this.data);
                }
            }
            return this.value;
        }
        public double calculate(string var1, double value)
        {
            this.variable = var1;
            this.variableValue = value;
            double leftValue;
            double rightValue;
            if (this.childLeft == null && this.childRight != null)
            {
                string oper = this.getOperator();
                rightValue = this.childRight.calculate(var1, value);
                switch (oper)
                {
                    case "-":
                        this.value = 0 - rightValue;
                        break;
                    case "s":
                        this.value = Math.Sin(rightValue);
                        break;
                    case "c":
                        this.value = Math.Cos(rightValue);
                        break;
                    case "t":
                        this.value = Math.Tan(rightValue);
                        break;
                    case "|":
                        this.value = Math.Exp(rightValue);
                        break;
                    case "l":
                        this.value = Math.Log(rightValue);
                        break;
                    case "[":
                        this.value = Math.Sqrt(rightValue);
                        break;
                    case "g":
                        this.value = 1 / Math.Tan(rightValue);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                if (this.childLeft != null && this.childRight != null)
                {
                    string oper = this.getOperator();
                    leftValue = this.childLeft.calculate(var1, value);
                    rightValue = this.childRight.calculate(var1, value);
                    switch (oper)
                    {
                        case "+":
                            this.value = leftValue + rightValue;
                            break;
                        case "-":
                            this.value = leftValue - rightValue;
                            break;
                        case "*":
                            this.value = leftValue * rightValue;
                            break;
                        case "/":
                            this.value = leftValue / rightValue;
                            break;
                        case "^":
                            this.value = Math.Pow(leftValue, rightValue);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    this.value = convertToDouble(this.data);
                }
            }
            return this.value;
        }

        private double convertToDouble(string s)
        {
            double ans;
            try
            {
                ans = Convert.ToDouble(s);
            }
            catch (System.FormatException ex)
            {
                ans = Convert.ToDouble(s.Replace(this.variable, this.variableValue.ToString()));  //if the variable is 's','c','t','g', there will be a mistake;
            }
            return ans;
        }
    }
    public class unbalancedStringExeption : Exception
    { }

    public class wrongvariable : Exception
    { }

    public class varExist : Exception
    { }
}
