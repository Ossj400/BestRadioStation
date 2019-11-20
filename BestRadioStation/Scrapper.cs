using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using HtmlAgilityPack;
using System.Linq;

namespace BestRadioStation
{
    class Scrapper
    {
        string[] radiostationsName = new string[0];
        string[] radiostationsUrl = new string[0];
        public int element;
        public  void getHtmlNotAsync(string url)
        {
            var url_ = url;
            var httpClient = new HttpClient();
           // var html = await httpClient.GetStringAsync(url_);  <<< If I would like to do it Async
            //var htmlDocument = new HtmlDocument();
            //htmlDocument.LoadHtml(html);
            HtmlWeb web = new HtmlWeb();
            HtmlDocument htmlDocument = web.Load(url_);

            IEnumerable<HtmlNode> radioStNameHtmlDoc = htmlDocument.DocumentNode.Descendants("h4")
            .Where(node => node.Attributes.Contains("class") &&
            node.Attributes["class"].Value.Contains("a"));
            HtmlNodeCollection radioUrlHtmlDoc = htmlDocument.DocumentNode.SelectNodes("//small[@class='hidden-xs']/a[@title='PLS Playlist File']");

            string[] arrWithNames = new string[radioStNameHtmlDoc.Count()];
            string[] arrWithUrls = new string[radioUrlHtmlDoc.Count()];
            int i = 0;
            foreach (var Names in radioStNameHtmlDoc)
            {
                arrWithNames[i] = string.Format("{0}). {1}", i + 1, Names.InnerText);
                i = i + 1;
            }
            int j = 0;
            foreach (var Names in radioUrlHtmlDoc)
            {
                arrWithUrls[j] = string.Format("{0}). :{1}", j + 1, Names.OuterHtml);
                j = j + 1;
            }

            String SplitStr = "playpls', '";
            String UrlString = string.Join(",", arrWithUrls);
            String[] splittedUrlString = UrlString.Split(SplitStr);
            splittedUrlString = splittedUrlString.Skip(1).ToArray();

            int k = 0;
            foreach (var urls in splittedUrlString)
            {
                if (urls.Contains('\''))
                {
                    int index = urls.IndexOf('\'');
                    arrWithUrls[k] = urls.Substring(0, index);
                }
                k = k + 1;
            }
            int l = 0;
            foreach (var urlsm3u in arrWithUrls)   //changing file format to one which can be used in mediaElement
            {
                if (urlsm3u.Contains("listen.pls"))
                {
                    arrWithUrls[l] = urlsm3u.Replace("listen.pls", "m3u^");
                    int index = arrWithUrls[l].IndexOf('^');
                    arrWithUrls[l] = arrWithUrls[l].Substring(0, index);
                }
                l = l + 1;
            }

            radiostationsName = arrWithNames;
            radiostationsUrl = arrWithUrls;
        }
        public string[] getRadioName()
        {
            return radiostationsName;
        }
        public string[] getRadioUrl()
        {
            return radiostationsUrl;
        }
        public string whichElementUrl(int elem)
        {
            string element = radiostationsUrl[elem].ToString();
            return element;
        }
        public string whichElementName(int elem)
        {
            string element = radiostationsName[elem].ToString();
            return element;
        }

    }
}
