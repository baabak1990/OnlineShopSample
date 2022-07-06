using Microsoft.AspNetCore.Http;
using OzhanCoreLayer.Services.GeneralServices;
using OzhanDomainLayer.Entities.Products.Common;
using OzhanDomainLayer.Entities.Products.Crouses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanCoreLayer.ViewModels.BaseProducts
{
    public class ProductCreatOrEditViewModel : ICreateOrEditVM<long>
    {
        #region General Properties

        [Display(Name = "شناسه")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public long Id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(300)]
        public string Title { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]

        public double Price { get; set; }


        [Display(Name = "ویدیو")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(300)]
        public string Video { get; set; }

        [Display(Name = "شرح مختصر")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public string ShortDescription { get; set; }

        [Display(Name = "تخفیف")]

        public double OffSale { get; set; }

        [Display(Name = " قیمت نهایی")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public double TotalPrice
        {

            get
            {
                return Price - OffSale;
            }
        }

        [Display(Name = " توضیحات ")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public string LongDescription { get; set; }

        [Display(Name = " حذف شده است ؟ ")]
        public bool IsDeleted { get; set; }

        [Display(Name = "کلمات کلیدی")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(300)]
        public string Tags { get; set; }

        [Display(Name = "وضعیت ")]
        public Status IsAvailable { get; set; }

        [Display(Name = "تعداد")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public int Count { get; set; }

        [Display(Name = "رنگ")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public Color Color { get; set; }

        [Display(Name = "نور پردازی RGB")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public RGb RGB { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "تاریخ به روز رسانی")]
        public DateTime? ModifyDate { get; set; }
        [Display(Name = "تصویر")]
        public string ImagheName { get; set; }
        #endregion
        #region GeneralAttributes
        [Display(Name = "سازنده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string Creator { get; set; }
        [Display(Name = "چیپ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string Chipset { get; set; }
        [Display(Name = "توع پردازنده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string CpuType { get; set; }
        [Display(Name = "فرمت ساخت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public MotherboardFormat Format { get; set; }
        [Display(Name = "تعداد سوکت پردازنده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public Numbers CpuZipCount { get; set; }
        [Display(Name = "پردازنده های پشتیبانی شده")]

        public CpuGeneration CpuGenerations { get; set; }
        [Display(Name = "توضیحات پردازنده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string CpuDescription { get; set; }
        [Display(Name = "نوع حافظ پشتیبانی شده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public RamGen RamGeneration { get; set; }
        [Display(Name = "حداکثر حافظه رم")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string RamCapacities { get; set; }
        [Display(Name = "پشتیبانی از حالت دو کاناله رم")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DirectAnswer DualChanel { get; set; }
        [Display(Name = "شرح اطلاعات حافظه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string RamDescription { get; set; }
        [Display(Name = "اعداد اسلالت های رم")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public Numbers DimmRam { get; set; }

        #endregion
        #region Graphics
        [Display(Name = "پرت HDMI")]
        public Numbers HdimPorts { get; set; }
        [Display(Name = "توضیحات HDMI")]
        public string HdmiDescription { get; set; }
        [Display(Name = "پرت DVI")]
        public Numbers DVIPorts { get; set; }
        [Display(Name = "توضیحات DVI")]
        public string DviDescription { get; set; }
        [Display(Name = "پرت RGB")]
        public Numbers RgbPorts { get; set; }
        [Display(Name = "توضحیات RGB")]
        public string RgbDescription { get; set; }
        [Display(Name = "پرت DisplayPort")]
        public Numbers DisplayPorts { get; set; }
        [Display(Name = "توضیحات DisplayPort")]
        public string DisplayDescription { get; set; }
        [Display(Name = "پشتیبانی از SLI")]
        public DirectAnswer SliSupport { get; set; }
        [Display(Name = "توضیحات SLI")]
        public string SliDescription { get; set; }
        [Display(Name = "پشتیبانی از CrossFire")]
        public DirectAnswer CrossFireSupport { get; set; }
        [Display(Name = "توضحیات CrossFire")]
        public string CrossFireDescription { get; set; }

        #endregion
        #region Ports
        [Display(Name = "PCle 5.0 *16 ")]
        public DirectAnswer PCIe5_0_16 { get; set; }
        [Display(Name = "PCle 5.0 *16 تعداد")]
        public Numbers PCIe5_0num { get; set; }
        [Display(Name = "PCle 3.0 *16")]
        public DirectAnswer PCIe3_16 { get; set; }
        [Display(Name = "توضیحات PCle 3.0 *16 ")]
        public Numbers PCIe3_16_0num { get; set; }
        [Display(Name = " PCle 3.0 *4 ")]
        public DirectAnswer PCIe3_4 { get; set; }
        [Display(Name = "توضیحات PCle 3.0 *4 ")]
        public Numbers PCIe3_4_0num { get; set; }
        [Display(Name = " PCle 3.0 *1 ")]
        public DirectAnswer PCIe3_1 { get; set; }
        [Display(Name = "توضیحات PCle 3.0 *1 ")]
        public Numbers PCIe3_1_0num { get; set; }
        [Display(Name = "هدر Usb 3.2 2-2")]
        public Numbers RearUsb3_2Gen2_2 { get; set; }
        [Display(Name = "هدر Usb 3.2 2")]
        public Numbers RearUsb3_2Gen { get; set; }
        [Display(Name = "هدر Usb 3.2 1")]
        public Numbers RearUsb3_1Gen { get; set; }
        [Display(Name = "هدر usb3.1 پنل جلو")]
        public Numbers FrontUsb3_1Gen { get; set; }
        [Display(Name = "هدر usb3.2 پنل جلو")]
        public Numbers FrontUsb3_2Gen { get; set; }
        [Display(Name = "هدر usb2 پنل جلو")]
        public Numbers FrontUsb2Gen { get; set; }
        #endregion
        #region IOConnectors
        [Display(Name = "سوکت 4 پین فن")]
        public Numbers CpuFanHeaders { get; set; }
        [Display(Name = "سوکت 4 پین پمپ فن")]
        public Numbers CpuOPTFanHeaders { get; set; }
        [Display(Name = "AIOFanHeaders")]
        public Numbers AIOFanHeaders { get; set; }
        [Display(Name = "ChassisFanHeader")]
        public Numbers ChassisFanHeader { get; set; }
        [Display(Name = "کانکتور 24 پین برق")]
        public Numbers TwentyFourPinPowerConnector { get; set; }
        [Display(Name = "کانکتور 8 پین برق")]
        public Numbers Eight12VPinPowerConnector { get; set; }
        [Display(Name = "کانکتور 4 پین برق")]
        public Numbers Four12VPinPowerConnector { get; set; }
        [Display(Name = "پرت لن")]
        public DirectAnswer PortLan { get; set; }
        [Display(Name = "توضیحات پرت لن")]
        public string PortLanDescription { get; set; }
        [Display(Name = "گیرنده وای فا")]
        public DirectAnswer Wireless { get; set; }
        [Display(Name = "توضیحات گیرنده وای فا")]
        public string WifiDescription { get; set; }
        [Display(Name = "بلوتوث")]
        public DirectAnswer BlueTooth { get; set; }
        [Display(Name = "مشخصات بلوتوث")]
        public string BlueToothDescription { get; set; }
        [Display(Name = "درگاه M2")]
        public DirectAnswer M2Prot { get; set; }
        [Display(Name = "تعداد درگاه M2")]
        public Numbers M2Protnum { get; set; }
        [Display(Name = "پورت ساتا 6 گیگ")]
        public DirectAnswer Sata6Gb { get; set; }
        [Display(Name = "تعداد پورت ساتا 6 گیگ")]
        public Numbers Sata6Gbnum { get; set; }
        [Display(Name = "تعداد پورت ساتا ")]
        public Numbers Sata { get; set; }
        [Display(Name = "هدر AURA RGB")]
        public DirectAnswer AuraRgbHeader { get; set; }
        [Display(Name = "دکمه Clear CMos")]
        public DirectAnswer ClearCmosBottom { get; set; }
        [Display(Name = "مضخصات بایوس")]
        public string Bios { get; set; }


        #endregion
        #region Storage
        [Display(Name = "توضیحات M2")]
        public string M2Description { get; set; }
        [Display(Name = "توضیحات M2_2")]
        public string M2_2Description { get; set; }
        [Display(Name = "توضیحات M2_3")]
        public string M2_3Description { get; set; }
        [Display(Name = "توضیحات M2_4")]
        public string M2_4Description { get; set; }
        [Display(Name = "RAID")]
        public DirectAnswer RaidSupport { get; set; }
        [Display(Name = "توضیحات Raid")]
        public string RaidDescription { get; set; }



        #endregion
        #region Audio
        [Display(Name = "توضیحات کارت صدا")]
        public string AudioDescription { get; set; }

        #endregion
        public int Group { get; set; }
        public int? SubGroup { get; set; }


        public CourseGroup CourseGroup { get; set; }

        public CourseGroup subCourseGroup { get; set; }

        [Required]
        public IFormFile ProductImg { get; set; }
        public IFormFile DemoFile { get; set; }
    }

    public class ProductIndexViewModle : IIndexVm<long>
    {
        #region General Properties

        [Display(Name = "شناسه")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public long Id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(300)]
        public string Title { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]

        public double Price { get; set; }

        [Display(Name = "تخفیف")]

        public double OffSale { get; set; }

        [Display(Name = " قیمت نهایی")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]

        public double TotalPrice
        {

            get
            {
                return Price - OffSale;
            }
        }


        [Display(Name = "وضعیت ")]
        public Status IsAvailable { get; set; }

        [Display(Name = "تعداد")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(200)]
        public int Count { get; set; }

        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public IEnumerable<BaseProduct> ListOfProducts { get; set; }
        #endregion
        public int Group { get; set; }
        public int? SubGroup { get; set; }
    }

    public class BaseProductVmForShow
    {
        [Display(Name = "شناسه")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public long Id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(300)]
        public string Title { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]

        public double Price { get; set; }

        [Display(Name = "تخفیف")]

        public double OffSale { get; set; }

        [Display(Name = " قیمت نهایی")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]

        public double TotalPrice
        {

            get
            {
                return Price - OffSale;
            }
        }
        [Display(Name = "وضعیت ")]
        public Status IsAvailable { get; set; }

        [Display(Name = "تعداد")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(200)]
        public int Count { get; set; }

        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public IEnumerable<BaseProduct> ListOfProducts { get; set; }

        public int Group { get; set; }
        public int? SubGroup { get; set; }
    }

    public class BaseProductSingleShow
    {
        #region General Properties

        [Display(Name = "شناسه")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public long Id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(300)]
        public string Title { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]

        public double Price { get; set; }


        [Display(Name = "ویدیو")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(300)]
        public string Video { get; set; }

        [Display(Name = "شرح مختصر")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public string ShortDescription { get; set; }

        [Display(Name = "تخفیف")]

        public double OffSale { get; set; }

        [Display(Name = " قیمت نهایی")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public double TotalPrice
        {

            get
            {
                return Price - OffSale;
            }
        }

        [Display(Name = " توضیحات ")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public string LongDescription { get; set; }

        [Display(Name = " حذف شده است ؟ ")]
        public bool IsDeleted { get; set; }

        [Display(Name = "کلمات کلیدی")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(300)]
        public string Tags { get; set; }

        [Display(Name = "وضعیت ")]
        public Status IsAvailable { get; set; }

        [Display(Name = "تعداد")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public int Count { get; set; }

        [Display(Name = "رنگ")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public Color Color { get; set; }

        [Display(Name = "نور پردازی RGB")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public RGb RGB { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "تاریخ به روز رسانی")]
        public DateTime? ModifyDate { get; set; }
        [Display(Name = "تصویر")]
        public string ImagheName { get; set; }
        #endregion
        #region GeneralAttributes
        [Display(Name = "سازنده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string Creator { get; set; }
        [Display(Name = "چیپ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string Chipset { get; set; }
        [Display(Name = "توع پردازنده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string CpuType { get; set; }
        [Display(Name = "فرمت ساخت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public MotherboardFormat Format { get; set; }
        [Display(Name = "تعداد سوکت پردازنده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public Numbers CpuZipCount { get; set; }
        [Display(Name = "پردازنده های پشتیبانی شده")]

        public CpuGeneration CpuGenerations { get; set; }
        [Display(Name = "توضیحات پردازنده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string CpuDescription { get; set; }
        [Display(Name = "نوع حافظ پشتیبانی شده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public RamGen RamGeneration { get; set; }
        [Display(Name = "حداکثر حافظه رم")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string RamCapacities { get; set; }
        [Display(Name = "پشتیبانی از حالت دو کاناله رم")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DirectAnswer DualChanel { get; set; }
        [Display(Name = "شرح اطلاعات حافظه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string RamDescription { get; set; }
        [Display(Name = "اعداد اسلالت های رم")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public Numbers DimmRam { get; set; }

        #endregion
        #region Graphics
        [Display(Name = "پرت HDMI")]
        public Numbers HdimPorts { get; set; }
        [Display(Name = "توضیحات HDMI")]
        public string HdmiDescription { get; set; }
        [Display(Name = "پرت DVI")]
        public Numbers DVIPorts { get; set; }
        [Display(Name = "توضیحات DVI")]
        public string DviDescription { get; set; }
        [Display(Name = "پرت RGB")]
        public Numbers RgbPorts { get; set; }
        [Display(Name = "توضحیات RGB")]
        public string RgbDescription { get; set; }
        [Display(Name = "پرت DisplayPort")]
        public Numbers DisplayPorts { get; set; }
        [Display(Name = "توضیحات DisplayPort")]
        public string DisplayDescription { get; set; }
        [Display(Name = "پشتیبانی از SLI")]
        public DirectAnswer SliSupport { get; set; }
        [Display(Name = "توضیحات SLI")]
        public string SliDescription { get; set; }
        [Display(Name = "پشتیبانی از CrossFire")]
        public DirectAnswer CrossFireSupport { get; set; }
        [Display(Name = "توضحیات CrossFire")]
        public string CrossFireDescription { get; set; }

        #endregion
        #region Ports
        [Display(Name = "PCle 5.0 *16 ")]
        public DirectAnswer PCIe5_0_16 { get; set; }
        [Display(Name = "PCle 5.0 *16 تعداد")]
        public Numbers PCIe5_0num { get; set; }
        [Display(Name = "PCle 3.0 *16")]
        public DirectAnswer PCIe3_16 { get; set; }
        [Display(Name = "توضیحات PCle 3.0 *16 ")]
        public Numbers PCIe3_16_0num { get; set; }
        [Display(Name = " PCle 3.0 *4 ")]
        public DirectAnswer PCIe3_4 { get; set; }
        [Display(Name = "توضیحات PCle 3.0 *4 ")]
        public Numbers PCIe3_4_0num { get; set; }
        [Display(Name = " PCle 3.0 *1 ")]
        public DirectAnswer PCIe3_1 { get; set; }
        [Display(Name = "توضیحات PCle 3.0 *1 ")]
        public Numbers PCIe3_1_0num { get; set; }
        [Display(Name = "هدر Usb 3.2 2-2")]
        public Numbers RearUsb3_2Gen2_2 { get; set; }
        [Display(Name = "هدر Usb 3.2 2")]
        public Numbers RearUsb3_2Gen { get; set; }
        [Display(Name = "هدر Usb 3.2 1")]
        public Numbers RearUsb3_1Gen { get; set; }
        [Display(Name = "هدر usb3.1 پنل جلو")]
        public Numbers FrontUsb3_1Gen { get; set; }
        [Display(Name = "هدر usb3.2 پنل جلو")]
        public Numbers FrontUsb3_2Gen { get; set; }
        [Display(Name = "هدر usb2 پنل جلو")]
        public Numbers FrontUsb2Gen { get; set; }
        #endregion
        #region IOConnectors
        [Display(Name = "سوکت 4 پین فن")]
        public Numbers CpuFanHeaders { get; set; }
        [Display(Name = "سوکت 4 پین پمپ فن")]
        public Numbers CpuOPTFanHeaders { get; set; }
        [Display(Name = "AIOFanHeaders")]
        public Numbers AIOFanHeaders { get; set; }
        [Display(Name = "ChassisFanHeader")]
        public Numbers ChassisFanHeader { get; set; }
        [Display(Name = "کانکتور 24 پین برق")]
        public Numbers TwentyFourPinPowerConnector { get; set; }
        [Display(Name = "کانکتور 8 پین برق")]
        public Numbers Eight12VPinPowerConnector { get; set; }
        [Display(Name = "کانکتور 4 پین برق")]
        public Numbers Four12VPinPowerConnector { get; set; }
        [Display(Name = "پرت لن")]
        public DirectAnswer PortLan { get; set; }
        [Display(Name = "توضیحات پرت لن")]
        public string PortLanDescription { get; set; }
        [Display(Name = "گیرنده وای فا")]
        public DirectAnswer Wireless { get; set; }
        [Display(Name = "توضیحات گیرنده وای فا")]
        public string WifiDescription { get; set; }
        [Display(Name = "بلوتوث")]
        public DirectAnswer BlueTooth { get; set; }
        [Display(Name = "مشخصات بلوتوث")]
        public string BlueToothDescription { get; set; }
        [Display(Name = "درگاه M2")]
        public DirectAnswer M2Prot { get; set; }
        [Display(Name = "تعداد درگاه M2")]
        public Numbers M2Protnum { get; set; }
        [Display(Name = "پورت ساتا 6 گیگ")]
        public DirectAnswer Sata6Gb { get; set; }
        [Display(Name = "تعداد پورت ساتا 6 گیگ")]
        public Numbers Sata6Gbnum { get; set; }
        [Display(Name = "تعداد پورت ساتا ")]
        public Numbers Sata { get; set; }
        [Display(Name = "هدر AURA RGB")]
        public DirectAnswer AuraRgbHeader { get; set; }
        [Display(Name = "دکمه Clear CMos")]
        public DirectAnswer ClearCmosBottom { get; set; }
        [Display(Name = "مضخصات بایوس")]
        public string Bios { get; set; }


        #endregion
        #region Storage
        [Display(Name = "توضیحات M2")]
        public string M2Description { get; set; }
        [Display(Name = "توضیحات M2_2")]
        public string M2_2Description { get; set; }
        [Display(Name = "توضیحات M2_3")]
        public string M2_3Description { get; set; }
        [Display(Name = "توضیحات M2_4")]
        public string M2_4Description { get; set; }
        [Display(Name = "RAID")]
        public DirectAnswer RaidSupport { get; set; }
        [Display(Name = "توضیحات Raid")]
        public string RaidDescription { get; set; }



        #endregion
        #region Audio
        [Display(Name = "توضیحات کارت صدا")]
        public string AudioDescription { get; set; }

        #endregion
        public int Group { get; set; }
        public int? SubGroup { get; set; }


        public CourseGroup CourseGroup { get; set; }

        public CourseGroup subCourseGroup { get; set; }
    }
}
