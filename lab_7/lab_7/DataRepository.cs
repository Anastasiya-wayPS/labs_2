using System;
using System.Collections.Generic;
using System.Linq;

namespace lab_7 {
    public class DataRepository {
        private Dictionary<int, Trip> Trips = new();

        public int Add(Trip toAdd) {
            int addedId = Trips.Keys.Count > 1 ? Trips.Keys.Max() : 0;
            Trips.Add(addedId, toAdd);
            Console.WriteLine(Trips.Count);
            return addedId;
        }

        public Trip? Find(int id) {
            if (Trips.ContainsKey(id)) return Trips[id];
            return null;
        }

        public Trip[] Find(Ranges range) => Trips.Values.Where(t => t.Range == range).ToArray();

        public bool Delete(int id) => Trips.Remove(id);

        public Trip[] All => Trips.Values.ToArray();

        public int GetId(Trip trip) {
            var keys = Trips.Keys;
            return keys.Single(k => Trips[k].Info == trip.Info);
        }
    }
}