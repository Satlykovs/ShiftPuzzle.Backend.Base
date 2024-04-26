using Microsoft.AspNetCore.Mvc;

[Route("api/carpool/")]
public class CarpoolController : ControllerBase
{
    private readonly ICarpoolManager _carpoolManager;

    public CarpoolController(ICarpoolManager carpoolManager)
    {
        _carpoolManager = carpoolManager;
    }

    [HttpGet("search")]
    public IActionResult GetUsers(string origin, string destination)
    {
        return Ok(_carpoolManager.GetUsers(origin, destination));
    }

    [HttpPost("add")]
    public IActionResult AddUser([FromBody] User user)
    {
        _carpoolManager.AddUser(user);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        _carpoolManager.DeleteUser(id);
        return Ok();
    }
}