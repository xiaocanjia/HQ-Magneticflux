namespace JSystem.Device
{
    partial class BoardView
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Btn_Connect = new Sunny.UI.UIButton();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.CbB_Board_Type = new Sunny.UI.UIComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TB_RelMove_VelH = new Sunny.UI.UITextBox();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.TB_RelMove_Dist = new Sunny.UI.UITextBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.TB_RelMove_Dcc = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.TB_RelMove_Acc = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.Btn_Rel_Move = new Sunny.UI.UIButton();
            this.TB_RelMove_VelL = new Sunny.UI.UITextBox();
            this.uiLabel14 = new Sunny.UI.UILabel();
            this.TB_RelMove_Axis = new Sunny.UI.UITextBox();
            this.uiLabel15 = new Sunny.UI.UILabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TB_Reset_Offset = new Sunny.UI.UITextBox();
            this.uiLabel13 = new Sunny.UI.UILabel();
            this.TB_Reset_Dir = new Sunny.UI.UITextBox();
            this.uiLabel12 = new Sunny.UI.UILabel();
            this.TB_Reset_VelH = new Sunny.UI.UITextBox();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.TB_Reset_Mode = new Sunny.UI.UITextBox();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.TB_Reset_Dcc = new Sunny.UI.UITextBox();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.TB_Reset_Acc = new Sunny.UI.UITextBox();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.Btn_Reset = new Sunny.UI.UIButton();
            this.TB_Reset_VelL = new Sunny.UI.UITextBox();
            this.uiLabel10 = new Sunny.UI.UILabel();
            this.TB_Reset_Axis = new Sunny.UI.UITextBox();
            this.uiLabel11 = new Sunny.UI.UILabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Connect
            // 
            this.Btn_Connect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Connect.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_Connect.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(197)))), ((int)(((byte)(244)))));
            this.Btn_Connect.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Btn_Connect.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Connect.Location = new System.Drawing.Point(157, 108);
            this.Btn_Connect.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Connect.Name = "Btn_Connect";
            this.Btn_Connect.RectColor = System.Drawing.Color.SteelBlue;
            this.Btn_Connect.Size = new System.Drawing.Size(100, 40);
            this.Btn_Connect.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Connect.StyleCustomMode = true;
            this.Btn_Connect.TabIndex = 172;
            this.Btn_Connect.Text = "连接";
            this.Btn_Connect.Click += new System.EventHandler(this.Btn_Connect_Click);
            // 
            // uiLabel2
            // 
            this.uiLabel2.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(21, 36);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(78, 23);
            this.uiLabel2.TabIndex = 171;
            this.uiLabel2.Text = "板卡类型";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CbB_Board_Type
            // 
            this.CbB_Board_Type.DataSource = null;
            this.CbB_Board_Type.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CbB_Board_Type.FillColor = System.Drawing.Color.White;
            this.CbB_Board_Type.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CbB_Board_Type.Location = new System.Drawing.Point(116, 30);
            this.CbB_Board_Type.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbB_Board_Type.MinimumSize = new System.Drawing.Size(63, 0);
            this.CbB_Board_Type.Name = "CbB_Board_Type";
            this.CbB_Board_Type.Padding = new System.Windows.Forms.Padding(8, 0, 30, 2);
            this.CbB_Board_Type.Size = new System.Drawing.Size(266, 29);
            this.CbB_Board_Type.TabIndex = 170;
            this.CbB_Board_Type.TextAlignment = System.Drawing.ContentAlignment.BottomLeft;
            this.CbB_Board_Type.SelectedIndexChanged += new System.EventHandler(this.CbB_Cam_Type_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TB_RelMove_VelH);
            this.groupBox1.Controls.Add(this.uiLabel5);
            this.groupBox1.Controls.Add(this.TB_RelMove_Dist);
            this.groupBox1.Controls.Add(this.uiLabel4);
            this.groupBox1.Controls.Add(this.TB_RelMove_Dcc);
            this.groupBox1.Controls.Add(this.uiLabel3);
            this.groupBox1.Controls.Add(this.TB_RelMove_Acc);
            this.groupBox1.Controls.Add(this.uiLabel1);
            this.groupBox1.Controls.Add(this.Btn_Rel_Move);
            this.groupBox1.Controls.Add(this.TB_RelMove_VelL);
            this.groupBox1.Controls.Add(this.uiLabel14);
            this.groupBox1.Controls.Add(this.TB_RelMove_Axis);
            this.groupBox1.Controls.Add(this.uiLabel15);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(15, 361);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 157);
            this.groupBox1.TabIndex = 248;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "相对运动";
            // 
            // TB_RelMove_VelH
            // 
            this.TB_RelMove_VelH.ButtonSymbol = 61761;
            this.TB_RelMove_VelH.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_RelMove_VelH.DoubleValue = 10000D;
            this.TB_RelMove_VelH.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_RelMove_VelH.IntValue = 10000;
            this.TB_RelMove_VelH.Location = new System.Drawing.Point(404, 28);
            this.TB_RelMove_VelH.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.TB_RelMove_VelH.Maximum = 2147483647D;
            this.TB_RelMove_VelH.Minimum = -2147483648D;
            this.TB_RelMove_VelH.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_RelMove_VelH.Name = "TB_RelMove_VelH";
            this.TB_RelMove_VelH.Padding = new System.Windows.Forms.Padding(7);
            this.TB_RelMove_VelH.Size = new System.Drawing.Size(90, 30);
            this.TB_RelMove_VelH.TabIndex = 254;
            this.TB_RelMove_VelH.Text = "10000";
            this.TB_RelMove_VelH.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel5
            // 
            this.uiLabel5.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel5.Location = new System.Drawing.Point(349, 32);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(55, 25);
            this.uiLabel5.TabIndex = 253;
            this.uiLabel5.Text = "速度H";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_RelMove_Dist
            // 
            this.TB_RelMove_Dist.ButtonSymbol = 61761;
            this.TB_RelMove_Dist.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_RelMove_Dist.DoubleValue = 10000D;
            this.TB_RelMove_Dist.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_RelMove_Dist.IntValue = 10000;
            this.TB_RelMove_Dist.Location = new System.Drawing.Point(404, 73);
            this.TB_RelMove_Dist.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.TB_RelMove_Dist.Maximum = 2147483647D;
            this.TB_RelMove_Dist.Minimum = -2147483648D;
            this.TB_RelMove_Dist.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_RelMove_Dist.Name = "TB_RelMove_Dist";
            this.TB_RelMove_Dist.Padding = new System.Windows.Forms.Padding(7);
            this.TB_RelMove_Dist.Size = new System.Drawing.Size(90, 30);
            this.TB_RelMove_Dist.TabIndex = 252;
            this.TB_RelMove_Dist.Text = "10000";
            this.TB_RelMove_Dist.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel4
            // 
            this.uiLabel4.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel4.Location = new System.Drawing.Point(349, 77);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(46, 25);
            this.uiLabel4.TabIndex = 251;
            this.uiLabel4.Text = "距离";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_RelMove_Dcc
            // 
            this.TB_RelMove_Dcc.ButtonSymbol = 61761;
            this.TB_RelMove_Dcc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_RelMove_Dcc.DoubleValue = 10000D;
            this.TB_RelMove_Dcc.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_RelMove_Dcc.IntValue = 10000;
            this.TB_RelMove_Dcc.Location = new System.Drawing.Point(245, 73);
            this.TB_RelMove_Dcc.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.TB_RelMove_Dcc.Maximum = 2147483647D;
            this.TB_RelMove_Dcc.Minimum = -2147483648D;
            this.TB_RelMove_Dcc.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_RelMove_Dcc.Name = "TB_RelMove_Dcc";
            this.TB_RelMove_Dcc.Padding = new System.Windows.Forms.Padding(7);
            this.TB_RelMove_Dcc.Size = new System.Drawing.Size(90, 30);
            this.TB_RelMove_Dcc.TabIndex = 250;
            this.TB_RelMove_Dcc.Text = "10000";
            this.TB_RelMove_Dcc.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel3.Location = new System.Drawing.Point(183, 77);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(62, 25);
            this.uiLabel3.TabIndex = 249;
            this.uiLabel3.Text = "减速度";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_RelMove_Acc
            // 
            this.TB_RelMove_Acc.ButtonSymbol = 61761;
            this.TB_RelMove_Acc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_RelMove_Acc.DoubleValue = 10000D;
            this.TB_RelMove_Acc.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_RelMove_Acc.IntValue = 10000;
            this.TB_RelMove_Acc.Location = new System.Drawing.Point(75, 73);
            this.TB_RelMove_Acc.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.TB_RelMove_Acc.Maximum = 2147483647D;
            this.TB_RelMove_Acc.Minimum = -2147483648D;
            this.TB_RelMove_Acc.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_RelMove_Acc.Name = "TB_RelMove_Acc";
            this.TB_RelMove_Acc.Padding = new System.Windows.Forms.Padding(7);
            this.TB_RelMove_Acc.Size = new System.Drawing.Size(90, 30);
            this.TB_RelMove_Acc.TabIndex = 248;
            this.TB_RelMove_Acc.Text = "10000";
            this.TB_RelMove_Acc.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(12, 77);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(62, 25);
            this.uiLabel1.TabIndex = 247;
            this.uiLabel1.Text = "加速度";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Btn_Rel_Move
            // 
            this.Btn_Rel_Move.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Rel_Move.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_Rel_Move.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(197)))), ((int)(((byte)(244)))));
            this.Btn_Rel_Move.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Btn_Rel_Move.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Rel_Move.Location = new System.Drawing.Point(426, 116);
            this.Btn_Rel_Move.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Rel_Move.Name = "Btn_Rel_Move";
            this.Btn_Rel_Move.RectColor = System.Drawing.Color.SteelBlue;
            this.Btn_Rel_Move.Size = new System.Drawing.Size(66, 29);
            this.Btn_Rel_Move.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Rel_Move.StyleCustomMode = true;
            this.Btn_Rel_Move.TabIndex = 239;
            this.Btn_Rel_Move.Text = "运动";
            this.Btn_Rel_Move.Click += new System.EventHandler(this.Btn_Rel_Move_Click);
            // 
            // TB_RelMove_VelL
            // 
            this.TB_RelMove_VelL.ButtonSymbol = 61761;
            this.TB_RelMove_VelL.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_RelMove_VelL.DoubleValue = 10000D;
            this.TB_RelMove_VelL.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_RelMove_VelL.IntValue = 10000;
            this.TB_RelMove_VelL.Location = new System.Drawing.Point(245, 28);
            this.TB_RelMove_VelL.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.TB_RelMove_VelL.Maximum = 2147483647D;
            this.TB_RelMove_VelL.Minimum = -2147483648D;
            this.TB_RelMove_VelL.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_RelMove_VelL.Name = "TB_RelMove_VelL";
            this.TB_RelMove_VelL.Padding = new System.Windows.Forms.Padding(7);
            this.TB_RelMove_VelL.Size = new System.Drawing.Size(90, 30);
            this.TB_RelMove_VelL.TabIndex = 239;
            this.TB_RelMove_VelL.Text = "10000";
            this.TB_RelMove_VelL.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel14
            // 
            this.uiLabel14.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel14.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel14.Location = new System.Drawing.Point(183, 32);
            this.uiLabel14.Name = "uiLabel14";
            this.uiLabel14.Size = new System.Drawing.Size(55, 25);
            this.uiLabel14.TabIndex = 238;
            this.uiLabel14.Text = "速度L";
            this.uiLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_RelMove_Axis
            // 
            this.TB_RelMove_Axis.ButtonSymbol = 61761;
            this.TB_RelMove_Axis.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_RelMove_Axis.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_RelMove_Axis.Location = new System.Drawing.Point(75, 29);
            this.TB_RelMove_Axis.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.TB_RelMove_Axis.Maximum = 2147483647D;
            this.TB_RelMove_Axis.Minimum = -2147483648D;
            this.TB_RelMove_Axis.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_RelMove_Axis.Name = "TB_RelMove_Axis";
            this.TB_RelMove_Axis.Padding = new System.Windows.Forms.Padding(7);
            this.TB_RelMove_Axis.Size = new System.Drawing.Size(90, 30);
            this.TB_RelMove_Axis.TabIndex = 237;
            this.TB_RelMove_Axis.Text = "0";
            this.TB_RelMove_Axis.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel15
            // 
            this.uiLabel15.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel15.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel15.Location = new System.Drawing.Point(12, 33);
            this.uiLabel15.Name = "uiLabel15";
            this.uiLabel15.Size = new System.Drawing.Size(48, 25);
            this.uiLabel15.TabIndex = 236;
            this.uiLabel15.Text = "轴号";
            this.uiLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TB_Reset_Offset);
            this.groupBox2.Controls.Add(this.uiLabel13);
            this.groupBox2.Controls.Add(this.TB_Reset_Dir);
            this.groupBox2.Controls.Add(this.uiLabel12);
            this.groupBox2.Controls.Add(this.TB_Reset_VelH);
            this.groupBox2.Controls.Add(this.uiLabel6);
            this.groupBox2.Controls.Add(this.TB_Reset_Mode);
            this.groupBox2.Controls.Add(this.uiLabel7);
            this.groupBox2.Controls.Add(this.TB_Reset_Dcc);
            this.groupBox2.Controls.Add(this.uiLabel8);
            this.groupBox2.Controls.Add(this.TB_Reset_Acc);
            this.groupBox2.Controls.Add(this.uiLabel9);
            this.groupBox2.Controls.Add(this.Btn_Reset);
            this.groupBox2.Controls.Add(this.TB_Reset_VelL);
            this.groupBox2.Controls.Add(this.uiLabel10);
            this.groupBox2.Controls.Add(this.TB_Reset_Axis);
            this.groupBox2.Controls.Add(this.uiLabel11);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(15, 189);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(512, 157);
            this.groupBox2.TabIndex = 255;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "回零";
            // 
            // TB_Reset_Offset
            // 
            this.TB_Reset_Offset.ButtonSymbol = 61761;
            this.TB_Reset_Offset.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Reset_Offset.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Reset_Offset.Location = new System.Drawing.Point(245, 115);
            this.TB_Reset_Offset.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.TB_Reset_Offset.Maximum = 2147483647D;
            this.TB_Reset_Offset.Minimum = -2147483648D;
            this.TB_Reset_Offset.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Reset_Offset.Name = "TB_Reset_Offset";
            this.TB_Reset_Offset.Padding = new System.Windows.Forms.Padding(7);
            this.TB_Reset_Offset.Size = new System.Drawing.Size(90, 30);
            this.TB_Reset_Offset.TabIndex = 256;
            this.TB_Reset_Offset.Text = "0";
            this.TB_Reset_Offset.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel13
            // 
            this.uiLabel13.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel13.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel13.Location = new System.Drawing.Point(183, 118);
            this.uiLabel13.Name = "uiLabel13";
            this.uiLabel13.Size = new System.Drawing.Size(58, 25);
            this.uiLabel13.TabIndex = 255;
            this.uiLabel13.Text = "偏移量";
            this.uiLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_Reset_Dir
            // 
            this.TB_Reset_Dir.ButtonSymbol = 61761;
            this.TB_Reset_Dir.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Reset_Dir.DoubleValue = 1D;
            this.TB_Reset_Dir.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Reset_Dir.IntValue = 1;
            this.TB_Reset_Dir.Location = new System.Drawing.Point(75, 115);
            this.TB_Reset_Dir.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.TB_Reset_Dir.Maximum = 2147483647D;
            this.TB_Reset_Dir.Minimum = -2147483648D;
            this.TB_Reset_Dir.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Reset_Dir.Name = "TB_Reset_Dir";
            this.TB_Reset_Dir.Padding = new System.Windows.Forms.Padding(7);
            this.TB_Reset_Dir.Size = new System.Drawing.Size(90, 30);
            this.TB_Reset_Dir.TabIndex = 254;
            this.TB_Reset_Dir.Text = "1";
            this.TB_Reset_Dir.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel12
            // 
            this.uiLabel12.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel12.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel12.Location = new System.Drawing.Point(12, 118);
            this.uiLabel12.Name = "uiLabel12";
            this.uiLabel12.Size = new System.Drawing.Size(46, 25);
            this.uiLabel12.TabIndex = 253;
            this.uiLabel12.Text = "方向";
            this.uiLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_Reset_VelH
            // 
            this.TB_Reset_VelH.ButtonSymbol = 61761;
            this.TB_Reset_VelH.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Reset_VelH.DoubleValue = 10000D;
            this.TB_Reset_VelH.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Reset_VelH.IntValue = 10000;
            this.TB_Reset_VelH.Location = new System.Drawing.Point(404, 28);
            this.TB_Reset_VelH.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.TB_Reset_VelH.Maximum = 2147483647D;
            this.TB_Reset_VelH.Minimum = -2147483648D;
            this.TB_Reset_VelH.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Reset_VelH.Name = "TB_Reset_VelH";
            this.TB_Reset_VelH.Padding = new System.Windows.Forms.Padding(7);
            this.TB_Reset_VelH.Size = new System.Drawing.Size(90, 30);
            this.TB_Reset_VelH.TabIndex = 254;
            this.TB_Reset_VelH.Text = "10000";
            this.TB_Reset_VelH.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel6
            // 
            this.uiLabel6.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel6.Location = new System.Drawing.Point(349, 32);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(55, 25);
            this.uiLabel6.TabIndex = 253;
            this.uiLabel6.Text = "速度H";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_Reset_Mode
            // 
            this.TB_Reset_Mode.ButtonSymbol = 61761;
            this.TB_Reset_Mode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Reset_Mode.DoubleValue = 1D;
            this.TB_Reset_Mode.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Reset_Mode.IntValue = 1;
            this.TB_Reset_Mode.Location = new System.Drawing.Point(404, 73);
            this.TB_Reset_Mode.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.TB_Reset_Mode.Maximum = 2147483647D;
            this.TB_Reset_Mode.Minimum = -2147483648D;
            this.TB_Reset_Mode.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Reset_Mode.Name = "TB_Reset_Mode";
            this.TB_Reset_Mode.Padding = new System.Windows.Forms.Padding(7);
            this.TB_Reset_Mode.Size = new System.Drawing.Size(90, 30);
            this.TB_Reset_Mode.TabIndex = 252;
            this.TB_Reset_Mode.Text = "1";
            this.TB_Reset_Mode.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel7
            // 
            this.uiLabel7.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel7.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel7.Location = new System.Drawing.Point(349, 77);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(55, 25);
            this.uiLabel7.TabIndex = 251;
            this.uiLabel7.Text = "模式";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_Reset_Dcc
            // 
            this.TB_Reset_Dcc.ButtonSymbol = 61761;
            this.TB_Reset_Dcc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Reset_Dcc.DoubleValue = 10000D;
            this.TB_Reset_Dcc.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Reset_Dcc.IntValue = 10000;
            this.TB_Reset_Dcc.Location = new System.Drawing.Point(245, 73);
            this.TB_Reset_Dcc.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.TB_Reset_Dcc.Maximum = 2147483647D;
            this.TB_Reset_Dcc.Minimum = -2147483648D;
            this.TB_Reset_Dcc.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Reset_Dcc.Name = "TB_Reset_Dcc";
            this.TB_Reset_Dcc.Padding = new System.Windows.Forms.Padding(7);
            this.TB_Reset_Dcc.Size = new System.Drawing.Size(90, 30);
            this.TB_Reset_Dcc.TabIndex = 250;
            this.TB_Reset_Dcc.Text = "10000";
            this.TB_Reset_Dcc.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel8
            // 
            this.uiLabel8.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel8.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel8.Location = new System.Drawing.Point(183, 77);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(62, 25);
            this.uiLabel8.TabIndex = 249;
            this.uiLabel8.Text = "减速度";
            this.uiLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_Reset_Acc
            // 
            this.TB_Reset_Acc.ButtonSymbol = 61761;
            this.TB_Reset_Acc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Reset_Acc.DoubleValue = 10000D;
            this.TB_Reset_Acc.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Reset_Acc.IntValue = 10000;
            this.TB_Reset_Acc.Location = new System.Drawing.Point(75, 73);
            this.TB_Reset_Acc.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.TB_Reset_Acc.Maximum = 2147483647D;
            this.TB_Reset_Acc.Minimum = -2147483648D;
            this.TB_Reset_Acc.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Reset_Acc.Name = "TB_Reset_Acc";
            this.TB_Reset_Acc.Padding = new System.Windows.Forms.Padding(7);
            this.TB_Reset_Acc.Size = new System.Drawing.Size(90, 30);
            this.TB_Reset_Acc.TabIndex = 248;
            this.TB_Reset_Acc.Text = "10000";
            this.TB_Reset_Acc.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel9
            // 
            this.uiLabel9.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel9.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel9.Location = new System.Drawing.Point(12, 77);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(62, 25);
            this.uiLabel9.TabIndex = 247;
            this.uiLabel9.Text = "加速度";
            this.uiLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Btn_Reset
            // 
            this.Btn_Reset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Reset.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_Reset.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(197)))), ((int)(((byte)(244)))));
            this.Btn_Reset.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Btn_Reset.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Reset.Location = new System.Drawing.Point(426, 116);
            this.Btn_Reset.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Reset.Name = "Btn_Reset";
            this.Btn_Reset.RectColor = System.Drawing.Color.SteelBlue;
            this.Btn_Reset.Size = new System.Drawing.Size(66, 29);
            this.Btn_Reset.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Reset.StyleCustomMode = true;
            this.Btn_Reset.TabIndex = 239;
            this.Btn_Reset.Text = "复位";
            this.Btn_Reset.Click += new System.EventHandler(this.Btn_Reset_Click);
            // 
            // TB_Reset_VelL
            // 
            this.TB_Reset_VelL.ButtonSymbol = 61761;
            this.TB_Reset_VelL.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Reset_VelL.DoubleValue = 10000D;
            this.TB_Reset_VelL.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Reset_VelL.IntValue = 10000;
            this.TB_Reset_VelL.Location = new System.Drawing.Point(245, 28);
            this.TB_Reset_VelL.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.TB_Reset_VelL.Maximum = 2147483647D;
            this.TB_Reset_VelL.Minimum = -2147483648D;
            this.TB_Reset_VelL.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Reset_VelL.Name = "TB_Reset_VelL";
            this.TB_Reset_VelL.Padding = new System.Windows.Forms.Padding(7);
            this.TB_Reset_VelL.Size = new System.Drawing.Size(90, 30);
            this.TB_Reset_VelL.TabIndex = 239;
            this.TB_Reset_VelL.Text = "10000";
            this.TB_Reset_VelL.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel10
            // 
            this.uiLabel10.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel10.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel10.Location = new System.Drawing.Point(183, 32);
            this.uiLabel10.Name = "uiLabel10";
            this.uiLabel10.Size = new System.Drawing.Size(55, 25);
            this.uiLabel10.TabIndex = 238;
            this.uiLabel10.Text = "速度L";
            this.uiLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_Reset_Axis
            // 
            this.TB_Reset_Axis.ButtonSymbol = 61761;
            this.TB_Reset_Axis.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Reset_Axis.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Reset_Axis.Location = new System.Drawing.Point(75, 29);
            this.TB_Reset_Axis.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.TB_Reset_Axis.Maximum = 2147483647D;
            this.TB_Reset_Axis.Minimum = -2147483648D;
            this.TB_Reset_Axis.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Reset_Axis.Name = "TB_Reset_Axis";
            this.TB_Reset_Axis.Padding = new System.Windows.Forms.Padding(7);
            this.TB_Reset_Axis.Size = new System.Drawing.Size(90, 30);
            this.TB_Reset_Axis.TabIndex = 237;
            this.TB_Reset_Axis.Text = "0";
            this.TB_Reset_Axis.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel11
            // 
            this.uiLabel11.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel11.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel11.Location = new System.Drawing.Point(12, 33);
            this.uiLabel11.Name = "uiLabel11";
            this.uiLabel11.Size = new System.Drawing.Size(48, 25);
            this.uiLabel11.TabIndex = 236;
            this.uiLabel11.Text = "轴号";
            this.uiLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BoardView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Btn_Connect);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.CbB_Board_Type);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BoardView";
            this.Size = new System.Drawing.Size(552, 800);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UIButton Btn_Connect;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIComboBox CbB_Board_Type;
        private System.Windows.Forms.GroupBox groupBox1;
        private Sunny.UI.UITextBox TB_RelMove_Dist;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UITextBox TB_RelMove_Dcc;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox TB_RelMove_Acc;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIButton Btn_Rel_Move;
        private Sunny.UI.UITextBox TB_RelMove_VelL;
        private Sunny.UI.UILabel uiLabel14;
        private Sunny.UI.UITextBox TB_RelMove_Axis;
        private Sunny.UI.UILabel uiLabel15;
        private Sunny.UI.UITextBox TB_RelMove_VelH;
        private Sunny.UI.UILabel uiLabel5;
        private System.Windows.Forms.GroupBox groupBox2;
        private Sunny.UI.UITextBox TB_Reset_Dir;
        private Sunny.UI.UILabel uiLabel12;
        private Sunny.UI.UITextBox TB_Reset_VelH;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UITextBox TB_Reset_Mode;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UITextBox TB_Reset_Dcc;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UITextBox TB_Reset_Acc;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UIButton Btn_Reset;
        private Sunny.UI.UITextBox TB_Reset_VelL;
        private Sunny.UI.UILabel uiLabel10;
        private Sunny.UI.UITextBox TB_Reset_Axis;
        private Sunny.UI.UILabel uiLabel11;
        private Sunny.UI.UITextBox TB_Reset_Offset;
        private Sunny.UI.UILabel uiLabel13;
    }
}
