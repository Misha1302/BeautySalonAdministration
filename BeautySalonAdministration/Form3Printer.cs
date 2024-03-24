using System.Drawing.Printing;

namespace BeautySalonAdministration
{
    public class Form3Printer
    {
        private PrintDocument printDocument1 = new PrintDocument();
        Bitmap memoryImage;

        public Form3Printer(DataGridView table)
        {
            printDocument1.PrintPage += printDocument1_PrintPage;
            _table = table;
        }

        private DataGridView _table;

        public void Print()
        {
            CaptureScreen();
            printDocument1.Print();
        }

        private void CaptureScreen()
        {
            memoryImage = new Bitmap(_table.Width + 15, _table.Height + 15, _table.CreateGraphics());

            var b = _table.Bounds;
            b.Width += 15;
            b.Height += 15;
            _table.DrawToBitmap(memoryImage, b);
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }
    }
}
