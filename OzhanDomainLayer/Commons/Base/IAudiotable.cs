using System;

namespace OzhanDomainLayer.Commons.Base
{
    public interface IAudioTable
    {
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}