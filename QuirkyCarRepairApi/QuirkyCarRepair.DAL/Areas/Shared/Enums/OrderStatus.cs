namespace QuirkyCarRepair.DAL.Areas.Shared.Enums
{
    public enum OrderStatus
    {
        Pending = 0,
        Canceled = 1,

        ArrangeOrder = 2,
        ReadyForPickup = 3,
        OrderCompleted = 4,
        Return = 5,
        AcceptedReturn = 6,

        Complaint = 7,
        Ready = 8,

        AcceptedDate = 9,
        RepairAnalysis = 10,
        PendingForClientAccepting = 11,
        AcceptedByClient = 12,
        CanceledByclient = 13,
        Repair = 14
    }
}