using Palprimes.Shared.Models.Numbers;
using System.Collections.Generic;

namespace Palprimes.Handlers
{
    public interface IPalprimeFinder
    {
        List<Number> FindPalprimes(int numberSystem);
    }
}
