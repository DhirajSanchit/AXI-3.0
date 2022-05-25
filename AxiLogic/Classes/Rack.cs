using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AxiDAL.DAL;
using AxiDAL.DTOs;
using AxiDAL.Factories;
using AxiDAL.Interfaces;

namespace AxiLogic.Classes
{
    public class Rack
    {
        public int Location;
        public readonly List<Plank> Planks = new();
        private IPlankDAL _plankDal;
        //todo implement factory
        
        public Rack(int location)
        {
            Location = location;
            
            _plankDal = new PlankDAL(new SqlConnection(@"Server=mssqlstud.fhict.local;Database=dbi484674;User Id=dbi484674;Password=DatabaseAXItim;"));
        }
        
        public Rack(int Location, List<Plank> Planks)
        {
            this.Location = Location;
            this.Planks = Planks;
            _plankDal = new PlankDAL(new SqlConnection(@"Server=mssqlstud.fhict.local;Database=dbi484674;User Id=dbi484674;Password=DatabaseAXItim;"));

        }

        public Rack(RackDto rackDto)
        {
            _plankDal = new PlankDAL(new SqlConnection(@"Server=mssqlstud.fhict.local;Database=dbi484674;User Id=dbi484674;Password=DatabaseAXItim;"));

            Location = rackDto.Location;
            Planks = new List<Plank>();
            foreach (var plankDto in _plankDal.GetAllFromRack(rackDto))
            {
                Planks.Add(new Plank(plankDto));
            }
        }
        
        public void AddPlank(Plank plank)
        {
            if (Planks.Contains(plank))
            {
                throw new ArgumentException("Can not add a duplicate plank");
            }
            Planks.Add(plank);
        }

        public void RemovePlank(Plank plank)
        {
            for (var i = 0; i < Planks.Count; i++)
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

        public RackDto ToDto()
        {
            List<PlankDto> plankDtos = new();
                foreach (var plank in Planks)
                {
                plankDtos.Add(plank.ToDto());
                }
            return new RackDto { plankDtos = plankDtos };
        }
        public Plank GetPlankByLocation(int location)
        {
            foreach (var plank in Planks)
            {
                if (plank.Location == location)
                {
                    return plank;
                }
            }
            return null;
        }
    }
}
