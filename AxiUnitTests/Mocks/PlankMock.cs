using AxiDAL.DTOs;
using AxiDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiUnitTests.Mocks
{
    public class PlankMock : IPlankDAL
    {
        private IDalFactory _mockFactory;
        public List<PlankDto> planks = new List<PlankDto>();

        public PlankMock(IDalFactory mockFactory)
        {
            planks = mockFactory as List<PlankDto>;

            var plank1 = new PlankDto()
            {
                Location = 1,
                RackId = 2,
                Id = 3,
                // palletDtos = 
            };
            var plank2 = new PlankDto()
            {
                Location = 2,
                RackId = 3,
                Id = 4,
            };
            planks.Add(plank1);
            planks.Add(plank2);
        }

        public int AddPlank(PlankDto plankDto)
        {
            planks.Add(plankDto);
            var index = planks.Count - 1;
            return index;
        }

        public void DeletePlank(PlankDto plankDto)
        {
            planks.Remove(plankDto);
        }

        public IList<PlankDto> GetAllFromRack(RackDto rack)
        {
            var plankDtos = new List<PlankDto>();
            foreach (var plankDto in planks)
            {
                if (plankDto.RackId == rack.Id)
                {
                    plankDtos.Add(plankDto);
                }
            }
            return plankDtos;
        }

        public void UpdatePlank(PlankDto plankDto)
        {
            foreach (var dto in planks)
            {
                if (dto.Id == plankDto.Id)
                {
                    planks.Remove(dto);
                    planks.Add(plankDto);
                }
            }
        }
    }
}
