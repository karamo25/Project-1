using System.Data.SqlClient;
using System;
using System.Collections;

namespace FifaAPI.Controllers
{
    public class Players
    {
        #region Fields 
        public int playerID { get; set; }
        public string playerName { get; set; }
        public string playerPosition { get; set; }
        public string playerTeam { get; set; }

        public string playerImage { get; set; }
        public int playerTeamID { get; set; }
        #endregion
        SqlConnection con = new SqlConnection("server=Karamo-PC\\KARAMOINSTANCE2;database=MYDB;integrated security = true");
        #region Add Player
        public string addPlayer(string pName, string pPosition, string pTeam, string pImage, int pTeamId)
        {
            SqlCommand cmd = new SqlCommand("insert into players values(@playerName,@playerPosition,@playerTeam,@playerImage,@playerTeamId)", con);

            cmd.Parameters.AddWithValue("@playerName", pName);
            cmd.Parameters.AddWithValue("@playerPosition", pPosition);
            cmd.Parameters.AddWithValue("@playerTeam", pTeam);
            cmd.Parameters.AddWithValue("@playerImage", pImage);
            cmd.Parameters.AddWithValue("@playerTeamId", pTeamId);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            return "Player Added Succesfully";
        }
        #endregion

        #region Delete Player
        public string deletePlayer(int playerID)
        {
            SqlCommand cmd = new SqlCommand("delete from players where playerId=@playerID", con);
            cmd.Parameters.AddWithValue("@playerId", playerID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            return "Player Deleted Successfully";
        }
        #endregion

        #region Move Player
        public string updatePlayerTeam(int p_playerID, int newTeamId)
        {
            SqlCommand cmd = new SqlCommand("update players set playerTeamId = @newTeamId where playerId=@p_playerId", con);
            cmd.Parameters.AddWithValue("@newTeamId", newTeamId);
            cmd.Parameters.AddWithValue("@p_playerID", p_playerID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            return "Player Moved Successfully";
        }

        #endregion

        #region Get Player By ID

        public List<Players> getPlayerbyID(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from players where playerId = " + id, con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            List<Players> list = new List<Players>();
            while (rd.Read())
            {
                list.Add(new Players()
                {
                    playerID = Convert.ToInt32(rd[0]),
                    playerName = rd[1].ToString(),
                    playerPosition = rd[2].ToString(),
                    playerTeam = rd[3].ToString(),
                    playerTeamID = Convert.ToInt32(rd[5])
                });
            }
            return list;
            rd.Close();
            con.Close();
        }

        #endregion 
        #region Select Player By Name 

        public List<Players> getPlayer(string vPlayerName)
        {
            SqlCommand cmd = new SqlCommand("select * from players where playerName =@vPlayerName", con);
            cmd.Parameters.AddWithValue("@vPlayerName", vPlayerName);
            con.Open();
            List<Players> playerInfo = new List<Players>();
            SqlDataReader rd1 = cmd.ExecuteReader();
            while (rd1.Read())
            {
                playerInfo.Add(new Players()
                {
                    playerID = Convert.ToInt32(rd1[0]),
                    playerName = rd1[1].ToString(),
                    playerPosition = rd1[2].ToString(),
                    playerTeam = rd1[3].ToString(),
                    playerImage = rd1[4].ToString(),
                    playerTeamID = Convert.ToInt32(rd1[5])
                });
            }
            rd1.Close();
            con.Close();

            return playerInfo;
        }

        #endregion

        #region Select Player By Position 

        public List<Players> getPlayersByPosition(string vPlayerPosition)
        {
            SqlCommand cmd = new SqlCommand("select * from players where playerPosition=@vPlayerPosition", con);
            cmd.Parameters.AddWithValue("@vPlayerPosition", vPlayerPosition);
            con.Open();
            List<Players> playersPos = new List<Players>();

            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                playersPos.Add(new Players()
                {
                    playerID = Convert.ToInt32(rd[0]),
                    playerName = rd[1].ToString(),
                    playerPosition = rd[2].ToString(),
                    playerTeam = rd[3].ToString(),
                    playerImage = rd[4].ToString(),
                    playerTeamID = Convert.ToInt32(rd[5])
                });
            }
            rd.Close();
            con.Close();

            return playersPos;

        }

        #endregion

        #region Select All the Players At Once 
        public List<Players> getAllPlayers()
        {
            SqlCommand cmd = new SqlCommand("select * from players", con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            List<Players>  allPlayers = new List<Players>();
            while (rd.Read())
            {
                allPlayers.Add(new Players()
                {
                    playerID = Convert.ToInt32(rd[0]),
                    playerName = rd[1].ToString(),
                    playerPosition = rd[2].ToString(),
                    playerTeam = rd[3].ToString(),
                    playerImage = rd[4].ToString(),
                    playerTeamID = Convert.ToInt32(rd[5])
                });

            }
            rd.Close();
            con.Close();

            return allPlayers;
        }

        #endregion

        #region Get Number of All the players

        public int getNumofPlayers()
        {
            SqlCommand cmd = new SqlCommand("select count(playerId) from players",con);
            con.Open();
            int num = 0;

            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                num = Convert.ToInt32(rd[0]);
            }
            
         
            return num; 
        }

        #endregion

        #region Search Players By Positon 
        // Return the playerId, name and country of the player 

        public List<Players> getPlayerbyPosition(string position)
        {
            SqlCommand cmd = new SqlCommand("select * from players where playerPosition like @position" , con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            List<Players> playerPos = new List<Players>();
            while (rd.Read())
            {
                playerPos.Add(new Players()
                {
                    playerID = Convert.ToInt32(rd[0]),
                    playerName = rd[1].ToString(),
                    playerPosition = rd[2].ToString(),
                    playerTeam = rd[3].ToString(),
                    playerTeamID = Convert.ToInt32(rd[5])

                });
                rd.Close();
                con.Close() ;
            }

            return playerPos;
        }



        #endregion

        #region Number of Forwards

        public int getPositionNum()
        {
            SqlCommand cmd = new SqlCommand("select count(playerId) from players where playerPosition = 'Forward' ", con);
            con.Open();
            int num = 0;
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
                num = Convert.ToInt32(rd[0]);
            return num;
        }

        #endregion

        #region Number of Midfielders
        
        public int getMidfieldersNumber()
        {
            SqlCommand cmd = new SqlCommand("select count(playerId) from players where playerPosition = 'Midfielder' ", con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            int num = 0;
            if (rd.Read())
                num = Convert.ToInt32(rd[0]);
            rd.Close();
            con.Close();
            return num;
        }

        #endregion

        #region Number of Defenders
        
      public int getNumberofDefenders()
        {
            SqlCommand cmd = new SqlCommand("select count(playerId) from players where playerPosition = 'Defender' " , con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            int num = 0;
            if (rd.Read())
                num = Convert.ToInt32(rd[0]);
            return num;
            rd.Close();
            con.Close();
            
        }

        #endregion

        #region Number of Goalkeepers

        public int getNumberofGoallies()
        {
            SqlCommand cmd = new SqlCommand("select count(playerId) from players where playerPosition = 'Goalkeeper' ",con);
            con.Open();
            int num = 0;
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
                num = Convert.ToInt32(rd[0]);

            return num;
            rd.Close();
            con.Close();

        }

        #endregion 
    }
}
