using System.Collections.Generic;
using AxiLogic.Classes;
using System;
using System.IO;
using AxiDAL.DTOs;
using AxiDAL.Interfaces;
using AxiLogic.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AxiLogic.Containers
{
    public class ArticleContainer
    {
    private List<Article> _articles;
    private  IArticleDAL _context;

    public ArticleContainer(IArticleDAL context)
    {
        _context = context;
    }
 

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
        SaveArticles();
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

    public void SaveArticles()
    {
        var jsonObj = new JObject();
        jsonObj["articles"] = JToken.FromObject(_articles);
        var jsonString = JsonConvert.SerializeObject(jsonObj);
        File.WriteAllText(@"..\AxiLogic\Jsons\Articles.json",jsonString);
    }

        public Article GetArticleByID(int articleID)
        {
            foreach (var article in _articles)
            {
                if(article.Id == articleID)
                {
                    return article;
                }
            }
            return null;
        }

    /*
    public IList<ArticleDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public ArticleDto GetById()
    {
        throw new NotImplementedException();
    }

    public bool AddArticle()
    {
        throw new NotImplementedException();
    }

    public bool DeleteArticle()
    {
        throw new NotImplementedException();
    }

    public bool UpdateArticle()
    {
        throw new NotImplementedException();
    }*/
    
    }
}