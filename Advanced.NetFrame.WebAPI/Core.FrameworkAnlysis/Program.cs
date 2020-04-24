using System;
using System.Threading.Tasks;

namespace Core.FrameworkAnlysis
{
    class Program
    {
        public delegate Task RequestDelegate(int context);
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Func<RequestDelegate, RequestDelegate> middleware1 = (ctx => {

                //RequestDelegate del2 = async ctx =>
                //{
                //    await Task.CompletedTask;
                //};

                //return del2;

                return async ctx =>
                {
                    await Task.CompletedTask;
                }; ;
            });
        }
    }
}
