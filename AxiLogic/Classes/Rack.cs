using System;
using System.Collections.Generic;
using AxiDAL.DTOs;

namespace AxiLogic.Classes
{
    public class Rack
    {
        public int Location;
        public readonly List<Plank> Planks = new();
        
        public Rack(){}
        
        public Rack(int location)
        {
            Location = location;
        }
        
        public Rack(int location, List<Plank> planks)
        {
            Location = location;
            Planks = planks;
        }

        public Rack(RackDto rackDto)
        {
            Location = rackDto.Location;
            Planks = new List<Plank>();
            foreach (var plankDto in rackDto.plankDtos)
            {
                Planks.Add(new Plank(plankDto));
            }
        }
        
        public void AddPlank(Plank plank)
        {
            if (Planks.Contains(plank))
            {
                throw new ArgumentException("Can not add a duplicate plank");
            }
            Planks.Add(plank);
        }

        public void RemovePlank(Plank plank)
        {
            for (int i = 0; i < Planks.Count; i++)
            {
                if (plank != Planks[i])
                {
                    throw new ArgumentException("Pallet not found");
                }
            }
            Planks.Remove(plank);
        }

        public void ClearPlanks()
        {
            Planks.Clear();
        }

        public RackDto ToDto()
        {
            List<PlankDto> plankDtos = new();
                foreach (var plank in Planks)
                {
                plankDtos.Add(plank.ToDto());
                }
            return new RackDto { plankDtos = plankDtos };
        }
    }
}
