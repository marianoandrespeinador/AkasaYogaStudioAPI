using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Akasa.Data.Core
{
    /// <summary>
    /// Using reflection, this class registers all classes, on this assembly, that implement "IEntityTypeBuilder"
    /// </summary>
    public static class EntityBuilderRegistrator
    {
        public static void RegisterDataEntityToTableBuilders(ModelBuilder modelBuilder, Assembly assemblyToGet)
        {
            var builderType = typeof(IEntityTypeBuilder).GetTypeInfo();

            foreach (var entityTypeBuilderCurrent in assemblyToGet.GetTypes()
                .Where(t => builderType.IsAssignableFrom(t)
                            && t.GetTypeInfo().IsClass
                            && !t.GetTypeInfo().IsAbstract))
            {
                var currentBuilder = Activator.CreateInstance(entityTypeBuilderCurrent) as IEntityTypeBuilder;
                // Is not null because we are iterating through reflection, all classes that implement "IEntityTypeBuilder"
                // ReSharper disable once PossibleNullReferenceException
                currentBuilder.ConfigureThisEntity(modelBuilder);
            }
        }

    }
}
