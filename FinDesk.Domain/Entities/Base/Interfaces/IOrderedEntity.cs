namespace FinDesk.Domain.Entities.Base.Interfaces
{
    /// <summary>Упорядочиваемая сущность</summary>
    public interface IOrderedEntity: IBaseEntity
    {
        /// <summary>Порядковый номер/// </summary>
        public int Order { get; set; }
    }
}
