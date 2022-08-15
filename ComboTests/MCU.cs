using System;
using System.Collections.Generic;
using System.Text;

namespace ComboTests
{
    class MCU
    {
        public string Title { get; set; }
        public List<Hero> Heroes { get; set; }
        public int SeriesCounter { get; set; }
    }
    class Hero
    {
        public string Name { get; set; }
    }
}
