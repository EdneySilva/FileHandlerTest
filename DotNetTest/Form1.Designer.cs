namespace DotNetTest
{
    partial class FrmMain
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
            this.btnLeitura = new System.Windows.Forms.Button();
            this.btnPopularGrid = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.cbxFilterType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkDocumento = new System.Windows.Forms.CheckBox();
            this.chkDtNasc = new System.Windows.Forms.CheckBox();
            this.chkNome = new System.Windows.Forms.CheckBox();
            this.chkEndereco = new System.Windows.Forms.CheckBox();
            this.chkNumero = new System.Windows.Forms.CheckBox();
            this.chkComplemento = new System.Windows.Forms.CheckBox();
            this.chkBairro = new System.Windows.Forms.CheckBox();
            this.chkCidade = new System.Windows.Forms.CheckBox();
            this.chkCep = new System.Windows.Forms.CheckBox();
            this.chkPai = new System.Windows.Forms.CheckBox();
            this.chkMae = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLeitura
            // 
            this.btnLeitura.Location = new System.Drawing.Point(1083, 117);
            this.btnLeitura.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLeitura.Name = "btnLeitura";
            this.btnLeitura.Size = new System.Drawing.Size(171, 27);
            this.btnLeitura.TabIndex = 2;
            this.btnLeitura.Text = "Gerar Arquivo";
            this.btnLeitura.UseVisualStyleBackColor = true;
            this.btnLeitura.Click += new System.EventHandler(this.btnLeitura_Click);
            // 
            // btnPopularGrid
            // 
            this.btnPopularGrid.Location = new System.Drawing.Point(909, 116);
            this.btnPopularGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPopularGrid.Name = "btnPopularGrid";
            this.btnPopularGrid.Size = new System.Drawing.Size(168, 28);
            this.btnPopularGrid.TabIndex = 3;
            this.btnPopularGrid.Text = "Popular Grid";
            this.btnPopularGrid.UseVisualStyleBackColor = true;
            this.btnPopularGrid.Click += new System.EventHandler(this.btnPopularGrid_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 151);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1237, 315);
            this.dataGridView1.TabIndex = 4;
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(188, 37);
            this.txtAge.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(53, 22);
            this.txtAge.TabIndex = 5;
            // 
            // cbxFilterType
            // 
            this.cbxFilterType.FormattingEnabled = true;
            this.cbxFilterType.Items.AddRange(new object[] {
            ">",
            "<",
            ">=",
            "<=",
            "=",
            "<>"});
            this.cbxFilterType.Location = new System.Drawing.Point(77, 36);
            this.cbxFilterType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxFilterType.Name = "cbxFilterType";
            this.cbxFilterType.Size = new System.Drawing.Size(60, 24);
            this.cbxFilterType.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Idade";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Anos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(147, 41);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "que";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Filtros";
            // 
            // chkDocumento
            // 
            this.chkDocumento.AutoSize = true;
            this.chkDocumento.Location = new System.Drawing.Point(27, 87);
            this.chkDocumento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkDocumento.Name = "chkDocumento";
            this.chkDocumento.Size = new System.Drawing.Size(102, 21);
            this.chkDocumento.TabIndex = 11;
            this.chkDocumento.Text = "Documento";
            this.chkDocumento.UseVisualStyleBackColor = true;
            // 
            // chkDtNasc
            // 
            this.chkDtNasc.AutoSize = true;
            this.chkDtNasc.Location = new System.Drawing.Point(141, 87);
            this.chkDtNasc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkDtNasc.Name = "chkDtNasc";
            this.chkDtNasc.Size = new System.Drawing.Size(138, 21);
            this.chkDtNasc.TabIndex = 12;
            this.chkDtNasc.Text = "Data Nascimento";
            this.chkDtNasc.UseVisualStyleBackColor = true;
            // 
            // chkNome
            // 
            this.chkNome.AutoSize = true;
            this.chkNome.Location = new System.Drawing.Point(293, 87);
            this.chkNome.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkNome.Name = "chkNome";
            this.chkNome.Size = new System.Drawing.Size(67, 21);
            this.chkNome.TabIndex = 13;
            this.chkNome.Text = "Nome";
            this.chkNome.UseVisualStyleBackColor = true;
            // 
            // chkEndereco
            // 
            this.chkEndereco.AutoSize = true;
            this.chkEndereco.Location = new System.Drawing.Point(373, 87);
            this.chkEndereco.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkEndereco.Name = "chkEndereco";
            this.chkEndereco.Size = new System.Drawing.Size(91, 21);
            this.chkEndereco.TabIndex = 14;
            this.chkEndereco.Text = "Endereço";
            this.chkEndereco.UseVisualStyleBackColor = true;
            // 
            // chkNumero
            // 
            this.chkNumero.AutoSize = true;
            this.chkNumero.Location = new System.Drawing.Point(477, 87);
            this.chkNumero.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkNumero.Name = "chkNumero";
            this.chkNumero.Size = new System.Drawing.Size(80, 21);
            this.chkNumero.TabIndex = 15;
            this.chkNumero.Text = "Número";
            this.chkNumero.UseVisualStyleBackColor = true;
            // 
            // chkComplemento
            // 
            this.chkComplemento.AutoSize = true;
            this.chkComplemento.Location = new System.Drawing.Point(569, 87);
            this.chkComplemento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkComplemento.Name = "chkComplemento";
            this.chkComplemento.Size = new System.Drawing.Size(116, 21);
            this.chkComplemento.TabIndex = 16;
            this.chkComplemento.Text = "Complemento";
            this.chkComplemento.UseVisualStyleBackColor = true;
            // 
            // chkBairro
            // 
            this.chkBairro.AutoSize = true;
            this.chkBairro.Location = new System.Drawing.Point(697, 87);
            this.chkBairro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkBairro.Name = "chkBairro";
            this.chkBairro.Size = new System.Drawing.Size(68, 21);
            this.chkBairro.TabIndex = 17;
            this.chkBairro.Text = "Bairro";
            this.chkBairro.UseVisualStyleBackColor = true;
            // 
            // chkCidade
            // 
            this.chkCidade.AutoSize = true;
            this.chkCidade.Location = new System.Drawing.Point(776, 87);
            this.chkCidade.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkCidade.Name = "chkCidade";
            this.chkCidade.Size = new System.Drawing.Size(74, 21);
            this.chkCidade.TabIndex = 18;
            this.chkCidade.Text = "Cidade";
            this.chkCidade.UseVisualStyleBackColor = true;
            // 
            // chkCep
            // 
            this.chkCep.AutoSize = true;
            this.chkCep.Location = new System.Drawing.Point(863, 87);
            this.chkCep.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkCep.Name = "chkCep";
            this.chkCep.Size = new System.Drawing.Size(57, 21);
            this.chkCep.TabIndex = 19;
            this.chkCep.Text = "CEP";
            this.chkCep.UseVisualStyleBackColor = true;
            // 
            // chkPai
            // 
            this.chkPai.AutoSize = true;
            this.chkPai.Location = new System.Drawing.Point(933, 87);
            this.chkPai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkPai.Name = "chkPai";
            this.chkPai.Size = new System.Drawing.Size(50, 21);
            this.chkPai.TabIndex = 20;
            this.chkPai.Text = "Pai";
            this.chkPai.UseVisualStyleBackColor = true;
            // 
            // chkMae
            // 
            this.chkMae.AutoSize = true;
            this.chkMae.Location = new System.Drawing.Point(996, 87);
            this.chkMae.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkMae.Name = "chkMae";
            this.chkMae.Size = new System.Drawing.Size(57, 21);
            this.chkMae.TabIndex = 21;
            this.chkMae.Text = "Mãe";
            this.chkMae.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 65);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(532, 17);
            this.label5.TabIndex = 22;
            this.label5.Text = "Selecione as colunas que deseja visualizar no Grid e no arquivo gerado";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 481);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkMae);
            this.Controls.Add(this.chkPai);
            this.Controls.Add(this.chkCep);
            this.Controls.Add(this.chkCidade);
            this.Controls.Add(this.chkBairro);
            this.Controls.Add(this.chkComplemento);
            this.Controls.Add(this.chkNumero);
            this.Controls.Add(this.chkEndereco);
            this.Controls.Add(this.chkNome);
            this.Controls.Add(this.chkDtNasc);
            this.Controls.Add(this.chkDocumento);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxFilterType);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnPopularGrid);
            this.Controls.Add(this.btnLeitura);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmMain";
            this.Text = "Leitura/Geração de Arquivo";
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLeitura;
        private System.Windows.Forms.Button btnPopularGrid;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.ComboBox cbxFilterType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkDocumento;
        private System.Windows.Forms.CheckBox chkDtNasc;
        private System.Windows.Forms.CheckBox chkNome;
        private System.Windows.Forms.CheckBox chkEndereco;
        private System.Windows.Forms.CheckBox chkNumero;
        private System.Windows.Forms.CheckBox chkComplemento;
        private System.Windows.Forms.CheckBox chkBairro;
        private System.Windows.Forms.CheckBox chkCidade;
        private System.Windows.Forms.CheckBox chkCep;
        private System.Windows.Forms.CheckBox chkPai;
        private System.Windows.Forms.CheckBox chkMae;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

