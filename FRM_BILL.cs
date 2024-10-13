using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gold1.BL;
using System.IO.Ports;
using System.Data.SqlClient;
using gold1;
using gold1.BL;
using GOLD1;
using gold1.PL;



namespace Gold.PL
{
    public partial class FRM_BILL : Form
    {
        SerialPort ComPort = new SerialPort();

      

        internal delegate void SerialDataReceivedEventHandlerDelegate(object sender, SerialDataReceivedEventArgs e);
        internal delegate void SerialPinChangedEventHandlerDelegate(object sender, SerialPinChangedEventArgs e);
        private SerialPinChangedEventHandler SerialPinChangedEventHandler1;
        delegate void SetTextCallback(string text);
        string InputData = String.Empty;



        Int32 jewelerID;
        CLS_BILL b = new CLS_BILL();
        CLS_JEWELER j = new CLS_JEWELER();
        CLS_ITEM item = new CLS_ITEM();
        CLS_ITEMBILL ib = new CLS_ITEMBILL();
        CLS_CUSTOMERACCOUNT ca = new CLS_CUSTOMERACCOUNT();
        CLS_CASH cash = new CLS_CASH();
        CLS_PAYMENTS p = new CLS_PAYMENTS();
        CLS_TOTAL t = new CLS_TOTAL();
        CLS_CAT cat = new CLS_CAT();
        
        
        public FRM_BILL()
        {
            ComPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(port_DataReceived_1);
            InitializeComponent();
        }


