//26JUL2007 Randomized Vendor Prices and Amounts
//http://www.runuo.com/forums/custom-script-releases/79568-runuo-2-0-rc1-randomized-vendor-prices-amounts.html
using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
    public class GenericSellInfo : IShopSellInfo
    {
        private Dictionary<Type, int> m_Table = new Dictionary<Type, int>();
        private Type[] m_Types;

        public GenericSellInfo()
        {
        }

        public void Add(Type type, int price)
        {
            //26JUL2007 Randomized Vendor Prices and Amounts *** START ***
            //m_Table[type] = price;
            m_Table[type] = GetRandSellPriceFor(price);
            //26JUL2007 Randomized Vendor Prices and Amounts *** END   ***
            m_Types = null;
        }
        //26JUL2007 Randomized Vendor Prices and Amounts *** START ***
        public static int GetRandSellPriceFor(int itemPrice)
        {
            int lowPrice = (int)(.7 * itemPrice);
            int highPrice = (int)(1.2 * itemPrice);
            int price = 0;
            for (int i = 1; i <= 3; i++)
            {
                price += Utility.RandomMinMax(lowPrice, highPrice);
            }
            price /= 3;
            if (price < 1)
                price = 1;
            return price;
        }
        //26JUL2007 Randomized Vendor Prices and Amounts *** END   ***

        public int GetSellPriceFor(Item item)
        {
            int price = 0;
            m_Table.TryGetValue(item.GetType(), out price);

            if (item is BaseArmor)
            {
                BaseArmor armor = (BaseArmor)item;

                if (armor.Quality == ArmorQuality.Low)
                    price = (int)(price * 0.60);
                else if (armor.Quality == ArmorQuality.Exceptional)
                    price = (int)(price * 1.25);

                price += 100 * (int)armor.Durability;

                price += 100 * (int)armor.ProtectionLevel;

                if (price < 1)
                    price = 1;
            }
            else if (item is BaseWeapon)
            {
                BaseWeapon weapon = (BaseWeapon)item;

                if (weapon.Quality == WeaponQuality.Low)
                    price = (int)(price * 0.60);
                else if (weapon.Quality == WeaponQuality.Exceptional)
                    price = (int)(price * 1.25);

                price += 100 * (int)weapon.DurabilityLevel;

                price += 100 * (int)weapon.DamageLevel;

                if (price < 1)
                    price = 1;
            }
            else if (item is BaseBeverage)
            {
                int price1 = price, price2 = price;

                if (item is Pitcher)
                { price1 = 3; price2 = 5; }
                else if (item is BeverageBottle)
                { price1 = 3; price2 = 3; }
                else if (item is Jug)
                { price1 = 6; price2 = 6; }

                BaseBeverage bev = (BaseBeverage)item;

                if (bev.IsEmpty || bev.Content == BeverageType.Milk)
                    price = price1;
                else
                    price = price2;
            }

            return price;
        }

        public int GetBuyPriceFor(Item item)
        {
            return (int)(1.90 * GetSellPriceFor(item));
        }

        public Type[] Types
        {
            get
            {
                if (m_Types == null)
                {
                    m_Types = new Type[m_Table.Keys.Count];
                    m_Table.Keys.CopyTo(m_Types, 0);
                }

                return m_Types;
            }
        }

        public string GetNameFor(Item item)
        {
            if (item.Name != null)
                return item.Name;
            else
                return item.LabelNumber.ToString();
        }

        public bool IsSellable(Item item)
        {
            //if ( item.Hue != 0 )
            //return false;

            return IsInList(item.GetType());
        }

        public bool IsResellable(Item item)
        {
            //if ( item.Hue != 0 )
            //return false;

            return IsInList(item.GetType());
        }

        public bool IsInList(Type type)
        {
            return m_Table.ContainsKey(type);
        }
    }
}
