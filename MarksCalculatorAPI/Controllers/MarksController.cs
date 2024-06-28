using Microsoft.AspNetCore.Mvc;
using MarksCalculatorAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace MarksCalculatorAPI.Controllers
{
    [ApiController]
    [Route("api/marks")]
    public class MarksController : ControllerBase
    {
        private static List<MarksModel> _marksData = new List<MarksModel>();

        [HttpPost("calculate")]
        public ActionResult<double> CalculatePercentage([FromBody] List<MarksModel> marks)
        {
            if (marks == null || !marks.Any())
    {
        return BadRequest("Marks cannot be empty");
    }

    _marksData.Clear();

    double totalMarks = marks.Sum(m => m.Marks);
    double totalMaxMarks = marks.Sum(m => m.MaxMarks);

    if (totalMarks > totalMaxMarks)
    {
        return BadRequest("Marks cannot be greater than Max Marks");
    }

    foreach (var mark in marks)
    {
        var calculatedMark = new MarksModel(mark.Subject, mark.Marks, mark.MaxMarks);
                _marksData.Add(calculatedMark);
    }

    double overallPercentage = Math.Round((totalMarks / totalMaxMarks) * 100, 2);
    return Ok(overallPercentage);
        }

        [HttpGet("marks")]
        public ActionResult<List<MarksModel>> GetMarksData()
        {
            return Ok(_marksData);
        }
    }
}
