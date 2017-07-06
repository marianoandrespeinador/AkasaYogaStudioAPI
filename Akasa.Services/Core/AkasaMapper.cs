using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Akasa.Dto;
using Akasa.Dto.Core;
using Akasa.Model;
using Akasa.Model.Core;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;

namespace Akasa.Services.Core
{
    public class AkasaMapper : Profile
    {
        public AkasaMapper()
        {
            AddDataEntityToDtoMapping();
        }

        private void AddDataEntityToDtoMapping()
        {
            var dataEntityAssemblyName = "Akasa.Model";
            var dtoAssemblyName = "Akasa.Dto";
            
            var kernelData = Assembly.Load(new AssemblyName(dataEntityAssemblyName));
            var dataEntities = kernelData.GetTypes().Where(t => t.GetTypeInfo().IsClass).ToList();

            var kernelDTO = Assembly.Load(new AssemblyName(dtoAssemblyName));
            var dtoEntities = kernelDTO.GetTypes().Where(t => t.GetTypeInfo().IsClass).ToList();

            foreach (var curDataEntity in dataEntities)
            {//El DTO principal, debe tener el mismo nombre que la entidad de data + DTO al final
                var curDTO =
                    dtoEntities.FirstOrDefault(
                        c => c.Name.ToLower().Replace("dto", "").Equals(curDataEntity.Name.ToLower()));
                if (curDTO != null)
                {
                    CreateMap(curDataEntity, curDTO).ReverseMap();

                    //Busca los DTOS que heredan del DTO principal (curDTO), para mapearlos tambien:
                    var childrenDtos = kernelDTO
                        .GetTypes()
                        .Where(dto => curDTO.IsAssignableFrom(dto) && (curDTO != dto))
                        .ToList();

                    childrenDtos.ForEach(childDTO => CreateMap(curDataEntity, childDTO).ReverseMap());
                }
            }
        }
    }
}
