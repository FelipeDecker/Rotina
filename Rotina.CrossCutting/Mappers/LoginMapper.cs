using AutoMapper;
using Rotina.Domain.Entities;
using Rotina.Domain.ViewModels;
using System.Collections.Generic;

namespace Rotina.CrossCutting.Mappers
{
    public class LoginMapper
    {
        private static MapperConfiguration Configure()
        {
            return new MapperConfiguration(x =>
            {
                x.AllowNullCollections = true;
                x.CreateMap<LoginEntity, LoginViewModel>().AfterMap((src, dest) =>
                {
                    dest.Id = src.Id.ToString();
                    dest.IdUser = src.IdUser.ToString();
                    dest.Date = src.Date.ToString("dd/MM/yyyy HH:mm:ss");
                });
            });
        }

        public static List<LoginViewModel> ParseToViewModel(List<LoginEntity> obj)
        {
            return Configure().CreateMapper().Map<List<LoginEntity>, List<LoginViewModel>>(obj);
        }
    }
}
