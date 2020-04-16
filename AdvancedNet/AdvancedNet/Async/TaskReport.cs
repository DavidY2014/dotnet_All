using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdvancedNet.Async
{
    /// <summary>
    /// async实现进度汇报
    /// </summary>
    public class TaskReport
    {
        public async Task<int> UploadPicturesAsync(List<MyImage> imageList,
     IProgress<int> progress)
        {
            int totalCount = imageList.Count;
            int processCount = await Task.Run<int>(() =>
            {
                int tempCount = 0;
                foreach (var image in imageList)
                {
                    //await the processing and uploading logic here
                    //int processed = await  UploadAndProcessAsync(image);
                    //if (progress != null)
                    //{
                    //    progress.Report((tempCount * 100 / totalCount));
                    //}
                    tempCount++;
                }
                return tempCount;
            });
            return processCount;
        }


        public async Task<int> Test() {

            Console.WriteLine($"Current thread id ={Thread.CurrentThread}");

            return await Task.Run(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine($"Task.Run thread id ={Thread.CurrentThread}");
                return 1;
            }).ContinueWith(o=> {
                Console.WriteLine($"ContinueWith thread id ={Thread.CurrentThread}");
                return o.Result;
            });
            //Console.WriteLine($"main thread id ={Thread.CurrentThread}");
            //return 2;
        }


        /// <summary>
        /// 模拟异步处理程序，延迟一定的时间
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public Task<int> UploadAndProcessAsync(MyImage image) 
        {
            return new Task<int>(() => { return 1; });
        }

        /// <summary>
        /// 使用此异步调用方法
        /// </summary>
        public async void ShowProgress() 
        {
            List<MyImage> images = new List<MyImage>();

            int uploads = await UploadPicturesAsync(images,
                new Progress<int>(percent => Console.WriteLine(percent)));
        }




    }
}
