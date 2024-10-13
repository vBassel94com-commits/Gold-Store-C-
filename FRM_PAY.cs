using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gold1.BL;
using Gold.PL;
using System.IO.Ports;
using gold1.BL;

namespace gold1.PL
{
    public partial class FRM_PAY : Form
    {
        CLS_JEWELER j = new CLS_JEWELER();
        CLS_PAYMENTS p = new CLS_PAYMENTS();
        CLS_CUSTOMERACCOUNT ca = new CLS_CUSTOMERACCOUNT();
        CLS_CASH cash = new CLS_CASH();
        CLS_VALUE v = new CLS_VALUE();

        SerialPort ComPort = new SerialPort();


        internal delegate void SerialDataReceivedEventHandlerDelegate(object sender, SerialDataReceivedEventArgs e);
        internal delegate void SerialPinChangedEventHandlerDelegate(object sender, SerialPinChangedEventArgs e);
        private SerialPinChangedEventHandler SerialPinChangedEventHandler1;
        delegate void SetTextCallback(string text);
        string InputData = String.Empty;


        public FRM_PAY()
        {
            ComPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(port_DataReceived_1);

            InitializeComponent();
        }

        private void FRM_PAY_Load(object sender, EventArgs e)
        {
            DataTable dtt = j.jewelerSelect();
            AutoCompleteStringCollection datasource1 = new AutoCompleteStringCollection();
            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                datasource1.Add(dtt.Rows[i][1].ToString());
            }
            this.textBox2.AutoCompleteCustomSource = datasource1;
            this.textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.textBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            dataGridView1.DataSource = p.paymentSelect1();
            DataTable d = v.valuesSelect();
            textBox6.Text = d.Rows[0][0].ToString();
            textBox7.Text = d.Rows[0][1].ToString();
            textBox8.Text = d.Rows[0][2].ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DataTable dt = j.jewelerSelect2(textBox2.Text);
            label8.Text = dt.Rows[0][0].ToString();
            p.paymentAdd(Convert.ToDouble(textBox3.Text), 0, Convert.ToDouble(textBox4.Text), 0, Convert.ToDouble(textBox5.Text), 0, Convert.ToInt32(label8.Text), dateTimePicker1.Value);
            dataGridView1.DataSource = p.paymentSelect(Convert.ToInt32(label8.Text));
            DataTable dt1 = p.maxPayment();

            ca.customeraccountAdd(dateTimePicker1.Value, 0, Convert.ToDouble(textBox4.Text) * Convert.ToDouble(textBox1.Text), 0, Convert.ToDouble(textBox4.Text), "استلام دفعة", Convert.ToInt32(label8.Text), Convert.ToInt32(dt1.Rows[0][0].ToString()));
            cash.cashAdd(dateTimePicker1.Value, Convert.ToDouble(textBox4.Text) * Convert.ToInt32(textBox1.Text), 0, Convert.ToDouble(textBox3.Text), 0, Convert.ToDouble(textBox4.Text), 0, Convert.ToDouble(textBox5.Text), 0, Convert.ToInt32(dt1.Rows[0][0].ToString()), Convert.ToInt32(label8.Text), "دفعة استلام");

        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Text = (Convert.ToDouble(textBox3.Text) * Convert.ToSingle(textBox6.Text)).ToString();
                textBox5.Text = ((Convert.ToDouble(textBox4.Text) * Convert.ToSingle(textBox8.Text)) / Convert.ToSingle(textBox7.Text)).ToString();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox5.Text = ((Convert.ToDouble(textBox4.Text) * Convert.ToSingle(textBox8.Text)) / Convert.ToSingle(textBox7.Text)).ToString();
                textBox3.Text = (Convert.ToDouble(textBox4.Text) / Convert.ToSingle(textBox6.Text)).ToString();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Text = Math.Round(((Convert.ToDouble(textBox5.Text) * Convert.ToInt32(textBox7.Text)) / Convert.ToInt32(textBox8.Text)), 2).ToString();
                textBox3.Text = Math.Round((Convert.ToDouble(textBox4.Text) / Convert.ToInt32(textBox6.Text)), 2).ToString();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = j.jewelerSelect2(textBox2.Text);
            label8.Text = dt.Rows[0][0].ToString();
            p.paymentAdd(0, Convert.ToDouble(textBox3.Text), 0, Convert.ToDouble(textBox4.Text), 0, Convert.ToDouble(textBox5.Text), Convert.ToInt32(label8.Text), dateTimePicker1.Value);
            dataGridView1.DataSource = p.paymentSelect(Convert.ToInt32(label8.Text));
            DataTable dt1 = p.maxPayment();

