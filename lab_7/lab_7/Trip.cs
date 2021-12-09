using System;

namespace lab_7 {
    public class Trip {
        public Ranges Range { get; set; }
        public String DepartureLocation { get; set; }
        public String ArrivalLocation { get; set; }

        public String Info => $"{DepartureLocation} - {ArrivalLocation}";
    }
}