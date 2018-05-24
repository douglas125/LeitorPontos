using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LeitorPontos
{
    public partial class frmLerPtos : Form
    {
        public frmLerPtos()
        {
            InitializeComponent();
        }

        #region Abertura de arquivos e leitura do clipboard
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPtos.Hide();
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Figuras|*.bmp; *.jpg; *.gif; *.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Bitmap bmp = new Bitmap(ofd.FileName);
                    picGraf.Image = bmp;
                    picGraf.Width = bmp.Width;
                    picGraf.Height = bmp.Height;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            frmPtos.Show();
        }
        private void btnPaste_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Bitmap))
            {
                Bitmap bmp = (Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap);
                picGraf.Image = bmp;
                picGraf.Width = bmp.Width;
                picGraf.Height = bmp.Height;
            }
        }
        private void frmLerPtos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
            {
                btnPaste_Click(sender, e);
            }
        }
        #endregion

        #region Controles com o mouse

        private enum MouseMode
        {
            /// <summary>Mouse used to zoom</summary>
            Zoom,
            /// <summary>Mouse used to pick points</summary>
            PickPoint
        }

        /// <summary>Current mouse mode</summary>
        private MouseMode CurMode = MouseMode.PickPoint;
        
        private void btnZoom_Click(object sender, EventArgs e)
        {
            picGraf.Cursor = Cursors.SizeAll;
            CurMode = MouseMode.Zoom;
        }
        private void btnAdquire_Click(object sender, EventArgs e)
        {
            picGraf.Cursor = Cursors.Cross;
            CurMode = MouseMode.PickPoint;
        }

        private PointF curMousePos = new PointF();
        private void picGraf_MouseMove(object sender, MouseEventArgs e)
        {
            float invW = 1 / (float)picGraf.Width;
            float invH = 1 / (float)picGraf.Height;
            float RelPickSizeX = (float)PickSize * invW;
            float RelPickSizeY = (float)PickSize * invH;

            curMousePos.X = (float)e.X * invW; curMousePos.Y = (float)e.Y * invH;
            PointF mousePosGlobal = ConvToGlobal(curMousePos);
            lblX.Text = mousePosGlobal.X.ToString(); lblY.Text = mousePosGlobal.Y.ToString();

            //User is dragging point
            if (DraggingPoint && SelPoint>=0)
            {
                MarkedCurve.RemoveAt(SelPoint);
                MarkedCurve.Insert(SelPoint, curMousePos);

                AtualizaPtosTabela();
            }
            else
            {
                //User is not dragging, try to know closest point
                int selPoint0 = SelPoint;
                SelPoint = -1;

                for (int i = 0; i < MarkedCurve.Count; i++)
                {
                    if (MarkedCurve[i].X - RelPickSizeX <= curMousePos.X && curMousePos.X <= MarkedCurve[i].X + RelPickSizeX
                        && MarkedCurve[i].Y - RelPickSizeY <= curMousePos.Y && curMousePos.Y <= MarkedCurve[i].Y + RelPickSizeY)
                    {
                        SelPoint = i;
                        i = MarkedCurve.Count;
                    }
                }

                //Redesenha se mudou a selecao
                if (selPoint0 != SelPoint) picGraf.Refresh();
                //Só habilita p remover ponto atual se houver ponto selecionado
                cmdRemovePto.Enabled = SelPoint >= 0;
            }

        }


        /// <summary>Clicked point at MouseDown</summary>
        private PointF P0 = new Point(0, 0);

        /// <summary>List of clicked points</summary>
        private List<PointF> MarkedCurve = new List<PointF>();
        /// <summary>List of predicted points</summary>
        private List<PointF> PredictedCurve;

        /// <summary>Selected curve point</summary>
        private int SelPoint = -1;
        /// <summary>Pick size to move points</summary>
        private int PickSize = 5;
        /// <summary>Guess point size</summary>
        private int GuessSize = 3;
        /// <summary>Is user dragging a point?</summary>
        private bool DraggingPoint = false;

        /// <summary>Reference points</summary>
        PointF p1 = new PointF(0.1f, 0.9f), p2 = new PointF(0.9f, 0.1f);
        /// <summary>Reference point for rotation</summary>
        PointF pRot = new PointF(0.1f, 0.9f);

        private void picGraf_MouseDown(object sender, MouseEventArgs e)
        {
            if (CurMode == MouseMode.Zoom)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (picGraf.Width < 5000 && picGraf.Height < 5000)
                    {
                        picGraf.Width *= 2;
                        picGraf.Height *= 2;
                    }

                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (picGraf.Width > 8 && picGraf.Height > 8)
                    {
                        picGraf.Width /= 2;
                        picGraf.Height /= 2;
                    }
                }
            }

            else if (CurMode == MouseMode.PickPoint && e.Button==MouseButtons.Left)
            {
                if (SelPoint < 0)
                {
                    P0.X = e.X; P0.Y = e.Y;
                    PointF P = new PointF((float)e.X / (float)picGraf.Width, (float)e.Y / (float)picGraf.Height);

                    MarkedCurve.Add(P);
                    AtualizaPtosTabela();
                }
                else DraggingPoint = true;
            }

            else if (e.Button == MouseButtons.Middle)
            {
                
            }
        }

        private void picGraf_MouseUp(object sender, MouseEventArgs e)
        {
            if (CurMode == MouseMode.PickPoint && e.Button == MouseButtons.Left)
            {
                DraggingPoint = false;
            }
        }

        private void picGraf_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Green, 3);
            Pen pen2 = new Pen(Color.Yellow, 1);

            #region Curva interpolada
            if (coefsLocal!=null && coefsLocal.Length > 0 && MarkedCurve.Count>0)
            {
                float minXMarked = MarkedCurve[0].X;
                float maxXMarked = MarkedCurve[0].X;
                for (int i = 1; i < MarkedCurve.Count; i++)
                {
                    if (minXMarked > MarkedCurve[i].X) minXMarked = MarkedCurve[i].X;
                    if (maxXMarked < MarkedCurve[i].X) maxXMarked = MarkedCurve[i].X;
                }

                PointF[] InterpPts = new PointF[100];
                for (int i = 0; i < 100; i++)
                {
                    float xx = mix(minXMarked, maxXMarked, 0.01f * (float)i);
                    float yy = (float)coefsLocal[0];

                    double val = xx;
                    for (int k = 1; k < coefsLocal.Length; k++)
                    {
                        yy += (float)(val * coefsLocal[k]);
                        val *= xx;
                    }

                    InterpPts[i] = new PointF(xx*(float)picGraf.Width, yy*(float)picGraf.Height);
                }

                e.Graphics.DrawLines(Pens.DarkOrange, InterpPts);
            }
            #endregion

            #region Retas e pontos
            //Pontos previstos
            if (PredictedCurve != null)
            {
                for (int i = 0; i < PredictedCurve.Count; i++)
                {
                    Brush b = Brushes.LightSeaGreen;
                    e.Graphics.FillRectangle(b, PredictedCurve[i].X * picGraf.Width - GuessSize, PredictedCurve[i].Y * picGraf.Height - GuessSize, 2 * GuessSize, 2 * GuessSize);
                }
            }

            //Retas
            for (int i = 1; i < MarkedCurve.Count; i++)
            {
                e.Graphics.DrawLine(pen, MarkedCurve[i - 1].X * picGraf.Width, MarkedCurve[i - 1].Y * picGraf.Height, MarkedCurve[i].X * picGraf.Width, MarkedCurve[i].Y * picGraf.Height);
                e.Graphics.DrawLine(pen2, MarkedCurve[i - 1].X * picGraf.Width, MarkedCurve[i - 1].Y * picGraf.Height, MarkedCurve[i].X * picGraf.Width, MarkedCurve[i].Y * picGraf.Height);
            }
            
            //Pontos
            for (int i = 0; i < MarkedCurve.Count; i++)
            {
                Brush b;
                if (SelPoint == i) b = Brushes.Maroon;
                else b = Brushes.Blue;

                e.Graphics.FillRectangle(b, MarkedCurve[i].X * picGraf.Width - PickSize, MarkedCurve[i].Y * picGraf.Height - PickSize, 2 * PickSize, 2 * PickSize);
            }
            #endregion

            #region Pontos de referencia e eixo rotacionado
            //Pontos
            Pen penRed = new Pen(Color.Red, 1);
            Pen penGreen = new Pen(Color.Green, 1);

            e.Graphics.DrawLine(penRed, p1.X * picGraf.Width - PickSize, p1.Y * picGraf.Height, p1.X * picGraf.Width + PickSize, p1.Y * picGraf.Height);
            e.Graphics.DrawLine(penRed, p1.X * picGraf.Width, p1.Y * picGraf.Height - PickSize, p1.X * picGraf.Width, p1.Y * picGraf.Height + PickSize);
            e.Graphics.DrawLine(penGreen, p2.X * picGraf.Width - PickSize, p2.Y * picGraf.Height, p2.X * picGraf.Width + PickSize, p2.Y * picGraf.Height);
            e.Graphics.DrawLine(penGreen, p2.X * picGraf.Width, p2.Y * picGraf.Height - PickSize, p2.X * picGraf.Width, p2.Y * picGraf.Height + PickSize);
            
            //String dos pontos de referencia
            Font refFont = new Font("Arial", 8, FontStyle.Bold);
            e.Graphics.DrawString("[" + p1x.Text + ";" + p1y.Text + "]", refFont, Brushes.Red, p1.X * picGraf.Width + PickSize, p1.Y * picGraf.Height + PickSize);
            e.Graphics.DrawString("[" + p2x.Text + ";" + p2y.Text + "]", refFont, Brushes.Green, p2.X * picGraf.Width + PickSize, p2.Y * picGraf.Height + PickSize);

            //Referencia de rotacao
            if (pRot.X != p1.X || pRot.Y != p1.Y)
            {
                Pen penRot = new Pen(Color.LightSalmon);
                e.Graphics.DrawLine(penRot, pRot.X * picGraf.Width - PickSize, pRot.Y * picGraf.Height, pRot.X * picGraf.Width + PickSize, pRot.Y * picGraf.Height);
                e.Graphics.DrawLine(penRot, pRot.X * picGraf.Width, pRot.Y * picGraf.Height - PickSize, pRot.X * picGraf.Width, pRot.Y * picGraf.Height + PickSize);
                e.Graphics.DrawLine(penRot, pRot.X * picGraf.Width, pRot.Y * picGraf.Height, p1.X * picGraf.Width, p1.Y * picGraf.Height);

                PointF T = new PointF((pRot.X - p1.X) * picGraf.Width, (pRot.Y - p1.Y) * picGraf.Height);
                PointF N = new PointF(T.Y, -T.X);

                e.Graphics.DrawLine(penRot, p1.X * picGraf.Width, p1.Y * picGraf.Height,
                    N.X + p1.X * picGraf.Width, N.Y + p1.Y * picGraf.Height);

            }

            #endregion
        }


        #endregion


        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>Linear interpolation</summary>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        /// <param name="t">Interpolation parameter in the interval [0,1]</param>
        private float mix(float min, float max, float t)
        {
            return min + (max - min) * t;
        }

        /// <summary>Linear interpolation</summary>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        /// <param name="t">Interpolation parameter in the interval [0,1]</param>
        private double mix(double min, double max, float t)
        {
            return min + (max - min) * t;
        }

        #region COntext menu
        private void maisZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (picGraf.Width < 5000 && picGraf.Height < 5000)
            {
                picGraf.Width *= 2;
                picGraf.Height *= 2;
            }
        }

        private void menosZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (picGraf.Width > 8 && picGraf.Height > 8)
            {
                picGraf.Width /= 2;
                picGraf.Height /= 2;
            }
        }
        void picGraf_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta>0) maisZoomToolStripMenuItem_Click(sender, new EventArgs());
            else menosZoomToolStripMenuItem_Click(sender, new EventArgs());
        }
        private void limparPontosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarkedCurve.Clear();
            AtualizaPtosTabela();
        }
        private void ponto1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            p1.X = curMousePos.X;
            p1.Y = curMousePos.Y;
            pRot.X = p1.X;
            pRot.Y = p1.Y;
            picGraf.Refresh();
            AtualizaPtosTabela();
        }
        private void ponto2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            p2.X = curMousePos.X;
            p2.Y = curMousePos.Y;
            picGraf.Refresh();
            AtualizaPtosTabela();
        }
        private void referênciaDeRotaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pRot.X = curMousePos.X;
            pRot.Y = curMousePos.Y;
            picGraf.Refresh();
            AtualizaPtosTabela();
        }

        #endregion

        #region Coordinate transformation

        /// <summary>Converts a point to local coordinates as per what the user wants</summary>
        /// <param name="src">Source point in relative coordinates</param>
        private PointF ConvToGlobal(PointF src)
        {
            float a, b, c, d;
            float.TryParse(p1x.Text, out a);
            float.TryParse(p1y.Text, out b);
            float.TryParse(p2x.Text, out c);
            float.TryParse(p2y.Text, out d);

            PointF p1G = new PointF(a, b);
            PointF p2G = new PointF(c, d);

            //Rotation correction
            if (pRot.X != p1.X || pRot.Y != p1.Y)
            {
                PointF T = new PointF(pRot.X - p1.X, pRot.Y - p1.Y);
                float invNorma = (float)(1/Math.Sqrt(T.X * T.X + T.Y * T.Y));
                T.X *= invNorma; T.Y *= invNorma;

                PointF N = new PointF(p2.X, p2.Y);
                N.X = p2.X - p1.X - T.X * ((p2.X - p1.X) * T.X + (p2.Y - p1.Y) * T.Y);
                N.Y = p2.Y - p1.Y - T.Y * ((p2.X - p1.X) * T.X + (p2.Y - p1.Y) * T.Y);

                float temp = (src.X - p1.X);
                src.X = T.X * temp + T.Y * (src.Y - p1.Y);
                src.Y = N.X * temp + N.Y * (src.Y - p1.Y);
                src.X += p1.X;
                src.Y += p2.X;
            }

            if (escalaCartesianaToolStripMenuItem.Checked)
            {
                float lenX = (p1G.X - p2G.X) / (p1.X - p2.X);
                float minX = p1G.X - lenX * p1.X;
                float maxX = lenX + minX;

                float lenY = (p1G.Y - p2G.Y) / (p1.Y - p2.Y);
                float minY = p1G.Y - lenY * p1.Y;
                float maxY = lenY + minY;

                return new PointF(mix(minX, maxX, src.X), mix(minY, maxY, src.Y));
            }
            else if (escalaLogarítmicaToolStripMenuItem.Checked)
            {
                double lenX = (Math.Log10(p1G.X) - Math.Log10(p2G.X)) / (p1.X - p2.X);
                double minX = Math.Log10(p1G.X) - lenX * p1.X;
                double maxX = lenX + minX;

                double logx = mix(minX, maxX, src.X);
                float pontoX = (float)Math.Pow(10, logx);

                float lenY = (p1G.Y - p2G.Y) / (p1.Y - p2.Y);
                float minY = p1G.Y - lenY * p1.Y;
                float maxY = lenY + minY;

                return new PointF(pontoX, mix(minY, maxY, src.Y));
            }
            else if (escalaLoglogToolStripMenuItem.Checked)
            {
                double lenX = (Math.Log10(p1G.X) - Math.Log10(p2G.X)) / (p1.X - p2.X);
                double minX = Math.Log10(p1G.X) - lenX * p1.X;
                double maxX = lenX + minX;

                double logx = mix(minX, maxX, src.X);
                float pontoX = (float)Math.Pow(10, logx);

                double lenY = (Math.Log10(p1G.Y) - Math.Log10(p2G.Y)) / (p1.Y - p2.Y);
                double minY = Math.Log10(p1G.Y) - lenY * p1.Y;
                double maxY = lenY + minY;

                double logy = mix(minY, maxY, src.Y);
                float pontoY = (float)Math.Pow(10, logy);

                return new PointF(pontoX, pontoY);
            }
            else return new PointF();
        }


        private void cmdRemovePto_Click(object sender, EventArgs e)
        {
            if (SelPoint >= 0) MarkedCurve.RemoveAt(SelPoint);
            AtualizaPtosTabela();
            picGraf.Refresh();
        }
        #endregion


        private void p1x_Leave(object sender, EventArgs e)
        {
            float num;
            ToolStripTextBox txt = (ToolStripTextBox)sender;
            float.TryParse(txt.Text, out num);
            txt.Text = num.ToString();
            AtualizaPtosTabela();

            picGraf.Refresh();
        }

        #region Banco de pontos
        DataTable tblPtos;
        frmPontos frmPtos;
        private void frmLerPtos_Load(object sender, EventArgs e)
        {
            string[] Campos = new string[] { "dblPonto", "dblX", "dblY" };
            tblPtos = XMLFuncs.CreateNewTable("TblPtos", Campos);
            frmPtos = new frmPontos();

            frmPtos.gridPtos.DataSource = tblPtos;
            frmPtos.gridPtos.Columns["Count"].Visible = false;
            frmPtos.gridPtos.Columns["dblPonto"].Width = 50;
            frmPtos.gridPtos.Columns["dblPonto"].HeaderText = "Ponto";
            frmPtos.gridPtos.Columns["dblX"].Width = 80;
            frmPtos.gridPtos.Columns["dblX"].HeaderText = "X";
            frmPtos.gridPtos.Columns["dblY"].Width = 80;
            frmPtos.gridPtos.Columns["dblY"].HeaderText = "Y";
            frmPtos.Show();

            picGraf.MouseWheel += new MouseEventHandler(picGraf_MouseWheel);
            flowPan.MouseWheel += new MouseEventHandler(picGraf_MouseWheel);
            this.MouseWheel += new MouseEventHandler(picGraf_MouseWheel);
        }

        double[] coefs;
        double[] coefsLocal;
        private void AtualizaPtosTabela()
        {
            tblPtos.Rows.Clear();
            int i = 0;

            //Interpolação da equação
            int Ordem = 4;
            LinearAlgebra.Matrix M = new LinearAlgebra.Matrix(MarkedCurve.Count, Ordem);
            LinearAlgebra.Matrix MLocal = new LinearAlgebra.Matrix(MarkedCurve.Count, Ordem);
            double[] y = new double[MarkedCurve.Count];
            double[] yLocal = new double[MarkedCurve.Count];

            foreach (PointF p in MarkedCurve)
            {
                PointF pG = ConvToGlobal(p);
                DataRow r = tblPtos.NewRow();

                r["dblPonto"] = (1+i).ToString();
                r["dblX"] = pG.X.ToString();
                r["dblY"] = pG.Y.ToString();
                tblPtos.Rows.Add(r);

                //Equação
                y[i] = pG.Y;
                yLocal[i] = p.Y;
                double val = 1;
                double valLocal = 1;
                for (int k = 0; k < Ordem; k++)
                {
                    M[i, k] = val;
                    val *= pG.X;

                    MLocal[i, k] = valLocal;
                    valLocal *= p.X;
                }


                i++;
            }

            //4 pontos p identificar ax³+bx²+cx+d=y(x)
            if (MarkedCurve.Count >= 4)
            {
                try
                {
                    coefs = M.IdentifyParameters(y);
                    try
                    {
                        coefsLocal = MLocal.IdentifyParameters(yLocal);
                    }
                    catch {
                    }

                    string s = ((float)coefs[3]).ToString() + "x³";

                    if (coefs[2] >= 0) s += "+";
                    s += ((float)coefs[2]).ToString() + "x²";

                    if (coefs[1] >= 0) s += "+";
                    s += ((float)coefs[1]).ToString() + "x";

                    if (coefs[0] >= 0) s += "+";
                    s += ((float)coefs[0]).ToString();

                    frmPtos.lblEq.Text = s;
                }
                catch
                {
                }
            }
            else
            {
                frmPtos.lblEq.Text = "";
                coefs = null;
                coefsLocal = null;
            }
            //Tenta adivinhar a curva
            if (MarkedCurve.Count > 3)
            {
                try
                {
                    PredictedCurve = PointPredictor.PreviewNextPoints(MarkedCurve, PickSize, picGraf);
                }
                catch
                {
                    PredictedCurve = null;
                }
            }
            else PredictedCurve = null;
            aceitarSugestãoToolStripMenuItem.Enabled = (PredictedCurve != null);

            frmPtos.lblEq.Refresh();
            picGraf.Refresh();
        }

        private void aceitarSugestãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PredictedCurve == null) return;
            MarkedCurve.Clear();
            foreach (PointF p in PredictedCurve)
            {
                MarkedCurve.Add(new PointF(p.X, p.Y));
            }
            AtualizaPtosTabela();
            aceitarSugestãoToolStripMenuItem.Enabled = false;
        }
        #endregion

        private void btnQuit_Click(object sender, EventArgs e)
        {
            frmPtos.Saindo = true;
            Application.Exit();
        }

        frmAbout frmSobre;
        private void btnAbout_Click(object sender, EventArgs e)
        {
            if (frmSobre == null || frmSobre.IsDisposed)
                frmSobre = new frmAbout();
         
            frmSobre.ShowDialog();
        }

        #region Controle de escalas
        private void btnEscala_ButtonClick(object sender, EventArgs e)
        {
            btnEscala.ShowDropDown();
        }

        private void escalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            escalaCartesianaToolStripMenuItem.Checked = false;
            escalaLogarítmicaToolStripMenuItem.Checked = false;
            escalaLoglogToolStripMenuItem.Checked = false;

            ToolStripMenuItem t = (ToolStripMenuItem)sender;
            t.Checked = true;

            AtualizaPtosTabela();
        }
        #endregion

        private void picGraf_Click(object sender, EventArgs e)
        {

        }





    }
}











