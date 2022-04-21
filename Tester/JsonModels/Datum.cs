using System.Collections.Generic;

namespace Tester.JsonModels
{
    public class Datum
    {
        public string Theme { get; set; }

        public List<Ticket> Tickets { get; set; }
    }
}