using System;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DTO for ProductInfo type
    /// </summary>
    public partial class ProductInfoDto
    {
        /// <summary>
        /// Gets or sets the Product Id.
        /// </summary>
        /// <value>The Product Id.</value>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the Product Code.
        /// </summary>
        /// <value>The Product Code.</value>
        public string ProductCode { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <value>The Name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Product Type Id.
        /// </summary>
        /// <value>The Product Type Id.</value>
        public int ProductTypeId { get; set; }

        /// <summary>
        /// Gets or sets the Unit Cost.
        /// </summary>
        /// <value>The Unit Cost.</value>
        public string UnitCost { get; set; }

        /// <summary>
        /// Gets or sets the Stock Byte Null.
        /// </summary>
        /// <value>The Stock Byte Null.</value>
        public byte? StockByteNull { get; set; }

        /// <summary>
        /// Gets or sets the Stock Byte.
        /// </summary>
        /// <value>The Stock Byte.</value>
        public byte StockByte { get; set; }

        /// <summary>
        /// Gets or sets the Stock Short Null.
        /// </summary>
        /// <value>The Stock Short Null.</value>
        public short? StockShortNull { get; set; }

        /// <summary>
        /// Gets or sets the Stock Short.
        /// </summary>
        /// <value>The Stock Short.</value>
        public short StockShort { get; set; }

        /// <summary>
        /// Gets or sets the Stock Int Null.
        /// </summary>
        /// <value>The Stock Int Null.</value>
        public int? StockIntNull { get; set; }

        /// <summary>
        /// Gets or sets the Stock Int.
        /// </summary>
        /// <value>The Stock Int.</value>
        public int StockInt { get; set; }

        /// <summary>
        /// Gets or sets the Stock Long Null.
        /// </summary>
        /// <value>The Stock Long Null.</value>
        public long? StockLongNull { get; set; }

        /// <summary>
        /// Gets or sets the Stock Long.
        /// </summary>
        /// <value>The Stock Long.</value>
        public long StockLong { get; set; }
    }
}
