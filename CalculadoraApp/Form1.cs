using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraApp
{
    public partial class Form1 : Form
    {
        bool NovoNum = false;
        decimal? numleft = null;
        decimal? numright = null;
        string operador = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    

        private void buttonsOperadores_Click(object sender, EventArgs e)
        {
            NovoNum = true;
        }

        private void buttonsNum_Click(object sender, EventArgs e)
        {
            if(txtResultado.Text.Equals("0") || NovoNum)
            {
                txtResultado.Text = string.Empty;
                NovoNum = false;
            }
            Button btn = sender as Button;
            if (txtResultado.Text.Contains(",") && btn.Text.Equals(","))
            {
                return;
            }
            txtResultado.Text += btn.Text;


        }

        private void button20_Click(object sender, EventArgs e)
        {
            txtResultado.Text ="0";
            operador = string.Empty;
            numleft = numright = null;
        }

        private void buttonMais_Click(object sender, EventArgs e)
        {
            operador = button14.Text;
            NovoNum = true;
            if (!numleft.HasValue)
            {
                numleft = Convert.ToDecimal(txtResultado.Text);
            }
            else
            {
                numright = Convert.ToDecimal(txtResultado.Text);
            }
        }

        private void buttonIgual_Click(object sender, EventArgs e)
        {
            decimal? resultado = 0;
            numright = Convert.ToDecimal(txtResultado.Text);
            if (numleft == null) return;
            switch (operador)
            {
                case "+":
                    resultado = numleft + numright;
                    break;
                case "-":
                    resultado = numleft - numright;
                    break;
                case "x":
                    resultado = numleft * numright;
                    break;
                case "/":
                    resultado = numleft / numright;
                    break;

                case "log":
                    resultado = Elog(numleft.Value, numright.Value);
                    break;

                case "^":
                    resultado = potencia(numleft.Value, numright.Value);
                    break;

            }

            numleft=numright=null;
            txtResultado.Text =resultado.HasValue ? resultado.Value.ToString() :"0";

        }

        private void buttonDividir_Click(object sender, EventArgs e)
        {
            operador = "/";
            NovoNum = true;
            if (!numleft.HasValue)
            {
                numleft = Convert.ToDecimal(txtResultado.Text);
            }
            else
            {
                numright = Convert.ToDecimal(txtResultado.Text);
            }

        }

        private void buttonVezes_Click(object sender, EventArgs e)
        {
            operador = "x";
            NovoNum = true;
            if (!numleft.HasValue)
            {
                numleft = Convert.ToDecimal(txtResultado.Text);
            }
            else
            {
                numright = Convert.ToDecimal(txtResultado.Text);
            }

        
         }

        private void buttonMenos_Click(object sender, EventArgs e)
        {
            operador = "-";
            NovoNum = true;
            if (!numleft.HasValue)
            {
                numleft = Convert.ToDecimal(txtResultado.Text);
            }
            else
            {
                numright = Convert.ToDecimal(txtResultado.Text);
            }
        }

        private void buttonnegativo_Click(object sender, EventArgs e)
        {
            txtResultado.Text = (0- Convert.ToDecimal(txtResultado.Text)).ToString();

        }

        private decimal Elog(decimal _num, decimal _base)
        {
            decimal contador = 0;
            decimal num2 = _num;
            decimal precisao = 1.0M;
            while (num2 > _base)
            {
                num2 = num2 / _base;
                contador = contador + 1;
            }

            for(int i=0; i < 60; i++)
            {
                num2 = num2 * num2;
                precisao = precisao / 2;
                if (num2 > _base)
                {
                    contador = contador + precisao;
                    num2 = num2 / _base;
                }
            }
            return contador; 

            
        }

        private void buttonlog(object sender, EventArgs e)
        {
            operador = "log";
            NovoNum = true;
            if (!numleft.HasValue)
            {
                numleft = Convert.ToDecimal(txtResultado.Text);
            }
            else
            {
                numright = Convert.ToDecimal(txtResultado.Text);
            }
        }

         private decimal potencia(decimal _base,decimal expoente)
        {
            decimal v = _base;
            for (int i = 1; i < expoente; i++)
            {
                v = v * _base;
            }
            return v;
        }

        private void buttonspotencia(object sender, EventArgs e)
        {
            operador = "^";
            NovoNum = true;
            if (!numleft.HasValue)
            {
                numleft = Convert.ToDecimal(txtResultado.Text);
            }
            else
            {
                numright = Convert.ToDecimal(txtResultado.Text);
            }
        }
    }
}

       