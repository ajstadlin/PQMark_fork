using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
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

        #region [PQEvent Plot Methods]
        public IEnumerable<Disturbance> GetPQEventData(int siteId)
        {
            DataTable table = DataContext.Connection.RetrieveData("SELECT * FROM Disturbance WHERE SiteID  IN (SELECT MeterID FROM Site Where ID = {0}) ", siteId);
            return table.Select().Select(row => DataContext.Table<Disturbance>().LoadRecord(row));

        }

        public IEnumerable<Disturbance> GetPQEventDataAllSites(int companyId)
        {
            DataTable table = DataContext.Connection.RetrieveData("SELECT * FROM Disturbance WHERE SiteID IN (Select MeterID FROM [Site] WHERE CompanyID = {0})", companyId);
            return table.Select().Select(row => DataContext.Table<Disturbance>().LoadRecord(row));
        }

        public IEnumerable<VoltageCurvePoint> GetCurves()
        {
            return DataContext.Table<VoltageCurvePoint>().QueryRecords("VoltageCurveID, LoadOrder", restriction: new RecordRestriction("VoltageCurveID IN (SELECT ID FROM VoltageCurve WHERE Name ='ITIC UPPER' OR Name = 'ITIC Lower' OR Name = 'SEMI')"));
        }

        #endregion

        #region [PQEvent 3D Methods]
        public IEnumerable<PQVoltageEvent> GetPQEvent3DData(int siteId)
        {
            DataTable table =  DataContext.Connection.RetrieveData("SELECT Duration.ID AS DurationID, VoltageBin.ID AS VoltageBinID, COALESCE(Temp.[Count],0) as [Count] FROM VoltageBin CROSS JOIN Duration Left JOin (SELECT Count(*) AS[Count], Duration.ID As DurationIndex, VoltageBin.ID AS VoltageIndex FROM Disturbance CROSS JOIN Duration CROSS JOIN VoltageBin WHERE DurationSeconds < Duration.Max AND DurationSeconds >= Duration.Min AND PerUnitMagnitude * 100 >= VoltageBin.Min AND PerUnitMagnitude * 100 < VoltageBin.Max AND SiteID IN (SELECT MeterID FROM Site WHERE ID = {0}) GROUP BY Duration.ID, VoltageBin.ID) Temp ON VoltageBin.id = Temp.VoltageIndex AND Duration.ID = temp.DurationIndex", siteId);
            return table.Select().Select(row => DataContext.Table<PQVoltageEvent>().LoadRecord(row));
        }

        public IEnumerable<PQVoltageEvent> GetPQEvent3DDataAllSites(int companyId)
        {
            DataTable table = DataContext.Connection.RetrieveData("SELECT Duration.ID AS DurationID, VoltageBin.ID AS VoltageBinID, COALESCE(Temp.[Count],0)/(SELECT Count(*) FROM Site WHERE CompanyID = {0}) as [Count] FROM VoltageBin CROSS JOIN Duration Left JOin (SELECT Count(*) AS[Count], Duration.ID As DurationIndex, VoltageBin.ID AS VoltageIndex FROM Disturbance CROSS JOIN Duration CROSS JOIN VoltageBin WHERE DurationSeconds < Duration.Max AND DurationSeconds >= Duration.Min AND PerUnitMagnitude * 100 >= VoltageBin.Min AND PerUnitMagnitude * 100 < VoltageBin.Max AND SiteID IN(Select MeterID FROM[Site] WHERE CompanyID = {1}) GROUP BY Duration.ID, VoltageBin.ID) Temp ON VoltageBin.id = Temp.VoltageIndex AND Duration.ID = temp.DurationIndex", companyId, companyId);
            return table.Select().Select(row => DataContext.Table<PQVoltageEvent>().LoadRecord(row));

        }

        public IEnumerable<Duration> GetDurationBins()
        {
            return DataContext.Table<Duration>().QueryRecords();

        }

        public IEnumerable<VoltageBin> GetVoltageBins()
        {
            return DataContext.Table<VoltageBin>().QueryRecords();

        }



        #endregion


        #region [Voltage THD Methods]
        public List<Dictionary<string, string>> GetVoltageTHDData(int siteId)
        {
            DataTable table = DataContext.Connection.RetrieveData("SELECT * FROM VoltageTHD WHERE ID IN (SELECT MeterID FROM Site WHERE ID = {0})", siteId);
            return table.Select().Select(row =>
            {
                return table.Columns.Cast<DataColumn>().ToDictionary(col => col.ColumnName, col => row[col].ToString());
            }).ToList();
        }

        public List<Dictionary<string, string>> GetVoltageTHDDataAllSites(int companyId)
        {
            DataTable table = DataContext.Connection.RetrieveData("SELECT * FROM VoltageTHD WHERE ID IN (SELECT MeterID FROM Site WHERE CompanyID = {0})", companyId);
            return table.Select().Select(row =>
            {
                return table.Columns.Cast<DataColumn>().ToDictionary(col => col.ColumnName, col => row[col].ToString());
            }).ToList();

        }


        public List<Dictionary<string, string>> GetBenchmarkData()
        {
            DataTable table = DataContext.Connection.RetrieveData("SELECT * FROM VoltageTHD WHERE ID  = 0");
            return table.Select().Select(row =>
            {
                return table.Columns.Cast<DataColumn>().ToDictionary(col => col.ColumnName, col => row[col].ToString());
            }).ToList();
        }


        #endregion

    }
}