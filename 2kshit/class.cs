// Copyright(C) 2023 Abjust 版权所有。

// 本程序是自由软件：你可以根据自由软件基金会发布的GNU Affero通用公共许可证的条款，即许可证的第3版或（您选择的）任何后来的版本重新发布它和/或修改它。。

// 本程序的发布是希望它能起到作用。但没有任何保证；甚至没有隐含的保证。本程序的分发是希望它是有用的，但没有任何保证，甚至没有隐含的适销对路或适合某一特定目的的保证。 参见 GNU Affero通用公共许可证了解更多细节。

// 您应该已经收到了一份GNU Affero通用公共许可证的副本。 如果没有，请参见<https://www.gnu.org/licenses/>。

using Mirai.Net.Data.Events.Concretes.Group;
using Mirai.Net.Data.Events.Concretes.Message;
using Mirai.Net.Data.Events.Concretes.Request;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Data.Shared;
using Mirai.Net.Sessions;
using Mirai.Net.Sessions.Http.Managers;
using Mirai.Net.Utils.Scaffolds;
using Net_2kShit.m;
using System.Reactive.Linq;

namespace Net_2kShit
{
    internal class Class
    {
        static async Task Main()
        {
            // ➗🔟🎨⭕局变💡
            if (!System.IO.File.Exists("g.txt"))
            {
                string[] l={ "owner_qq=", "api=", "api_key=", "bot_qq=", "verify_key=" };System.IO.File.Create("g.txt").Close();await System.IO.File.WriteAllLinesAsync("g.txt",l);
                Console.WriteLine("全局变量文件已创建！现在，你需要前往项目文件夹或者程序文件夹找到g.txt并按照要求编辑");
                Environment.Exit(0);
            }
            else
            {
                foreach (string line in System.IO.File.ReadLines("g.txt"))
                {
                    string[] s=line.Split("=");
                    if (s.Length==2){if (s[0]=="owner_qq"){G.Oq=s[1];}else if(s[0]=="api"){G.A=s[1];}else if(s[0]=="api_key"){G.Ak=s[1];}else if(s[0]=="bot_qq"){G.bq=s[1];}else if(s[0]=="verify_key"){G.vK = s[1];}}
                }
            }
            // 7️🕳️📝7️人程序
            using var b=new MiraiBot{Address="localhost:8080",QQ=G.bq,VerifyKey=G.vK};
            await b.LaunchAsync();
            // 🔟➖8️分
            // ❌1️❌
            b.EventReceived.OfType<NudgeEvent>().Subscribe(async n =>{if(n.Target==G.bq&&n.Subject.Kind=="Group"){try{await MessageManager.SendGroupMessageAsync(n.Subject.Id,"狗日的，你tm还有脸戳我？");}catch{}}else if(n.Target==G.bq&&n.Subject.Kind=="Friend"){try{await MessageManager.SendFriendMessageAsync(n.Subject.Id,"cnmlgbd，还跑到私信里来了？");}catch{}}});
            // 被➕👍🈶
            b.EventReceived.OfType<NewFriendRequestedEvent>().Subscribe(async f =>{await f.ApproveAsync();});
            //➕👗
            b.EventReceived.OfType<NewInvitationRequestedEvent>().Subscribe(async iv =>{await RequestManager.HandleNewInvitationRequestedAsync(iv,NewInvitationRequestHandlers.Approve,"");});
            // ➕👗请⚽
            b.EventReceived.OfType<NewMemberRequestedEvent>().Subscribe(async rq =>{try{await MessageManager.SendGroupMessageAsync(rq.GroupId,"not implemented");}catch{}});
            // name🔧改
            b.EventReceived.OfType<MemberCardChangedEvent>().Subscribe(async nm =>{if(nm.Current!=""){try{await MessageManager.SendGroupMessageAsync(nm.Member.Group.Id,$"QQ号：{nm.Member.Id}\r\n原昵称：{nm.Origin}\r\n新昵称：{nm.Current}");}catch {}}});
            // 🚗回
            b.EventReceived.OfType<GroupMessageRecalledEvent>().Subscribe(async rc =>{var messageChain=new MessageChainBuilder().At(rc.Operator.Id).Plain(" 你又撤回了什么见不得人的东西？").Build();if (rc.AuthorId!=rc.Operator.Id){if(rc.Operator.Permission.ToString()!="Administrator"&&rc.Operator.Permission.ToString()!="Owner"){try{await MessageManager.SendGroupMessageAsync(rc.Group.Id,messageChain);}catch{}}}else{try{await MessageManager.SendGroupMessageAsync(rc.Group.Id, messageChain);}catch{}}});
            // kick仁
            b.EventReceived.OfType<MemberKickedEvent>().Subscribe(async k =>{try{await MessageManager.SendGroupMessageAsync(k.Member.Group.Id,$"{k.Member.Name} ({k.Member.Id}) 被踢出去辣，好似，开香槟咯！");}catch{}});
            // 🦵👗
            b.EventReceived.OfType<MemberLeftEvent>().Subscribe(async qt =>{try{await MessageManager.SendGroupMessageAsync(qt.Member.Group.Id,$"{qt.Member.Name} ({qt.Member.Id}) 退群力（悲）"); } catch {}});
            // 🈲👗
            b.EventReceived.OfType<MemberJoinedEvent>().Subscribe(async j =>{MessageChain? messageChain = new MessageChainBuilder().At(j.Member.Id).Plain(" 来辣，让我们一起撅新人！（bushi").Build();try{await MessageManager.SendGroupMessageAsync(j.Member.Group.Id, messageChain);}catch{}});
            // 4️聊😁息
            b.MessageReceived.OfType<FriendMessageReceiver>().Subscribe(async pv =>{if(pv.FriendId!=G.Oq){MessageChain? messageChain=new MessageChainBuilder().Plain($"消息来自：{pv.FriendName} ({pv.FriendId})\n消息内容：").Build();foreach(MessageBase message in pv.MessageChain){messageChain.Add(message);await MessageManager.SendFriendMessageAsync(G.Oq, messageChain);}}});
            // 👗😁息
            b.MessageReceived.OfType<GroupMessageReceiver>().Subscribe(async gp =>{
                string m = gp.MessageChain.GetPlainMessage();
                if (m == "版本")
                {
                    List<string> splashes = new()
                        {
                            "也试试HanBot罢！Also try HanBot!",
                            "誓死捍卫微软苏维埃！",
                            "打倒MF独裁分子！",
                            "要把反革命分子的恶臭思想，扫进历史的垃圾堆！",
                            "PHP是世界上最好的编程语言（雾）",
                            "社会主义好，社会主义好~",
                            "Minecraft很好玩，但也可以试试Terraria！",
                            "So Nvidia, f**k you!",
                            "战无不胜的马克思列宁主义万岁！",
                            "Bug是杀不完的，你杀死了一个Bug，就会有千千万万个Bug站起来！",
                            "跟张浩扬博士一起来学Jvav罢！",
                            "哼哼哼，啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊",
                            "你知道吗？其实你什么都不知道！",
                            "Tips:这是一条烫...烫..烫知识（）",
                            "你知道成功的秘诀吗？我告诉你成功的秘诀就是：我操你妈的大臭逼",
                            "有时候ctmd不一定是骂人 可能是传统美德",
                            "python不一定是编程语言 也可能是屁眼通红",
                            "这条标语虽然没有用，但是是有用的，因为他被加上了标语",
                            "使用C#编写！"
                        };
                    Random r = new();int random = r.Next(splashes.Count);
                    try{await MessageManager.SendGroupMessageAsync(gp.GroupId,$"机器人版本：1.0.0-alpha1\r\n上次更新日期：2023/6/10\r\n更新内容：做不被定义的bot\r\n---------\r\n{splashes[random]}");}catch{}}});
        }
    }
}