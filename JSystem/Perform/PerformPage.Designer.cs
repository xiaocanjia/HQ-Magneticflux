namespace JSystem.Perform
{
    partial class PerformPage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uiTableLayoutPanel1 = new Sunny.UI.UITableLayoutPanel();
            this.uiTableLayoutPanel2 = new Sunny.UI.UITableLayoutPanel();
            this.Btn_CloseBuzzer = new Sunny.UI.UISymbolButton();
            this.Btn_Stop = new Sunny.UI.UISymbolButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Btn_Start = new Sunny.UI.UISymbolButton();
            this.Btn_Pause = new Sunny.UI.UISymbolButton();
            this.Btn_Reset = new Sunny.UI.UISymbolButton();
            this.Panel_Statistics = new Sunny.UI.UITitlePanel();
            this.Btn_Clear = new Sunny.UI.UIButton();
            this.Lb_Total = new Sunny.UI.UILabel();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.Lb_UPH = new Sunny.UI.UILabel();
            this.Lb_CT = new Sunny.UI.UILabel();
            this.Lb_Fail = new Sunny.UI.UILabel();
            this.Lb_Pass = new Sunny.UI.UILabel();
            this.Lb_OK_Pct = new Sunny.UI.UILabel();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.StatusPanel = new JSystem.Perform.StatusPanel();
            this.runningMsgPanel = new JSystem.Perform.LogPanel();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.uiTabControl1 = new Sunny.UI.UITabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DGV_Result = new Sunny.UI.UIDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.磁通量上限 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiTableLayoutPanel1.SuspendLayout();
            this.uiTableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Panel_Statistics.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.uiPanel1.SuspendLayout();
            this.uiTabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Result)).BeginInit();
            this.SuspendLayout();
            // 
            // uiTableLayoutPanel1
            // 
            this.uiTableLayoutPanel1.ColumnCount = 2;
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.uiTableLayoutPanel1.Controls.Add(this.uiTableLayoutPanel2, 1, 0);
            this.uiTableLayoutPanel1.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.uiTableLayoutPanel1.Controls.Add(this.uiPanel1, 0, 0);
            this.uiTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            this.uiTableLayoutPanel1.RowCount = 2;
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.uiTableLayoutPanel1.Size = new System.Drawing.Size(1217, 840);
            this.uiTableLayoutPanel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiTableLayoutPanel1.TabIndex = 33;
            this.uiTableLayoutPanel1.TagString = null;
            // 
            // uiTableLayoutPanel2
            // 
            this.uiTableLayoutPanel2.ColumnCount = 4;
            this.uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTableLayoutPanel2.Controls.Add(this.Btn_CloseBuzzer, 3, 0);
            this.uiTableLayoutPanel2.Controls.Add(this.Btn_Stop, 2, 0);
            this.uiTableLayoutPanel2.Controls.Add(this.panel1, 1, 0);
            this.uiTableLayoutPanel2.Controls.Add(this.Btn_Reset, 0, 0);
            this.uiTableLayoutPanel2.Controls.Add(this.Panel_Statistics, 0, 1);
            this.uiTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel2.Location = new System.Drawing.Point(870, 3);
            this.uiTableLayoutPanel2.Name = "uiTableLayoutPanel2";
            this.uiTableLayoutPanel2.RowCount = 2;
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.uiTableLayoutPanel2.Size = new System.Drawing.Size(344, 582);
            this.uiTableLayoutPanel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiTableLayoutPanel2.TabIndex = 31;
            this.uiTableLayoutPanel2.TagString = null;
            // 
            // Btn_CloseBuzzer
            // 
            this.Btn_CloseBuzzer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_CloseBuzzer.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_CloseBuzzer.FillDisableColor = System.Drawing.Color.AliceBlue;
            this.Btn_CloseBuzzer.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.Btn_CloseBuzzer.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_CloseBuzzer.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_CloseBuzzer.Location = new System.Drawing.Point(263, 5);
            this.Btn_CloseBuzzer.Margin = new System.Windows.Forms.Padding(5, 5, 3, 3);
            this.Btn_CloseBuzzer.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_CloseBuzzer.Name = "Btn_CloseBuzzer";
            this.Btn_CloseBuzzer.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Btn_CloseBuzzer.Size = new System.Drawing.Size(73, 62);
            this.Btn_CloseBuzzer.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_CloseBuzzer.StyleCustomMode = true;
            this.Btn_CloseBuzzer.Symbol = 61942;
            this.Btn_CloseBuzzer.SymbolOffset = new System.Drawing.Point(0, 5);
            this.Btn_CloseBuzzer.SymbolSize = 48;
            this.Btn_CloseBuzzer.TabIndex = 45;
            this.Btn_CloseBuzzer.Text = "静音";
            this.Btn_CloseBuzzer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_CloseBuzzer.Click += new System.EventHandler(this.Btn_ClearAlarm_Click);
            // 
            // Btn_Stop
            // 
            this.Btn_Stop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Stop.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_Stop.FillDisableColor = System.Drawing.Color.AliceBlue;
            this.Btn_Stop.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Stop.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Stop.Location = new System.Drawing.Point(177, 5);
            this.Btn_Stop.Margin = new System.Windows.Forms.Padding(5, 5, 3, 3);
            this.Btn_Stop.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Stop.Name = "Btn_Stop";
            this.Btn_Stop.Size = new System.Drawing.Size(69, 62);
            this.Btn_Stop.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Stop.StyleCustomMode = true;
            this.Btn_Stop.Symbol = 61517;
            this.Btn_Stop.SymbolOffset = new System.Drawing.Point(0, 3);
            this.Btn_Stop.SymbolSize = 48;
            this.Btn_Stop.TabIndex = 44;
            this.Btn_Stop.Text = "停止";
            this.Btn_Stop.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Stop.Click += new System.EventHandler(this.Btn_End_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Btn_Start);
            this.panel1.Controls.Add(this.Btn_Pause);
            this.panel1.Location = new System.Drawing.Point(89, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(80, 64);
            this.panel1.TabIndex = 43;
            // 
            // Btn_Start
            // 
            this.Btn_Start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Start.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_Start.FillDisableColor = System.Drawing.Color.AliceBlue;
            this.Btn_Start.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Start.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Start.Location = new System.Drawing.Point(3, 2);
            this.Btn_Start.Margin = new System.Windows.Forms.Padding(5, 5, 3, 3);
            this.Btn_Start.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(69, 62);
            this.Btn_Start.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Start.StyleCustomMode = true;
            this.Btn_Start.Symbol = 61515;
            this.Btn_Start.SymbolOffset = new System.Drawing.Point(0, 2);
            this.Btn_Start.SymbolSize = 48;
            this.Btn_Start.TabIndex = 6;
            this.Btn_Start.Text = "启动";
            this.Btn_Start.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // Btn_Pause
            // 
            this.Btn_Pause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Pause.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_Pause.FillDisableColor = System.Drawing.Color.AliceBlue;
            this.Btn_Pause.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Pause.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Pause.Location = new System.Drawing.Point(3, 2);
            this.Btn_Pause.Margin = new System.Windows.Forms.Padding(5, 5, 3, 3);
            this.Btn_Pause.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Pause.Name = "Btn_Pause";
            this.Btn_Pause.Size = new System.Drawing.Size(69, 62);
            this.Btn_Pause.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Pause.StyleCustomMode = true;
            this.Btn_Pause.Symbol = 61516;
            this.Btn_Pause.SymbolOffset = new System.Drawing.Point(0, 2);
            this.Btn_Pause.SymbolSize = 48;
            this.Btn_Pause.TabIndex = 12;
            this.Btn_Pause.Text = "暂停";
            this.Btn_Pause.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Pause.Click += new System.EventHandler(this.Btn_Pause_Click);
            // 
            // Btn_Reset
            // 
            this.Btn_Reset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Reset.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_Reset.FillDisableColor = System.Drawing.Color.AliceBlue;
            this.Btn_Reset.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Reset.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Reset.Location = new System.Drawing.Point(5, 5);
            this.Btn_Reset.Margin = new System.Windows.Forms.Padding(5, 5, 3, 3);
            this.Btn_Reset.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Reset.Name = "Btn_Reset";
            this.Btn_Reset.Size = new System.Drawing.Size(69, 62);
            this.Btn_Reset.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Reset.StyleCustomMode = true;
            this.Btn_Reset.Symbol = 61470;
            this.Btn_Reset.SymbolOffset = new System.Drawing.Point(0, 3);
            this.Btn_Reset.SymbolSize = 48;
            this.Btn_Reset.TabIndex = 42;
            this.Btn_Reset.Text = "初始化";
            this.Btn_Reset.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Reset.Click += new System.EventHandler(this.Btn_Reset_Click);
            // 
            // Panel_Statistics
            // 
            this.Panel_Statistics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiTableLayoutPanel2.SetColumnSpan(this.Panel_Statistics, 4);
            this.Panel_Statistics.Controls.Add(this.Btn_Clear);
            this.Panel_Statistics.Controls.Add(this.Lb_Total);
            this.Panel_Statistics.Controls.Add(this.uiLabel9);
            this.Panel_Statistics.Controls.Add(this.Lb_UPH);
            this.Panel_Statistics.Controls.Add(this.Lb_CT);
            this.Panel_Statistics.Controls.Add(this.Lb_Fail);
            this.Panel_Statistics.Controls.Add(this.Lb_Pass);
            this.Panel_Statistics.Controls.Add(this.Lb_OK_Pct);
            this.Panel_Statistics.Controls.Add(this.uiLabel5);
            this.Panel_Statistics.Controls.Add(this.uiLabel4);
            this.Panel_Statistics.Controls.Add(this.uiLabel3);
            this.Panel_Statistics.Controls.Add(this.uiLabel2);
            this.Panel_Statistics.Controls.Add(this.uiLabel6);
            this.Panel_Statistics.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Panel_Statistics.Location = new System.Drawing.Point(4, 75);
            this.Panel_Statistics.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Panel_Statistics.MinimumSize = new System.Drawing.Size(1, 1);
            this.Panel_Statistics.Name = "Panel_Statistics";
            this.Panel_Statistics.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.Panel_Statistics.Size = new System.Drawing.Size(336, 502);
            this.Panel_Statistics.Style = Sunny.UI.UIStyle.Custom;
            this.Panel_Statistics.StyleCustomMode = true;
            this.Panel_Statistics.TabIndex = 12;
            this.Panel_Statistics.Text = "生产统计";
            this.Panel_Statistics.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.Panel_Statistics.TitleColor = System.Drawing.Color.SteelBlue;
            // 
            // Btn_Clear
            // 
            this.Btn_Clear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Clear.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_Clear.FillHoverColor = System.Drawing.Color.LightSteelBlue;
            this.Btn_Clear.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Btn_Clear.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Clear.Location = new System.Drawing.Point(109, 364);
            this.Btn_Clear.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Clear.Name = "Btn_Clear";
            this.Btn_Clear.RectColor = System.Drawing.Color.SteelBlue;
            this.Btn_Clear.Size = new System.Drawing.Size(100, 40);
            this.Btn_Clear.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Clear.StyleCustomMode = true;
            this.Btn_Clear.TabIndex = 218;
            this.Btn_Clear.Text = "清除";
            this.Btn_Clear.Click += new System.EventHandler(this.Btn_Clear_Click);
            // 
            // Lb_Total
            // 
            this.Lb_Total.BackColor = System.Drawing.Color.Transparent;
            this.Lb_Total.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lb_Total.Location = new System.Drawing.Point(115, 133);
            this.Lb_Total.Name = "Lb_Total";
            this.Lb_Total.Size = new System.Drawing.Size(77, 23);
            this.Lb_Total.Style = Sunny.UI.UIStyle.Custom;
            this.Lb_Total.TabIndex = 41;
            this.Lb_Total.Text = "0";
            this.Lb_Total.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel9
            // 
            this.uiLabel9.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel9.Location = new System.Drawing.Point(18, 133);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(77, 23);
            this.uiLabel9.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel9.TabIndex = 40;
            this.uiLabel9.Text = "总数";
            this.uiLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Lb_UPH
            // 
            this.Lb_UPH.BackColor = System.Drawing.Color.Transparent;
            this.Lb_UPH.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lb_UPH.Location = new System.Drawing.Point(115, 297);
            this.Lb_UPH.Name = "Lb_UPH";
            this.Lb_UPH.Size = new System.Drawing.Size(77, 23);
            this.Lb_UPH.Style = Sunny.UI.UIStyle.Custom;
            this.Lb_UPH.TabIndex = 37;
            this.Lb_UPH.Text = "0";
            this.Lb_UPH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Lb_CT
            // 
            this.Lb_CT.BackColor = System.Drawing.Color.Transparent;
            this.Lb_CT.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lb_CT.Location = new System.Drawing.Point(115, 256);
            this.Lb_CT.Name = "Lb_CT";
            this.Lb_CT.Size = new System.Drawing.Size(77, 23);
            this.Lb_CT.Style = Sunny.UI.UIStyle.Custom;
            this.Lb_CT.TabIndex = 36;
            this.Lb_CT.Text = "0";
            this.Lb_CT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Lb_Fail
            // 
            this.Lb_Fail.BackColor = System.Drawing.Color.Transparent;
            this.Lb_Fail.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lb_Fail.Location = new System.Drawing.Point(115, 215);
            this.Lb_Fail.Name = "Lb_Fail";
            this.Lb_Fail.Size = new System.Drawing.Size(77, 23);
            this.Lb_Fail.Style = Sunny.UI.UIStyle.Custom;
            this.Lb_Fail.TabIndex = 35;
            this.Lb_Fail.Text = "0";
            this.Lb_Fail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Lb_Pass
            // 
            this.Lb_Pass.BackColor = System.Drawing.Color.Transparent;
            this.Lb_Pass.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lb_Pass.Location = new System.Drawing.Point(115, 174);
            this.Lb_Pass.Name = "Lb_Pass";
            this.Lb_Pass.Size = new System.Drawing.Size(77, 23);
            this.Lb_Pass.Style = Sunny.UI.UIStyle.Custom;
            this.Lb_Pass.TabIndex = 34;
            this.Lb_Pass.Text = "0";
            this.Lb_Pass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Lb_OK_Pct
            // 
            this.Lb_OK_Pct.BackColor = System.Drawing.Color.Transparent;
            this.Lb_OK_Pct.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lb_OK_Pct.Location = new System.Drawing.Point(115, 92);
            this.Lb_OK_Pct.Name = "Lb_OK_Pct";
            this.Lb_OK_Pct.Size = new System.Drawing.Size(77, 23);
            this.Lb_OK_Pct.Style = Sunny.UI.UIStyle.Custom;
            this.Lb_OK_Pct.TabIndex = 33;
            this.Lb_OK_Pct.Text = "100%";
            this.Lb_OK_Pct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel5
            // 
            this.uiLabel5.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.Location = new System.Drawing.Point(18, 256);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(77, 23);
            this.uiLabel5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel5.TabIndex = 32;
            this.uiLabel5.Text = "CT";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel4
            // 
            this.uiLabel4.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(18, 297);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(77, 23);
            this.uiLabel4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel4.TabIndex = 31;
            this.uiLabel4.Text = "UPH";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(18, 215);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(77, 23);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 30;
            this.uiLabel3.Text = "FAIL数";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(18, 174);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(77, 23);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 29;
            this.uiLabel2.Text = "PASS数";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel6
            // 
            this.uiLabel6.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel6.Location = new System.Drawing.Point(18, 92);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(77, 23);
            this.uiLabel6.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel6.TabIndex = 28;
            this.uiLabel6.Text = "良率";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.uiTableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel1, 2);
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.StatusPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.runningMsgPanel, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 591);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 246F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1211, 246);
            this.tableLayoutPanel1.TabIndex = 33;
            // 
            // StatusPanel
            // 
            this.StatusPanel.BackColor = System.Drawing.Color.SteelBlue;
            this.StatusPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusPanel.Location = new System.Drawing.Point(5, 0);
            this.StatusPanel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.StatusPanel.Name = "StatusPanel";
            this.StatusPanel.Size = new System.Drawing.Size(595, 241);
            this.StatusPanel.TabIndex = 0;
            // 
            // runningMsgPanel
            // 
            this.runningMsgPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.runningMsgPanel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.runningMsgPanel.Location = new System.Drawing.Point(609, 0);
            this.runningMsgPanel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 5);
            this.runningMsgPanel.Name = "runningMsgPanel";
            this.runningMsgPanel.Size = new System.Drawing.Size(598, 241);
            this.runningMsgPanel.TabIndex = 1;
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.uiTabControl1);
            this.uiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel1.Location = new System.Drawing.Point(9, 5);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(9, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(854, 578);
            this.uiPanel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiPanel1.TabIndex = 34;
            this.uiPanel1.Text = null;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiTabControl1
            // 
            this.uiTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiTabControl1.Controls.Add(this.tabPage2);
            this.uiTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTabControl1.ItemSize = new System.Drawing.Size(150, 40);
            this.uiTabControl1.Location = new System.Drawing.Point(2, 2);
            this.uiTabControl1.MainPage = "";
            this.uiTabControl1.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiTabControl1.Name = "uiTabControl1";
            this.uiTabControl1.SelectedIndex = 0;
            this.uiTabControl1.Size = new System.Drawing.Size(850, 574);
            this.uiTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl1.Style = Sunny.UI.UIStyle.Custom;
            this.uiTabControl1.StyleCustomMode = true;
            this.uiTabControl1.TabBackColor = System.Drawing.Color.LightSteelBlue;
            this.uiTabControl1.TabIndex = 35;
            this.uiTabControl1.TabSelectedColor = System.Drawing.Color.SteelBlue;
            this.uiTabControl1.TabSelectedForeColor = System.Drawing.Color.White;
            this.uiTabControl1.TabUnSelectedForeColor = System.Drawing.Color.SteelBlue;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DGV_Result);
            this.tabPage2.Location = new System.Drawing.Point(0, 40);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(850, 534);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "数据";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DGV_Result
            // 
            this.DGV_Result.AllowUserToAddRows = false;
            this.DGV_Result.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(228)))), ((int)(((byte)(233)))));
            this.DGV_Result.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_Result.BackgroundColor = System.Drawing.Color.White;
            this.DGV_Result.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_Result.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_Result.ColumnHeadersHeight = 32;
            this.DGV_Result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_Result.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column3,
            this.磁通量上限,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_Result.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_Result.EnableHeadersVisualStyles = false;
            this.DGV_Result.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.DGV_Result.GridColor = System.Drawing.Color.LightSkyBlue;
            this.DGV_Result.Location = new System.Drawing.Point(0, 3);
            this.DGV_Result.Name = "DGV_Result";
            this.DGV_Result.RectColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_Result.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGV_Result.RowHeadersVisible = false;
            this.DGV_Result.RowHeadersWidth = 51;
            this.DGV_Result.RowHeight = 30;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.DGV_Result.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DGV_Result.RowTemplate.Height = 30;
            this.DGV_Result.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DGV_Result.ScrollMode = Sunny.UI.UIDataGridView.UIDataGridViewScrollMode.Page;
            this.DGV_Result.SelectedIndex = -1;
            this.DGV_Result.ShowGridLine = true;
            this.DGV_Result.Size = new System.Drawing.Size(847, 528);
            this.DGV_Result.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(228)))), ((int)(((byte)(233)))));
            this.DGV_Result.Style = Sunny.UI.UIStyle.Custom;
            this.DGV_Result.StyleCustomMode = true;
            this.DGV_Result.TabIndex = 4;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "序号";
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "SN";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "磁通量下限";
            this.Column4.Name = "Column4";
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 95;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "磁通量";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 磁通量上限
            // 
            this.磁通量上限.HeaderText = "磁通量上限";
            this.磁通量上限.Name = "磁通量上限";
            this.磁通量上限.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.磁通量上限.Width = 95;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "测高下限";
            this.Column5.Name = "Column5";
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 90;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "测高高度";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 90;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "测高上限";
            this.Column7.Name = "Column7";
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column7.Width = 90;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "MES";
            this.Column8.Name = "Column8";
            this.Column8.Width = 55;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "结果";
            this.Column9.Name = "Column9";
            this.Column9.Width = 55;
            // 
            // PerformPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1217, 840);
            this.Controls.Add(this.uiTableLayoutPanel1);
            this.Name = "PerformPage";
            this.Style = Sunny.UI.UIStyle.Custom;
            this.StyleCustomMode = true;
            this.Text = "PerformWindow";
            this.uiTableLayoutPanel1.ResumeLayout(false);
            this.uiTableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.Panel_Statistics.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.uiPanel1.ResumeLayout(false);
            this.uiTabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Result)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private LogPanel runningMsgPanel;
        public StatusPanel StatusPanel;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UITabControl uiTabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private Sunny.UI.UIDataGridView DGV_Result;
        private Sunny.UI.UITitlePanel Panel_Statistics;
        private Sunny.UI.UILabel Lb_Total;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UILabel Lb_UPH;
        private Sunny.UI.UILabel Lb_CT;
        private Sunny.UI.UILabel Lb_Fail;
        private Sunny.UI.UILabel Lb_Pass;
        private Sunny.UI.UILabel Lb_OK_Pct;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UISymbolButton Btn_CloseBuzzer;
        public Sunny.UI.UISymbolButton Btn_Stop;
        private System.Windows.Forms.Panel panel1;
        public Sunny.UI.UISymbolButton Btn_Start;
        public Sunny.UI.UISymbolButton Btn_Pause;
        private Sunny.UI.UISymbolButton Btn_Reset;
        private Sunny.UI.UIButton Btn_Clear;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn 磁通量上限;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}