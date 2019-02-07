using BLL;
using Entidadades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PoryectoCartas.UI.Registros
{
    public partial class Destinatarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            FechadateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            CantCartasTexbox.Text = "0";
            DestinatarioIDTextbox.Text = "0";
            

        }

        public Destinatario LlenaClase()
        {
            Destinatario destinatarios = new Destinatario();
            int id;
            bool result = int.TryParse(DestinatarioIDTextbox.Text, out id);
            if (result == true)
            {
                destinatarios.DestinatarioID = id;
            }
            else
            {
                destinatarios.DestinatarioID = 0;
            }

            destinatarios.Nombre = NombreTextbox.Text;
            destinatarios.CantCartas = Convert.ToInt32(CantCartasTexbox.Text.ToString());

            return destinatarios;
        }

        private void LlenaCampos(Destinatario destinatario)
        {
            DestinatarioIDTextbox.Text = destinatario.DestinatarioID.ToString();
            NombreTextbox.Text = destinatario.Nombre;
            CantCartasTexbox.Text = destinatario.CantCartas.ToString();


        }

        private void Limpiar()
        {
            
            DestinatarioIDTextbox.Text = "";
            NombreTextbox.Text = "";
            CantCartasTexbox.Text = "0";

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Destinatario> repositorio = new RepositorioBase<Destinatario>();

            Destinatario destinatario = LlenaClase();

            bool paso = false;

            if (Page.IsValid)
            {
                if (DestinatarioIDTextbox.Text == "0")
                {
                    paso = repositorio.Guardar(destinatario);

                }


                else
                {
                    var verificar = repositorio.Buscar(Utilities.Utils.ToInt(DestinatarioIDTextbox.Text));

                    if (verificar != null)
                    {
                        paso = repositorio.Modificar(destinatario);
                    }
                    else
                    {
                        Utilities.Utils.ShowToastr(this, "Destinatario No Existe", "Fallido", "success");
                        return;
                    }
                }

                if (paso)

                {
                    Utilities.Utils.ShowToastr(this, "Destinatario Registrada", "Exito", "success");
                }

                else

                {
                    Utilities.Utils.ShowToastr(this, "No pudo Guardarse el Destinatario", "Exito", "success");
                }
                Limpiar();
                return;
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {

            RepositorioBase<Destinatario> repositorio = new RepositorioBase<Destinatario>();



            int id = Utilities.Utils.ToInt(DestinatarioIDTextbox.Text);
            var cuenta = repositorio.Buscar(id);


            if (cuenta == null)
            {
                Utilities.Utils.ShowToastr(this, "No se puede Eliminar", "Fallido", "success");
            }

            

            else
            {
                repositorio.Eliminar(id);

                Utilities.Utils.ShowToastr(this, "Cuenta a sido Eliminada", "Exito", "success");
                Limpiar();
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Destinatario> repositorio = new RepositorioBase<Destinatario>();


            Destinatario cuentas = repositorio.Buscar(Convert.ToInt32(DestinatarioIDTextbox.Text));
            if (cuentas != null)
            {
                LlenaCampos(cuentas);
            }
            else
            {
                Utilities.Utils.ShowToastr(this, "Usuario no encontrado", "Fallido", "success");

            }
        }
    }
}