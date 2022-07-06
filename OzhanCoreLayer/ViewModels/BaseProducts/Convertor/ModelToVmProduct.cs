using OzhanDomainLayer.Entities.Products.Crouses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanCoreLayer.ViewModels.BaseProducts.Convertor
{
    public static class ModelToVmProduct
    {
        public static ProductCreatOrEditViewModel ProductModelToiViewModelCreateOrEdit(this BaseProduct baseProduct)
        {
            return new ProductCreatOrEditViewModel()
            {
                Title = baseProduct.Title,
                AIOFanHeaders = baseProduct.AIOFanHeaders,
                AudioDescription = baseProduct.AudioDescription,
                AuraRgbHeader = baseProduct.AuraRgbHeader,
                Bios = baseProduct.Bios,
                BlueTooth = baseProduct.BlueTooth,
                BlueToothDescription = baseProduct.BlueToothDescription,
                ChassisFanHeader = baseProduct.ChassisFanHeader,
                Chipset = baseProduct.Chipset,
                ClearCmosBottom = baseProduct.ClearCmosBottom,
                Color = baseProduct.Color,
                Count = baseProduct.Count,
                CpuDescription = baseProduct.CpuDescription,
                CpuFanHeaders = baseProduct.CpuFanHeaders,
                CpuGenerations = baseProduct.CpuGenerations,
                CpuOPTFanHeaders = baseProduct.CpuOPTFanHeaders,
                CpuType = baseProduct.CpuType,
                CpuZipCount = baseProduct.CpuZipCount,
                CreateDate = baseProduct.CreateDate,
                Creator = baseProduct.Creator,
                CrossFireDescription = baseProduct.CrossFireDescription,
                CrossFireSupport = baseProduct.CrossFireSupport,
                DimmRam = baseProduct.DimmRam,
                DisplayDescription = baseProduct.DisplayDescription,
                DisplayPorts = baseProduct.DisplayPorts,
                DualChanel = baseProduct.DualChanel,
                DviDescription = baseProduct.DviDescription,
                DVIPorts = baseProduct.DVIPorts,
                Eight12VPinPowerConnector = baseProduct.Eight12VPinPowerConnector,
                Format = baseProduct.Format,
                Four12VPinPowerConnector = baseProduct.Four12VPinPowerConnector,
                FrontUsb2Gen = baseProduct.FrontUsb2Gen,
                FrontUsb3_1Gen = baseProduct.FrontUsb3_1Gen,
                FrontUsb3_2Gen = baseProduct.FrontUsb3_2Gen,
                HdimPorts = baseProduct.HdimPorts,
                HdmiDescription = baseProduct.HdmiDescription,
                Id = baseProduct.Id,
                IsAvailable = baseProduct.IsAvailable,
                IsDeleted = baseProduct.IsDeleted,
                LongDescription = baseProduct.LongDescription,
                M2Description = baseProduct.M2Description,
                M2Prot = baseProduct.M2Prot,
                M2Protnum = baseProduct.M2Protnum,
                M2_2Description = baseProduct.M2_2Description,
                M2_3Description = baseProduct.M2_3Description,
                M2_4Description = baseProduct.M2_4Description,
                ModifyDate = baseProduct.ModifyDate,
                OffSale = baseProduct.OffSale,
                PCIe3_1 = baseProduct.PCIe3_1,
                PCIe3_16 = baseProduct.PCIe3_16,
                PCIe3_16_0num = baseProduct.PCIe3_16_0num,
                PCIe3_1_0num = baseProduct.PCIe3_1_0num,
                PCIe3_4 = baseProduct.PCIe3_4,
                PCIe3_4_0num = baseProduct.PCIe3_4_0num,
                PCIe5_0num = baseProduct.PCIe5_0num,
                PCIe5_0_16 = baseProduct.PCIe5_0_16,
                PortLan = baseProduct.PortLan,
                PortLanDescription = baseProduct.PortLanDescription,
                Price = baseProduct.Price,
                RaidDescription = baseProduct.RaidDescription,
                RaidSupport = baseProduct.RaidSupport,
                RamCapacities = baseProduct.RamCapacities,
                RamDescription = baseProduct.RamDescription,
                RamGeneration = baseProduct.RamGeneration,
                RearUsb3_1Gen = baseProduct.RearUsb3_1Gen,
                RearUsb3_2Gen = baseProduct.RearUsb3_2Gen,
                RearUsb3_2Gen2_2 = baseProduct.RearUsb3_2Gen2_2,
                RGB = baseProduct.RGB,
                RgbDescription = baseProduct.RgbDescription,
                RgbPorts = baseProduct.RgbPorts,
                Sata = baseProduct.Sata,
                Sata6Gb = baseProduct.Sata6Gb,
                Sata6Gbnum = baseProduct.Sata6Gbnum,
                ShortDescription = baseProduct.ShortDescription,
                SliDescription = baseProduct.SliDescription,
                SliSupport = baseProduct.SliSupport,
                Tags = baseProduct.Tags,
                TwentyFourPinPowerConnector = baseProduct.TwentyFourPinPowerConnector,
                WifiDescription = baseProduct.WifiDescription,
                Wireless = baseProduct.Wireless,
                Video = baseProduct.Video,
                Group = baseProduct.Group,
                SubGroup=baseProduct.SubGroup,
                ImagheName=baseProduct.ImageName,
                CourseGroup=baseProduct.CourseGroup,
                subCourseGroup=baseProduct.subCourseGroup


            };
        }

        public static IEnumerable<ProductCreatOrEditViewModel> ProductModelToiViewModelCreateOrEdit(this IEnumerable<BaseProduct> baseProducts)
        {
            return baseProducts.Select(x =>x.ProductModelToiViewModelCreateOrEdit());
        }
        public static IQueryable<ProductCreatOrEditViewModel> ProductModelToiViewModelCreateOrEdit(this IQueryable<BaseProduct> baseProducts)
        {
            return baseProducts.Select(x => x.ProductModelToiViewModelCreateOrEdit());
        }
    }

    public static class ProductIndexModelToViewModel
    {
        public static ProductIndexViewModle ProductModelToIndex(this BaseProduct baseProduct)
        {
            return new ProductIndexViewModle()
            {
              Count = baseProduct.Count,
              Id = baseProduct.Id,
              IsAvailable = baseProduct.IsAvailable,
              OffSale = baseProduct.OffSale,
              Price = baseProduct.Price,
              Title = baseProduct.Title,
              Group = baseProduct.Group,
              SubGroup = baseProduct.SubGroup,
            };
        }

        public static IEnumerable<ProductIndexViewModle> ProductModelToiViewModelCreateOrEdit(this IEnumerable<BaseProduct> baseProducts)
        {
            return baseProducts.Select(x => x.ProductModelToIndex());
        }
        public static IQueryable<ProductIndexViewModle> ProductModelToiViewModelCreateOrEdit(this IQueryable<BaseProduct> baseProducts)
        {
            return baseProducts.Select(x => x.ProductModelToIndex());
        }
    }
}
