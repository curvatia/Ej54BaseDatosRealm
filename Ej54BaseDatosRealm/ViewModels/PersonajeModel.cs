using System;
using Ej54BaseDatosRealm.Models;
using Ej54BaseDatosRealm.Repositories;
using Ej54BaseDatosRealm.ViewModels.Base;
using Xamarin.Forms;

namespace Ej54BaseDatosRealm.ViewModels
{
    public class PersonajeModel : ViewModelBase
    {
        RepositoryRealm repo;

        public PersonajeModel()
        {
            this.repo = new RepositoryRealm();
            this.miPersonaje = new Personaje();
        }

        //PROPIEDAD PARA REALIZAR LOS BINDINGS SOBRE LAS VISTAS
        private Personaje _Personaje;
        public Personaje miPersonaje
        {
            get { return this._Personaje; }
            set
            {
                this._Personaje = value;
                OnPropertyChanged("miPersonaje");
            }
        }

        //PROPIEDAD PARA MOSTRAR LOS RESULTADOS DE LAS ACCIONES
        private String _Mensaje;
        public String Mensaje
        {
            get { return this._Mensaje; }
            set
            {
                this._Mensaje = value;
                OnPropertyChanged("Mensaje");
            }
        }

        //<Button Text="Insertar Personaje" HorizontalOptions="FillAndExpand"
        //Command="{Binding InsertarDato}"/>
        //EL ATRIBUTO DEL TIPO Command DE InsertarPersonaje.xaml SE PUEDE ENLAZAR A LA PROPIEDAD Command DE InsertarPersonaje.xaml
        public Command InsertarDato
        {
            get
            {
                return new Command(() => {
                    this.repo.InsertarPersonaje(this.miPersonaje);
                    this.Mensaje = "Dato insertado";
                });
            }
        }

        public Command ModificarDato
        {
            get
            {
                return new Command(() => {
                    this.repo.ModificarPersonaje(this.miPersonaje);
                    this.Mensaje = "Dato Modificado";
                });
            }
        }

        public Command EliminarDato
        {
            get
            {
                return new Command(() => {
                    this.repo.EliminarPersonaje(this.miPersonaje.IdPersonaje);
                    this.Mensaje = "Dato Eliminado";
                });
            }
        }


    }
}
