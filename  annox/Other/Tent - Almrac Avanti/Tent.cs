//==============================================//
// Created by Dupre				//
// Thanks to:					//
// Zippy					//
// Ike						//
// Ignacio					//
// For putting up with a 'tard like me :)	//
// 						//
// Modified by Almrac Avanti			//
//==============================================//
using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class TentWalls : BaseAddon
    {

        [Constructable]
        public TentWalls()
        {
            //WALLS
            //Corners - Clockwise from SE
            AddComponent(new AddonComponent(0x2DE), 3, 3, 0);
            AddComponent(new AddonComponent(0x2E2), -2, 3, 0);
            AddComponent(new AddonComponent(0x2E1), -2, -2, 0);
            AddComponent(new AddonComponent(0x2E3), 3, -2, 0);

            //East Side
            AddComponent(new AddonComponent(0x2E0), 3, 2, 0);
            AddComponent(new AddonComponent(0x2E0), 3, -1, 0);

            //South Side
            AddComponent(new AddonComponent(0x2DF), 2, 3, 0);
            AddComponent(new AddonComponent(0x2DF), 1, 3, 0);
            AddComponent(new AddonComponent(0x2DF), 0, 3, 0);
            AddComponent(new AddonComponent(0x2DF), -1, 3, 0);

            //West Side
            AddComponent(new AddonComponent(0x2E5), -2, 2, 0);
            AddComponent(new AddonComponent(0x2E5), -2, 1, 0);
            AddComponent(new AddonComponent(0x2E5), -2, 0, 0);
            AddComponent(new AddonComponent(0x2E5), -2, -1, 0);

            //North Side
            AddComponent(new AddonComponent(0x2E4), -1, -2, 0);
            AddComponent(new AddonComponent(0x2E4), 0, -2, 0);
            AddComponent(new AddonComponent(0x2E4), 1, -2, 0);
            AddComponent(new AddonComponent(0x2E4), 2, -2, 0);

            //Misc.items
            AddComponent(new AddonComponent(0x1BDF), +4, +3, 0); // Logs
            AddComponent(new AddonComponent(0xFAC), +7, 0, 0);   // camp fire
            AddComponent(new AddonComponent(0x1E98), +7, 0, 4);  // rabbit on a spit
            AddComponent(new AddonComponent(0x19AB), +7, 0, 2);  // flames
            AddComponent(new AddonComponent(0xFB6), +5, +3, 0);  // horse shoes
            AddComponent(new AddonComponent(0xFB1), +2, +4, 2);  // small forge
            AddComponent(new AddonComponent(0xFB0), +1, +4, 0);  // anvil
            AddComponent(new AddonComponent(0x107B), -1, +4, 0); // stretched hide
            AddComponent(new AddonComponent(0xFFA), +7, +1, 0);  // bucket
            AddComponent(new AddonComponent(0x9D7), +6, +1, 0);  // plate
            AddComponent(new AddonComponent(0xA2B), +6, 0, 0);   // stool
        }

        public TentWalls(Serial serial)
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

    public class TentRoof : BaseAddon
    {

        [Constructable]
        public TentRoof()
        {
            //ROOF
            AddComponent(new AddonComponent(0x604), 3, 3, 20);
            AddComponent(new AddonComponent(0x601), 2, 3, 20);
            AddComponent(new AddonComponent(0x601), 1, 3, 20);
            AddComponent(new AddonComponent(0x601), 0, 3, 20);
            AddComponent(new AddonComponent(0x607), -1, 3, 20);

            AddComponent(new AddonComponent(0x602), 3, 2, 20);
            AddComponent(new AddonComponent(0x604), 2, 2, 23);
            AddComponent(new AddonComponent(0x601), 1, 2, 23);
            AddComponent(new AddonComponent(0x607), 0, 2, 23);
            AddComponent(new AddonComponent(0x5FF), -1, 2, 20);

            AddComponent(new AddonComponent(0x602), 3, 1, 20);
            AddComponent(new AddonComponent(0x602), 2, 1, 23);
            AddComponent(new AddonComponent(0x608), 1, 1, 31);
            AddComponent(new AddonComponent(0x5FF), 0, 1, 23);
            AddComponent(new AddonComponent(0x5FF), -1, 1, 20);

            AddComponent(new AddonComponent(0x602), 3, 0, 20);
            AddComponent(new AddonComponent(0x605), 2, 0, 23);
            AddComponent(new AddonComponent(0x600), 1, 0, 23);
            AddComponent(new AddonComponent(0x606), 0, 0, 23);
            AddComponent(new AddonComponent(0x5FF), -1, 0, 20);

            AddComponent(new AddonComponent(0x605), 3, -1, 20);
            AddComponent(new AddonComponent(0x600), 2, -1, 20);
            AddComponent(new AddonComponent(0x600), 1, -1, 20);
            AddComponent(new AddonComponent(0x600), 0, -1, 20);
            AddComponent(new AddonComponent(0x606), -1, -1, 20);
        }

        public TentRoof(Serial serial)
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

    public class TentFloor : BaseAddon
    {

        [Constructable]
        public TentFloor()
        {
            //CARPET 5997.1682.0 - 3 3 0
            //AddComponent( new AddonComponent( 0xABA ), 2, 2, 0 );
        }

        public TentFloor(Serial serial)
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

    public class TentTrim : BaseAddon
    {

        [Constructable]
        public TentTrim()
        {
            //AddComponent( new AddonComponent( 0x378 ), -2, 4, -5 );
        }

        public TentTrim(Serial serial)
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
