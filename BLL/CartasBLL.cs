using DAL;
using Entidadades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class CartasBLL : RepositorioBase<Carta>
    {
        public bool Guardar(Carta entity)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                if (contexto.cartas.Add(entity) != null)
                {

                    var cuenta = contexto.cartas.Find(entity.CartaID);
                    //Incrementar el balance
                    cuenta.CantidadCartas += entity.CantidadCartas;


                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception) { throw; }

            return paso;
        }

        public bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                Carta depositos = contexto.cartas.Find(id);

                if (depositos != null)
                {
                    var cuenta = contexto.cartas.Find(depositos.CartaID);
                    //Incrementar la cantidad
                    cuenta.CantidadCartas -= depositos.CantidadCartas;

                    contexto.Entry(depositos).State = EntityState.Deleted;

                }

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                    contexto.Dispose();
                }


            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }


        public override bool Modificar(Carta entity)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            RepositorioBase<Carta> repositorio = new RepositorioBase<Carta>();
            try
            {

                var depositosanterior = repositorio.Buscar(entity.CartaID);

                var Cuenta = contexto.cartas.Find(entity.CartaID);
                var Cuentasanterior = contexto.cartas.Find(depositosanterior.CartaID);

                if (entity.CartaID != depositosanterior.CartaID)
                {
                    Cuenta.CantidadCartas += entity.CantidadCartas;
                    Cuentasanterior.CantidadCartas -= depositosanterior.CantidadCartas;
                }


                int diferencia;
                diferencia = entity.CantidadCartas - depositosanterior.CantidadCartas;

                Cuenta.CantidadCartas += diferencia;

                contexto.Entry(entity).State = EntityState.Modified;

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception) { throw; }

            return paso;
        }
    }
}
