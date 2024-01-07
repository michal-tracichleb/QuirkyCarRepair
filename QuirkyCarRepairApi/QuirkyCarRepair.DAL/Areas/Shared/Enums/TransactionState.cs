﻿namespace QuirkyCarRepair.DAL.Areas.Shared.Enums
{
    public enum TransactionState
    {
        Pending = 0,
        Canceled = 1,
        ArrangeOrder = 2,
        ReadyForPickup = 3,
        Received = 4,
        Return = 5,
        AcceptedReturn = 6,
        Complaint = 7,
        Ready = 8
    }
}