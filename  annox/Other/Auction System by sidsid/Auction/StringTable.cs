using System;
using System.Collections;

namespace Arya.Auction
{
	/// <summary>
	/// Provides access to localized text used by the system
	/// </summary>
	public class StringTable
	{
		private Hashtable m_Table;

		public StringTable()
		{
			m_Table = new Hashtable();
			m_Table.Add( 0, "Auction Delivery Service" );
			m_Table.Add( 1, "Delivering..." );
			m_Table.Add( 2, "Place the gold in your bank" );
			m_Table.Add( 3, "Place the item in your bank" );
			m_Table.Add( 4, "Item" );
			m_Table.Add( 5, "Gold" );
			m_Table.Add( 6, "View the auction screen" );
			m_Table.Add( 7, "Close" );
			m_Table.Add( 8, "Welcome to the Auction House" );
			m_Table.Add( 9, "Auction An Item" );
			m_Table.Add( 10, "View All Auctions" );
			m_Table.Add( 11, "View Your Auctions" );
			m_Table.Add( 12, "View Your Bids" );
			m_Table.Add( 13, "View Your Pendencies" );
			m_Table.Add( 14, "Exit" );
			m_Table.Add( 15, "The auction system has been stopped. Please try again later." );
			m_Table.Add( 16, "Search" );
			m_Table.Add( 17, "Sort" );
			m_Table.Add( 18, "Page {0}/{1}" ); // Page 1/3 - used when displaying more than one page
			m_Table.Add( 19, "Displaying {0} items" ); // {0} is the number of items displayed in an auction listing
			m_Table.Add( 20, "No items to display" );
			m_Table.Add( 21, "Previous Page" );
			m_Table.Add( 22, "Next Page" );
			m_Table.Add( 23, "An unexpected error occurred. Please try again." );
			m_Table.Add( 24, "The selected item has expired. Please refresh the auction listing." );
			m_Table.Add( 25, "Auction Messaging System" );
			m_Table.Add( 26, "Auction:" );
			m_Table.Add( 27, "View details" );
			m_Table.Add( 28, "Not available" );
			m_Table.Add( 29, "Message Details:" );
			m_Table.Add( 30, "Time left for all part to take their decisions: {0} days and {1} hours." );
			m_Table.Add( 31, "The auction no longer exists, therefore this message is no longer valid." );
			m_Table.Add( 32, "Auction House Search" );
			m_Table.Add( 33, "Enter the terms to search for (leave blank for all items)" );
			m_Table.Add( 34, "Limit search to those types:" );
			m_Table.Add( 35, "Maps" );
			m_Table.Add( 36, "Artifacts" );
			m_Table.Add( 37, "Power and Stat Cap Scrolls" );
			m_Table.Add( 38, "Resources" );
			m_Table.Add( 39, "Jewels" );
			m_Table.Add( 40, "Weapons" );
			m_Table.Add( 41, "Armor" );
			m_Table.Add( 42, "Shields" );
			m_Table.Add( 43, "Reagents" );
			m_Table.Add( 44, "Potions" );
			m_Table.Add( 45, "BOD (Large)" );
			m_Table.Add( 46, "BOD (Small)" );
			m_Table.Add( 47, "Cancel" );
			m_Table.Add( 48, "Search only within your current results" );
			m_Table.Add( 49, "Auction House Sorting System" );
			m_Table.Add( 50, "Name" );
			m_Table.Add( 51, "Ascending" );
			m_Table.Add( 52, "Descending" );
			m_Table.Add( 53, "Date" );
			m_Table.Add( 54, "Oldest first" );
			m_Table.Add( 55, "Newest first" );
			m_Table.Add( 56, "Time Left" );
			m_Table.Add( 57, "Shortest first" );
			m_Table.Add( 58, "Longest first" );
			m_Table.Add( 59, "Number of bids" );
			m_Table.Add( 60, "Few first" );
			m_Table.Add( 61, "Most first" );
			m_Table.Add( 62, "Minimum bid value" );
			m_Table.Add( 63, "Lowest first" );
			m_Table.Add( 64, "Highest first" );
			m_Table.Add( 65, "Highest bid value" );
			m_Table.Add( 66, "Cancel Sorting" );
			m_Table.Add( 67, "{0} Items total" ); // Number of items inside a container - auction view gump
			m_Table.Add( 68, "Starting Bid" );
			m_Table.Add( 69, "Reserve" );
			m_Table.Add( 70, "Highest Bid" );
			m_Table.Add( 71, "No bids yet" );
			m_Table.Add( 72, "Web Link" );
			m_Table.Add( 73, "{0} Days {1} Hours" ); // 5 Days 2 Hours
			m_Table.Add( 74, "{0} Hours" ); // 18 Hours
			m_Table.Add( 75, "{0} Minutes" ); // 50 Minutes
			m_Table.Add( 76, "{0} Seconds" ); // 10 Seconds
			m_Table.Add( 77, "Pending" );
			m_Table.Add( 78, "N/A" );
			m_Table.Add( 79, "Bid on this item:" );
			m_Table.Add( 80, "View Bids" );
			m_Table.Add( 81, "Owner's Description" );
			m_Table.Add( 82, "Item Hue" );
			m_Table.Add( 83, "[3D Clients don't display item hues]" );
			m_Table.Add( 84, "This auction is closed and is no longer accepting bids" );
			m_Table.Add( 85, "Invalid bid. Bid not accepted." );
			m_Table.Add( 86, "Bidding History" );
			m_Table.Add( 87, "Who" );
			m_Table.Add( 88, "Amount" );
			m_Table.Add( 89, "Return to the Auction" );
			m_Table.Add( 90, "Creatures Division" );
			m_Table.Add( 91, "Stable the pet" );
			m_Table.Add( 92, "Use this ticket to stable your pet." );
			m_Table.Add( 93, "Stabled pets must be claimed" ); // This and the following form one sentence
			m_Table.Add( 94, "within a week time from the stable." );
			m_Table.Add( 95, "You will not pay for this service." );
			m_Table.Add( 96, "AUCTION SYSTEM TERMINATION" );
			m_Table.Add( 97, "<basefont color=#FFFFFF>You are about to terminate the auction system running on this server. This will cause all current auctions to end right now. All items will be returned to the original owners and the highest bidders will receive their money back.<br><br>Are you sure you wish to do this?" );
			m_Table.Add( 98, "Yes I want to terminate the system" );
			m_Table.Add( 99, "Do nothing and let the system running" );
			m_Table.Add( 100, "New Auction Configuration" );
			m_Table.Add( 101, "Duration" );
			m_Table.Add( 102, "Days" );
			m_Table.Add( 103, "Description (Optional)" );
			m_Table.Add( 104, "Web Link (Optional)" );
			m_Table.Add( 106, "I have read the auction agreement and wish" ); // This and the following form one sentence
			m_Table.Add( 107, "to continue and commit this auction." );
			m_Table.Add( 108, "Cancel and exit" );
			m_Table.Add( 109, "The starting bid must be at least 1 gold coin." );
			m_Table.Add( 110, "The reserve must be greater or equal than the starting bid" );
			m_Table.Add( 111, "An auction must last at least {0} days." );
			m_Table.Add( 112, "An auction can last at most {0} days." );
			m_Table.Add( 113, "Please speicfy a name for your auction" );
			m_Table.Add( 114, "The reserve you specified is too high. Either lower it or raise the starting bid." );
			m_Table.Add( 115, "The system has been closed" );
			m_Table.Add( 116, "The item carried by this check no longer exists due to reasons outside the auction system" );
			m_Table.Add( 117, "The content of the check has been delivered to your bank box." );
			m_Table.Add( 118, "Couldn't add the item to your bank box. Please make sure it has enough space to hold it." );
			m_Table.Add( 119, "Your godly powers allow you to access this check." );
			m_Table.Add( 120, "This check can only be used by its owner" );
			m_Table.Add( 121, "You are not supposed to remove this item manually. Ever." );
			m_Table.Add( 122, "Gold Check from the Auction System" );
			m_Table.Add( 123, "You have been outbid for the auction of {0}. Your bid was {1}." );
			m_Table.Add( 124, "Auction system stopped. Returning your bid of {1} gold for {0}" );
			m_Table.Add( 125, "Auction for {0} has been canceled by either you or the owner. Returning your bid." );
			m_Table.Add( 126, "Your bid of {0} for {1} didn't meet the reserve and the owner decided not to accept your offer" );
			m_Table.Add( 127, "The auction was in pending state due to either reserve not being met or because one or more items have been deleted. No decision has been taken by the involved parts to resolve the auction therefore it has been ended unsuccesfully." );
			m_Table.Add( 128, "The auction has been cancelled because the auctioned item has been removed from the world." );
			m_Table.Add( 129, "You have sold {0} through the auction system. The highest bid was {1}." );
			m_Table.Add( 130, "{0} is not a valid reason for an auction gold check" );
			m_Table.Add( 131, "Creature Check from the Auction System" );
			m_Table.Add( 132, "Item Check from the Auction System" );
			m_Table.Add( 133, "Your auction for {0} has terminated without bids." );
			m_Table.Add( 134, "Your auction for {0} has been canceled" );
			m_Table.Add( 135, "The auction system has been stopped and your auctioned item is being returned to you. ({0})" );
			m_Table.Add( 136, "The auction has been cancelled because the auctioned item has been removed from the world." );
			m_Table.Add( 137, "You have succesfully purchased {0} through the auction system. Your bid was {1}." );
			m_Table.Add( 138, "{0} is not a valid reason for an auction item check" );
			m_Table.Add( 139, "You can't auction creatures that don't belong to you." );
			m_Table.Add( 140, "You can't auction dead creatures" );
			m_Table.Add( 141, "You can't auction summoned creatures" );
			m_Table.Add( 142, "You can't auction familiars" );
			m_Table.Add( 143, "Please unload your pet's backpack first" );
			m_Table.Add( 144, "The pet represented by this check no longer exists" );
			m_Table.Add( 145, "Sorry we're closed at this time. Please try again later." );
			m_Table.Add( 146, "This item no longer exists" );
			m_Table.Add( 147, "Control Slots : {0}<br>" ); // For a pet
			m_Table.Add( 148, "Bondable : {0}<br>" );
			m_Table.Add( 149, "Str : {0}<br>" );
			m_Table.Add( 150, "Dex : {0}<br>" );
			m_Table.Add( 151, "Int : {0}<br>" );
			m_Table.Add( 152, "Amount: {0}<br>" );
			m_Table.Add( 153, "Uses remaining : {0}<br>" );
			m_Table.Add( 154, "Spell : {0}<br>" );
			m_Table.Add( 155, "Charges : {0}<br>" );
			m_Table.Add( 156, "Crafted by {0}<br>" );
			m_Table.Add( 157, "Resource : {0}<br>" );
			m_Table.Add( 158, "Quality : {0}<br>" );
			m_Table.Add( 159, "Hit Points : {0}/{1}<br>" );
			m_Table.Add( 160, "Durability : {0}<br>" );
			m_Table.Add( 161, "Protection: {0}<br>" );
			m_Table.Add( 162, "Poison Charges : {0} [{1}]<br>" );
			m_Table.Add( 163, "Range : {0}<br>" );
			m_Table.Add( 164, "Damage : {0}<br>" );
			m_Table.Add( 165, "Accurate<br>" ); // Accuracy level, might want to leave as is
			m_Table.Add( 166, "{0} Accurate<br>" ); // Will become: Supremely Accurate/Extremely Accurate
			m_Table.Add( 167, "Slayer : {0}<br>" );
			m_Table.Add( 168, "Map : {0}<br>" );
			m_Table.Add( 169, "Spell Count : {0}" );
			m_Table.Add( 170, "Invalid Localization" );
			m_Table.Add( 171, "Invalid" );
			m_Table.Add( 172, "The item you selected has been removed and will be held under strict custody" );
			m_Table.Add( 173, "You cancel the auction and your item is returned to you" );
			m_Table.Add( 174, "You cancel the auction and your pet is returned to you" );
			m_Table.Add( 175, "You don't have enough control slots to bid on that creature" );
			m_Table.Add( 176, "Your bid isn't high enough" );
			m_Table.Add( 177, "Your bid doesn't reach the minimum bid" );
			m_Table.Add( 178, "Your stable is full. Please free some space before claiming this creature." );
			m_Table.Add( 179, "You have been outbid. An auction check of {0} gold coins has been deposited in your backpack or bankbox. View the auction details if you wish to place another bid." );
			m_Table.Add( 180, "Your auction has ended, but the highest bid didn't reach the reserve you specified. You now have option to decide whether to sell your item or not.<br><br>The highest bid is {0}. Your reserve was {1}." );
			m_Table.Add( 181, "<br><br>Some of the items auctioned have been deleted during the duration of the auction. The buyer will have to accept the new auction before it can be completed." );
			m_Table.Add( 182, "Yes I want to sell my item even if the reserve hasn't been met" );
			m_Table.Add( 183, "No I don't want to sell and I want my item returned to me" );
			m_Table.Add( 184, "Your bid didn't meet the reserve specified by the auction owner. The item owner will now have to decide whether to sell or not.<br><br>Your bid was {1}. The reserve is {2}." );
			m_Table.Add( 185, "Close this message" );
			m_Table.Add( 186, "You have participated and won an auction. However due to external events one or more of the items auctioned no longer exist. Please review the auction by using the view details button and decide whether you wish to purchase the items anyway or not.<br><br>Your bid was {0}" );
			m_Table.Add( 187, "<br><br>Your bid didn't meet the reserve specified by the owner. The owner will not have to deicde whether they wish to sell or not" );
			m_Table.Add( 188, "Yes I want to purchase anyway" );
			m_Table.Add( 189, "No I don't want to purchase and wish to have my money back" );
			m_Table.Add( 190, "Some of the items you acutioned no longer exists because of external reasons. The buyer will now decide whether to purchase or not." );
			m_Table.Add( 191, "Please target the item you wish to put on auction..." );
			m_Table.Add( 192, "You cannot have more than {0} auctions active on your account" );
			m_Table.Add( 193, "You can only auction items" );
			m_Table.Add( 194, "You cannot put that on auction" );
			m_Table.Add( 195, "One of the items you're auctioning isn't identified" );
			m_Table.Add( 196, "One of the items inside the container isn't allowed at the auction house" );
			m_Table.Add( 197, "You cannot sell containers with items nested in other containers" );
			m_Table.Add( 198, "You can only auction items that you have in your backpack or in your bank box" );
			m_Table.Add( 199, "You don't have enough money in your bank to place this bid" );
			m_Table.Add( 200, "The auction system is currently stopped" );
			m_Table.Add( 201, "Delete" );
			m_Table.Add( 202, "You have bid on an auction that has been removed by the shard staff. Your bid is now being returned to you." );
			m_Table.Add( 203, "Your auction has been closed by the shard staff and your item is now returned to you." );
			m_Table.Add( 204, "Your bid must be at least {0} higher than the current bid" );
			m_Table.Add( 205, "You cannot auction items that are not movable" );
			m_Table.Add( 206, "Props" );
			m_Table.Add( 207, "The selected auction is no longer active. Please refresh the auctions list." );

			// VERSION 1.7 Begins here

			m_Table.Add( 208, "Allow Buy Now For:" );
			m_Table.Add( 209, "If you chose to use the Buy Now feature, please specify a value higher than the reserve" );
			m_Table.Add( 210, "Buy this item now for {0} gold" );

			// Entry 105 has been changed from the previous version. Buy Now section has been added.
			m_Table.Add( 105, @"<basefont color=#FF0000>Auction Agreement<br>
<basefont color=#FFFFFF>By completing and submitting this form you agree to take part in the auction system. The item you are auctioning will be removed from your inventory and will be returned to you only if you cancel this auction, if the auction is unsuccesfull and the item isn't sold, or if staff forces the auction system to stop.
<basefont color=#FF0000>Starting Bid:<basefont color=#FFFFFF> This is the minimum bid accepted for this item. Set this value to something reasonable, and possibly lower than what you expect to collect for the item in the end.
<basefont color=#FF0000>Reserve:<basefont color=#FFFFFF> This value will not be know to the bidders, and you should consider it as a safe price for your item. If the final bid reaches this value, the sale will be automatically finalized by the system. If on the other hand the highest bid is somewhere between the starting bid and the reserve, you will be given the option of choosing whether to sell the item or not. You will have 7 days after the end of the auction to take this decision. If you don't, the auction system will assume you decided not to sell and will return the item to you and the money to the highest bidder. Bidders will not see the value of the reserve, but only a statement saying whether it has been reached or not.
<basefont color=#FF0000>Duration:<basefont color=#FFFFFF> This value specifies how many days the auction will last from its creation time. At the end of this period, the system will proceed to either finalize the sale, return the item and the highest bid, or wait for a decision in case of a reserve not reached issue.
<basefont color=#FF0000>Buy Now:<basefont color=#FFFFFF> This options allows you to specify a safe price at which you are willing to sell the item before the end of the auction. If the buyer is willing to pay this price, they will be able to purchase the item right away without any further bids.
<basefont color=#FF0000>Name:<basefont color=#FFFFFF> This should be a short name defining your auction. The system will suggest a name based on the item you're selling, but you might wish to change it in some circumstances.
<basefont color=#FF0000>Description:<basefont color=#FFFFFF> You can write pretty much anything you wish here about your item. Keep in mind that the item properties you see when moving your mouse over the item will be available to bidders automatically, so there's no need for you to describe those.
<basefont color=#FF0000>Web Link:<basefont color=#FFFFFF> You can add a web link to this auction, in case you have a web page with further information or discussion about this item
<br>
Once you commit this auction you will not be able to retrieve your item until the auction ends. Make sure you understand what this means before committing." );

			m_Table.Add( 211, "You don't have enough money in your bank to buy this item" );
			m_Table.Add( 212, "You don't have enough space in your bank to make this deposit. Please free some space and try again." );
			m_Table.Add( 213, "Auction Control" );
			m_Table.Add( 214, "Properties" );
			m_Table.Add( 215, "Account : {0}" );
			m_Table.Add( 216, "Auction Owner : {0}" );
			m_Table.Add( 217, "Online" );
			m_Table.Add( 218, "Offline" );
			m_Table.Add( 219, "Auctioned Item" );
			m_Table.Add( 220, "Place it in your backpack" );
			m_Table.Add( 221, "Put the item back into the system" );
			m_Table.Add( 222, "Auction" );
			m_Table.Add( 223, "End auction now" );
			m_Table.Add( 224, "Close and return item to the owner" );
			m_Table.Add( 225, "Close and put the item in your pack" );
			m_Table.Add( 226, "Close and delete the item" );
			m_Table.Add( 227, "Auction Staff Panel" );
		}

		/// <summary>
		/// Gets the localized string for the Auction System
		/// </summary>
		public string this[int index]
		{
			get
			{
				string s = m_Table[ index ] as string;

				if ( s == null )
					return "Localization Missing";
				else
					return s;
			}
		}
	}
}
