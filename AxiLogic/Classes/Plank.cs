using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AxiDAL.DAL;
using AxiDAL.DTOs;
using AxiDAL.Interfaces;

namespace AxiLogic.Classes
{
    public class Plank
    {
        public int Location;
        public readonly List<Pallet> Pallets = new();
        private IPalletDAL _palletDAL;

        public IReadOnlyList<Pallet> GetPallets()
        {
            return Pallets;
        }
        
        //todo implement factory
        
        
        public Plank(int location)
        {
            _palletDAL = new PalletDAL(new SqlConnection(@"Server=mssqlstud.fhict.local;Database=dbi484674;User Id=dbi484674;Password=DatabaseAXItim;"));
            Location = location;
        }
        
        public Plank(int location, List<Pallet> pallets)
        {
            _palletDAL = new PalletDAL(new SqlConnection(@"Server=mssqlstud.fhict.local;Database=dbi484674;User Id=dbi484674;Password=DatabaseAXItim;"));
            Location = location;
            Pallets = pallets;
        }

        public Plank(PlankDto plankDto)
        {
            _palletDAL = new PalletDAL(new SqlConnection(@"Server=mssqlstud.fhict.local;Database=dbi484674;User Id=dbi484674;Password=DatabaseAXItim;"));
            Location = plankDto.Location;
            Pallets = new List<Pallet>();
            foreach (var palletDTO in _palletDAL.GetAllFromPlank(plankDto))
            {
               Pallets.Add(new Pallet(palletDTO));
            }
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
            //to do: write test
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
