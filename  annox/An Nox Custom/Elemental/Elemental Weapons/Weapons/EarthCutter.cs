using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
    [FlipableAttribute(0x13B2, 0x13B1)]
    public class EarthCutter : BaseElementalWeapon
    {
        public override int EffectID { get { return 0x26BA; } }
        public override Type AmmoType { get { return typeof(EarthOrb); } }
        public override Item Ammo { get { return new EarthOrb(); } }

        public override SkillName DefSkill { get { return SkillName.Swords; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.BleedAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return 70; } }
        public override int AosMinDamage { get { return 22; } }
        public override int AosMaxDamage { get { return 27; } }
        public override int AosSpeed { get { return 36; } }

        public override int OldStrengthReq { get { return 20; } }
        public override int OldMinDamage { get { return 9; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 20; } }

        public override int DefMaxRange { get { return 1; } }

        public override int InitMinHits { get { return 2000; } }
        public override int InitMaxHits { get { return 2000; } }

        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.Slash2H; } }

        [Constructable]
        public EarthCutter()
            : base(0x26BA)
        {
            Weight = 4.0;
            Name = "Cutter of Earth";
            Layer = Layer.TwoHanded;
            MissSound = 1307;
            WeaponAttributes.HitLowerAttack = 40;
            WeaponAttributes.HitLowerDefend = 40;
            HitSound = 755;
            WeaponAttributes.ResistPhysicalBonus = 20;
            Hue = 1818;

        }


        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy)
        {
            phys = 100;
            pois = 0;

            fire = cold = nrgy = 0;
        }

        public EarthCutter(Serial serial)
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

            if (Weight == 5.0)
                Weight = 4.0;
        }
    }
}