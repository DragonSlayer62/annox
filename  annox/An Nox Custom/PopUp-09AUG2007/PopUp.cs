// 15AUG2007 written by RavonTUS
//
//   /\\           |\\  ||
//  /__\\  |\\ ||  | \\ ||  /\\  \ //
// /    \\ | \\||  |  \\||  \//  / \\ 
// Play at An Nox, the cure for the UO addiction
// http://annox.no-ip.com  // RavonTUS@Yahoo.com

//use [add popup
//use [set name "Your PopUp information goes here."

#define PopUp

using System;
using Server.Items;
using Server.Gumps;
using Server.Accounting;
using Server.Mobiles;

namespace Server.Items
{
    public class PopUp : Item
    {
        [Constructable]
        public PopUp()
            : base(0x1BC3)
        {
            Movable = false;
            Visible = false;

            Name = "PopUp - use [set name 'Your PopUp information goes here.'";
        }

        public override bool HandlesOnMovement { get { return true; } }

        public override void OnMovement(Mobile from, Point3D oldLocation)
        {
            if (from.InRange(this, 3) && from is PlayerMobile)
            {
                if (!from.HasGump(typeof(PopUpGump)))
                    from.SendGump(new PopUpGump(Name));
            }
            if (!from.InRange(this, 3) && from is PlayerMobile)
            {
                if (from.HasGump(typeof(PopUpGump)))
                    from.CloseGump(typeof(PopUpGump));
            }
        }

        //If you want to be able to double click on the 'PopUp' then add the following lines.
        //public override void OnDoubleClick(Mobile from)
        //{
        //    if (!from.HasGump(typeof(PopUpGump)))
        //        from.SendGump(new PopUpGump(Name));
        //}

        public PopUp(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}

//The Gump
namespace Server.Gumps
{
    public class PopUpGump : Gump
    {
        public PopUpGump(string Name)
            : base(500, 350)
        {
            this.Closable = true;
            this.Disposable = true;
            this.Dragable = true;
            this.Resizable = false;
            this.AddPage(0);
            this.AddImage(89, 112, 9460);
            this.AddHtml(125, 149, 177, 100, @"<center>" + Name + "</center>", (bool)false, (bool)false);

            //for smaller sign replace the above two lines with these two lines.
            //this.AddImage(163, 134, 100);
            //this.AddHtml(191, 160, 87, 49, @"<center>" + Name + "</center>", (bool)false, (bool)false);
        }
    }
}


