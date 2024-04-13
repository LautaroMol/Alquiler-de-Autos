using CapaInstituto;
using CapaNegocio;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App1
{
    public partial class cargaCliente : Form
    {
        NegAuto objNegAuto = new NegAuto();
        NegCliente objNegCliente = new NegCliente();
        public cargaCliente()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add("DNI", "DNI");
            dataGridView1.Columns.Add("Nombres", "Nombres");
            dataGridView1.Columns.Add("Apellidos", "Apellidos");
            dataGridView1.Columns.Add("Telefono", "Teléfono");
            dataGridView1.Columns.Add("Patente", "Patente");
            dataGridView1.Columns.Add("Alquilando", "Alquilando");


            LlenarDGV();
        }

        private void btnguard_Click(object sender, EventArgs e)
        {
            if (txtdni.Text.Trim() != "" && txtnom.Text.Trim() != "" && txtap.Text.Trim() != "" && txttel.Text.Trim() != "")
            {
                DataSet ds = new DataSet();
                ds = objNegCliente.listadoCliente(0);
                DataRow clienEnc = null;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (dr[0].ToString() == txtdni.Text)
                        {
                            clienEnc = dr;
                            break;
                        }
                    }
                }
                if (clienEnc != null)
                {
                    MessageBox.Show("Ya hay un cliente con ese dni");
                }
                else
                {
                    int nGrabados = -1;
                    Cliente cliente = new Cliente(int.Parse(txtdni.Text), txtnom.Text, txtap.Text, int.Parse(txttel.Text));
                    nGrabados = objNegCliente.abmCliente("Alta", cliente);
                    if (nGrabados == -1)
                    {
                        MessageBox.Show("No se pudo grabar el Cliente en el sistema");
                    }
                    MessageBox.Show("Cliente Cargado al sistema");
                    LlenarDGV();
                }

            }
            else MessageBox.Show("Por favor llene todos los campos");
        }

        private Cliente BuscarCliente(int dni)
        {
            DataSet ds = objNegCliente.listadoCliente(dni);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                Cliente cliente = new Cliente(Convert.ToInt32(dr["DNI"]), dr["Nombres"].ToString(), dr["Apellidos"].ToString(),
                    Convert.ToInt32(dr["Telefono"]), dr["Patente"].ToString(), Convert.ToBoolean(dr["Alquilado"]));
                return cliente;
            }
            else return null;
        }

        private void LlenarDGV()
        {
            dataGridView1.Rows.Clear();
            DataSet ds = objNegCliente.listadoCliente(0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(
                        dr["DNI"].ToString(),
                        dr["Nombres"].ToString(),
                        dr["Apellidos"].ToString(),
                        dr["Telefono"].ToString(),
                        dr["Patente"].ToString(),
                        ((bool)dr["Alquilado"]) ? "Sí" : "No"
                    );
                }
            }
        }

        private void btnelim_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int Dni = int.Parse(dataGridView1.SelectedRows[0].Cells["DNI"].Value.ToString());
                Cliente cliente = BuscarCliente(Dni);
                if (cliente != null && cliente.GetAlquilado() == false)
                {
                    objNegCliente.abmCliente("Borrar", cliente);
                    MessageBox.Show("Cliente Borrado");
                    LlenarDGV();
                }
                else MessageBox.Show("No puede borrar clientes que esten alquilando un auto");
            }
            else MessageBox.Show("Por favor, seleccione una fila antes de Borrar el auto.");
        }

        private void btnmod_Click(object sender, EventArgs e)
        {
            Cliente client = BuscarCliente(int.Parse(txtdni.Text.ToString()));
            if (client != null)
            {
                txtnom.Text = client.GetNombres();
                txtap.Text = client.GetApellidos();
                txttel.Text = client.GetTelefono().ToString();
                txtdni.Enabled = false;
            }
            else MessageBox.Show("No se encontro un cliente con ese dni");
        }

        private void btnmodi_Click(object sender, EventArgs e)
        {
            int result = -1;
            if (txtdni.Text.Trim() != "" && txtnom.Text.Trim() != "" && txtap.Text.Trim() != "" && txttel.Text.Trim()!= "")
            {
                Cliente clienmid = BuscarCliente(int.Parse(txtdni.Text));
                if (clienmid != null)
                {
                    clienmid.Modi(txtnom.Text,txtap.Text,int.Parse(txttel.Text));
                    result = objNegCliente.abmCliente("Modificar", clienmid);
                    if (result != -1) MessageBox.Show("Cliente de dni: " + txtdni.Text + " Modificado exitosamente");
                    else MessageBox.Show("Error");
                    txtdni.Enabled = true;
                    LlenarDGV();
                }
                else MessageBox.Show("No existe el cliente");
            }
        }
    }
}
