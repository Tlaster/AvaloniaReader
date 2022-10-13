using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;
using AvaloniaReader.UI.Model;
using Humanizer;

namespace AvaloniaReader.Repository;

class FeedRepository
{
    public Task<ImmutableList<UiFeedItem>> GetFeedItems(string target)
    {
        return Task.Run(() =>
        {
            try
            {
                using var reader = XmlReader.Create(target);
                var feed = SyndicationFeed.Load(reader);
                return feed.Items.Select(item => new UiFeedItem
                (
                    Title:item.Title.Text,
                    Desc: item.Summary.Text,
                    Link: item.Links.FirstOrDefault()?.Uri.ToString() ?? string.Empty
                )).ToImmutableList();
            }
            catch
            {
                return ImmutableList<UiFeedItem>.Empty;
            }
        });
    }

    public Task<ImmutableList<UiFeedSource>> GetFeedSource()
    {
        return Task.FromResult(new[]
        {
            new UiFeedSource("IT之家", "https://www.ithome.com/rss/"),
            new UiFeedSource("cnBeta", "https://www.cnbeta.com/backend.php"),
            new UiFeedSource("36Kr", "https://36kr.com/feed"),
            new UiFeedSource("V2EX", "https://www.v2ex.com/feed/tab/tech.xml"),
            new UiFeedSource("InfoQ", "https://www.infoq.cn/feed"),
            new UiFeedSource("开发者头条", "https://toutiao.io/rss"),
            new UiFeedSource("伯乐在线", "https://blog.jobbole.com/feed/"),
            new UiFeedSource("掘金", "https://juejin.cn/feed"),
            new UiFeedSource("SegmentFault", "https://segmentfault.com/blogs?format=rss"),
            new UiFeedSource("CSDN", "https://blog.csdn.net/rss/list"),
            new UiFeedSource("博客园", "https://www.cnblogs.com/sitehome/rss"),
            new UiFeedSource("知乎", "https://www.zhihu.com/rss"),
            new UiFeedSource("简书", "https://www.jianshu.com/rss"),
        }.ToImmutableList());
    }

    public async Task<UiArticle> GetArticle(string url)
    {
        var reader = new SmartReader.Reader(url);
        var article = await reader.GetArticleAsync();
        return new UiArticle(Title: article.Title ?? "", Content: article.Content ?? "", Author: article.Author ?? "", Url: url, ImageUrl: article.FeaturedImage ?? "", PublishDate: article.PublicationDate?.Humanize() ?? "");
    }
}