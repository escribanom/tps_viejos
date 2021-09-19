using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Inicializa el formulario
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
        }
        private bool auxBin = false;
        /// <summary>
        /// Limpia los valores del formulario
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.SelectedIndex = 0;
            lblResultado.Text = default;
            auxBin = false;
        }
        /// <summary>
        /// Limpia los valores del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        
        /// <summary>
        /// Cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Realiza el calculo de los valores ingresados en base al operador ingresado
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns>Retorna el resultado del calculo</returns>
        private static double Operar(string numero1, string numero2,string operador)
        {
            Operando op1 = new Operando(numero1);
            Operando op2 = new Operando(numero2);
            char.TryParse(operador, out char auxOp);
            return Calculadora.Operar(op1, op2, auxOp);
        }
        /// <summary>
        /// Realiza el calculo de los valores recibidos y los muestra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            listaOperaciones.Items.Add(txtNumero1.Text + cmbOperador.Text + txtNumero2.Text +
                '=' + resultado.ToString());
            lblResultado.Text = resultado.ToString();
        }
        /// <summary>
        /// Convierte un numero decimal a binario y lo muestra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if(auxBin==false)
            {
                Operando op = new Operando();
                lblResultado.Text = op.DecimalBinario(lblResultado.Text);
                auxBin = true;
            }
        }
        /// <summary>
        /// Convierte un numero binario a decimal y lo muestra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if(auxBin==true)
            {
                Operando op = new Operando();
                lblResultado.Text = op.BinarioDecimal(lblResultado.Text);
                auxBin = false;
            }
        }
        /// <summary>
        /// Cierra el form en caso de que el usuario confirme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogo=MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if(dialogo==DialogResult.Yes)
            {
                MessageBox.Show("Usted ha abandonado el programa correctamente","Salir");
            }
            else
            {
                MessageBox.Show("Usted ha cancelado el cierre del programa","Salir");
                e.Cancel = true;
            }

        }
        /// <summary>
        /// No permite ingresar operando por teclado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbOperador_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        /// <summary>
        /// No permite ingresar algo diferente a numeros en el textBox2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumero2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsLetter(e.KeyChar)||char.IsSymbol(e.KeyChar)||char.IsWhiteSpace(e.KeyChar)||char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Ingrese solo numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// No permite ingresar algo diferente a numeros en el textBox1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumero1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Ingrese solo numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// limpia el form al cargarlo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
