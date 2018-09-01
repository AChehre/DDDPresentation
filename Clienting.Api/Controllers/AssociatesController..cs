using System;
using Clienting.Api.Services;
using Clienting.Domain.AggregatesModel.AssociateAggregate;
using Clienting.Domain.AggregatesModel.ClientAggregate;
using Microsoft.AspNetCore.Mvc;

namespace Clienting.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssociatesController : ControllerBase
    {
        private readonly IAssociateRepository _associateRepository;
        private readonly IAssociateService _associateService;
        private readonly IClientRepository _clientRepository;

        public AssociatesController(IAssociateRepository associateRepository, IClientRepository clientRepository,
            IAssociateService associateService)
        {
            _associateRepository = associateRepository;
            _clientRepository = clientRepository;
            _associateService = associateService;
        }

        [HttpPost("{associateId}/clients/{clientId}")]
        public IActionResult AssociateWorksForClient(string associateId, string clientId)
        {
            try
            {
                var client = _clientRepository.GetClientById(clientId);
                if (client == null)
                {
                    throw new MissingMemberException($"Client with id {clientId} not found!");
                }




                var associate = _associateRepository.LoadAssociateWithClients(associateId);
                if (associate == null)
                {
                    throw new MissingMemberException($"Associate with id {associateId} not found!");
                }

                _associateService.AssociateWorkForClient(associate, client);
                return Created($"associates/{associate.AssociateId}/clients", associate);
            }
            catch (MissingMemberException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}