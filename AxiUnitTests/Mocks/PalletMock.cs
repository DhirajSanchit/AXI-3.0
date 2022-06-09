using AxiDAL.DTOs;
using AxiDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxiUnitTests.Scrubs;

namespace AxiUnitTests.Mocks
{
    public class PalletMock : IPalletDAL
    {
        public List<PalletDto> pallets = new();
        private IDalFactory _mockFactory;

        public PalletMock(IDalFactory mockfactory)
        {
            _mockFactory = mockfactory;
            var palletDto1 = new PalletDto()
            {
                Id = 1,
                PlankId = 2,
                ArticleId = 3,
                Article = mockfactory.GetArticleDal().GetAll()[0],
                Amount = 2,
                Location = 2,
            };

            var palletDto2 = new PalletDto()
            {
                Id = 2,
                PlankId = 3,
                ArticleId = 4,
                Article = mockfactory.GetArticleDal().GetAll()[1],
                Amount = 1,
                Location = 1,
            };

            pallets.Add(palletDto1);
            pallets.Add(palletDto2);
        }

        public int AddPallet(PalletDto palletDto)
        {
            pallets.Add(palletDto);
            var index = pallets.Count - 1;
            return index;
        }

        public void DeletePallet(PalletDto palletDto)
        {
            pallets.Remove(palletDto);
        }

        public IList<PalletDto> GetAllFromPlank(PlankDto plank)
        {
            var palletDtos = new List<PalletDto>();
            foreach (var palletDto in pallets)
            {
                if (palletDto.Id == plank.Id)
                {
                    palletDtos.Add(palletDto);
                }
            }
            return palletDtos;
        }

        public void UpdatePallet(PalletDto palletDto)
        {
            foreach (var dto in pallets)
            {
                if (dto.Id == palletDto.Id)
                {
                    pallets.Remove(dto);
                    pallets.Add(palletDto);
                }
            }
        }
    }
}
