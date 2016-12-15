using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {
        private SoundPlayer Sound1;
        public Form1()
        {
            InitializeComponent();
            Sound1 = new SoundPlayer("../../Resources/button-30.wav");
        }

      
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        /*this loads the game form to start playing slapjack*/
        private void butStart_Click(object sender, EventArgs e)
        {

            Sound1.Play();
            if (NumPlayers.Value < 2)
                MessageBox.Show("Please select at least 2");
            else{
                    // Show the main SlapJack UI game
                    using (Form2 slapjackform = new Form2())
                    {
                        Hide();
                        slapjackform.ShowDialog();
                        Show();

                    }
                }
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            Sound1.Play();
            Application.Exit();
        }

        private void butRules_Click(object sender, EventArgs e)
        {
            Sound1.Play();
            TextReader reader = File.OpenText(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)+@"\Slapjack-manual.txt");
            Instructions iForm = new Instructions();
            
            iForm.setText( reader.ReadToEnd() );
            iForm.Visible = true;
          
        }
        
        /* lloads the optiond form for options the user can select from*/
        private void butOpt_Click(object sender, EventArgs e)
        {
            Sound1.Play();
            // Show the Options panel
            using (options optionsForm = new options())
            {
                Hide();
                optionsForm.ShowDialog();
                Show();
            }
        }

        private void NumPlayers_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.NumberPlayers = (int)NumPlayers.Value;
            
        }
       
    }
}
