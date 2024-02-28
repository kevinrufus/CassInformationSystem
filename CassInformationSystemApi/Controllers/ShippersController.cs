using AutoMapper;
using CassInformationSystem.Application.Contracts;
using CassInformationSystemApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace CassInformationSystemApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShippersController : ControllerBase
    {
        private readonly ILogger<ShippersController> _logger;
        private readonly IShipperService _shipperService;
        private readonly IMapper _mapper;

        public ShippersController(ILogger<ShippersController> logger,IShipperService shipperService, IMapper mapper)
        {
            _logger = logger;
            _shipperService = shipperService;
            _mapper = mapper;
        }

        [HttpGet("get-shippers", Name = "GetShippers")]
        public async Task<ActionResult> GetShippers()
        {
            _logger.LogInformation("Get Shippers - ShippersController function called");
            var shippersList = _mapper.Map<List<ShippersReturnableDto>>(await _shipperService.GetShippers());
            _logger.LogInformation("Get Shippers - ShippersController function execuuted");
            return Ok(new ResponseModel(shippersList, (int)HttpStatusCode.OK, true));
        }

        [HttpGet("get-shipper-shipment-details", Name = "GetShipperAndShipmentDetails")]
        public async Task<ActionResult> GetShipperAndShipmentDetails([Required] int shipperId)
        {
            _logger.LogInformation("Get Shippers And Shipment Details - ShippersController function called");
            var result = await _shipperService.GetShipperShipmentDetails(shipperId);
            var returnableData = _mapper.Map<List<ShipperShipmentDetailsReturnableDto>>(result);
            if(returnableData.Count > 1)
            {
                _logger.LogInformation("Get Shippers And Shipment Details - ShippersControllerfunction executed");
                return Ok(new ResponseModel(returnableData, (int)HttpStatusCode.OK, true));
            }
            else
            {
                _logger.LogInformation("Get Shippers And Shipment Details - ShippersController function executed but no data found for shipperId @shipperId", shipperId);
                return Ok(new ResponseModel(Array.Empty<ShipperShipmentDetailsReturnableDto>(),
                    (int)HttpStatusCode.NotFound, false, $"No data found for shipperId {shipperId}"));
            }
        }
    }
}
