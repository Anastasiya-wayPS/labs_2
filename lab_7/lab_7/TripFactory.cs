using System;
using System.Collections.Generic;
using System.Linq;

namespace lab_7 {
    public delegate String InputMethod(String message);

    public delegate void OutputMethod(String message);

    public class TripFactory {
        private Dictionary<string, Ranges> RangeMap = new() {
            {"Ближний", Ranges.Close},
            {"Средний", Ranges.Medium},
            {"Дальний", Ranges.Far}
        };

        private InputMethod Read;
        private OutputMethod Out;

        public TripFactory(InputMethod Read, OutputMethod Out) {
            this.Read = Read;
            this.Out = Out;
        }

        public Trip Create() {
            Trip trip = new Trip();
            trip.DepartureLocation = Read("Укажите точку отправления: ");
            trip.ArrivalLocation = Read("Укажите точку прибытия: ");

            Ranges? range = null;
            while (range == null) {
                try {
                    range = RangeFromInput(ReadRange());
                }
                catch (Exception ex) {
                    Out(ex.Message);
                    Out("Попробуйте снова");
                }
            }
            trip.Range = (Ranges) range;

            return trip;
        }

        public string ReadRange() {
            for (int i = 0; i < RangeMap.Keys.Count; i++) {
                string rangeName = RangeMap.Keys.ElementAt(i);
                Out($"{i + 1}. {rangeName}");
            }

            return Read("");
        }

        public Ranges? RangeFromInput(string input) {
            bool isValidRangeIdx = Int32.TryParse(input, out int rangeIdx);
            if (!isValidRangeIdx) {
                throw new ArgumentException("Указана неверная дальность. Попробуйте снова");
            }

            if (rangeIdx <= 0 || RangeMap.Values.Count < rangeIdx - 1) {
                throw new ArgumentException("Указана неверная дальность. Попробуйте снова");
            }

            Ranges range = RangeMap.Values.ElementAt(rangeIdx - 1);
            return range;
        }
    }
}