using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Plush.BusinessLogicLayer.Service.Interface;
using Plush.DataAccessLayer.Domain.Domain;
using Plush.DataAccessLayer.Domain.Models;
using Plush.Utils;

namespace Plush.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProviderDeliveryController : ControllerBase
    {
        private readonly IProviderService providerService;
        private readonly IDeliveryService deliveryService;

        public ProviderDeliveryController(IProviderService providerService, IDeliveryService deliveryService)
        {
            this.providerService = providerService;
            this.deliveryService = deliveryService;
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("InsertProvider")]
        public async Task<IActionResult> InsertProvider(ProviderInsert provider)
        {
            if (provider == null)
            {
                return StatusCode(Codes.Number_204, Messages.NoContent_204NoContent);
            }

            var newProvider = new Provider
            {
                Name = provider.Name,
                ContactData = provider.ContactData,
                ProviderID = Guid.NewGuid()
            };

            if (await providerService.InsertProvider(newProvider) == false)
            {
                return StatusCode(Codes.Number_400, Messages.SthWentWrong_400BadRequest);
            }

            return StatusCode(Codes.Number_201, Messages.Created_201Ok);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("InsertDelivery")]
        public async Task<IActionResult> InsertDelivery(DeliveryInsert delivery)
        {
            if (delivery == null)
            {
                return StatusCode(Codes.Number_204, Messages.NoContent_204NoContent);
            }

            var newDelivery = new Delivery
            {
                Name = delivery.Name,
                Specification = delivery.Specification,
                DeliveryID=Guid.NewGuid(),
                Price=delivery.Price
            };

            if (await deliveryService.InsertDelivery(newDelivery) == false)
            {
                return StatusCode(Codes.Number_400, Messages.SthWentWrong_400BadRequest);
            }

            return StatusCode(Codes.Number_201, Messages.Created_201Ok);
        }

        [HttpGet]
        [Route("GetDelivery")]
        public async Task<IActionResult> GetDelivery()
        {
            var deliveries = await deliveryService.GetDeliveriesAsync();

            if (deliveries == null)
            {
                return StatusCode(Codes.Number_400, Messages.SthWentWrong_400BadRequest);
            }

            return StatusCode(Codes.Number_200, deliveries);
        }

        [HttpGet]
        [Route("GetProviders")]
        public async Task<IActionResult> GetProviders()
        {
            var providers = await providerService.GetProvidersAsync();

            if (providers == null)
            {
                return StatusCode(Codes.Number_400, Messages.SthWentWrong_400BadRequest);
            }

            return StatusCode(Codes.Number_200, providers);
        }

        [Authorize(Roles = "admin")]
        [Route("DeleteDelivery")]
        [HttpDelete]
        public async Task<IActionResult> DeleteDelivery(String id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return StatusCode(Codes.Number_204, Messages.NoContent_204NoContent);
            }

            if (await deliveryService.DeleteDeliveryByIdAsync(new Guid(id)) == false)
            {
                return StatusCode(Codes.Number_400, Messages.SthWentWrong_400BadRequest);
            }

            return Ok();
        }

        [Authorize(Roles = "admin")]
        [Route("DeleteProvider")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProvider(String id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return StatusCode(Codes.Number_204, Messages.NoContent_204NoContent);
            }

            if (await providerService.DeleteProviderByIdAsync(new Guid(id)) == false)
            {
                return StatusCode(Codes.Number_400, Messages.SthWentWrong_400BadRequest);
            }

            return Ok();
        }

    }
}