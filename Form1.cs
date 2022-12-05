using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVGB07_LABB2_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int maxValue = 36;
            int minValue = 0;
            if(int.Parse(txbValue1.Text) >= maxValue || int.Parse(txbValue1.Text) <= minValue
                || int.Parse(txbValue2.Text) >= maxValue || int.Parse(txbValue2.Text) <= minValue
                || int.Parse(txbValue3.Text) >= maxValue || int.Parse(txbValue3.Text) <= minValue
                || int.Parse(txbValue4.Text) >= maxValue || int.Parse(txbValue4.Text) <= minValue
                || int.Parse(txbValue5.Text) >= maxValue || int.Parse(txbValue5.Text) <= minValue
                || int.Parse(txbValue6.Text) >= maxValue || int.Parse(txbValue6.Text) <= minValue
                || int.Parse(txbValue7.Text) >= maxValue || int.Parse(txbValue7.Text) <= minValue)
            {
                lblErrorMsg.Text = "ERROR! Ha inga värden över 35 eller under 0!";
                return;
            } else
            {
                int[] tal = new int[7];

                tal[0] = int.Parse(txbValue1.Text);
                tal[1] = int.Parse(txbValue2.Text);
                tal[2] = int.Parse(txbValue3.Text);
                tal[3] = int.Parse(txbValue4.Text);
                tal[4] = int.Parse(txbValue5.Text);
                tal[5] = int.Parse(txbValue6.Text);
                tal[6] = int.Parse(txbValue7.Text);

                Array.Sort(tal);

                if (tal.Distinct().Count() != tal.Count())
                {
                    lblErrorMsg.Text = "ERROR! Du har angett dubbletter";
                    return;
                }

                Random rand = new Random();
                int[] number = new int[7];
                int AntalDragningar = int.Parse(txbDraggning.Text);
                while (AntalDragningar != 0)
                {
                    int Antal = 0;
                    for (int i = 0; i < 7; i++)
                    {
                        int rndTal = rand.Next(1, 35);
                        if (number.Contains(rndTal))
                        {
                            i--;
                        }
                        else
                        {
                            number[i] = rndTal;
                        }
                    }
                    for(int i = 0; i<7; i++)
                    {
                        if (number.Contains(tal[i])) { Antal++; }
                    }
                    if (Antal == 5)
                    {
                        int tmpTal5 = int.Parse(txb5Ratt.Text);
                        tmpTal5++;
                        txb5Ratt.Text = tmpTal5.ToString();
                    } else if (Antal == 6)
                    {
                        int tmpTal6 = int.Parse(txb6Ratt.Text);
                        tmpTal6++;
                        txb6Ratt.Text = tmpTal6.ToString();
                    } else if (Antal == 7)
                    {
                        int tmpTal7 = int.Parse(txb7Ratt.Text);
                        tmpTal7++;
                        txb7Ratt.Text = tmpTal7.ToString();
                    }

                    AntalDragningar--;
                }
                    Array.Sort(number);


                lblErrorMsg.Text = "Din lottorad: " + string.Join("-", tal);
            }
        }

        private void txbValue1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
