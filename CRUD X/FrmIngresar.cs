using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using CRUD_X.modelo;
namespace CRUD_X
{
    public partial class FrmIngresar : Form
    {
        public FrmIngresar()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            TIC.DatosPersonas persona = new TIC.DatosPersonas();
            persona.Cedula = txtCedula.Text;
            persona.Apellidos = txtApellidos.Text;
            persona.Nombres = txtNombres.Text;
            persona.Sexo = cmbSexo.Text;
            persona.FechaNacimiento =dtFechaNacimiento.Value;
            ValidarCorreo ps = new ValidarCorreo();
            if (ps.Email_Valido(this.txtCorreo.Text) == false)
            {
                error1.SetError(this.txtCorreo, " Ingrese un Email Válido");
                this.txtCorreo.Focus();
                return;
            }
            else
            {
                error1.Clear();
                btnGuardar.Visible = true;



            }
            persona.Correo = txtCorreo.Text;
            try
            {
                persona.Estatura = int.Parse(txtEstatura.Text);
            }catch(Exception ez)
            {
                MessageBox.Show(ez.Message.ToString());
            }
            try
            {
                persona.Peso = decimal.Parse(txtPeso.Text);
            }catch (Exception hz)
            {
                MessageBox.Show("Error:Numero de peso null");
            }
            try {
                int x = TIC.DatosPersonask.crear(persona);
                if (x > 0)
                    MessageBox.Show("Registro agregado");
                else
                    MessageBox.Show("No agregado");
            } catch (Exception hx){
                MessageBox.Show(hx.Message.ToString());
            }
        }
        private void cargar()
        {
            DataTable ps = TIC.DatosPersonask.getAll();
            this.dgPersonas.DataSource = ps;
        }

        private void dgPersonas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void FrmIngresar_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
