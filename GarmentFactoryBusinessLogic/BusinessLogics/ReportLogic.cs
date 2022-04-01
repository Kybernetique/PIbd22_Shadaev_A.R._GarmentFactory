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

        private readonly AbstractSaveToExcel _saveToExcel;

        private readonly AbstractSaveToWord _saveToWord;

        private readonly AbstractSaveToPdf _saveToPdf;

        public ReportLogic(IGarmentStorage garmentStorage, ITextileStorage
        textileStorage, IOrderStorage orderStorage,
        AbstractSaveToExcel saveToExcel, AbstractSaveToWord saveToWord,
        AbstractSaveToPdf saveToPdf)
        {
            _garmentStorage = garmentStorage;
            _textileStorage = textileStorage;
            _orderStorage = orderStorage;
            _saveToExcel = saveToExcel;
            _saveToWord = saveToWord;
            _saveToPdf = saveToPdf;
        }

        // Получение списка компонент с указанием, в каких изделиях используются
        public List<ReportGarmentTextileViewModel> GetGarmentTextile()
        {
            var textiles = _textileStorage.GetFullList();
            var garments = _garmentStorage.GetFullList();
            var list = new List<ReportGarmentTextileViewModel>();
            foreach (var textile in textiles)
            {
                var record = new ReportGarmentTextileViewModel
                {
                    TextileName = textile.TextileName,
                    Garments = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var garment in garments)
                {
                    if (garment.GarmentTextiles.ContainsKey(textile.Id))
                    {
                        record.Garments.Add(new Tuple<string, int>(garment.GarmentName,
                        garment.GarmentTextiles[textile.Id].Item2));
                        record.TotalCount += garment.GarmentTextiles[textile.Id].Item2;
                    }
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

        // Сохранение компонент с указаеним продуктов в файл-Excel
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
    }
}
