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
using Advanced.Framework.ThreadTest.Common;

namespace Advanced.Framework.ThreadTest
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 红球集合
        /// </summary>
        private string[] RedNums =
        { "01","02", "03" , "04" , "05" , "06" , "07" , "08" ,
        "09","10","11","12","13","14","15","16","17","18","19",
        "20","21","22","23","24","25","26","27","28","29","30","31","32","33"
        };

        /// <summary>
        /// 篮球集合
        /// </summary>
        private string[] BlueNums =
        { "01","02", "03" , "04" , "05" , "06" , "07" , "08" ,
        "09","10","11","12","13","14","15","16"
        };

        private List<Task> taskList = new List<Task>(); 
        /// <summary>
        /// start
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Text = "运行中";
            this.button1.Enabled = false;
            this.button2.Enabled = true;
            this.IsGoOn = true;
            this.label2Red.Text = "00";
            this.label3Red.Text = "00";
            this.label4Red.Text = "00";
            this.label5Red.Text = "00";
            this.label6Red.Text = "00";
            this.label7Red.Text = "00";
            this.labelBlue.Text = "00";
            Thread.Sleep(1000);


            #region 渲染
            foreach (var control in this.groupBox1.Controls)
            {
                if (control is Label)
                {
                    Label label = (Label)control;
                    if (label.Name.Contains("Blue"))
                    {
                        taskList.Add(Task.Run(() =>
                        {
                            try
                            {
                                while (IsGoOn)
                                {
                                    int index = new RandomHelper().GetRandomNumberDelay(0, 16);
                                    string sNumber = this.BlueNums[index];
                                    //this.labelBlue.Text = sNumber;//子线程不能操作主线程UI，需要通过委托实现
                                    //lambda入参会自动判断出action
                                    this.Invoke(new Action(() =>
                                    {
                                        label.Text = sNumber;
                                    }));
                                }

                            }
                            catch (Exception ex)
                            {
                            }
                        }));
                    }
                    else if (label.Name.Contains("Red"))
                    {
                        taskList.Add(Task.Run(() =>
                        {
                            try
                            {
                                while (IsGoOn)
                                {
                                    int index = new RandomHelper().GetRandomNumberDelay(0, 33);
                                    string sNumber = this.RedNums[index];
                                    lock (GroupBox1_Lock)
                                    {
                                        List<string> usedNumberList = this.GetUsedRedNumbers();
                                        if (!usedNumberList.Contains(sNumber))
                                        {
                                            this.Invoke(new Action(() =>
                                            {
                                                label.Text = sNumber;
                                            }));
                                        }
                                    }
                                }

                            }
                            catch (Exception ex)
                            {
                            }
                        }));
                    }
                }
      
            }
            new TaskFactory().ContinueWhenAll(taskList.ToArray(), taskArray =>
            {
                this.ShowResult();
            });
            #endregion
        }

        private static readonly object GroupBox1_Lock = new object();

        private bool IsGoOn;
        private List<string> GetUsedRedNumbers()
        {
            List<string> usedNumberList = new List<string>();
            foreach (var controller in this.groupBox1.Controls)
            {
                if (controller is Label)
                {
                    if (((Label)controller).Name.Contains("Red"))
                    {
                        usedNumberList.Add(((Label)controller).Text);
                    }
                }
            }
            return usedNumberList;
        }

        /// <summary>
        /// stop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.IsGoOn = false;
            this.button1.Enabled = true;
            this.button2.Enabled = false;
            this.button1.Text = "开始";

            //这种会导致UI线程死锁
            //原因是当你点击停止按钮时会触发此函数执行，但是此UI线程一直卡在waitall等待子线程完成
            //但是上面的子线程又需要主线程UI更新数字，所以就发生了死锁
            //Task.WaitAll(taskList.ToArray());
            //ShowResult();

            //Task.Run(() =>
            //{
            //    Task.WaitAll(taskList.ToArray());
            //    ShowResult();
            //});
        }

        private void ShowResult()
        {
            MessageBox.Show($"红球是: {this.label2Red.Text},{this.label3Red.Text},{this.label4Red.Text},{this.label5Red.Text}" +
                $",{this.label6Red.Text},{this.label7Red.Text} 篮球是: {this.labelBlue.Text}");
        }

    }
}
