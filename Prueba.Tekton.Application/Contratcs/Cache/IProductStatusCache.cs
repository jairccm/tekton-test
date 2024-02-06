namespace Prueba.Tekton.Application.Contratcs.Cache
{
    public interface IProductStatusCache
    {
        Dictionary<int, string> GetDictotionaryProductStatus();
    }
}
