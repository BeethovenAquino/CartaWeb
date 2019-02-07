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
    public partial class Cartas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Carta LlenaClase()
        {
            Carta carta = new Carta();
            int id;
            bool result = int.TryParse(CartaIDTextbox.Text, out id);
            if (result == true)
            {
                carta.CartaID = id;
            }
            else
            {
                carta.CartaID = 0;
            }

            carta.CartaID = Convert.ToInt32(DropDownList.SelectedValue);

            carta.Cuerpo = CuerpoTextbox.Text;
            carta.Fecha = Convert.ToDateTime(FechadateTime.Text);
            carta.CantidadCartas = Convert.ToInt32(CantCartasTexbox.Text.ToString());

            return carta;
        }

        private void LlenaCampos(Carta carta)
        {
            CartaIDTextbox.Text = carta.CartaID.ToString();
            LlenaComboCuentaID();
            CuerpoTextbox.Text = carta.Cuerpo;
            CantCartasTexbox.Text = carta.CantidadCartas.ToString();

        }
        private void Limpiar()
        {
            CartaIDTextbox.Text = "";
            LlenaComboCuentaID();
            CuerpoTextbox.Text = "";
            CantCartasTexbox.Text = "";
            FechadateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");

        }
        
        private void LlenaComboCuentaID()
        {
            RepositorioBase<Carta> cuentas = new RepositorioBase<Carta>();
            DropDownList.Items.Clear();
            DropDownList.DataSource = cuentas.GetList(x => true);
            DropDownList.DataValueField = "CartaID";
            DropDownList.DataTextField = "Nombre";
            DropDownList.DataBind();
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {

            CartasBLL repositorio = new CartasBLL();
            Carta carta = LlenaClase();
            RepositorioBase<Carta> cuentas = new RepositorioBase<Carta>();

            var validar = cuentas.Buscar(Utilities.Utils.ToInt(DropDownList.SelectedValue));

            bool paso = false;


            if (validar != null)
            {

                if (Page.IsValid)
                {
                    if (CartaIDTextbox.Text == "0")
                    {
                        paso = repositorio.Guardar(carta);

                    }

                    else
                    {
                        var verificar = repositorio.Buscar(Utilities.Utils.ToInt(CartaIDTextbox.Text));
                        if (verificar != null)
                        {
                            paso = repositorio.Modificar(carta);
                        }
                        else
                        {
                            Utilities.Utils.ShowToastr(this, "No se encuentra el ID", "Fallo", "success");
                            return;
                        }
                    }

                    if (paso)

                    {
                        Utilities.Utils.ShowToastr(this, "Registro Con Exito", "Exito", "success");

                    }

                    else

                    {
                        Utilities.Utils.ShowToastr(this, "No se pudo Guardar", "Fallo", "success");
                    }
                    Limpiar();
                    return;
                }


            }
            else
            {
                Utilities.Utils.ShowToastr(this, "El numero de cuenta no existe", "Fallo", "success");
                return;


            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {

            CartasBLL repositorio = new CartasBLL();
            RepositorioBase<Carta> dep = new RepositorioBase<Carta>();


            int id = Utilities.Utils.ToInt(CartaIDTextbox.Text);
            var depositos = repositorio.Buscar(id);


            if (depositos == null)
            {
                Utilities.Utils.ShowToastr(this, "El deposito no existe", "Fallo", "success");
            }

            else
            {
                repositorio.Eliminar(id);



                Utilities.Utils.ShowToastr(this, "Elimino Correctamente", "Exito", "success");
                Limpiar();
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {

            RepositorioBase<Carta> repositorio = new RepositorioBase<Carta>();


            Carta carta = repositorio.Buscar(Utilities.Utils.ToInt(CartaIDTextbox.Text));

            Limpiar();
            if (carta != null)
            {
                LlenaCampos(carta);

                Utilities.Utils.ShowToastr(this, "Se ha Encontrado su deposito", "Exito", "success");
            }
            else
            {
                Utilities.Utils.ShowToastr(this, "el ID registrado no existe", "Fallido", "success");
            }
        }
    }
}