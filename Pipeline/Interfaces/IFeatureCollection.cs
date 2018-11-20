using System;
using System.Collections.Generic;
using System.Text;

namespace Pipeline.Interfaces
{
    public interface IFeatureCollection
    {
        TFeature Get<TFeature>();
        IFeatureCollection Set<TFeature>(TFeature instance);
    }
}
