using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gold1.BL;
using gold1.PL;
using System.Data.SqlClient;
using gold1;
using gold1.BL;

namespace Gold.PL
{
    public partial class FRM_ITEMS : Form
    {
        CLS_CAT cat = new CLS_CAT();
        CLS_ITEM item = new CLS_ITEM();
        SerialPort ComPort = new SerialPort();

        internal delegate void SerialDataReceivedEventHandlerDelegate(object sender, SerialDataReceivedEventArgs e);
        internal delegate void SerialPinChangedEventHandlerDelegate(object sender, SerialPinChangedEventArgs e);
        private SerialPinChangedEventHandler SerialPinChangedEventHandler1;
        delegate void SetTextCallback(string text);
        string InputData = String.Empty;


        public FRM_ITEMS()
        {
            // SerialPinChangedEventHandler1 = new SerialPinChangedEventHandler(PinChanged);
            ComPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(port_DataReceived_1);
            //btnPortState_Click();
            InitializeComponent();
            textBox1.Focus();
        }


        private void port_DataReceived_1(object sender, SerialDataReceivedEventArgs e)
        {
            InputData = ComPort.ReadExisting();
            if (InputData != String.Empty)
            {
                this.BeginInvoke(new SetTextCallback(SetText), new object[] { InputData });
            }
        }
        String g = "";
        private void SetText(string text)
        {

            string temp = text;
            text = g + text;
            var f = fix(text);
            g = temp;
         
            if (f == null)
                Weight.Text = "000";
            else
                Weight.Text = f;
        
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            String bar = textBox2.Text;

            Zen.Barcode.Code128BarcodeDraw brCode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            pictureBox2.Image = brCode.Draw(bar, 128);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != String.Empty || textBox1.Text != String.Empty)
            {
                MemoryStream ms = new MemoryStream();
                pictureBox2.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] image = ms.ToArray();

                item.itemEdit(Convert.ToInt32(textBox6.Text),textBox1.Text,textBox2.Text, image, Convert.ToSingle(textBox3.Text), Convert.ToInt32(textBox4.Text), Convert.ToSingle(textBox5.Text),comboBox1.Text,checkBox1.Checked);
                MessageBox.Show("تم تعديل مصاغ بنجاح");
                textBox1.Text = String.Empty;
                textBox2.Text = String.Empty;
                textBox3.Text = String.Empty;
                textBox4.Text = String.Empty;
                textBox5.Text = String.Empty;
                textBox6.Text = String.Empty;
               
            }
            else
            {
                MessageBox.Show("المعلومات المدخلة ليست كافية");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != String.Empty)
            {
                MemoryStream ms = new MemoryStream();
                pictureBox2.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] image = ms.ToArray();

