using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace ScreenSaver
{
    class PictureHandling
    {
        private string[] pathToPictureFiles;
        private int quantityAllPicture = 0;
        private int numberCurrentPicture = 0;

        public PictureHandling()
        {

        }

        public void checkPictureExist ()
        {
            bool checkSomethingPictureIs = false;
            string pathToFolderOfPictures = Application.StartupPath + "\\obrazki";
            try
            {
                pathToPictureFiles = Directory.GetFiles(pathToFolderOfPictures);
                quantityAllPicture = pathToPictureFiles.Length;
            }
            catch
            {
                MessageBox.Show("Brak katalogu \"obrazki\" w katalogu z programem", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            if (quantityAllPicture == 0)
            {
                MessageBox.Show("Brak plików w katalogu \"obrazki\"", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            do
            {
                try
                {
                    Form1.ActiveForm.BackgroundImage = Image.FromFile(pathToPictureFiles[numberCurrentPicture++]);
                    checkSomethingPictureIs = true;
                    break;
                }
                catch { }
            } while (numberCurrentPicture < quantityAllPicture);
            if (!checkSomethingPictureIs)
            {
                MessageBox.Show("Katalog nie zawiera plików graficznych.", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        public void pictureShow ()
        {
            if (numberCurrentPicture >= quantityAllPicture)
            {
                numberCurrentPicture = 0;
            }
            do
            {
                try
                {
                    Form1.ActiveForm.BackgroundImage = Image.FromFile(pathToPictureFiles[numberCurrentPicture++]);
                    break;
                }
                catch
                {
                    if (numberCurrentPicture == quantityAllPicture - 1)
                    {
                        numberCurrentPicture = 0;
                        break;
                    }
                }
            } while (numberCurrentPicture < quantityAllPicture);
        }
        public void loadFirstPicture (Form currentForm)
        {
            if (numberCurrentPicture >= quantityAllPicture)
            {
                numberCurrentPicture = 0;
            }
            try
            {
                currentForm.BackgroundImage = Image.FromFile(pathToPictureFiles[numberCurrentPicture++]);
            }
            catch
            {
                if (numberCurrentPicture == quantityAllPicture - 1)
                {
                    numberCurrentPicture = 0;
                }
            }
        }
    }
}
