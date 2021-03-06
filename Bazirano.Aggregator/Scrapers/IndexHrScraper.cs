﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Toolkit.Parsers.Rss;
using System.Text;
using System.Collections.Generic;
using Bazirano.Aggregator.Interfaces;
using Bazirano.Aggregator.Helpers;
using Bazirano.Library.Enums;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Bazirano.Aggregator.Models;

namespace Bazirano.Aggregator.Scrapers
{
    public class IndexHrScraper : IScraper
    {
        private const string FeedUrl = "https://www.index.hr/rss/najcitanije";

        private readonly IHttpHelper httpHelper;
        private readonly KeywordHelper keywordHelper;

        public IndexHrScraper(IHttpHelper httpHelper)
        {
            this.httpHelper = httpHelper;

            keywordHelper = new KeywordHelper();
        }

        public async Task<List<Article>> GetArticlesAsync()
        {
            var articles = await ScrapeArticles();

            return articles;
        }

        private async Task<List<Article>> ScrapeArticles()
        {
            var articles = new List<Article>();

            var feed = await httpHelper.Get(FeedUrl);

            if (string.IsNullOrEmpty(feed))
            {
                throw new NullReferenceException($"Could not get feed from url {FeedUrl}");
            }

            var parser = new RssParser();
            var rss = parser.Parse(feed);
            var newestArticlesSchemas = rss.OrderByDescending(x => x.PublishDate).Take(10);

            foreach (var schema in newestArticlesSchemas)
            {
                if (schema.Categories.Contains("Vijesti"))
                {
                    articles.Add(new Article
                    {
                        Source = NewsSource.IndexHr,
                        Guid = GetGuidFromUrl(schema.InternalID),
                        Title = schema.Title,
                        Image = schema.ImageUrl,
                        Text = await GetArticleText(schema.InternalID),
                        Summary = schema.Summary,
                        Keywords = keywordHelper.GetKeywordsFromTitle(schema.Title),
                        SourceUrl = schema.InternalID
                    });
                }
            }

            return articles;
        }

        private async Task<string> GetArticleText(string url)
        {
            var document = await httpHelper.GetDocumentFromUrl(url);
            var paragraphs = document
                .QuerySelectorAll("div.text > p")
                .Where(x => x.ChildElementCount == 0);

            var paragraphStringBuilder = new StringBuilder();
            foreach (var par in paragraphs)
            {
                paragraphStringBuilder.Append(par.TextContent + Environment.NewLine + Environment.NewLine);
            }

            return paragraphStringBuilder.ToString();
        }

        private long GetGuidFromUrl(string url)
        {
            var index = url.IndexOf("id=") + 3;
            var guid = url.Substring(index);

            return Convert.ToInt64(guid);
        }
    }
}