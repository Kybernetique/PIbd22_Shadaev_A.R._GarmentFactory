using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.ViewModels;
using System.Collections.Generic;


namespace GarmentFactoryContracts.BusinessLogicsContracts
{
    public interface IReportLogic
    {
        // Получение списка тканей с указанием, в каких швейных изделиях используются
        List<ReportGarmentTextileViewModel> GetGarmentTextile();

        // Получение списка заказов за определенный период
        List<ReportOrdersViewModel> GetOrders(ReportBindingModel model);

        // Получение списка тканей на складах
        List<ReportWarehouseTextileViewModel> GetWarehouseTextiles();

        // Получение списка заказов за определенный период
        List<ReportTotalOrdersViewModel> GetTotalOrders();

        // Сохранение тканей в файл-Word
        void SaveGarmentsToWordFile(ReportBindingModel model);

        // Сохранение складов в файл-Word
        void SaveWarehousesToWordFile(ReportBindingModel model);

        // Сохранение тканей с указаеним швейных изделий в файл-Excel
        void SaveGarmentTextileToExcelFile(ReportBindingModel model);

        // Сохранение компонент с указаеним продуктов в файл-Excel
        void SaveWarehouseTextileToExcelFile(ReportBindingModel model);

        // Сохранение заказов в файл-Pdf
        void SaveOrdersToPdfFile(ReportBindingModel model);

        // Сохранение заказов за весь период в файл-Pdf
        void SaveTotalOrdersToPdfFile(ReportBindingModel model);
    }
}
