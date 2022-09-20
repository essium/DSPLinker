using DSPLinker.Database;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace DSPLinker
{
    public partial class DSPLinker : Form
    {
        Controller controller = new Controller();
        public DSPLinker()
        {
            InitializeComponent();
        }
        private void ShowLog(Func<string> action)
        {
            string log = action();
            textBox.AppendText(log);
        }
        private void DSPLinker_Load(object sender, EventArgs e)
        {

        }
        private void analyzeBlueprint(object sender, EventArgs e)
        {
            ShowLog(controller.AnalyzeBlueprint);
        }
        private void linkBlueprint(object sender, EventArgs e)
        {
            ShowLog(controller.LinkBlueprint);
        }
        private void Debug(object sender, EventArgs e)
        {
            controller.Debug();
        }
        private void Open(object sender, EventArgs e)
        {
            ShowLog(controller.OpenBlueprint);
        }

        private void Save(object sender, EventArgs e)
        {
            ShowLog(controller.SaveBlueprint);
        }
        private void ShowSorters(object sender, EventArgs e)
        {
            ShowLog(controller.ShowSorters);
        }

        private void ShowMarkers(object sender, EventArgs e)
        {
            ShowLog(controller.ShowMarkers);
        }

        private void ShowBelts(object sender, EventArgs e)
        {
            ShowLog(controller.ShowBelts);
        }
    }
}