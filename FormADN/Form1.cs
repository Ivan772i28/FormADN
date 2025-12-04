using System;
using System.Drawing;
using System.Windows.Forms;

namespace FormADN
{
    public partial class Form1 : Form
    {
        private TextBox[] txtProteinas;
        private Button btnAnalizar;
        private Button btnLimpiar;
        private Label lblTitulo;
        private Label lblInstrucciones;
        private Panel panelResultados;
        private Label lblResultados;

        private int contadorA = 0;
        private int contadorC = 0;
        private int contadorG = 0;
        private int contadorT = 0;
        private int datosErroneos = 0;

        const int TOTAL_VALORES = 20;

        public Form1()
        {
            InitializeComponent();
            InicializarControles();
        }

        private void InicializarControles()
        {
            // Configuración del formulario
            this.Text = "Analizador de Secuencia de ADN";
            this.Size = new Size(700, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(240, 248, 255);

            // Título
            lblTitulo = new Label
            {
                Text = "ANÁLISIS DE SECUENCIA DE ADN",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(25, 25, 112),
                Location = new Point(150, 15),
                AutoSize = true
            };
            this.Controls.Add(lblTitulo);

            // Instrucciones
            lblInstrucciones = new Label
            {
                Text = "Ingrese las 20 proteínas: (A)denina, (C)itosina, (G)uanina, (T)imina",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.FromArgb(70, 70, 70),
                Location = new Point(80, 50),
                AutoSize = true
            };
            this.Controls.Add(lblInstrucciones);

            // Crear 20 TextBoxes para las proteínas
            txtProteinas = new TextBox[TOTAL_VALORES];
            int x = 30;
            int y = 90;
            int contador = 0;

            for (int i = 0; i < TOTAL_VALORES; i++)
            {
                Label lbl = new Label
                {
                    Text = $"{i + 1}:",
                    Location = new Point(x, y + 3),
                    Size = new Size(25, 20),
                    Font = new Font("Segoe UI", 9),
                    TextAlign = ContentAlignment.MiddleRight
                };
                this.Controls.Add(lbl);

                txtProteinas[i] = new TextBox
                {
                    Location = new Point(x + 30, y),
                    Size = new Size(40, 25),
                    MaxLength = 1,
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    TextAlign = HorizontalAlignment.Center
                };
                txtProteinas[i].CharacterCasing = CharacterCasing.Upper;
                this.Controls.Add(txtProteinas[i]);

                contador++;
                x += 80;

                // Nueva fila cada 5 elementos
                if (contador % 5 == 0)
                {
                    x = 30;
                    y += 40;
                }
            }

            // Botón Analizar
            btnAnalizar = new Button
            {
                Text = "🔬 Analizar Secuencia",
                Location = new Point(180, 330),
                Size = new Size(160, 40),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.FromArgb(70, 130, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnAnalizar.FlatAppearance.BorderSize = 0;
            btnAnalizar.Click += BtnAnalizar_Click;
            this.Controls.Add(btnAnalizar);

            // Botón Limpiar
            btnLimpiar = new Button
            {
                Text = "🗑️ Limpiar",
                Location = new Point(360, 330),
                Size = new Size(120, 40),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.FromArgb(220, 20, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.Click += BtnLimpiar_Click;
            this.Controls.Add(btnLimpiar);

            // Panel de Resultados
            panelResultados = new Panel
            {
                Location = new Point(30, 385),
                Size = new Size(630, 510),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Visible = false
            };
            this.Controls.Add(panelResultados);

            // Label de Resultados
            lblResultados = new Label
            {
                Location = new Point(10, 10),
                Size = new Size(610, 390),
                Font = new Font("Consolas", 10),
                ForeColor = Color.Black
            };
            panelResultados.Controls.Add(lblResultados);
        }

        private void BtnAnalizar_Click(object? sender, EventArgs e)
        {
            // Reiniciar contadores
            contadorA = 0;
            contadorC = 0;
            contadorG = 0;
            contadorT = 0;
            datosErroneos = 0;

            // Analizar cada entrada
            for (int i = 0; i < TOTAL_VALORES; i++)
            {
                string valor = txtProteinas[i].Text.Trim().ToUpper();

                if (string.IsNullOrEmpty(valor))
                {
                    MessageBox.Show($"Por favor complete todos los campos.\nFalta la proteína {i + 1}",
                        "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtProteinas[i].Focus();
                    return;
                }

                char proteina = valor[0];

                switch (proteina)
                {
                    case 'A':
                        contadorA++;
                        txtProteinas[i].BackColor = Color.FromArgb(144, 238, 144);
                        break;
                    case 'C':
                        contadorC++;
                        txtProteinas[i].BackColor = Color.FromArgb(173, 216, 230);
                        break;
                    case 'G':
                        contadorG++;
                        txtProteinas[i].BackColor = Color.FromArgb(255, 218, 185);
                        break;
                    case 'T':
                        contadorT++;
                        txtProteinas[i].BackColor = Color.FromArgb(255, 182, 193);
                        break;
                    default:
                        datosErroneos++;
                        txtProteinas[i].BackColor = Color.FromArgb(255, 99, 71);
                        break;
                }
            }

            MostrarResultados();
        }

        private void MostrarResultados()
        {
            string resultado = "";

            if (datosErroneos > 0)
            {
                resultado = "═══════════════════════════════════════════════\n";
                resultado += "              ⚠️  ATENCIÓN  ⚠️\n";
                resultado += "═══════════════════════════════════════════════\n\n";
                resultado += $"  Se encontraron {datosErroneos} dato(s) erróneo(s)\n\n";
                resultado += "  La secuencia NO es válida para análisis.\n\n";
                resultado += "  Por favor, corrija los valores marcados en rojo.";

                lblResultados.ForeColor = Color.FromArgb(178, 34, 34);
            }
            else
            {
                double porcentajeA = (contadorA * 100.0) / TOTAL_VALORES;
                double porcentajeC = (contadorC * 100.0) / TOTAL_VALORES;
                double porcentajeG = (contadorG * 100.0) / TOTAL_VALORES;
                double porcentajeT = (contadorT * 100.0) / TOTAL_VALORES;

                resultado = "═══════════════════════════════════════════════\n";
                resultado += "         ✓ SECUENCIA VÁLIDA - ANÁLISIS COMPLETADO\n";
                resultado += "═══════════════════════════════════════════════\n\n";
                resultado += "Distribución de proteínas:\n";
                resultado += "───────────────────────────────────────────────\n";
                resultado += $"(A)denina  : {contadorA,2} proteínas - {porcentajeA,6:F1}%\n";
                resultado += $"(C)itosina : {contadorC,2} proteínas - {porcentajeC,6:F1}%\n";
                resultado += $"(G)uanina  : {contadorG,2} proteínas - {porcentajeG,6:F1}%\n";
                resultado += $"(T)imina   : {contadorT,2} proteínas - {porcentajeT,6:F1}%\n";
                resultado += "───────────────────────────────────────────────\n";
                resultado += $"TOTAL      : {TOTAL_VALORES} proteínas - 100.0%\n";

                lblResultados.ForeColor = Color.FromArgb(34, 139, 34);
            }

            lblResultados.Text = resultado;
            panelResultados.Visible = true;
        }

        private void BtnLimpiar_Click(object? sender, EventArgs e)
        {
            foreach (TextBox txt in txtProteinas)
            {
                txt.Clear();
                txt.BackColor = Color.White;
            }

            panelResultados.Visible = false;
            txtProteinas[0].Focus();
        }
    }
}