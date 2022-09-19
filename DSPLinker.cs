namespace DSPLinker
{
    public partial class DSPLinker : Form
    {
        static string defaultPath = "C:\\Users\\wu\\Documents\\Dyson Sphere Program\\Blueprint";
        string openFileName = string.Empty;
        string saveFileName = string.Empty;
        BlueprintData blueprintData;
        LinkInfo linkInfo;
        public DSPLinker()
        {
            InitializeComponent();
        }

        private void openMenuItemClicked(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = defaultPath;
            ofd.Filter = "DSP Blueprint File(.txt)|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                openFileName = ofd.FileName;
            }
            try
            {
                blueprintData = Utils.OpenFile(openFileName);
                linkInfo = new LinkInfo();
                textBox.AppendText("choose blueprint file: " + openFileName + "\r\n");
            }
            catch (Exception exc)
            {
                textBox.AppendText("open file exception: " + exc.Message + "\r\n");
            }
        }

        private void DSPLinker_Load(object sender, EventArgs e)
        {

        }

        private void analyzeBlueprint(object sender, EventArgs e)
        {
            try
            {
                linkInfo = new LinkInfo();
                linkInfo.AnalyzeLink(blueprintData);
                textBox.AppendText("analyzed link information of blueprint\r\n");
            }
            catch(Exception exc)
            {
                textBox.AppendText("analyze exception: " + exc.Message + "\r\n");
            }
        }

        private void linkBlueprint(object sender, EventArgs e)
        {
            try
            {
                textBox.AppendText(linkInfo.Link(blueprintData));
                textBox.AppendText("relink blueprint\r\n");
            }
            catch (Exception exc)
            {
                textBox.AppendText("relink exception: " + exc.Message + "\r\n");
            }
        }

        private void saveMenuClicked(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "DSP Blueprint Data(.txt)|*.txt";
            sfd.InitialDirectory = defaultPath;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                saveFileName = sfd.FileName;
            }
            try
            {
                Utils.SaveFile(saveFileName, blueprintData);
                textBox.AppendText("save blueprint data: " + saveFileName + "\r\n");
            }
            catch (Exception exc)
            {
                textBox.AppendText("save blueprint exception: " + exc.Message + "\r\n");
            }
        }

        private void showSorters(object sender, EventArgs e)
        {
            try
            {
                string log = Auxiliary.SorterStatus(blueprintData);
                textBox.AppendText(log);
            }
            catch (Exception exc)
            {
                textBox.AppendText("show sorter excetpion: " + exc.Message + "\r\n");
            }
        }

        private void showMarers(object sender, EventArgs e)
        {
            try
            {
                string log = Auxiliary.BeltMarker(blueprintData);
                textBox.AppendText(log);
            }
            catch (Exception exc)
            {
                textBox.AppendText("show marker exception: " + exc.Message + "\r\n");
            }
        }

        private void showBelts(object sender, EventArgs e)
        {
            try
            {
                string log = Auxiliary.Belts(linkInfo);
                textBox.AppendText(log);
            }
            catch (Exception exc)
            {
                textBox.AppendText("show belts exception: " + exc.Message + "\r\n");
            }
        }
    }
}