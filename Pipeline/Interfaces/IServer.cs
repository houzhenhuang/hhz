using System;
using System.Collections.Generic;
using System.Text;

namespace Pipeline.Interfaces
{
    public interface IServer
    {
        void Start<TContext>(IHttpApplication<TContext> application);
        IFeatureCollection Features { get; }
    }
}
