using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AdvancedNet.ExpressionTree
{
    /// <summary>
    /// 解析expression,通过解析express 树来构造sql语句
    /// 这比以前通过反射手动拼接sql字符串要自由的多，而且表达生成树具备缓存等功能
    /// 效率也好于反射，反射的拼接不大灵活，对于比较关系运算符的拼接，反射做不到
    /// 但是express 可以保存此结构
    /// </summary>
    public class ConditionBuilderVisitor:ExpressionVisitor
    {
        /// <summary>
        /// 栈内部存的是生成的sql语句信息
        /// </summary>
        private Stack<string> _StringStack = new Stack<string>();

        public string Condition()
        {
            string condition = string.Concat(this._StringStack.ToArray());
            this._StringStack.Clear();
            return condition;
        }

        /// <summary>
        /// 二元表达式
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (node == null) throw new ArgumentNullException("BinaryExpression");

            this._StringStack.Push(")");
            base.Visit(node.Right);
            this._StringStack.Push(" " + node.NodeType.ToSqlOperator() + " ");
            base.Visit(node.Left);
            this._StringStack.Push("(");
            return node;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (node == null) throw new ArgumentNullException("MemberExpression");
            this._StringStack.Push("[" + node.Member.Name + "]");
            return node;
        }


        /// <summary>
        /// 常量表达式
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected override Expression VisitConstant(ConstantExpression node)
        {
            if (node == null) throw new ArgumentNullException("ConstantExpression");
            this._StringStack.Push("'" + node.Value + "'");
            return node;
        }

        /// <summary>
        /// 方法表达式,比如contains,startwith,endwith等解析
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        protected override Expression VisitMethodCall(MethodCallExpression m)
        {
            if (m == null) throw new ArgumentNullException("MethodCallExpression");

            string format;
            switch (m.Method.Name)
            {
                case "StartWith":
                    format = "{0} LIKE {1}+'%'";
                    break;

                case "Contains":
                    format = "({0} LIKE '%'+{1}+'%')";
                    break;

                case "EndsWith":
                    format = "({0} LIKE '%'+{1})";
                    break;

                default:
                    throw new NotSupportedException(m.NodeType + " is not supported!");
            }
            this.Visit(m.Object);
            this.Visit(m.Arguments[0]);
            string right = this._StringStack.Pop();
            string left = this._StringStack.Pop();
            this._StringStack.Push(String.Format(format, left, right));
            return m;
        }








    }
}
