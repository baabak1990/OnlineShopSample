using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzhanDomainLayer.Entities.Products.Crouses;

namespace OzhanCoreLayer.ViewModels.ProductVM.Convertor
{
   public  static class ConvertModelToViewModel
    {
        public static ProductGroupeIndex ConvertToGroupIndex(this CourseGroup group)
        {
            return new ProductGroupeIndex()
            {
                Id = group.Id,
                ParentId = group.ParentId,
                ModifyDate = group.ModifyDate,
                CreateData = group.CreateDate,
                Title = group.Title,
                ISDelete = group.IsDeleted
            };
        }

        public static IQueryable<ProductGroupeIndex> ConvertToGroupIndex(this IQueryable<CourseGroup> groups)
        {
            return groups.Select(g => g.ConvertToGroupIndex());
        }

        public static IEnumerable<ProductGroupeIndex> ConvertToGroupIndex(this IEnumerable<CourseGroup> groups)
        {
            return groups.Select(g => g.ConvertToGroupIndex());
        }
    }

    public static class ConvertModelToViewModelCreateOrEdit
    {
        public static ProductGroupeCreateOrEdit ConvertToGroupCreateOrEdit(this CourseGroup group)
        {
            return new ProductGroupeCreateOrEdit()
            {
             CreateDate=group.CreateDate,
             Title=group.Title,
             ID = group.Id

            };
        }

        public static IEnumerable<ProductGroupeCreateOrEdit> ConvertToGroupCreateOrEdit(this IEnumerable<CourseGroup> groups)
        {
            return groups.Select(g => g.ConvertToGroupCreateOrEdit());
        }
    }
}
