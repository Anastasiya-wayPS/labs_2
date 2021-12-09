using System;

namespace lab_7 {
    public class TripService {
        private DataRepository repository = new();
        private TripFactory factory;

        private OutputMethod Output;
        private InputMethod Input;

        public TripService(InputMethod input, OutputMethod output) {
            Output = output;
            Input = input;
            factory = new TripFactory(input, output);
        }

        public void Create() {
            Trip created = factory.Create();
            int id = repository.Add(created);
            Output($"Рейс создан (номер {id})");
            PrintAll();
        }

        public void Delete() {
            (Trip candidate, int id) = ChooseByIdx();
            bool isDeleted = repository.Delete(id);
            if (!isDeleted) {
                Output($"Не удалось удалить рейс {candidate.Info}");
            }
            Output($"Рейс удален (номер {id})");
            PrintAll();
        }

        public void Find() {
            Ranges range = (Ranges) factory.RangeFromInput(factory.ReadRange());
            Trip[] founded = repository.Find(range);
            Output("Результаты поиска");
            Print(founded);
        }

        private (Trip, int) ChooseByIdx() {
            try {
                PrintAll();
                string input = Input("");
                bool isValidId = Int32.TryParse(input, out int id);
                if (!isValidId) throw new Exception("Неверный выбор");
                Trip? founded = repository.Find(id);
                if (founded == null) throw new Exception("Рейс с таким номером не найден");
                return (founded, id);
            }
            catch (Exception ex) {
                Output($"{ex.Message}\n Попробуйте снова");
                return ChooseByIdx();
            }

        }

        private void Print(Trip[] toPrint) {
            foreach (Trip trip in toPrint) {
                int idx = repository.GetId(trip);
                Output($"{idx}. {trip.Info}");
            }
        }

        public void PrintAll() {
            foreach (Trip trip in repository.All) {
                int idx = repository.GetId(trip);
                Output($"{idx}. {trip.Info}");
            }
        }
    }
}