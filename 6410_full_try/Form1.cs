using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;
//using System.Runtime.Serialization;
using Microsoft.Office.Interop.Excel;
//using Microsoft.Office.Tools.Excel.Controls;
using Microsoft.WindowsCE.Forms;

namespace _410_full_try
{
    public partial class Form1 : Form
    {
        public string sensInit1;
        public string beforeDot1;
        public string afterDot1;
        public string ExpectedPacket1;
        public int SensorFlag1;
        public string contactNo;
        //schedular
        string[] hours;
        string[] minute;
        string HH, mm, dd, dd1, MM1, MM, yyyy, setTime;
        static int HOUR, MIN;
        int HHH, mmm, HHH1, mmm1;
        int hours1, minutes1;
        string timeString;
        string timeStringDisp;
        string setTimeDisp;
        ComboBox ComboBox1 = new System.Windows.Forms.ComboBox();
        ComboBox ComboBox2 = new System.Windows.Forms.ComboBox();
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();


       // public event PassValueHandler PassValue1;
        //public event PaintEventHandler PassValue2;
        private int Status = 0;
        string[] row;
        string message;
        string message1;
        string timestamp;
        string timeDate;
        string Temp;
        string pH;
        string DO;
        string EC;
        string TD;
        string OR;
        string AllRow;
        String readMsg;
        string nodes;
        string nodesPacket;
        string[] AllRow1;
        string arya;
        string aryaHead;
        //string[] nodeDigit;
        string[] HMac;
        string[] LMac;
        string[] Packet;
        byte[] bytesToSend = new byte[1] { 0x1A };  //Control+Z for GSM
        string SIMno;
        //for sorting
        int n1;
        string Receive1;
        string nodeDigit;
        string nodeTen;
        string nodeD1;
        int[] wUnit = new int[100];
        int[] wTen = new int[100];
        string[] w1Unit = new string[100];
        string[] w1Ten = new string[100];
        string[] q = new string[1000];
        int s, p, u, v, t, c;
        int n ;
        int na;
        int m;
        bool k;
        string rece;
        System.Data.DataTable table = new System.Data.DataTable();
        int colNo;
        //int SensorFlag;
        int packetChange;
        string dfgh;
        public Form1()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(timer_Tick); // Everytime timer ticks, timer_Tick will be called
            timer.Interval = (60) * (1);             // Timer will tick evert 10 seconds
            timer.Enabled = true;                       // Enable the timer
            // timer.Start();
             colNo = 1;
             //textBox4.Text = ExpectedPacket1;
             ////if (SensorFlag == 1)
             ////{
             ////    textBox4.Text = ExpectedPacket1;
             ////}
             ////else
             ////{
             ////    textBox4.Text = "TPxx.yPHxx.yyDOxx.yyECxxx.yTDxxxxxxORxxxx.y";
             ////}

        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string node1 = "Mayur";
        //    string MAC1 = "Dhnyaneshwari";
        //    string[] row = new string[] { node1, MAC1 };
        //    //dataGridView1.Rows.Add(row);
        //    //dataGrid1.RowHeadersVisible(row);
        //    //dataGrid1.CreateGraphics();
        //    //string qwe = dataGrid1.GridLineColor;//.ToString;
        //    string qwe= dataGrid1.Width.ToString;
        //    textBox1.Text = qwe;
        //}
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Status == 1)
            {
                serialPort1.Write(e.KeyChar.ToString());
            }
        }

        private void menuItem2_Click(object sender, EventArgs e)   //Connect
        {
            MessageBox.Show(SIMno);

           // if (Status == 0)
            //{


            //if (SensorFlag1 == 1)
            //{
            //    textBox4.Text = ExpectedPacket1;
            //}
            //else
            if (ExpectedPacket1 == null)
            {
                textBox4.Text = "TPxx.yPHxx.yyDOxx.yyECxxx.yTDxxxxxxORxxxx.y";
            }
            else
            {
                packetChange = 1;
                textBox4.Text = ExpectedPacket1;
            }
            
                serialPort1.PortName = "COM1";   //33

            ////////string[] ports = SerialPort.GetPortNames();
            ////////foreach (string str in ports)
            ////////{
            ////////    try
            ////////    {
            ////////        serialPort1.PortName = str;
            ////////        serialPort1.Open();
            ////////        serialPort1.Write("+++");
            ////////        Thread.Sleep(20000);
            ////////        String readyOK = (serialPort1.ReadExisting()).ToString();
            ////////        Thread.Sleep(1000);
            ////////        MessageBox.Show(readyOK);
            ////////        string[] n = new string[readyOK.Length];
            ////////        for (int i = 0; i < readyOK.Length; i++)
            ////////        {
            ////////            n[i] = readyOK[i].ToString();
            ////////        }
            ////////        if (n[0] == "O")
            ////////        {
            ////////            MessageBox.Show("ZigBee is connected to " + str);
            ////////        }
            ////////    }
            ////////    catch (Exception ex)
            ////////    {
            ////////        //MessageBox.Show("Error in opening/writing to serial port :: " + ex.Message, "Error!");
            ////////        ;
            ////////    }
        ////////////        serialPort1.Close();
        ////////////}
                serialPort1.Open();
                Status = 1;
                this.Text = "Serial port is opened...!";
                serialPort1.Write("+++");
                Thread.Sleep(2000);
                serialPort1.Write("atnd\r\n");
                Thread.Sleep(5000);

                rece = (serialPort1.ReadExisting()).ToString();
                textBox1.Text += rece;

                this.Invoke(new EventHandler(delegate
                {
                    button3_Click(sender,e);
                }));
                //serialPort1.Write("atcn\r\n");
                //Thread.Sleep(5000);
                //serialPort1.Write(":)....:)");
                //Thread.Sleep(3000);
                //String read = (serialPort1.ReadExisting()).ToString();
                //Thread.Sleep(1000);
                //MessageBox.Show(read,"atnd response");
                //textBox1.Clear();

                //System.Threading.Thread.Sleep(10);
                //serialPort1.Write("atnd\r\n");
                //System.Threading.Thread.Sleep(10);
                //string str = serialPort1.ReadExisting();
                //MessageBox.Show(str);
                /*string OKReceived = textBox1.Text;
                //string OKReceived = OKReceived1.Substring(0, 1);
                if (PassValue1 != null)
                {
                    PassValue1(OKReceived);
                }

                if (OKReceived != "OK1")
                {
                    //textBox1.Clear();
                    serialPort1.Write("atnd\r\n");
                    //MessageBox.Show("neeri");
                }*/
                //System.Threading.Thread.Sleep(100);
                //serialPort1.Write("atnd\r\n");

                /* string ATStart = "+++";
            serialPort1.WriteLine(ATStart);
            textBox1.Text(ATStart);
            System.Threading.Thread.Sleep(10);
            string ReceiveOK = textBox1.Text;
            if (ReceiveOK == "+++OK")
            {
                //textBox1.Clear();
                serialPort1.WriteLine("atnd");
            }*/


                //serialPort1.NewLine;
                // serialPort1.BaudRate = 9600;

                // serialPort1.PortName = "COM1";
            }
        //}

        private void invoke(object button3_Click)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            if (Status == 1)
            {
                serialPort1.Close();
                Status = 0;
                this.Text = "Serial port is closed...!";
                //textBox1.Clear();
                

            }
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            readMsg = (serialPort1.ReadExisting()).ToString();
            MessageBox.Show(readMsg);
            this.Invoke(new EventHandler(delegate
            {
                if (readMsg.Equals("\n") || readMsg.Equals("\r"))
                {
                    readMsg = "\r\n";
                }
                this.textBox1.Text += readMsg;
                this.textBox1.SelectionStart = this.textBox1.TextLength;
                this.textBox1.ScrollToCaret();
            }));
        }
        //send
        private void button3_Click(object sender, EventArgs e)
        {
            
            string Receive = "";
            Receive = textBox1.Text;             // here
            //if (PassValue1 != null)
            //{
            //    PassValue1(Receive);
            //}

            // to calculate number of nodes in network
            string[] a1 = new string[Receive.Length];     //replace Packet by message
            for (int i1 = 0; i1 < Receive.Length; i1++)
            {
                a1[i1] = Receive[i1].ToString();
                //MessageBox.Show(a1[i1]);
            }
            int i2 = 0;
            k = true;
            n = 0;
            n1 = 0;
            na = 0;
            m = 0;
            while (k)
            {
                for (i2 = n + 3; i2 < (n + 3 + 30); i2++)
                {
                    if (a1[n + 3] != "F")//|| a1[n] == "=")
                    {
                        k = false;
                        break;
                    }
                } n = n + 30; m++;
            }

            //string[] row = new string[] { node1, MAC1 };
            //dataGridView1.Rows.Add(row);
            //string[] row1 = new string[] { node2, MAC2 };
            //dataGridView1.Rows.Add(row1);
            //string[] row2 = new string[] { node3, MAC3 };
            //dataGridView1.Rows.Add(row2);                                 

            //sorting starts here
            string[] y = new string[Receive.Length];     //replace Packet by message
            for (int i = 0; i < Receive.Length; i++)
            {
                y[i] = Receive[i].ToString();
            }

            for (int b1 = 0; b1 < m - 1; b1++)
            {   //select only node number i.e. 1 from N001 and so on
                nodeDigit = Receive.Substring(29 + n1, 2);
                //nodeTen = Receive.Substring(2+n1,1) 
                n1 = n1 + 30;
                nodeD1 += nodeDigit;
            }
            //MessageBox.Show(nodeD1);

            string[] b2 = new string[nodeD1.Length];
            for (int i = 0; i < nodeD1.Length; )
            {
                b2[i] = nodeD1[i].ToString();
                b2[i + 1] = nodeD1[i + 1].ToString();
                i = i + 2;
            }

            int[] w = new int[(m - 1) * 32];
            int[] w1 = new int[(m - 1) * 32];
            for (int i = 0, j = 0; i < nodeD1.Length; j++)
            {
                w[i] = Convert.ToInt32(b2[i]);
                w[i + 1] = Convert.ToInt32(b2[i + 1]);
                w1[j] = 10 * w[i] + w[i + 1];
                i = i + 2;
            }

            int temp;
            for (int i = 0; i <= (m - 1 - 2); i++)
            {
                for (int j = 0; j <= ((m - 1 - 2) - i); j++)
                {
                    if (w1[j] > w1[j + 1])
                    {
                        temp = w1[j];
                        w1[j] = w1[j + 1];
                        w1[j + 1] = temp;
                    }
                }
            }
            //string myString = w1[4].ToString();
            //MessageBox.Show(myString);

            for (int i = 0; i < m - 1; i++)
            {
                wTen[i] = w1[i] / 10;
                wUnit[i] = w1[i] % 10;
                w1Ten[i] = wTen[i].ToString();
                w1Unit[i] = wUnit[i].ToString();
            }

            for (int i1 = 0; i1 < m - 1; i1++)                    //packetization of other factors along with node eg.dh,dl,etc
            {
                c = m - 1;
                while (c != 0)   //position
                {
                    if (w1Unit[i1] == y[30 + s] && w1Ten[i1] == y[29 + s])   //20, 19
                    {
                        for (v = p, u = s + 3; u < 30 + 3 + s; u++, v++)
                        {
                            q[v] = y[u];
                        }
                        p = p + 30;
                        c--;
                        s = 0;
                        break;
                    }
                    else
                    {
                        s = s + 30;
                    }
                }//c=t;
            }
            Receive1 = ConvertStringArrayToString(q);
            //string m1 = m.ToString();
            //MessageBox.Show(m1);

            if (message != null)
                message = "";
            for (int b = 0; b < m - 1; b++)
            {
                string MAC1 = Receive1.Substring(5 + na, 15);   //17    H 8 to 13 ; L 15 to 22 
                string node1 = Receive1.Substring(24 + na, 4);   //36
                string high1 = Receive1.Substring(5 + na, 6);
                MessageBox.Show(high1, "high");

                string low1 = Receive1.Substring(12 + na, 8);
                MessageBox.Show(low1, "low");
                HMac = new string[1] { high1 };
                LMac = new string[1] { low1 };
                // MessageBox.Show(HMac[b],"hmac");
                //MessageBox.Show(LMac[b],"lmac");
                Thread.Sleep(1000);
                serialPort1.Write("+++");
                //Thread.Sleep(2000);
                serialPort1.Write("atdh");
                //serialPort1.Write(HMac[b]);
                serialPort1.Write(high1);
                serialPort1.Write("\r\n");
                // Thread.Sleep(5000);
                serialPort1.Write("atdl");
                //serialPort1.Write(LMac[b]);
                serialPort1.Write(low1);
                serialPort1.Write("\r\n");
                // Thread.Sleep(5000);
                serialPort1.Write("atcn\r\n");
                // Thread.Sleep(5000);
                //  serialPort1.Write("ready?");
                //  Thread.Sleep(5000);
                // String OKRec = (serialPort1.ReadExisting()).ToString();
                // Thread.Sleep(10000);
                //if (OKRec == "OK")
                //{
                //    MessageBox.Show("OK received");
                //    serialPort1.Write("u r Ready?");
                //}
                ////Thread.Sleep(10000);
                //         String readyMsg = (serialPort1.ReadExisting()).ToString();
                //         Thread.Sleep(1000);
                // serialPort1.Write("+++");
                // Thread.Sleep(1000);
                //string readyMsg = "QWE";
                //         MessageBox.Show(readyMsg);

                //if (readyMsg == "OK")
                // {
                // serialPort1.Write(readMsg);
                serialPort1.Write("\r\nsend data");
                Thread.Sleep(30000);
                message = (serialPort1.ReadExisting()).ToString();
                //Thread.Sleep(25000);    //earlier 10000
                //MessageBox.Show(message,"message");
                Thread.Sleep(1000);    //earlier 10000
                //MessageBox.Show(message1, "message1");

                timestamp = DateTime.Now.ToString("HH:mm:ss <dd-MM-yyyy>");  //yyyyMMddHHmmssfff
                timeDate = DateTime.Now.ToString("ddMMyyyyHHmm");

                Thread.Sleep(1000);

                string[] a = new string[message.Length];     //replace Packet by message
                for (int i = 0; i < message.Length; i++)
                {
                    a[i] = message[i].ToString();
                }
                //string[] bn = new string[sensInit1.Length];     //sensor initials
                //for (int i = 0; i < sensInit1.Length; i++)
                //{
                //    bn[i] = sensInit1[i].ToString();
                //}
                //int seneNo = sensInit1.Length;
                //int nw;
                //string[] c = new string[beforeDot1.Length];
                //for (int i = 0; i < beforeDot1.Length; i++)
                //{
                //    c[i] = beforeDot1[i].ToString();
                //}

                //string[] d = new string[afterDot1.Length];
                //for (int i = 0; i < afterDot1.Length; i++)
                //{
                //    d[i] = afterDot1[i].ToString();
                //}
                ////if (packetChange == 1)
                ////{
                ////    for (n = 0, nw = 0; n < seneNo * 2; nw++)
                ////    {
                ////        for (int i = 0; i < message.Length; i++)
                ////        {
                ////            //TP50.1PH14.01DO50.01EC200.0TD100000OR2000.1
                ////            if (a[i] == bn[n] && a[i + 1] == bn[n + 1])
                ////            //if (a[i] == "T" && a[i + 1] == "P")
                ////            {
                ////                for (int j = i; j < i + 2 + Convert.ToInt32(c[nw]) + 1 + Convert.ToInt32(d[nw]); j++)
                ////                {
                ////                    //Temp = a[i + 2] + a[i + 3] + a[i + 4] + a[i + 5];
                ////                    //Temp += a[j];
                ////                    // sensors[nw] += a[j];
                ////                    dfgh += a[j];
                ////                }
                ////            }
                ////        }


                ////        n = n + 2;

                ////    }
                ////    MessageBox.Show(dfgh);
                ////}

                //else
                //{

                    //   for (n = 0, nw = 0; n < seneNo; nw++)
                    //{
                        for (int i = 0; i < message.Length; i++)
                        {
                            //TP50.1PH14.01DO50.01EC200.0TD100000OR2000.1
                            if (a[i] == "T" && a[i + 1] == "P")
                            {
                                Temp = a[i + 2] + a[i + 3] + a[i + 4] + a[i + 5];
                            }

                            if (a[i] == "P" && a[i + 1] == "H")
                            {
                                pH = a[i + 2] + a[i + 3] + a[i + 4] + a[i + 5] + a[i + 6];
                            }
                            if (a[i] == "D" && a[i + 1] == "O")
                            {
                                DO = a[i + 2] + a[i + 3] + a[i + 4] + a[i + 5] + a[i + 6];
                            }
                            if (a[i] == "E" && a[i + 1] == "C")
                            {
                                EC = a[i + 2] + a[i + 3] + a[i + 4] + a[i + 5] + a[i + 6];
                            }
                            if (a[i] == "T" && a[i + 1] == "D")
                            {
                                TD = a[i + 2] + a[i + 3] + a[i + 4] + a[i + 5] + a[i + 6] + a[i + 7];
                            }
                            if (a[i] == "O" && a[i + 1] == "R")
                            {
                                OR = a[i + 2] + a[i + 3] + a[i + 4] + a[i + 5] + a[i + 6] + a[i + 7];
                            }
                            //if new sensor string is received 
                            //if (a[i] != "P" && a[i] != "T" && a[i] != "D" && a[i] != "E" && a[i] != "H" && a[i] != "O" && a[i] != "C" && a[i] != "R" && a[i] != "." && a[i] != "0" && a[i] != "1" && a[i] != "2" && a[i] != "3" && a[i] != "4" && a[i] != "5" && a[i] != "6" && a[i] != "7" && a[i] != "8" && a[i] != "9")
                            //{
                            //    arya = a[i + 1] + a[i + 2] + a[i + 3] + a[i + 4];
                            //    aryaHead = a[i];
                            //    //dataGridView1.Columns.Add(a[i], a[i]);     // to create new column in dataGrid, a[i] is heading
                            //}
                        }
                        //string[] row1 = new string[] { "Node", "MAC ID", "Temperature", "pH", "Time Stamp" };
                        //dataGridView1.Rows.Add(row1);
                        // row = new string[] { node1, MAC1, Temp, pH, timestamp, arya };
                        //row = new string[] { "\r\n",node1, MAC1, Temp, pH, timestamp };
                        row = new string[] { "\r\n", node1, high1 + low1, Temp, pH, timestamp };
                        // row = new string[] { Temp, pH, timestamp };
                        //string[] row = new string[] { node1,MAC1,message, timestamp};
                        //dataGridView1.Rows.Add(row);
                        if (colNo == 1)
                        {
                            table.Columns.Add(".", typeof(string));
                            table.Columns.Add("Node  ", typeof(string));
                            table.Columns.Add("Mac ID                ", typeof(string));
                            table.Columns.Add("Temp ", typeof(string));
                            table.Columns.Add("pH   ", typeof(string));
                            table.Columns.Add("Timestamp", typeof(string));
                            
                            //table.Columns.Add("extra", typeof(string));
                            colNo--;
                        }


                        table.Rows.Add(row);
                        row = null;
                        //AllRow1[b] = row[0] + row[1] + row[2] + row[3] + row[4] + row[5] + "\r\n";
                        //MessageBox.Show(AllRow);
                        if (nodes != null)
                        {
                            nodes = "";
                        }
                        if (nodesPacket != null)
                        {
                            nodesPacket = "";
                        }
                        nodes += node1 + ":" + high1 + low1 + "\r\n";
                        nodesPacket += node1 + "\n" + "TP" + Temp + " pH" + pH + " DO" + DO + " EC" + EC + " TD" + TD + " OR" + OR + "\n";
                        serialPort1.Write("+++");
                        na = na + 30;

                   // }
               // }
                serialPort1.Close();
                MessageBox.Show("its time to display");
                //textBox1.Text.Remove(0, textBox1.Text.Length);
                if (textBox1 != null)
                    textBox1.Text = "";
                //foreach (DataColumn column in table.Columns)
                //{
                //    textBox1.Text += column.ToString() + " ";
                //}
                //foreach (DataRow row in table.Rows)
                //{
                //    //Console.WriteLine();
                //    for (int x = 0; x < table.Columns.Count; x++)
                //    {
                //        // Console.Write(row[x].ToString() + " ");
                //        textBox1.Text += row[x].ToString() + " ";
                //        //MessageBox.Show(row[x].ToString() + " ");
                //        //ExportToExcel(System.Data.DataTable table, @"C:\Users\AMIT\Desktop");
                //    }
                //}
                dataGrid1.DataSource = table;

                //DataObject data = dataGrid1.GetClipboardContent();
                //DataObject data1 = dataGrid1.Ge
                MessageBox.Show(nodes, "nodes");
                MessageBox.Show(nodesPacket, "nodesPacket");
                // AllRow1 = "neeri" + AllRow;
                //   MessageBox.Show(AllRow1[0] + AllRow1[1]);


                // MessageBox.Show("yup...its broken...!");


                /* string[] row = new string[] { node1, MAC1 };
                 dataGridView1.Rows.Add(row);
                 string[] row1 = new string[] { node2, MAC2 };
                 dataGridView1.Rows.Add(row1); */
                //serialPort1.Close();


                this.Invoke(new EventHandler(delegate
                    {
                        // menuItem2_Click(sender, e);
                        button5_Click(sender, e);              //time geing its 5
                    }));
            }
        }

        //private void copy()
        //{
        //    //dataGrid1.Select();
        //    dataGridView1.SelectAll();
        //    DataObject data = dataGridView1.GetClipboardContent();
            
        //    if (data != null)
        //        Clipboard.SetDataObject(data);
        //}

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    copy();
        //    string time = DateTime.Now.ToString("dd_MM_yyyy HH_mm_ss");
        //    //string excelFile = @"C:\WSNResponse\new.xls";
        //    Microsoft.Office.Interop.Excel.Application xlexcel;
        //    Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
        //    Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
        //    object misValue = System.Reflection.Missing.Value;
        //    xlexcel = new Microsoft.Office.Interop.Excel.Application();
        //    xlexcel.Visible = true;

        //    xlWorkBook = xlexcel.Workbooks.Add(misValue);
        //    xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
        //    Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[2, 1];
        //    CR.Select();
        //    xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        //    Microsoft.Office.Interop.Excel.Range C1 = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 2];
        //    //Microsoft.Office.Interop.Excel.Range c1 = xlWorkSheet.get_Range("A1");
        //    C1.Value2 = "Node";
        //    Microsoft.Office.Interop.Excel.Range C2 = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 3];
        //    C2.Value2 = "MAC ID";
        //    Microsoft.Office.Interop.Excel.Range C3 = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 4];
        //    C3.Value2 = "Temperature";
        //    Microsoft.Office.Interop.Excel.Range C4 = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 5];
        //    C4.Value2 = "pH";
        //    Microsoft.Office.Interop.Excel.Range C5 = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 6];
        //    C5.Value2 = "Timestamp";
        //    Microsoft.Office.Interop.Excel.Range C6 = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 7];
        //    C6.Value2 = aryaHead;  //arya;
        //    //xlexcel.Save(@"C:\WSNResponse");
        //    //xlexcel.Save();
        //    //     xlWorkSheet.Shapes.AddPicture(@"C:\Users\AMIT\Documents\Visual Studio 2005\Projects\day2_1 - Copy (2) working - try1 - in sequence\day2_1\neeri logo.jpg",true , true, 100, 100, 70, 70);
        //    // Microsoft.Office.Interop.Excel.Range picPosition = xlWorkSheet.Cells[10,10];
        //    // Microsoft.Office.Interop.Excel.Picture nee = xlWorkSheet.Pictures(System.Reflection.Missing.Value);
        //    // Microsoft.Office.Interop.Excel.Picture neepic = nee

        //    //xlWorkBook.Close(Type.Missing);
        //    //xlexcel.Quit();

        //    //xlWorkBook.SaveAs(@"C:\WSNResponse\DataRecord.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
        //    xlWorkBook.SaveAs(@"C:\WSNResponse\" + "Sensor Readings at " + time /*+ "DataRecord.xls"*/, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
        //    chartPage.Export(@"C:\excel_chart_export.bmp", "BMP", misValue);
        //    xlWorkBook.Close(true, misValue, misValue);
        //    xlexcel.Quit();


        //    MessageBox.Show("Excel file created , you can find the file C:WSNResponse");
        //}

        static string ConvertStringArrayToString(string[] array)
        {
            //
            // Concatenate all the elements into a StringBuilder.
            //
            StringBuilder builder = new StringBuilder();
            foreach (string value in array)
            {
                builder.Append(value);
                //builder.Append('.');
            }
            return builder.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //send nodes info sms
            //byte[] bytesToSend = new byte[1]{0x1A};
            //serialPort1.Close();
            serialPort2.Close();
            serialPort2.PortName="COM6";   //32
            ////////string[] ports1 = SerialPort.GetPortNames();
            ////////foreach (string str1 in ports1)
            ////////{
            ////////    try
            ////////    {
            ////////        //MessageBox.Show(str);
            ////////        serialPort2.PortName = str1;
            ////////        serialPort2.Open();
            ////////        serialPort2.Write("AT\r\n");
            ////////        Thread.Sleep(20000);
            ////////        String readyOK1 = (serialPort2.ReadExisting()).ToString();
            ////////        Thread.Sleep(1000);
            ////////        MessageBox.Show(readyOK1);
            ////////        string[] nn1 = new string[readyOK1.Length];

            ////////        for (int i = 0; i < readyOK1.Length; i++)
            ////////        {
            ////////            nn1[i] = readyOK1[i].ToString();
            ////////        }
            ////////        //if (readyMsg == "OK")
            ////////        if (nn1[0] == "O" || nn1[0] == "A")                      //also check for "0"
            ////////        {
            ////////            MessageBox.Show("GSM Modem is connected to " + str1);
            ////////        }
            ////////        // else
            ////////        //{ MessageBox.Show("no"); }
            ////////    }
            ////////    catch (Exception ex)
            ////////    {
            ////////        //MessageBox.Show("Error in opening/writing to serial port :: " + ex.Message, "Error!");
            ////////        ;
            ////////    }
            ///////}

            serialPort2.Open();
            this.Text = "Serial port is Opened...Sending Node SMS!";
            serialPort2.Write("AT\r\n");
            Thread.Sleep(1000);
            serialPort2.Write("at+cmgf=1\r\n");
            Thread.Sleep(1000);
            serialPort2.Write("at+cmgs=\""+SIMno+"\""+"\r\n");
            //serialPort2.Write("at+cmgs=\"8600361752\"\r\n");   //8600361752  //9422325897   //8806958188
            Thread.Sleep(1000);
            //serialPort2.Write("*CSIR - NEERI WSN SYS*\r\n");
            //serialPort2.Write("*Developed by AID*\r\n");
            //serialPort2.Write(timestamp + "\r\n");       //here
            //serialPort2.Write("*Developed by AID*\r\n");
            //serialPort2.Write("Nodes: ");
            //serialPort2.Write(--m+"\r\n");
            serialPort2.Write("*Developed by AID*\r\n" + timestamp + "\r\n" + "Nodes: " + --m + "\r\n\r\n" + nodesPacket); //here
            serialPort2.Write("Node:  MAC ID\r\n");
            serialPort2.Write(nodes);       //here
            Thread.Sleep(1000);
            serialPort2.Write(bytesToSend,0,1);
            //serialPort2.Write(ch ConvertFromUtf32(26));         
            Thread.Sleep(1000);
            serialPort2.Close();
            this.Text = "Serial port is Closed...Node SMS is sent!";
            this.Invoke(new EventHandler(delegate
               {
                   // menuItem2_Click(sender, e);
                   button6_Click(sender, e);
               }));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //send packet sms
            //serialPort1.Close();
            serialPort2.Close();
            serialPort2.PortName = "COM6";  //32
            //////////string[] ports2 = SerialPort.GetPortNames();
            //////////foreach (string str2 in ports2)
            //////////{
            //////////    try
            //////////    {
            //////////        //MessageBox.Show(str);
            //////////        serialPort2.PortName = str2;
            //////////        serialPort2.Open();
            //////////        serialPort2.Write("AT\r\n");
            //////////        Thread.Sleep(20000);
            //////////        String readyOK2 = (serialPort2.ReadExisting()).ToString();
            //////////        Thread.Sleep(1000);
            //////////        MessageBox.Show(readyOK2);
            //////////        string[] nn2 = new string[readyOK2.Length];
            //////////        for (int i = 0; i < readyOK2.Length; i++)
            //////////        {
            //////////            nn2[i] = readyOK2[i].ToString();
            //////////        }
            //////////        //if (readyMsg == "OK")
            //////////        if (nn2[0] == "O" || nn2[0] == "A")                      //also check for "0"
            //////////        {
            //////////            MessageBox.Show("GSM Modem is connected to " + str2);
            //////////        }
            //////////        // else
            //////////        //{ MessageBox.Show("no"); }
            //////////    }
            //////////    catch (Exception ex)
            //////////    {
            //////////        //MessageBox.Show("Error in opening/writing to serial port :: " + ex.Message, "Error!");
            //////////        ;
            //////////    }
            ///////}

             serialPort2.Open();
            this.Text = "Serial port is Opened...Sending Packet SMS!";
            serialPort2.Write("AT\r\n");
            Thread.Sleep(1000);
            serialPort2.Write("at+cmgf=1\r\n");
            Thread.Sleep(1000);
            serialPort2.Write("at+cmgs=\"" + SIMno + "\"" + "\r\n");
            //serialPort2.Write("at+cmgs=\"8600361752\"\r\n");    //8600361752    //9422325897 //8806958188
            Thread.Sleep(1000);
            //serialPort2.Write("*CSIR - NEERI WSN SYS*\n");
            //MessageBox.Show("*Developed by AID*\r\n" + timestamp + "\r\n" + "Nodes: " + m + "\r\n\r\n" + nodesPacket, "before");
            // serialPort2.Write("*Developed by AID*\r\n" + timestamp + "\r\n" + "Nodes: " + --m + "\r\n");
            //MessageBox.Show("*Developed by AID*\r\n" + timestamp + "\r\n" + "Nodes: " + m + "\r\n\r\n" + nodesPacket,"after");
            serialPort2.Write(timestamp + "\n");
            serialPort2.Write("Nodes: ");
            serialPort2.Write(--m + "\n");
            serialPort2.Write(nodesPacket);
            Thread.Sleep(1000);
           // serialPort2.Write(char.ConvertFromUtf32(26));
            serialPort2.Write(bytesToSend, 0, 1);
            Thread.Sleep(1000);
            serialPort2.Close();
            this.Text = "Serial port is Closed...Packet SMS is sent!";

            this.Invoke(new EventHandler(delegate
               {
                   // menuItem2_Click(sender, e);
                   button10_Click(sender, e);
               }));
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        
        //set Date
        private void button8_Click(object sender, EventArgs e)
        {
            dd = dateTimePicker1.Value.ToString("dd");
            MM = dateTimePicker1.Value.ToString("MM");
            dd1 = dateTimePicker1.Value.ToString("dd");
            MM1 = dateTimePicker1.Value.ToString("MM");
            yyyy = dateTimePicker1.Value.ToString("yyyy");
            Controls.Add(ComboBox1);
            Controls.Add(ComboBox2);
            hours = new string[]{"0", "1","2", "3", "4","5", "6","7", "8", "9","10", "11", "12", 
				"13", "14","15", "16", "17","18", "19", "20","21", "22", "23","24"};
            minute = new string[] {"0", "1","2", "3", "4","5", "6","7", "8", "9","10", "11", "12", 
				"13", "14","15", "16", "17","18", "19", "20","21", "22", "23","24","25", "26","27", "28", "29","30", "31","32", "33", "34","35", "36", "37", 
				"38", "39","40", "41", "42","43", "44", "45","46", "47", "48","49", "50", "51","52", "53", "54","55", "56", "57","58","59"};
            //ComboBox1.Items.AddRange(hours);
            for (int i = 0; i < 24; i++)
                ComboBox1.Items.Add(hours[i]);

            for (int j = 0; j < 60; j++)
                ComboBox2.Items.Add(minute[j]);

            //ComboBox2.Items.AddRange(minute);
            ComboBox1.Location = new System.Drawing.Point(20, 60);
            ComboBox2.Location = new System.Drawing.Point(110, 60);

            //ComboBox1.IntegralHeight = false;
            //ComboBox2.IntegralHeight = false;
            //ComboBox1.MaxDropDownItems = 5;
            //ComboBox2.MaxDropDownItems = 5;
            //ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            //ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox1.Name = "Hours";
            ComboBox2.Name = "Minutes";
            ComboBox1.Size = new System.Drawing.Size(60, 81);
            ComboBox2.Size = new System.Drawing.Size(60, 81);
            ComboBox1.TabIndex = 0;
            ComboBox2.TabIndex = 0;
            ComboBox1.Text = "Hours";
            ComboBox2.Text = "Minutes";
            //Controls.Add(ComboBox1);
            //Controls.Add(ComboBox2);
            //Controls.Add(label1);
            //Controls.Add(label2);
            button8.Dispose();
            //button2.Enabled();

        }
        //Set Period
        private void button9_Click(object sender, EventArgs e)
        {
            HH = ComboBox1.Text;
            mm = ComboBox2.Text;
            string[] d = new string[dd.Length];     //replace Packet by message
            for (int i1 = 0; i1 < dd.Length; i1++)
            {
                d[i1] = dd[i1].ToString();
            }
            if (d[0] == "0")
            {
                dd = d[1];
            }
            string[] M = new string[MM.Length];     //replace Packet by message
            for (int i1 = 0; i1 < MM.Length; i1++)
            {
                M[i1] = MM[i1].ToString();
            }
            if (M[0] == "0")
            {
                MM = M[1];
            }
            HHH = Convert.ToInt32(HH);
            mmm = Convert.ToInt32(mm);
            HHH = HOUR + HHH;
            mmm = MIN + mmm;
            if (mmm >= 60) { mmm = mmm - 60; HHH++; }
            if (HHH >= 24) { mmm = 0; HHH = 0; }

            timecheck();
            button9.Dispose();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            // Alert the user
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            hours1 = DateTime.Now.Hour;
            minutes1 = DateTime.Now.Minute;
            int seconds = DateTime.Now.Second;
            //int milSeconds = DateTime.Now.Millisecond;
            HOUR = hours1;
            MIN = minutes1;
            timeString = day + ":" + month + ":" + year + ":" + hours1 + ":" + minutes1; //+ " : " + seconds; //+ " : " + milSeconds;
            timeStringDisp = day + " : " + month + " : " + year + "  ::  " + hours1 + " : " + minutes1 + " : " + seconds; //+ " : " + milSeconds;
            if (setTimeDisp == timeStringDisp)
            {
                HHH1 = Convert.ToInt32(HH);
                mmm1 = Convert.ToInt32(mm);
                int H1 = Convert.ToInt32(HHH1);
                int m1 = Convert.ToInt32(mmm1);
                HHH1 = HOUR + H1;
                mmm1 = MIN + m1;

                if (mmm1 >= 60) { mmm1 = mmm1 - 60; HHH1++; }
                if (HHH1 >= 24) { mmm1 = 0; HHH1 = 0; }
                string HH1 = Convert.ToString(HHH1);
                string mm1 = Convert.ToString(mmm1);
                setTimeDisp = dd + " : " + MM + " : " + yyyy + "  ::  " + HH1 + " : " + mm1 + " : " + "0";
                textBox2.Text = setTimeDisp;

                
                this.Invoke(new EventHandler(delegate
                {
                    menuItem2_Click(sender, e);
                }));

            }
            
                textBox3.Text = timeStringDisp;
            

        }

        private void timecheck()
        {
            string HHn = Convert.ToString(HHH);
            string mmn = Convert.ToString(mmm);
            setTime = dd + ":" + MM + ":" + yyyy + ":" + HH + ":" + mm;
            setTimeDisp = dd + " : " + MM + " : " + yyyy + "  ::  " + HHn + " : " + mmn + " : " + "0";
            textBox2.Text = setTimeDisp;
        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            //SensorFlag = 1;
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void menuItem6_Click(object sender, EventArgs e)
        {
            this.Invoke(new EventHandler(delegate
                {
                    menuItem2_Click(sender, e);
                }));
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_ParentChanged(object sender, EventArgs e)
        {

        }
        //to copy table to hidden textbox
        private void button10_Click(object sender, EventArgs e)
        {
            foreach (DataColumn column in table.Columns)
            {
                textBox5.Text += column.ToString() + " ";
            }
            foreach (DataRow row in table.Rows)
            {
                //Console.WriteLine();
                for (int x = 0; x < table.Columns.Count; x++)
                {
                    // Console.Write(row[x].ToString() + " ");
                    textBox5.Text += row[x].ToString() + " ";
                    //MessageBox.Show(row[x].ToString() + " ");
                    //ExportToExcel(System.Data.DataTable table, @"C:\Users\AMIT\Desktop");
                }
            }

            string ReceiveNew = textBox5.Text;
            //System.IO.File.WriteAllText(@"C:\NeerajTry\text2.txt", Receive);
            MessageBox.Show(ReceiveNew);
            string time = DateTime.Now.ToString("dd_MM_yyyy HH_mm_ss");
            //System.IO.StreamWriter sw = new System.IO.StreamWriter(@"C:\NeerajTry\" + "Sensor Readings at " + time + ".txt");
            System.IO.StreamWriter sw = new System.IO.StreamWriter(@"\NandFlash\NEERI WSN" + "Sensor Readings at " + time + ".txt");
            sw.Write(ReceiveNew);
            sw.Close();
            textBox5.Text = "";
            //this.Invoke(new EventHandler(delegate
            //        {
            //            // menuItem2_Click(sender, e);
            //            button5_Click(sender, e);              //time geing its 5
            //        }));
        }
        //contact no
        private void menuItem7_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SIMno = textBox6.Text;
            //MessageBox.Show(SIMno);
        }

        ////////////reset
        //////////private void button7_Click(object sender, EventArgs e)
        //////////{
        //////////    InitializeComponent();
        //////////    timer.Tick += new EventHandler(timer_Tick); // Everytime timer ticks, timer_Tick will be called
        //////////    timer.Interval = (60) * (1);             // Timer will tick evert 10 seconds
        //////////    timer.Enabled = true;                       // Enable the timer
        //////////    // timer.Start();
        //////////    colNo = 1;
        //////////    textBox1.Text = "";
        //////////    textBox2.Text = "";
        //////////    textBox3.Text = "";
        //////////    textBox4.Text = "";
        //////////    textBox5.Text = "";


        //////////}

       
       

        
        
    }
}