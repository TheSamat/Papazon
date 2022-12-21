using System;

namespace Papazon.Domain
{
    /// <summary>
    /// Продукт 
    /// </summary>
    public class Product    // https://support.google.com/merchants/answer/7052112?hl=ru&ref_topic=6324338#zippy=
    {
        /// <summary>
        /// ID - идентификатор в БД, авто
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Отображаемое название товара / серийное название, 150 символов максимум, обязателен
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// Описание товара, неограничен, необязателен
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Бренд товара, только официальное название на английском, обязателен
        /// </summary>
        public string Brand { get; set; }
        /// <summary>
        /// SKU - складской номер, у каждого постовщика свой, 70 символов максимум, обязателен
        /// </summary>
        public string SKU { get; set; }
        /// <summary>
        /// PN - идентификатор детали/запчасти, 70 символов максимум, не обязателен
        /// </summary>
        public string? PN { get; set; }
        /// <summary>
        /// GTIN - глобальный номер товарной продукции, 14 цифр максимум, обязателен
        /// </summary>
        public string GTIN { get; set; }    // https://support.google.com/merchants/answer/6324461
        /// <summary>
        /// MPN - код производителя товара, 70 символов максимум, обязателен
        /// </summary>
        public string MPN { get; set; } // https://support.google.com/merchants/answer/6324482
        /// <summary>
        /// Цена товара в сомах, обязателен
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Длина товара в см (слева-направо), необязателен
        /// </summary>
        public double? Length { get; set; }
        /// <summary>
        /// Ширина товара в см (спереди-сзади), необязателен
        /// </summary>
        public double? Width { get; set; }
        /// <summary>
        /// Высота товара в см (сверху-вниз), необязателен
        /// </summary>
        public double? Height { get; set; }
        /// <summary>
        /// Вес товара в кг, необязателен
        /// </summary>
        public double? Weight { get; set; }

        /// <summary>
        /// (на рассмотрении) Дата и время поступления, авто
        /// </summary>
        public DateTime? CreateDateTime { get; set; }
        /// <summary>
        /// Дата и время последнего изменения, авто
        /// </summary>
        public DateTime? EditDateTime { get; set; }

        /// <summary>
        /// Статус удаления, по умолчанию false, авто
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Категория, внешний ключ - Id Category, не обязателен
        /// </summary>
        public int? CategoryId { get; set; }
        /// <summary>
        /// Наличие, внешний ключ - Id Availability, не обязателен
        /// </summary>
        public int? Availability { get; set; }  // в наличии, нет в наличии, предзаказ, под заказ
        /// <summary>
        /// Состояние, внешний ключ - Id Condition, не обязателен
        /// </summary>
        public int? Condition { get; set; } // Новый, Восстановленный, Б/у
        /// <summary>
        /// Цвет, внешний ключ - Id Color, не обязателен
        /// </summary>
        public int? Color { get; set; }

        // Имеет связи:
        //  компоненты *-1
        //  изображения *-1
        //  (на рассмотрении) поставки товаров 1-1
        //  продажи 1-1
    }
}
