using GarmentFactoryBusinessLogic.OfficePackage;
using GarmentFactoryBusinessLogic.OfficePackage.HelperModels;
using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.BusinessLogicsContracts;
using GarmentFactoryContracts.StoragesContracts;
using GarmentFactoryContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GarmentFactoryBusinessLogic.BusinessLogics
{
    public class ReportLogic : IReportLogic
    {
        private readonly ITextileStorage _textileStorage;

        private readonly IGarmentStorage _garmentStorage;

        private readonly IOrderStorage _orderStorage;

        private readonly IWarehouseStorage _warehouseStorage;

        private readonly AbstractSaveToExcel _saveToExcel;

        private readonly AbstractSaveToWord _saveToWord;

        private readonly AbstractSaveToPdf _saveToPdf;

        public ReportLogic(IGarmentStorage garmentStorage, ITextileStorage
        textileStorage, IOrderStorage orderStorage, IWarehouseStorage warehouseStorage,
        AbstractSaveToExcel saveToExcel, AbstractSaveToWord saveToWord,
        AbstractSaveToPdf saveToPdf)
        {
            _garmentStorage = garmentStorage;
            _textileStorage = textileStorage;
            _orderStorage = orderStorage;
            _warehouseStorage = warehouseStorage;
            _saveToExcel = saveToExcel;
            _saveToWord = saveToWord;
            _saveToPdf = saveToPdf;
        }

        // Получение списка тканей с указанием, в каких изделиях используются
        public List<ReportGarmentTextileViewModel> GetGarmentTextile()
        {
            var garments = _garmentStorage.GetFullList();
            var list = new List<ReportGarmentTextileViewModel>();
            foreach (var garment in garments)
            {
                var record = new ReportGarmentTextileViewModel
                {
                    GarmentName = garment.GarmentName,
                    Textiles = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var textile in garment.GarmentTextiles)
                {
                    record.Textiles.Add(new Tuple<string, int>(textile.Value.Item1, textile.Value.Item2));
                    record.TotalCount += textile.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }

        // Получение списка заказов за определенный период
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                GarmentName = x.GarmentName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
            .ToList();
        }

        // Сохранение швейных изделий в файл-Word
        public void SaveGarmentsToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                Garments = _garmentStorage.GetFullList()
            });
        }

        // Сохранение тканей с указаеним продуктов в файл-Excel
        public void SaveGarmentTextileToExcelFile(ReportBindingModel model)
        {
            _saveToExcel.CreateReport(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список тканей",
                GarmentTextiles = GetGarmentTextile()
            });
        }

        // Сохранение заказов в файл-Pdf
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            _saveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }

        public List<ReportWarehouseTextileViewModel> GetWarehouseTextiles()
        {
            var garments = _warehouseStorage.GetFullList();
            var list = new List<ReportWarehouseTextileViewModel>();
            foreach (var garment in garments)
            {
                var record = new ReportWarehouseTextileViewModel
                {
                    WarehouseName = garment.WarehouseName,
                    Textiles = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var textile in garment.WarehouseTextiles)
                {
                    record.Textiles.Add(new Tuple<string, int>(textile.Value.Item1, textile.Value.Item2));
                    record.TotalCount += textile.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }

        public void SaveWarehouseTextileToExcelFile(ReportBindingModel model)
        {
            _saveToExcel.CreateWarehouseReport(new ExcelInfoWarehouses
            {
                FileName = model.FileName,
                Title = "Список тканей складов",
                WarehouseTextiles = GetWarehouseTextiles()
            });
        }

        public void SaveWarehousesToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateWarehouseDoc(new WordInfoWarehouses
            {
                FileName = model.FileName,
                Title = "Список складов",
                Warehouses = _warehouseStorage.GetFullList()
            });
        }

        public List<ReportTotalOrdersViewModel> GetTotalOrders()
        {
            return _orderStorage.GetFullList()
                .GroupBy(order => order.DateCreate.ToLongDateString())
                .Select(rec => new ReportTotalOrdersViewModel
                {
                    DateCreate = Convert.ToDateTime(rec.Key),
                    TotalCount = rec.Count(),
                    TotalSum = rec.Sum(order => order.Sum)
                })
                .ToList();
        }

        public void SaveTotalOrdersToPdfFile(ReportBindingModel model)
        {
            _saveToPdf.CreateDocTotalOrders(new PdfInfoTotalOrders
            {
                FileName = model.FileName,
                Title = "Список заказов за весь период",
                TotalOrders = GetTotalOrders()
            });
        }
    }
}
