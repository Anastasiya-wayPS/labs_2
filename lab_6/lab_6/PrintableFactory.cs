using System;
using System.Collections.Generic;

namespace lab_6 {
    public delegate String InputPageMethod(int pageIdx);
    public class PrintableFactory {

        public T Create<T>(int pagesCount, InputPageMethod ReadPage) where T: Printable, new() {
            List<String> pages = new();
            for (int i = 0; i < pagesCount; i++) {
                String content = ReadPage(i);
                pages.Add(content);
            }

            T instance = new T();
            instance.SetPages(pages);
            return instance;
        }
    }
}