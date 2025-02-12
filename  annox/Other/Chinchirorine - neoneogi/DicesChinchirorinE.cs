//Chinchirorin is a dice game in which 3 die are rolled into a bowl to determine
//an outcome of a wager. All wagers on Triple Triad Extreme's version of Chinchirorin
//is based on active points and the wager itself may not be more than 1/3rd of their
//total active points.
//
//How to Play:
//
//One person will create a table with an initial AP wager. The opponent will join
//the table and will have to match the AP wager before the game can begin. A random
//player is selected to start and will be given the option to roll three times to
//initiate a storm or make a pair to gain points. Depending on the outcome of the
//rolls, the opponent will then get three rolls to beat their opponent's score.

//Dice Rules:

//If two dice are the same value, the third die is the score for the roll. The turn immediately ends.
//1, 1, 1 = Storm (bad) - Roller loses 3x his bet. Game ends.
//Any three of a kind except 1s - Storm (good) - Roller wins 3x his bet. Game ends.
//1, 2, 3 = Low Run (bad) - Roller loses 2x his bet. Game ends.
//4, 5, 6 = High Run (good) - Roller wins 2x his bet. Game ends.

using System;
using Server;
using Server.Network;
using System.IO;
using Server.Gumps;
using Server.Commands;

namespace Server.Items
{
	public class DicesChinchirorinE : Item
	{
		[Constructable]
		public DicesChinchirorinE() : base( 0xFA7 )
		{
			Weight = 1.0;
		}

		public DicesChinchirorinE( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( this.GetWorldLocation(), 2 ) )
				return;
			int dice1 = Utility.Random( 1, 6 );
			int dice2 = Utility.Random( 1, 6 );
			int dice3 = Utility.Random( 1, 6 );
			int dicetotal = dice1 + dice2 + dice3;
			
            this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format("*{0} 's turn. First Dice is [{1}] , One of Second Dice is [{2}] , Two of Second Dice is [{3}] *\n*Total is [{4}]*", from.Name, dice1, dice2, dice3, dicetotal));
			//Judge of Total
			//dice1,dice2 is equal or dice1,dice3 matched
			if ( ( dice1 == dice2 ) || ( dice1 == dice3 ) ) {
				//It judges at this stage. Deme or Zorome
				if(( dice1 == dice2 ) && ( dice2 == dice3 ) ) {
					//Zorome!
					this.PublicOverheadMessage( MessageType.Regular, 32, false, string.Format( "**Cool! You have Zorome!**") ) ;
				} else {
					if( dice1 == dice3 ){
						//dice2 is Deme
						this.PublicOverheadMessage( MessageType.Regular, 16, false, string.Format( "**Good! Deme is [{0}]!**",dice2) ) ;
					} else {
						//dice3 is Deme
						this.PublicOverheadMessage( MessageType.Regular, 16, false, string.Format( "**Good! Deme is [{0}]!**",dice3) ) ;
					}
				}
			} else {
			//Because dice1 is a value different from dice2 and dice3, it compares it by dice2 and dice3. 
				if( dice2 == dice3 ){
					//if Dice2 equals Dice3,It is Deme.
						this.PublicOverheadMessage( MessageType.Regular, 16, false, string.Format( "**Good! Deme is [{0}]!**",dice1) ) ;
				}
			}
			//123,456 Judge (we call "Hifumi","Jigoro"
			if( (dice1 * dice2 * dice3 )== 6){
				this.PublicOverheadMessage( MessageType.Regular, 16, false, string.Format( "**Wow! You Hit 'Hifumi'!**") ) ;
			}
			if( (dice1 * dice2 * dice3 )== 120){
				this.PublicOverheadMessage( MessageType.Regular, 16, false, string.Format( "**Wow! You Hit 'Jigoro'!**") ) ;
			}
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
