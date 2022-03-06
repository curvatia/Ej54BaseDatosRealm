using System;
using System.Collections.Generic;
using Ej54BaseDatosRealm.Models;
using Ej54BaseDatosRealm.Repositories;
using Ej54BaseDatosRealm.ViewModels;
using Xamarin.Forms;

namespace Ej54BaseDatosRealm.Views
{
    public partial class Inicio : ContentPage
    {
        //NEW
        RepositoryRealm repo;

        public Inicio()
        {
            InitializeComponent();
            //NEW
            this.repo = new RepositoryRealm();

            this.botondetalles.Clicked += Botondetalles_Clicked;
            this.botoneliminar.Clicked += Botoneliminar_Clicked;
            this.botoninsertar.Clicked += Botoninsertar_Clicked;
            this.botonmodificar.Clicked += Botonmodificar_Clicked;
            this.botonmostrarregistros.Clicked += Botonmostrarregistros_Clicked;
        }

        private async void Botoninsertar_Clicked(object sender, EventArgs e)
        {
            InsertarPersonaje insertview = new InsertarPersonaje();
            await Navigation.PushAsync(insertview);
            //await Navigation.PushModalAsync(insertview);
        }

        //ENLAZA CON LA CLASE PersonajesViewModel.cs PARA VOLCAR TODA LA LISTA AL COMPLETO
        private async void Botonmostrarregistros_Clicked(object sender, EventArgs e)
        {
            PersonajesView listaview = new PersonajesView();
            await Navigation.PushAsync(listaview);
        }

        //ENLAZA CON LA CLASE PersonajeModel.cs PARA VER LOS DETALLES AL COMPLETO, MODIFICAR Y ELIMINAR
        private async void Botondetalles_Clicked(object sender, EventArgs e)
        {
            DetallesPersonaje detailsview = new DetallesPersonaje();
            PersonajeModel viewmodel = new PersonajeModel();
            int id = int.Parse(this.txtid.Text);
            Personaje person = this.repo.BuscarPersonaje(id);
            viewmodel.miPersonaje = person;
            detailsview.BindingContext = viewmodel;
            await Navigation.PushAsync(detailsview);
        }

        private async void Botonmodificar_Clicked(object sender, EventArgs e)
        {
            ModificarPersonaje updateview = new ModificarPersonaje();
            PersonajeModel viewmodel = new PersonajeModel();
            int id = int.Parse(this.txtid.Text);
            Personaje person = this.repo.BuscarPersonaje(id);
            viewmodel.miPersonaje = person;
            updateview.BindingContext = viewmodel;
            await Navigation.PushAsync(updateview);
        }


        private async void Botoneliminar_Clicked(object sender, EventArgs e)
        {
            EliminarPersonaje deleteview = new EliminarPersonaje();
            PersonajeModel viewmodel = new PersonajeModel();
            int id = int.Parse(this.txtid.Text);
            Personaje person = this.repo.BuscarPersonaje(id);
            viewmodel.miPersonaje = person;
            deleteview.BindingContext = viewmodel;
            await Navigation.PushAsync(deleteview);//VOLVEMOS A LA PAG QUE QUEREMOS
        }

    }
}

