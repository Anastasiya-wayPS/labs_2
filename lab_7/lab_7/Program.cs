using System;
using System.Diagnostics;

namespace lab_7 {
    class Program {
        private static TripService service;
        static void Main(string[] args) {
            service = new TripService(Input, Output);
            Act();
        }

        private static void Act() {
            int menuAction = PrintAndReadMenu();
            switch (menuAction) {
                case 1:
                    service.PrintAll();
                    break;
                case 2:
                    service.Create();
                    break;
                case 3:
                    service.Find();
                    break;
                case 4:
                    service.Delete();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
            }

            Act();
        }

        private static int PrintAndReadMenu() {
            try {
                Console.WriteLine("1. Вывести все рейсы \n"
                + "2. Добавить рейс \n"
                + "3. Найти рейс \n"
                + "4. Удалить рейс \n"
                + "0. Выход");
                string input = Console.ReadLine();
                int number = Convert.ToInt32(input);
                return number;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return PrintAndReadMenu();
            }
        }



        public static String Input(String message) {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public static void Output(String message) {
            Console.WriteLine(message);
        }
    }
}