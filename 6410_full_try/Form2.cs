using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _410_full_try
{
    public partial class Form2 : Form
    {
        string ExpectPacket;
        int g1, g2;
        private List<TextBox> inputTextBoxes;
        private List<TextBox> initTextBoxes;
        private List<TextBox> precTextBoxes;
        private List<TextBox> prec1TextBoxes;
        // TextBox textBox1 = new TextBox
        //Get the number of input text boxes to generate

        int inputNumber;
        int i;
        int labelWidth;
        string packet;
        string sensInit;
        string beforeDot;
        string afterDot;
        string newdataSet;
        int SensorFlag;
        string[] sensors;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            inputNumber = Int32.Parse(textBox1.Text);

            //Initialize list of input text boxes
            inputTextBoxes = new List<TextBox>();
            initTextBoxes = new List<TextBox>();
            precTextBoxes = new List<TextBox>();
            prec1TextBoxes = new List<TextBox>();
            Button button2 = new Button();

            Label head1 = new Label();
            Label head2 = new Label();
            Label head3 = new Label();
            Label head4 = new Label();


            sensors = new string[inputNumber];
            //Generate labels and text boxes
            for (i = 1; i <= inputNumber; i++)
            {

                //Create a new label and text box
                Label labelInput = new Label();
                Label dot = new Label();

                TextBox textBoxNewInput = new TextBox();
                TextBox textBoxNewInput1 = new TextBox();
                TextBox textBoxNewInput2 = new TextBox();
                TextBox textBoxNewInput3 = new TextBox();


                //Initialize label's property
                labelInput.Text = "Sensor " + i;
                labelInput.Location = new Point(30, textBox1.Bottom + (i * 30));
                labelWidth = labelInput.Width;
                dot.Text = ".";
                dot.Location = new Point(labelInput.Width + 245, labelInput.Top);
                // labelInput.AutoSize = true;

                textBoxNewInput1.Width = 30;
                textBoxNewInput2.Width = 30;
                textBoxNewInput3.Width = 30;
                //Initialize textBoxes Property
                textBoxNewInput.Location = new Point(labelInput.Width + 30, labelInput.Top);
                textBoxNewInput1.Location = new Point(labelInput.Width + 150, labelInput.Top);
                textBoxNewInput2.Location = new Point(labelInput.Width + 210, labelInput.Top);
                textBoxNewInput3.Location = new Point(labelInput.Width + 250, labelInput.Top);

                //Add the newly created text box to the list of input text boxes
                inputTextBoxes.Add(textBoxNewInput);
                initTextBoxes.Add(textBoxNewInput1);
                precTextBoxes.Add(textBoxNewInput2);
                prec1TextBoxes.Add(textBoxNewInput3);
                //textBoxNewInput_TextChanged(sender,e)

                //////initTextBoxes.Add(textBoxNewInput1);

                //inputTextBoxes.Add(textBox1);
                //textBoxNewInput.Text = "Sensor Name";
                //textBoxNewInput1.Text = "Initials";
                // textBoxNewInput1.Text = textBoxNewInput.ToString();

                // textBoxNewInput.GotFocus(sender, e)

                //  textBoxNewInput.TabStop = true;
                ////////////Button button2 = new Button();

                //Add the labels and text box to the form
                this.Controls.Add(labelInput);
                //this.Controls.Add(dot);
                this.Controls.Add(textBoxNewInput);
                this.Controls.Add(textBoxNewInput1);
                this.Controls.Add(textBoxNewInput2);
                this.Controls.Add(textBoxNewInput3);
                //button2.Click += new EventHandler(button2_Click);
                this.Controls.Add(button2);

                button2.Text = "Set String";
                button2.Location = new Point(textBoxNewInput.Width + 210, textBoxNewInput2.Bottom);

                //string str = textBoxNewInput1.Text;
                //MessageBox.Show(str);
            }
            head1.Text = "Sensor's Name";
            head2.Text = "Initials";
            head3.Text = "X";
            head4.Text = "Y";

            head2.Width = 50;
            head3.Width = 10;
            head4.Width = 10;

            head1.Location = new Point(labelWidth + 30, textBox1.Bottom + 15);
            head2.Location = new Point(labelWidth + 150, textBox1.Bottom + 15);
            head3.Location = new Point(labelWidth + 210, textBox1.Bottom + 15);
            head4.Location = new Point(labelWidth + 250, textBox1.Bottom + 15);

            this.Controls.Add(head1);
            this.Controls.Add(head2);
            this.Controls.Add(head3);
            this.Controls.Add(head4);


            button2.Click += new EventHandler(button2_Click);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            foreach (TextBox inputBox in initTextBoxes)
            {

                string input = inputBox.Text;
                if (inputBox.Text == String.Empty)
                {
                    MessageBox.Show("Plaese fill in all the text boxes.", "Error");
                    return;
                }

                else
                {
                    if (inputBox.Text.Length != 2)
                    {
                        MessageBox.Show("Initials should be of TWO letters only. ", "Error");
                        return;
                    }
                    else
                    {

                        // sum += Int32.Parse(inputBox.Text);

                        // MessageBox.Show(input);

                        //sensors =  new string[1] {input}; 
                        sensInit += input;
                        //  MessageBox.Show(sensors[1]);
                    }

                }//MessageBox.Show(input);
            }

            foreach (TextBox inputBox in precTextBoxes)
            {

                string input1 = inputBox.Text;
                if (inputBox.Text == String.Empty)
                {
                    MessageBox.Show("Plaese fill in all the text boxes.", "Error");
                    return;
                }

                else
                { beforeDot += input1; }
            }

            foreach (TextBox inputBox in prec1TextBoxes)
            {

                string input2 = inputBox.Text;
                if (inputBox.Text == String.Empty)
                {
                    MessageBox.Show("Plaese fill in all the text boxes.", "Error");
                    return;
                }

                else
                { afterDot += input2; }
            }

             string[] bn = new string[sensInit.Length];     //sensor initials
                for (int i = 0; i < sensInit.Length; i++)
                {
                    bn[i] = sensInit[i].ToString();
                }
                
                string[] c = new string[beforeDot.Length];
                for (int i = 0; i < beforeDot.Length; i++)
                {
                    c[i] = beforeDot[i].ToString();
                }

                string[] d = new string[afterDot.Length];
                for (int i = 0; i < afterDot.Length; i++)
                {
                    d[i] = afterDot[i].ToString();
                }

            for (g1 = 0, g2 = 0; g1 < sensInit.Length/2; g1++)
            {
                ExpectPacket += bn[g2] + bn[g2 + 1];
               // MessageBox.Show(ExpectPacket,"1");
                for (int h = 0; h < Convert.ToInt32(c[g1]); h++)
                {
                    ExpectPacket += "x";
                }
               // MessageBox.Show(ExpectPacket,"2");
                ExpectPacket += ".";
                for (int h = 0; h < Convert.ToInt32(d[g1]); h++)
                {
                    ExpectPacket += "y";
                }
                    g2 = g2 + 2;
            }

            MessageBox.Show(ExpectPacket,"expected packet");
            //    MessageBox.Show(sensInit, "sensinit");
            //MessageBox.Show(beforeDot, "beforedot");
            //MessageBox.Show(afterDot, "afterdot");
            //for (int j = 0; j < 3; j++)
            //{
            //    MessageBox.Show(sensors[j]);

            //}
            
            Form1 form1 = new Form1();
            form1.sensInit1 = sensInit;
            form1.beforeDot1 = beforeDot;
            form1.afterDot1 = afterDot;
            form1.ExpectedPacket1 = ExpectPacket;
            form1.SensorFlag1 = SensorFlag;
            SensorFlag = 1;
            this.Dispose();
            form1.ShowDialog();

            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_ParentChanged(object sender, EventArgs e)
        {

        }

       
    }
}