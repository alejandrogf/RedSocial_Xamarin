using Xamarin.Forms;

namespace MvvmLibrary.Factorias
{
    //Tiene que implementar el dialog service porque este implementa el servicio de dialogos
    //y de esta forma los relacionas
    public interface IPage: IDialogService
    { 
        INavigation Navigation { get; } 
    }
}