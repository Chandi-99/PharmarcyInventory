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
    public partial class Form2 : Form
    {
        public Form2(string[] itemsArray, string[] typeArray, double[] unitpriceArray, double[] quantityArray,
            double[] costArray,string date, string paymethod,string loyalty,double pharmacyprice,double dairyprice,
            double diaperprice, double otherprice, double billnumber)

        { 
            InitializeComponent();

            
            txtloyalty_34.Text = loyalty;
            txtpaymethod_34.Text = paymethod;
            double total = 0;
            double discount = 0;
            double final = 0;
            txtbillno_34.Text = (billnumber-1).ToString();
            
            for (int i = 0; i < itemsArray.Length; i++)
            {               
                dataGridView1.Rows.Add(itemsArray[i], typeArray[i],
                    unitpriceArray[i].ToString(), quantityArray[i].ToString(),
                    costArray[i].ToString());
                
            }
            /* for (int i = 10000; i <= 10000000; i++)
             {
                 int[] billnumber ;
                 billnumber = new int[1000000];
                 billnumber[i-1000] = i;
                 txtbillno_34.Text = billnumber[i].ToString();


             }*/

            for (int i = 0; i < itemsArray.Length; i++)
            {

                double discount1 = 0, discount2 = 0, discount3 = 0;

                total += costArray[i];

            }/*
                if (paymethod == "Cash")
                {
                    if (typeArray[i] == "Pharmaceuticals")
                    {
                        if (pharmacyprice > 500 && pharmacyprice <= 1000)
                        {
                            
                            final += costArray[i] - (costArray[i] * 5 / 100);
                            
                        }
                        else if (pharmacyprice > 1000)
                        {
                             
                            final += costArray[i] - (costArray[i] * 7 / 100);
                            

                        }                       

                    }
                    else if (typeArray[i] == "Milk Supplements")
                    {
                        if (dairyprice > 1000)
                        {
                             
                            final += costArray[i] - (costArray[i] * 5 / 100);
                            
                        }
                        
                    }
                    else if (typeArray[i] == "Diapers (adult or baby)")
                    {
                        if (diaperprice > 1000)
                        {
                             
                            final += costArray[i] - (costArray[i] * 4 / 100);
                            
                        }
                    }
                    else
                    {
                        if (otherprice >= 0)
                        {
                            final += costArray[i];
                        }
                    }

                   
                }
                else 
                {
                    if (typeArray[i] == "Pharmaceuticals")
                    {
                        if (pharmacyprice > 500 && pharmacyprice <= 1000)
                        {
                             
                            final += costArray[i] - (costArray[i] * 3 / 100);
                            
                        }
                        else if (pharmacyprice > 1000)
                        {
                          
                            final += costArray[i] - (costArray[i] * 5 / 100);
                            
                        }
                    }
                    else if (typeArray[i] == "Milk Supplements")
                    {

                        if (dairyprice > 1000)
                        {
                             discount2 = 3;
                            final += costArray[i] - (costArray[i] * 3 / 100);
                            discount += discount2;
                        }
                    }
                    else if (typeArray[i] == "Diapers (adult or baby)")
                    {
                        if (diaperprice > 1000)
                        {
                            
                            final += costArray[i] - (costArray[i] * 2 / 100);
                            
                        }
                    }
                    else
                    {
                        if (otherprice >= 0)
                        {
                            final += costArray[i];
                        }
                    }

                
                }
            }*/
            if (paymethod == "Cash")
            {
                if (pharmacyprice > 500 && pharmacyprice <= 1000)
                {
                    discount += 5;
                }
                else if (pharmacyprice > 1000)
                {
                    discount += 7;
                }
                if (dairyprice > 1000)
                {
                    discount += 5;
                }
                if (diaperprice > 1000)
                {
                    discount += 4;
                }
               
            }
            else
            {
                if (pharmacyprice > 500 && pharmacyprice <= 1000)
                {
                    discount += 3;
                }
                else if (pharmacyprice > 1000)
                {
                    discount += 5;
                }
                if (dairyprice > 1000)
                {
                    discount += 3;
                }
                if (diaperprice > 1000)
                {
                    discount += 2;
                }
            }
            if (loyalty == "Yes")
            {
                if (total >= 2500)
                    discount += 2;
                
            }

            final = total - (total * discount / 100);
            txttotal_34.Text = total.ToString();
            txtdiscount_34.Text = discount.ToString();
            txtfinal_34.Text = final.ToString();
            
        }       
    }
}
  
                                   