using System;
using System.Collections.Generic;
using AxiDAL.DTOs;

namespace AxiLogic.Classes
{
    public class Plank
    {
        public int Location;
        public readonly List<Pallet> Pallets = new();

        public IReadOnlyList<Pallet> GetPallets()
        {
            return Pallets;
        }

        public Plank(){}
        
        public Plank(int location)
        {
            Location = location;
        }
        
        public Plank(int location, List<Pallet> pallets)
        {
            Location = location;
            Pallets = pallets;
        }

        public Plank(PlankDto plankDto)
        {
            Location = plankDto.Location;
            Pallets = new List<Pallet>();
        }
        
        public void AddPallet(Pallet pallet)
        {
            if (Pallets.Contains(pallet))
            {
                throw new ArgumentException("Can not add duplicate pallet");
            }
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
        
        public void ClearPallets()
        {
            Pallets.Clear();
        }

        public Pallet GetPallet(int location)
        {
            foreach(var pallet in Pallets)
            {
                if (pallet.Location == location)
                {
                    return pallet;
                }
            }
            return null;
        }
        public PlankDto ToDto()
        {
            List<PalletDto> palletDtos = new();
            foreach (var pallet in Pallets)
            {
                palletDtos.Add(pallet.ToDto());
            }
            return new PlankDto { palletDtos = palletDtos };
        }
    }
}
