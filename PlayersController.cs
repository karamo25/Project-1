using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FifaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        Players playerObj = new Players();

        #region Add Player 
        [HttpPost]
        [Route("addName/{playerName}addPosition/{playerPosition} addTeam/{playerTeam} addImage/{playerImage} addId/{playerTeamId}")]
        
        public IActionResult addPlayer(string playerName,string playerPosition, string playerTeam,string playerImage,int playerTeamId)
        {
            return Ok(playerObj.addPlayer(playerName, playerPosition, playerTeam,playerImage, playerTeamId));
        }
        #endregion

        #region Delete Player 
        [HttpDelete]
        [Route("delete/{playerID}")]
        public IActionResult DeletePlayer(int playerID)
        {
            try
            {
                return Ok(playerObj.deletePlayer(playerID));
            }
            catch(Exception es)
            {
                return BadRequest(es.Message);
            }
        }

        #endregion

        #region Update Player
        [HttpPut]
        [Route("movePlayer/{playerID} {newTeam}")]
        public IActionResult MovePlayer(int playerID,int newTeam)
        {
            try
            {
                return Ok(playerObj.updatePlayerTeam(playerID, newTeam));
            }
            catch (Exception es)
            {
                return BadRequest(es.Message);
            }
        }

        #endregion

        #region Get Player By Name 
        [HttpGet]
        [Route("playerName")]
        public IActionResult playerData(string aPlayerName)
        {
            return Ok(playerObj.getPlayer(aPlayerName));
        }

        #endregion

        #region Get All Players
        [HttpGet]
        [Route("ListofPlayers")]
        public IActionResult getAllPlayers()
        {
            return Ok(playerObj.getAllPlayers());
        }

        #endregion

        #region Number of Players
        [HttpGet]
        [Route("NumberOfPlayers")]
        public IActionResult getNumofPlayers()
        {
            return Ok(playerObj.getNumofPlayers());
        }

        #endregion 


    }
}
