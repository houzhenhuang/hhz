using Pipeline.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pipeline
{
    public class FeatureCollection : IFeatureCollection
    {
        private readonly Dictionary<Type, object> features = new Dictionary<Type, object>();
        public TFeature Get<TFeature>()
        {
            object feature;
            return features.TryGetValue(typeof(TFeature), out feature)
                ? (TFeature)feature
                : default(TFeature);
        }

        public IFeatureCollection Set<TFeature>(TFeature instance)
        {
            features[typeof(TFeature)] = instance;
            return this;
        }
    }
}
