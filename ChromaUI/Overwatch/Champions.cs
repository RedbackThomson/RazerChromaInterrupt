using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaUI.Overwatch
{
    public enum Champion
    {
        Genji = 0,
        McCree,
        Pharah,
        Reaper,
        Soldier,
        Tracer,
        Bastion,
        Hanzo,
        Junkrat,
        Mei,
        Torbjorn,
        Widowmaker,
        Dva,
        Reinhardt,
        Roadhog,
        Winston,
        Zarya,
        Ana,
        Lucio,
        Mercy,
        Symmetra,
        Zenyatta
    }
    class ChampionColours
    {
        private static readonly Dictionary<Color, Champion> ColourDictionary = new Dictionary<Color, Champion>()
        {
            { Color.FromArgb(255, 66, 255, 0), Champion.Genji },
            { Color.FromArgb(255, 116, 6, 6), Champion.McCree },
            { Color.FromArgb(255, 0, 28, 153), Champion.Pharah },
            { Color.FromArgb(255, 33, 0, 2), Champion.Reaper },
            { Color.FromArgb(255, 16, 25, 54), Champion.Soldier },
            { Color.FromArgb(255, 223, 58, 0), Champion.Tracer },
            { Color.FromArgb(255, 31, 51, 24), Champion.Bastion },
            { Color.FromArgb(255, 135, 118, 39), Champion.Hanzo },
            { Color.FromArgb(255, 255, 135, 2), Champion.Junkrat },
            { Color.FromArgb(255, 18, 98, 255), Champion.Mei },
            { Color.FromArgb(255, 150, 21, 14), Champion.Torbjorn },
            { Color.FromArgb(255, 78, 14, 84), Champion.Widowmaker },
            { Color.FromArgb(255, 255, 57, 154), Champion.Dva },
            { Color.FromArgb(255, 61, 78, 79), Champion.Reinhardt },
            { Color.FromArgb(255, 128, 48, 2), Champion.Roadhog },
            { Color.FromArgb(255, 84, 87, 128), Champion.Winston },
            { Color.FromArgb(255, 255, 33, 116), Champion.Zarya },
            //{ Color.FromArgb(255, 78, 14, 84), Champion.Ana },
            { Color.FromArgb(255, 40, 170, 2), Champion.Lucio },
            { Color.FromArgb(255, 255, 255, 127), Champion.Mercy },
            { Color.FromArgb(255, 55, 139, 177), Champion.Symmetra },
            { Color.FromArgb(255, 255, 255, 31), Champion.Zenyatta }
        };

        public static Champion? GetChampion(Color championColor)
        {
            if (!ColourDictionary.ContainsKey(championColor))
            {
                return null;
            }
            return ColourDictionary[championColor];
        }

        public static Color? GetChampionColor(Champion champ)
        {
            if (ColourDictionary.ContainsValue(champ))
            {
                return ColourDictionary.FirstOrDefault(x => x.Value == champ).Key;
            }
            return null;
        }
    }
}
