using System.Collections.Generic;

namespace AxiLogic.Classes
{
    public class Row
    {
        public string Name { get; set; }

        public IReadOnlyList<Rack> GetRacks()
        {
            return new List<Rack>();
        }
        
        public void AddRack(Rack rack)
        {
            
        }
        
        public void RemoveRack(Rack rack)
        {
            
        }
        
        public void SetName (string name)
        {
            
        }
    }
}
