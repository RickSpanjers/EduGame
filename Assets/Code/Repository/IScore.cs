using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.Repository
{
    interface IScore
    {
        List<Score> RetrieveHighscores();
        bool SaveCharacterPoints();
    }
}
