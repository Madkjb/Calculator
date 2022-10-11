using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace CalApp
{
    // Setting Rectangle, height, width. X and Y Axis for autoresize

    public partial class Calculator : Form
    {
        private Rectangle buttonOneRectangle;
        private Rectangle buttonTwoRectangle;
        private Rectangle buttonThreeRectangle;
        private Rectangle buttonFourRectangle;
        private Rectangle buttonFiveRectangle;
        private Rectangle buttonSixRectangle;
        private Rectangle buttonSevenRectangle;
        private Rectangle buttonEightRectangle;
        private Rectangle buttonNineRectangle;
        private Rectangle buttonZeroRectangle;
        private Rectangle buttonPlusRectangle;
        private Rectangle buttonMinusRectangle;
        private Rectangle buttonMultiplyRectangle;
        private Rectangle buttonDivideRectangle;
        private Rectangle buttonEqualRectangle;
        private Rectangle buttonPlusMinusRectangle;
        private Rectangle buttonClearRectangle;
        private Rectangle buttonBackspaceRectangle;
        private Rectangle buttonDecimalRectangle;
        private Rectangle buttonSquareRectangle;
        private Rectangle displayScreenRectangle;
        private Size originalFormSize;
        
        public Calculator()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            originalFormSize = this.Size;
            
            buttonOneRectangle = new Rectangle(buttonOne.Location.X, buttonOne.Location.Y,buttonOne.Width, buttonOne.Height);
            buttonTwoRectangle = new Rectangle(buttonTwo.Location.X, buttonTwo.Location.Y,buttonTwo.Width, buttonTwo.Height);
            buttonThreeRectangle = new Rectangle(buttonThree.Location.X, buttonThree.Location.Y,buttonThree.Width, buttonThree.Height);
            buttonFourRectangle = new Rectangle(buttonFour.Location.X, buttonFour.Location.Y,buttonFour.Width, buttonFour.Height);
            buttonFiveRectangle = new Rectangle(buttonFive.Location.X, buttonFive.Location.Y,buttonFive.Width, buttonFive.Height);
            buttonSixRectangle = new Rectangle(buttonSix.Location.X, buttonSix.Location.Y,buttonSix.Width, buttonSix.Height);
            buttonSevenRectangle = new Rectangle(buttonSeven.Location.X, buttonSeven.Location.Y,buttonSeven.Width, buttonSeven.Height);
            buttonEightRectangle = new Rectangle(buttonEight.Location.X, buttonEight.Location.Y,buttonEight.Width, buttonEight.Height);
            buttonNineRectangle = new Rectangle(buttonNine.Location.X, buttonNine.Location.Y,buttonNine.Width, buttonNine.Height);
            buttonZeroRectangle = new Rectangle(buttonZero.Location.X, buttonZero.Location.Y,buttonZero.Width, buttonZero.Height);
            buttonPlusRectangle = new Rectangle(buttonPlus.Location.X, buttonPlus.Location.Y,buttonPlus.Width, buttonPlus.Height);
            buttonMinusRectangle = new Rectangle(buttonMinus.Location.X, buttonMinus.Location.Y,buttonMinus.Width, buttonMinus.Height);
            buttonMultiplyRectangle = new Rectangle(buttonMultiply.Location.X, buttonMultiply.Location.Y, buttonMultiply.Width, buttonMultiply.Height);
            buttonDivideRectangle = new Rectangle(buttonDivide.Location.X, buttonDivide.Location.Y, buttonDivide.Width, buttonDivide.Height);
            buttonEqualRectangle = new Rectangle(buttonEqual.Location.X, buttonEqual.Location.Y, buttonEqual.Width, buttonEqual.Height);
            buttonPlusMinusRectangle = new Rectangle(buttonPlusMinus.Location.X, buttonPlusMinus.Location.Y, buttonPlusMinus.Width, buttonPlusMinus.Height);
            buttonClearRectangle = new Rectangle(buttonClear.Location.X, buttonClear.Location.Y, buttonClear.Width, buttonClear.Height);
            buttonBackspaceRectangle = new Rectangle(buttonBackspace.Location.X, buttonBackspace.Location.Y, buttonBackspace.Width, buttonBackspace.Height);
            buttonDecimalRectangle = new Rectangle(buttonDecimal.Location.X, buttonDecimal.Location.Y, buttonDecimal.Width, buttonDecimal.Height);
            buttonSquareRectangle = new Rectangle(buttonSquare.Location.X, buttonSquare.Location.Y, buttonSquare.Width, buttonSquare.Height);
            displayScreenRectangle = new Rectangle(displayScreen.Location.X, displayScreen.Location.Y, displayScreen.Width, displayScreen.Height);
        }
        private void Calculator_Resize(object sender, EventArgs e)
        {
            resizeControl(buttonOneRectangle, buttonOne);
            resizeControl(buttonTwoRectangle, buttonTwo);
            resizeControl(buttonThreeRectangle, buttonThree);
            resizeControl(buttonFourRectangle, buttonFour);
            resizeControl(buttonFiveRectangle, buttonFive);
            resizeControl(buttonSixRectangle, buttonSix);
            resizeControl(buttonSevenRectangle, buttonSeven);
            resizeControl(buttonEightRectangle, buttonEight);
            resizeControl(buttonNineRectangle, buttonNine);
            resizeControl(buttonZeroRectangle, buttonZero);
            resizeControl(buttonPlusRectangle, buttonPlus);
            resizeControl(buttonMinusRectangle, buttonMinus);
            resizeControl(buttonMultiplyRectangle, buttonMultiply);
            resizeControl(buttonDivideRectangle, buttonDivide);
            resizeControl(buttonEqualRectangle, buttonEqual);
            resizeControl(buttonPlusMinusRectangle, buttonPlusMinus);
            resizeControl(buttonClearRectangle, buttonClear);
            resizeControl(buttonBackspaceRectangle, buttonBackspace);
            resizeControl(buttonDecimalRectangle, buttonDecimal);
            resizeControl(buttonSquareRectangle, buttonSquare);
            resizeControl(displayScreenRectangle, displayScreen);
        }

        private void resizeControl(Rectangle OrginalControlReact, Control control)
        {
            float xAxis = (float)(this.Width) / (float)(originalFormSize.Width);
            float yAxis = (float)(this.Height) / (float)(originalFormSize.Height);

            int newXPosition = (int)(OrginalControlReact.X * xAxis);
            int newYPosition = (int)(OrginalControlReact.Y * yAxis);

            int newWidth = (int)(OrginalControlReact.Width * xAxis);    
            int newHeight = (int)(OrginalControlReact.Height * yAxis);

            control.Location = new Point(newXPosition, newYPosition);
            control.Size = new Size(newWidth, newHeight);
        }

        // decimal maths

        float num1, num2, result;
        char operation;
        bool dec = false;

        private void changeLabel(int numPressed)
        {
            if(dec == true)
            {
                int decimalCount = 0;
                foreach (char c in displayScreen.Text)
                {
                    if(c == '.')
                    {
                        decimalCount++;
                    }
                }
                if(decimalCount < 1)
                {
                    displayScreen.Text = displayScreen.Text + ".";
                }
                dec = false;    
            }
            else
            {
                if(displayScreen.Text.Equals("0") == true && displayScreen.Text != null)
                {
                    displayScreen.Text = numPressed.ToString();
                }
                else if(displayScreen.Text.Equals("-0") == true)
                {
                    displayScreen.Text = "-" + numPressed.ToString();
                }
                else
                {
                    displayScreen.Text = displayScreen.Text + numPressed.ToString();
                }
            }
        }

        private void buttonZero_Click(object sender, EventArgs e)
        {
            changeLabel(0);
        }

        private void buttonOne_Click(object sender, EventArgs e)
        {
            changeLabel(1);
        }

        private void buttonTwo_Click(object sender, EventArgs e)
        {
            changeLabel(2);
        }

        private void buttonThree_Click(object sender, EventArgs e)
        {
            changeLabel(3);
        }

        private void buttonFour_Click(object sender, EventArgs e)
        {
            changeLabel(4);
        }

        private void buttonFive_Click(object sender, EventArgs e)
        {
            changeLabel(5);
        }

        private void buttonSix_Click(object sender, EventArgs e)
        {
            changeLabel(6);
        }

        private void buttonSeven_Click(object sender, EventArgs e)
        {
            changeLabel(7);
        }

        private void buttonEight_Click(object sender, EventArgs e)
        {
            changeLabel(8);
        }

        private void buttonNine_Click(object sender, EventArgs e)
        {
            changeLabel(9);
        }

        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            dec = true;
            changeLabel(0);
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            result = 0;
            if(displayScreen.Text.Equals("0") == false)
            {
                switch (operation)
                {
                    case '+':
                        num2 = float.Parse(displayScreen.Text);
                        result = num1 + num2;
                        break;
                    case '-':
                        num2 = float.Parse(displayScreen.Text);
                        result = num1 - num2;
                        break;
                    case '/':
                        num2 = float.Parse(displayScreen.Text);
                        result = num1 / num2;
                        break;
                    case '*':
                        num2 = float.Parse(displayScreen.Text);
                        result = num1 * num2;
                        break;
                    default:
                        break;
                }
            }
            displayScreen.Text = result.ToString();
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            num1 = float.Parse(displayScreen.Text);
            operation = '+';
            result = result + num1;
            displayScreen.Text = "";
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            num1 = float.Parse(displayScreen.Text);
            operation = '-';
            result = result - num1;
            displayScreen.Text = "";
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            num1 = float.Parse(displayScreen.Text);
            operation = '/';
            result = result / num1;
            displayScreen.Text = "";
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            num1 = float.Parse(displayScreen.Text);
            operation = '*';
            result = result * num1;
            displayScreen.Text = "";
        }

        private void buttonSquare_Click(object sender, EventArgs e)
        {
           num1 = float.Parse(displayScreen.Text);
            if(num1 > 0)
            {
                double sqrt = Math.Sqrt(num1);
                displayScreen.Text = sqrt.ToString();
            }
        }

        private void buttonPlusMinus_Click(object sender, EventArgs e)
        {
            displayScreen.Text = "-" + displayScreen.Text;  
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            displayScreen.Text = "0";
            num1 = 0;
            num2 = 0;
            result = 0;
            operation = '\0';
            dec = false;
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            int stringLength = displayScreen.Text.Length; 
            if(stringLength > 1)
            {
                displayScreen.Text = displayScreen.Text.Substring(0, stringLength -1);
            }
            else
            {
                displayScreen.Text = "0";
            }
        }

        // Keyboard Input
        private void Calculator_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad1:
                    buttonOne.PerformClick();
                    break;
                case Keys.D1:
                    buttonOne.PerformClick();
                    break;
                case Keys.NumPad2:
                    buttonTwo.PerformClick();
                    break;
                case Keys.D2:
                    buttonTwo.PerformClick();
                    break;
                case Keys.NumPad3:
                    buttonThree.PerformClick();
                    break;
                case Keys.D3:
                    buttonFour.PerformClick();
                    break;
                case Keys.NumPad4:
                    buttonFour.PerformClick();
                    break;
                case Keys.D4:
                    buttonFour.PerformClick();
                    break;
                case Keys.NumPad5:
                    buttonFive.PerformClick();
                    break;
                case Keys.D5:
                    buttonFive.PerformClick();
                    break;
                case Keys.NumPad6:
                    buttonSix.PerformClick();
                    break;
                case Keys.D6:
                    buttonSix.PerformClick();
                    break;
                case Keys.NumPad7:
                    buttonSeven.PerformClick();
                    break;
                case Keys.D7:
                    buttonSeven.PerformClick();
                    break;
                case Keys.NumPad8:
                    buttonEight.PerformClick();
                    break;
                case Keys.D8:
                    buttonEight.PerformClick();
                    break;
                case Keys.NumPad9:
                    buttonNine.PerformClick();
                    break;
                case Keys.D9:
                    buttonNine.PerformClick();
                    break;
                case Keys.Divide:
                    buttonDivide.PerformClick();
                    break;
                case Keys.Subtract:
                    buttonMinus.PerformClick();
                    break;
                case Keys.Add:
                    buttonPlus.PerformClick();
                    break;
                case Keys.Multiply:
                    buttonMultiply.PerformClick();
                    break;
                default:
                    break;
            }
        }

        private void Calculator_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    buttonEqual.PerformClick();
                    break;
                default:
                    break;
            }
        }

    }
}
