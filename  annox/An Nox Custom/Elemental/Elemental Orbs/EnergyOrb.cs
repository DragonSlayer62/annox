using System;

namespace Server.Items
{
    public class EnergyOrb : Item, ICommodity
    {
        string ICommodity.Description
        {
            get
            {
                return String.Format(Amount == 1 ? "{0} EnergyOrb" : "{0} EnergyOrbs", Amount);
            }
        }

        int ICommodity.DescriptionNumber { get { return LabelNumber; } }

        [Constructable]
        public EnergyOrb()
            : this(1)
        {
        }

        [Constructable]
        public EnergyOrb(int amount)
            : base(3630)
        {
            Stackable = false;
            Hue = 1174;
            Name = "Orb Of Energy";
            Weight = 0.1;
            Amount = amount;
        }

        public EnergyOrb(Serial serial)
            : base(serial)
        {
        }

        //public override Item Dupe(int amount)
        //{
        //    return base.Dupe(new Arrow(amount), amount);
        //}

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