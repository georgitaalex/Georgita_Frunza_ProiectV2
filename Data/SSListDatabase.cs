
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Georgita_Frunza_Proiect.Models;


namespace Georgita_Frunza_Proiect.Data
{
    public class SSListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public SSListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<SSList>().Wait();
            _database.CreateTableAsync<Sport>().Wait();
            _database.CreateTableAsync<ListSport>().Wait();
        }
        public Task<int> SaveSportAsync(Sport product)
        {
            if (product.ID != 0)
            {
                return _database.UpdateAsync(product);
            }
            else
            {
                return _database.InsertAsync(product);
            }
        }
        public Task<int> DeleteSportAsync(Sport product)
        {
            return _database.DeleteAsync(product);
        }
       
        public Task<List<Sport>> GetSportsAsync()
        {
            return _database.Table<Sport>().ToListAsync();
        }
    

        public Task<List<SSList>> GetSSListsAsync()
        {
            return _database.Table<SSList>().ToListAsync();
        }
        public Task<SSList> GetSSListAsync(int id)
        {
            return _database.Table<SSList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveSSListAsync(SSList sportslist)
        {
            if (sportslist.ID != 0)
            {
                return _database.UpdateAsync(sportslist);
            }
            else
            {
                return _database.InsertAsync(sportslist);
            }
        }
        public Task<int> DeleteSSListAsync(SSList sportslist)
        {
            return _database.DeleteAsync(sportslist);
        }
        public Task<int> SaveListSportAsync(ListSport listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Sport>> GetListSportsAsync(int shoplistid)
        {
            return _database.QueryAsync<Sport>(
            "select P.ID, P.Description from Sport P"
            + " inner join ListSport LP"
            + " on P.ID = LP.SportID where LP.SSListID = ?",
            shoplistid);
        }
    }
}

