//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

namespace WindowsFormsApplication1
{
   
        /// <summary>
        /// Player values
        /// </summary>
     
        public class Player
        {
            
        
            private int score;
            private Deck hand;
            
            public int Score { get { return score; } set { score = value; } }

            /// <summary>
            /// Constructor for a player create a score and deck to hold cards
            /// </summary>
            public Player()
            {
                this.score = 0;
                this.hand = new Deck();
                
            }

            /// <summary>
            /// Return the score
            /// </summary>
            /// <returns></returns>
            //public int returnScore()
            //{
            //    return this.score;
            //}
        }
}
