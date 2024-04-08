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
    public partial class Form1 : Form
    {
        NegAuto objNegAuto = new NegAuto();

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
            // Resto del código para configurar las columnas como lo tienes actualmente

            // Agregar un manejador de eventos CellFormatting a la columna "Libre"
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
                    int nGrabados = -1;
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

            if (auto != null)
            {
                auto.Alquilar(datepickerEnt.Value, dateTimeDev.Value);
                int est = objNegAuto.abmAutos("Modificar", auto);
                MessageBox.Show("¡Auto alquilado con éxito!");
                LlenarDGV();
            }
            else
            {
                MessageBox.Show("Error al alquilar, verifique que la patente sea correcta.");
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

        private void butLib_Click(object sender, EventArgs e)
        {
            if (datagrid.SelectedRows.Count > 0)
            {
                string patente = datagrid.SelectedRows[0].Cells["Patente"].Value.ToString();
                Auto auto = BuscarAutoPorPatente(patente);
                if (auto != null && auto.getDisponible() == false)
                {
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
                if (auto != null && auto.getDisponible() == true)
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
            string patenteABuscar = buscdata.Text.Trim();

            if (!string.IsNullOrEmpty(patenteABuscar))
            {
                foreach (DataGridViewRow row in datagrid.Rows)
                {
                    string patenteEnFila = row.Cells["Patente"].Value.ToString();

                    if (patenteEnFila.Equals(patenteABuscar, StringComparison.OrdinalIgnoreCase))
                    {
                        row.Selected = true;

                        datagrid.FirstDisplayedScrollingRowIndex = row.Index;

                        break;
                    }
                }
            }
        }

    }
}