using System;
using System.Collections.Generic;
using System.Text;

namespace lab_6 {
    class Journal : Printable {
        public int Number;
    }

    class NotPrintable {
        public List<String> Pages;
    }

    class Program {
        static void Main(string[] args) {
            PrintableFactory factory = new();
            Printable journal = factory.Create<Journal>(3, InputPage);
            journal.Print();
            try {
                // var shouldNotCompile = factory.Create < (Printable) NotPrintable > (1, InputPage);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public static String InputPage(int pageIdx) {
            Console.WriteLine($"Введите страницу {pageIdx + 1}");
            return Console.ReadLine();
        }
    }
}