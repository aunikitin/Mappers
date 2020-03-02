using System;

namespace Mapper.Objects
{
    public class Source
    {
        /// <summary>
        /// Название "физической" таблицы в БД Generated
        /// </summary>
        public string SchemeName { get; set; } = "Test";
        /// <summary>
        /// Название для прикладного разработчика
        /// </summary>
        public string Name { get; set; } = "Test";
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; } = "Test";

        /// <summary>
        /// Системная
        /// </summary>
        public bool IsSystem { get; set; } = true;

        /// <summary>
        /// Статус
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Справочник
        /// </summary>
        public bool IsDirectory { get; set; } = true;
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreationDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Дата изменения
        /// </summary>
        public DateTime ModificationDate { get; set; } = DateTime.Now;
    }
}