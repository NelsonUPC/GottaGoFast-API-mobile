using GottaGoFast.Domain.Publishing.Models.Entities;
using GottaGoFast.Domain.Publishing.Repositories;
using GottaGoFast.Infraestructure.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace GottaGoFast.Infraestructure.Publishing.Persistence;

public class RentRepository : IRentRepository
{
    private readonly DriveSafeDBContext _driveSafeDbContext;
    
    public RentRepository(DriveSafeDBContext driveSafeDbContext)
    {
        _driveSafeDbContext = driveSafeDbContext;
    }
    
    public async Task<List<Rent>> GetAllAsync()
    {
        var result = await _driveSafeDbContext.Rents.Where(r => r.IsActive).ToListAsync();
        return result;
    }

    public async Task<Rent> GetByIdAsync(int id)
    {
        return await _driveSafeDbContext.Rents.Where(r => r.Id == id).FirstOrDefaultAsync();
    }

    public async Task<int> SaveAsync(Rent? data)
    {
        await using (var transaction = await _driveSafeDbContext.Database.BeginTransactionAsync())
        {
            try
            {
                if (data != null)
                {
                    data.IsActive = true;
                    _driveSafeDbContext.Rents.Add(data);
                }
                await _driveSafeDbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        if (data != null) return data.Id;
        return 0;
    }


    public async Task<bool> UpdateAsync(Rent data, int id)
    {
        var existingRent = _driveSafeDbContext.Rents.FirstOrDefault(r => r.Id == id);
        if (existingRent != null)
        {
            existingRent.Status = data.Status;
            existingRent.PickupDate = data.PickupDate;
            existingRent.DropoffDate = data.DropoffDate;
            existingRent.PickUpLocation = data.PickUpLocation;
            existingRent.DroppOfLocation = data.DroppOfLocation;
            existingRent.RentalRate = data.RentalRate;
            existingRent.Surcharge = data.Surcharge;
            existingRent.SalesTax = data.SalesTax;
            existingRent.TotalPrice = data.TotalPrice;
            _driveSafeDbContext.Rents.Update(existingRent);
        }
        await _driveSafeDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existingRent = _driveSafeDbContext.Rents.FirstOrDefault(r => r.Id == id);
        if (existingRent != null)
        {
            _driveSafeDbContext.Rents.Remove(existingRent);
        }
        await _driveSafeDbContext.SaveChangesAsync();
        return true;
    }
    
}