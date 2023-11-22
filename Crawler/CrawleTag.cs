﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Crawler
{
    internal class CrawleTag
    {
        private readonly HtmlWeb _htmlWeb;
        public CrawleTag()
        {
          
           
            _htmlWeb = new HtmlWeb();
            _htmlWeb.UserAgent = "bing";

        }


        public void startCrawle(int pagenumber)
        {
           
            for (int i = pagenumber; i < (pagenumber + 300); i++)
            {

                try
                {
                
                
                    string baseurl = $"https://www.digikala.com/search/category-stationery-sub/?page={i}&sort=7";
                    Console.WriteLine(baseurl);
                    GetImages(baseurl);
                    
                }
                catch (Exception e)
                {

                    Console.WriteLine( e.Message);
                    continue;
                }

            }
        }
        private HtmlNodeCollection GetProductTags(string Url)
        {


          
            var htmlDoc = _htmlWeb.Load(Url);
            var res = htmlDoc.DocumentNode.SelectNodes("//a[contains(@class, 'block cursor-pointer relative')]");
            return res;

           
        }

        private void GetImages(string Url)
        {
            var PicsDir = Path.Combine(Directory.GetCurrentDirectory(), "pic");
            if (!Directory.Exists(PicsDir))
            {
                Directory.CreateDirectory(PicsDir);
            }


            foreach (var item in GetProductTags(Url))
            {



                try
                {

                    var LinkValue = item.Attributes["href"].Value;

                    var htmlDoc = _htmlWeb.Load($"https://www.digikala.com{LinkValue}");


                    var images = htmlDoc.DocumentNode.SelectNodes("//img[contains(@class, 'w-full bg-neutral-000 inline-block')]");
                    WebClient webClient = new WebClient();
                    foreach (var image in images)
                    {
                        try
                        {
                            var imgUrl = image.Attributes["src"].Value.Split("?")[0];
                            var ImgName = Path.GetFileName(imgUrl);
                            var filepath = Path.Combine(PicsDir, ImgName);
                            webClient.DownloadFile(imgUrl, filepath);
                            Console.WriteLine($"successfully DownloadFile : {ImgName} ");


                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            continue;
                        }
                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                    continue;
                }


            }
        }
    }
}
