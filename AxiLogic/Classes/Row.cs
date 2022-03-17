using System;
using System.Collections.Generic;

namespace AxiLogic.Classes
{
    public class Row
    {
        List <Rack> racks = new List<Rack>();
        public string Name { get; set; }
        
 
        public IReadOnlyList<Rack> GetRacks()
        {
            return racks;
        }
        
        public void AddRack(Rack rack)
        {
            if (racks.Contains(rack))
            {
                throw new ArgumentException("Adding duplicate rack not allowed");
            }
            racks.Add(rack);
        }
        
        public void RemoveRack(Rack rack)
        {
            if (!racks.Contains(rack))
            {
                throw new ArgumentException("Does not contain given rack");
            }
            racks.Remove(rack);
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public Row(string Name)
        {
            this.Name = Name;
        }
    }
}
