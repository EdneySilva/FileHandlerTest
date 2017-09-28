using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DotNetTest.IO;
using DotNetTest.Extensions;
using DotNetTest.Parsers;
using DotNetTest.Validators;
using DotNetTest.Parsers.Validators;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DotNetTest.Filters;
using System.Diagnostics;

namespace DotNetTest
{
    public partial class FrmMain : Form
    {
        private const string fileName = "C:\\ArquivoLeitura\\File.txt";
        IFileHandler FileHandler { get; set; }
        ColumnFilter ColumnFilter { get; set; }

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            ConfigureFileHandler()
            .ConfigureColumnFilter()
                .LoadFileHandler();
        }

        private void btnLeitura_Click(object sender, EventArgs e)
        {
            var data = FilterData();
            Task task = new Task(() =>
            {
                var folder = "C:\\ArquivosGerados\\";
                var file = $"{folder}{DateTime.Now.ToString("ddMMyyyyHHmmssfff")}.txt";
                var writeTask = FileHandler.WriteAllDataAsync(file, data);
                writeTask.Wait();
                writeTask.Result.OnFail(this, (ctx, ex) =>
                {
                    MessageBox.Show($"Não foi possível criar o arquivo '{file}', ocorreram os seguintes erros:\n{ex.Message}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }).OnSuccess((ctx, result) =>
                {
                    MessageBox.Show($"O arquivo '{file}' foi criado com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process.Start(folder);
                    return result;
                });                
            });
            task.Start();
        }

        private void btnPopularGrid_Click(object sender, EventArgs e)
        {
            int age = 0;
            int.TryParse(txtAge.Text, out age);
            dataGridView1.DataSourceAsync(FilterData());
        }

        private void LoadFileHandler()
        {
            FileHandler.Open(fileName).OnFail(this, (frm, ex) =>
            {
                MessageBox.Show(ex.Message, "Ops! Ocorreu um erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }).OnSuccess((frm, result) =>
            {
                this.dataGridView1.DataSourceAsync(result.ReadAsync());
                return true;
            });
        }

        private FrmMain ConfigureFileHandler()
        {
            FileHandler = new FileHandlerConfiguration()
                                    .UseParser<DefaultParser>()
                                    .AddValidator<FileExists>()
                                    .AddParsing<NumericColumns>(new[] { new[] { "NUM", "CEP" } })
                                    .AddParsing<DateColumn>(new[] { new[] { "DTNASC" } })
                                    .AddParsing<DocumentColumn>(new[] { new[] { "DOCUMENTO" } })
                                    .AddParsing<SimpleTextColumn>(new[] { new[] { "NOME", "ENDERECO", "BAIRRO", "CIDADE", "PAI", "MAE" } })
                                    .AddParsing<SimpleLowerTextColumn>(new[] { new[] { "COMP" } })
                                .Build();
            return this;
        }

        private FrmMain ConfigureColumnFilter()
        {
            ColumnFilter = new ColumnFilter()
                .ConfigureVisibility("DOCUMENTO", () => chkDocumento.Checked)
                .ConfigureVisibility("DTNASC", () => chkDtNasc.Checked)
                .ConfigureVisibility("NOME", () => chkNome.Checked)
                .ConfigureVisibility("ENDERECO", () => chkEndereco.Checked)
                .ConfigureVisibility("NUM", () => chkNumero.Checked)
                .ConfigureVisibility("COMP", () => chkComplemento.Checked)
                .ConfigureVisibility("BAIRRO", () => chkBairro.Checked)
                .ConfigureVisibility("CIDADE", () => chkCidade.Checked)
                .ConfigureVisibility("CEP", () => chkCep.Checked)
                .ConfigureVisibility("PAI", () => chkPai.Checked)
                .ConfigureVisibility("MAE", () => chkMae.Checked);
            return this;
        }

        private Task<DataTable> FilterData()
        {
            int age = 0;
            int.TryParse(txtAge.Text, out age);
            return FileHandler.Read().FilterAsync(
                new FilterAge().Column("DTNASC").Is(cbxFilterType.SelectedItem?.ToString()).Than(age).Build(),
                ColumnFilter?.Build()
            );
        }
    }
}
