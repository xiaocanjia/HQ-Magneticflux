namespace JSystem.Device
{
    partial class MagneticFluxView
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
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.TB_Send = new Sunny.UI.UITextBox();
            this.Btn_SetRange = new Sunny.UI.UIButton();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.Btn_SetUnit = new Sunny.UI.UIButton();
            this.CB_Range = new Sunny.UI.UIComboBox();
            this.CB_Unit = new Sunny.UI.UIComboBox();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.Lb_Value = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // uiLabel4
            // 
            this.uiLabel4.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel4.Location = new System.Drawing.Point(22, 302);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(47, 29);
            this.uiLabel4.TabIndex = 208;
            this.uiLabel4.Text = "量程";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel3
            // 
            this.uiLabel3.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel3.Location = new System.Drawing.Point(22, 140);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(85, 25);
            this.uiLabel3.TabIndex = 206;
            this.uiLabel3.Text = "停止位";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(22, 32);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(85, 25);
            this.uiLabel2.TabIndex = 203;
            this.uiLabel2.Text = "串口号";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel9
            // 
            this.uiLabel9.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel9.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel9.Location = new System.Drawing.Point(22, 104);
            this.uiLabel9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(85, 25);
            this.uiLabel9.TabIndex = 199;
            this.uiLabel9.Text = "数据位";
            this.uiLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(22, 68);
            this.uiLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(85, 25);
            this.uiLabel1.TabIndex = 198;
            this.uiLabel1.Text = "波特率";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_Send
            // 
            this.TB_Send.AutoScroll = true;
            this.TB_Send.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.TB_Send.ButtonSymbol = 61761;
            this.TB_Send.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Send.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TB_Send.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.TB_Send.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_Send.Location = new System.Drawing.Point(0, 35);
            this.TB_Send.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_Send.Maximum = 10D;
            this.TB_Send.MaxLength = 1024;
            this.TB_Send.Minimum = -2147483648D;
            this.TB_Send.MinimumSize = new System.Drawing.Size(1, 16);
            this.TB_Send.Multiline = true;
            this.TB_Send.Name = "TB_Send";
            this.TB_Send.Size = new System.Drawing.Size(479, 83);
            this.TB_Send.Style = Sunny.UI.UIStyle.Custom;
            this.TB_Send.StyleCustomMode = true;
            this.TB_Send.TabIndex = 229;
            this.TB_Send.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Btn_SetRange
            // 
            this.Btn_SetRange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_SetRange.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_SetRange.FillHoverColor = System.Drawing.Color.LightSteelBlue;
            this.Btn_SetRange.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Btn_SetRange.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_SetRange.Location = new System.Drawing.Point(286, 302);
            this.Btn_SetRange.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_SetRange.Name = "Btn_SetRange";
            this.Btn_SetRange.RectColor = System.Drawing.Color.SteelBlue;
            this.Btn_SetRange.Size = new System.Drawing.Size(73, 29);
            this.Btn_SetRange.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_SetRange.StyleCustomMode = true;
            this.Btn_SetRange.TabIndex = 204;
            this.Btn_SetRange.Text = "设置";
            this.Btn_SetRange.Click += new System.EventHandler(this.Btn_SetRange_Click);
            // 
            // uiLabel5
            // 
            this.uiLabel5.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel5.Location = new System.Drawing.Point(22, 362);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(47, 29);
            this.uiLabel5.TabIndex = 242;
            this.uiLabel5.Text = "单位";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Btn_SetUnit
            // 
            this.Btn_SetUnit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_SetUnit.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_SetUnit.FillHoverColor = System.Drawing.Color.LightSteelBlue;
            this.Btn_SetUnit.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Btn_SetUnit.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_SetUnit.Location = new System.Drawing.Point(286, 362);
            this.Btn_SetUnit.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_SetUnit.Name = "Btn_SetUnit";
            this.Btn_SetUnit.RectColor = System.Drawing.Color.SteelBlue;
            this.Btn_SetUnit.Size = new System.Drawing.Size(73, 29);
            this.Btn_SetUnit.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_SetUnit.StyleCustomMode = true;
            this.Btn_SetUnit.TabIndex = 241;
            this.Btn_SetUnit.Text = "设置";
            this.Btn_SetUnit.Click += new System.EventHandler(this.Btn_SetUnit_Click);
            // 
            // CB_Range
            // 
            this.CB_Range.DataSource = null;
            this.CB_Range.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CB_Range.FillColor = System.Drawing.Color.White;
            this.CB_Range.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CB_Range.Items.AddRange(new object[] {
            "2mWb",
            "20mWb",
            "200mWb",
            "2Wb",
            "2mVs",
            "20mVs",
            "200mVs",
            "2Vs"});
            this.CB_Range.Location = new System.Drawing.Point(88, 302);
            this.CB_Range.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CB_Range.MinimumSize = new System.Drawing.Size(63, 0);
            this.CB_Range.Name = "CB_Range";
            this.CB_Range.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CB_Range.Size = new System.Drawing.Size(191, 29);
            this.CB_Range.TabIndex = 244;
            this.CB_Range.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CB_Unit
            // 
            this.CB_Unit.DataSource = null;
            this.CB_Unit.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CB_Unit.FillColor = System.Drawing.Color.White;
            this.CB_Unit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CB_Unit.Items.AddRange(new object[] {
            "mWb",
            "mVs"});
            this.CB_Unit.Location = new System.Drawing.Point(88, 362);
            this.CB_Unit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CB_Unit.MinimumSize = new System.Drawing.Size(63, 0);
            this.CB_Unit.Name = "CB_Unit";
            this.CB_Unit.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CB_Unit.Size = new System.Drawing.Size(191, 29);
            this.CB_Unit.TabIndex = 245;
            this.CB_Unit.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel6
            // 
            this.uiLabel6.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel6.Location = new System.Drawing.Point(22, 428);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(60, 29);
            this.uiLabel6.TabIndex = 246;
            this.uiLabel6.Text = "当前值";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lb_Value
            // 
            this.Lb_Value.BackColor = System.Drawing.Color.Transparent;
            this.Lb_Value.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Lb_Value.Location = new System.Drawing.Point(88, 428);
            this.Lb_Value.Name = "Lb_Value";
            this.Lb_Value.Size = new System.Drawing.Size(110, 29);
            this.Lb_Value.TabIndex = 247;
            this.Lb_Value.Text = "0.0";
            this.Lb_Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MagneticFluxView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.Lb_Value);
            this.Controls.Add(this.uiLabel6);
            this.Controls.Add(this.CB_Unit);
            this.Controls.Add(this.CB_Range);
            this.Controls.Add(this.uiLabel5);
            this.Controls.Add(this.Btn_SetUnit);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.Btn_SetRange);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel9);
            this.Controls.Add(this.uiLabel1);
            this.Name = "MagneticFluxView";
            this.Controls.SetChildIndex(this.uiLabel1, 0);
            this.Controls.SetChildIndex(this.uiLabel9, 0);
            this.Controls.SetChildIndex(this.uiLabel2, 0);
            this.Controls.SetChildIndex(this.Btn_SetRange, 0);
            this.Controls.SetChildIndex(this.uiLabel3, 0);
            this.Controls.SetChildIndex(this.uiLabel4, 0);
            this.Controls.SetChildIndex(this.Btn_SetUnit, 0);
            this.Controls.SetChildIndex(this.uiLabel5, 0);
            this.Controls.SetChildIndex(this.CB_Range, 0);
            this.Controls.SetChildIndex(this.CB_Unit, 0);
            this.Controls.SetChildIndex(this.uiLabel6, 0);
            this.Controls.SetChildIndex(this.Lb_Value, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox TB_Send;
        private Sunny.UI.UIButton Btn_SetRange;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UIButton Btn_SetUnit;
        private Sunny.UI.UIComboBox CB_Range;
        private Sunny.UI.UIComboBox CB_Unit;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UILabel Lb_Value;
    }
}
