using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartotekaKontrahentowWpf.Interfaces
{
    public interface IClient
    {
        int Id { get; set; }
        string Name { get; set; }
        string Country { get; set; }
        string City { get; set; }
        string Street { get; set; }
        string StreetNumber { get; set; }
        bool IsBusinessClient { get; set; }
    }
}
