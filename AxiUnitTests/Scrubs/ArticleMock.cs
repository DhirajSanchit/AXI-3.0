﻿using System.Collections.Generic;
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
            throw new System.NotImplementedException();
        }

        public List<ArticleDto> GetByCategory(CategoryDto categoryDto)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveCategory(ArticleDto articleDto)
        {
            throw new System.NotImplementedException();
        }

        public ArticleDto GetArticleById(int Id)
        {
            throw new System.NotImplementedException();
        }
    }
}