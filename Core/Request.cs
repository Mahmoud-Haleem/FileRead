using System.Collections.Generic;

namespace Core
{
    public class Request
    {
        public int RequestId { get; set; }

        public int Status { get; set; }

        public Technology Technology { get; set; }

        public Plant Plant { get; set; }

        public List<Unit> Units { get; set; }
    }
}
