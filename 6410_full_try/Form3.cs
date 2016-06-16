using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _410_full_try
{
    public partial class Form3 : Form
    {
        private List<TextBox> inputTextBoxes;
        //private List<TextBox> initTextBoxes;
        //private List<TextBox> precTextBoxes;
        //private List<TextBox> prec1TextBoxes;

        int  inputNumber;
        int i;
        int labelWidth;
        string packet;
        string sensInit;
        //string beforeDot;
        //string afterDot;
        //string newdataSet;
        //int SensorFlag;
        string[] sensors;

        public Form3()
        {
            InitializeComponent();
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            inputNumber = Int32.Parse(textBox1.Text);
            

            //Initialize list of input text boxes
            inputTextBoxes = new List<TextBox>();
            //initTextBoxes = new List<TextBox>();
            //precTextBoxes = new List<TextBox>();
            //prec1TextBoxes = new List<TextBox>();
            Button button2 = new Button();

            Label head1 = new Label();
            //Label head2 = new Label();
            //Label head3 = new Label();
            //Label head4 = new Label();


            sensors = new string[inputNumber];
            //Generate labels and text boxes
            for (i = 1; i <= inputNumber; i++)
            {

                //Create a new label and text box
                Label labelInput = new Label();
                Label dot = new Label();

                TextBox textBoxNewInput = new TextBox();
                //TextBox textBoxNewInput1 = new TextBox();
                //TextBox textBoxNewInput2 = new TextBox();
                //TextBox textBoxNewInput3 = new TextBox();


                //Initialize label's property
                labelInput.Text = "Contact No. " + i;
                labelInput.Location = new Point(30, textBox1.Bottom + (i * 30));
                labelWidth = labelInput.Width;
                dot.Text = ".";
                dot.Location = new Point(labelInput.Width + 245, labelInput.Top);
                // labelInput.AutoSize = true;

                //textBoxNewInput1.Width = 30;
                //textBoxNewInput2.Width = 30;
                //textBoxNewInput3.Width = 30;
                //Initialize textBoxes Property
                textBoxNewInput.Location = new Point(labelInput.Width + 30, labelInput.Top);
                //textBoxNewInput1.Location = new Point(labelInput.Width + 150, labelInput.Top);
                //textBoxNewInput2.Location = new Point(labelInput.Width + 210, labelInput.Top);
                //textBoxNewInput3.Location = new Point(labelInput.Width + 250, labelInput.Top);

                //Add the newly created text box to the list of input text boxes
                inputTextBoxes.Add(textBoxNewInput);
                //initTextBoxes.Add(textBoxNewInput1);
                //precTextBoxes.Add(textBoxNewInput2);
                //prec1TextBoxes.Add(textBoxNewInput3);
                //textBoxNewInput_TextChanged(sender,e)

                //////initTextBoxes.Add(textBoxNewInput1);

                inputTextBoxes.Add(textBox1);
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
                //this.Controls.Add(textBoxNewInput1);
                //this.Controls.Add(textBoxNewInput2);
                //this.Controls.Add(textBoxNewInput3);
                //button2.Click += new EventHandler(button2_Click);
                this.Controls.Add(button2);

                button2.Text = "Set Contact No.";
                button2.Location = new Point(textBoxNewInput.Width + 210, textBoxNewInput.Bottom);

                //string str = textBoxNewInput1.Text;
                //MessageBox.Show(str);
            }
            head1.Text = "Contact No.";
            //head2.Text = "Initials";
            //head3.Text = "X";
            //head4.Text = "Y";

            //head2.Width = 50;
            //head3.Width = 10;
            //head4.Width = 10;

            head1.Location = new Point(labelWidth + 30, textBox1.Bottom + 15);
            //head2.Location = new Point(labelWidth + 150, textBox1.Bottom + 15);
            //head3.Location = new Point(labelWidth + 210, textBox1.Bottom + 15);
            //head4.Location = new Point(labelWidth + 250, textBox1.Bottom + 15);

            this.Controls.Add(head1);
            //this.Controls.Add(head2);
            //this.Controls.Add(head3);
            //this.Controls.Add(head4);

            button2.Click += new EventHandler(button2_Click);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //sensInit = .Text;     check here
            MessageBox.Show(sensInit);
            Form1 form1 = new Form1();
            form1.contactNo = sensInit;
            //form1.beforeDot1 = beforeDot;
            //form1.afterDot1 = afterDot;
            //form1.ExpectedPacket1 = ExpectPacket;
            //form1.SensorFlag1 = SensorFlag;
            //SensorFlag = 1;
            this.Dispose();
            form1.ShowDialog();
        }
    }
}