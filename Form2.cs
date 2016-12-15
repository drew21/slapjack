using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Media;
using System.Windows.Forms;
using System.IO;



namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        private SoundPlayer Sound1;
        private Deck deck;
        private PictureBox[] dealCards, p1Cards, p2Cards, p3Cards, p4Cards;
        private List<Card> dcards, p1cards, p2cards, p3cards, p4cards;
        private int timer, score, players;
        private Player p1, p2, p3, p4;
        private bool slapClicked;

        //return the current deck
        //public Deck CurrentDeck { get { return deck; } }
        //constructor
        public Form2()
        {
            InitializeComponent();
            Sound1 = new SoundPlayer("../../Resources/button-30.wav");
            setUpNewGame();
            LoadCardSkinImages();
            timer1.Enabled = false;
            slapClicked = false;
            
        }
  
     
        /// </summary>
        private void setUpNewGame()
        {
            pictureBox2.ImageLocation = Properties.Settings.Default.PlayerImage;
            pictureBox2.Visible = true;
            lblPlayer1.Text = Properties.Settings.Default.PlayerName;
            players = 2;

            if (Properties.Settings.Default.NumberPlayers > 2)
            {
                pictureBox4.Visible = true;
                lblPlayer3.Visible = true;
                label3.Visible = true;
                txtScore3.Visible = true;
                p3PicBox.Visible = true;
                pl3pb1.Visible = true;
                pl3pb2.Visible = true;
                pl3pb3.Visible = true;
                p3 = new Player();
                players = 3;
            }

            if (Properties.Settings.Default.NumberPlayers > 3)
            {
                pictureBox5.Visible = true;
                lblPlayer4.Visible = true;
                label4.Visible = true;
                txtScore4.Visible = true;
                p4PicBox.Visible = true;
                pl4pb1.Visible = true;
                pl4pb2.Visible = true;
                pl4pb3.Visible = true;
                p4 = new Player();
                players = 4;
            }
        }

        private void LoadCardSkinImages()
        {
            try
            {
                // Load the card skin image from file
                Image cardSkin = Image.FromFile(Properties.Settings.Default.CardGameImageSkinPath);
                // Set the three cards on the UI to the card skin image
                pictureBox1.Image = cardSkin;
                p1PicBox.Image = cardSkin;
                p2PicBox.Image = cardSkin;
                p3PicBox.Image = cardSkin;
                p4PicBox.Image = cardSkin;
                pl1pb1.Image = cardSkin;
                pl1pb2.Image = cardSkin;
                pl1pb3.Image = cardSkin;
                pl2pb1.Image = cardSkin;
                pl2pb2.Image = cardSkin;
                pl2pb3.Image = cardSkin;
                pl3pb1.Image = cardSkin;
                pl3pb2.Image = cardSkin;
                pl3pb3.Image = cardSkin;
                pl4pb1.Image = cardSkin;
                pl4pb2.Image = cardSkin;
                pl4pb3.Image = cardSkin;
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show("Card skin images are not loading correctly.  Make sure the card skin images are in the correct location.");
            }
            dealCards = new PictureBox[52];
            p1Cards = new PictureBox[] { pl1pb3, pl1pb2, pl1pb1, p1PicBox };
            p2Cards = new PictureBox[] {p2PicBox, pl2pb1, pl2pb2, pl2pb3 };
            p3Cards = new PictureBox[] { p3PicBox, pl3pb1, pl3pb2, pl3pb3 };
            p4Cards = new PictureBox[] { p4PicBox, pl4pb1, pl4pb2, pl4pb3 };
            for (int i = 0; i < 52; i++)
                dealCards[i] = pictureBox1;
          
        }

        /// <summary>
        /// Takes the card value and loads the corresponding card image from file
        /// </summary>
        /// <param name="pb"></param>
        /// <param name="c"></param>
        private void LoadCard(PictureBox pb, Card c)
        {
            try
            {
                StringBuilder image = new StringBuilder();

                switch (c.Suit)
                {
                    case Suit.Diamonds:
                        image.Append("di");
                        break;
                    case Suit.Hearts:
                        image.Append("he");
                        break;
                    case Suit.Spades:
                        image.Append("sp");
                        break;
                    case Suit.Clubs:
                        image.Append("cl");
                        break;
                }

                switch (c.FaceVal)
                {
                    case FaceValue.Ace:
                        image.Append("1");
                        break;
                    case FaceValue.King:
                        image.Append("k");
                        break;
                    case FaceValue.Queen:
                        image.Append("q");
                        break;
                    case FaceValue.Jack:
                        image.Append("j");
                        break;
                    case FaceValue.Ten:
                        image.Append("10");
                        break;
                    case FaceValue.Nine:
                        image.Append("9");
                        break;
                    case FaceValue.Eight:
                        image.Append("8");
                        break;
                    case FaceValue.Seven:
                        image.Append("7");
                        break;
                    case FaceValue.Six:
                        image.Append("6");
                        break;
                    case FaceValue.Five:
                        image.Append("5");
                        break;
                    case FaceValue.Four:
                        image.Append("4");
                        break;
                    case FaceValue.Three:
                        image.Append("3");
                        break;
                    case FaceValue.Two:
                        image.Append("2");
                        break;
                }

                image.Append(Properties.Settings.Default.CardGameImageExtension);
                string cardGameImagePath = Properties.Settings.Default.CardGameImagePath;
                string cardGameImageSkinPath = Properties.Settings.Default.CardGameImageSkinPath;
                image.Insert(0, cardGameImagePath);
                //check to see if the card should be faced down or up;
                if (!c.IsCardUp)
                    image.Replace(image.ToString(), cardGameImageSkinPath);

                pb.Image = new Bitmap(image.ToString());
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Card images are not loading correctly.  Make sure all card images are in the right location.");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Load the card skin image from file
            //Image topDeck = Image.FromFile(Properties.Settings.Default.DefaultDeckImage);
            //pictureBox1.Image = topDeck;
            
        }

        private void pl1pb3_Click(object sender, EventArgs e)
        {
            // Load the card skin image from file
            Image topDeck1 = Image.FromFile(Properties.Settings.Default.DefaultDeckImage);
            pl1pb3.Image = topDeck1;
            //pl1pb3.Left = pl1pb3.Left + 20;
            //pl1pb3.Top = pl1pb3.Top - 20;

        }

      
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        
        

        /*exits the game back to the main form*/
        private void butEndGame_Click(object sender, EventArgs e)
        {

            // play click sound
            Sound1.Play();   
               
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblPlayer1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {

        }

        private void reset()
        {
           for(int i = 0; i < 4; i++)
           {
               Image cardSkin = Image.FromFile(Properties.Settings.Default.CardGameImageSkinPath);
                p1Cards[i].Image = cardSkin;
                p2Cards[i].Image = cardSkin;
                p3Cards[i].Image = cardSkin;
                p4Cards[i].Image = cardSkin;
           }

             //intialize to first element of array
             timer = 0;
             score = 0;

             txtScore.Text = "0";
             txtScore2.Text = "0";
             txtScore3.Text = "0";
             txtScore4.Text = "0";

             // creating player's one and two
             p1 = new Player();
             p2 = new Player();

             // creating new deck of cards, shuffling and dealing then to an array
             deck = new Deck();
             deck.Shuffle();
             deck.Deal();
        }
        private void newGamebut_Click(object sender, EventArgs e)
        {

            reset();
            // play click sound
            Sound1.Play();                    
            dcards = deck.Cards;
            timer1.Enabled = true;

       
            
            
        }

        //timer to deal cards one at a time
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (timer != 52)
            {
                //this takes the card and displays the image of the card to screen
                LoadCard(dealCards[timer], dcards[timer]);
                Console.WriteLine(dcards[timer]);
                Console.WriteLine(p1.Score);

                timer++;
                score++;
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                int checkJack2 = (int)dcards[timer - 1].FaceVal;
                if (checkJack2 == 11 && !slapClicked)
                {
                    Random random = new Random();
                    int rand = random.Next(2, players);
                    string tmp = Convert.ToString(rand);
                    string p = "txtScore";
                    p = p + tmp;

                    if (String.Compare(p, "txtScore2") == 0)
                    {
                        p2.Score += score;
                        string p2Score = Convert.ToString(p2.Score);
                        txtScore2.Text = p2Score;
                    }

                    else if (String.Compare(p, "txtScore3") == 0)
                    {
                        p3.Score += score;
                        string p3Score = Convert.ToString(p3.Score);
                        txtScore3.Text = p3Score;
                    }

                    else
                    {
                        p4.Score += score;
                        string p4Score = Convert.ToString(p4.Score);
                        txtScore4.Text = p4Score;
                    }
                    score = 0;
                    slapClicked = false;
                }
                //dealCards[i].Visible = true;
                // dealCards[i].BringToFront();
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            }
            else            //game is over cards are all delt
            {
                timer1.Enabled = false;

                if (players == 2)
                {
                  if (p1.Score > p2.Score)  //2 players
                    {
                        MessageBox.Show("PLAYER 1 IS THE WINNER!"); //output p1 is winner
                    }
                   else if ((p1.Score == p2.Score) && (p1.Score != 0))   /// not likely but could happen
                    {
                        MessageBox.Show("IT'S A TIE!"); //output its a tie
                    }
                }
                else if (players == 3) //3 players
                {
                       if ((p1.Score > p2.Score) && (p1.Score > p3.Score))
                           MessageBox.Show("PLAYER 1 IS THE WINNER!"); //output p1 is winner
                       else if ((p1.Score == p2.Score) && (p1.Score == p3.Score) && (p2.Score == p3.Score) && (p1.Score != 0))   /// not likely but could happen
                           MessageBox.Show("IT'S A TIE!"); //output its a tie
                       else if (p2.Score > p3.Score)
                           MessageBox.Show("PLAYER 2 IS THE WINNER!"); //output p2 is winner
                       else
                             MessageBox.Show("PLAYER 3 IS THE WINNER!"); //output p3 is winner
                }
                else if (players == 4)  //players = 4
                {
                      if ((p1.Score > p2.Score) && (p1.Score > p3.Score)&& (p1.Score > p4.Score)) 
                           MessageBox.Show("PLAYER 1 IS THE WINNER!"); //output p1 is winner
                      else if ((p1.Score == p2.Score) && (p1.Score == p3.Score) && (p1.Score == p4.Score) && (p2.Score == p3.Score)  && (p2.Score == p4.Score) && (p3.Score == p4.Score) && (p1.Score != 0))   /// not likely but could happen
                          MessageBox.Show("IT'S A TIE!"); //output its a tie
                       else if ((p2.Score > p3.Score) && (p2.Score > p4.Score))
                           MessageBox.Show("PLAYER 2 IS THE WINNER!"); //output p2 is winner
                       else if (p3.Score > p4.Score)
                             MessageBox.Show("PLAYER 3 IS THE WINNER!"); //output p3 is winner
                      else
                          MessageBox.Show("PLAYER 4 IS THE WINNER!"); //output p4 is winner
                }
            
            }
           }

        private void butPause_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                timer1.Enabled = false;
                butPause.Text = "Unpause";
                //Console.WriteLine("Paused");
            }
            else 
            {
                timer1.Enabled = true;
                butPause.Text = "Pause";
            }
        }

        private void but_Slap_Click(object sender, EventArgs e)
        {
            // play click sound
            slapClicked = true;
            Sound1.Play();
            Console.WriteLine("Slap  ");
            int checkJack = (int)dcards[timer-1].FaceVal;
            if (checkJack == 11) ///card is a jack
            {
                // Console.WriteLine(dcards[timer]);
                // if(dcards[timer] == "JackofHearts");
                Console.WriteLine("You just won");

                if (timer >= 4)
                {
                    int j = timer - 1;
                    for (int i = 0; i < 4; i++)
                    {
                        LoadCard(p1Cards[i], dcards[j]);
                        j--;
                    }
                }
                else
                {
                    int k = timer - 1;
                    for (int i = 0; i < timer; i++)
                    {
                        LoadCard(p1Cards[i], dcards[k]);
                        k--;
                    }
                }
                p1.Score += score;
                string p1Score = Convert.ToString(p1.Score);
                txtScore.Text = p1Score;
                score = 0;
                

            }
            else
            {

                for(int i = 0; i < 4; i++)
                {
                    Image cardSkin = Image.FromFile(Properties.Settings.Default.CardGameImageSkinPath);
                    p1Cards[i].Image = cardSkin;
                    p2Cards[i].Image = cardSkin;
                    p3Cards[i].Image = cardSkin;
                    p4Cards[i].Image = cardSkin;
                }

                if (p1.Score == 0)
                {
                    MessageBox.Show("YOU LOSE CLICK ON NEW GAME TO START AGAIN");
                    timer = 52;
                }
                score += p1.Score;
                p1.Score = 0;
                Console.WriteLine("You just lost");
                string p1Score = Convert.ToString(p1.Score);
                txtScore.Text = p1Score;
            }



            //slapClicked = false;
        }

      
       

     

       
    }
}
