using MedicineManagerAPI.Models;
using MedicineManagerAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MedicineManagerAPI.Controllers
{
    [Route("api/medicinecabinet")]
    [ApiController]
    [Authorize]
    public class MedicineCabinetController : ControllerBase
    {
        private readonly IMedicineCabinetService _medicineCabinetService;
        private readonly IAuthorizationService _authorizationService;
        public MedicineCabinetController(IMedicineCabinetService medicineCabinetService, IAuthorizationService authorizationService)
        {
            _medicineCabinetService = medicineCabinetService;
            _authorizationService = authorizationService;
        }

        [HttpPost]
        //[AllowAnonymous]
        public ActionResult CreateMedicine([FromBody] CreateMedicineDto dto)
        {
            
            var id = _medicineCabinetService.Create(dto);

            return Created($"/api/medicineCabinet/{id}", null);
        }

        [HttpGet("{id}")]
        public ActionResult<MedicineCabinetDto> Get([FromRoute] int id)
        {
            var medicine = _medicineCabinetService.GetById(id);
            return Ok(medicine);
        }
        [HttpGet]
        public ActionResult<List<MedicineCabinetDto>> GetAll([FromQuery]MedicineCabinetQuery query)
        {
            var medicine = _medicineCabinetService.GetAll(query);
            return Ok(medicine);
        }

        [HttpPut("{id}")]
        public ActionResult Update ([FromBody] UpdateMedicine dto, [FromRoute] int id)
        {
            _medicineCabinetService.Update(id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _medicineCabinetService.Delete(id);
            return NoContent();
        }
        [HttpGet("/api/getalldebag")]
        [AllowAnonymous]
        public ActionResult<List<MedicineCabinetDto>> GetAllDebag()
        {
            var medicine = _medicineCabinetService.GetAllDebag();
            return Ok(medicine);
        }
    }
}