        public FRM_BILL(int billid)
        {
            ComPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(port_DataReceived_1);
            InitializeComponent();
            textBox1.Text = billid.ToString();
            //////////////////////


            DataTable dt = b.billSelect(Convert.ToInt32(textBox1.Text));
            if (dt.Rows.Count == 0)
            {
                DataTable dt1 = b.billSelect2(Convert.ToInt32(textBox1.Text));
                if (dt1.Rows.Count == 0)
                {
                    MessageBox.Show("لايوجد فاتورة بهذا الرقم");
                }
                else
                {
                    comboBox1.Text = dt1.Rows[0][1].ToString();
                    dateTimePicker1.Text = dt1.Rows[0][2].ToString();

                    bunifuMaterialTextbox12.Text = dt1.Rows[0][3].ToString();
                    bunifuMaterialTextbox6.Text = dt1.Rows[0][4].ToString();
                    bunifuMaterialTextbox5.Text = dt1.Rows[0][5].ToString();
                    bunifuMaterialTextbox4.Text = dt1.Rows[0][6].ToString();



                    //bunifuMaterialTextbox17.Text = dt1.Rows[0][8].ToString();
                    //bunifuMaterialTextbox23.Text = dt1.Rows[0][9].ToString();
                    dataGridView1.DataSource = ib.billitemsSelect(Convert.ToInt32(textBox1.Text));
                    DataTable dd = t.totalSelect(Convert.ToInt32(textBox1.Text));

                    if (dd.Rows.Count == 0)
                    {

                    }
                    else
                    {
                        textBox4.Text = dd.Rows[0][1].ToString();
                        textBox5.Text = dd.Rows[0][0].ToString();
                    }

                }
            }
            else
            {
                comboBox1.Text = dt.Rows[0][1].ToString();
                dateTimePicker1.Text = dt.Rows[0][2].ToString();
                textBox2.Text = dt.Rows[0][3].ToString();
                textBox3.Text = dt.Rows[0][4].ToString();
                bunifuMaterialTextbox12.Text = dt.Rows[0][5].ToString();
                bunifuMaterialTextbox6.Text = dt.Rows[0][6].ToString();
                bunifuMaterialTextbox5.Text = dt.Rows[0][7].ToString();
                Double total = Convert.ToDouble(bunifuMaterialTextbox6.Text) - Convert.ToDouble(bunifuMaterialTextbox5.Text);
                bunifuMaterialTextbox8.Text = (Math.Round(total, 2)).ToString();
                int total1 = ((int)Math.Round(total * Convert.ToDouble(bunifuMaterialTextbox12.Text) / 500.0)) * 500;
                bunifuMaterialTextbox4.Text = total1.ToString();


                // bunifuMaterialTextbox4.Text = dt.Rows[0][8].ToString();
                dataGridView1.DataSource = ib.billitemsSelect(Convert.ToInt32(textBox1.Text));
                DataTable dd = t.totalSelect(Convert.ToInt32(textBox1.Text));
                textBox4.Text = dd.Rows[0][1].ToString();

                textBox5.Text = dd.Rows[0][0].ToString();
            }







            /////////////////////////
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            b.billAdd1("مبيع", DateTime.Now);
            DataTable dt = b.billSelect1("مبيع");
            textBox1.Text = dt.Rows[0][0].ToString();
            comboBox1.Text = "مبيع";
            dataGridView1.DataSource = ib.billitemsSelect(Convert.ToInt32(textBox1.Text));
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FRM_BILL_Load(object sender, EventArgs e)
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
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dt = j.jewelerSelect2(textBox2.Text);
                jewelerID = Convert.ToInt32(dt.Rows[0][0].ToString());
                textBox3.Text = dt.Rows[0][2].ToString();
                DataTable dd = b.balanceSelect(jewelerID);
                if(dd.Rows.Count == 0)
                {
                    textBox7.Text = "0";
                }
                else
                {
                    textBox7.Text = dd.Rows[0][0].ToString();
                    label14.Text = dd.Rows[0][1].ToString();
                }
              
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            b.billAdd1("شراء", DateTime.Now);
            DataTable dt = b.billSelect1("شراء");
            textBox1.Text = dt.Rows[0][0].ToString();
            comboBox1.Text = "شراء";
            dataGridView1.DataSource = ib.billitemsSelect(Convert.ToInt32(textBox1.Text));
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

            ////////////////added by ahmad//////////////////

            if(Convert.ToDouble(bunifuMaterialTextbox12.Text)==0)
            {
                MessageBox.Show("ادخل سعر غرام الدهب");
                return;
            }
            ////////////////////////




            if (dataGridView1.CurrentRow.Cells[0].Value.ToString() == String.Empty)
            {

            }
            else
            {
                //if (dataGridView1.CurrentRow.Cells[2].Value.ToString() == String.Empty)

                //{

                    String cells = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    DataTable dt;
                    if(comboBox1.Text == "مبيع")
                    {
                      dt = item.itemSearch(cells);
                    }
                    else 
                    {
                      dt = item.itemSearch1(cells);
                    }
                    
                    if (dt.Rows.Count == 0 )
                    {
                        //  MessageBox.Show("لايوجد مادة لها هذا الباركود");

                    }

                    dataGridView1.CurrentRow.Cells[0].Value = dt.Rows[0][0].ToString();
                    dataGridView1.CurrentRow.Cells[1].Value = dt.Rows[0][1].ToString();
                    dataGridView1.CurrentRow.Cells[2].Value = dt.Rows[0][2].ToString();
                    
                    if (dt.Rows[0][6].ToString() == "كاملة")
                    {
                        dataGridView1.CurrentRow.Cells[3].Value = dt.Rows[0][3].ToString();
                        dataGridView1.CurrentRow.Cells[4].Value = dt.Rows[0][4].ToString();
                        dataGridView1.CurrentRow.Cells[5].Value = dt.Rows[0][5].ToString();
                        Double gold = Convert.ToDouble(dataGridView1.CurrentRow.Cells[3].Value) * 1;//الوزن
                         //الوزن * العدد * أجور الصياغة
                        Double draft = Convert.ToDouble(dataGridView1.CurrentRow.Cells[5].Value) * gold;

                        if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value.ToString()) == 21)
                        {
                        Double total = gold + draft;
                        dataGridView1.CurrentRow.Cells[6].Value = Math.Round(total, 2);
                        dataGridView1.CurrentRow.Cells[7].Value = Math.Round(total, 2);
                        dataGridView1.CurrentRow.Cells[8].Value = "لايوجد داعي للتحويل";
                        dataGridView1.CurrentRow.Cells[9].Value = dataGridView1.CurrentRow.Cells[6].Value;
                        }
                        else if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value.ToString()) == 18)
                        {
                        Double total1 = gold + draft;
                        Double totalgold18 = (gold * 18) / 21;
                        Double totaldraft18 = (draft * 18) / 21;
                        Double total18 = totaldraft18 + totalgold18;
                        dataGridView1.CurrentRow.Cells[6].Value = Math.Round(total1, 2);
                        dataGridView1.CurrentRow.Cells[7].Value = Math.Round(total1, 2);
                        dataGridView1.CurrentRow.Cells[8].Value = "تحويل إلى 21";
                        dataGridView1.CurrentRow.Cells[9].Value = Math.Round(total18, 2);
                        }


                    }
                    else if (dt.Rows[0][6].ToString() == "فلت" && dataGridView1.CurrentRow.Cells[3].Value.ToString() == String.Empty)
                    {
                       dataGridView1.CurrentRow.Cells[0].Value = dt.Rows[0][0].ToString();
                       dataGridView1.CurrentRow.Cells[1].Value = dt.Rows[0][1].ToString();
                       dataGridView1.CurrentRow.Cells[2].Value = dt.Rows[0][2].ToString();
                       label15.Text = dt.Rows[0][3].ToString();
                    }
                    else if (dt.Rows[0][6].ToString() == "فلت" && dataGridView1.CurrentRow.Cells[3].Value.ToString() != String.Empty)
                    {
                   
                    dataGridView1.CurrentRow.Cells[4].Value = dt.Rows[0][4].ToString();
                    dataGridView1.CurrentRow.Cells[5].Value = dt.Rows[0][5].ToString();
                    Double gold = Convert.ToDouble(dataGridView1.CurrentRow.Cells[3].Value) * 1;//الوزن
                                                                                                //الوزن * العدد * أجور الصياغة
                    Double draft = Convert.ToDouble(dataGridView1.CurrentRow.Cells[5].Value) * gold;

                    if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value.ToString()) == 21)
                    {
                        Double total = gold + draft;
                        dataGridView1.CurrentRow.Cells[6].Value = Math.Round(total, 2);
                        dataGridView1.CurrentRow.Cells[7].Value = Math.Round(total, 2);
                        dataGridView1.CurrentRow.Cells[8].Value = "لايوجد داعي للتحويل";
                        dataGridView1.CurrentRow.Cells[9].Value = dataGridView1.CurrentRow.Cells[6].Value;
                    }
                    else if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value.ToString()) == 18)
                    {
                        Double total1 = gold + draft;
                        Double totalgold18 = (gold * 18) / 21;
                        Double totaldraft18 = (draft * 18) / 21;
                        Double total18 = totaldraft18 + totalgold18;
                        dataGridView1.CurrentRow.Cells[6].Value = Math.Round(total1, 2);
                        dataGridView1.CurrentRow.Cells[7].Value = Math.Round(total1, 2);
                        dataGridView1.CurrentRow.Cells[8].Value = "تحويل إلى 21";
                        dataGridView1.CurrentRow.Cells[9].Value = Math.Round(total18, 2);
                    }


                }










                //try
                //    {
                //    if (dt.Rows[0][5].ToString() == "كاملة")
                //    {
                //        dataGridView1.CurrentRow.Cells[0].Value = dt.Rows[0][0].ToString();
                //        dataGridView1.CurrentRow.Cells[1].Value = dt.Rows[0][1].ToString();
                //        dataGridView1.CurrentRow.Cells[2].Value = dt.Rows[0][2].ToString();
                //        dataGridView1.CurrentRow.Cells[3].Value = dt.Rows[0][3].ToString();
                //        dataGridView1.CurrentRow.Cells[4].Value = dt.Rows[0][4].ToString();


                //        //الوزن  يعني مصاغ
                //       // Double gold = Convert.ToDouble(dataGridView1.CurrentRow.Cells[3].Value) * 1;
                //        //الوزن * العدد * أجور الصياغة
                //       // Double draft = Convert.ToDouble(dataGridView1.CurrentRow.Cells[5].Value) * gold;

                //        //if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value.ToString()) == 21)
                //        //{
                //        //    Double total = gold + draft;
                //        //    dataGridView1.CurrentRow.Cells[6].Value = Math.Round(total, 2);
                //        //    dataGridView1.CurrentRow.Cells[7].Value = Math.Round(total, 2);
                //        //    dataGridView1.CurrentRow.Cells[8].Value = "لايوجد داعي للتحويل";
                //        //    dataGridView1.CurrentRow.Cells[9].Value = dataGridView1.CurrentRow.Cells[6].Value;
                //        //}
                //        //else if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value.ToString()) == 18)
                //        //{
                //        //    Double total1 = gold + draft;
                //        //    Double totalgold18 = (gold * 18) / 21;
                //        //    Double totaldraft18 = (draft * 18) / 21;
                //        //    Double total18 = totaldraft18 + totalgold18;
                //        //    dataGridView1.CurrentRow.Cells[6].Value = Math.Round(total1, 2);
                //        //    dataGridView1.CurrentRow.Cells[7].Value = Math.Round(total1, 2);
                //        //    dataGridView1.CurrentRow.Cells[8].Value = "تحويل إلى 21";
                //        //    dataGridView1.CurrentRow.Cells[9].Value = Math.Round(total18, 2);
                //        //}

                //    }
                //    else if (dt.Rows[0][6].ToString() == "فلت" && dataGridView1.CurrentRow.Cells[3].Value.ToString() == String.Empty)
                //    {

                //        dataGridView1.CurrentRow.Cells[0].Value = dt.Rows[0][0].ToString();
                //        dataGridView1.CurrentRow.Cells[1].Value = dt.Rows[0][1].ToString();
                //        dataGridView1.CurrentRow.Cells[2].Value = dt.Rows[0][2].ToString();
                //        dataGridView1.CurrentRow.Cells[3].Value = dt.Rows[0][3].ToString();
                //        // MessageBox.Show("يمكنك تعديل الوزن ... الوزن الأصلي هو "+ dt.Rows[0][2].ToString() );

                //    }
                //}
                //catch { }


                // try
                //{


                //    if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == String.Empty)
                //    {

                //    }
                //    else
                //    {
                //        dataGridView1.CurrentRow.Cells[4].Value = dt.Rows[0][4].ToString();
                //        dataGridView1.CurrentRow.Cells[5].Value = dt.Rows[0][5].ToString();


                //        //الوزن  يعني مصاغ
                //        Double gold = Convert.ToDouble(dataGridView1.CurrentRow.Cells[3].Value) * 1;
                //        //الوزن * العدد * أجور الصياغة
                //        Double draft = Convert.ToDouble(dataGridView1.CurrentRow.Cells[5].Value) * gold;

                //        if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value.ToString()) == 21)
                //        {
                //            Double total = gold + draft;
                //            dataGridView1.CurrentRow.Cells[6].Value = Math.Round(total, 2);
                //            dataGridView1.CurrentRow.Cells[7].Value = Math.Round(total, 2);
                //            dataGridView1.CurrentRow.Cells[8].Value = "لايوجد داعي للتحويل";
                //            dataGridView1.CurrentRow.Cells[9].Value = dataGridView1.CurrentRow.Cells[6].Value;
                //        }
                //        else if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value.ToString()) == 18)
                //        {
                //            Double total1 = gold + draft;
                //            Double totalgold18 = (gold * 18) / 21;
                //            Double totaldraft18 = (draft * 18) / 21;
                //            Double total18 = totaldraft18 + totalgold18;
                //            dataGridView1.CurrentRow.Cells[6].Value = Math.Round(total1, 2);
                //            dataGridView1.CurrentRow.Cells[7].Value = Math.Round(total1, 2);
                //            dataGridView1.CurrentRow.Cells[8].Value = "تحويل إلى 21";
                //            dataGridView1.CurrentRow.Cells[9].Value = Math.Round(total18, 2);
                //        }
                //    }


                //}
                //catch { }
                ////}
            }

            }

                private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
                 {
                    if (e.KeyCode == Keys.Enter)
                    { 
                        //اجمالي الفاتورة
                        Double sum = 0;
                        for (Int32 i = 0; i < dataGridView1.Rows.Count; i++)
                         {
                           sum = sum + Convert.ToDouble(dataGridView1.Rows[i].Cells[9].Value);

                         }
                            bunifuMaterialTextbox6.Text = sum.ToString();
                       //إجمالي أجور الصياغة
                      Double sum1 = 0;
                       for (Int32 i = 0; i < dataGridView1.Rows.Count; i++)
                       {
                          if(Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value.ToString()) == 21)
                          {
                               sum1 = sum1 + Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value)  * Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                          }
                          else
                          {
                               sum1 = sum1 + (( Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value)  * Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value))*18)/21;
                          }
                         
                       }
                        Double sum3 = Math.Round(sum1, 2);
                        textBox4.Text = sum3.ToString();

                       Double sum2 = 0;
                       for (Int32 i = 0; i < dataGridView1.Rows.Count; i++)
                       {
                            if(Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value) == 21)
                            {
                                sum2 = sum2 + Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                            }
                            else
                            {
                                sum2 = sum2 + ((Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value))*18)/21;
                            } 
                       }
                        Double sum4 = Math.Round(sum2, 2); 
                        textBox5.Text = sum4.ToString();


                Double total = Convert.ToDouble(bunifuMaterialTextbox6.Text) - Convert.ToDouble(bunifuMaterialTextbox5.Text);

                bunifuMaterialTextbox8.Text = total.ToString();

                if (bunifuMaterialTextbox12.Text == String.Empty)
                {

                }
                else
                {

                    Double total1 = total * Convert.ToDouble(bunifuMaterialTextbox12.Text);
                    bunifuMaterialTextbox4.Text = (Math.Round(total1 / 500) * 500).ToString();
                }



            }


                }



      

        private void button9_Click(object sender, EventArgs e)
        {
            DataTable dt = j.jewelerSelect2(textBox2.Text);
            jewelerID = Convert.ToInt32(dt.Rows[0][0].ToString());
            DataTable items = ib.itemidSelect(Convert.ToInt32(textBox1.Text));
            for(Int32 i = 0; i<items.Rows.Count; i++)
            {
                if(items.Rows[i][3].ToString() == "فلت")
                {
                    item.statusItem1(Convert.ToInt32(items.Rows[i][0].ToString()));
                    item.itemEdit1(Convert.ToInt32(items.Rows[i][0].ToString()), Convert.ToDouble(items.Rows[i][1].ToString()) + Convert.ToDouble(items.Rows[i][1].ToString()));
                }
                else
                {
                    item.statusItem1(Convert.ToInt32(items.Rows[i][0].ToString()));
                    
                }
                
            }

            t.totalDelete(Convert.ToInt32(textBox1.Text));
            ib.billitemsDelete(Convert.ToInt32(textBox1.Text));
            ca.customeraccountDelete(Convert.ToInt32(textBox1.Text));
            cash.cashDelete(Convert.ToInt32(textBox1.Text));

            for (Int32 i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                DataTable dtt2 = item.itemSelect3(dataGridView1.Rows[i].Cells[0].Value.ToString());
                if(dtt2.Rows.Count == 0)
                {
                    DataTable dt6 = cat.catSelect3(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    Int32 ID = Convert.ToInt32(dt6.Rows[0][0].ToString());
                    item.itemAdd1(dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[0].Value.ToString(),
                    Convert.ToSingle(dataGridView1.Rows[i].Cells[2].Value.ToString()),Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value.ToString()),
                    Convert.ToSingle(dataGridView1.Rows[i].Cells[4].Value.ToString()),"كاملة",true,ID);
                }
                DataTable dtt = item.itemSelect3(dataGridView1.Rows[i].Cells[0].Value.ToString());
                if (dtt.Rows[0][1].ToString() == "فلت")
                {
                    ib.billitemsAdd(Convert.ToInt32(dtt.Rows[0][0].ToString()), Convert.ToInt32(textBox1.Text),Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value.ToString()),
                    Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value.ToString()), Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value.ToString()), dataGridView1.Rows[i].Cells[8].Value.ToString(),
                    Convert.ToDouble(dataGridView1.Rows[i].Cells[9].Value.ToString()));
                    item.itemEdit1(Convert.ToInt32(dtt.Rows[0][0].ToString()), Convert.ToDouble(dtt.Rows[0][2].ToString())-Convert.ToDouble( dataGridView1.Rows[i].Cells[3].Value.ToString()));
                    DataTable dtt1 = item.itemSelect3(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    if (Convert.ToDouble(dtt1.Rows[0][2].ToString()) == 0.0 )
                    {
                        item.statusItem(Convert.ToInt32(dtt.Rows[0][0].ToString()));
                    }
                }
                else
                {
                    ib.billitemsAdd(Convert.ToInt32(dtt.Rows[0][0].ToString()), Convert.ToInt32(textBox1.Text),Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value.ToString()),
                                      Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value.ToString()), Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value.ToString()), dataGridView1.Rows[i].Cells[8].Value.ToString(),
                                      Convert.ToDouble(dataGridView1.Rows[i].Cells[9].Value.ToString()));
                    if(comboBox1.Text == "مبيع")
                    {
                        item.statusItem(Convert.ToInt32(dtt.Rows[0][0].ToString()));
                    }
                    else
                    {
                        item.statusItem1(Convert.ToInt32(dtt.Rows[0][0].ToString()));
                    }
                    
                }
                
            }
            t.totalAdd(Convert.ToDouble(textBox5.Text), Convert.ToDouble(textBox4.Text), Convert.ToInt32(textBox1.Text));
            b.billEdit(Convert.ToInt32(textBox1.Text), comboBox1.Text, dateTimePicker1.Value, jewelerID, Convert.ToSingle(bunifuMaterialTextbox12.Text),
                       Convert.ToDouble(bunifuMaterialTextbox6.Text), Convert.ToDouble(bunifuMaterialTextbox5.Text), Convert.ToDouble(bunifuMaterialTextbox8.Text));
            if (comboBox1.Text == "مبيع")
            {
                ca.customeraccountAdd(dateTimePicker1.Value, Convert.ToDouble(bunifuMaterialTextbox4.Text), 0, Convert.ToDouble(bunifuMaterialTextbox8.Text), 0, "فاتورة مبيع",jewelerID ,Convert.ToInt32(textBox1.Text));
               // cash.cashAdd(dateTimePicker1.Value , Convert.ToDouble(bunifuMaterialTextbox4.Text), 0 , Convert.ToDouble(bunifuMaterialTextbox4.Text)/1148 , 0, Convert.ToDouble(bunifuMaterialTextbox8.Text),0,( Convert.ToDouble(bunifuMaterialTextbox4.Text) * 875) / 745 , 0 , Convert.ToInt32(textBox1.Text),jewelerID , "فاتورة مبيع");
            }
            else if (comboBox1.Text == "شراء")
            {
                ca.customeraccountAdd(dateTimePicker1.Value,0, Convert.ToDouble(bunifuMaterialTextbox4.Text), 0, Convert.ToDouble(bunifuMaterialTextbox8.Text), "فاتورة شراء",jewelerID,Convert.ToInt32(textBox1.Text));
                //cash.cashAdd(dateTimePicker1.Value,0, Convert.ToDouble(bunifuMaterialTextbox4.Text), 0, Convert.ToDouble(bunifuMaterialTextbox4.Text) / 1148, 0, Convert.ToDouble(bunifuMaterialTextbox8.Text), 0, (Convert.ToDouble(bunifuMaterialTextbox4.Text) * 875) / 745,  Convert.ToInt32(textBox1.Text), jewelerID, "فاتورة مبيع");
            }
           
            SqlConnection co = new SqlConnection();
            //co.ConnectionString = @"Data Source=FLAMINGO\SQLEXPRESS;AttachDbFilename=D:\Yakdi\gold\gold.mdf;Integrated Security=True;database=gold";
            co.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Yakdi\gold\gold.mdf;Integrated Security=True;database=gold";
            // co.ConnectionString = @"Data Source = DESKTOP-R8D391E; Initial Catalog = gold; User ID = sa; password = 12345678"; 
            String sq = "select  bill.ID ,category , buyorpur ,bill.date , jewelerName , mobile , goldprice , total , discount , totalafterdiscount ,items.name ,round(actvalue,2)'actvalue',round(draftwages, 2)'draftwages' , valueafterchange ,ABS(round((sum(toyou21) - sum(tous21)), 2))'balance',CASE WHEN round((sum(toyou21) - sum(tous21)), 2) > 0 THEN 'لكم' WHEN round((sum(toyou21)-sum(tous21)),2) < 0 THEN 'لنا' END AS 'youus', CASE WHEN round((sum(toyou21)-sum(tous21)),2) > 0 THEN totalafterdiscount -ABS(round((sum(toyou21) - sum(tous21)), 2)) WHEN round((sum(toyou21)-sum(tous21)),2) < 0 THEN totalafterdiscount +ABS(round((sum(toyou21) - sum(tous21)), 2)) END AS 'finish',sumgold'sum1',sumdraft'sum2' from bill inner join jeweler on jeweler.ID = bill.jewelerID inner join billitems on billitems.billID ="+Convert.ToInt32(textBox1.Text)+" inner join items on billitems.itemID = items.ID inner join category on items.catID = category.ID inner join customeraccount on customeraccount.jewelerID ="+jewelerID+" inner join total on total.billID = bill.ID WHERE bill.ID ="+ Convert.ToInt32(textBox1.Text) + "  and jeweler.ID ="+jewelerID+ " group by  bill.ID,category , buyorpur ,bill.date , jewelerName , mobile , goldprice , total , discount , totalafterdiscount , items.name ,round(actvalue, 2),round(draftwages, 2) , valueafterchange,sumgold , sumdraft";
            DataSet3 ds = new DataSet3();
            SqlDataAdapter dad = new SqlDataAdapter(sq, co);
            dad.Fill(ds.Tables["DataTable1"]);
            CrystalReport3 em = new CrystalReport3();
            em.SetDataSource(ds.Tables["DataTable1"]);

            em.PrintOptions.PrinterName = "HP LaserJet Pro M12w";
            em.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
            em.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
            //   em.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            em.PrintToPrinter(1, false, 0, 0);
            //FRM_PRINT PR = new FRM_PRINT(em);
            // PR.ShowDialog();
            //zeroevery();

        }


        void zeroevery()
        {
            comboBox1.SelectedIndex = -1;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            bunifuMaterialTextbox4.Text = "0";
            bunifuMaterialTextbox6.Text = "";
            bunifuMaterialTextbox5.Text = "";
            bunifuMaterialTextbox8.Text = "";
            dataGridView1.DataSource =null;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dt = b.billSelect(Convert.ToInt32(textBox1.Text));
                if (dt.Rows.Count == 0)
                {
                    DataTable dt1 = b.billSelect2(Convert.ToInt32(textBox1.Text));
                    if (dt1.Rows.Count == 0)
                    {
                        MessageBox.Show("لايوجد فاتورة بهذا الرقم");
                    }
                    else
                    {
                        comboBox1.Text = dt1.Rows[0][1].ToString();
                        dateTimePicker1.Text = dt1.Rows[0][2].ToString();

                        bunifuMaterialTextbox12.Text = dt1.Rows[0][3].ToString();
                        bunifuMaterialTextbox6.Text = dt1.Rows[0][4].ToString();
                        bunifuMaterialTextbox5.Text = dt1.Rows[0][5].ToString();
                        bunifuMaterialTextbox4.Text = dt1.Rows[0][6].ToString();


                       
                        //bunifuMaterialTextbox17.Text = dt1.Rows[0][8].ToString();
                        //bunifuMaterialTextbox23.Text = dt1.Rows[0][9].ToString();
                        dataGridView1.DataSource = ib.billitemsSelect(Convert.ToInt32(textBox1.Text));
                        DataTable dd = t.totalSelect(Convert.ToInt32(textBox1.Text));
                       
                        if(dd.Rows.Count == 0)
                        {

                        }
                        else
                        {
                            textBox4.Text = dd.Rows[0][1].ToString();
                            textBox5.Text = dd.Rows[0][0].ToString();
                        }
                        
                    }
                }
                else
                {
                    comboBox1.Text = dt.Rows[0][1].ToString();
                    dateTimePicker1.Text = dt.Rows[0][2].ToString();
                    textBox2.Text = dt.Rows[0][3].ToString();
                    textBox3.Text = dt.Rows[0][4].ToString();
                    bunifuMaterialTextbox12.Text = dt.Rows[0][5].ToString();
                    bunifuMaterialTextbox6.Text = dt.Rows[0][6].ToString();
                    bunifuMaterialTextbox5.Text = dt.Rows[0][7].ToString();
                   Double total = Convert.ToDouble(bunifuMaterialTextbox6.Text) - Convert.ToDouble(bunifuMaterialTextbox5.Text);
                    bunifuMaterialTextbox8.Text = (Math.Round(total,2)).ToString();
                    int total1 = ((int)Math.Round(total*Convert.ToDouble(bunifuMaterialTextbox12.Text) / 500.0)) * 500;
                    bunifuMaterialTextbox4.Text = total1.ToString();
               
                   
                   // bunifuMaterialTextbox4.Text = dt.Rows[0][8].ToString();
                    dataGridView1.DataSource = ib.billitemsSelect(Convert.ToInt32(textBox1.Text));
                    DataTable dd = t.totalSelect(Convert.ToInt32(textBox1.Text));
                    textBox4.Text = dd.Rows[0][1].ToString();

                    textBox5.Text = dd.Rows[0][0].ToString();
                }




            }
        }


        private void bunifuMaterialTextbox5_KeyDown_1(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                Double total = Convert.ToDouble(bunifuMaterialTextbox6.Text) - Convert.ToDouble(bunifuMaterialTextbox5.Text);
              
                bunifuMaterialTextbox8.Text = total.ToString();
                
                if(bunifuMaterialTextbox12.Text == String.Empty)
                {

                }
                else
                {
                   
                    Double total1 = total * Convert.ToDouble(bunifuMaterialTextbox12.Text);
                    bunifuMaterialTextbox4.Text = (Math.Round(total1 / 500) * 500).ToString();
                }
               
               
            }
        }

  

 
        private void button4_Click(object sender, EventArgs e)
        {
            b.billDelete(Convert.ToInt32(textBox1.Text));
            MessageBox.Show("تم حذف الفاتورة بنجاح");
            ib.billitemsDelete(Convert.ToInt32(textBox1.Text));
            ca.customeraccountDelete(Convert.ToInt32(textBox1.Text));
            cash.cashDelete(Convert.ToInt32(textBox1.Text));

            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            bunifuMaterialTextbox12.Text = String.Empty;
            bunifuMaterialTextbox4.Text = String.Empty;
            bunifuMaterialTextbox5.Text = String.Empty;
            bunifuMaterialTextbox6.Text = String.Empty;
            
            bunifuMaterialTextbox8.Text = String.Empty;

           

        }

        private void dataGridView1_CellLeave_1(object sender, DataGridViewCellEventArgs e)
        {

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

        private void but_Click(object sender, EventArgs e)
        {
            dataGridView1.CurrentRow.Cells[2].Value = Weight.Text;

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            MessageBox.Show(dataGridView1.Rows.Count.ToString());

            Double gram = Convert.ToDouble(textBox6.Text)/Convert.ToDouble(bunifuMaterialTextbox12.Text);
            //dataGridView1.Rows.Add("","مشتراة بمبلغ",gram ,21 , 0 ,1 , gram , gram , "لايوجد داعي للتحويل", gram);
            //   dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = "";
            //   dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1].Value = "مشتراة بمبلغ";
            //   dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value = gram;
            //   dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[3].Value = 21;
            //   dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[4].Value = 0;
            ////   dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[5].Value = 1;
            //   dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[5].Value = gram;
            //   dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[6].Value = gram;
            //   dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[7].Value = "لايوجد داعي للتحويل";
            //   dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[8].Value = gram;


         //   dataGridView1.CurrentRow.Cells[0].Value = "";
            dataGridView1.CurrentRow.Cells[1].Value = "مشتراة بمبلغ";
            dataGridView1.CurrentRow.Cells[2].Value = gram;
            dataGridView1.CurrentRow.Cells[3].Value = 21;
            dataGridView1.CurrentRow.Cells[4].Value = 0;
            //   dataGridVCurrentRow - 1].Cells[5].Value = 1;
            dataGridView1.CurrentRow.Cells[5].Value = gram;
            dataGridView1.CurrentRow.Cells[6].Value = gram;
            dataGridView1.CurrentRow.Cells[7].Value = "لايوجد داعي للتحويل";
            dataGridView1.CurrentRow.Cells[8].Value = gram;




            // this.dataGridView1.Rows.Insert(dataGridView1.Rows.Count - 1, "مشتراة بمبلغ", gram, 21 , 0, gram, gram, "لايوجد داعي للتحويل", gram);


        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void itemfrm_Click(object sender, EventArgs e)
        {
            FRM_ITEMS f = new FRM_ITEMS();
            f.ShowDialog();
        }

        private void cust_Click(object sender, EventArgs e)
        {
            FRM_JEWELER frm = new FRM_JEWELER();
            frm.ShowDialog();
            FRM_BILL_Load(null, null);
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(dataGridView1.CurrentCell.Value.ToString());


            ////////////////added by ahmad//////////////////

            if (Convert.ToDouble(bunifuMaterialTextbox12.Text) == 0)
            {
                MessageBox.Show("ادخل سعر غرام الدهب");
                return;
            }
            ////////////////////////
            if (dataGridView1.CurrentCell.ColumnIndex == 0)

            {
                dataGridView1.CurrentRow.Cells[0].Value = dataGridView1.CurrentCell.Value.ToString();

                if (dataGridView1.CurrentRow.Cells[0].Value.ToString() == String.Empty)
                {

                }
                else
                {
                    if (dataGridView1.CurrentRow.Cells[2].Value.ToString() == String.Empty)

                    {

                        String cells = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    DataTable dt;
                    if (comboBox1.Text == "مبيع")
                    {
                        dt = item.itemSearch(cells);
                    }
                    else
                    {
                        dt = item.itemSearch1(cells);
                    }

                    if (dt.Rows.Count == 0)
                    {
                        //  MessageBox.Show("لايوجد مادة لها هذا الباركود");

                    }

                    try
                    {
                        if (dt.Rows[0][6].ToString() == "كاملة")
                        {
                            dataGridView1.CurrentRow.Cells[0].Value = dt.Rows[0][0].ToString();
                            dataGridView1.CurrentRow.Cells[1].Value = dt.Rows[0][1].ToString();
                            dataGridView1.CurrentRow.Cells[2].Value = dt.Rows[0][2].ToString();
                            dataGridView1.CurrentRow.Cells[3].Value = dt.Rows[0][3].ToString();
                            dataGridView1.CurrentRow.Cells[4].Value = dt.Rows[0][4].ToString();


                            //الوزن  يعني مصاغ
                            Double gold = Convert.ToDouble(dataGridView1.CurrentRow.Cells[2].Value) * 1;
                            //الوزن * العدد * أجور الصياغة
                            Double draft = Convert.ToDouble(dataGridView1.CurrentRow.Cells[4].Value) * gold;

                            if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value.ToString()) == 21)
                            {
                                Double total = gold + draft;
                                dataGridView1.CurrentRow.Cells[5].Value = Math.Round(total, 2);
                                dataGridView1.CurrentRow.Cells[6].Value = Math.Round(total, 2);
                                dataGridView1.CurrentRow.Cells[7].Value = "لايوجد داعي للتحويل";
                                dataGridView1.CurrentRow.Cells[8].Value = dataGridView1.CurrentRow.Cells[6].Value;
                            }
                            else if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value.ToString()) == 18)
                            {
                                Double total1 = gold + draft;
                                Double totalgold18 = (gold * 18) / 21;
                                Double totaldraft18 = (draft * 18) / 21;
                                Double total18 = totaldraft18 + totalgold18;
                                dataGridView1.CurrentRow.Cells[5].Value = Math.Round(total1, 2);
                                dataGridView1.CurrentRow.Cells[6].Value = Math.Round(total1, 2);
                                dataGridView1.CurrentRow.Cells[7].Value = "تحويل إلى 21";
                                dataGridView1.CurrentRow.Cells[8].Value = Math.Round(total18, 2);
                            }

                        }
                        else if (dt.Rows[0][5].ToString() == "فلت" && dataGridView1.CurrentRow.Cells[2].Value.ToString() == String.Empty)
                        {

                            dataGridView1.CurrentRow.Cells[0].Value = dt.Rows[0][0].ToString();
                            dataGridView1.CurrentRow.Cells[1].Value = dt.Rows[0][1].ToString();
                            // MessageBox.Show("يمكنك تعديل الوزن ... الوزن الأصلي هو "+ dt.Rows[0][2].ToString() );

                        }
                    }
                    catch { }


                    try
                    {


                        if (dataGridView1.CurrentRow.Cells[2].Value.ToString() == String.Empty)
                        {

                        }
                        else
                        {
                            dataGridView1.CurrentRow.Cells[3].Value = dt.Rows[0][3].ToString();
                            dataGridView1.CurrentRow.Cells[4].Value = dt.Rows[0][4].ToString();


                            //الوزن  يعني مصاغ
                            Double gold = Convert.ToDouble(dataGridView1.CurrentRow.Cells[2].Value) * 1;
                            //الوزن * العدد * أجور الصياغة
                            Double draft = Convert.ToDouble(dataGridView1.CurrentRow.Cells[4].Value) * gold;

                            if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value.ToString()) == 21)
                            {
                                Double total = gold + draft;
                                dataGridView1.CurrentRow.Cells[5].Value = Math.Round(total, 2);
                                dataGridView1.CurrentRow.Cells[6].Value = Math.Round(total, 2);
                                dataGridView1.CurrentRow.Cells[7].Value = "لايوجد داعي للتحويل";
                                dataGridView1.CurrentRow.Cells[8].Value = dataGridView1.CurrentRow.Cells[6].Value;
                            }
                            else if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value.ToString()) == 18)
                            {
                                Double total1 = gold + draft;
                                Double totalgold18 = (gold * 18) / 21;
                                Double totaldraft18 = (draft * 18) / 21;
                                Double total18 = totaldraft18 + totalgold18;
                                dataGridView1.CurrentRow.Cells[5].Value = Math.Round(total1, 2);
                                dataGridView1.CurrentRow.Cells[6].Value = Math.Round(total1, 2);
                                dataGridView1.CurrentRow.Cells[7].Value = "تحويل إلى 21";
                                dataGridView1.CurrentRow.Cells[8].Value = Math.Round(total18, 2);
                            }
                        }


                    }
                    catch { }
                    }
                }

                }

                //dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];
                //dataGridView1.BeginEdit(true);
            }

        private void button3_Click(object sender, EventArgs e)
        {
            FRM_PAY pa = new FRM_PAY();
            pa.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable dt = j.jewelerSelect2(textBox2.Text);
            jewelerID = Convert.ToInt32(dt.Rows[0][0].ToString());
            DataTable items = ib.itemidSelect(Convert.ToInt32(textBox1.Text));
            for (Int32 i = 0; i < items.Rows.Count; i++)
            {
                if (items.Rows[i][3].ToString() == "فلت")
                {
                    item.statusItem1(Convert.ToInt32(items.Rows[i][0].ToString()));
                    item.itemEdit1(Convert.ToInt32(items.Rows[i][0].ToString()), Convert.ToDouble(items.Rows[i][1].ToString()) + Convert.ToDouble(items.Rows[i][1].ToString()));
                }
                else
                {
                    item.statusItem1(Convert.ToInt32(items.Rows[i][0].ToString()));

                }

            }

            t.totalDelete(Convert.ToInt32(textBox1.Text));
            ib.billitemsDelete(Convert.ToInt32(textBox1.Text));
            ca.customeraccountDelete(Convert.ToInt32(textBox1.Text));
            cash.cashDelete(Convert.ToInt32(textBox1.Text));

            for (Int32 i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                DataTable dtt2 = item.itemSelect3(dataGridView1.Rows[i].Cells[0].Value.ToString());
                if (dtt2.Rows.Count == 0)
                {
                    DataTable dt6 = cat.catSelect3(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    Int32 ID = Convert.ToInt32(dt6.Rows[0][0].ToString());
                    item.itemAdd1(dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[0].Value.ToString(),
                    Convert.ToSingle(dataGridView1.Rows[i].Cells[2].Value.ToString()), Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value.ToString()),
                    Convert.ToSingle(dataGridView1.Rows[i].Cells[4].Value.ToString()), "كاملة", true, ID);
                }
                DataTable dtt = item.itemSelect3(dataGridView1.Rows[i].Cells[0].Value.ToString());
                if (dtt.Rows[0][1].ToString() == "فلت")
                {
                    ib.billitemsAdd(Convert.ToInt32(dtt.Rows[0][0].ToString()), Convert.ToInt32(textBox1.Text), Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value.ToString()),
                    Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value.ToString()), Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value.ToString()), dataGridView1.Rows[i].Cells[8].Value.ToString(),
                    Convert.ToDouble(dataGridView1.Rows[i].Cells[9].Value.ToString()));
                    item.itemEdit1(Convert.ToInt32(dtt.Rows[0][0].ToString()), Convert.ToDouble(dtt.Rows[0][2].ToString()) - Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value.ToString()));
                    DataTable dtt1 = item.itemSelect3(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    if (Convert.ToDouble(dtt1.Rows[0][2].ToString()) == 0.0)
                    {
                        item.statusItem(Convert.ToInt32(dtt.Rows[0][0].ToString()));
                    }
                }
                else
                {
                    ib.billitemsAdd(Convert.ToInt32(dtt.Rows[0][0].ToString()), Convert.ToInt32(textBox1.Text), Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value.ToString()),
                                      Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value.ToString()), Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value.ToString()), dataGridView1.Rows[i].Cells[8].Value.ToString(),
                                      Convert.ToDouble(dataGridView1.Rows[i].Cells[9].Value.ToString()));
                    if (comboBox1.Text == "مبيع")
                    {
                        item.statusItem(Convert.ToInt32(dtt.Rows[0][0].ToString()));
                    }
                    else
                    {
                        item.statusItem1(Convert.ToInt32(dtt.Rows[0][0].ToString()));
                    }

                }

            }
            t.totalAdd(Convert.ToDouble(textBox5.Text), Convert.ToDouble(textBox4.Text), Convert.ToInt32(textBox1.Text));
            b.billEdit(Convert.ToInt32(textBox1.Text), comboBox1.Text, dateTimePicker1.Value, jewelerID, Convert.ToSingle(bunifuMaterialTextbox12.Text),
                       Convert.ToDouble(bunifuMaterialTextbox6.Text), Convert.ToDouble(bunifuMaterialTextbox5.Text), Convert.ToDouble(bunifuMaterialTextbox8.Text));
            if (comboBox1.Text == "مبيع")
            {
                ca.customeraccountAdd(dateTimePicker1.Value, Convert.ToDouble(bunifuMaterialTextbox4.Text), 0, Convert.ToDouble(bunifuMaterialTextbox8.Text), 0, "فاتورة مبيع", jewelerID, Convert.ToInt32(textBox1.Text));
                // cash.cashAdd(dateTimePicker1.Value , Convert.ToDouble(bunifuMaterialTextbox4.Text), 0 , Convert.ToDouble(bunifuMaterialTextbox4.Text)/1148 , 0, Convert.ToDouble(bunifuMaterialTextbox8.Text),0,( Convert.ToDouble(bunifuMaterialTextbox4.Text) * 875) / 745 , 0 , Convert.ToInt32(textBox1.Text),jewelerID , "فاتورة مبيع");
            }
            else if (comboBox1.Text == "شراء")
            {
                ca.customeraccountAdd(dateTimePicker1.Value, 0, Convert.ToDouble(bunifuMaterialTextbox4.Text), 0, Convert.ToDouble(bunifuMaterialTextbox8.Text), "فاتورة شراء", jewelerID, Convert.ToInt32(textBox1.Text));
                //cash.cashAdd(dateTimePicker1.Value,0, Convert.ToDouble(bunifuMaterialTextbox4.Text), 0, Convert.ToDouble(bunifuMaterialTextbox4.Text) / 1148, 0, Convert.ToDouble(bunifuMaterialTextbox8.Text), 0, (Convert.ToDouble(bunifuMaterialTextbox4.Text) * 875) / 745,  Convert.ToInt32(textBox1.Text), jewelerID, "فاتورة مبيع");
            }

            SqlConnection co = new SqlConnection();
            //co.ConnectionString = @"Data Source=FLAMINGO\SQLEXPRESS;AttachDbFilename=D:\Yakdi\gold\gold.mdf;Integrated Security=True;database=gold";
            co.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Yakdi\gold\gold.mdf;Integrated Security=True;database=gold";
            //co.ConnectionString = @"Data Source = DESKTOP-R8D391E; Initial Catalog = gold; User ID = sa; password = 12345678";
            String sq = "select  bill.ID ,category , buyorpur ,bill.date , jewelerName , mobile , goldprice , total , discount , totalafterdiscount ,items.name ,round(actvalue,2)'actvalue',round(draftwages, 2)'draftwages' , valueafterchange ,ABS(round((sum(toyou21) - sum(tous21)), 2))'balance',CASE WHEN round((sum(toyou21) - sum(tous21)), 2) > 0 THEN 'لكم' WHEN round((sum(toyou21)-sum(tous21)),2) < 0 THEN 'لنا' END AS 'youus', CASE WHEN round((sum(toyou21)-sum(tous21)),2) > 0 THEN totalafterdiscount -ABS(round((sum(toyou21) - sum(tous21)), 2)) WHEN round((sum(toyou21)-sum(tous21)),2) < 0 THEN totalafterdiscount +ABS(round((sum(toyou21) - sum(tous21)), 2)) END AS 'finish',sumgold'sum1',sumdraft'sum2' from bill inner join jeweler on jeweler.ID = bill.jewelerID inner join billitems on billitems.billID =" + Convert.ToInt32(textBox1.Text) + " inner join items on billitems.itemID = items.ID inner join category on items.catID = category.ID inner join customeraccount on customeraccount.jewelerID =" + jewelerID + " inner join total on total.billID = bill.ID WHERE bill.ID =" + Convert.ToInt32(textBox1.Text) + "  and jeweler.ID =" + jewelerID + " group by  bill.ID,category , buyorpur ,bill.date , jewelerName , mobile , goldprice , total , discount , totalafterdiscount , items.name ,round(actvalue, 2),round(draftwages, 2) , valueafterchange,sumgold , sumdraft";
            DataSet3 ds = new DataSet3();
            SqlDataAdapter dad = new SqlDataAdapter(sq, co);
            dad.Fill(ds.Tables["DataTable1"]);
            CrystalReport5 em1 = new CrystalReport5();
            em1.SetDataSource(ds.Tables["DataTable1"]);

            em1.PrintOptions.PrinterName = "HP LaserJet Pro M12w";
            em1.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
            em1.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
            //   em.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            em1.PrintToPrinter(1, false, 0, 0);
            //FRM_PRINT3 PR = new FRM_PRINT3(em1);
            //PR.ShowDialog();
            //zeroevery();
        }
    }
}
