using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormWebServices
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void SetDataGridViewDataSource(DataSet dataSet)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                // Crear instancia del cliente del servicio web
                var cliente = new ServiceReference1.WebService1SoapClient();

                // Llamar al método del servicio web que devuelve un DataSet
                DataSet dataSet = cliente.tbalumno();

                // Verificar si el DataSet tiene alguna tabla y filas
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    // Asignar el DataSet al DataSource del DataGridView
                    dataGridView1.DataSource = dataSet.Tables[0];
                }
                else
                {
                    dataGridView1.DataSource = null; // Limpiar el DataGridView
                    MessageBox.Show("No hay datos disponibles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones adecuadamente (mostrar un mensaje de error, registrar, etc.)
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
