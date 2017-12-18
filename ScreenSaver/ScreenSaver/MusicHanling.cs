using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using WMPLib;

namespace ScreenSaver
{
    class MusicHanling
    {
        string[] pathToMusicFiles;
        int quantityAllMusic = 0;

        WindowsMediaPlayer player = new WindowsMediaPlayer();
        IWMPPlaylist playList;
        IWMPMedia media;

        List<string> listOfDonePathToMusicFiles;

        public MusicHanling()
        {
            listOfDonePathToMusicFiles = new List<string>();
        }

        public void checkMusicExist()
        {
            bool checkSomethingMusicIs = false;
            string pathToFolderOfMusic = Application.StartupPath + "\\muzyka";
            try
            {
                pathToMusicFiles = Directory.GetFiles(pathToFolderOfMusic);
                quantityAllMusic = pathToMusicFiles.Length;
            }
            catch
            {
                MessageBox.Show("Brak katalogu \"muzyka\" w katalogu z programem", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            if (quantityAllMusic == 0)
            {
                MessageBox.Show("Brak plików w katalogu \"muzyka\"", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            try
            {
                string pattern = @"(.+\.mp3)";
                Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
                foreach (string singlePathToMusicFiles in pathToMusicFiles)
                {
                    Match match = rgx.Match(singlePathToMusicFiles);
                    if (match.Length > 0)
                    {
                        listOfDonePathToMusicFiles.Add(match.Value);
                        checkSomethingMusicIs = true;
                    }
                }
            }
            catch { }
            if (!checkSomethingMusicIs)
            {
                MessageBox.Show("Katalog nie zawiera plików mp3.", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        public void wmpHandling ()
        {
            playList = player.playlistCollection.newPlaylist("MyPlaylist");
            foreach(var pathToMusicFile in listOfDonePathToMusicFiles)
            {
                media = player.newMedia(pathToMusicFile);
                playList.appendItem(media);
            }
            player.currentPlaylist = playList;
            player.settings.setMode("loop", true);
            player.controls.play();
        }
    }
}
