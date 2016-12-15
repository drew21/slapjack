using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Media;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class options : Form
    {
        private SoundPlayer Sound1;
        public options()
        {
            InitializeComponent();
            Sound1 = new SoundPlayer("../../Resources/button-30.wav");
        }

        /*populates a list of images from file that a user can choose from*/
        private void options_Load(object sender, EventArgs e)
        {
            try
            {
                // Loads the player image from file and displays the image in the "preview" box
                PicBoxPreview.Image = Image.FromFile(Properties.Settings.Default.PlayerImage);
                // Loads the path name for the other images
                string image1 = Properties.Settings.Default.DefaultImage1;
                string image2 = Properties.Settings.Default.DefaultImage2;
                string image3 = Properties.Settings.Default.DefaultImage3;
                string image4 = Properties.Settings.Default.DefaultImage4;
                string image5 = Properties.Settings.Default.DefaultImage5;
                string image6 = Properties.Settings.Default.DefaultImage6;

                // Loads each image and displays it in the image list
                imageList1.Images.Add(image1, Image.FromFile(image1));
                listView1.Items.Add(image1, image1);

                imageList1.Images.Add(image2, Image.FromFile(image2));
                listView1.Items.Add(image2, image2);

                imageList1.Images.Add(image3, Image.FromFile(image3));
                listView1.Items.Add(image3, image3);

                imageList1.Images.Add(image4, Image.FromFile(image4));
                listView1.Items.Add(image4, image4);

                imageList1.Images.Add(image5, Image.FromFile(image5));
                listView1.Items.Add(image5, image5);

                imageList1.Images.Add(image6, Image.FromFile(image6));
                listView1.Items.Add(image6, image6);

                for (int i = 0; i < 6; i++)
                    listView1.Items[i].Text = "";
               
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show("Images did not load properly.  Verify that images are in the correct location");
            }
        }

        /*allows a player to select an image from list and applies as the user's picture*/
        private void PlayerimageList1_ItemActivate(object sender, EventArgs e)
        {
            // Selects an image from the image scroll list
            ListView.SelectedListViewItemCollection items = listView1.SelectedItems;
            Properties.Settings.Default.PlayerImage = items[0].ImageKey;
            PicBoxPreview.Image = Image.FromFile(Properties.Settings.Default.PlayerImage);
        }

        /*reloads default settings and closes form*/
        private void butCancel_Click(object sender, EventArgs e)
        {
            // play click sound
            Sound1.Play();
            Properties.Settings.Default.Reload();
            this.Close();
        }

        /* Saves settings to file and closes form*/
        private void butOK_Click(object sender, EventArgs e)
        {
            // play click sound
            Sound1.Play();
            // Saves the player name to the settings file
            Properties.Settings.Default.PlayerName = txtPlayerName.Text;
            // Saves the values in the setting file to be used in the game
            Properties.Settings.Default.Save();
            this.Close();
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
