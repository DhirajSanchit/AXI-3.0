using AxiDAL.DTOs;
using AxiDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiUnitTests.Mocks
{
    public class RackMock : IRackDAL
    {
        public List<RackDto> racks = new();
        private IDalFactory mockfactory;

        public RackMock(IDalFactory dalFactory)
        {
            mockfactory = dalFactory;
            var rackdto1 = new RackDto()
            {
                Id = 1,
                Location = 2,
                RowId = 5,
            };

            var rackdto2 = new RackDto()
            {
                Id = 1,
                Location = 2,
                RowId = 5,
            };
            racks.Add(rackdto1);
            racks.Add(rackdto2);
        }

        public int AddRack(RackDto rack)
        {
            racks.Add(rack);
            var index = racks.Count - 1;
            return index;

        }

        public void DeleteRack(RackDto rack)
        {
            racks.Remove(rack);
        }

        public IList<RackDto> GetAllFromRow(RowDto row)
        {
            var rackdtos = new List<RackDto>();
            foreach (var rackDto in racks)
            {
                if (rackDto.Id == row.Id)
                {
                    rackdtos.Add(rackDto);
                }
            }
            return rackdtos;
        }

        public void UpdateRack(RackDto rack)
        {
            foreach (var dto in racks)
            {
                if (dto.Id == rack.Id)
                {
                    racks.Add(dto);
                    racks.Remove(rack);
                }
            }
        }
    }
}
