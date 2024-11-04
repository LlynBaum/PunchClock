using M223PunchclockDotnet.Dto;
using M223PunchclockDotnet.Model;
using Microsoft.EntityFrameworkCore;

namespace M223PunchclockDotnet.Service
{
    public class EntryService(DatabaseContext databaseContext)
    {
        public Task<List<Entry>> GetAll()
        {
            return databaseContext.Entries.ToListAsync();
        }

        public async Task<Entry> AddEntry(EntryDto entryDto)
        {
            var entry = new Entry
            {
                CheckIn = entryDto.CheckIn,
                CheckOut = entryDto.CheckOut
            };
            
            databaseContext.Entries.Add(entry);
            await databaseContext.SaveChangesAsync();

            return entry;
        }

        public async Task<Entry> DeleteAsync(int id, CancellationToken cancellation)
        {
            var entry = await databaseContext.Entries.SingleOrDefaultAsync(e => e.Id == id, cancellation);

            if (entry is null) throw new ArgumentException($"Entry with Id = {id} not found");
            
            databaseContext.Entries.Remove(entry);
            await databaseContext.SaveChangesAsync(cancellation);
            return entry;
        }

        public async Task<Entry> UpdateAsync(int id, EntryDto entryDto, CancellationToken cancellation)
        {
            var existing = await databaseContext.Entries.SingleOrDefaultAsync(e => e.Id == id ,cancellation);

            if (existing is null) throw new ArgumentException($"Entry with Id = {id} not found");

            existing.CheckIn = entryDto.CheckIn;
            existing.CheckOut = entryDto.CheckOut;

            databaseContext.Entries.Update(existing);
            await databaseContext.SaveChangesAsync(cancellation);
            return existing;
        }
    }
}
