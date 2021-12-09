using System;
using System.Dynamic;

namespace lab_5 {
    public class Building: IDrawable {
        private float width;
        private float height;
        private int floors;
        private String address;

        public Building(int foors, float width, float height) {
            this.floors = floors;
            this.width = width;
            this.height = height;
        }

        public void Draw() {
            String content =
                "/-/-/-/-/-/\\\n" +
                "| ___    __ |\n" +
                "||_|_|  |  ||\n" +
                "||_|_|  |  ||\n";
            Console.WriteLine(content);
        }

        public string Note() => $"Объект: дом. Этажей: {floors}. Площадь: {Square}";

        private float Square => width * height;

        private String Name => $"Строение\n Этажность: {floors}\n Адрес: {address}";
    }
}