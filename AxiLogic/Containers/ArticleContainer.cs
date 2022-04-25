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
    private  IArticleDAL iArticleDAL;

    public ArticleContainer(IArticleDAL context)
    {
        iArticleDAL = context;
    }
 

    public ArticleContainer()
    {
        var jObject = JObject.Parse(File.ReadAllText(@"../AxiLogic/Jsons/Articles.json"));
        _articles = jObject["articles"].ToObject<List<Article>>();
        
        //GetAll Articles
        
        //Return list
        
        
    }

    public IReadOnlyCollection<Article> GetArticles()
    {
        return _articles;
    }

    public bool AddArticle(Article article)
    {
            ArticleDto articleDto = new ArticleDto()
            {
                Name = article.Name,
                Price = article.Price,
                Barcode = article.Barcode,
                ImgRef = article.ImgRef,
                Description = article.Description,
                Category = article.Category
            };
            return iArticleDAL.AddArticle(articleDto);
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
        File.WriteAllText(@"/Users/graciousmacbook/RiderProjects/AXI-3.0/AxiLogic/Jsons/Articles.json",jsonString);
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

        public void GetAllArticles()
        {
            var articleDTOs = iArticleDAL.GetAll();
            List<Article> articles = new();
            foreach (var articleDTO in articleDTOs)
            {
                articles.Add(new Article(articleDTO));
            }

            _articles = articles;
        }

        // public Article AddArticle()
        // {
        //     
        // }

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