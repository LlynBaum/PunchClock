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

        public async Task<Entry> AddEntry(Entry entry)
        {
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

        public async Task<Entry> UpdateAsync(int id, Entry entry, CancellationToken cancellation)
        {
            var existing = await databaseContext.Entries.SingleOrDefaultAsync(e => e.Id == id ,cancellation);

            if (existing is null) throw new ArgumentException($"Entry with Id = {id} not found");

            existing.CheckIn = entry.CheckIn;
            existing.CheckOut = entry.CheckOut;

            databaseContext.Entries.Update(existing);
            await databaseContext.SaveChangesAsync(cancellation);
            return existing;
        }
    }
}
