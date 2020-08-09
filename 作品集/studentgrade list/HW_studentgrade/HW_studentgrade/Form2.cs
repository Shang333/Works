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

 
        private void btnAdd_Click(object sender, EventArgs e)
        { 
            //加資料
            ListViewItem person = new ListViewItem(txtName.Text);
            person.SubItems.Add(txtChinese.Text);
            person.SubItems.Add(txtEnglish.Text);
            person.SubItems.Add(txtMath.Text);
            //求總分
            double sum_dob = double.Parse(txtChinese.Text) + double.Parse(txtEnglish.Text) + double.Parse(txtMath.Text);
            person.SubItems.Add(sum_dob.ToString());
            
            //求平均
            double average_dob = sum_dob / 3;
            person.SubItems.Add(string.Format("{0:0.00}", average_dob));
           
            //求最低分的分數和對應科目
            double min = 99999;
            string min_header="";
            for (int i = 1; i < 4; i++)
            {
                //找最小值，如果比min小，就會取代min
                if(double.Parse(person.SubItems[i].Text)< min)
                {
                    min = double.Parse(person.SubItems[i].Text);
                    min_header = listView1.Columns[i].Text;
                }
            }
            person.SubItems.Add(min_header + min.ToString());


            //求最高分的分數和對應科目
            double max = 0;
            string max_header = "";
            for(int i = 1; i < 4; i++)
            {
                if (double.Parse(person.SubItems[i].Text) > max)
                {
                    max = double.Parse(person.SubItems[i].Text);
                    max_header = listView1.Columns[i].Text;
                }

            }
            person.SubItems.Add(max_header + max.ToString());
            listView1.Items.Add(person);
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView2.Items.Clear();
            txtName.Text = "";
            txtChinese.Text = "";
            txtEnglish.Text = "";
            txtMath.Text = "";
            
            //加入學生資料、插入儲存資料、移除資料、各科統計之按鈕功能開啟
            btnAdd.Enabled = true;
            btnInsert.Enabled = true;
            btnRemove.Enabled = true;
            btnStatic.Enabled = true;
        }





        private void btnStatic_Click(object sender, EventArgs e)
        {

            listView2.Items.Clear();
            //先移除舊資料，再加新資料(否則一行會有多筆資料，導致錯誤)

            //算各科總分
            double sumChin_lis2 = 0;
            double sumEng_lis2 = 0;
            double sumMath_lis2 = 0;
            foreach (ListViewItem item in listView1.Items)
            {
                sumChin_lis2 += double.Parse(item.SubItems[1].Text);
            }

            foreach (ListViewItem item in listView1.Items)
            {
                sumEng_lis2 += double.Parse(item.SubItems[2].Text);
            }

            foreach (ListViewItem item in listView1.Items)
            {
                sumMath_lis2 += double.Parse(item.SubItems[3].Text);
            }

            ListViewItem item1 = new ListViewItem();
            item1.Text = "總分";
            item1.SubItems.Add(sumChin_lis2.ToString());
            item1.SubItems.Add(sumEng_lis2.ToString());
            item1.SubItems.Add(sumMath_lis2.ToString());
            listView2.Items.Add(item1);

            //算各科平均          
            double aveChin_lis2 = 0;
            double aveEng_lis2 = 0;
            double aveMath_lis2 = 0;       
            aveChin_lis2 = sumChin_lis2 / (double)listView1.Items.Count;
            aveEng_lis2  = sumEng_lis2  / (double)listView1.Items.Count;
            aveMath_lis2 = sumMath_lis2 / (double)listView1.Items.Count;

            ListViewItem item2 = new ListViewItem();
            item2.Text = "平均";
            item2.SubItems.Add(string.Format("{0:0.00}", aveChin_lis2));
            item2.SubItems.Add(string.Format("{0:0.00}", aveEng_lis2));
            item2.SubItems.Add(string.Format("{0:0.00}", aveMath_lis2));
            listView2.Items.Add(item2);

            //求各科最高分
            double maxChin_lis2 = 0;
            double maxEng_lis2 = 0;
            double maxMath_lis2 = 0;

            foreach (ListViewItem item in listView1.Items)
            {
                maxChin_lis2 = Math.Max(maxChin_lis2, (double.Parse(item.SubItems[1].Text)));
            }

            foreach (ListViewItem item in listView1.Items)
            {
                maxEng_lis2 = Math.Max(maxEng_lis2, (double.Parse(item.SubItems[2].Text)));
            }
  
            foreach (ListViewItem item in listView1.Items)
            {
                maxMath_lis2 = Math.Max(maxMath_lis2, (double.Parse(item.SubItems[3].Text)));
            }
            ListViewItem item3 = new ListViewItem();
            item3.Text = "最高分";
            item3.SubItems.Add(maxChin_lis2.ToString());
            item3.SubItems.Add(maxEng_lis2.ToString());
            item3.SubItems.Add(maxMath_lis2.ToString());
            listView2.Items.Add(item3);

            //求各科最低分
            double minChin_lis2 = 101;
            double minEng_lis2 = 101;
            double minMath_lis2 = 101;

            foreach (ListViewItem item in listView1.Items)
            {
                minChin_lis2 = Math.Min(minChin_lis2, (double.Parse(item.SubItems[1].Text)));
            }

            foreach (ListViewItem item in listView1.Items)
            {
                minEng_lis2 = Math.Min(minEng_lis2, (double.Parse(item.SubItems[2].Text)));
            }

            foreach (ListViewItem item in listView1.Items)
            {
                minMath_lis2 = Math.Min(minMath_lis2, (double.Parse(item.SubItems[3].Text)));
            }
            ListViewItem item4 = new ListViewItem();
            item4.Text = "最低分";
            item4.SubItems.Add(minChin_lis2.ToString());
            item4.SubItems.Add(minEng_lis2.ToString());
            item4.SubItems.Add(minMath_lis2.ToString());
            listView2.Items.Add(item4);

            //加入學生資料、插入儲存資料、移除資料、各科統計之按鈕功能關閉
            btnAdd.Enabled = false;
            btnInsert.Enabled = false;
            btnRemove.Enabled = false;
            btnStatic.Enabled = false;       

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            //加資料
            ListViewItem person = new ListViewItem(txtName.Text);
            person.SubItems.Add(txtChinese.Text);
            person.SubItems.Add(txtEnglish.Text);
            person.SubItems.Add(txtMath.Text);
           
            //求總分
            double sum_dob = double.Parse(txtChinese.Text) + double.Parse(txtEnglish.Text) + double.Parse(txtMath.Text);
            person.SubItems.Add(sum_dob.ToString());

            //求平均
            double average_dob = sum_dob / 3;
    
            //求最低分的分數和對應科目
            double min = 99999;
            string min_header = "";
            for (int i = 1; i < 4; i++)
            {
                //找最小值，如果比min小，就會取代min
                if (double.Parse(person.SubItems[i].Text) < min)
                {
                    min = double.Parse(person.SubItems[i].Text);
                    min_header = listView1.Columns[i].Text;
                }
            }

            person.SubItems.Add(min_header + min.ToString());


            //求最高分的分數和對應科目
            double max = 0;
            string max_header = "";
            for (int i = 1; i < 4; i++)
            {
                if (double.Parse(person.SubItems[i].Text) > max)
                {
                    max = double.Parse(person.SubItems[i].Text);
                    max_header = listView1.Columns[i].Text;
                }

            }
            
            person.SubItems.Add(max_header + max.ToString());
            listView1.Items.Insert(0,person);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            listView1.Items.RemoveAt(0);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            double sear1 = double.Parse(txtSear1.Text);
            double sear2 = double.Parse(txtSear2.Text);
           
            for(int i = 0; i < listView1.Items.Count; i++)
            {
                double a = double.Parse(listView1.Items[i].SubItems[1].Text);

                if (a < sear1 || a > sear2)
                {
                    listView1.Items.Remove(listView1.Items[i]);
                }
            }
            
        }
    }
    
}
