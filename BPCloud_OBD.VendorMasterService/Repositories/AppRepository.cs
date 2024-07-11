using BPCloud_OBD.VendorMasterService.DBContext;
using BPCloud_OBD.VendorMasterService.Models;
using Newtonsoft.Json;
using System.Net;

namespace BPCloud_OBD.VendorMasterService.Repositories
{
    public class AppRepository : IAppRepository
    {
        private readonly MasterContext _dbContext;

        public AppRepository(MasterContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CBPApp> GetAllApps()
        {
            try
            {
                return _dbContext.CBPApps.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CBPApp> CreateApp(CBPApp App)
        {
            try
            {
                App.IsActive = true;
                App.CreatedOn = DateTime.Now;
                var result = _dbContext.CBPApps.Add(App);
                await _dbContext.SaveChangesAsync();
                return App;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CBPApp> UpdateApp(CBPApp App)
        {
            try
            {
                var entity = _dbContext.Set<CBPApp>().FirstOrDefault(x => x.ID == App.ID);
                if (entity == null)
                {
                    return entity;
                }
                //_dbContext.Entry(App).State = EntityState.Modified;
                entity.CCode = App.CCode;
                entity.Type = App.Type;
                entity.Level = App.Level;
                entity.User = App.User;
                entity.StartDate = App.StartDate;
                entity.EndDate = App.EndDate;
                entity.ModifiedBy = App.ModifiedBy;
                entity.ModifiedOn = DateTime.Now;
                await _dbContext.SaveChangesAsync();
                return App;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CBPApp> DeleteApp(CBPApp App)
        {
            try
            {
                //var entity = await _dbContext.Set<CBPApp>().FindAsync(App.App, App.Language);
                var entity = _dbContext.Set<CBPApp>().FirstOrDefault(x => x.ID == App.ID);
                if (entity == null)
                {
                    return entity;
                }

                _dbContext.Set<CBPApp>().Remove(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GspAuthResponse GetGspAuthToken()
        {
            GspAuthResponse gspauthResponse = new GspAuthResponse();
            try
            {
                //string errorCodeDescription = "";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://gsp.adaequare.com/gsp/authenticate?grant_type=token");
                request.Method = "POST";
                request.KeepAlive = true;
                request.AllowAutoRedirect = false;
                request.Accept = "*";
                request.ContentType = "application/json";
                request.Headers.Add("gspappid", "7C64ED016B324DBF9B9D811AE9AC3A7A");
                request.Headers.Add("gspappsecret", "4768421CG01A3G4AE0GA251GB2F999FD28C5");
                string str3 = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();
                gspauthResponse = JsonConvert.DeserializeObject<GspAuthResponse>(str3);
                gspauthResponse.errorStatus = false;
                gspauthResponse.errorMessage = "null";

            }
            catch (Exception exception)
            {
                gspauthResponse.errorStatus = true;
                gspauthResponse.errorMessage = exception.Message;
                //Log.WriteProcessLog("GSTReturns/GetGspAuthToken/Exception:- StackTrace: " + exception.StackTrace + " Message: " + exception.Message);

            }
            return gspauthResponse;
        }

    }
}
