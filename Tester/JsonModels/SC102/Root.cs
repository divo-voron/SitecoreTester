﻿using System.Collections.Generic;

namespace Tester.JsonModels.SC102
{
    public class Root
    {
        public List<Ticket> Tickets { get; set; }

        public List<Datum> Data { get; set; }
    }
}