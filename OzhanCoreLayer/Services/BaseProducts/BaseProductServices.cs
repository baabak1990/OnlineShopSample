using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OzhanCoreLayer.Utilities.ImageResizer;
using OzhanCoreLayer.Utilities.ImageSecurity;
using OzhanCoreLayer.Utilities.UniqNameGenerator;
using OzhanCoreLayer.ViewModels.BaseProducts;
using OzhanCoreLayer.ViewModels.BaseProducts.Convertor;
using OzhanDataLayer.Context;
using OzhanDomainLayer.Entities.Products.Common;
using OzhanDomainLayer.Entities.Products.Crouses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanCoreLayer.Services.BaseProducts
{
    public class BaseProductServices : IBaseProductServices
    {
        #region Constructor
        private readonly OzhanContext _context;

        public BaseProductServices(OzhanContext context)
        {
            _context = context;
        }
        #endregion
        #region CRUD

        public async Task<ProductCreatOrEditViewModel> Addproduct(ProductCreatOrEditViewModel vm)
        {
            BaseProduct productbase = new BaseProduct();
            #region new detailes productbase.AIOFanHeaders = vm.AIOFanHeaders;
            productbase.RGB = vm.RGB;
            productbase.RamCapacities = vm.RamCapacities;
            productbase.CpuGenerations = vm.CpuGenerations;
            productbase.Chipset = vm.Chipset;
            productbase.M2Prot = vm.M2Prot;
            productbase.M2Protnum = vm.M2Protnum;
            productbase.PCIe3_1 = vm.PCIe3_1;
            productbase.PCIe5_0_16 = vm.PCIe5_0_16;
            productbase.PCIe3_4 = vm.PCIe3_4;
            productbase.Video = vm.Video;
            productbase.AIOFanHeaders = vm.AIOFanHeaders;
            productbase.SubGroup = vm.SubGroup;
            productbase.Title = vm.Title;
            productbase.Price = vm.Price;
            productbase.AudioDescription = vm.AudioDescription;
            productbase.AuraRgbHeader = vm.AuraRgbHeader;
            productbase.Bios = vm.Bios;
            productbase.BlueTooth = vm.BlueTooth;
            productbase.Wireless = vm.Wireless;
            productbase.WifiDescription = vm.WifiDescription;
            productbase.TwentyFourPinPowerConnector = vm.TwentyFourPinPowerConnector;
            productbase.Tags = vm.Tags;
            productbase.BlueToothDescription = vm.BlueToothDescription;
            productbase.CpuDescription = vm.CpuDescription;
            productbase.DisplayDescription = vm.DisplayDescription;
            productbase.DviDescription = vm.DviDescription;
            productbase.ChassisFanHeader = vm.ChassisFanHeader;
            productbase.ClearCmosBottom = vm.ClearCmosBottom;
            productbase.Color = vm.Color;
            productbase.Count = vm.Count;
            productbase.CpuFanHeaders = vm.CpuFanHeaders;
            productbase.CpuGenerations = vm.CpuGenerations;
            productbase.CpuOPTFanHeaders = vm.CpuFanHeaders;
            productbase.CpuType = vm.CpuType;
            productbase.CpuZipCount = vm.CpuZipCount;
            productbase.CreateDate = DateTime.Now;
            productbase.Creator = vm.Creator;
            productbase.CrossFireDescription = vm.CrossFireDescription;
            productbase.CrossFireSupport = vm.CrossFireSupport;
            productbase.DimmRam = vm.DimmRam;
            productbase.DisplayPorts = vm.DisplayPorts;
            productbase.DualChanel = vm.DualChanel;
            productbase.DVIPorts = vm.DVIPorts;
            productbase.HdmiDescription = vm.HdmiDescription;
            productbase.Eight12VPinPowerConnector = vm.Eight12VPinPowerConnector;
            productbase.Format = vm.Format;
            productbase.Four12VPinPowerConnector = vm.Four12VPinPowerConnector;
            productbase.FrontUsb2Gen = vm.FrontUsb2Gen;
            productbase.FrontUsb3_1Gen = vm.FrontUsb3_1Gen;
            productbase.FrontUsb3_2Gen = vm.FrontUsb3_2Gen;
            productbase.SliSupport = vm.SliSupport;
            productbase.IsAvailable = vm.IsAvailable;
            productbase.IsDeleted = vm.IsDeleted;
            productbase.LongDescription = vm.LongDescription;
            productbase.M2Description = vm.M2Description;
            productbase.M2_2Description = vm.M2_2Description;
            productbase.M2_3Description = vm.M2_3Description;
            productbase.M2_4Description = vm.M2_4Description;
            productbase.ModifyDate = vm.ModifyDate;
            productbase.OffSale = vm.OffSale;
            productbase.PCIe3_16 = vm.PCIe3_16;
            productbase.PCIe3_16_0num = vm.PCIe3_16_0num;
            productbase.PCIe3_1_0num = vm.PCIe3_1_0num;
            productbase.PCIe3_4 = vm.PCIe3_4;
            productbase.PCIe3_1 = vm.PCIe3_1;
            productbase.PortLan = vm.PortLan;
            productbase.PortLanDescription = vm.PortLanDescription;
            productbase.RaidDescription = vm.RaidDescription;
            productbase.RaidSupport = vm.RaidSupport;
            productbase.RamCapacities = vm.RamCapacities;
            productbase.RamDescription = vm.RamDescription;
            productbase.RamGeneration = vm.RamGeneration;
            productbase.RearUsb3_1Gen = vm.RearUsb3_1Gen;
            productbase.RearUsb3_2Gen = vm.RearUsb3_2Gen;
            productbase.RearUsb3_2Gen2_2 = vm.RearUsb3_2Gen2_2;
            productbase.RgbPorts = vm.RgbPorts;
            productbase.Sata = vm.Sata;
            productbase.Sata6Gb = vm.Sata6Gb;
            productbase.Sata6Gbnum = vm.Sata6Gbnum;
            productbase.ShortDescription = vm.ShortDescription;
            productbase.SliDescription = vm.SliDescription;
            productbase.Group = vm.Group;
            productbase.CourseGroup = vm.CourseGroup;
            productbase.subCourseGroup = vm.subCourseGroup;
            #endregion
            #region Image and Video
            productbase.ImageName = "Product.jpg";
            if (vm.ProductImg != null && vm.ProductImg.IsImage())
            {
                var path = "";
                if (productbase.ImageName != "Product.jpg")
                {
                    path = Path.Combine(Directory.GetCurrentDirectory() + "wwwroot/AdminPanel/Product/ProductImg" +
                                             productbase.ImageName);
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }

                }
                productbase.ImageName = "pic" + NameGenerator.UniqName() + Path.GetExtension(vm.ProductImg.FileName);
                path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AdminPanel/Product/ProductImg", productbase.ImageName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    vm.ProductImg.CopyTo(stream);
                }
                //Resize Image For Show in Thumb
                ImageReziser reziser = new ImageReziser();
                string Thumbpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AdminPanel/Product/ProductThumb", productbase.ImageName);
                reziser.Image_resize(path, Thumbpath, 150);
            }
            //ToDo Add Video
            if (vm.DemoFile != null)
            {
                var videopath = "";
                if (productbase.Video != "Profile.jpg")
                {
                    videopath = Path.Combine(Directory.GetCurrentDirectory() + "wwwroot/AdminPanel/Product/ProductVideo" +
                                             productbase.Video);
                    if (File.Exists(videopath))
                    {
                        File.Delete(videopath);
                    }

                }
                productbase.Video = "Video" + NameGenerator.UniqName() + Path.GetExtension(vm.DemoFile.FileName);
                videopath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AdminPanel/Product/ProductVideo", productbase.Video);
                using (var stream = new FileStream(videopath, FileMode.Create))
                {
                    vm.DemoFile.CopyTo(stream);
                }
            }
            else
            {
                productbase.Video = "NoVideo";
            }
            #endregion
            await _context.baseProducts.AddAsync(productbase);
            await _context.SaveChangesAsync();
            return productbase.ProductModelToiViewModelCreateOrEdit();

        }

        public Task<ProductCreatOrEditViewModel> Add(ProductCreatOrEditViewModel vm)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductCreatOrEditViewModel> Edit(ProductCreatOrEditViewModel vm)
        {
            throw new NotImplementedException();
        }

        public Task<ProductCreatOrEditViewModel> Find(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductIndexViewModle>> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<SelectListItem> GetAllLeaderGroupes()
        {
            return _context.CourseGroups.Where(c => c.ParentId == null)
               .Select(c => new SelectListItem()
               {
                   Text = c.Title,
                   Value = c.Id.ToString()
               }).ToList();
        }

        public List<SelectListItem> GetAllSubGroupes(int groupId)
        {
            return _context.CourseGroups.Where(c => c.ParentId == groupId)
               .Select(c => new SelectListItem()
               {
                   Text = c.Title,
                   Value = c.Id.ToString()
               }).ToList();
        }

        #endregion
        public Task<bool> IsExist(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseProductVmForShow> ShowForAdminPage(string FilterByTitle = "", int page = 1)
        {
            var product = _context.baseProducts.Select(p => new BaseProductVmForShow()
            {
                Id = p.Id,
                Title = p.Title,
                Group = p.Group,
                SubGroup = p.SubGroup,
                Count = p.Count,
                Price = p.Price,
                OffSale = p.OffSale,
                IsAvailable = p.IsAvailable,
            }
                      ).ToList();
            if (!string.IsNullOrEmpty(FilterByTitle))
            {
                product = _context.baseProducts.Where(p => p.Title.Contains(FilterByTitle)).Select(p => new BaseProductVmForShow()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Group = p.Group,
                    SubGroup = p.SubGroup,
                    Count = p.Count,
                    Price = p.Price,
                    OffSale = p.OffSale,
                    IsAvailable = p.IsAvailable,
                }).ToList();
            }
            int take = 10;
            int skip = (page - 1);
            BaseProductVmForShow list = new BaseProductVmForShow();
            list.CurrentPage = page;
            list.PageCount = product.Count() / take;
            list.ListOfProducts = _context.baseProducts.OrderBy(p => p.Title).Skip(skip).Take(take).ToList();
            return list;
        }

        public async Task<ProductCreatOrEditViewModel> GetProductByID(long id)
        {
            var product = await _context.baseProducts.FindAsync(id);
            return product.ProductModelToiViewModelCreateOrEdit();
        }

        public async Task<List<ShowProductInIndexViewModel>> GetProductForShowInIndex(int pageId = 1, int Status = 1, string Filter = "",
            List<int> selectedGroup = null, string orderbyPrice = "Price",
            double Stratprice = 0, double endPrice = 0, int take = 0)
        {
            if (take == 0)
                take = 20;
            IQueryable<BaseProduct> Result = _context.baseProducts;
            if (!string.IsNullOrWhiteSpace(Filter))
            {
                Result = Result.Where(b => b.Title.Contains(Filter));
            }

            switch (orderbyPrice)
            {
                case "Max":
                    {
                        Result = Result.OrderByDescending(b => b.TotalPrice);
                        break;
                    }
                case "Min":
                    {
                        Result = Result.OrderBy(b => b.TotalPrice);
                        break;
                    }

            }
            //switch (Status)
            //{
            //    case (0):
            //        Result = Result.Where(r => r.IsAvailable == OzhanDomainLayer.Entities.Products.Common.Status.موجود);
            //        break;
            //    case (1):
            //        Result = Result.Where(r => r.IsAvailable == OzhanDomainLayer.Entities.Products.Common.Status.ناموجود);
            //        break;
            //    case (2):
            //        Result = Result.Where(r => r.IsAvailable == OzhanDomainLayer.Entities.Products.Common.Status.بزودی);
            //        break;
            //    default:
            //        Result = Result;
            //        break;
            //}
            if (Stratprice > 0)
            {
                Result = _context.baseProducts.Where(b => b.TotalPrice > Stratprice);
            }

            if (endPrice > 0)
            {
                Result = _context.baseProducts.Where(b => b.TotalPrice < Stratprice);
            }

            if (selectedGroup != null)
            {
                foreach (int item in selectedGroup)
                {
                    Result = Result.Where(b => b.Group == item || b.SubGroup == item);
                }
            }

            int skip = (pageId - 1) * take;
            return await Result.Select(b => new ShowProductInIndexViewModel()
            {
                Id = b.Id,
                Title = b.Title,
                IsAvailable = b.IsAvailable,
                PriceBeforeOff = b.Price,
                TotalPrice = b.TotalPrice,
                ImageName = b.ImageName

            }).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<ProductCreatOrEditViewModel> GetProductForSingleShow(long id)
        {
            var product=await _context.baseProducts.Include(p=>p.CourseGroup).Include(p => p.subCourseGroup).SingleOrDefaultAsync(p=>p.Id==id);
            return product.ProductModelToiViewModelCreateOrEdit();

        }
    }
}
