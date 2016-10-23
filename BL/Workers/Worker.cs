﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Workers
{
    public class Worker
    {
        protected Random rnd;

        public int LoadCapacity { get; protected set; }
        public int Health { get; private set; }
        public int CurrentGold { get; set; }
        public int gold { get; protected set; }

        public Worker()
        {
            rnd = new Random();
            Health = 1;
            LoadCapacity = 25;
            CurrentGold = 0;
            gold = rnd.Next(3, 5);
        }

        public void LevelUp()
        {
            LoadCapacity *= 2;
            gold *= 2;
        }
        public void Mining()
        {
            CurrentGold += gold;
        }
    }
}