using System;
using System.Collections.Generic;

namespace AxiLogic.Classes
{
    public class Rack
    {
        private List<Plank> Planks = new();

        public IReadOnlyList<Plank> GetPlanks()
        {
            return Planks;
        }
        public void AddPlank(Plank plank)
        {
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
    }
}
