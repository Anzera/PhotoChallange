using PhotoChallange.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PhotoChallange
{
    public partial class Form1 : Form
    {
        public string PhotoPath
        {
            get
            {
                return Settings.Default.PhotoPath;
            }
            set
            {
                Settings.Default.PhotoPath = value;
            }
        }
        public Form1()
        {
            InitializeComponent();
            SetPhotoAtStart();
        }
        private void SetPhotoAtStart()
        {
            if (PhotoPath != "brak")
            {
                pbPicture.Image = Image.FromFile(PhotoPath);
                pbPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                RemoveBtnVisible(true);
            }
            else
                pbPicture.Image = null;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ChoosePicture(); 
        }

        private void ChoosePicture()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files(*.jpg;*.png;*.jpeg;*.bmp;*.gif)|*.jpg;*.png;*.jpeg;*.bmp;*.gif";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                pbPicture.Image = new Bitmap(openFile.FileName);
                pbPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                RemoveBtnVisible(true);
                SaveSettingsData(openFile.FileName);
            }    
        }

        private void SaveSettingsData(string data)
        {
            Settings.Default["PhotoPath"] = data;
            Settings.Default.Save();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            pbPicture.Image = null;
            SaveSettingsData("brak");
            RemoveBtnVisible(false); 
        }

        private void RemoveBtnVisible(bool btnVisible)
        {
            btnRemove.Visible = btnVisible;
            btnAdd.Visible = !btnVisible;
        }
    }
}
