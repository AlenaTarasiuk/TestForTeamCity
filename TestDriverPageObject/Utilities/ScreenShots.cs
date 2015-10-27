using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;

namespace AutomatedTest.Utilities
{
    public class ScreenShots
    {
        public static void ScreenShot()
        {
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }
                DateTime thisDay = DateTime.Today;
                string data = thisDay.ToString("d");
                string ingName = "..//..//Screenshots//screenshots" + bitmap.GetHashCode() + ".jpg";
                bitmap.Save(ingName, ImageFormat.Jpeg);
                Thread.Sleep(2000);
            }
        }
    }
}
