using System;
using System.Collections.Generic;
using AxiDAL.DTOs;

namespace AxiLogic.Classes
{
    public class Row
    {
        public readonly List <Rack> Racks = new ();
        public string Name;

        public Row(){}
        
        public Row(string name)
        {
            Name = name;
        }
        
        public Row(string Name, List<Rack> Racks)
        {
            this.Name = Name;
            this.Racks = Racks;
        }
        
        public Row(RowDto rowDto)
        {
            Name = rowDto.Name;
            Racks = new List<Rack>();
            foreach (var rackDto in rowDto.RackDtos)
            {
                Racks.Add(new Rack(rackDto));
            }
        }
        
        public void AddRack(Rack rack)
        {
            if (Racks.Contains(rack))
            {
                throw new ArgumentException("Adding duplicate rack not allowed");
            }
            Racks.Add(rack);
        }
        
        public void RemoveRack(Rack rack)
        {
            if (!Racks.Contains(rack))
            {
                throw new ArgumentException("Does not contain given rack");
            }
            Racks.Remove(rack);
        }

        public void SetName(string name)
        {
            Name = name;
        }
        
        public RowDto ToDto()
        {
                
            List < RackDto > rackDtos = new();
            foreach (var rack in Racks)
            {
                rackDtos.Add(rack.ToDto());
            }
            return new RowDto { RackDtos = rackDtos,
                                Name = Name};
        }
    }
}
