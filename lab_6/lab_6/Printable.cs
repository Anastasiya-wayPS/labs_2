using System;
using System.Collections.Generic;

namespace lab_6 {
    public abstract class Printable: IPrintable {
        private List<String> Pages;

        public void SetPages(List<String> pages) {
            Pages = pages;
        }

        public void Print() {
            for (int i = 0; i < Pages.Count; i++) {
                String page = Pages[i];
                Console.WriteLine(page);
                Console.WriteLine($"page {i + 1} of {Pages.Count}");
            }
        }
    }
}