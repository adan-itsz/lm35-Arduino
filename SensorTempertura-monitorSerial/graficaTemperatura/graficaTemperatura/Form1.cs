using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections;

namespace graficaTemperatura
{
    public partial class Form1 : Form
    {
        ArrayList array= new ArrayList();
        public Form1()
        {
            InitializeComponent();
            serialPort1.PortName = ("COM7");
            serialPort1.BaudRate = 9600;
            serialPort1.Open();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        private void puertos()
        {
           
        }

        private void cBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // serialPort1.PortName = cBox1.Text;
           // cBox1.Enabled = false;
            try
            {
                serialPort1.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("puerto no disponible");
            }
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            serialPort1.Close();
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            String datosRecibidos = serialPort1.ReadLine();
            array.Add( datosRecibidos);
           // actualizarGrafica();
            
        }

        private void actualizarGrafica()
        {
            int x = 0;
            chart1.Series["Grados centigrados"].Points.Clear();
            foreach(String datos in array)
            {
                chart1.Series["Grados centigrados"].Points.AddXY(x++, datos);//faltará convertir a double
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            actualizarGrafica();
        }
    }
}
