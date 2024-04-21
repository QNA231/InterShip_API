using InternShip_API.DataContext;
using InternShip_API.Entities;
using InternShip_API.Handels.HandleGenerate;
using InternShip_API.PayLoads.Converters;
using InternShip_API.PayLoads.DataRequests.BillRequests;
using InternShip_API.PayLoads.DataResponses;
using InternShip_API.PayLoads.Responses;
using InternShip_API.Services.Interfaces;

namespace InternShip_API.Services.Implements
{
    public class BillServices : IBillServices
    {
        private readonly AppDbContext dbContext;
        private readonly BillFoodConverter billFoodConverter;
        private readonly BillTicketConverter billTicketConverter;
        private readonly BillConverter billConverter;
        private readonly ResponseObject<DataResponse_Bill> billResponseObject;
        private readonly ResponseObject<DataResponse_BillFood> foodResponseObject;
        private readonly ResponseObject<DataResponse_BillTicket> ticketResponseObject;

        public BillServices(BillFoodConverter billFoodConverter, BillTicketConverter billTicketConverter, BillConverter billConverter, ResponseObject<DataResponse_Bill> billResponseObject, ResponseObject<DataResponse_BillFood> foodResponseObject, ResponseObject<DataResponse_BillTicket> ticketResponseObject)
        {
            dbContext = new AppDbContext();
            this.billFoodConverter = billFoodConverter;
            this.billTicketConverter = billTicketConverter;
            this.billConverter = billConverter;
            this.billResponseObject = billResponseObject;
            this.foodResponseObject = foodResponseObject;
            this.ticketResponseObject = ticketResponseObject;
        }

        public async Task<ResponseObject<DataResponse_Bill>> CreateBill(Request_CreateBill request)
        {
            if(!dbContext.Users.Any(x => x.Id == request.CustomerId))
            {
                return billResponseObject.ResponseError(StatusCodes.Status400BadRequest, "Không tìm thấy thông tin khách hàng", null);
            }
            var promotion = dbContext.Promotions.SingleOrDefault(x => x.Id == request.PromotionId);
            Bill bill = new Bill
            {
                CustomerId = request.CustomerId,
                TradingCode = HandleGenerateCodes.GenerateCode(),
                CreateTime = DateTime.Now,
                Name = request.Name,
                BillStatusId = 1,
                PromotionId = promotion.Id,
                isActive = true,
                BillFoods = null,
                BillTickets = null,
                TotalMoney = 0,
            };
            await dbContext.Bills.AddAsync(bill);
            await dbContext.SaveChangesAsync();

            bill.BillTickets = await CreateListBillTicket(bill.Id, request.BillTickets);
            bill.BillFoods = await CreateListBillFood(bill.Id, request.BillFoods);

            double priceTicket = bill.BillTickets?.Sum(x => dbContext.Tickets.SingleOrDefault(y => y.Id == x.TicketId).PriceTicket * x.Quantity) ?? 0;
            double priceFood = bill.BillFoods?.Sum(x => dbContext.Foods.SingleOrDefault(y => x.Id == x.FoodId).Price * x.Quantity) ?? 0;
            double price = priceTicket + priceFood;
            if(promotion != null)
            {
                bill.TotalMoney = price - (price * promotion.Percent / 100.0);
            }
            else
            {
                bill.TotalMoney = price;
            }
            dbContext.Bills.Update(bill);
            await dbContext.SaveChangesAsync();
            return billResponseObject.ResponseSuccess("Tạo hóa đơn thành công", billConverter.EntityToDTO(bill));
        }

        public async Task<ResponseObject<DataResponse_BillFood>> CreateBillFood(int billId, Request_CreateBillFood request)
        {
            var bill = dbContext.Bills.SingleOrDefault(x => x.Id == billId);
            if (bill == null)
            {
                return foodResponseObject.ResponseError(StatusCodes.Status400BadRequest, "Không tìm thấy hóa đơn", null);
            }
            BillFood billFood = new BillFood
            {
                BillId = billId,
                Quantity = request.Quantity,
                FoodId = request.FoodId,
            };
            await dbContext.BillFoods.AddAsync(billFood);
            await dbContext.SaveChangesAsync();
            return foodResponseObject.ResponseSuccess("Thêm hóa đơn đồ ăn thành công", billFoodConverter.EntityToDTO(billFood));
        }

        public async Task<ResponseObject<DataResponse_BillTicket>> CreateBillTicket(int billId, Request_CreateBillTicket request)
        {
            var bill = dbContext.Bills.SingleOrDefault(x => x.Id == billId);
            if (bill == null)
            {
                return ticketResponseObject.ResponseError(StatusCodes.Status400BadRequest, "Không tìm thấy hóa đơn", null);
            }
            BillTicket billTicket = new BillTicket
            {
                BillId = billId,
                Quantity = 1,
                TicketId = request.TicketId,
            };
            await dbContext.BillTickets.AddAsync(billTicket);
            await dbContext.SaveChangesAsync();
            return ticketResponseObject.ResponseSuccess("Thêm hóa đơn đồ ăn thành công", billTicketConverter.EntityToDTO(billTicket));
        }

        public async Task<List<BillFood>> CreateListBillFood(int billId, List<Request_CreateBillFood> request)
        {
            var bill = dbContext.Bills.SingleOrDefault(x => x.Id == billId);
            if (bill == null)
            {
                return null;
            }
            List<BillFood> list = new List<BillFood>();
            foreach(var item in request)
            {
                BillFood billFood = new BillFood
                {
                    BillId = billId,
                    Quantity = item.Quantity,
                    FoodId = item.FoodId,
                };
                list.Add(billFood);
            }
            await dbContext.BillFoods.AddRangeAsync(list);
            await dbContext.SaveChangesAsync();
            return list;
        }

        public async Task<List<BillTicket>> CreateListBillTicket(int billId, List<Request_CreateBillTicket> request)
        {
            var bill = dbContext.Bills.SingleOrDefault(x => x.Id == billId);
            if (bill == null)
            {
                return null;
            }
            List<BillTicket> list = new List<BillTicket>();
            foreach (var item in request)
            {
                BillTicket billTicket = new BillTicket
                {
                    BillId = billId,
                    Quantity = 1,
                    TicketId = item.TicketId,
                };
                list.Add(billTicket);
            }
            await dbContext.BillTickets.AddRangeAsync(list);
            await dbContext.SaveChangesAsync();
            return list;
        }
    }
}
