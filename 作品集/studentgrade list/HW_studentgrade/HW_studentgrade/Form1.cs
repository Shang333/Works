using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW_studentgrade
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string name_random;
        int dataCoount=0;
        //ListViewItem person = new ListViewItem();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataCoount += 1;

            ListViewItem person = new ListViewItem(txtName.Text);
            person.SubItems.Add(txtName.Text);
            person.SubItems.Add(txtChinese.Text);
            person.SubItems.Add(txtEnglish.Text);
            person.SubItems.Add(txtMath.Text);
            int sum_int = int.Parse(txtChinese.Text) + int.Parse(txtEnglish.Text) + int.Parse(txtMath.Text);
            string sum_str = sum_int.ToString();
            person.SubItems.Add(sum_str);
            listView1.Items.Add(person);

            int average_int = sum_int / 3;
            string avavrage_str = average_int.ToString();
            person.SubItems.Add(avavrage_str);
        }

       
        private void btnRandom_Click(object sender, EventArgs e)
        {
            dataCoount += 1;
            name_random = dataCoount.ToString();

            ListViewItem person = new ListViewItem(name_random);
            Random rand = new Random();
            person.SubItems.Add(rand.Next(101).ToString());
            person.SubItems.Add(rand.Next(101).ToString());
            person.SubItems.Add(rand.Next(101).ToString());
            listView1.Items.Add(person);


            //int sum_int = int.Parse(listView1.Items[1].Text);
            int sum_int = int.Parse(person.SubItems[1].Text)+ int.Parse(person.SubItems[2].Text)+ int.Parse(person.SubItems[3].Text);
            string sum_str = sum_int.ToString();
            person.SubItems.Add(sum_str);

            int average_int = sum_int / 3;
            string avavrage_str = average_int.ToString();
            person.SubItems.Add(avavrage_str);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //name_random = dataCoount.ToString();
            //ListViewItem person = new ListViewItem(name_random);

            var a = listView1.Items[0].SubItems;
            //ListViewItem item = listView1.SelectedItems[0];
            MessageBox.Show(a.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    MessageBox.Show(subItem.ToString());
                }
            }

        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }


        private void btnRan20_Click(object sender, EventArgs e)
        {

            Random rand = new Random();
            for(int i = 0; i < 20;i++)
            {
                dataCoount += 1;
                name_random = dataCoount.ToString();
                ListViewItem person = new ListViewItem(name_random);
                person.SubItems.Add(rand.Next(101).ToString());
                person.SubItems.Add(rand.Next(101).ToString());
                person.SubItems.Add(rand.Next(101).ToString());
                listView1.Items.Add(person);
                
                int sum_int = int.Parse(person.SubItems[1].Text) + int.Parse(person.SubItems[2].Text) + int.Parse(person.SubItems[3].Text);
                string sum_str = sum_int.ToString();
                person.SubItems.Add(sum_str);
                
                int average_int = sum_int / 3;
                string avavrage_str = average_int.ToString();
                person.SubItems.Add(avavrage_str);

            }
           


            
           
        }

        private void btnStatic_Click(object sender, EventArgs e)
        {
            //if (this.ListView1.SelectedItems.Count == 0)
            //    return;
            //get selected row
            //ListViewItem item = ListView1.SelectedItems[0];
            //fill the text boxes
            //textBoxID.Text = item.Text;
            //labStatic.Text = item.SubItems[0].Text;
            //textBoxPhone.Text = item.SubItems[1].Text;
            //textBoxLevel.Text = item.SubItems[2].Text;

            ListView.SelectedListViewItemCollection breakfast =this.listView1.SelectedItems;
            double price = 0.0;
            foreach (ListViewItem item in breakfast)
            {
                price += Double.Parse(item.SubItems[1].Text);
            }

            // Output the price to TextBox1.
            textBox1.Text = price.ToString();
        }
    }
}
