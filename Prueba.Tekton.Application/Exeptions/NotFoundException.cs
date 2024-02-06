namespace Prueba.Tekton.Application.Exeptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key) : base($"Enityt \"{name}\" no fue encontrado")
        {
            
        }
    }
}
