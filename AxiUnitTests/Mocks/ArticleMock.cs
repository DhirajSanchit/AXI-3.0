using System;
using System.Collections.Generic;
using AxiDAL.DTOs;
using AxiDAL.Interfaces;
using AxiLogic.Classes;

namespace AxiUnitTests.Scrubs
{
    public class ArticleMock : IArticleDAL
    {
        public List<ArticleDto> _articleDtos = new();
        
        private IDalFactory _mockFactory;


        public ArticleMock(IDalFactory mockFactory)
        {
            _mockFactory = mockFactory;
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
            var id = _articleDtos.Count + 1;
            articleDto.Id = id;
            _articleDtos.Add(articleDto);
            return id;
        }

        public void UpdateArticle(ArticleDto articleDto)
        {
            foreach (var dto in _articleDtos)
            {
                if (dto.Id == articleDto.Id)
                {
                    _articleDtos.Remove(dto);
                    _articleDtos.Add(articleDto);
                }
            }
        }

        public void DeleteArticle(ArticleDto articleDto)
        {
            _articleDtos.Remove(articleDto);
        }

        public ArticleDto GetFromPallet(PalletDto palletDto)
        {
            var returnDto = new ArticleDto();
            foreach (var dto in _articleDtos)
            {
                if (dto.Id == palletDto.Id)
                {
                    returnDto = dto;
                }
            }
            return returnDto;
        }

        public List<ArticleDto> GetByCategory(CategoryDto categoryDto)
        {
            List<ArticleDto> returnList = new();
            foreach (var dto in _articleDtos)
            {
                if (dto.Category == categoryDto.Name)
                {
                    returnList.Add(dto);
                }
            }
            return returnList;
        }

        public void RemoveCategory(ArticleDto articleDto)
        {
            var thisDto = new ArticleDto();
            for (var i = 0; i < _articleDtos.Count; i++)
            {
                if (articleDto.Id == _articleDtos[i].Id)
                {
                    thisDto = _articleDtos[i];
                    _articleDtos.Remove(_articleDtos[i]);
                }
            }
            _articleDtos.Add(thisDto);
        }

        public ArticleDto GetArticleById(int Id)
        {
            var returnDto = new ArticleDto();
            foreach (var dto in _articleDtos)
            {
                if (dto.Id == Id)
                {
                    returnDto = dto;
                }
            }
            return returnDto;
        }
    }
}