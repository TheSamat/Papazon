ProductConfiguration - класс, представляющий собой конфигурацию Product через Fluent API.

ProductConfiguration реализует интерфейс IEntityTypeConfiguration<Product> из пространства имен
Microsoft.EntityFrameworkCore, позволяющий определить конфигурацию сущности Product в отдельный класс, 
а не в метод OnModelCreated от DBContext, упращая ведение кода.

IEntityTypeConfiguration<T> содержит один метод Configer, реализующий определение конфигурации сущности. Ничего не возвращает, но
при этом принимает EntityTypeBilder<T> из пространства имен Microsoft.Microsoft.EntityFrameworkCore.Metadata.Builders.Builders.
Именно через экземпляры EntityTypeBilder<T> задаются свойства конфигурации сущностей через его методы. 


Вот несколько из них:   //  (p => p.Property) = (Expression<Func<TEntity,Object>>)
    .HasKey(p => p.Property)            -   задает поле и обьявляется первичным ключем
    .HasIndex(p => p.Property)          -   задает индекс
    .HasIndex(..).IsUnique()            -   задает ограничение полю: только уникальные значения
    .HasProperty(p => p.Property)       -   задает поле
    .HasProperty(..).HasMaxLenght(int)  -   задает ограничение полю: максимальный размер по типу поля (для string - varchar)
