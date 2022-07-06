using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OzhanCoreLayer.ViewModels.ProductVM;
using OzhanCoreLayer.ViewModels.ProductVM.Convertor;
using OzhanDataLayer.Context;
using OzhanDomainLayer.Entities.Products.Crouses;

namespace OzhanCoreLayer.Services.Products
{
    public class ProductServices : IProductServices
    {
        #region Constructor

        private readonly OzhanContext _context;

        public ProductServices(OzhanContext context)
        {
            _context = context;
        }

        #endregion
        public Task<ProductGroupeCreateOrEdit> Find(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductGroupeCreateOrEdit> Add(ProductGroupeCreateOrEdit vm)
        {
            CourseGroup coures = new CourseGroup();
            coures.ParentId = null;
            coures.Title = vm.Title;
            coures.CreateDate = DateTime.Now;
            await _context.CourseGroups.AddAsync(coures);
            await _context.SaveChangesAsync();
            var newCourse = coures.ConvertToGroupCreateOrEdit();
            return newCourse;

        }
        public async Task<ProductGroupeCreateOrEdit> GetGroupById(int Id)
        {
            var groupe = await _context.CourseGroups.FindAsync(Id);
            if (groupe == null)
            {
                return null;
            }
            return groupe.ConvertToGroupCreateOrEdit();

        }
        public async Task<ProductGroupeCreateOrEdit> Edit(ProductGroupeCreateOrEdit vm)
        {
            var group = await _context.CourseGroups.FindAsync(vm.ID);
            if (group == null)
            {
                return null;
            }
            group.Title = vm.Title;
            group.ModifyDate = DateTime.Now;
            _context.CourseGroups.Update(group);
            await _context.SaveChangesAsync();
            return group.ConvertToGroupCreateOrEdit();

        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductGroupeIndex>> GetAll()
        {

            return await _context.CourseGroups.ConvertToGroupIndex().ToListAsync();

        }

        public Task<bool> IsExist(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductGroupeIndex> ShowLeaderGroups()
        {
            var ProductList = await _context.CourseGroups.Where(p => p.ParentId == null).ConvertToGroupIndex().ToListAsync();
            ProductGroupeIndex index = new ProductGroupeIndex();
            index.ListCourse = _context.CourseGroups.OrderBy(c => c.Title).ToList();
            return index;
        }


    }
}
