﻿namespace Clienting.Domain.AggregatesModel.AssociateAggregate.Events
{
    public class AssociateStartedWorkingAtClient
    {

        public string AssociateId { get; set; }
        public string ClientId { get; set; }

        public AssociateStartedWorkingAtClient(string associateId, string clientId)
        {
            AssociateId = associateId;
            ClientId = clientId;
        }
    }
}
