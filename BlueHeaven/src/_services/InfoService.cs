using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BlueHeaven.src.Enums;

namespace BlueHeaven.src.Services
{
    /// <summary>
    /// Handles printing static information to component
    /// </summary>
    public class InfoService
    {
        private List<string> _lines;
        private int _limit;
        private int _page;
        public InfoService(string key, int pagelimit)
        {
            LoadLines(key);
            if (pagelimit > 0 && pagelimit <= _lines.Count) _limit = pagelimit;
            else _limit = _lines.Count;
            _page = 0;
        }

        /// <summary>
        /// Increment by 1 page
        /// </summary>
        public void UpOnePage()
        {
            if ((_page + 1) * _limit < _lines.Count) _page += 1;
        }

        /// <summary>
        /// Decrement by 1 page
        /// </summary>
        public void DownOnePage()
        {
            if (_page > 0) _page -= 1;
        }
        
        /// <summary>
        /// Load lines to print 
        /// </summary>
        public void LoadLines(string key)
        {
            _lines = new List<string>();
            // limit line size!! based on font
            switch (key)
            {
                case "HELP":
                    _lines.Add("So this is the help section.");
                    _lines.Add("To be added later^^");
                    break;
                case "CREDITS":
                    _lines.Add("This is for crediting.");
                    _lines.Add("Also adding later^^");
                    break;
                default:
                    _lines.Add("Some information here, error?");
                    break;
            }
        }

        /// <summary>
        /// Print lines to a set pos
        /// </summary>
        /// <param name="cornerpos"></param>
        /// <param name="sbatch"></param>
        /// <param name="font"></param>
        public void PrintLines(int[] cornerpos, SpriteBatch sbatch, FontEnum font = FontEnum.Font20)
        {
            for (int index = _page * _limit; index < (_page + 1) * _limit; index++)
            {
                CommonUtilities.DrawFont(
                    _lines[index],
                    font,
                    new Vector2(cornerpos[0], cornerpos[1] + index * (int)font),
                    Color.Black,
                    sbatch);
            }
        }

        public int PageNumber { get => _page + 1; }
    }
}
