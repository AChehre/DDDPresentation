using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clienting.Api.Services;
using Clienting.Domain.AggregatesModel.AssociateAggregate;
using Clienting.Domain.AggregatesModel.ClientAggregate;
using Microsoft.AspNetCore.Mvc;

namespace Clienting.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class AssociateApi : ControllerBase
    {
        private IAssociateRepository AssociateRepository { get; set; }
        private IClientRepository ClientRepository { get; set; }
        private IAssociateService AssociateService { get; set; }

        public AssociateApi(IAssociateRepository associateRepository, IClientRepository clientRepository, IAssociateService associateService)
        {
            AssociateRepository = associateRepository;
            ClientRepository = clientRepository;
            AssociateService = associateService;
        }

        [HttpPost("associates/{associateId}/clients/{clientId}")]
        public IActionResult AssociateWorksForClient(string associateId, string clientId)
        {
            try
            {
                var client = ClientRepository.GetClientById(clientId);
                var associate = AssociateRepository.LoadAssociateWithClients(associateId);
                if(client == null)
                {
                    throw new MissingMemberException($"Client with id {clientId} not found!");
                }
                if(associate == null)
                {
                    throw new MissingMemberException($"Associate with id {associateId} not found!");
                }
                AssociateService.AssociateWorkForClient(associate, client);
                return Created($"associates/{associate.AssociateId}/clients", associate);
            }
            catch(MissingMemberException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
