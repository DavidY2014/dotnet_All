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

namespace Advanced.Framework.ThreadTest
{
    /// <summary>
    /// 测试多线程
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                //是个委托
                ThreadStart method = () => this.DoSomethingLong("button1_Click");
                Thread thread = new Thread(method);
                thread.Start();
            }
            { 
                ParameterizedThreadStart method = (obj) => this.DoSomethingLong("button1_Click");
                Thread thread = new Thread(method);
                thread.Start();
                //thread.Suspend();//暂停
                //thread.Resume();//恢复
                //thread.Abort();//中止
                
                //判断线程状态等待
                while (thread.ThreadState!= ThreadState.Stopped)
                { 
                    
                }

                //jion等待
                thread.Join();//这段代码会等待前面线程执行完毕
                thread.Join(1000);//等待1000ms
            }
            {
                //子线程委托
                ThreadStart threadStart = () => this.DoSomethingLong("btnthreadclick");
                //子线程回调委托
                Action actionCallBack = () =>
                {
                    Thread.Sleep(2000);
                    Console.WriteLine($"This is callback {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                };
                this.ThreadWithCallBack(threadStart, actionCallBack);
            }
            {
                Func<int> func = () =>
                {
                    Thread.Sleep(5000);
                    return DateTime.Now.Year;
                };
                Func<int> funcThread =  this.ThreadWithReturn(func);

                int iResult = funcThread.Invoke();
            }
        }

        private void ThreadWithCallBack(ThreadStart threadStart,Action actionCallback)
        {
            //Thread thread = new Thread(threadStart);
            //thread.Start();
            //thread.Join();//错了，主线程阻塞等待子线程结束
            //actionCallback.Invoke();//调用回调
            ThreadStart method = new ThreadStart(() =>
            {
                threadStart.Invoke();
                actionCallback.Invoke();
            });
            new Thread(method).Start();
        }


        private Func<T> ThreadWithReturn<T>(Func<T> func)
        {
            T t = default(T);
            ThreadStart threadStart = new ThreadStart(() =>
            {
                t = func.Invoke();//如何获取到其中的返回结果了
            });
            Thread thread =  new Thread(threadStart);
            thread.Start();
            return new Func<T>(() =>
            {
                thread.Join();
                return t;
            });
        }


        private void DoSomethingLong(string info)
        {
            Console.WriteLine(info);
        }


        /// <summary>
        /// 线程池
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            ManualResetEvent mre = new ManualResetEvent(false) ;
            //从线程池中获取一个线程执行委托
            ThreadPool.QueueUserWorkItem(o =>
            {
                this.DoSomethingLong("button2_Click");
                mre.Set();
            });

            ThreadPool.QueueUserWorkItem(o => this.DoSomethingLong("button2_Click"));
            ThreadPool.GetMaxThreads(out int workerThreads, out int completionPortThreads);

            mre.WaitOne();



        }
    }
}
