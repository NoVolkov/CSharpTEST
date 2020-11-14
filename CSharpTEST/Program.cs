



















using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using VkNet;
using VkNet.Exception;
using VkNet.Categories;
using VkNet.Abstractions;
using VkNet.AudioBypassService.Utils;

using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Enums.Filters;
using VkNet.AudioBypassService;
using VkNet.AudioBypassService.Extensions;

namespace CSharpTEST
{
    class Program
    {
        static void Main(string[] args)
        {
            /*   
            var stream = new FileStream(@"E:\HI.txt",FileMode.OpenOrCreate);
            for (int i = 0; i < stream.Length; i++)
            {
                Console.Write((char)stream.ReadByte());
            }
            string str = "Hello there";
            foreach(char s in str)
            {
                stream.WriteByte((byte)s);
            }
            stream.Close();
            */
            var services = new ServiceCollection();
            services.AddAudioBypass();
            
            VkApi api = new VkApi(services);
            var auth=new ApiAuthParams();
            auth.Login = "vdm.volkov249@mail.ru";
            auth.Password = "Wsufy2016Rjcvjltcfyn";
            auth.ApplicationId = 7658887;
            //auth.TwoFactorAuthorization = () =>Console.ReadLine(); 

            //auth.AccessToken = "5f1f49625f1f49625f1f4962c45f6b94e555f1f5f1f496200b49117c8b20227dc3f0b4a";
            Console.WriteLine(auth.TokenExpireTime);
            auth.Settings = Settings.All;
          
            Console.WriteLine();
            string cKey = null;
            ulong? cSid = null;
            while (true)
            {
                try
                {
                    Console.WriteLine(cKey + "///" + cSid);
                    Console.WriteLine(".");
                    auth.CaptchaKey = cKey;
                    auth.CaptchaSid = cSid;
                    api.Authorize(auth);
                    break;
                }
                catch (CaptchaNeededException ex)
                {

                    Console.WriteLine(ex.Img);
                    //cKey =ex.Img;
                    auth.CaptchaKey = Convert.ToString(ex.Img);
                    auth.CaptchaSid = ex.Sid;//Convert.ToUInt64(Console.ReadLine());
                    api.Authorize(auth);
                    break;
                    Console.WriteLine(cKey+"///"+cSid);
                    //       api.Authorize(auth);
                }
                
            }
            //Console.WriteLine("End");





            /* api.Authorize(new ApiAuthParams
             {
                 Login = "vdm.volkov249@mail.ru",
                 Password = "Wsufy20016Rjcvjltcfyn"
              });*/

            /*var mes = new MessagesSendParams();
            
            mes.RandomId = new Random().Next(999999);
            mes.ChatId = 238254422;
            mes.Message = "123";
            api.Messages.Send(mes);*/
            var f = api.Friends.GetLists(238254422);
            foreach(var t in f)
            {
                Console.WriteLine(t.Id+" // "+t.Name);
            }
            
            
           // Console.WriteLine(api.Messages.GetConversations(new GetConversationsParams()));
            
        }
    }
}
