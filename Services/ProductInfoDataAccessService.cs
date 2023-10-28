using Azure.Core;
using Azure.Identity;
using Core_CQRS_Mediatr.Models;
using Microsoft.EntityFrameworkCore;

namespace Core_CQRS_Mediatr.Services
{
    public class ProductInfoDataAccessService : IDataAccessService<ProductInfo, string>
    {

        CompanyContext ctx;
        ResponseObject<ProductInfo> Response;

        public ProductInfoDataAccessService(CompanyContext ctx)
        {
            this.ctx = ctx;
            Response = new ResponseObject<ProductInfo>();
        }

        async Task<ResponseObject<ProductInfo>> IDataAccessService<ProductInfo, string>.CreateAsync(ProductInfo entity)
        {
            try
            {
              
                var result = await ctx.ProductInfos.AddAsync(entity);
                await ctx.SaveChangesAsync();
                Response.Record = result.Entity;
                Response.Message = "Record is Added Successfully.";
                Response.StatucCode = 201;
                return Response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<ResponseObject<ProductInfo>> IDataAccessService<ProductInfo, string>.DeleteAsync(string id)
        {
            try
            {
                Response.Record = await ctx.ProductInfos.FindAsync(id);
                if (Response.Record is null)
                    throw new Exception($"Recortd with ProductId : {id} is not found.");


                int recordDeleted = ctx.ProductInfos.Where(prd => prd.ProductId == id).ExecuteDelete();

                if (recordDeleted == 0)
                {
                    Response.Message = "Record Delete Failed";
                    Response.StatucCode = 500;
                }
                else
                {
                    Response.Message = "Record is Deleted Successfully.";
                    Response.StatucCode = 200;
                }
                return Response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<ResponseObject<ProductInfo>> IDataAccessService<ProductInfo, string>.GetAsync()
        {
            try
            {
                Response.Records = await ctx.ProductInfos.ToListAsync();
                Response.Message = "Record is Read Successfully.";
                Response.StatucCode = 200;
                return Response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<ResponseObject<ProductInfo>> IDataAccessService<ProductInfo, string>.GetByIdAsync(string id)
        {
            try
            {
                Response.Record = await ctx.ProductInfos.FindAsync(id);
                Response.Message = "Record is Read Successfully.";
                Response.StatucCode = 200;
                return Response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<ResponseObject<ProductInfo>> IDataAccessService<ProductInfo, string>.UpdateAsync(string id, ProductInfo entity)
        {
            try
            {
                Response.Record = await ctx.ProductInfos.FindAsync(id);
                if (Response.Record is null)
                    throw new Exception($"Recortd with ProductId : {id} is not found.");


                int recordUpdated = ctx.ProductInfos
                    .Where(prd => prd.ProductId == id)
                    .ExecuteUpdate(setters => setters
                        .SetProperty(prd => prd.ProductName, entity.ProductName)
                        .SetProperty(prd => prd.Manufacturer, entity.Manufacturer)
                        .SetProperty(prd => prd.Description, entity.Description)
                        .SetProperty(prd => prd.BasePrice, entity.BasePrice)
                  );
                if (recordUpdated == 0)
                {
                    Response.Message = "Record Update Failed";
                    Response.StatucCode = 500;
                }
                else
                {
                    Response.Record = await ctx.ProductInfos.FindAsync(id);
                    Response.Message = "Record is Updated Successfully.";
                    Response.StatucCode = 204;
                }
                return Response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