                item.itemDelete(Convert.ToInt32(textBox6.Text));
                MessageBox.Show("تم حذف مصاغ بنجاح");
                textBox1.Text = String.Empty;
                textBox2.Text = String.Empty;
                textBox3.Text = String.Empty;
                textBox4.Text = String.Empty;
                textBox5.Text = String.Empty;
                textBox6.Text = String.Empty;
                
            }
            else
            {
                MessageBox.Show("المعلومات المدخلة ليست كافية");
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Random code = new Random();
                textBox2.Text = code.Next(1000000 , 9999999).ToString();


                String bar = textBox2.Text;

                Zen.Barcode.Code128BarcodeDraw brCode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                pictureBox2.Image = brCode.Draw(bar, 128);
                textBox3.Focus();
            }
        }

        private void FRM_ITEMS_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            DataTable dtt = cat.catSelect1();
            AutoCompleteStringCollection datasource1 = new AutoCompleteStringCollection();
            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                datasource1.Add(dtt.Rows[i][1].ToString());
            }
            this.textBox7.AutoCompleteCustomSource = datasource1;
            this.textBox7.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.textBox7.AutoCompleteMode = AutoCompleteMode.SuggestAppend;


        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != String.Empty)
            {
                MemoryStream ms = new MemoryStream();
                pictureBox2.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] image = ms.ToArray();
                DataTable dt = cat.catSelect3(textBox7.Text);
                Int32 ID = Convert.ToInt32(dt.Rows[0][0].ToString());
                item.itemAdd(textBox1.Text, textBox2.Text, image, Convert.ToSingle(textBox3.Text), Convert.ToInt32(textBox4.Text), Convert.ToSingle(textBox5.Text), comboBox1.Text,checkBox1.Checked,ID);
                MessageBox.Show("تم إضافة مصاغ بنجاح");
                textBox1.Text = String.Empty;
               // textBox2.Text = String.Empty;
                textBox3.Text = String.Empty;
                textBox4.Text = String.Empty;
                textBox5.Text = String.Empty;
            }
            else
            {
                MessageBox.Show("المعلومات المدخلة ليست كافية");
            }





            //////////ahmad////////////
           SqlConnection co = new SqlConnection();
            //String connectionString = @"Data Source=FLAMINGO\SQLEXPRESS;AttachDbFilename=D:\Yakdi\gold\gold.mdf;Integrated Security=True;User ID=sa; password=12345678;database=gold";
            co.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Yakdi\gold\gold.mdf;Integrated Security=True;database=gold";
            // co.ConnectionString = connectionString;
            String code = textBox2.Text;
            String sq = "select * from items where code ='" + code + "'";
            DataSet22 ds = new DataSet22();
            SqlDataAdapter dad = new SqlDataAdapter(sq, co);
            dad.Fill(ds.Tables["items"]);
            CrystalReport1 em = new CrystalReport1();
            em.SetDataSource(ds.Tables["items"]);


            em.PrintOptions.PrinterName = "ZDesigner ZD220-203dpi ZPL";
            em.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
     
            em.PrintToPrinter(1, false, 0, 0);

            /////////////////////
            textBox4.Text = "21";
            textBox1.Focus();
            //FRM_PRINT1 P = new FRM_PRINT1(textBox2.Text);
            //P.Show();
        }
        public String fix(String t)
        {

            var a = t.Replace(" ", "");
            var b = a.Replace("\n", "");
            var c = b.Replace("g", "");
            var d = c.Replace("\r", "");
            return d;
        }
        private void btnGetSerialPorts_Click(object sender, EventArgs e)
        {
            //ComPort.PortName = Convert.ToString(cboPorts.Text);
            //ComPort.BaudRate = Convert.ToInt32(cboBaudRate.Text);
            //ComPort.DataBits = Convert.ToInt16(cboDataBits.Text);
            //ComPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cboStopBits.Text);
            //ComPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), cboHandShaking.Text);
            //ComPort.Parity = (Parity)Enum.Parse(typeof(Parity), cboParity.Text);
            //ComPort.Open();

            try
            {

                string[] ArrayComPortsNames = null;
                int index = -1;
                string ComPortName = null;

                //Com Ports
                ArrayComPortsNames = SerialPort.GetPortNames();
                do
                {
                    index += 1;
                    cboPorts.Items.Add(ArrayComPortsNames[index]);


                } while (!((ArrayComPortsNames[index] == ComPortName) || (index == ArrayComPortsNames.GetUpperBound(0))));
                Array.Sort(ArrayComPortsNames);

                if (index == ArrayComPortsNames.GetUpperBound(0))
                {
                    ComPortName = ArrayComPortsNames[0];
                }
                //get first item print in text
                cboPorts.Text = ArrayComPortsNames[0];




                ComPort.PortName = Convert.ToString(cboPorts.Text);
                ComPort.BaudRate = Convert.ToInt32("9600");
                ComPort.DataBits = Convert.ToInt16("8");
                ComPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                ComPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), "None");
                ComPort.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
                ComPort.Open();

            }
            catch
            {
                MessageBox.Show("Please connect the Mizan");
            }
        }
        
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
               
               
            }
        }

        private void but_Click_1(object sender, EventArgs e)
        {
            textBox3.Text = Weight.Text;
        }

        private void FRM_ITEMS_FormClosing(object sender, FormClosingEventArgs e)
        {
            ComPort.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox5.Focus();
                comboBox1.SelectedIndex = 1;
            }
            }

        private void FRM_ITEMS_Shown(object sender, EventArgs e)
        {
            textBox1.Focus();

        }

        private void Weight_Click(object sender, EventArgs e)
        {

        }

       
        
        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                DataTable dt = cat.catSelect3(textBox7.Text);
                textBox5.Text = dt.Rows[0][2].ToString();
                textBox1.DataSource = item.itemSelect5(textBox7.Text);
                textBox1.DisplayMember = "name";
                textBox1.ValueMember = "ID";
            }
        }
    }
}
