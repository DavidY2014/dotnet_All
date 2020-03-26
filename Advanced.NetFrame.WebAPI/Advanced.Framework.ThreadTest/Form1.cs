using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
                //while (thread.ThreadState!= ThreadState.Stopped)
                //{ 
                    
                //}

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


        /// <summary>
        /// Task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            {
                Task task = new Task(() => this.DoSomethingLong("button3_Click"));
                task.Start();
            }
            {
                Task task = Task.Run(() => this.DoSomethingLong(""));
            }
            {
                TaskFactory taskFactory = Task.Factory;
                Task task =  taskFactory.StartNew(() => this.DoSomethingLong(""));
            }
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                Console.WriteLine("在Delay之前");
                Task task = Task.Delay(2000)
                    .ContinueWith(t =>
                    {
                        stopwatch.Stop();
                        Console.WriteLine($"Delay 耗时{stopwatch.ElapsedMilliseconds}");
                        Console.WriteLine($"This is ThreadId ={Thread.CurrentThread.ManagedThreadId.ToString()}");

                    });
                Console.WriteLine("在Delay之后");
            }
            {
                TaskFactory taskFactory = new TaskFactory();
                List<Task> taskList = new List<Task>();
                taskList.Add(taskFactory.StartNew(() => this.DoSomethingLong("")));
                taskList.Add(taskFactory.StartNew(() => this.DoSomethingLong("")));
                taskList.Add(taskFactory.StartNew(() => this.DoSomethingLong("")));
                taskList.Add(taskFactory.StartNew(() => this.DoSomethingLong("")));

                Task.WaitAny(taskList.ToArray());
                
                Task.WaitAll(taskList.ToArray());//等待上面的任务全部完成，不然会阻塞

                taskFactory.ContinueWhenAll(taskList.ToArray(), (t) =>
                {

                });

            }
            
        }

        /// <summary>
        /// Parallel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            //Parallel 并发执行action线程，但是主线程会参与计算，此时界面阻塞
            Parallel.Invoke(() => this.DoSomethingLong(""),
                () => this.DoSomethingLong(""),
                () => this.DoSomethingLong(""),
                () => this.DoSomethingLong("")
                );




        }


        /// <summary>
        /// 线程异常抓取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                ExceptionTest();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ExceptionTest()
        {
            try
            {
                int i = 8;
                int j = 0;
                int value = i / j;
                //此时下面这个异常信息抓不到
                throw new Exception("除数不为0");
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
