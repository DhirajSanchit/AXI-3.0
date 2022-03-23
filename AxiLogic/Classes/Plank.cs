﻿using AxiInterfaces.DTOs;
using System;
using System.Collections.Generic;

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

        public PlankDto ToDto()
        {
            List<PalletDto> palletDtos = new();
            foreach (var Pallet in Pallets)
            {
                palletDtos.Add(Pallet.ToDto());
            }
            return new PlankDto { palletDtos = palletDtos };
        }
    }
}
