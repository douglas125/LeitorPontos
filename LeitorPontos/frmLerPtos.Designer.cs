namespace LeitorPontos
{
    partial class frmLerPtos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLerPtos));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbPic = new System.Windows.Forms.GroupBox();
            this.flowPan = new System.Windows.Forms.FlowLayoutPanel();
            this.picGraf = new System.Windows.Forms.PictureBox();
            this.ctxPicMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmdRemovePto = new System.Windows.Forms.ToolStripMenuItem();
            this.limparPontosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pontoDeReferênciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ponto1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ponto2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.referênciaDeRotaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maisZoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menosZoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.aceitarSugestãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.status = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblX = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblY = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdquire = new System.Windows.Forms.ToolStripButton();
            this.btnZoom = new System.Windows.Forms.ToolStripButton();
            this.btnOpenFile = new System.Windows.Forms.ToolStripButton();
            this.btnPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblPtoRef = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.p1x = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.p1y = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.p2x = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.p2y = new System.Windows.Forms.ToolStripTextBox();
            this.btnEscala = new System.Windows.Forms.ToolStripSplitButton();
            this.escalaCartesianaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.escalaLogarítmicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.escalaLoglogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAbout = new System.Windows.Forms.ToolStripButton();
            this.btnQuit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mainMenu.SuspendLayout();
            this.gbPic.SuspendLayout();
            this.flowPan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGraf)).BeginInit();
            this.ctxPicMenu.SuspendLayout();
            this.status.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(639, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "mainMenu";
            this.mainMenu.Visible = false;
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "&Arquivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.abrirToolStripMenuItem.Text = "&Abrir...";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(106, 6);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // gbPic
            // 
            this.gbPic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPic.Controls.Add(this.flowPan);
            this.gbPic.Location = new System.Drawing.Point(5, 42);
            this.gbPic.Name = "gbPic";
            this.gbPic.Size = new System.Drawing.Size(628, 216);
            this.gbPic.TabIndex = 1;
            this.gbPic.TabStop = false;
            this.gbPic.Text = "Gráfico";
            // 
            // flowPan
            // 
            this.flowPan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowPan.AutoScroll = true;
            this.flowPan.Controls.Add(this.picGraf);
            this.flowPan.Location = new System.Drawing.Point(6, 19);
            this.flowPan.Name = "flowPan";
            this.flowPan.Size = new System.Drawing.Size(616, 191);
            this.flowPan.TabIndex = 0;
            // 
            // picGraf
            // 
            this.picGraf.ContextMenuStrip = this.ctxPicMenu;
            this.picGraf.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picGraf.Location = new System.Drawing.Point(3, 3);
            this.picGraf.Name = "picGraf";
            this.picGraf.Size = new System.Drawing.Size(188, 110);
            this.picGraf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picGraf.TabIndex = 0;
            this.picGraf.TabStop = false;
            this.picGraf.Click += new System.EventHandler(this.picGraf_Click);
            this.picGraf.Paint += new System.Windows.Forms.PaintEventHandler(this.picGraf_Paint);
            this.picGraf.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picGraf_MouseDown);
            this.picGraf.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picGraf_MouseMove);
            this.picGraf.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picGraf_MouseUp);
            // 
            // ctxPicMenu
            // 
            this.ctxPicMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdRemovePto,
            this.limparPontosToolStripMenuItem,
            this.pontoDeReferênciaToolStripMenuItem,
            this.zoomToolStripMenuItem,
            this.toolStripMenuItem3,
            this.aceitarSugestãoToolStripMenuItem});
            this.ctxPicMenu.Name = "ctxPicMenu";
            this.ctxPicMenu.Size = new System.Drawing.Size(206, 120);
            // 
            // cmdRemovePto
            // 
            this.cmdRemovePto.Name = "cmdRemovePto";
            this.cmdRemovePto.Size = new System.Drawing.Size(205, 22);
            this.cmdRemovePto.Text = "Remover ponto";
            this.cmdRemovePto.Click += new System.EventHandler(this.cmdRemovePto_Click);
            // 
            // limparPontosToolStripMenuItem
            // 
            this.limparPontosToolStripMenuItem.Name = "limparPontosToolStripMenuItem";
            this.limparPontosToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.limparPontosToolStripMenuItem.Text = "Limpar pontos";
            this.limparPontosToolStripMenuItem.Click += new System.EventHandler(this.limparPontosToolStripMenuItem_Click);
            // 
            // pontoDeReferênciaToolStripMenuItem
            // 
            this.pontoDeReferênciaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ponto1ToolStripMenuItem,
            this.ponto2ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.referênciaDeRotaçãoToolStripMenuItem});
            this.pontoDeReferênciaToolStripMenuItem.Name = "pontoDeReferênciaToolStripMenuItem";
            this.pontoDeReferênciaToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.pontoDeReferênciaToolStripMenuItem.Text = "Ponto de referência";
            // 
            // ponto1ToolStripMenuItem
            // 
            this.ponto1ToolStripMenuItem.Name = "ponto1ToolStripMenuItem";
            this.ponto1ToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.ponto1ToolStripMenuItem.Text = "Posicionar ponto 1 aqui";
            this.ponto1ToolStripMenuItem.Click += new System.EventHandler(this.ponto1ToolStripMenuItem_Click);
            // 
            // ponto2ToolStripMenuItem
            // 
            this.ponto2ToolStripMenuItem.Name = "ponto2ToolStripMenuItem";
            this.ponto2ToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.ponto2ToolStripMenuItem.Text = "Posicionar ponto 2 aqui";
            this.ponto2ToolStripMenuItem.Click += new System.EventHandler(this.ponto2ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(240, 6);
            this.toolStripMenuItem2.Visible = false;
            // 
            // referênciaDeRotaçãoToolStripMenuItem
            // 
            this.referênciaDeRotaçãoToolStripMenuItem.Name = "referênciaDeRotaçãoToolStripMenuItem";
            this.referênciaDeRotaçãoToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.referênciaDeRotaçãoToolStripMenuItem.Text = "Posicionar referência de rotação";
            this.referênciaDeRotaçãoToolStripMenuItem.Visible = false;
            this.referênciaDeRotaçãoToolStripMenuItem.Click += new System.EventHandler(this.referênciaDeRotaçãoToolStripMenuItem_Click);
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maisZoomToolStripMenuItem,
            this.menosZoomToolStripMenuItem});
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.zoomToolStripMenuItem.Text = "Zoom";
            // 
            // maisZoomToolStripMenuItem
            // 
            this.maisZoomToolStripMenuItem.Name = "maisZoomToolStripMenuItem";
            this.maisZoomToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.maisZoomToolStripMenuItem.Text = "Mais zoom";
            this.maisZoomToolStripMenuItem.Click += new System.EventHandler(this.maisZoomToolStripMenuItem_Click);
            // 
            // menosZoomToolStripMenuItem
            // 
            this.menosZoomToolStripMenuItem.Name = "menosZoomToolStripMenuItem";
            this.menosZoomToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.menosZoomToolStripMenuItem.Text = "Menos zoom";
            this.menosZoomToolStripMenuItem.Click += new System.EventHandler(this.menosZoomToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(202, 6);
            // 
            // aceitarSugestãoToolStripMenuItem
            // 
            this.aceitarSugestãoToolStripMenuItem.Enabled = false;
            this.aceitarSugestãoToolStripMenuItem.Name = "aceitarSugestãoToolStripMenuItem";
            this.aceitarSugestãoToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.aceitarSugestãoToolStripMenuItem.Text = "&Aceitar pontos sugeridos";
            this.aceitarSugestãoToolStripMenuItem.Click += new System.EventHandler(this.aceitarSugestãoToolStripMenuItem_Click);
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblX,
            this.toolStripStatusLabel3,
            this.lblY});
            this.status.Location = new System.Drawing.Point(0, 261);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(639, 22);
            this.status.TabIndex = 2;
            this.status.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(17, 17);
            this.toolStripStatusLabel1.Text = "X:";
            // 
            // lblX
            // 
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(13, 17);
            this.lblX.Text = "0";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(17, 17);
            this.toolStripStatusLabel3.Text = "Y:";
            // 
            // lblY
            // 
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(13, 17);
            this.lblY.Text = "0";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdquire,
            this.btnZoom,
            this.btnOpenFile,
            this.btnPaste,
            this.toolStripSeparator1,
            this.lblPtoRef,
            this.toolStripLabel2,
            this.p1x,
            this.toolStripLabel3,
            this.p1y,
            this.toolStripLabel4,
            this.p2x,
            this.toolStripLabel5,
            this.p2y,
            this.btnEscala,
            this.toolStripSeparator2,
            this.btnAbout,
            this.btnQuit,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(639, 39);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAdquire
            // 
            this.btnAdquire.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdquire.Image = ((System.Drawing.Image)(resources.GetObject("btnAdquire.Image")));
            this.btnAdquire.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAdquire.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdquire.Name = "btnAdquire";
            this.btnAdquire.Size = new System.Drawing.Size(36, 36);
            this.btnAdquire.Text = "Adquirir pontos. Clique com o botão esquerdo para inserir ou mover pontos.";
            this.btnAdquire.Visible = false;
            this.btnAdquire.Click += new System.EventHandler(this.btnAdquire_Click);
            // 
            // btnZoom
            // 
            this.btnZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoom.Image = ((System.Drawing.Image)(resources.GetObject("btnZoom.Image")));
            this.btnZoom.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoom.Name = "btnZoom";
            this.btnZoom.Size = new System.Drawing.Size(36, 36);
            this.btnZoom.ToolTipText = "Modo de zoom. Botão esquerdo aumenta o zoom; botão direito diminui";
            this.btnZoom.Visible = false;
            this.btnZoom.Click += new System.EventHandler(this.btnZoom_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpenFile.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenFile.Image")));
            this.btnOpenFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(28, 36);
            this.btnOpenFile.ToolTipText = "Carregar imagem do arquivo";
            this.btnOpenFile.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPaste.Image = ((System.Drawing.Image)(resources.GetObject("btnPaste.Image")));
            this.btnPaste.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(36, 36);
            this.btnPaste.Text = "Copiar da área de transferência (Ctrl-V)";
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // lblPtoRef
            // 
            this.lblPtoRef.Name = "lblPtoRef";
            this.lblPtoRef.Size = new System.Drawing.Size(118, 36);
            this.lblPtoRef.Text = "Pontos de referência:";
            this.lblPtoRef.ToolTipText = "Inserir as coordenadas dos pontos de referência";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.ForeColor = System.Drawing.Color.Red;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(53, 36);
            this.toolStripLabel2.Text = "Ponto 1:";
            this.toolStripLabel2.ToolTipText = "Inserir as coordenadas dos pontos de referência";
            // 
            // p1x
            // 
            this.p1x.Name = "p1x";
            this.p1x.Size = new System.Drawing.Size(36, 39);
            this.p1x.Text = "0";
            this.p1x.ToolTipText = "Inserir as coordenadas dos pontos de referência";
            this.p1x.Leave += new System.EventHandler(this.p1x_Leave);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(10, 36);
            this.toolStripLabel3.Text = ",";
            // 
            // p1y
            // 
            this.p1y.Name = "p1y";
            this.p1y.Size = new System.Drawing.Size(36, 39);
            this.p1y.Text = "0";
            this.p1y.ToolTipText = "Inserir as coordenadas dos pontos de referência";
            this.p1y.Leave += new System.EventHandler(this.p1x_Leave);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(53, 36);
            this.toolStripLabel4.Text = "Ponto 2:";
            this.toolStripLabel4.ToolTipText = "Inserir as coordenadas dos pontos de referência";
            // 
            // p2x
            // 
            this.p2x.Name = "p2x";
            this.p2x.Size = new System.Drawing.Size(36, 39);
            this.p2x.Text = "10";
            this.p2x.ToolTipText = "Inserir as coordenadas dos pontos de referência";
            this.p2x.Leave += new System.EventHandler(this.p1x_Leave);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(10, 36);
            this.toolStripLabel5.Text = ",";
            // 
            // p2y
            // 
            this.p2y.Name = "p2y";
            this.p2y.Size = new System.Drawing.Size(36, 39);
            this.p2y.Text = "10";
            this.p2y.ToolTipText = "Inserir as coordenadas dos pontos de referência";
            this.p2y.Leave += new System.EventHandler(this.p1x_Leave);
            // 
            // btnEscala
            // 
            this.btnEscala.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEscala.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.escalaCartesianaToolStripMenuItem,
            this.escalaLogarítmicaToolStripMenuItem,
            this.escalaLoglogToolStripMenuItem});
            this.btnEscala.Image = ((System.Drawing.Image)(resources.GetObject("btnEscala.Image")));
            this.btnEscala.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEscala.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEscala.Name = "btnEscala";
            this.btnEscala.Size = new System.Drawing.Size(40, 36);
            this.btnEscala.ToolTipText = "Selecionar escala";
            this.btnEscala.ButtonClick += new System.EventHandler(this.btnEscala_ButtonClick);
            // 
            // escalaCartesianaToolStripMenuItem
            // 
            this.escalaCartesianaToolStripMenuItem.Checked = true;
            this.escalaCartesianaToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.escalaCartesianaToolStripMenuItem.Name = "escalaCartesianaToolStripMenuItem";
            this.escalaCartesianaToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.escalaCartesianaToolStripMenuItem.Text = "Escala cartesiana";
            this.escalaCartesianaToolStripMenuItem.Click += new System.EventHandler(this.escalaToolStripMenuItem_Click);
            // 
            // escalaLogarítmicaToolStripMenuItem
            // 
            this.escalaLogarítmicaToolStripMenuItem.Name = "escalaLogarítmicaToolStripMenuItem";
            this.escalaLogarítmicaToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.escalaLogarítmicaToolStripMenuItem.Text = "Escala logarítmica em X";
            this.escalaLogarítmicaToolStripMenuItem.Click += new System.EventHandler(this.escalaToolStripMenuItem_Click);
            // 
            // escalaLoglogToolStripMenuItem
            // 
            this.escalaLoglogToolStripMenuItem.Name = "escalaLoglogToolStripMenuItem";
            this.escalaLoglogToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.escalaLoglogToolStripMenuItem.Text = "Escala log-log";
            this.escalaLoglogToolStripMenuItem.Click += new System.EventHandler(this.escalaToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // btnAbout
            // 
            this.btnAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAbout.Image = ((System.Drawing.Image)(resources.GetObject("btnAbout.Image")));
            this.btnAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(23, 36);
            this.btnAbout.Text = "Informações sobre o programa";
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnQuit.Image = ((System.Drawing.Image)(resources.GetObject("btnQuit.Image")));
            this.btnQuit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(28, 36);
            this.btnQuit.Text = "Sair do Leitor de Pontos";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // frmLerPtos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 283);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.status);
            this.Controls.Add(this.gbPic);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Name = "frmLerPtos";
            this.Text = "Leitor de Pontos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLerPtos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLerPtos_KeyDown);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.gbPic.ResumeLayout(false);
            this.flowPan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picGraf)).EndInit();
            this.ctxPicMenu.ResumeLayout(false);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbPic;
        private System.Windows.Forms.FlowLayoutPanel flowPan;
        private System.Windows.Forms.PictureBox picGraf;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblX;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblY;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnZoom;
        private System.Windows.Forms.ToolStripButton btnAdquire;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ctxPicMenu;
        private System.Windows.Forms.ToolStripMenuItem limparPontosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pontoDeReferênciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ponto1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ponto2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maisZoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menosZoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel lblPtoRef;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox p1x;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox p1y;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripTextBox p2x;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripTextBox p2y;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmdRemovePto;
        private System.Windows.Forms.ToolStripButton btnOpenFile;
        private System.Windows.Forms.ToolStripButton btnQuit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnAbout;
        private System.Windows.Forms.ToolStripButton btnPaste;
        private System.Windows.Forms.ToolStripSplitButton btnEscala;
        private System.Windows.Forms.ToolStripMenuItem escalaCartesianaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem escalaLogarítmicaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem escalaLoglogToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem referênciaDeRotaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem aceitarSugestãoToolStripMenuItem;
    }
}

