//10OCT2007 InstaKill for Creatures ONLY
//10OCT2007 Reorganized Guards

using System;
using Server;
using System.Collections;
using Server.Misc;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
    public class WarriorGuard : BaseGuard
    {
        private Timer m_AttackTimer, m_IdleTimer, m_DamageTimer;

        private Mobile m_Focus;

        [Constructable]
        public WarriorGuard()
            : this(null)
        {
        }

        public WarriorGuard(Mobile target)
            : base(target)
        {
            //10OCT2007 Reorganized Guards *** START ***
            //Reduce stats to a normal level
            //InitStats(1000, 1000, 1000);

            InitStats((Utility.RandomMinMax(50, 75)), (Utility.RandomMinMax(50, 75)), (Utility.RandomMinMax(50, 75)));
            Title = "the guard";

            SpeechHue = Utility.RandomDyedHue();

            Hue = Utility.RandomSkinHue();

            if (Female = Utility.RandomBool())
            {
                Body = 0x191;
                Name = NameList.RandomName("female");
                AddItem(new FemalePlateChest());
            }
            else
            {
                Body = 0x190;
                Name = NameList.RandomName("male");
                AddItem(new PlateChest());
                AddItem(new PlateArms());

                if (Utility.RandomBool())
                {
                    Utility.AssignRandomFacialHair(this, HairHue);
                }
            }

            AddItem(new PlateGloves());
            AddItem(new PlateGorget());
            AddItem(new PlateLegs());
            AddItem(new Boots());
            AddItem(new NorseHelm());

            AddItem(new BodySash(Utility.RandomNondyedHue()));

            Utility.AssignRandomHair(this);

            switch (Utility.Random(1))  //picks one of the following
            {
                case 0:
                    {
                        Longsword weapon = new Longsword();
                        weapon.Movable = false;
                        weapon.Crafter = this;
                        weapon.Quality = WeaponQuality.Exceptional;

                        AddItem(weapon);
                        AddItem(new MetalShield());
                        break;
                    }
                case 1:
                    {
                        Halberd weapon = new Halberd();
                        weapon.Movable = false;
                        weapon.Crafter = this;
                        weapon.Quality = WeaponQuality.Exceptional;

                        AddItem(weapon); break;
                    }
            }
            //10OCT2007 Reorganized Guards *** END   ***

            Container pack = new Backpack();

            pack.Movable = false;

            pack.DropItem(new Gold(10, 25));

            AddItem(pack);

            Skills[SkillName.Anatomy].Base = 120.0;
            Skills[SkillName.Tactics].Base = 120.0;
            Skills[SkillName.Swords].Base = 120.0;
            Skills[SkillName.MagicResist].Base = 120.0;
            Skills[SkillName.DetectHidden].Base = 100.0;

            this.NextCombatTime = DateTime.Now + TimeSpan.FromSeconds(0.5);
            this.Focus = target;
        }

        public WarriorGuard(Serial serial)
            : base(serial)
        {
        }

        public override bool OnBeforeDeath()
        {
            //10OCT2007 InstaKill for Creatures ONLY *** START ***
            //no more guards
            //if (m_Focus != null && m_Focus.Alive)
            //    new AvengeTimer(m_Focus).Start(); // If a guard dies, three more guards will spawn

            //Leave a dead body (keeps you from modifing BaseGuard.cs)
            //return base.OnBeforeDeath();
            return true;
            //10OCT2007 InstaKill for Creatures ONLY *** END   ***
        }

        public override void OnDamage(int amount, Mobile from, bool willKill)
        {
            m_DamageTimer = new DamageTimer(this);
            m_DamageTimer.Start();
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public override Mobile Focus
        {
            get
            {
                return m_Focus;
            }
            set
            {
                if (Deleted)
                    return;

                Mobile oldFocus = m_Focus;

                if (oldFocus != value)
                {
                    m_Focus = value;

                    if (value != null)
                        this.AggressiveAction(value);

                    Combatant = value;

                    if (oldFocus != null && !oldFocus.Alive)
                        Say("Thou hast suffered thy punishment, scoundrel.");

                    if (value != null)
                        Say(500131); // Thou wilt regret thine actions, swine!

                    if (m_AttackTimer != null)
                    {
                        m_AttackTimer.Stop();
                        m_AttackTimer = null;
                    }

                    if (m_IdleTimer != null)
                    {
                        m_IdleTimer.Stop();
                        m_IdleTimer = null;
                    }

                    if (m_Focus != null)
                    {
                        m_AttackTimer = new AttackTimer(this);
                        m_AttackTimer.Start();
                        ((AttackTimer)m_AttackTimer).DoOnTick();
                    }
                    else
                    {
                        m_IdleTimer = new IdleTimer(this);
                        m_IdleTimer.Start();
                    }
                }
                else if (m_Focus == null && m_IdleTimer == null)
                {
                    m_IdleTimer = new IdleTimer(this);
                    m_IdleTimer.Start();
                }
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

            writer.Write(m_Focus);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 0:
                    {
                        m_Focus = reader.ReadMobile();

                        if (m_Focus != null)
                        {
                            m_AttackTimer = new AttackTimer(this);
                            m_AttackTimer.Start();
                        }
                        else
                        {
                            m_IdleTimer = new IdleTimer(this);
                            m_IdleTimer.Start();
                        }

                        break;
                    }
            }
        }

        public override void OnAfterDelete()
        {
            if (m_AttackTimer != null)
            {
                m_AttackTimer.Stop();
                m_AttackTimer = null;
            }

            if (m_IdleTimer != null)
            {
                m_IdleTimer.Stop();
                m_IdleTimer = null;
            }

            if (m_DamageTimer != null)
            {
                m_DamageTimer.Stop();
                m_DamageTimer = null;
            }

            base.OnAfterDelete();
        }

        private class AvengeTimer : Timer
        {
            private Mobile m_Focus;

            public AvengeTimer(Mobile focus)
                : base(TimeSpan.FromSeconds(2.5), TimeSpan.FromSeconds(1.0), 3)
            {
                m_Focus = focus;
            }

            protected override void OnTick()
            {
                BaseGuard.Spawn(m_Focus, m_Focus, 1, true);
            }
        }

        private class AttackTimer : Timer
        {
            private WarriorGuard m_Owner;
            private int m_Stage;
            private bool m_TeleportTo = true;

            public AttackTimer(WarriorGuard owner)
                : base(TimeSpan.FromSeconds(0.25), TimeSpan.FromSeconds(0.1))
            {
                m_Owner = owner;
            }

            public void DoOnTick()
            {
                OnTick();
            }

            protected override void OnTick()
            {
                if (m_Owner.Deleted)
                {
                    Stop();
                    return;
                }

                m_Owner.Criminal = false;
                m_Owner.Kills = 0;
                m_Owner.Stam = m_Owner.StamMax;

                Mobile target = m_Owner.Focus;

                if (target != null && (target.Deleted || !target.Alive || !m_Owner.CanBeHarmful(target)))
                {
                    m_Owner.Focus = null;
                    Stop();
                    return;
                }

                //10OCT2007 InstaKill for Creatures ONLY *** START ***

                if (target != null && m_Owner.Combatant != target)
                    m_Owner.Combatant = target;

                if (target == null)
                {
                    Stop();
                }

                else
                {
                    //kill creatures only
                    if (target is BaseCreature)
                    {
                        target.BoltEffect(0);
                        //((BaseCreature)target).NoKillAwards = true;
                        target.Kill(); // just in case, maybe Damage is overriden on some shard
                        m_Owner.Focus = null;
                        Stop();
                    }
                    else
                    {
                        //kill player if in a certian region
                        IPoint3D ip = m_Owner as IPoint3D;

                        if (ip != null)
                        {
                            Point3D p = new Point3D(ip);

                            Region reg = Region.Find(new Point3D(p), m_Owner.Map);

                            Console.WriteLine("Guards Called to: " + reg.Name);

                            if (reg.Name == "SafeZone")
                            {
                                target.Frozen = true;
                                target.BoltEffect(0);
                                target.BodyMod = Utility.RandomList(50, 56);

                                Timer.DelayCall(TimeSpan.FromSeconds(20.0), new TimerCallback(ReportKill));                               
                                target.BoltEffect(0);
                                //((BaseCreature)target).NoKillAwards = true;
                                target.Kill(); // just in case, maybe Damage is overriden on some shard

                                target.BodyMod = 0x0;
                                target.Frozen = false;

                                m_Owner.Focus = null;
                                m_TeleportTo = false;
                                Stop();
                            }
                            else
                            {
                                //Turn Off Guard
                                m_Owner.Focus = null;

                                //wander around and wait for timer to end
                                if ((m_Stage++ % 4) == 0 || !m_Owner.Move(m_Owner.Direction))
                                {
                                    m_Owner.Direction = (Direction)Utility.Random(8);
                                }

                                //Time to talk
                                switch (Utility.Random(5))  //picks one of the following
                                {
                                    case 0:
                                        { m_Owner.Say("Depend not on fortune, but on conduct."); break; }
                                    case 1:
                                        { m_Owner.Say("A great fortune in the hands of a fool is a great misfortune."); break; }
                                    case 2:
                                        { m_Owner.Say("To save time is to lengthen life."); break; }
                                    case 3:
                                        { m_Owner.Say("Rich gifts wax poor when givers prove unkind."); break; }
                                    case 4:
                                        { m_Owner.Say("Act the way you'd like to be and soon you'll be the way you act."); break; }
                                }
                            }
                        }
                    }
                }

                //10OCT2007 InstaKill for Creatures ONLY *** END  ***

                //{// <instakill>
                //    TeleportTo( target );
                //    target.BoltEffect( 0 );

                //    if ( target is BaseCreature )
                //        ((BaseCreature)target).NoKillAwards = true;

                //    target.Damage( target.HitsMax, m_Owner );
                //    target.Kill(); // just in case, maybe Damage is overriden on some shard

                //    if ( target.Corpse != null && !target.Player )
                //        target.Corpse.Delete();

                //    m_Owner.Focus = null;
                //    Stop();
                //}// </instakill>
                ///*else if ( !m_Owner.InRange( target, 20 ) )
                //{
                //    m_Owner.Focus = null;
                //}
                //else if ( !m_Owner.InRange( target, 10 ) || !m_Owner.InLOS( target ) )
                //{
                //    TeleportTo( target );
                //}
                //else if ( !m_Owner.InRange( target, 1 ) )
                //{
                //    if ( !m_Owner.Move( m_Owner.GetDirectionTo( target ) | Direction.Running ) )
                //        TeleportTo( target );
                //}
                //else if ( !m_Owner.CanSee( target ) )
                //{
                //    if ( !m_Owner.UseSkill( SkillName.DetectHidden ) && Utility.Random( 50 ) == 0 )
                //        m_Owner.Say( "Reveal!" );
                //}*/
            }

            public virtual void ReportKill()
            {
                Console.WriteLine("Safe Zone:  Guard was sent to kill a player.");
                return;
            }

            private void TeleportTo(Mobile target)
            {
                if (m_TeleportTo == true)
                {
                    m_TeleportTo = false;

                    Point3D from = m_Owner.Location;
                    //10OCT2007 Adjust InstaKill Distance *** START ***
                    //Instead of teleporting on top of the player, make it a few spaces away.
                    //Point3D to = target.Location;
                    Point3D toclose = target.Location;
                    Point3D to = new Point3D(toclose.X + (Utility.RandomMinMax(-5, 5)), toclose.Y + (Utility.RandomMinMax(-5, 5)), toclose.Z);
                    //10OCT2007 Adjust InstaKill Distance *** END   ***

                    m_Owner.Location = to;

                    Effects.SendLocationParticles(EffectItem.Create(from, m_Owner.Map, EffectItem.DefaultDuration), 0x3728, 10, 10, 2023);
                    Effects.SendLocationParticles(EffectItem.Create(to, m_Owner.Map, EffectItem.DefaultDuration), 0x3728, 10, 10, 5023);

                    m_Owner.PlaySound(0x1FE);
                }
            }
        }

        private class DamageTimer : Timer
        {
            private WarriorGuard m_Owner;
            private int m_Stage;

            public DamageTimer(WarriorGuard owner)
                : base(TimeSpan.FromSeconds(0.25), TimeSpan.FromSeconds(0.1))
            {
                m_Owner = owner;
            }

            public void DoOnTick()
            {
                OnTick();
            }

            protected override void OnTick()
            {
                if (m_Owner.Deleted)
                {
                    Stop();
                    return;
                }

                m_Owner.Criminal = false;
                m_Owner.Kills = 0;
                m_Owner.Stam = m_Owner.StamMax;

                Mobile target = m_Owner.Focus;

                if (target != null && (target.Deleted || !target.Alive || !m_Owner.CanBeHarmful(target)))
                {
                    m_Owner.Focus = null;
                    Stop();
                    return;
                }

                if (target != null && m_Owner.Combatant != target)
                    m_Owner.Combatant = target;

                if (target == null)
                {
                    Stop();
                }

                else
                {
                    //wander around, kill and wait for timer to end
                    if ((m_Stage++ % 4) == 0 || !m_Owner.Move(m_Owner.Direction))
                    {
                        m_Owner.Direction = (Direction)Utility.Random(8);
                    }

                    //Time to talk
                    switch (Utility.Random(5))  //picks one of the following
                    {
                        case 0:
                            { m_Owner.Say("Whose life is it anyway?."); break; }
                        case 1:
                            { m_Owner.Say("The appearance of right oft leads us wrong."); break; }
                        case 2:
                            { m_Owner.Say("Go, and do thou likewise."); break; }
                        case 3:
                            { m_Owner.Say("What stings is justice."); break; }
                        case 4:
                            { m_Owner.Say("Dig the well before you are thirsty."); break; }
                    }

                    //Stop fighting and wait for next attack
                    //m_Owner.Focus = null;
                    //Stop();
                    //return;
                }
            }
        }

        private class IdleTimer : Timer
        {
            private WarriorGuard m_Owner;
            private int m_Stage;

            public IdleTimer(WarriorGuard owner)
                : base(TimeSpan.FromSeconds(2.0), TimeSpan.FromSeconds(2.5))
            {
                m_Owner = owner;
            }

            protected override void OnTick()
            {
                if (m_Owner.Deleted)
                {
                    Stop();
                    return;
                }

                if ((m_Stage++ % 4) == 0 || !m_Owner.Move(m_Owner.Direction))
                    m_Owner.Direction = (Direction)Utility.Random(8);

                if (m_Stage > 16)
                {
                    Effects.SendLocationParticles(EffectItem.Create(m_Owner.Location, m_Owner.Map, EffectItem.DefaultDuration), 0x3728, 10, 10, 2023);
                    m_Owner.PlaySound(0x1FE);

                    m_Owner.Delete();
                }
            }
        }
    }
}