using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace Proyecto_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lex.palabrasReservadas();
        }


        //Crando componentes
        private TabPage tabNuevo;
        private RichTextBox rtbNuevo;
        private int contador = 0;
        public static String extencion2 = String.Empty;



        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Agregar pestañas dinámicamente
        private void nuevaPestañaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabNuevo = new TabPage();
            rtbNuevo = new RichTextBox();

            tcPestañas.Controls.Add(tabNuevo);

            tabNuevo.Controls.Add(rtbNuevo);

            tabNuevo.Name = "Grafica";
            tabNuevo.Padding = new Padding(3);
            tabNuevo.Size = new Size(293, 409);
            tabNuevo.TabIndex = 0;
            tabNuevo.Text = "Pestaña Nueva";
            tabNuevo.UseVisualStyleBackColor = true;

            rtbNuevo.Size = new Size(297, 535);
            rtbNuevo.TabIndex = 0;
            rtbNuevo.Text = "";
            extencion2 = String.Empty;

            rtbNuevo.TextChanged += new EventHandler(this.Text_Change);
        }

        private void Text_Change(Object sender, EventArgs e)
        {
            MatchCollection mc = null;
            MatchCollection mcCadenas = null;
            MatchCollection mcDigitos = null;
            MatchCollection mcLlaves = null;
            MatchCollection mcPuntoycoma = null;
            String tokens = "";

            String cadena = "(\".*?\")";
            mcCadenas = Regex.Matches(getPestaña().Text, cadena);

            tokens = @"\b(Grafica|Nombre|Continente|Poblacion|Pais|Saturacion|Bandera)\b";

            //Regex colores = new Regex(tokens);

            //MatchCollection mc = colores.Matches(getPestaña().Text);

            
            
            
            mc = Regex.Matches(getPestaña().Text, tokens);

            //int seleccion = getPestaña().SelectionStart;
            

            String digito = @"\d*";
            mcDigitos = Regex.Matches(getPestaña().Text, digito);

            String llaves = @"{|}";
            mcLlaves = Regex.Matches(getPestaña().Text, llaves);

            String puntoycoma = @";";
            mcPuntoycoma = Regex.Matches(getPestaña().Text, puntoycoma);

            int originalIndex = getPestaña().SelectionStart;
            int orignalLength = getPestaña().SelectionLength;

            Color originalColor = Color.Black;

            getPestaña().Focus();

            getPestaña().SelectionStart = 0;
            getPestaña().SelectionLength = getPestaña().Text.Length;
            getPestaña().SelectionColor = originalColor;

            foreach (Match item in mcCadenas)
            {
                getPestaña().SelectionStart = item.Index;
                getPestaña().SelectionLength = item.Length;
                getPestaña().SelectionColor = Color.Yellow;

            }

            foreach (Match item in mc)
            {
                getPestaña().SelectionStart = item.Index;
                getPestaña().SelectionLength = item.Length;
                getPestaña().SelectionColor = Color.Blue;
            }

            

            foreach (Match item in mcDigitos)
            {
                getPestaña().SelectionStart = item.Index;
                getPestaña().SelectionLength = item.Length;
                getPestaña().SelectionColor = Color.Green;
            }

            foreach (Match item in mcLlaves)
            {
                getPestaña().SelectionStart = item.Index;
                getPestaña().SelectionLength = item.Length;
                getPestaña().SelectionColor = Color.Red;
            }

            foreach (Match item in mcPuntoycoma)
            {
                getPestaña().SelectionStart = item.Index;
                getPestaña().SelectionLength = item.Length;
                getPestaña().SelectionColor = Color.Orange;
            }

            getPestaña().SelectionStart = originalIndex;
            getPestaña().SelectionLength = orignalLength;
            getPestaña().SelectionColor = originalColor;

            getPestaña().Focus();

        }

        public RichTextBox getPestaña()
        {
            RichTextBox texto = null;

            TabPage pagina = tcPestañas.SelectedTab;

            if (pagina != null)
            {
                texto = pagina.Controls[0] as RichTextBox;
            }
            else
            {
                MessageBox.Show("No hay pestañas activas");
            }

            return texto;
        }

        Analizador_Lexico lex = new Analizador_Lexico();
        public int contador2 = 0; 

        private void btnAnalizar_Click(object sender, EventArgs e)
        {
            contador2++;
            pbGrafica.Image = null;

            String entrada;
            try
            {

                if (getPestaña().Text != "")
                {

                    lex.setFila(1);
                    lex.setColumna(0);
                    lex.setGrafica();
                    entrada = getPestaña().Text;
                    LinkedList<Token> lTokens = lex.scanner(entrada);
                    lex.imprimir(lTokens);
                    lex.imprimirErrores(lTokens);
                    lex.llenarJerarquia(lTokens);
                    lex.imprimirGrafica();
                    contador = 0;
                    foreach(Token item in lTokens)
                    {
                        if(item.getTipoToken() != "DESCONOCIDO")
                        {
                            continue;
                        }
                        else
                        {
                            contador++;
                        }
                    }

                    if(contador == 0)
                    {
                        //Console.WriteLine("Hola que pasa porque no funcionas");
                     
                        FileInfo pathGrafo = new FileInfo("D:\\Desktop\\Imagen.txt");
                        ProcessStartInfo stInicio = new ProcessStartInfo("dot.exe", "-Tpng " + pathGrafo.DirectoryName + "\\Imagen.txt -o " + pathGrafo.DirectoryName + "\\Imagen" + contador2 + ".png");
                        Process proceso = Process.Start(stInicio);
                        proceso.WaitForExit();
                        pbGrafica.Image = Image.FromFile(pathGrafo.DirectoryName + "\\Imagen" + contador2 + ".png");
                        Console.WriteLine("-Tpng " + pathGrafo.DirectoryName + "\\Imagen.txt -o " + pathGrafo.DirectoryName + "\\Imagen" + contador2 + ".png");
                        Process procesoTokens = new Process();
                        procesoTokens.StartInfo.FileName = "Archivos\\Tokens.html";
                        procesoTokens.Start();

                        try
                        {
                            pbPais.Image = Image.FromFile(lex.seleccionPais().getBandera());
                        }
                        catch (Exception)
                        {
                            pbPais.Image = Image.FromFile("Archivos\\error.png");
                        }
                        Console.WriteLine(lex.seleccionPais().getBandera());
                        Console.WriteLine(lex.seleccionPais().getNombre());
                        Console.WriteLine(lex.seleccionPais().getPoblacion());
                        lblPaisSelecionado.Text = lex.seleccionPais().getNombre();
                        lblPoblacion.Text = Convert.ToString(lex.seleccionPais().getPoblacion());

                    }else
                    {
                        MessageBox.Show("Ha habido [" + contador + "] errores");
                        pbGrafica.Image = null;
                        pbPais.Image = null;
                        lblPaisSelecionado = null;
                        lblTexto = null;
                        Process proceso = new Process();
                        proceso.StartInfo.FileName = "Archivos\\Errores.html";
                        proceso.Start();
                    }
                   
                }
                else
                {
                    MessageBox.Show("No hay nada que analizar");
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void archivoToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void men1_DropDownOpened(object sender, EventArgs e)
        {
            
        }

        private void men1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void varMenu_ChangeUICues(object sender, UICuesEventArgs e)
        {
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            FileInfo pathGrafo = new FileInfo("D:\\Desktop\\Imagen.txt");
            ProcessStartInfo stInicio = new ProcessStartInfo("dot.exe", "-Tpdf " + pathGrafo.DirectoryName + "\\Imagen.txt -o " + pathGrafo.DirectoryName + "\\Imagen" + contador2 + ".pdf");
            Process proceso = Process.Start(stInicio);
            proceso.WaitForExit();
            Console.WriteLine("-Tpdf " + pathGrafo.DirectoryName + "\\Imagen.txt -o " + pathGrafo.DirectoryName + "\\Imagen" + contador2 + ".pdf");
            Process.Start(pathGrafo.DirectoryName + "\\Imagen" + contador2 + ".pdf");
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                String contenido = String.Empty;
                String extencion = String.Empty;

                OpenFileDialog file = new OpenFileDialog();

                file.Filter = "org Archivos (*.org)|*.org";
                file.FilterIndex = 2;
                file.RestoreDirectory = true;

                if(file.ShowDialog() == DialogResult.OK)
                {
                    extencion = file.SafeFileName;
                    extencion2 = file.FileName;

                    var lectura = file.OpenFile();

                    StreamReader leer = new StreamReader(lectura);

                    contenido = leer.ReadToEnd();

                    tabNuevo.Text = Path.GetFileNameWithoutExtension(extencion);

                    getPestaña().Text = contenido;
                }

            }catch(Exception)
            {
                MessageBox.Show("No hay ninguna pestaña Activa");
            }
        }
       

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                
                if(extencion2 != "")
                {
                    File.WriteAllText(extencion2, getPestaña().Text);
                }else
                {
                    SaveFileDialog guardar = new SaveFileDialog();

                    guardar.Filter = "org Files (*.org)|*.org";

                    if(guardar.ShowDialog() == DialogResult.OK)
                    {
                        extencion2 = guardar.FileName;
                        tabNuevo.Text = Path.GetFileNameWithoutExtension(extencion2);
                        File.WriteAllText(guardar.FileName, getPestaña().Text);
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                String extencion = String.Empty;
                SaveFileDialog sfdGuardar = new SaveFileDialog();

                sfdGuardar.Filter = "ly files (*.org)|*.org";

                if(sfdGuardar.ShowDialog() == DialogResult.OK)
                {
                    extencion = sfdGuardar.FileName;
                    Console.WriteLine(extencion);
                    tabNuevo.Text = Path.GetFileNameWithoutExtension(extencion);
                    File.WriteAllText(sfdGuardar.FileName, getPestaña().Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No hay ninguna pestaña abierta");
            }
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Acerda_De open = new Acerda_De();
            open.Visible = true;
        }
    }
}
