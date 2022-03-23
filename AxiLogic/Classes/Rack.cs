﻿using System;
using System.Collections.Generic;

namespace AxiLogic.Classes
{
    public class Rack
    {
        public string Location;
        public readonly List<Plank> Planks = new();
        
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
