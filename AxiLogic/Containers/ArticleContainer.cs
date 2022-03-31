using System.Collections.Generic;
using AxiLogic.Classes;
using System;
using AxiDAL.DTOs;
using AxiDAL.Interfaces;
using AxiLogic.Interfaces;

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
        _articles = new List<Article>();
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