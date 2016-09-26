using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GSF.Data;
using GSF.Data.Model;
using GSF.Web.Hubs;
using GSF.Web.Model;
using Microsoft.AspNet.SignalR;
using PQMark.Models;

namespace PQMark
{
    public class DataHub: RecordOperationsHub<DataHub>
    {

        #region [SelectBox Methods]
        public IEnumerable<Company> GetCompanyForSelectBox()
        {
            return DataContext.Table<Company>().QueryRecords(restriction: new RecordRestriction("Benchmark = 0"));
        }

        public IEnumerable<Site> GetSiteForSelectBox(int companyID)
        {
            return DataContext.Table<Site>().QueryRecords(restriction: new RecordRestriction("CompanyID = {0}", companyID));
        }
        #endregion

        #region [SARFI Plot Methods]
        public IEnumerable<SARFI> GetSARFIData(int siteId)
        {
            return DataContext.Table<SARFI>().QueryRecords(restriction: new RecordRestriction("SiteID = {0}", siteId));
        }

        public IEnumerable<SARFI> GetSARFIDataAllSites(int companyId)
        {
            return DataContext.Table<SARFI>().QueryRecords(restriction: new RecordRestriction("SiteID IN (Select ID FROM [Site] WHERE CompanyID IN (SELECT ID FROM Company WHERE Company.ID = {0}))", companyId));
        }

        public IEnumerable<SARFI> GetSARFIBenchmarkData()
        {
            return DataContext.Table<SARFI>().QueryRecords(restriction: new RecordRestriction("SiteID IN (Select ID FROM [Site] WHERE Name Like 'Benchmark')"));
        }

        public IEnumerable<VoltageEnvelope> GetSARFIIndex()
        {
            return DataContext.Table<VoltageEnvelope>().QueryRecords();
        }

        #endregion

    }
}