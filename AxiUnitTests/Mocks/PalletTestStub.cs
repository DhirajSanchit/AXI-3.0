using AxiDAL.DTOs;
using AxiDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiUnitTests.Mocks
{
    public class PalletTestStub : IPalletDAL
    {
        public List<PalletDto> pallets = new List<PalletDto>();

        public PalletTestStub()
        {
            var palletDto1 = new PalletDto()
            {
                Id = 1,
                PlankId = 2,
                ArticleId = 3,
             //   Article = ArticleDto(),
                Amount = 2,
                Location = 2,
            };

            var palletDto2 = new PalletDto()
            {
                Id = 2,
                PlankId = 3,
                ArticleId = 4,
                //   Article = ArticleDto(),
                Amount = 1,
                Location = 1,
            };

            pallets.Add(palletDto1);
            pallets.Add(palletDto2);
        }

        public int AddPallet(PalletDto palletDto)
        {
            pallets.Add(palletDto);
            return 1;
        }

        public void DeletePallet(PalletDto palletDto)
        {
            for (var i = 0; i < pallets.Count; i++)
            {
                if (pallets[i].Id == palletDto.Id)
                {
                    pallets.Remove(pallets[i]);
                }
            }
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
            return pallets;
        }

        public void UpdatePallet(PalletDto palletDto)
        {
            throw new NotImplementedException();
        }
    }
}