            cash.cashAdd(dateTimePicker1.Value, 0, Convert.ToDouble(textBox4.Text) * Convert.ToInt32(textBox1.Text), 0, Convert.ToDouble(textBox3.Text), 0, Convert.ToDouble(textBox4.Text), 0, Convert.ToDouble(textBox5.Text), Convert.ToInt32(dt1.Rows[0][0].ToString()), Convert.ToInt32(label8.Text), "دفعة تسليم");
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dt = j.jewelerSelect2(textBox2.Text);
                dataGridView1.DataSource = p.paymentSelect(Convert.ToInt32(dt.Rows[0][0].ToString()));
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Yakdi\gold\gold.mdf;Integrated Security=True;database=gold";
            //co.ConnectionString = @"Data Source=FLAMINGO\SQLEXPRESS;AttachDbFilename=D:\Yakdi\gold\gold.mdf;Integrated Security=True;database=gold";
            String sq = "select payments.ID , recieve24 'استلام24',delivery24'تسليم24', recieve21 'استلام21',delivery21'تسليم21',recieve18 'استلام18',delivery18'تسليم18', jewelerName'اسم الصايغ' ,date 'تاريخ الدفعة' from payments inner join jeweler on payments.jewelerID = jeweler.ID where payments.ID = " + Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            DataSet3 ds = new DataSet3();
            SqlDataAdapter dad = new SqlDataAdapter(sq, co);
            dad.Fill(ds.Tables["DataTable1"]);
            CrystalReport4 em = new CrystalReport4();
            em.SetDataSource(ds.Tables["DataTable1"]);

            em.PrintOptions.PrinterName = "HP LaserJet Pro M12w";
            em.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
            em.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
            //   em.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            em.PrintToPrinter(1, false, 0, 0);
            //FRM_PRINT2 PR = new FRM_PRINT2(em);
            //PR.ShowDialog();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == "0")
            {
                label8.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            }
            else
            {
                label8.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            DataTable dt = j.jewelerSelect2(textBox2.Text);
            Int32 jewelerID = Convert.ToInt32(dt.Rows[0][0].ToString());
            if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == "0")
            {
                p.paymentEdit(Convert.ToInt32(label8.Text), 0, Convert.ToDouble(textBox3.Text), 0, Convert.ToDouble(textBox4.Text), 0, Convert.ToDouble(textBox5.Text), jewelerID, dateTimePicker1.Value);
                ca.customeraccountEdit1(dateTimePicker1.Value, Convert.ToDouble(textBox4.Text) * Convert.ToDouble(textBox1.Text), 0, Convert.ToDouble(textBox4.Text), 0, "دفعة تسليم", jewelerID, Convert.ToInt32(label8.Text));
                cash.cashEdit1(dateTimePicker1.Value, 0, Convert.ToDouble(textBox4.Text) * Convert.ToInt32(textBox1.Text), 0, Convert.ToDouble(textBox3.Text), 0, Convert.ToDouble(textBox4.Text), 0, Convert.ToDouble(textBox5.Text), Convert.ToInt32(label8.Text), jewelerID, "دفعة تسليم");
            }
            else
            {
                p.paymentEdit(Convert.ToInt32(label8.Text), Convert.ToDouble(textBox3.Text), 0, Convert.ToDouble(textBox4.Text), 0, Convert.ToDouble(textBox5.Text), 0, jewelerID, dateTimePicker1.Value);
                ca.customeraccountEdit1(dateTimePicker1.Value, 0, Convert.ToDouble(textBox4.Text) * Convert.ToDouble(textBox1.Text), 0, Convert.ToDouble(textBox4.Text), "استلام دفعة", jewelerID, Convert.ToInt32(label8.Text));
                cash.cashEdit1(dateTimePicker1.Value, Convert.ToDouble(textBox4.Text) * Convert.ToInt32(textBox1.Text), 0, Convert.ToDouble(textBox3.Text), 0, Convert.ToDouble(textBox4.Text), 0, Convert.ToDouble(textBox5.Text), 0, Convert.ToInt32(label8.Text), jewelerID, "دفعة استلام");
            }

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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void but_Click(object sender, EventArgs e)
        {

            textBox4.Text = Weight.Text;

            try
            {

                textBox5.Text = Math.Round(((Convert.ToDouble(textBox4.Text) * Convert.ToInt32(textBox8.Text)) / Convert.ToInt32(textBox7.Text)), 2).ToString();
                textBox3.Text = Math.Round((Convert.ToDouble(textBox4.Text) / Convert.ToInt32(textBox6.Text)), 2).ToString();
            }
            catch { }

        }


        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Text = Weight.Text;
            try
            {
                textBox4.Text = Math.Round((Convert.ToDouble(textBox3.Text) * Convert.ToInt32(textBox6.Text)), 2).ToString();
                textBox5.Text = Math.Round(((Convert.ToDouble(textBox4.Text) * Convert.ToInt32(textBox8.Text)) / Convert.ToInt32(textBox7.Text)), 2).ToString();
            }
            catch { }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox5.Text = Weight.Text;
            try
            {
                textBox4.Text = Math.Round(((Convert.ToDouble(textBox5.Text) * Convert.ToInt32(textBox7.Text)) / Convert.ToInt32(textBox8.Text)), 2).ToString();
                textBox3.Text = Math.Round((Convert.ToDouble(textBox4.Text) / Convert.ToInt32(textBox6.Text)), 2).ToString();
            }
            catch { }
        }
    }
}