using Assets.Code.DBContext;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.Repository.MySQL
{
    class ScoreMySQLContext : ConnectionHelper, IScore
    {
        public List<Score> RetrieveHighscores()
        {
            List<Score> listOfScores = new List<Score>();
            try
            {
                MySqlConnection cnn = ReturnSQLConnection();
                string sql = "SELECT * FROM scores ORDER BY Score DESC LIMIT 10";
                var cmd = cnn.CreateCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int scoreId = Convert.ToInt32(dr["ScoreId"]);
                    string username = dr["Name"].ToString();
                    int score = Convert.ToInt32(dr["Score"]);
                    Score highscore = new Score(scoreId, username, score);
                    listOfScores.Add(highscore);
                }

                cnn.Close();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            return listOfScores;
        }

        public bool SaveCharacterPoints()
        {
            try
            {
                MySqlConnection cnn = ReturnSQLConnection();
                string query = "INSERT INTO scores (Name, Score) VALUES (@Name, @Score)";

                MySqlCommand newCmd = new MySqlCommand();
                newCmd.Connection = cnn;
                newCmd.CommandType = CommandType.Text;
                newCmd.CommandText = query;

                newCmd.Parameters.AddWithValue("@Name", PersistenceManager.manager.characterName);
                newCmd.Parameters.AddWithValue("@Score", PersistenceManager.manager.characterPoints);
                newCmd.ExecuteNonQuery();
                cnn.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;

        }
    }
}
