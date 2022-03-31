using System.Collections.Generic;
using AxiLogic.Classes;
using System;
using System.IO;
using AxiLogic.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AxiLogic.Containers
{
    public class ArticleContainer
    {
    private List<Article> _articles;

    public ArticleContainer()
    {
        var jObject = JObject.Parse(File.ReadAllText(@"..\AxiLogic\Jsons\Articles.json"));
        _articles = jObject["articles"].ToObject<List<Article>>();
    }

    public IReadOnlyCollection<Article> GetArticles()
    {
        return _articles;
    }

    public void AddArticle(Article article)
    {
        if (_articles.Contains(article))
        {
            throw new ArgumentException("Can not add duplicate article");
        }

        _articles.Add(article);
    }

    public void RemoveArticle(Article article)
    {
        if (!_articles.Contains(article))
        {
            throw new ArgumentException("Article does not exist");
        }

        _articles.Remove(article);
    }

    public void ClearArticles()
    {
        _articles.Clear();
    }

    }
}