using System.Collections.Generic;
using AxiDAL.DTOs;
using AxiDAL.Interfaces;
using AxiLogic.Classes;

namespace AxiUnitTests.Scrubs
{
    public class ArticleScrub : IArticleDAL
    {
        public List<ArticleDto> _articleDtos = new();
        
        public ArticleScrub()
        {
            _articleDtos.Add(new ArticleDto()
            {
                Id = 1,
                Barcode = "1",
                Category = "Tools",
                Description = "description1",
                ImgRef = "someUrl1",
                Name = "name1",
                Price = 90.30
            });
            _articleDtos.Add(new ArticleDto()
            {
                Id = 2,
                Barcode = "2",
                Category = "Tools",
                Description = "description2",
                ImgRef = "someUrl2",
                Name = "name2",
                Price = 8.15
            });
        }
        
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

        public int AddArticle(ArticleDto articleDto)
        {
            _articleDtos.Add(articleDto);
            var id = _articleDtos.Count;
            return id;
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