using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_02
{
    public partial class Form1 : Form
    {
        double billnumber;
        string item, type, paymethod, loyalty, date;
        double quantity, unitprice, price, pharmacyprice, dairyprice, diaperprice, otherprice ;

        bool errors = false;
        public Form1()
        {
            InitializeComponent();

            
            pharmacyprice = 0;
            dairyprice = 0;
            diaperprice = 0;
            otherprice = 0;
            date = dateTimePicker1.Text.ToString();
            billnumber = 10000;
            
          
            price = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for(var i=0;i<100; i++)
            {
                comboBox2.Items.Add(i + 1);
            }
            radioButton1.Checked = true;

            //txtbillno_34.Text= billnumber;
            
        }
        private void btnsubmit_34_Click(object sender, EventArgs e)
        {
            try
            {
                type = comboBox1.SelectedItem.ToString();
                paymethod = comboBox3.SelectedItem.ToString();
                item = txtitem_34.Text;

                if (radioButton1.Checked = true)
                {
                    loyalty = "Yes";
                }
                else
                {
                    loyalty = "No";
                }
                quantity = Convert.ToDouble(comboBox2.SelectedItem);

                if (txtitem_34.Text == "" || txtprice_34.Text == "" || comboBox1.SelectedIndex == -1 ||
                    comboBox2.SelectedIndex == -1 || comboBox3.SelectedIndex == -1 ||
                    !Double.TryParse((txtprice_34.Text), out price))
                {
                    errors = true;
                    MessageBox.Show("Invalid Inputs ", "Error Message", MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                }
                else
                {
                    unitprice = Convert.ToDouble(txtprice_34.Text);
                    price = quantity * unitprice;
                    if (comboBox1.SelectedIndex == 0) {
                        pharmacyprice += price;
                    dataGridView1.Rows.Add(item, type, unitprice, quantity,price);
                    }
                    else if(comboBox1.SelectedIndex == 1)
                    {
                        dairyprice += price;
                        dataGridView1.Rows.Add(item, type, unitprice, quantity, price);
                    }
                    else if (comboBox1.SelectedIndex == 2)
                    {
                        diaperprice += price;
                        dataGridView1.Rows.Add(item, type, unitprice, quantity, price);
                    }
                    else 
                    {
                        otherprice += price;
                        dataGridView1.Rows.Add(item, type, unitprice, quantity, otherprice);
                    }
                   
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error Message" ,MessageBoxButtons.OKCancel,MessageBoxIcon.Asterisk);
            }
        }
        private void btnclear_34_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();          
        }
        private void btntotal_34_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                errors = true;
                MessageBox.Show("You didn't submit any item to add to the bill", "Error message", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Error) ;

            }
            else
            {
                var itemsList = new List<string>();
                var itemtypeList = new List<string>();
                var unitpriceList = new List<double>();
                var quantityList = new List<double>();
                var costList = new List<double>();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    itemsList.Add(row.Cells[0].Value.ToString());
                    itemtypeList.Add(row.Cells[1].Value.ToString());
                    unitpriceList.Add(double.Parse(row.Cells[2].Value.ToString()));
                    quantityList.Add(double.Parse(row.Cells[3].Value.ToString()));
                    costList.Add(double.Parse(row.Cells[4].Value.ToString()));

                }

                string[] itemsArray = itemsList.ToArray();
                string[] typeArray = itemtypeList.ToArray();
                double[] unitpriceArray = unitpriceList.ToArray();
                double[] quantityArray = quantityList.ToArray();
                double[] costArray = costList.ToArray();
                billnumber++;

                Form2 form2 = new Form2(itemsArray, typeArray, unitpriceArray, quantityArray, costArray,
                                        date, paymethod, loyalty, pharmacyprice, dairyprice, diaperprice, otherprice, billnumber);
                form2.Show();
            }
        }
    }
}
