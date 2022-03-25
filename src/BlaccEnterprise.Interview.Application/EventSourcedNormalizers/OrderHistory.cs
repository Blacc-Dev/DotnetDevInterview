using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

using BlaccEnterprise.Interview.Domain.Order.Enums;
using BlaccEnterprise.Interview.Infrastructure.DomainEvents;

namespace BlaccEnterprise.Interview.Application.EventSourcedNormalizers
{
    public class OrderHistoryData
    {
        public string Action { get; set; }
        public string Timestamp { get; set; }
        public string Who { get; set; }

        public int Id { get; set; }

        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public double Amount { get; set; }
        public EOrderStatus Status { get; set; }
        public string OrderSource { get; set; }
    }

    public class OrderHistory
    {
        public static IList<OrderHistoryData> HistoryData { get; set; }

        public static IList<OrderHistoryData> ToJavaScriptOrderHistory(IList<StoredDomainEvent> storedEvents)
        {
            HistoryData = new List<OrderHistoryData>();
            OrderHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.Timestamp);

            var list = new List<OrderHistoryData>();
            var last = new OrderHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new OrderHistoryData
                {
                    Id = change.Id,
                    OrderNumber = change.OrderNumber,
                    OrderDate = change.OrderDate,
                    Amount = change.Amount,
                    Status = change.Status,
                    OrderSource = change.OrderSource,
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    Timestamp = change.Timestamp,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void OrderHistoryDeserializer(IEnumerable<StoredDomainEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var historyData = JsonSerializer.Deserialize<OrderHistoryData>(e.Data);
                historyData.Timestamp = DateTime.Parse(historyData.Timestamp).ToString("yyyy'-'MM'-'dd' - 'HH':'mm':'ss");

                switch (e.Action)
                {
                    case "OrderCreatedEvent":
                        historyData.Action = "Created";
                        historyData.Who = e.User;
                        break;
                    case "OrderUpdatedEvent":
                        historyData.Action = "Updated";
                        historyData.Who = e.User;
                        break;
                    case "OrderRemovedEvent":
                        historyData.Action = "Removed";
                        historyData.Who = e.User;
                        break;
                }
                HistoryData.Add(historyData);
            }
        }
    }
}
