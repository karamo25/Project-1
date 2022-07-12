using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FifaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        Teams teamObj = new Teams();

        #region Add Team 
        [HttpPost]
        [Route("addTeam/{teamName} addCountry/{teamCountry} addFlag{teamFlag} addJersey{teamJersey}")]
       
        public IActionResult AddTeam(string teamName,string teamCountry,string teamFlag,string teamJersey)
        {
            return Ok(teamObj.AddTeam(teamName,teamCountry,teamFlag,teamJersey));
        }
        #endregion

        #region Get Team List 
        [HttpGet]
        [Route("TeamList")]
        public IActionResult GetAllTeams()
        {
            return Ok(teamObj.getAllTeams());
        }

        #endregion

        #region Get Team By ID
        [HttpGet]
        [Route("GetTeamByID")]
        public IActionResult getTeamfromID(int teamID)
        {
            return Ok(teamObj.getTeambyID(teamID));
        }

        #endregion

        #region Get Team By Name

        [HttpGet]
        [Route("teamCountry")]
        public IActionResult getTeamByName(string pTeamName)
        {
            return Ok(teamObj.getATeam(pTeamName));
        }

        #endregion

        #region Count Number of Teams 
        [HttpGet]
        [Route("NumberofTeams")]
        public IActionResult getNumofTeams()
        {
            return Ok(teamObj.getTeamNum());
        }
        #endregion 

    }
}
