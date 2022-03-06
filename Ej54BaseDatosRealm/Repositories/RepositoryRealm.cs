using System;
using System.Collections.Generic;
using System.Linq;
using Ej54BaseDatosRealm.Models;
using Realms;

namespace Ej54BaseDatosRealm.Repositories
{
    public class RepositoryRealm
    {
        //NEW SE DECLARA VARIABLE transaction DEL TIPO Transaction
        private Realm conexionrealm;
        Transaction transaction;

        public RepositoryRealm()
        {
            //CREAMOS EL OBJETO QUE NOS PERMITIRA CONECTARNOS
            //CON REALM EN CADA DISPOSITIVO
            this.conexionrealm = Realm.GetInstance();//CREA UNA INSTANCIA DE LA BBDD DEL DISPOSITIVO
        }

        //METODO PARA DEVOLVER TODOS LOS OBJETOS PERSONAJES
        public List<Personaje> GetPersonajes()
        {
            List<Personaje> lista = this.conexionrealm.All<Personaje>().ToList();
            return lista;
        }

        public Personaje BuscarPersonaje(int idpersonaje)
        {
            //RECUPERAMOS TODOS LOS PERSONAJES
            List<Personaje> lista = this.GetPersonajes();
            //BUSCAMOS UN PERSONAJE EN CONCRETO
            Personaje personaje = lista.FirstOrDefault(z => z.IdPersonaje == idpersonaje);
            return personaje;
        }

        public int GetMaximoIdPersonaje()
        {
            //RECUPERAMOS TODOS LOS PERSONAJES
            List<Personaje> lista = this.GetPersonajes();
            return lista.Count + 1;
        }

        //METODO PARA INSERTAR EN REALM.  
        public void InsertarPersonaje(Personaje personaje)
        {
            transaction = conexionrealm.BeginWrite();//COMIENZA LA TRANSACCIÓN CON EL METOD Add PARA AÑADIR OBJETOS
            var entry = conexionrealm.Add(personaje);//SE INSERTA TODO EL OBJETO personaje
            transaction.Commit();
            //this.conexionrealm.Write(() =>
            //{
            //    //CREAMOS UN NUEVO PERSONAJE PARA INSERTAR
            //    //EN EL METODO WRITE
            //    Personaje newpersonaje = new Personaje();
            //    newpersonaje.IdPersonaje = this.GetMaximoIdPersonaje();
            //    newpersonaje.Nombre = personaje.Nombre;
            //    newpersonaje.Serie = personaje.Serie;
            //});
        }

        //METODO PARA MODIFICAR EN REALM.  
        public void ModificarPersonaje(Personaje personaje)
        {
            //BUSCAMOS UN PERSONAJE EN CONCRETO A MODIFICAR
            Personaje existepersonaje = this.BuscarPersonaje(personaje.IdPersonaje);
            //UTILIZAMOS TRANSACCIONES PARA MODIFICAR EL PERSONAJE
            using (var trans = this.conexionrealm.BeginWrite())
            {
                //EL IdPersonaje SALE DESHABILITADO SOLO DEJA MODIFICAR Nombre Y Serie
                existepersonaje.Nombre = personaje.Nombre;
                existepersonaje.Serie = personaje.Serie;
                trans.Commit();
            }
        }

        public void EliminarPersonaje(int idpersonaje)
        {
            //BUSCAMOS EL PERSONAJE EN CONCRETO A ELIMINAR
            Personaje personaje = this.BuscarPersonaje(idpersonaje);

            if (personaje != null)
            {
                using (var trans = this.conexionrealm.BeginWrite())
                {
                    this.conexionrealm.Remove(personaje);
                    trans.Commit();
                }
            }
        }


    }
}
