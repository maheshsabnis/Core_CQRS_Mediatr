using Azure.Core;
using Azure.Identity;
using Core_CQRS_Mediatr.Models;
using Microsoft.EntityFrameworkCore;

namespace Core_CQRS_Mediatr.Services
{
    public class ProductInfoDataAccessService : IDataAccessService<ProductInfo, string>
    {

        CompanyContext Ctx;
        ResponseRecords<ProductInfo> ResponseRecords;
        ResponseRecord<ProductInfo> ResponseRecord;

        public ProductInfoDataAccessService(CompanyContext Ctx)
        {
            this.Ctx = Ctx;
            ResponseRecords = new ResponseRecords<ProductInfo>();
            ResponseRecord = new ResponseRecord<ProductInfo>();
        }

        async Task<ResponseRecord<ProductInfo>> IDataAccessService<ProductInfo, string>.CreateAsync(ProductInfo entity)
        {
            //try
            //{
              
                var result = await Ctx.ProductInfos.AddAsync(entity);
                await Ctx.SaveChangesAsync();
                ResponseRecord.Record = result.Entity;
                ResponseRecord.Message = "Record is Added Successfully.";
                ResponseRecord.IsSuccess = true;
                return ResponseRecord;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        async Task<ResponseRecord<ProductInfo>> IDataAccessService<ProductInfo, string>.DeleteAsync(string id)
        {
            //try
            //{
                ResponseRecord.Record = await Ctx.ProductInfos.FindAsync(id);
                if (ResponseRecord.Record is null)
                    throw new Exception($"Recortd with ProductId : {id} is not found.");


                int recordDeleted = Ctx.ProductInfos.Where(prd => prd.ProductId == id).ExecuteDelete();

                if (recordDeleted == 0)
                {
                    ResponseRecord.Message = "Record Delete Failed";
                    ResponseRecord.IsSuccess = false; 
                }
                else
                {
                    ResponseRecord.Message = "Record is Deleted Successfully.";
                    ResponseRecord.IsSuccess = true;
                }
                return ResponseRecord;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        async Task<ResponseRecords<ProductInfo>> IDataAccessService<ProductInfo, string>.GetAsync()
        {
            //try
            //{
                ResponseRecords.Records = await Ctx.ProductInfos.ToListAsync();
                ResponseRecords.Message = "Record is Read Successfully.";
                ResponseRecords.IsSuccess = true; 
                return ResponseRecords;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        async Task<ResponseRecord<ProductInfo>> IDataAccessService<ProductInfo, string>.GetByIdAsync(string id)
        {
            //try
            //{
                ResponseRecord.Record = await Ctx.ProductInfos.FindAsync(id);
                ResponseRecord.Message = "Record is Read Successfully.";
                ResponseRecord.IsSuccess = true;
                return ResponseRecord;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        async Task<ResponseRecord<ProductInfo>> IDataAccessService<ProductInfo, string>.UpdateAsync(string id, ProductInfo entity)
        {
            //try
            //{
                ResponseRecord.Record = await Ctx.ProductInfos.FindAsync(id);
                if (ResponseRecord.Record is null)
                    throw new Exception($"Recortd with ProductId : {id} is not found.");


                int recordUpdated = Ctx.ProductInfos
                    .Where(prd => prd.ProductId == id)
                    .ExecuteUpdate(setters => setters
                        .SetProperty(prd => prd.ProductName, entity.ProductName)
                        .SetProperty(prd => prd.Manufacturer, entity.Manufacturer)
                        .SetProperty(prd => prd.Description, entity.Description)
                        .SetProperty(prd => prd.BasePrice, entity.BasePrice)
                  );
                if (recordUpdated == 0)
                {
                    ResponseRecord.Message = "Record Update Failed";
                    ResponseRecord.IsSuccess = false;
                }
                else
                {
                    ResponseRecord.Record = await Ctx.ProductInfos.FindAsync(id);
                    ResponseRecord.Message = "Record is Updated Successfully.";
                    ResponseRecord.IsSuccess = true;
                }
                return ResponseRecord;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
    }
}
