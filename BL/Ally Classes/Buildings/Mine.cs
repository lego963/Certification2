using System.Collections.Generic;
using System.Drawing;
using BL.Workers;

namespace BL.Ally_Classes.Buildings
{
    public class Mine
    {
        public int Health { get; set; }
        public PointF Coords { get; set; }
        public List<Worker> Workers { get; set; }
        public int MinedGold { get; set; }

        public Mine(PointF coords)
        {
            MinedGold = 0;
            Health = 1000;
            Workers = new List<Worker>();
            Coords = coords;
        }

        public void CreateWorker()
        {
            Workers.Add(new Worker());
        }

        public void Mining()
        {
            foreach (var item in Workers)
            {
                item.Mining();
                if (item.CurrentGold >= item.LoadCapacity) { MinedGold += item.CurrentGold; item.CurrentGold = 0; }
            }
        }
    }
}
