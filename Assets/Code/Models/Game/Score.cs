using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class Score
{
    public int id { get; set; }
    public string name { get; set; }
    public int score { get; set; }

    public Score(int id, string name, int score)
    {
        this.id = id;
        this.name = name;
        this.score = score;
    }
}
