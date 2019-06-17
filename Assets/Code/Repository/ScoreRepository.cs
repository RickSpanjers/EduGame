using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.Repository
{
    class ScoreRepository
    {
        private readonly IScore scoreInterace;

        public ScoreRepository(IScore context)
        {
            scoreInterace = context;
        }

        public List<Score> RetrieveHighscores()
        {
            return scoreInterace.RetrieveHighscores();
        }

        public bool SaveCharacterPoints()
        {
            return scoreInterace.SaveCharacterPoints();
        }
    }
}
