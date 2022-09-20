using DSPLinker.Database;

namespace DSPLinker
{
    internal class Controller
    {
        private static string defaultPath = "C:\\Users\\wu\\Documents\\Dyson Sphere Program\\Blueprint";
        private string openFileName = string.Empty;
        private string saveFileName = string.Empty;
        private BlueprintData? blueprintData = null;
        private LinkInfo? linkInfo = null;
        private TextBox? textBox = null;

        public string OpenBlueprint()
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
                return "choose blueprint file: " + openFileName + "\r\n";
            }
            catch (Exception exc)
            {
                return "open file exception: " + exc.Message + "\r\n";
            }
        }

        public string SaveBlueprint()
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
                return "save blueprint data: " + saveFileName + "\r\n";
            }
            catch (Exception exc)
            {
                return "save blueprint exception: " + exc.Message + "\r\n";
            }
        }

        public string AnalyzeBlueprint()
        {
            try
            {
                linkInfo = new LinkInfo();
                linkInfo.AnalyzeLink(blueprintData);
                return "analyzed link information of blueprint\r\n";
            }
            catch (Exception exc)
            {
                return "analyze exception: " + exc.Message + "\r\n";
            }
        }

        public string LinkBlueprint()
        {
            try
            {
                return linkInfo.Link(blueprintData) + "relink blueprint\r\n";
            }
            catch (Exception exc)
            {
                return "relink exception: " + exc.Message + "\r\n";
            }
        }

        public string ShowSorters()
        {
            try
            {
                return Auxiliary.SorterStatus(blueprintData);
            }
            catch (Exception exc)
            {
                return "show sorter excetpion: " + exc.Message + "\r\n";
            }
        }

        public string ShowMarkers()
        {
            try
            {
                return Auxiliary.BeltMarker(blueprintData);
            }
            catch (Exception exc)
            {
                return "show marker exception: " + exc.Message + "\r\n";
            }
        }

        public string ShowBelts()
        {
            try
            {
                return Auxiliary.Belts(linkInfo);
            }
            catch (Exception exc)
            {
                return "show belts exception: " + exc.Message + "\r\n";
            }
        }

        public void Debug()
        {
            Database.LDB.GetItem(1001);
        }
    }
}
