using System.Collections.Generic;
using AxiDAL.DTOs;
using AxiDAL.Interfaces;
using AxiLogic.Classes;

namespace AxiUnitTests.Scrubs
{
    public class ArticleScrub : IArticleDAL
    {
        public List<ArticleDto> _articleDtos = new();
        
        public IList<ArticleDto> GetAll()
        {
            return _articleDtos;
        }

        public ArticleDto GetByBarcode(ArticleDto articleDto)
        {
            var returnDto = new ArticleDto();
            foreach (var dto in _articleDtos)
            {
                if (dto.Barcode == articleDto.Barcode)
                {
                    returnDto = dto;
                }
            }
            return returnDto;
        }

        public bool AddArticle(ArticleDto articleDto)
        {
            _articleDtos.Add(articleDto);
            return true;
        }

        public bool UpdateArticle(ArticleDto articleDto)
        {
            foreach (var dto in _articleDtos)
            {
                if (dto.Id == articleDto.Id)
                {
                    _articleDtos.Remove(dto);
                    _articleDtos.Add(articleDto);
                }
            }
            return true;
        }

        public bool DeleteArticle(ArticleDto articleDto)
        {
            _articleDtos.Remove(articleDto);
            return true;
        }
    }
}