using QuirkyCarRepair.BLL.Areas.CarService.DTO;
using QuirkyCarRepair.BLL.Areas.InvoiceGenerator.Models;
using QuirkyCarRepair.BLL.Areas.Warehouse.DTO;

namespace QuirkyCarRepair.BLL.Areas.InvoiceGenerator.Services
{
    public static class InvoiceDocumentDataSource
    {
        private static Random Random = new Random();

        public static InvoiceModel GetInvoiceDetails(DetailsServiceOrderDTO detailsServiceOrder)
        {
            return new InvoiceModel
            {
                InvoiceNumber = detailsServiceOrder.DocumentNumber,
                IssueDate = detailsServiceOrder.StatusStartDate,
                DueDate = detailsServiceOrder.StatusStartDate + TimeSpan.FromDays(14),

                SellerAddress = GenerateQRCAddress(),
                CustomerAddress = GenerateCustomerAddress(detailsServiceOrder.UserData),

                Items = GenerateOrderItem(detailsServiceOrder.Parts, detailsServiceOrder.ServiceTransactions),
            };
        }

        private static List<OrderThing> GenerateOrderItem(List<PartDTO> parts, List<ServiceTransactionDTO> serviceTransactions)
        {
            List<OrderThing> orderThings = new List<OrderThing>();

            if (parts != null && parts.Count != 0)
            {
                foreach (var part in parts)
                {
                    orderThings.Add(new OrderThing()
                    {
                        Name = part.Name,
                        Price = part.UnitPrice,
                        Quantity = part.Quantity
                    });
                }
            }

            if (serviceTransactions != null && serviceTransactions.Count != 0)
            {
                foreach (var serviceTransaction in serviceTransactions)
                {
                    orderThings.Add(new OrderThing()
                    {
                        Name = serviceTransaction.Name,
                        Price = serviceTransaction.Price,
                        Quantity = serviceTransaction.Quantity
                    });
                }
            }

            return orderThings;
        }

        private static Address GenerateCustomerAddress(OrderOwnerDTO orderOwner)
        {
            return new Address
            {
                Name = $"{orderOwner.FirstName} {orderOwner.LastName}",
                Email = "",
                Phone = orderOwner.PhoneNumber
            };
        }

        private static Address GenerateQRCAddress()
        {
            return new Address
            {
                Name = "Quirky Car Repair, Inc.",
                Email = "office@qcr.com",
                Phone = "+48 123 123 123"
            };
        }
    }
}