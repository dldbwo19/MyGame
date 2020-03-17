using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using System.Linq;
using System.Net;
using System.IO;

public class Leaderboard : MonoBehaviour
{
    /*
    [SerializeField] Text playerID;
    [SerializeField] Text record;
    */

    /*
    async void Start()
    {
        await RequestAsync("ididi아이디did", -비번20,cookie_1);
        await RequestAsync("데이터id", 데이터 value,cookie_1);
        await Response_webAsync();
    }
    */
    public void RequestBut()
    {
        Request("ididqwrdid", -20);
    }


   
    public static string Request(string id, int record)
    {


        string struri = "http://localhost:65251/api/ranks";
        string quest = "{\"identifier\":" + "\"" + id + "\",\"record\":" + Convert.ToString(record) + "}";

        //string data = string.Format("{\"identifier\":\"{0}\",\"record\":{1}}", null,Convert.ToString(record));
        // string data = string.Format("identifier={0}&record={1}", null, record);
        // byte[] byteData = UTF8Encoding.UTF8.GetBytes(data);
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(struri);
        req.Method = "POST";
        req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3";
        req.KeepAlive = true;
        req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/76.0.3809.132 Safari/537.36";
        req.ContentType = "application/json; charset=utf-8";
        WebHeaderCollection myclient = req.Headers;
        myclient.Add("Accept-Encoding", "gzip, deflate, br");
        myclient.Add("Accept-Language", "ko-KR,ko;q=0.9,en-US;q=0.8,en;q=0.7");
        req.Headers.Set(HttpRequestHeader.CacheControl, "max-age=0");
        req.ProtocolVersion = HttpVersion.Version10;
        //   req.ContentLength = byteData.Length;
        req.Headers.Add("Sec-Fetch-Mode", "navigate");
        req.Headers.Add("Sec-Fetch-Site", "none");
       
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

        req.ContentType = "Application/JSON";
        //req.CookieContainer = cook;
        StreamWriter writer = new StreamWriter(req.GetRequestStream());
        writer.Write(quest);
        writer.Close();

        /*
        using (Stream postStream = req.GetRequestStream())
        {
            postStream.Write(byteData, 0, byteData.Length);
        }
        */
        HttpWebResponse result = (HttpWebResponse) req.GetResponse();
        if (result.StatusCode == HttpStatusCode.OK)
        {
            Encoding encode = Encoding.GetEncoding("utf-8");
            Stream strReceiveStream = result.GetResponseStream();
            StreamReader reqStreamReader = new StreamReader(strReceiveStream, encode);
            string strResult = reqStreamReader.ReadToEnd();
            req.Abort();
            strReceiveStream.Close();
            reqStreamReader.Close();

            Console.WriteLine(strResult);

            return strResult;

        }
        return null;
    }

    public async System.Threading.Tasks.Task<string> Response_webAsync()
    {

        HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://localhost:44393/api/ranks");
        req.Method = "GET";
        req.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate | DecompressionMethods.None;
        req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3";
        req.Headers.Add("Accept-Encoding", "gzip, deflate, br");
        req.ContentType = "application/json";
       
        HttpWebResponse result2 = (HttpWebResponse)await req.GetResponseAsync();
        TextReader r = (TextReader)new StreamReader(result2.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
        //Console.WriteLine(r.ReadToEnd());
        string strhtml = r.ReadToEnd();
        Console.WriteLine(strhtml);

        return null;

    }


}
