using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        private readonly IProviderDeliveryService providerDeliveryService;

        public ProviderDeliveryController(IProviderDeliveryService providerDeliveryService)
        {
            this.providerDeliveryService = providerDeliveryService;
        }

        [HttpPost]
        [Route("InsertProvider")]
        public async Task<IActionResult> InsertProvider(ProviderInsert provider)
        {
            if (provider == null)
            {
                return StatusCode(Codes.Number_204, Messages.NoContent_204NoContent);
            }

            if (await providerDeliveryService.GetProviderByNameAsync(provider.Name) != null)
            {
                return StatusCode(Codes.Number_409, Messages.AlreadyExist_409Conflict);
            }

            var newProvider = new Provider
            {
                Name = provider.Name,
                ContactData = provider.ContactData
            };

            if (await providerDeliveryService.InsertProvider(newProvider) == false)
            {
                return StatusCode(Codes.Number_400, Messages.SthWentWrong_400BadRequest);
            }

            return StatusCode(Codes.Number_201, Messages.Created_201Ok);
        }

        [HttpPost]
        [Route("InsertDelivery")]
        public async Task<IActionResult> InsertDelivery(DeliveryInsert delivery)
        {
            if (delivery == null)
            {
                return StatusCode(Codes.Number_204, Messages.NoContent_204NoContent);
            }

            if (await providerDeliveryService.GetDeliveryByNameAsync(delivery.Name) != null)
            {
                return StatusCode(Codes.Number_409, Messages.AlreadyExist_409Conflict);
            }

            var newDelivery = new Delivery
            {
                Name = delivery.Name,
                Specification = delivery.Specification
            };

            if (await providerDeliveryService.InsertDelivery(newDelivery) == false)
            {
                return StatusCode(Codes.Number_400, Messages.SthWentWrong_400BadRequest);
            }

            return StatusCode(Codes.Number_201, Messages.Created_201Ok);
        }

        [HttpPost]
        [Route("InsertProviderDelivery")]
        public async Task<IActionResult> InsertProviderDelivery(ProviderDeliveryInsert providerDeliveryInsert)
        {
            if (providerDeliveryInsert == null)
            {
                return StatusCode(Codes.Number_204, Messages.NoContent_204NoContent);
            }

            var newProviderDelivery = new ProviderDelivery
            {
                Delivery = await providerDeliveryService.GetDeliveryByNameAsync(providerDeliveryInsert.DeliveryName),
                Provider = await providerDeliveryService.GetProviderByNameAsync(providerDeliveryInsert.ProviderName),
                DeliveryCompany = providerDeliveryInsert.DeliveryCompany,
                Price = providerDeliveryInsert.Price,
                Specification = providerDeliveryInsert.Specification
            };

           if (newProviderDelivery.Provider==null || newProviderDelivery.Delivery==null)
            {
                return StatusCode(Codes.Number_400, Messages.SthWentWrong_400BadRequest);
            }

            if (await providerDeliveryService.InsertProviderDelivery(newProviderDelivery) == false)
            {
                return StatusCode(Codes.Number_400, Messages.SthWentWrong_400BadRequest);
            }

            return StatusCode(Codes.Number_201, Messages.Created_201Ok);
        }

        [HttpGet]
        [Route("GetDelivery")]
        public async Task<IActionResult> GetDelivery()
        {
            var deliveries = await providerDeliveryService.GetDeliveriesAsync();

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
            var providers = await providerDeliveryService.GetProvidersAsync();

            if (providers == null)
            {
                return StatusCode(Codes.Number_400, Messages.SthWentWrong_400BadRequest);
            }

            return StatusCode(Codes.Number_200, providers);
        }


        [HttpGet]
        [Route("GetProvidersDeliveries")]
        public async Task<IActionResult> GetProvidersDeliveries()
        {
            var providersdeliveries = await providerDeliveryService.GetProvidersDeliveriesAsync();

            if (providersdeliveries == null)
            {
                return StatusCode(Codes.Number_400, Messages.SthWentWrong_400BadRequest);
            }

            var newProvDeliver = new List<ProviderDeliveryView>();
            foreach(var provdeliver in providersdeliveries)
            {
                newProvDeliver.Add(new ProviderDeliveryView
                {
                    DeliveryCompany = provdeliver?.DeliveryCompany,
                    DeliveryName=provdeliver?.Delivery?.Name,
                    DeliverySpecification=provdeliver?.Delivery?.Specification,
                    Specification=provdeliver?.Specification,
                    Price=provdeliver.Price,
                    ProviderContactData=provdeliver?.Provider?.ContactData,
                    ProviderDeliveryID=provdeliver.ID.ToString(),
                    ProviderName=provdeliver?.Provider?.Name
                }) ;
            }

            return StatusCode(Codes.Number_200, newProvDeliver);
        }

        [Route("DeleteProviderDelivery")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProviderDelivery(String id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return StatusCode(Codes.Number_204, Messages.NoContent_204NoContent);
            }

            if (await providerDeliveryService.GetProviderDeliveryByIdAsync(Int32.Parse(id)) == null)
            {
                return StatusCode(Codes.Number_404, Messages.NotFound_4040NotFound);
            }

            if (await providerDeliveryService.DeleteProviderDeliveryByIdAsync(Int32.Parse(id)) == false)
            {
                return StatusCode(Codes.Number_400, Messages.SthWentWrong_400BadRequest);
            }

            return Ok();
        }

    }
}