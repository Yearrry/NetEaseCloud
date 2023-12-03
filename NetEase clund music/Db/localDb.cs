using NetEase_clund_music.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace NetEase_clund_music.Db
{
    public class localDb
    {
        public localDb()
        {
            init();
        }

        public List<SongList> SongListsOne;

        public List<SongList> SongListsTwo;

        public List<Exclusiveover> Exclusiveovers;

        public List<ListBoxItem> listBoxItemsOne;

        public List<ListBoxItem> HostStationListBoxItems;

        public static List<SongData> SongList;

        private void init()
        {
            listBoxItemsOne = new List<ListBoxItem>()
            {
               new ListBoxItem(){Background = new ImageBrush(){ ImageSource = new BitmapImage(new Uri("pack://application:,,,/ResuourceHome/images/cb4.jpg",UriKind.Absolute)),Stretch = Stretch.UniformToFill },Content ="独家策划" },
               new ListBoxItem(){Background = new ImageBrush(){ ImageSource = new BitmapImage(new Uri("pack://application:,,,/ResuourceHome/images/Afflatus9.jpg",UriKind.Absolute)),Stretch = Stretch.UniformToFill },Content ="广告" },
               new ListBoxItem(){Background = new ImageBrush(){ ImageSource = new BitmapImage(new Uri("pack://application:,,,/ResuourceHome/images/Cowboy11.jpg",UriKind.Absolute)),Stretch = Stretch.UniformToFill },Content ="广告" },
               new ListBoxItem(){Background = new ImageBrush(){ ImageSource = new BitmapImage(new Uri("pack://application:,,,/ResuourceHome/images/Cowboy9.png",UriKind.Absolute)),Stretch = Stretch.UniformToFill },Content ="星际牛仔专栏" },
               new ListBoxItem(){Background = new ImageBrush(){ ImageSource = new BitmapImage(new Uri("pack://application:,,,/ResuourceHome/images/wallhaven-42xp5g.jpg",UriKind.Absolute)),Stretch = Stretch.UniformToFill },Content ="R&M" },
            };

            HostStationListBoxItems = new List<ListBoxItem>()
            {
                new ListBoxItem(){Background = new ImageBrush(){ ImageSource = new BitmapImage(new Uri("pack://application:,,,/ResuourceHome/images/wide/21090903s.jpg",UriKind.Absolute)),Stretch = Stretch.UniformToFill },Content ="Super" },
               new ListBoxItem(){Background = new ImageBrush(){ ImageSource = new BitmapImage(new Uri("pack://application:,,,/ResuourceHome/images/wide/21090904s.jpeg",UriKind.Absolute)),Stretch = Stretch.UniformToFill },Content ="Universe" },
               new ListBoxItem(){Background = new ImageBrush(){ ImageSource = new BitmapImage(new Uri("pack://application:,,,/ResuourceHome/images/wide/wallhaven-z8ql8w.jpg",UriKind.Absolute)),Stretch = Stretch.UniformToFill },Content ="Invincible" },
               new ListBoxItem(){Background = new ImageBrush(){ ImageSource = new BitmapImage(new Uri("pack://application:,,,/ResuourceHome/images/wide/21090902.jpeg",UriKind.Absolute)),Stretch = Stretch.UniformToFill },Content ="Sharp" },
               new ListBoxItem(){Background = new ImageBrush(){ ImageSource = new BitmapImage(new Uri("pack://application:,,,/ResuourceHome/images/wide/21090905.jpeg",UriKind.Absolute)),Stretch = Stretch.UniformToFill },Content ="N Carousel" },
            };

            SongListsOne = new List<SongList>()
            {
                new SongList(){SongListType = SongListType.NoBreak,SongListName="每日歌曲推荐",Image="pack://application:,,,/ResuourceHome/images/gd1.jpg",Listentime = 9527,
                Remark = "根据你的音乐口味生成，每日更新"},
                 new SongList(){SongListType = SongListType.PrivateRadar,SongListName="今日从《孤独患者》听起 | 私人雷达",Image="pack://application:,,,/ResuourceHome/images/gd3.jpg",Listentime = 58484 ,
                 Remark ="猜你喜欢"},
                new SongList(){SongListType = SongListType.Default,SongListName="复古浪潮Disco/EDM || 适合一杯日落Martini",Image="pack://application:,,,/ResuourceHome/images/gd2.jpg",Listentime = 8848 ,
                Remark = "根据你喜欢的歌手《陈奕迅》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="Jazz Hiphop | 落日武士",Image="pack://application:,,,/ResuourceHome/images/gd4.jpg",Listentime = 45152 ,
                Remark ="落日西行，Jazz Hiphop"},
                new SongList(){SongListType = SongListType.Default,SongListName="一首粤曲 唱述一生",Image="pack://application:,,,/ResuourceHome/images/gd5.jpg",Listentime = 98712 ,
                Remark ="根据你喜欢的《春夏秋冬》推荐"},
                new SongList(){SongListType = SongListType.Customize,SongListName="【华语私人定制】最懂你的华语推荐 每日更新35首",Image="pack://application:,,,/ResuourceHome/images/gd7.jpg",Listentime = 31566,
                Remark ="猜你喜欢"},
                new SongList(){SongListType = SongListType.Default,SongListName="放松调配 | 把心情转到最佳位置",Image="pack://application:,,,/ResuourceHome/images/gd6.jpg",Listentime = 11515,
                Remark = "根据你喜欢的《Luv(sic)》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="余音绕梁 | 巴拉阿巴乌拉拉",Image="pack://application:,,,/ResuourceHome/images/gd8.jpg",Listentime = 48489,
                Remark = "根据你喜欢的《Closer(80s Remix)》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="仙书一半 | 除非你是我，才可昼夜同在",Image="pack://application:,,,/ResuourceHome/images/gd11.jpg",Listentime = 51515,
                Remark = "根据你喜欢的《与我常在》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
            };

            SongListsTwo = new List<SongList>()
            {
                new SongList(){SongListType = SongListType.BoutiqueList,SongListName="精品歌单",Image="pack://application:,,,/ResuourceHome/images/gd1.jpg",Listentime = 9527,
                Remark = "精品歌单倾心推荐，给最懂音乐的你"},
                 new SongList(){SongListType = SongListType.OfficialList,SongListName="华语私人定制",Image="pack://application:,,,/ResuourceHome/images/gd3.jpg",Listentime = 58484 ,
                 Remark ="【华语私人定制】 最懂你的华语推荐 每日更新35首"},
                new SongList(){SongListType = SongListType.Default,SongListName="华语速爆新歌",Image="pack://application:,,,/ResuourceHome/images/gd2.jpg",Listentime = 8848 ,
                Remark = "【华语速爆新歌】 听回春丹式经典重塑，忆初恋时不经意的相遇沉溺sfdsaf"},
                new SongList(){SongListType = SongListType.OfficialList,SongListName="华语R&B",Image="pack://application:,,,/ResuourceHome/images/gd4.jpg",Listentime = 45152 ,
                Remark ="【华语节奏布鲁斯】 情绪辗转反侧，雾气消散不开"},
                new SongList(){SongListType = SongListType.OfficialList,SongListName="流行点唱机",Image="pack://application:,,,/ResuourceHome/images/gd5.jpg",Listentime = 98712 ,
                Remark ="【流行点唱机】 2010年代华语热播 每日30首"},
                new SongList(){SongListType = SongListType.OfficialList,SongListName="一周影视热歌",Image="pack://application:,,,/ResuourceHome/images/gd7.jpg",Listentime = 31566,
                Remark ="[一周影视热歌] 周深与你共享“夏日友情天”"},
                new SongList(){SongListType = SongListType.Default,SongListName="放松调配 | 把心情转到最佳位置",Image="pack://application:,,,/ResuourceHome/images/gd6.jpg",Listentime = 11515,
                Remark = "【小行星蓝调】 不停的逃跑，哪里才是尽头呢？    - 斯派克"},
                new SongList(){SongListType = SongListType.Default,SongListName="余音绕梁 | 巴拉阿巴乌拉拉",Image="pack://application:,,,/ResuourceHome/images/gd8.jpg",Listentime = 48489,
                Remark = "【小行星蓝调】 不停的逃跑，哪里才是尽头呢？    - 斯派克"},
                new SongList(){SongListType = SongListType.Default,SongListName="仙书一半 | 除非你是我，才可昼夜同在",Image="pack://application:,,,/ResuourceHome/images/gd11.jpg",Listentime = 51515,
                Remark = "【小行星蓝调】 不停的逃跑，哪里才是尽头呢？    - 斯派克"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/xxx1.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/mn14.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/gd3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
                new SongList(){SongListType = SongListType.Default,SongListName="欧美万评 | 格莱美",Image="pack://application:,,,/ResuourceHome/images/om3.jpg",Listentime = 15456,
                Remark = "根据你喜欢的《What Do You Mean》推荐"},
            };

            //独家放送
            Exclusiveovers = new List<Exclusiveover>()
            {
                new Exclusiveover(){ image = "pack://application:,,,/ResuourceHome/images/wide/wallhaven-z8ql8w.jpg",remark="《今日营业中》 除非你是我，才可与我常在" },
                new Exclusiveover(){ image = "pack://application:,,,/ResuourceHome/images/wide/cb4.jpg",remark="《星际牛仔》 有星星掉下来了。那不是颗普通的星星，是战士的眼泪" },
                new Exclusiveover(){ image = "pack://application:,,,/ResuourceHome/images/wide/wallhaven-n6r73q.png",remark="《瑞克与莫蒂》 宇宙是一头猛兽，它以平庸的人为食" },
            };

            SongList = new List<SongData>()
            {
                new SongData()
                {
                    Songid = 1,
                    Song_Lyric="[00:00:00]作词：林夕\n[00:01.00]作曲：伍乐城\n[00:16.870]童年你与谁渡过\n[00:20.170]圣诗班中唱的歌\n[00:23.600]再哼一哼可以么\n[00:30.470]当时谁与你排着坐\n" +
                "[00:34.220]白色恤衫灰裤子\n[00:37.700]再穿一穿可以么\n[00:42.840]遗憾我当时年纪不可亲手拥抱你欣赏\n[00:49.820]童年便相识\n" +
                "[00:51.530]余下日子多闪几倍光\n[00:56.670]谁让我倒流时光一起亲身跟你去分享\n[01:03.490]能留下印象\n[01:05.170]阅览你家中每道墙\n" +
                "[01:10.050]拿着你歌书\n[01:13.630]与你合唱\n[01:19.340]\n[01:29.640]童年你与谁路过\n[01:33.010]逛的公园有几多\n[01:36.500]再走一走可以么\n" +
                "[01:43.350]当时谁对你凝望过\n[01:46.780]是否真的比我多\n[01:50.230]再演一演可以么\n[01:55.710]遗憾我当时年纪不可亲手拥抱你欣赏\n" +
                "[02:02.200]童年便相识\n[02:03.830]余下日子多闪几倍光\n[02:09.140]谁让我倒流时光一起亲身跟你去分享\n[02:15.970]遗憾印象\n[02:17.600]没有你家中那面墙\n" +
                "[02:22.590]拿着你相簿\n[02:25.970]从前拍过的相\n[02:30.810]多么妒忌你昨日同过的窗\n[02:37.560]早些看着你美丽模样\n[02:42.300]对你天真的赞赏\n" +
                "[02:51.390]遗憾我当时年纪不可亲手拥抱你欣赏\n[02:58.070]童年便相识\n[02:59.440]余下日子多闪几倍光\n[03:04.590]谁让我倒流时光一起亲身跟你去分享\n" +
                "[03:11.770]遗憾印象\n[03:13.210]没有你家中那面墙\n[03:18.380]拿着你相簿\n[03:21.500]从头细看\n[03:24.560]你六岁当天\n[03:27.950]已是我偶像\n",
                    Singer_Song = new Singer(){ SingerName = "陈奕迅", SingerImage = "pack://application:,,,/ResuourceHome/images/cyx1.jpg"},
                    SongDiskAddress = @"H:\CloudMusic\时光倒流二十年.m4a",
                    SongName = "时光倒流二十年(Live In Hong Kong, 2013)",
                    Album = new SongList(){ SongListName = "Eason's Life 陈奕迅2013演唱会"},
                 },

                new SongData()
                {
                    Songid = 2,
                    Song_Lyric = "[00:02.440]Oh Yeah (Prod. Noria)\n[00:03.439]Oh oh yeah\n[00:07.191]U been hurt me so much so\n[00:08.441]Oh yeah\n[00:12.940]So baby do u like me like em\n" +
                    "[00:14.941]Oh yeah\n[00:16.940]Set this trap on me said I’m the\n[00:18.690]One yeah\n[00:20.440]Now its 4 at night\n[00:22.190]So where u at\n[00:24.689]Should I drown in my dream\n" +
                    "[00:29.440]Said oh yeah yeah\n[00:32.142]Baby u don wear the save belt\n[00:35.892]Should I never told her don stay here\n[00:39.392]Like the shame I can’t say\n[00:45.891]Lil bit animal lil beast\n" +
                    "[00:47.393]U are\n[00:49.392]Have never been sweating me\n[00:50.642]Like this u are\n[00:52.892]Everyday I’m starting to counting me the ratio about\n" +
                    "[00:56.144]I finna erase the pain with the ice on the em whisky\n[00:58.892]I was so low in bankroll\n[01:00.642]Waking up wondering when should we have meal\n" +
                    "[01:02.893]Cash in my wallet I don wanna waste em\n[01:05.393]I came from the mud no reason\n[01:06.893]Looking the light when sun going down\n[01:08.143]Its a beautiful dawn I call it profound\n" +
                    "[01:10.143]Look what we had its hard to be found\n[01:12.142]But still we found it\n[01:13.142]Baby girl\n[01:13.893]Like oh yeah\n[01:15.892]U been telling lies all this time oh yeah\n" +
                    "[01:19.642]If u really tryna fk like\n[01:21.393]Oh yeah\n[01:23.393]U should never call me like some decent\n[01:27.142]Ever think about condition oh yeah\n[01:31.644]She just set me up yeah\n" +
                    "[01:35.392]U should watch me inside\n[01:38.892]Should I call it a end\n[01:44.143]So is it bout me\n[01:45.893]For no reason I will change\n[01:49.392]But u will never know\n" +
                    "[01:51.392]I was trembling when wake up\n[01:53.392]Play myself then stay down\n[01:57.142]U never know\n[01:58.893]Shawty got mood\n[01:59.642]Shawty got light\n[02:00.642]Shawty got magic\n" +
                    "[02:01.643]Shawty is alive\n[02:02.392]Shining in my bed\n[02:03.392]Shining with back\n[02:04.392]One of kind\n[02:05.393]Hard to imagine\n[02:06.144]How many nights\n[02:07.143]U were my baby\n" +
                    "[02:08.142]Now its a story\n[02:08.893]I call u daisy\n[02:09.894]U call me fishy\n[02:10.896]Its all\n[02:12.641]Oh yeah\n[02:15.142]Elves with the ocean eyes\n[02:16.892]What’s that\n" +
                    "[02:18.642]I should never telling lies\n[02:20.389]I don care\n[02:23.396]Oh yeah\n[02:25.642]Well\n[02:26.144]Baby girl she stab like\n[02:27.893]Oh yeah\n[02:29.894]I should be the one she call me\n" +
                    "[02:31.644]Oh yeah\n[02:33.641]I should never telling lies\n[02:34.892]I don care\n[02:38.144]Oh yeah",

                    Singer_Song = new Singer(){ SingerName = "K.O.R", SingerImage = "pack://application:,,,/ResuourceHome/images/cyx1.jpg"},
                    SongDiskAddress = @"H:\CloudMusic\Oh Yeah.m4a",
                    SongName = "Oh Yeah (Prod. Noria)",
                    Album = new SongList(){ SongListName = "Oh Yeah"},
                 },

                new SongData()
                {
                    Songid = 3,
                    Song_Lyric = "[00:00.00]纯音乐，请您欣赏",

                    Singer_Song = new Singer(){ SingerName = "FKJ", SingerImage = "pack://application:,,,/ResuourceHome/images/cyx1.jpg"},
                    SongDiskAddress = @"H:\CloudMusic\Ylang Ylang.m4a",
                    SongName = "Ylang Ylang",
                    Album = new SongList(){ SongListName = "Ylang Ylang EP"},
                 }
            };
           
        }

        public List<T> GetList<T>(string listName)
        {
            if (listName == "SongListsOne")
            {
                return (List<T>)(Object)SongListsOne;
            }
            else if(listName == "SongListsTwo")
            {
                return (List<T>)(Object)SongListsTwo;
            }
            else if (listName == "Exclusiveovers")
            {
                return (List<T>)(Object)Exclusiveovers;
            }
            else if (listName == "listBoxItemsOne")
            {
                return (List<T>)(Object)listBoxItemsOne;
            }
            else if (listName == "HostStationListBoxItems")
            {
                return (List<T>)(Object)HostStationListBoxItems;
            }
            else
            {
                return null;
            }
        }

        public string GetLyric(int id)
        {
            string Lyric = SongList.Where(x => x.Songid == id).ToList()[0].Song_Lyric;
            return Lyric;
        }

        public static SongData GetSong(int id)
        {
            SongData ss = new SongData();

            if(SongList.Where(x=>x.Songid == id).Count() != 0)
            {
                ss = SongList.Where(x => x.Songid == id).ToList()[0];
            }
            return ss;
        }

    }
}
