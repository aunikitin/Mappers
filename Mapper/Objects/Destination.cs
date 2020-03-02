using System;

namespace Mapper.Objects
{
    public class Destination
    {
        /// <summary>
        /// Название "физической" таблицы в БД Generated
        /// </summary>
        public string SchemeName { get; set; }
        /// <summary>
        /// Название для прикладного разработчика
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Системная
        /// </summary>
        public bool IsSystem { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Справочник
        /// </summary>
        public bool IsDirectory { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// Дата изменения
        /// </summary>
        public DateTime ModificationDate { get; set; }
    }
}