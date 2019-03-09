using System;
using Microsoft.Extensions.DependencyInjection;

namespace Trinity.Infra.CrossCutting.IoC
{
    /// <summary>
    /// Interface for registering Lazy services capability in the container.
    /// </summary>
    /// <typeparam name="T">Type of the "lazed" service.</typeparam>
    public class Lazier<T> : Lazy<T> where T : class
    {
        public Lazier(IServiceProvider provider) : base(() => provider.GetRequiredService<T>())
        { }
    }
}
