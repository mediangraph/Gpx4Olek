using GpxEditor.Backend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GpxEditor
{
    public partial class MainWindow : Form
    {
        private Engine _engine;
        public MainWindow()
        {
            InitializeComponent();
            _engine = new Engine();
        }

        private async void bt_Generate_Click(object sender, EventArgs e)
        { 
            var gpxDir = tb_ChooseDir.Text;
            var outGpxDir = tb_Output.Text;
            if (_engine.ValidatePath(gpxDir) && _engine.ValidateOrCreatePath(outGpxDir))
            {
                foreach (var path in Directory.EnumerateFiles(gpxDir).Where(x => Path.GetExtension(x) == ".gpx"))
                {
                   var t = Task.Run( () =>
                   {
                       _engine.EditGpxFile(path, Path.Combine(outGpxDir, Path.GetFileName(path)));
                       UpdateConsole(_engine.Message);
                   });
                }
            }
        }

        private void UpdateConsole(ConsoleMessage msg)
        {
            tb_Console.ForeColor = msg.isError ? Color.Red : Color.Black;
            this.Invoke(new MethodInvoker(() => tb_Console.Text += $"{Environment.NewLine}{msg.MessageText}{Environment.NewLine}"));
        }

        private void bt_Browse_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    tb_ChooseDir.Text = fbd.SelectedPath;
                }
            }
        }

        private void bt_BrowseOutput_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    tb_Output.Text = fbd.SelectedPath;
                }
            }
        }

        private void tb_ChooseDir_Leave(object sender, EventArgs e)
        {
            var outputFolder = $"Edited_{_engine.GetTimestamp()}";
            if (!string.IsNullOrWhiteSpace(tb_ChooseDir.Text))
            {
                tb_Output.Text = Path.Combine(tb_ChooseDir.Text, outputFolder);
            }
        }
    }
}
