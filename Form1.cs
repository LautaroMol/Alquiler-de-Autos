using CapaInstituto;
using CapaNegocio;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App1
{
    public partial class Form1 : Form
    {
        NegAuto objNegAuto = new NegAuto();
        NegCliente objNegCliente = new NegCliente();
        public Form1()
        {
            InitializeComponent();
            datagrid.AutoGenerateColumns = false;
            datagrid.Columns.Add("Patente", "Patente");
            datagrid.Columns.Add("Marca", "Marca");
            datagrid.Columns.Add("Modelo", "Modelo");
            datagrid.Columns.Add("Detalles", "Detalles");
            datagrid.Columns.Add("Precio", "Precio");
            datagrid.Columns.Add("Fecha De Entrega", "Fecha De Entrega");
            datagrid.Columns.Add("Fecha De Devolucion", "Fecha De Devolucion");
            datagrid.Columns.Add("Disponible", "Disponible");
            ConfigurarDataGridView();
            LlenarDGV();

            txtprec.KeyPress += txtprec_KeyPress;
        }

        private void LlenarDGV()
        {
            datagrid.Rows.Clear();
            DataSet ds = new DataSet();
            ds = objNegAuto.listadoAutos("todos");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DateTime fechaEntrega = Convert.ToDateTime(dr[5]);
                    DateTime fechaDevolucion = Convert.ToDateTime(dr[6]);

                    string fechaEntregaFormateada = fechaEntrega.ToString("dd/MM/yyyy");
                    string fechaDevolucionFormateada = fechaDevolucion.ToString("dd/MM/yyyy");

                    datagrid.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4],
                    fechaEntregaFormateada, fechaDevolucionFormateada, dr[7].ToString());
                }
            }
        }

        private void ConfigurarDataGridView()
        {
            datagrid.CellFormatting += DataGridViewCellFormatting;
        }

        private void DataGridViewCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == datagrid.Columns["Disponible"].Index && e.RowIndex >= 0)
            {
                if (e.Value != null && e.Value is string)
                {
                    if (e.Value.ToString().ToLower() == "true")
                    {
                        e.Value = "Si";
                        e.FormattingApplied = true;
                    }
                    else if (e.Value.ToString().ToLower() == "false")
                    {
                        e.Value = "No";
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtpat.Text != "" && txtdet.Text != "" && txtmarc.Text != "" && txtmod.Text != "" && txtprec.Text != "")
            {
                DataSet ds = new DataSet();
                ds = objNegAuto.listadoAutos("todos");
                DataRow autoEnc = null;
                int nGrabados = -1;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (dr[0].ToString() == txtpat.Text)
                        {
                            autoEnc = dr;
                            break;
                        }
                    }
                }
                if (autoEnc != null)
                {
                    MessageBox.Show("Ya hay un auto con esa patente");
                }
                else
                {
                    Auto auto = new Auto(txtpat.Text, txtmarc.Text, txtmod.Text, txtdet.Text, int.Parse(txtprec.Text), DateTime.Today, DateTime.Today, true);
                    nGrabados = objNegAuto.abmAutos("Alta", auto);
                    if (nGrabados == -1)
                    {
                        MessageBox.Show("No se pudo grabar el prod en el sistema");
                    }

                    MessageBox.Show("Auto Cargado al sistema");
                    LlenarDGV();
                }

            }
            else MessageBox.Show("llene todos los campos");
        }

        private void butBusc_Click(object sender, EventArgs e)
        {
            bool enc = false;
            DataSet ds = objNegAuto.listadoAutos(ingpatente.Text.ToString());
            MarcaM.Text = "Marca";
            ModeloM.Text = "Modelo";
            DetallesM.Text = "Detalles";
            PrecioM.Text = "Precio";
            DispM.Text = "Disponible?";
            //llenando el combo box
            DataSet ds1 = objNegAuto.listadoAutos("todos");

            comboBox1.Items.Clear();
            foreach (DataRow dr in ds1.Tables[0].Rows)
            {
                // Agregar patente al ComboBox solo si el auto está disponible
                if ((bool)dr["Disponible"])
                {
                    comboBox1.Items.Add(dr["Patente"].ToString());
                }

            }


            if (ingpatente.Text != " ")
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    MarcaM.Text += " : " + dr["Marca"].ToString();
                    ModeloM.Text += " : " + dr["Modelo"].ToString();
                    DetallesM.Text += " : " + dr["Detalles"].ToString();
                    PrecioM.Text += " : " + dr["Precio"].ToString();
                    DispM.Text += " : " + ((bool)dr["Disponible"] ? "si" : "No");
                    enc = true;
                }

                if (!enc)
                {
                    // Si no se encontró la patente, mostrar un mensaje
                    MessageBox.Show("No se encontró la patente ingresada.");
                }
            }
            else MessageBox.Show("Debe ingresar datos");
        }



        private void butAlquilar_Click(object sender, EventArgs e)
        {
            string patente = ingpatente.Text;

            Auto auto = BuscarAutoPorPatente(patente);

            if (auto != null && auto.GetDisponible() == true && txtalqdni.Text != " ")
            {
                Cliente cliente = BuscarCliente(int.Parse(txtalqdni.Text));
                
                if (cliente != null)
                {
                    if (cliente.GetAlquilado() == true)
                    {
                        MessageBox.Show("El cliente ya tiene alquilado 1 vehiculo a su nombre");
                    }else
                    {
                        auto.Alquilar(datepickerEnt.Value, dateTimeDev.Value);
                        objNegAuto.abmAutos("Modificar", auto);
                        cliente.reserva(auto.GetPatente());
                        objNegCliente.abmCliente("Modificar", cliente);
                        MessageBox.Show("¡Auto alquilado con éxito!");
                        LlenarDGV();
                    }
                }
                else  
                {
                    MessageBox.Show("no se encontro el cliente, por favor carguelo ");
                    cargaCliente cargaCliente = new cargaCliente();
                    cargaCliente.Show();
                }               
            }
            else
            {
                MessageBox.Show("Error al alquilar, verifique que la patente sea correcta y este disponible");
            }
        }
        private Auto BuscarAutoPorPatente(string patente)
        {
            DataSet ds = objNegAuto.listadoAutos(patente);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                Auto auto = new Auto(dr["Patente"].ToString(), dr["Marca"].ToString(), dr["Modelo"].ToString(),
                                     dr["Detalles"].ToString(), Convert.ToInt32(dr["Precio"]),
                                     Convert.ToDateTime(dr["FechaEntrega"]), Convert.ToDateTime(dr["FechaDevolucion"]),
                                     Convert.ToBoolean(dr["Disponible"]));
                return auto;
            }
            else
            {
                return null;
            }
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

        private void butLib_Click(object sender, EventArgs e)
        {
            if (datagrid.SelectedRows.Count > 0)
            {
                string patente = datagrid.SelectedRows[0].Cells["Patente"].Value.ToString();
                Auto auto = BuscarAutoPorPatente(patente);
                Cliente cliente = null;
                if (auto != null && auto.GetDisponible() == false)
                {
                    DataSet ds = objNegCliente.listadoCliente(0);
                    if (ds.Tables[0].Rows.Count> 0)
                    {
                        foreach(DataRow dr in ds.Tables[0].Rows)
                        {
                            if (dr[4].ToString() == auto.GetPatente())
                            {
                                cliente = new Cliente(int.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), int.Parse(dr[3].ToString()));
                                cliente.Liberar();
                            }
                        }
                    }
                    objNegCliente.abmCliente("Modificar", cliente);
                    auto.Liberar();
                    objNegAuto.abmAutos("Modificar", auto);
                    MessageBox.Show("Auto Disponible");
                    LlenarDGV();
                }
                else MessageBox.Show("No puede liberar autos disponibles");
            }else MessageBox.Show("Por favor, seleccione una fila antes de liberar el auto.");
        }

        private void butBorrar_Click(object sender, EventArgs e)
        {
            if (datagrid.SelectedRows.Count > 0)
            {
                string patente = datagrid.SelectedRows[0].Cells["Patente"].Value.ToString();
                Auto auto = BuscarAutoPorPatente(patente);
                if (auto != null && auto.GetDisponible() == true)
                {
                    objNegAuto.abmAutos("Borrar", auto);
                    MessageBox.Show("Auto Borrado");
                    LlenarDGV();
                }
                else MessageBox.Show("No puede borrar autos ocupados");
            }
            else MessageBox.Show("Por favor, seleccione una fila antes de Borrar el auto.");
        }
        private void txtBuscarPatente_TextChanged(object sender, EventArgs e)
        {
            string patenteABuscar = buscdata.Text.Trim().ToUpper();

            if (!string.IsNullOrEmpty(patenteABuscar))
            {
                foreach (DataGridViewRow row in datagrid.Rows)
                {
                    if (row.Cells["Patente"].Value != null)
                    {
                        string patenteEnFila = row.Cells["Patente"].Value.ToString().ToUpper();

                        if (patenteEnFila.IndexOf(patenteABuscar, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            row.Selected = true;
                            datagrid.FirstDisplayedScrollingRowIndex = row.Index;
                            break;
                        }
                    }
                }
            }
        }
        
        private void txtprec_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnmod_Click(object sender, EventArgs e)
        {
            int result = -1;
            if (txtpat.Text != "" && txtdet.Text != "" && txtmarc.Text != "" && txtmod.Text != "" && txtprec.Text != "")
            {
                Auto automod = BuscarAutoPorPatente(txtpat.Text);
                if (automod != null)
                {
                    automod.Modi(txtpat.Text, txtmarc.Text, txtmod.Text, txtdet.Text, int.Parse(txtprec.Text));
                    result = objNegAuto.abmAutos("Modificar",automod);
                    if (result != -1) MessageBox.Show("Auto con la patente: " + txtpat.Text + " Modificado exitosamente");
                    else MessageBox.Show("Error");
                    LlenarDGV();
                }
                else MessageBox.Show("No existe un auto con la patente ingresada");
            }

        }

        private void btnCli_Click(object sender, EventArgs e)
        {
            cargaCliente cargaCliente = new cargaCliente();
            cargaCliente.Show();
        }
    }
}