namespace Locadora_De_Veiculos.WindApp.Compartilhado
{
    public interface IServiceLocator
    {
        T Get<T>() where T : ControladorBase;
    }
}