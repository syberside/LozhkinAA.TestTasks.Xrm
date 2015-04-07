using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LozhkinAA.TestTasks.Xrm.Annotations.DataAccess.Models;
using LozhkinAA.TestTasks.Xrm.Annotations.DataAccess.Services.Abstract;

namespace LozhkinAA.TestTasks.Xrm.Annotations.Viewer
{
    /// <summary>
    ///     Main application form
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly IAnnotationDetailsViewService _viewService;

        /// <summary>
        ///     This ctor should be used only by visual designer.
        /// </summary>
        [Obsolete("Designer only", true)]
        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(IAnnotationDetailsViewService viewService)
        {
            if (viewService == null)
            {
                throw new ArgumentNullException("viewService");
            }
            //constructor injection
            _viewService = viewService;
            InitializeComponent();
            statusLabel.Text = "To load annotations press \"Update\" button";
        }

        private async void bUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                bUpdate.Enabled = false;
                statusLabel.Text = "Loading annotations...";
                AnnotationDescription[] data = null;
                await Task.Run(() => { data = _viewService.All().ToArray(); });
                dgwCommits.DataSource = data;
                statusLabel.Text = "To reload annotations press \"Update\" button";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
            finally
            {
                bUpdate.Enabled = true;
            }
        }
    }
}
