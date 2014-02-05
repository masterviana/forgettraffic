namespace ForgetTraffic.FillDatabaseData
{
    internal interface ITableOperation
    {
        void UpdateTableData();
        void FillTableData();
        void DeleteTableData();
    }
}