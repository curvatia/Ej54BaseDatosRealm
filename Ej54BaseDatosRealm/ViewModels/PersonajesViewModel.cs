using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Ej54BaseDatosRealm.Models;
using Ej54BaseDatosRealm.Repositories;
using Ej54BaseDatosRealm.ViewModels.Base;

namespace Ej54BaseDatosRealm.ViewModels
{
    public class PersonajesViewModel : ViewModelBase
    {
        private RepositoryRealm repo;

        public PersonajesViewModel()
        {
            this.repo = new RepositoryRealm();
            List<Personaje> lista = this.repo.GetPersonajes();
            Personajes = new ObservableCollection<Personaje>(lista);//AL CAMBIAR DE VENTANA LOS DATOS SIGUEN VISIBLES, NO DESAPARECEN
        }

        private ObservableCollection<Personaje> _Personajes;

        //LA PROPIEDAD QUE DEVUELVE LA LISTA DE TODAS LAS PERSONAS SE LLAMA Personajes
        public ObservableCollection<Personaje> Personajes
        {
            get { return this._Personajes; }
            set
            {
                this._Personajes = value;
                OnPropertyChanged("Personajes");
            }
        }
    }
}
