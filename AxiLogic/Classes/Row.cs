using System.Collections.Generic;

namespace AxiLogic.Classes
{
    public class Row
    {
        public string Name { get; set; }

<<<<<<< Updated upstream
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
=======
        public Row(string Name)
        {
            this.Name = Name;
        }
        public void CreateRack(Rack rack)
        {
            
        }

        public void RemoveRack(Rack rack)
>>>>>>> Stashed changes
        {
            
        }
    }
}
