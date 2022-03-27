using AutoMapper;

namespace Rotina.CrossCutting.Mappers
{
    public class GenericMapper<TSource, TDestiny> where TSource : class where TDestiny : class
    {
        private static MapperConfiguration Configure()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestiny>();
            });
        }

        public static TDestiny ClasseParaComando(TSource obj)
        {
            return Configure().CreateMapper().Map<TSource, TDestiny>(obj);
        }
    }
}
