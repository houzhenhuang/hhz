using System;
using System.Collections.Generic;
using System.Text;

namespace Pipeline.Interfaces
{
    public interface IServerAddressesFeature
    {
        ICollection<string> Addresses { get; }
    }
}
