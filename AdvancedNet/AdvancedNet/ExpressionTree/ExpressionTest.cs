using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using AdvancedNet.ExpressionTree;
using AdvancedNet.Models;

namespace AdvancedNet
{
    public class ExpressionTest
    {
        
        /// <summary>
        /// linq to sql 实现
        /// </summary>
        public static void Test()
        {
            Expression<Func<People, bool>> lambda = x => x.Age > 5
                                                        && x.Id < 5
                                                        && x.Id == 3
                                                        && x.Name.StartsWith("1")
                                                        && x.Name.EndsWith("1")
                                                        && x.Name.Contains("1");

            //组装了expression
            new List<People>().AsQueryable().Where(x => x.Age > 5 && x.Id == 10);
            //解析expression并动态生成sql,区别反射动态拼装sql
            //SELECT * FROM People WHERE Age>5
            ConditionBuilderVisitor vistor = new ConditionBuilderVisitor();
            vistor.Visit(lambda);
            Console.WriteLine(vistor.Condition());


            #region 表达式连接，多个判断条件的连接
            {
                Expression<Func<People, bool>> lambda1 = x => x.Age > 5;
                Expression<Func<People, bool>> lambda2 = x => x.Id > 5;
                Expression<Func<People, bool>> lambda3 = lambda1.And(lambda2);
                Expression<Func<People, bool>> lambda4 = lambda1.Or(lambda2);
                Expression<Func<People, bool>> lambda5 = lambda1.Not();
                Do1(lambda3);
            }
            #endregion
        }


        /// <summary>
        /// 拼装expression tree
        /// </summary>
        public static void CombineExpression()
        {
            Func<int, int, int> func = (m, n) => m * n + 2;
            Expression<Func<int, int, int>> exp = (m, n) => m * n + 2;
            int iResult1 = func.Invoke(1,2);
            int iResult2 = exp.Compile().Invoke(1, 2);

            {
                //拼装表达生成树
                ConstantExpression right = Expression.Constant(1);
                ConstantExpression left = Expression.Constant(2);
                BinaryExpression plus = Expression.Add(left, right);
                Expression<Func<int>> expression = Expression.Lambda<Func<int>>(
                    plus, new ParameterExpression[] { }
                    );
            }
            {
                //拼装 p.Name.Contains("Eleven")AndAlso(p=>p.Age>5)

                ParameterExpression parameterExpression = Expression.Parameter(typeof(People), "p");
                //if(!name=="")
                var name = typeof(People).GetProperty("Name");
                var eleven = Expression.Constant("Eleven", typeof(string));
                var nameExp = Expression.Property(parameterExpression, name);
                var contains = typeof(string).GetMethod("Contains");
                var containsExp = Expression.Call(nameExp, contains, new Expression[]
                    { eleven});

                //if(Age输入)
                var age = typeof(People).GetProperty("Age");
                var age5 = Expression.Constant(5);
                var ageExp = Expression.Property(parameterExpression, age);
                var greatorThan = Expression.GreaterThan(ageExp, age5);
                //if()
                var body = Expression.AndAlso(containsExp, greatorThan);
                Expression<Func<People, bool>> expression = Expression.Lambda<Func<People,
                    bool>>(body, new ParameterExpression[] { parameterExpression });
                expression.Compile();

            
            
            }
        }

        /// <summary>
        /// 解读expression树
        /// </summary>
        public void ParseExpression()
        { 
            
        }

        #region 数据测试
        private static void Do1(Expression<Func<People,bool>> func)
        {
            List<People> people = new List<People>()
            {
                new People(){ Id=4,Name="123",Age=4},
                new People(){ Id=5,Name="234",Age=5},
                new People(){ Id=6,Name="345",Age=6},
            };
            List<People> peopleList = people.Where(func.Compile()).ToList();
        }



        #endregion

    }
}
