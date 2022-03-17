using System.Collections.Generic;

namespace AxiLogic.Classes
{
    public class Row
    {
        List <Rack> racks = new List<Rack>();
        public string Name { get; set; }
        
 
        public IReadOnlyList<Rack> GetRacks()
        {
            return new List<Rack>();
        }
        
        public void AddRack(Rack rack)
        {
            racks.Add(rack);
        }
        
        public void RemoveRack(Rack rack)
        {
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
