﻿using AxiInterfaces.DTOs;
using System;
using System.Collections.Generic;

namespace AxiLogic.Classes
{
    public class Row
    {
        public readonly List <Rack> Racks = new ();
        public string Name;
        
 
       
        
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

        public Row(string name)
        {
            Name = name;
        }

        public RowDto ToDto()
        {
                
            List < RackDto > RackDtos = new();
            foreach (var Rack in Racks)
            {
                RackDtos.Add(Rack.ToDto());
            }
            return new RowDto { RackDtos = RackDtos,
                                Name = Name};
        }
    }
}
