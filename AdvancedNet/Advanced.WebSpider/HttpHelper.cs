using System;
using System.IO;
using System.Net;
using System.Text;
using HtmlAgilityPack;

namespace Advanced.WebSpider
{
    public class HttpHelper
    {
        /// <summary>
        /// 这个请求是请求主页面url，ajax暂时抓不到
        /// 数据筛选为HtmlAgilityPack
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public static string DownloadHtml(string url,Encoding encode)
        {
            string html = string.Empty;
            try
            {
                HttpWebRequest request =HttpWebRequest.Create(url) as HttpWebRequest ;
                request.Timeout = 30 * 1000;
                request.UserAgent = "";
                request.ContentType = "";
                request.Headers.Add("Cookie", "");
                #region 自动读取cookie
                request.CookieContainer = new CookieContainer();


                #endregion


                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {

                    }
                    else
                    {
                        try
                        {
                            //读取cookie
                            string sessionValue = response.Cookies[""].Value;

                            StreamReader sr = new StreamReader(response.GetResponseStream(), encode);
                            html = sr.ReadToEnd();
                            sr.Close();
                        }
                        catch (Exception ex)
                        {
                            return null;
                        }
                    }
                }


            }
            catch (Exception ex)
            { 
            }
            return html;
        
        }
        public static void Parse(string html)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            string pageNumberPath = "";
            HtmlNode pageNumberNode = doc.DocumentNode.SelectSingleNode(pageNumberPath);
            if (pageNumberNode!=null)
            {
                string sNumber = pageNumberNode.InnerText;
                for (int i=1;i<int.Parse(sNumber)+1;i++)
                {
                    //string pageUrl = string.Format("{0}&page={1}", category.url, i);
                    try
                    {

                    }
                    catch (Exception ex)
                    { 
                    }
                }
            }

        }







    }
}
