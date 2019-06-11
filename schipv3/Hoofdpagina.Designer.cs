namespace schipv3
{
    partial class Hoofdpagina
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hoofdpagina));
            this.BtnSchip = new System.Windows.Forms.Button();
            this.NudLengte = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NudBreedte = new System.Windows.Forms.NumericUpDown();
            this.LbSoort = new System.Windows.Forms.ListBox();
            this.BtnToevoegenContainer = new System.Windows.Forms.Button();
            this.NUDcontainer = new System.Windows.Forms.NumericUpDown();
            this.LbContainers = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.btnIndelen = new System.Windows.Forms.Button();
            this.btnWegvaren = new System.Windows.Forms.Button();
            this.btnmaakveelcontainers = new System.Windows.Forms.Button();
            this.Aantalcontainers = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCheckBalans = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NudLengte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudBreedte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDcontainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Aantalcontainers)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnSchip
            // 
            this.BtnSchip.Location = new System.Drawing.Point(74, 86);
            this.BtnSchip.Name = "BtnSchip";
            this.BtnSchip.Size = new System.Drawing.Size(75, 23);
            this.BtnSchip.TabIndex = 0;
            this.BtnSchip.Text = "Schip";
            this.BtnSchip.UseVisualStyleBackColor = true;
            this.BtnSchip.Click += new System.EventHandler(this.BtnSchip_Click);
            // 
            // NudLengte
            // 
            this.NudLengte.Location = new System.Drawing.Point(74, 19);
            this.NudLengte.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudLengte.Name = "NudLengte";
            this.NudLengte.Size = new System.Drawing.Size(120, 20);
            this.NudLengte.TabIndex = 1;
            this.NudLengte.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "lengte";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Breedte";
            // 
            // NudBreedte
            // 
            this.NudBreedte.Location = new System.Drawing.Point(74, 55);
            this.NudBreedte.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudBreedte.Name = "NudBreedte";
            this.NudBreedte.Size = new System.Drawing.Size(120, 20);
            this.NudBreedte.TabIndex = 4;
            this.NudBreedte.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LbSoort
            // 
            this.LbSoort.FormattingEnabled = true;
            this.LbSoort.Items.AddRange(new object[] {
            "Gekoeld",
            "Waardevol",
            "Normaal"});
            this.LbSoort.Location = new System.Drawing.Point(34, 23);
            this.LbSoort.Name = "LbSoort";
            this.LbSoort.Size = new System.Drawing.Size(120, 95);
            this.LbSoort.TabIndex = 5;
            // 
            // BtnToevoegenContainer
            // 
            this.BtnToevoegenContainer.Location = new System.Drawing.Point(34, 192);
            this.BtnToevoegenContainer.Name = "BtnToevoegenContainer";
            this.BtnToevoegenContainer.Size = new System.Drawing.Size(120, 23);
            this.BtnToevoegenContainer.TabIndex = 6;
            this.BtnToevoegenContainer.Text = "Invoegen";
            this.BtnToevoegenContainer.UseVisualStyleBackColor = true;
            this.BtnToevoegenContainer.Click += new System.EventHandler(this.BtnToevoegenContainer_Click);
            // 
            // NUDcontainer
            // 
            this.NUDcontainer.Location = new System.Drawing.Point(34, 151);
            this.NUDcontainer.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.NUDcontainer.Minimum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.NUDcontainer.Name = "NUDcontainer";
            this.NUDcontainer.Size = new System.Drawing.Size(120, 20);
            this.NUDcontainer.TabIndex = 7;
            this.NUDcontainer.Value = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            // 
            // LbContainers
            // 
            this.LbContainers.FormattingEnabled = true;
            this.LbContainers.Location = new System.Drawing.Point(961, 81);
            this.LbContainers.Name = "LbContainers";
            this.LbContainers.Size = new System.Drawing.Size(271, 290);
            this.LbContainers.TabIndex = 8;
            this.LbContainers.SelectedIndexChanged += new System.EventHandler(this.LbContainers_SelectedIndexChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(57, 466);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(458, 134);
            this.listBox1.TabIndex = 9;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(756, 455);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(459, 147);
            this.listBox2.TabIndex = 10;
            // 
            // btnIndelen
            // 
            this.btnIndelen.Location = new System.Drawing.Point(477, 309);
            this.btnIndelen.Name = "btnIndelen";
            this.btnIndelen.Size = new System.Drawing.Size(75, 23);
            this.btnIndelen.TabIndex = 11;
            this.btnIndelen.Text = "Indelen";
            this.btnIndelen.UseVisualStyleBackColor = true;
            this.btnIndelen.Click += new System.EventHandler(this.BtnIndelen_Click);
            // 
            // btnWegvaren
            // 
            this.btnWegvaren.Location = new System.Drawing.Point(702, 308);
            this.btnWegvaren.Name = "btnWegvaren";
            this.btnWegvaren.Size = new System.Drawing.Size(75, 23);
            this.btnWegvaren.TabIndex = 12;
            this.btnWegvaren.Text = "Wegvaren";
            this.btnWegvaren.UseVisualStyleBackColor = true;
            this.btnWegvaren.Click += new System.EventHandler(this.BtnWegvaren_Click);
            // 
            // btnmaakveelcontainers
            // 
            this.btnmaakveelcontainers.Location = new System.Drawing.Point(34, 289);
            this.btnmaakveelcontainers.Name = "btnmaakveelcontainers";
            this.btnmaakveelcontainers.Size = new System.Drawing.Size(75, 23);
            this.btnmaakveelcontainers.TabIndex = 13;
            this.btnmaakveelcontainers.Text = "button1";
            this.btnmaakveelcontainers.UseVisualStyleBackColor = true;
            this.btnmaakveelcontainers.Click += new System.EventHandler(this.Btnmaakveelcontainers_Click);
            // 
            // Aantalcontainers
            // 
            this.Aantalcontainers.Location = new System.Drawing.Point(34, 253);
            this.Aantalcontainers.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.Aantalcontainers.Name = "Aantalcontainers";
            this.Aantalcontainers.Size = new System.Drawing.Size(120, 20);
            this.Aantalcontainers.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NudLengte);
            this.groupBox1.Controls.Add(this.BtnSchip);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.NudBreedte);
            this.groupBox1.Location = new System.Drawing.Point(530, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 114);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LbSoort);
            this.groupBox2.Controls.Add(this.BtnToevoegenContainer);
            this.groupBox2.Controls.Add(this.Aantalcontainers);
            this.groupBox2.Controls.Add(this.NUDcontainer);
            this.groupBox2.Controls.Add(this.btnmaakveelcontainers);
            this.groupBox2.Location = new System.Drawing.Point(72, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 324);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // btnCheckBalans
            // 
            this.btnCheckBalans.Location = new System.Drawing.Point(583, 378);
            this.btnCheckBalans.Name = "btnCheckBalans";
            this.btnCheckBalans.Size = new System.Drawing.Size(84, 23);
            this.btnCheckBalans.TabIndex = 17;
            this.btnCheckBalans.Text = "checkBalans";
            this.btnCheckBalans.UseVisualStyleBackColor = true;
            this.btnCheckBalans.Click += new System.EventHandler(this.BtnCheckBalans_Click);
            // 
            // Hoofdpagina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1278, 657);
            this.Controls.Add(this.btnCheckBalans);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnWegvaren);
            this.Controls.Add(this.btnIndelen);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.LbContainers);
            this.Name = "Hoofdpagina";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.NudLengte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudBreedte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDcontainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Aantalcontainers)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnSchip;
        private System.Windows.Forms.NumericUpDown NudLengte;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown NudBreedte;
        private System.Windows.Forms.ListBox LbSoort;
        private System.Windows.Forms.Button BtnToevoegenContainer;
        private System.Windows.Forms.NumericUpDown NUDcontainer;
        private System.Windows.Forms.ListBox LbContainers;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button btnIndelen;
        private System.Windows.Forms.Button btnWegvaren;
        private System.Windows.Forms.Button btnmaakveelcontainers;
        private System.Windows.Forms.NumericUpDown Aantalcontainers;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCheckBalans;
    }
}

