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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el identificador desde la caja de texto
                string ciToDelete = textBox1.Text;

                // Validar que el campo no esté vacío
                if (string.IsNullOrWhiteSpace(ciToDelete))
                {
                    MessageBox.Show("Ingrese un CI válido para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear instancia del cliente del servicio web
                var cliente = new ServiceReference1.WebService1SoapClient();

                // Llamar al método del servicio web para eliminar el registro
                cliente.DeleteAlumno(ciToDelete);

                // Actualizar el DataGridView después de eliminar
                RefreshDataGridView();

                // Limpiar la caja de texto
                textBox1.Clear();
            }
            catch (Exception ex)
            {
                // Manejar excepciones adecuadamente (mostrar un mensaje de error, registrar, etc.)
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshDataGridView()
        {
            try
            {
                // Llamada al método GetAlumnos para obtener los datos actualizados
                var cliente = new ServiceReference1.WebService1SoapClient();
                DataSet dataSet = cliente.tbalumno();

                // Verificar si el DataSet tiene alguna tabla y filas
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    // Asignar el DataSet al DataSource del DataGridView
                    dataGridView1.DataSource = dataSet.Tables[0];
                }
                else
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("No hay datos disponibles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones adecuadamente (mostrar un mensaje de error, registrar, etc.)
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los valores de las cajas de texto
                string ci = textBox2.Text;
                string nombre = textBox3.Text;

                // Validar que los campos no estén vacíos
                if (string.IsNullOrWhiteSpace(ci) || string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("Ingrese valores válidos para CI y Nombre.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear instancia del cliente del servicio web
                var cliente = new ServiceReference1.WebService1SoapClient();

                // Llamar al método del servicio web para insertar un nuevo registro
                cliente.InsertAlumno(ci, nombre);

                // Actualizar el DataGridView después de la inserción
                RefreshDataGridView();

                // Limpiar las cajas de texto después de la inserción
                textBox2.Clear();
                textBox3.Clear();
            }
            catch (Exception ex)
            {
                // Manejar excepciones adecuadamente (mostrar un mensaje de error, registrar, etc.)
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los valores de las cajas de texto
                string ci = textBox4.Text;
                string nuevoNombre = textBox5.Text;

                // Validar que los campos no estén vacíos
                if (string.IsNullOrWhiteSpace(ci) || string.IsNullOrWhiteSpace(nuevoNombre))
                {
                    MessageBox.Show("Ingrese valores válidos para CI y Nuevo Nombre.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear instancia del cliente del servicio web
                var cliente = new ServiceReference1.WebService1SoapClient();

                // Llamar al método del servicio web para actualizar un registro
                cliente.UpdateAlumno(ci, nuevoNombre);

                // Actualizar el DataGridView después de la actualización
                RefreshDataGridView();

                // Limpiar las cajas de texto después de la actualización
                textBox4.Clear();
                textBox5.Clear();
            }
            catch (Exception ex)
            {
                // Manejar excepciones adecuadamente (mostrar un mensaje de error, registrar, etc.)
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
