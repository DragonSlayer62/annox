using System;

namespace Server.Items
{
	public class MageMango : Item
	{
		private TimedSkillMod skillMod; 

		[Constructable]
		public MageMango() : base( 0x9D2 )
		{
			Weight = 1.0;
			DefineMods();
			Name = "Mage's Mango";
			Stackable = false;
            	}

		private void DefineMods()
		{
			DateTime duration = DateTime.Now + TimeSpan.FromSeconds( 60.0 );

			skillMod = new TimedSkillMod( SkillName.Magery, true, 10.0, duration );

			skillMod.ObeyCap = false;
		}

		private void SetMods( Mobile m )
		{
			m.AddSkillMod( skillMod );
		}

      		public MageMango( Serial serial ) : base( serial ) 
      		{
			DefineMods();
      		} 

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

            	}

      		public override void OnDoubleClick( Mobile from ) 
      		{ 
         		if ( !from.InRange( GetWorldLocation(), 1 ) ) 
         		{ 
            			from.SendLocalizedMessage( 500446 ); // That is too far away. 
         		} 
         		else 
			{
				if ( from.Mounted == true )
				{
					from.SendLocalizedMessage( 1042561 );
				}
				else
        			{
					SetMods( from );
					from.PlaySound( 0x3A );
					Delete();
				}
			}
		}

	}
}