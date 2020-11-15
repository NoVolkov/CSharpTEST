using System;
using System.IO;
using System.Net;

namespace CSharpTEST
{
    class Program
    {
        static void Main(string[] args)
        {
            string url="https://api.vk.com/method/friends.get?user_id=238254422&order=name&fields=nickname,has_mobile&access_token=5f1f49625f1f49625f1f4962c45f6b94e555f1f5f1f496200b49117c8b20227dc3f0b4a&v=5.126";
            string res;
            using(var webClient = new WebClient())
            {
                //webClient.QueryString.Add("format", "json");
                res=webClient.DownloadString(url);
            }
            var stream = new FileStream(@"E:\HI.json",FileMode.OpenOrCreate);
            foreach(char s in res)
            {
                stream.WriteByte((byte)s);
            }
            Console.WriteLine(res.Length);
            
        }
    }
}
