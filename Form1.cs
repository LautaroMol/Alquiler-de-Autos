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
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtpat.Text != "" && txtdet.Text !=""&& txtmarc.Text !="" && txtmod.Text!="" && txtprec.Text != "")
            {
                DataSet ds = new DataSet();
                ds = objNegAuto.listadoAutos("todos");
                DataRow autoEnc = null;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
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
                }

            }
        }
    }
}
