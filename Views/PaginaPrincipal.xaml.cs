using BLOGSOCIALUDLA.Data;
using BLOGSOCIALUDLA.Models;
using System.Collections.ObjectModel;

namespace BLOGSOCIALUDLA.Views;

public partial class PaginaPrincipal : ContentPage
{
    public ObservableCollection<Facultad> Facultades { get; set; }
    //Copia de la coleccion para mostrar las imagenes en un orden diferente

    public PaginaPrincipal()
    {
        InitializeComponent();
        //InitializeFacultades();
        BindingContext = this;
    }

    private async void ficaButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PostFica());
        //await Shell.Current.GoToAsync("PostFica");
    }

    private async void nodoButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PostNodo());
    }

    private async void IrPerfilButton_Clicked(object sender, EventArgs e)
    {
       await Navigation.PushAsync(new UsuarioView());

    }

    private void InitializeFacultades()
    {
        Facultades = new ObservableCollection<Facultad>
        {
            new Facultad{Name= "FICA", ReadTime= new TimeSpan(0,4,0), Image= "fica.jpg"},
            new Facultad{Name= "Facultad de Medicina", ReadTime= new TimeSpan(0,3,0), Image= "medicina.jpg"},
            new Facultad{Name= "Facultad de Derecho", ReadTime= new TimeSpan(0,2,0), Image= "derecho.jpg"},
            new Facultad{Name= "Facultad de Arquitectura", ReadTime= new TimeSpan(0,3,0), Image= "arquitectura.jpg"},
            new Facultad{Name= "NODO", ReadTime= new TimeSpan(0,3,0), Image= "nodo.jpg"},
            new Facultad{Name= "Escuela de Música", ReadTime= new TimeSpan(0,2,0), Image= "musica.jpg"}
        };
    }

    private void Salir(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}
