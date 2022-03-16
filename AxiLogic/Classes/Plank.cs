using System;
using System.Collections.Generic;

namespace AxiLogic.Classes
{
    public class Plank
    {
        private List<Pallet> Pallets = new();

        public IReadOnlyList<Pallet> GetPallets()
        {
            return Pallets;
        }

        public void CreatePallet(Pallet pallet)
        {
            Pallets.Add(pallet);
        }

        public void RemovePallet(Pallet pallet)
        {
            for (int i = 0; i < Pallets.Count; i++)
            {
                if (pallet != Pallets[i])
                {
                    throw new ArgumentException("Pallet not found");
                }
            }
            Pallets.Remove(pallet);
        }
    }
}
